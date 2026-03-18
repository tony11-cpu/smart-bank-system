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

namespace SmartBank_UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSignOut_Click(object sender, EventArgs e) => this.Close();

        private void _loadUser()
        {
            lblUSerFullName.Text = clsGlobal.ActiveUser.FullName;
            switch(clsGlobal.ActiveUser.Permissions.PermissionPresenter)
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
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _loadUser();
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy - hh:mm tt");
        }
    }
}
