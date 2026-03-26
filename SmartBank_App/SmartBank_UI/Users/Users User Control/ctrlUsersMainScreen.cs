using SmartBank;
using SmartBank_BLL;
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

        private string _defaultSearchBarSTR = "Search by name, phone, or last 4 digits of national ID...";
        private List<clsUsers> _allUsers = new List<clsUsers>();

        private void _bindGrid(List<clsUsers> usersView)
        {
            if (usersView == null)
                return;

            dgvUsersData.DataSource = usersView;

            int totalUsers = usersView.Count;
            int ActiveUsers = usersView.Count(n => n.IsActive);

            lblNumberOfUsers.Text = totalUsers.ToString();
            lblNumberOfActiveUsers.Text = ActiveUsers.ToString();
            lblNumberOfLockedUsers.Text = (totalUsers - ActiveUsers).ToString();

            dgvUsersData.Columns["UserID"].Visible = false;
            dgvUsersData.Columns["HashedPassword"].Visible = false;
            dgvUsersData.Columns["PasswordSalt"].Visible = false;
            dgvUsersData.Columns["CreatedDate"].Visible = false;

            dgvUsersData.Columns["Permissions"].HeaderText = "Role";
            dgvUsersData.Columns["IsActive"].HeaderText = "Status";
            dgvUsersData.Columns["LastLoginDate"].HeaderText = "Last login";
            dgvUsersData.Columns["IsLocked"].HeaderText = "Is locked";
            dgvUsersData.Columns["FullName"].HeaderText = "Full name";

            int counter = 0;
            foreach (DataGridViewRow row in dgvUsersData.Rows)
            {
                row.Cells["Permissions"].Value = usersView[counter++].Permissions.PermissionPresenterString;
            }
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

            _bindGrid(_loadUsersList());
        }
    }
}
