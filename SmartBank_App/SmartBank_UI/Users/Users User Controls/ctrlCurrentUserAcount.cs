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
            tbFullName.Text = clsGlobal.ActiveUser.FullName;
            tbUsername.Text = clsGlobal.ActiveUser.Username;
            tbCreationDate.Text = clsGlobal.ActiveUser.CreatedDate?.ToString("dd MMMM yyyy") ?? "N/A";

            rbActive.Checked = clsGlobal.ActiveUser.IsActive;
            rbNotActive.Checked = !clsGlobal.ActiveUser.IsActive;
            rbLocked.Checked = clsGlobal.ActiveUser.IsLocked;
            rbNotLocked.Checked = !clsGlobal.ActiveUser.IsLocked;
            rbAdmin.Checked = clsGlobal.ActiveUser.Permissions.PermissionPresenter == enPermissionPresenter.Admin;
            rbManager.Checked = clsGlobal.ActiveUser.Permissions.PermissionPresenter == enPermissionPresenter.Manager;
            rbTeller.Checked = clsGlobal.ActiveUser.Permissions.PermissionPresenter == enPermissionPresenter.Teller;
            rbCustome.Checked = clsGlobal.ActiveUser.Permissions.PermissionPresenter == enPermissionPresenter.Custom;

            if (string.IsNullOrEmpty(clsGlobal.ActiveUser.ImagePath))
                pbUserPhoto.Image = Properties.Resources.icons8_user_50;
            else
                pbUserPhoto.ImageLocation = clsGlobal.ActiveUser.ImagePath;
        }

        private void _loadDGVs()
        {
            dgvUserLoginHistory.DataSource = clsGlobal.ActiveUser.GetUserLoginRecors();

            dgvUserLoginHistory.Columns["Username"].Width = 175;
            dgvUserLoginHistory.Columns["Attempt Date"].Width = 180;
            dgvUserLoginHistory.Columns["Login State"].Width = 200;
        }

        private void ctrlCurrentUserAcount_Load(object sender, EventArgs e)
        {
            _loadCurrentUserData();
            _loadDGVs();
        }

        private void Perform_Click(object sender, EventArgs e)
        {
            return;
        }
    }        
}
