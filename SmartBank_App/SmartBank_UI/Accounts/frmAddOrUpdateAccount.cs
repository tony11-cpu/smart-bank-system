using SmartBank;
using SmartBank_BLL;
using SmartBank_UI.Main_Form_UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI.Accounts
{
    public partial class frmAddOrUpdateAccount : Form
    {
        private enum enMode { Add, Update }
        private enMode _currentMode = enMode.Add;
        private string _accountNumber;
        private clsAccounts _selectedAccount;
        private bool? _accountType_Savings = null;

        public frmAddOrUpdateAccount(string accountNumber)
        {
            InitializeComponent();
            _accountNumber = accountNumber;
        }

        public frmAddOrUpdateAccount()
        {
            InitializeComponent();
        }

        private void frmAddOrUpdateAccount_Load(object sender, EventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            ctrlCustomerShortInfo1.OnCustomerSelected += _loadCustomerInfo;
            _selectedAccount = new clsAccounts();
            if (!string.IsNullOrEmpty(_accountNumber) && clsAccounts.IsAccountExists(_accountNumber))
            {
                _currentMode = enMode.Update;
                _loadAccountInfo();
            }
            else
            {
                _currentMode = enMode.Add;
                _setAddModeDefaults();
            }
        }

        private void _setAddModeDefaults()
        {
            lblAddOrUpdate.Text = "Open New Account";
            btnOpenOrUpdateAccount.Text = "Open Account";
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            lblOpenedByUsername.Text = clsGlobal.ActiveUser.Username;

            nupOpeningBalance.Minimum = 0;
            nupOpeningBalance.Maximum = 1000000;

            nupMinBalance.Minimum = 0;
            nupMinBalance.Maximum = 1000000;

            _setControlsEnabled(false);
        }

        private void _setControlsEnabled(bool enabled)
        {
            btnOpenOrUpdateAccount.Enabled = enabled;
            btnSavingsAccountType.Enabled = enabled;
            btnCheckingAccountType.Enabled = enabled;
            nupMinBalance.Enabled = enabled;
            nupOpeningBalance.Enabled = enabled;
        }

        private bool _validateSelectedCustomer()
        {
            if (ctrlCustomerShortInfo1.Customer == null)
                return false;

            if (!ctrlCustomerShortInfo1.Customer.IsActive)
            {
                MessageBox.Show("The selected customer is inactive. Please select an active customer to proceed.", "Inactive Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void _loadCustomerInfo()
        {
            _accountType_Savings = null;
            lblAccountTypeLiveView.Text = "Not Selected";
            errorProvider1.SetError(btnSavingsAccountType, null);
            errorProvider1.SetError(btnCheckingAccountType, null);

            if (_validateSelectedCustomer())
            {
                _setControlsEnabled(true);
                _loadAutomatedAccountID();

                lblCustomerNameLiveView.Text = $"{ctrlCustomerShortInfo1.Customer.FirstName} {ctrlCustomerShortInfo1.Customer.LastName}";

                if (string.IsNullOrEmpty(ctrlCustomerShortInfo1.Customer.ImagePath) || !File.Exists(ctrlCustomerShortInfo1.Customer.ImagePath))
                {
                    pbCustomerPicture.Image = ctrlCustomerShortInfo1.Customer.Gender ? Properties.Resources.icons8_person_female_skin_type_1_and_2_80 : Properties.Resources.icons8_person_80;
                    return;
                }

                pbCustomerPicture.ImageLocation = ctrlCustomerShortInfo1.Customer.ImagePath;
            }
            else
            {
                _setControlsEnabled(false);
                tbAccountNumber.Text = string.Empty;
                lblAccountNumberLiveView.Text = string.Empty;
                lblCustomerNameLiveView.Text = string.Empty;
                pbCustomerPicture.Image = null;
            }
        }

        private void _loadAutomatedAccountID()
        {
            string accountNumber = $"SB-{DateTime.Now.Year}-{ctrlCustomerShortInfo1.Customer.NationalID.Substring(ctrlCustomerShortInfo1.Customer.NationalID.Length - 4)}";
            if (clsAccounts.IsAccountExists(accountNumber))
            {
                int suffix = 1;
                while (clsAccounts.IsAccountExists($"{accountNumber}-{suffix}")) 
                    suffix++;

                accountNumber = $"{accountNumber}-{suffix}";
            }

            tbAccountNumber.Text = accountNumber;
            lblAccountNumberLiveView.Text = accountNumber;
        }

        private void _updateForm()
        {
            lblAddOrUpdate.Text = "Update Account";
            btnOpenOrUpdateAccount.Text = "Update Account";
            lblInforamtionAboutForm.Text = $"You are updating the account information of " + $"{_selectedAccount.Customer.FirstName} {_selectedAccount.Customer.LastName}";

            nupOpeningBalance.Enabled = false;
            btnSavingsAccountType.Enabled = false;
            btnCheckingAccountType.Enabled = false;
        }

        private void _loadAccountInfo()
        {
            _selectedAccount = clsAccounts.Find(_accountNumber);

            if (_selectedAccount == null)
            {
                MessageBox.Show("Account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _updateForm();
            ctrlCustomerShortInfo1.LoadCustomerInfo(_selectedAccount.Customer?.NationalID);

            tbAccountNumber.Text = _selectedAccount.AccountNumber;
            nupOpeningBalance.Value = _selectedAccount.Balance;
            nupMinBalance.Value = _selectedAccount.MinimumBalance;
            lblBalanceLiveView.Text = _selectedAccount.Balance.ToString("C");
            lblMinBalanceLiveView.Text = _selectedAccount.MinimumBalance.ToString("C");
            lblAccountTypeLiveView.Text = _selectedAccount.AccountType.ToString();
            lblDate.Text = _selectedAccount.OpenedDate?.ToString("MMMM dd, yyyy") ?? "N/A";
            lblOpenedByUsername.Text = clsUsers.Find(_selectedAccount.CreatedByUserID)?.Username ?? "N/A";

            _accountType_Savings = _selectedAccount.AccountType == clsAccounts.enAccountType.Savings;
            nupMinBalance.Minimum = _accountType_Savings == true ? 500 : 0;
        }

        private void btnSavingsAccountType_Click(object sender, EventArgs e)
        {
            lblSavingOrCheckingsAccountType.Text = $"Savings — {(_currentMode == enMode.Update ? "Update Account" : "New Account")}";
            lblAccountTypeLiveView.Text = "Savings";
            lblAccountTypeLiveView.ForeColor = Color.Lime;

            nupMinBalance.Minimum = 500;
            nupMinBalance.Value = nupMinBalance.Value < 500 ? 500 : nupMinBalance.Value;

            _accountType_Savings = true;

            errorProvider1.SetError(btnSavingsAccountType, null);
            errorProvider1.SetError(btnCheckingAccountType, null);
        }

        private void btnCheckingAccountType_Click(object sender, EventArgs e)
        {
            lblSavingOrCheckingsAccountType.Text = $"Checking — {(_currentMode == enMode.Update ? "Update Account" : "New Account")}";
            lblAccountTypeLiveView.Text = "Checking";
            lblAccountTypeLiveView.ForeColor = Color.FromArgb(192, 192, 255);

            nupMinBalance.Minimum = 0;
            nupMinBalance.Value = 0;

            _accountType_Savings = false;

            errorProvider1.SetError(btnSavingsAccountType, null);
            errorProvider1.SetError(btnCheckingAccountType, null);
        }

        private void nupOpeningBalance_ValueChanged(object sender, EventArgs e) => lblBalanceLiveView.Text = nupOpeningBalance.Value.ToString("C");

        private void nupMinBalance_ValueChanged(object sender, EventArgs e) => lblMinBalanceLiveView.Text = nupMinBalance.Value.ToString("C");

        private void nupMinBalance_Validating(object sender, CancelEventArgs e)
        {
            if (_accountType_Savings.HasValue && _accountType_Savings.Value && nupMinBalance.Value < 500)
            {
                nupMinBalance.Value = 500;
                nupMinBalance.Minimum = 500;
                errorProvider1.SetError(nupMinBalance, null);
            }
            else if (nupOpeningBalance.Value > 0 && nupMinBalance.Value > nupOpeningBalance.Value)
            {
                e.Cancel = true;
                errorProvider1.SetError(nupMinBalance, "Minimum balance cannot exceed the opening balance.");
            }
            else
            {
                errorProvider1.SetError(nupMinBalance, null);
            }
        }

        private void btnAccountType_Validating(object sender, CancelEventArgs e)
        {
            if (!_accountType_Savings.HasValue)
            {
                e.Cancel = true;
                errorProvider1.SetError(btnSavingsAccountType, "Please select an account type.");
                errorProvider1.SetError(btnCheckingAccountType, "Please select an account type.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(btnSavingsAccountType, null);
                errorProvider1.SetError(btnCheckingAccountType, null);
            }
        }

        private void nupOpeningBalance_Validating(object sender, CancelEventArgs e)
        {
            if (_accountType_Savings.HasValue && _accountType_Savings.Value && nupOpeningBalance.Value < nupMinBalance.Value)
            {
                e.Cancel = true;
                errorProvider1.SetError(nupOpeningBalance, "Open balance cannot be less than the minimum balance.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(nupOpeningBalance, null);
            }
        }

        private void btnOpenOrUpdateAccount_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            _fetchAccountData();
            if (_selectedAccount.Save())
            {
                _updateForm();
                lblSavingOrCheckingsAccountType.Text = $"{(_accountType_Savings.Value ? "Savings" : "Checking")} — Update Account";
                MessageBox.Show($"Account {_selectedAccount.AccountNumber} {(_currentMode == enMode.Add ? "opened" : "updated")} successfully.", "Account Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _currentMode = enMode.Update;
            }
            else
            {
                MessageBox.Show($"Failed to {(_currentMode == enMode.Add ? "open" : "update")} the account. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _fetchAccountData()
        {
            _selectedAccount.AccountNumber = tbAccountNumber.Text;
            _selectedAccount.Customer = ctrlCustomerShortInfo1.Customer;
            _selectedAccount.AccountType = _accountType_Savings.Value ? clsAccounts.enAccountType.Savings : clsAccounts.enAccountType.Checking;
            _selectedAccount.Balance = nupOpeningBalance.Value;
            _selectedAccount.MinimumBalance = nupMinBalance.Value;
            _selectedAccount.CreatedByUserID = clsGlobal.ActiveUser.UserID.Value;
        }
    }
}
