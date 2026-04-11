using SmartBank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartBank.clsPermissions;

namespace SmartBank_UI.Users.Users_User_Controls
{
    public partial class ctrlCurrentUserAcount : UserControl
    {
        public ctrlCurrentUserAcount()
        {
            InitializeComponent();
        }

        private void _loadCurrentUserData()
        {
            lblEditUserMessage.Visible = !clsGlobal.ActiveUser.Permissions.Has(enPermission.CanManageUsers);
            lblUserFullName.Text = $"Hey, {clsGlobal.ActiveUser.FullName}";

            tbFullName.Text = clsGlobal.ActiveUser.FullName;
            tbUsername.Text = clsGlobal.ActiveUser.Username;
            tbCreationDate.Text = clsGlobal.ActiveUser.CreatedDate?.ToString("dd MMMM yyyy") ?? "N/A";

            _loadDefaultbtnImages();

            if (clsGlobal.ActiveUser.IsActive) btnActive.Image = Properties.Resources.icons8_dot_24;
            else btnNotActive.Image = Properties.Resources.icons8_dot_24;

            if(clsGlobal.ActiveUser.IsLocked) btnLocked.Image = Properties.Resources.icons8_dot_24;
            else btnNotLocked.Image= Properties.Resources.icons8_dot_24;

            if(clsGlobal.ActiveUser.Permissions.PermissionPresenter == enPermissionPresenter.Admin) btnAdmin.Image = Properties.Resources.icons8_dot_24;
            else if(clsGlobal.ActiveUser.Permissions.PermissionPresenter == enPermissionPresenter.Manager) btnManager.Image = Properties.Resources.icons8_dot_24;
            else if(clsGlobal.ActiveUser.Permissions.PermissionPresenter == enPermissionPresenter.Teller) btnTeller.Image = Properties.Resources.icons8_dot_24;
            else if(clsGlobal.ActiveUser.Permissions.PermissionPresenter == enPermissionPresenter.Custom) btnCustome.Image = Properties.Resources.icons8_dot_24;

            if (string.IsNullOrEmpty(clsGlobal.ActiveUser.ImagePath)) pbUserPhoto.Image = Properties.Resources.icons8_user_50;
            else pbUserPhoto.ImageLocation = clsGlobal.ActiveUser.ImagePath;
        }

        private void _loadUserLoginsDGV()
        {
            try
            {
                dgvUserLoginHistory.DataSource = clsGlobal.ActiveUser.GetUserLoginRecors();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading login history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvUserLoginHistory.Columns["Attempt Date"].Width = 280;
            dgvUserLoginHistory.Columns["Login State"].Width = 277;
        }

        private void _loadUserTransactionsDGV()
        {
            // Get all transactions the current user has made and display them in the dgvUserTransactions
        }

        private void _loadDefaultbtnImages()
        {
            btnActive.Image = Properties.Resources.icons8_dot_24__1_;
            btnNotLocked.Image = Properties.Resources.icons8_dot_24__1_;
            btnAdmin.Image = Properties.Resources.icons8_dot_24__1_;
            btnManager.Image = Properties.Resources.icons8_dot_24__1_;
            btnTeller.Image = Properties.Resources.icons8_dot_24__1_;
            btnCustome.Image = Properties.Resources.icons8_dot_24__1_;
            btnLocked.Image = Properties.Resources.icons8_dot_24__1_;
            btnNotLocked.Image = Properties.Resources.icons8_dot_24__1_;
        }

        private void ctrlCurrentUserAcount_Load(object sender, EventArgs e)
        {
            _loadCurrentUserData();
            _loadUserLoginsDGV();
            _loadUserTransactionsDGV();

            frmAddOrUpdateUser.OnCurrentUserEdit += _loadCurrentUserData;
        }
    }        
}
