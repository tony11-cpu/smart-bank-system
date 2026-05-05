using SmartBank;
using SmartBank_UI.Login;
using SmartBank_UI.Main_Form_UC;
using SmartBank_UI.Properties;
using SmartBank_UI.System_Config;
using SmartBank_UI.Transaction.Transactions_User_Controls;
using SmartBank_UI.Users;
using SmartBank_UI.Users.Users_User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI
{
    public partial class frmMain : Form
    {
        private Form _frmLogin;
        public frmMain(Form LoginForm)
        {
            InitializeComponent();
            _frmLogin = LoginForm;
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            _signOut();
            this.Close();
        }

        private void _signOut()
        {
            clsGlobal.ActiveUser = null;
            _frmLogin.Show();
            _frmLogin.Activate();
            if (_frmLogin is frmLogin loginForm)
                loginForm.RefreshCountsOnSignOut();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (clsGlobal.ActiveUser != null)
                _signOut();
        }

        private void _showView(UserControl control)
        {
            pMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pMain.Controls.Add(control);
        }

        private void _loadUser()
        {
            lblUSerFullName.Text = clsGlobal.ActiveUser.FullName;
            lblUserRole.Text = clsGlobal.ActiveUser.Permissions.PermissionPresenterString;
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy - hh:mm tt");
            btnUsers.Visible = clsGlobal.ActiveUser.Permissions.Has(clsPermissions.enPermission.CanManageUsers);

            if (string.IsNullOrEmpty(clsGlobal.ActiveUser.ImagePath)) 
                pbUserPhoto.Image = Resources.icons8_user_50;
            else
                pbUserPhoto.ImageLocation = clsGlobal.ActiveUser.ImagePath;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if(LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode) 
                return;

            DayTime.Start();

            _showView(_dashboard);
            _loadUser();

            frmAddOrUpdateUser.OnCurrentUserEdit += _loadUser;
        }

        private void timer1_Tick(object sender, EventArgs e) => lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy - hh:mm tt");

        private ctrlDashboard _dashboard = new ctrlDashboard();
        private void btnDashBoard_Click(object sender, EventArgs e) => _showView(_dashboard);

        private ctrlCustomersMainScreen _customers = new ctrlCustomersMainScreen();
        private void btnCustomers_Click(object sender, EventArgs e) => _showView(_customers);

        private ctrlAccounts _accounts = new ctrlAccounts();
        private void btnAccounts_Click(object sender, EventArgs e) => _showView(_accounts);

        private ctrlUsersMainScreen _users = new ctrlUsersMainScreen();
        private void btnUsers_Click(object sender, EventArgs e) => _showView(_users);

        private ctrlCurrentUserAcount _currentUserAccount = new ctrlCurrentUserAcount();
        private void btnCurrentUserAccount_Click(object sender, EventArgs e) => _showView(_currentUserAccount);

        private ctrlMainSysConfigScreen _configScreen = new ctrlMainSysConfigScreen(); 
        private void btnSystemConfig_Click(object sender, EventArgs e) => _showView(_configScreen);

        private ctrlTransactionsMainScreen _transactions = new ctrlTransactionsMainScreen();
        private void btnTransactions_Click(object sender, EventArgs e) => _showView(_transactions);
    }
}
