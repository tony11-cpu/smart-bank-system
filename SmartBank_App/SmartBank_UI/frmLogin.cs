using SmartBank;
using SmartBank_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartBank_BLL.clsUtil.clsSecurity;

namespace SmartBank_UI.Login
{
    public partial class frmLogin : Form
    {
        private int _userFailedLoginAttempsCounter = 1;

        public frmLogin() => InitializeComponent();

        private enum enErrorState { None, AcountNotFound, InvalidCredentials, AccountLocked, AccountDeactivated }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void btnShowPassword_Click(object sender, EventArgs e) => tbPassword.PasswordChar = tbPassword.PasswordChar == default ? '*' : default;

        private enErrorState _validateUser(clsUsers user , string password)
        {
            if (user == null) return enErrorState.AcountNotFound;
            if (user.IsLocked) return enErrorState.AccountLocked;
            if (!user.IsActive) return enErrorState.AccountDeactivated;
            if (!clsUtil.clsSecurity.Verify(password, user.HashedPassword, user.PasswordSalt)) return enErrorState.InvalidCredentials;

            return enErrorState.None;
        }

        private bool _handleLogin(enErrorState errorState, clsUsers user)
        {
            switch (errorState)
            {
                case enErrorState.InvalidCredentials:
                    user.RecordLoginAttemp(false);
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnWrongAttempWarning.Visible = true;
                    btnWrongAttempWarning.Text = $"Warning - {_userFailedLoginAttempsCounter++} of 5 attempts used.";
                    _checkUserLoginAttemps(user);
                    return false;

                case enErrorState.AccountLocked:
                    MessageBox.Show("Your account is locked. Please contact support.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                case enErrorState.AccountDeactivated:
                    MessageBox.Show("Your account is deactivated.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                case enErrorState.AcountNotFound:
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                case enErrorState.None:
                    user.RecordLoginAttemp(true);
                    MessageBox.Show($"Welcome, {user.FullName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }

            return false;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            clsUsers user = clsUsers.Find(tbUsername.Text.Trim());

            if (!_handleLogin(_validateUser(user, tbPassword.Text.Trim()), user))
                return;

            // Log To Win Reg For Automatic Login Before Showing Main Form...
            frmMain mainForm = new frmMain(user);
            mainForm.Show();
        }

        private void _checkUserLoginAttemps(clsUsers user)
        {
            if (_userFailedLoginAttempsCounter == clsConfigurations.MaxLoginAttempts)
            {
                user.Lock();
                MessageBox.Show("Your account has been locked due to multiple failed login attempts. Please contact support.","Account Locked", 
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
