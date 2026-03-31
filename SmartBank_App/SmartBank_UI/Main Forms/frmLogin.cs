using SmartBank;
using SmartBank_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SmartBank_UI.Login
{
    public partial class frmLogin : Form
    {
        private int _userFailedLoginAttempsCounter = 0;
        private string _previouseUsername = string.Empty;

        public frmLogin() => InitializeComponent();

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private enum enErrorState { None, AcountNotFound, InvalidCredentials, AccountLocked, AccountDeactivated }

        private enErrorState _validateUser(clsUsers user, string password)
        {
            return user == null ? enErrorState.AcountNotFound :
                (user.IsLocked ? enErrorState.AccountLocked :
                (!user.IsActive ? enErrorState.AccountDeactivated :
                clsUtil.clsSecurity.Verify(password, user.HashedPassword, user.PasswordSalt) ? enErrorState.None : enErrorState.InvalidCredentials));
        }

        private bool _handleLogin(enErrorState errorState, clsUsers user)
        {
            switch (errorState)
            {
                case enErrorState.AccountLocked:
                    MessageBox.Show("Your account is locked. Please contact support.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                case enErrorState.AccountDeactivated:
                    MessageBox.Show("Your account is deactivated.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                case enErrorState.AcountNotFound:
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                case enErrorState.InvalidCredentials:
                    _userFailedLoginAttempsCounter = tbUsername.Text != _previouseUsername ? 0 : _userFailedLoginAttempsCounter;
                    user.RecordLoginAttemp(false);
                    btnWrongAttempWarning.Visible = true;
                    btnWrongAttempWarning.Text = $"Warning - {++_userFailedLoginAttempsCounter} of 5 attempts used.";
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _checkUserLoginAttemps(user);
                    return false;

                case enErrorState.None:
                    btnWrongAttempWarning.Visible = false;
                    user.RecordLoginAttemp(true);
                    clsGlobal.ActiveUser = user;
                    clsUtil.clsLogger.SaveUserDataToRegistry(user.Username, tbPassword.Text.Trim());
                    _userFailedLoginAttempsCounter = 0;
                    return true;
            }

            return false;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            clsUsers user = clsUsers.Find(tbUsername.Text.Trim());
            if (!_handleLogin(_validateUser(user, tbPassword.Text.Trim()), user))
            {
                _previouseUsername = tbUsername.Text;
                return;
            }

            MessageBox.Show($"Welcome, {user.FullName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            notifyIcon1.Visible = true;
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.ShowBalloonTip(3000, "SmartBank", $"Welcome back, {clsGlobal.ActiveUser.FullName.Split(' ')[0]}!", ToolTipIcon.Info);

            this.Hide();
            frmMain mainForm = new frmMain(this);
            mainForm.ShowDialog();
        }

        private void _checkUserLoginAttemps(clsUsers user)
        {
            if (_userFailedLoginAttempsCounter == clsConfigurations.MaxLoginAttempts)
            {
                user.Lock();
                MessageBox.Show("Your account has been locked due to multiple failed login attempts. Please contact support.", "Account Locked",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            (string Username, string Password) userEntry = clsUtil.clsLogger.ReadUserDataFromRegistry();

            tbPassword.Text = userEntry.Password;
            tbUsername.Text = userEntry.Username;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e) => btnSignIn.Enabled = tbPassword.Text.Length > 0 ? true : false;

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSignIn_Click(null, null);
            }
        }
    }
}
