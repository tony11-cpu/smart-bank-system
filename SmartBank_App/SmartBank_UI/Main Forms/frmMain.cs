using SmartBank;
using SmartBank_UI.Login;
using SmartBank_UI.Main_Form_UC;
using SmartBank_UI.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Sign out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) 
                return;

            clsGlobal.ActiveUser = null;
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void _showView(UserControl control)
        {
            pMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pMain.Controls.Add(control);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if(LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode) 
                return;

            btnDashBoard_Click(sender, null);
            lblUSerFullName.Text = clsGlobal.ActiveUser.FullName;
            switch (clsGlobal.ActiveUser.Permissions.PermissionPresenter)
            {
                case clsPermissions.enPermissionPresenter.Admin:
                    lblUserRole.Text = "Admin";
                    break;
                case clsPermissions.enPermissionPresenter.Manager:
                    lblUserRole.Text = "Manager";
                    break;
                case clsPermissions.enPermissionPresenter.Teller:
                    lblUserRole.Text = "Teller";
                    break;
                default:
                    lblUserRole.Text = "Custom Permissions";
                    break;
            }

            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy - hh:mm tt");
         }
        
        private ctrlDashboard _dashboard = new ctrlDashboard();
        private void btnDashBoard_Click(object sender, EventArgs e) => _showView(_dashboard);

        private ctrlCustomersMainScreen _customers = new ctrlCustomersMainScreen();
        private void btnCustomers_Click(object sender, EventArgs e) => _showView(_customers);

        private ctrlAccounts _accounts = new ctrlAccounts();
        private void btnAccounts_Click(object sender, EventArgs e) => _showView(_accounts);

        private ctrlUsersMainScreen _users = new ctrlUsersMainScreen();
        private void btnUsers_Click(object sender, EventArgs e)
        {
            if(!clsGlobal.ActiveUser.Permissions.Has(clsPermissions.enPermission.CanManageUsers))
            {
                MessageBox.Show("You do not have permissions to manage users!" , "Access denied!" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                return;
            }

            _showView(_users);
        }
    }
}
