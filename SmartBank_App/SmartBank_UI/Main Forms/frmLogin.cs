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
        private DataGridView dgvTodayTransactions;

        public frmLogin()
        {
            InitializeComponent();
            _initTransactionsGrid();
        }

        private void _initTransactionsGrid()
        {
            dgvTodayTransactions = new DataGridView();
            dgvTodayTransactions.Name = "dgvTodayTransactions";
            dgvTodayTransactions.Location = new System.Drawing.Point(490, 450);
            dgvTodayTransactions.Size = new System.Drawing.Size(300, 150);
            dgvTodayTransactions.ReadOnly = true;
            dgvTodayTransactions.AllowUserToAddRows = false;
            dgvTodayTransactions.AllowUserToDeleteRows = false;
            dgvTodayTransactions.MultiSelect = false;
            dgvTodayTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTodayTransactions.BackgroundColor = Color.FromArgb(30, 30, 50);
            dgvTodayTransactions.DefaultCellStyle.ForeColor = Color.White;
            dgvTodayTransactions.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 50);
            dgvTodayTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 90, 150);
            dgvTodayTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTodayTransactions.EnableHeadersVisualStyles = false;
            dgvTodayTransactions.RowHeadersVisible = false;
            dgvTodayTransactions.BorderStyle = BorderStyle.None;
            this.Controls.Add(dgvTodayTransactions);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private enum enErrorState { None, AcountNotFound, InvalidCredentials, AccountLocked, AccountDeactivated }

        private enErrorState _validateUser(clsUsers user, string password)
        {
            return user == null ? enErrorState.AcountNotFound :
                (user.IsLocked ? enErrorState.AccountLocked :
                (!user.IsActive ? enErrorState.AccountDeactivated :
                clsUtil.clsSecurity.Verify(password, user.HashedPassword, user.PasswordSalt) ? enErrorState.None : enErrorState.InvalidCredentials));
        }

        private async Task<bool> _handleLogin(enErrorState errorState, clsUsers user)
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
                    btnWrongAttempWarning.Visible = true;
                    btnWrongAttempWarning.Text = $"Warning - {++_userFailedLoginAttempsCounter} of {(await clsConfigurations.GetConfigValueAsync(clsConfigurations.enConfigKey.MaxLoginAttempts)).Value} attempts used.";
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await _checkUserLoginAttemps(user);
                    await user.RecordLoginAttemptAsync(false);
                    return false;

                case enErrorState.None:
                    btnWrongAttempWarning.Visible = false;
                    clsGlobal.ActiveUser = user;
                    clsUtil.clsLogger.SaveUserDataToRegistry(user.Username, tbPassword.Text.Trim());
                    _userFailedLoginAttempsCounter = 0;
                    await user.RecordLoginAttemptAsync(true);
                    return true;
            }

            return false;
        }
        
        private async Task _signIn()
        {
            clsUsers user = await clsUsers.FindAsync(tbUsername.Text.Trim());
            bool isLoginSuccessful = await _handleLogin(_validateUser(user, tbPassword.Text.Trim()), user);

            if (!isLoginSuccessful)
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

        private async void btnSignIn_Click(object sender, EventArgs e) => await _signIn();

        private async Task _checkUserLoginAttemps(clsUsers user)
        {
            if (_userFailedLoginAttempsCounter == (await clsConfigurations.GetConfigValueAsync(clsConfigurations.enConfigKey.MaxLoginAttempts)).Value)
            {
                bool isLocked = await user.LockAsync();
                if(isLocked)
                {
                    MessageBox.Show("Your account has been locked due to multiple failed login attempts. Please contact support.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("An error occurred while locking your account. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

private async void frmLogin_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            (string Username, string Password) userEntry = clsUtil.clsLogger.ReadUserDataFromRegistry();

            tbPassword.Text = userEntry.Password;
            tbUsername.Text = userEntry.Username;

            await _refreshLiveCounts();
        }

        private async Task _refreshLiveCounts()
        {
            lblNumberActiveAccounts.Text = (await clsAccounts.NumberOfActiveAccountsAsync()).ToString();
            lblNumberTransactionsToday.Text = (await clsTransactionLog.GetAllTransactionsAsync()).Count(n => n.TransactionDate.Date == DateTime.Today).ToString();
        }

        private async void frmLogin_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                await _refreshLiveCounts();
        }

        private void _loadTodayTransactionsToGrid(List<clsTransactionLog> transactions)
        {
            dgvTodayTransactions.DataSource = transactions;
            dgvTodayTransactions.Columns["FromAccount"].HeaderText = "From Account";
            dgvTodayTransactions.Columns["ToAccount"].HeaderText = "To Account";
            dgvTodayTransactions.Columns["TransactionType"].HeaderText = "Type";
            dgvTodayTransactions.Columns["Amount"].HeaderText = "Amount";
            dgvTodayTransactions.Columns["TransactionDate"].HeaderText = "Time";
            dgvTodayTransactions.Columns["Description"].Visible = false;
            dgvTodayTransactions.Columns["UserResponsibleID"].Visible = false;
            dgvTodayTransactions.Columns["TransactionID"].Visible = false;
            dgvTodayTransactions.Columns["IsScheduled"].Visible = false;
            dgvTodayTransactions.Columns["BalanceAfterTransaction"].Visible = false;
            dgvTodayTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTodayTransactions.RowTemplate.Height = 28;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e) => btnSignIn.Enabled = tbPassword.Text.Length > 0 ? true : false;

        private async void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                 await _signIn();
        }
    }
}
