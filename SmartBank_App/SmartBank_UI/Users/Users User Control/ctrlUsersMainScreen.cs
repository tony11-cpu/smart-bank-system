using SmartBank;
using SmartBank_BLL;
using SmartBank_UI.Main_Form_UC;
using SmartBank_UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI.Users
{
    public partial class ctrlUsersMainScreen : UserControl
    {
        public ctrlUsersMainScreen()
        {
            InitializeComponent();
        }

        private List<clsUsers> _allUsers = new List<clsUsers>();
        private clsUsers _currentUser = null;

        private void _bindGridToMainUsersDGV(List<clsUsers> usersView)
        {
            if (usersView == null) return;

            dgvUsersData.DataSource = usersView;

            lblNumberOfUsers.Text = usersView.Count.ToString();
            lblNumberOfActiveUsers.Text = usersView.Count(n => n.IsActive).ToString();
            lblNumberOfLockedUsers.Text = usersView.Count(n => n.IsLocked).ToString();

            dgvUsersData.Columns["UserID"].Visible = false;
            dgvUsersData.Columns["HashedPassword"].Visible = false;
            dgvUsersData.Columns["PasswordSalt"].Visible = false;
            dgvUsersData.Columns["CreatedDate"].Visible = false;
            dgvUsersData.Columns["CreatedByUserUsername"].Visible = false;
            dgvUsersData.Columns["ImagePath"].Visible = false;

            dgvUsersData.Columns["LastLoginDate"].HeaderText = "Last login";
            dgvUsersData.Columns["LastLoginDate"].Width = 155;
            dgvUsersData.Columns["FullName"].HeaderText = "Full name";
            dgvUsersData.Columns["FullName"].Width = 200;
            dgvUsersData.Columns["Permissions"].HeaderText = "Role";
            dgvUsersData.Columns["IsActive"].HeaderText = "Status";
            dgvUsersData.Columns["IsLocked"].HeaderText = "Is locked";            
        }

        private void _reloadCurrentUserLoginHistory()
        {
            if (_currentUser == null) return;

            dgvUserLoginHistory.DataSource = _currentUser.GetUserLoginRecors();
            dgvUserLoginHistory.Columns["Username"].Width = 155;
            dgvUserLoginHistory.Columns["Attempt Date"].Width = 155;
        }

        private List<clsUsers> _loadUsersList()
        {
            _allUsers = clsUsers.GetAllUsers();
            return _allUsers;
        }

        private void ctrlUsersMainScreen_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            _bindGridToMainUsersDGV(_loadUsersList());
            _reloadCurrentUserLoginHistory();
        }

        private void tbSearchBar_EnterLeave(object sender, EventArgs e)
        {
            string tbFilterTag = tbSearchBar.Tag.ToString().Trim();
            tbSearchBar.Text = tbSearchBar.Focused && tbSearchBar.Text == tbFilterTag ? string.Empty :
                !tbSearchBar.Focused && string.IsNullOrWhiteSpace(tbSearchBar.Text) ? tbFilterTag : tbSearchBar.Text;

            tbSearchBar.ForeColor = tbSearchBar.Text == tbFilterTag ? Color.DimGray : Color.White;
        }

        private void tbSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchBar.Text) || tbSearchBar.Text == tbSearchBar.Tag.ToString())
            {
                _bindGridToMainUsersDGV(_allUsers);
                return;
            }

            string textFilter = tbSearchBar.Text.Trim();
            _bindGridToMainUsersDGV(_allUsers.Where(n =>
            {
                return n.Username.StartsWith(textFilter) ||
                       n.FullName.StartsWith(textFilter) ||
                       n.Permissions.PermissionPresenterString.StartsWith(textFilter);
            }).ToList());
        }

        private void btnAllFilter_Click(object sender, EventArgs e) => _bindGridToMainUsersDGV(_allUsers);

        private void btnDeactivatedFilter_Click(object sender, EventArgs e) => _bindGridToMainUsersDGV(_allUsers.Where(n => !n.IsActive).ToList());

        private void btnActiveFilter_Click(object sender, EventArgs e) => _bindGridToMainUsersDGV(_allUsers.Where(n => n.IsActive).ToList());

        private void dgvUsersData_CellClick(object sender, DataGridViewCellEventArgs e) => _loadUserFromDGV();

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e) => _loadUserFromDGV();

        private void _loadUserFromDGV()
        {
            if (dgvUsersData.Rows.Count > 0)
            {
                _loadUserInfo(dgvUsersData.CurrentRow.Cells["Username"].Value.ToString());
                if (_currentUser != null)
                {
                    btnActivate.Visible = !_currentUser.IsActive;
                    btnDeactivate.Visible = _currentUser.IsActive;
                    activateToolStripMenuItem.Enabled = !_currentUser.IsActive;
                    deactivateCustomerToolStripMenuItem.Enabled = _currentUser.IsActive;

                    _reloadCurrentUserLoginHistory();
                }
            }
        }

        private void _loadUserInfo(string username)
        {
            _currentUser = clsUsers.Find(username);

            if(_currentUser == null)
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(_currentUser.ImagePath))
                pbUserImage.Image = Resources.icons8_user_50;
            else
                pbUserImage.ImageLocation = _currentUser.ImagePath;

            tbUsername.Text = _currentUser.Username;
            tbUserFullName.Text = _currentUser.FullName;
            tbAccountCreatedDay.Text = _currentUser.CreatedDate.HasValue ? _currentUser.CreatedDate.Value.ToShortDateString() : "N/A";
            tbLastLoginDate.Text = _currentUser.LastLoginDate.HasValue ? _currentUser.LastLoginDate.Value.ToString() : "No login record for this user yet.";
            tbCreatedByUsername.Text = _currentUser.CreatedByUserUsername;
            lblUserName.Text = _currentUser.FullName.Split(' ')[0] + " -- Details";

            btnActivate.Visible = !_currentUser.IsActive;
            btnDeactivate.Visible = _currentUser.IsActive;
        }

        private void DeactivateUser_Click(object sender, EventArgs e)
        {
            if (_checkUserStates(_currentUser, true) == enUserStatesError.ReadyToDeactivate
                && MessageBox.Show("Are you sure you want to deactivate this user?", "Confirm Deactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if(_currentUser.UserID == clsGlobal.ActiveUser.UserID)
                {
                    MessageBox.Show("User is already in use and cannot be deactivated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_currentUser.Deactivate())
                {
                    _bindGridToMainUsersDGV(_loadUsersList());
                    btnDeactivate.Visible = false;
                    btnActivate.Visible = true;
                    MessageBox.Show("user deactivated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error while deactivating user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (_checkUserStates(_currentUser, false) == enUserStatesError.ReadyToActivate
               && MessageBox.Show("Are you sure you want to activate this user?", "Confirm activation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_currentUser.Activate())
                {
                    _bindGridToMainUsersDGV(_loadUsersList());
                    btnDeactivate.Visible = true;
                    btnActivate.Visible = false;
                    MessageBox.Show("User activated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error while activating user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private enum enUserStatesError { RecordNotExists = 1, UserAlreadyActive = 2, UserAlreadyInActive = 3, ReadyToDeactivate = 4, ReadyToActivate = 5 }

        private enUserStatesError _checkUserStates(clsUsers user, bool deactivation)
        {
            if (user == null)
            {
                MessageBox.Show("User not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return enUserStatesError.RecordNotExists;
            }

            if (!user.IsActive && deactivation)
            {
                MessageBox.Show("User is already inactive!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return enUserStatesError.UserAlreadyInActive;
            }

            if (user.IsActive && !deactivation)
            {
                MessageBox.Show("Customer is already active!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return enUserStatesError.UserAlreadyActive;
            }

            return deactivation ? enUserStatesError.ReadyToDeactivate : enUserStatesError.ReadyToActivate;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateUser frm = new frmAddOrUpdateUser();
            frm.OnNewUserAdded += _loadUserInfo;
            frm.ShowDialog();
            _bindGridToMainUsersDGV(_loadUsersList());
        }

        private void EditUserInfo_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("User is not exist!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddOrUpdateUser frm = new frmAddOrUpdateUser(_currentUser.Username);
            frm.OnNewUserAdded += _loadUserInfo;
            frm.ShowDialog();
            _bindGridToMainUsersDGV(_loadUsersList());
        }
    }
}
