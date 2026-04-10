using SmartBank;
using SmartBank_BLL;
using SmartBank_UI.Main_Form_UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public frmAddOrUpdateAccount(string accountNumber)
        {
            InitializeComponent();
            _accountNumber = accountNumber;
        }

        public frmAddOrUpdateAccount()
        {
            InitializeComponent();
        }

        private bool _validateCustomer()
        {
            if(ctrlCustomerShortInfo1.Customer == null)
                return false;

            if(!ctrlCustomerShortInfo1.Customer.IsActive)
            {
                MessageBox.Show("The selected customer is inactive. Please select an active customer to proceed.", "Inactive Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void frmAddOrUpdateAccount_Load(object sender, EventArgs e)
        {
            ctrlCustomerShortInfo1.OnCustomerSelected += () => 
            {
                if (_validateCustomer())
                {
                    btnOpenOrUpdateAccount.Enabled = true;
                    btnSavingsAccountType.Enabled = true;
                    nupMinBalance.Enabled = true;
                    nupOpeningBalance.Enabled = true;

                    _loadAutomatedAccountID();

                    lblCustomerNameLiveView.Text = $"{ctrlCustomerShortInfo1.Customer.FirstName} {ctrlCustomerShortInfo1.Customer.LastName}";

                    if (string.IsNullOrEmpty(ctrlCustomerShortInfo1.Customer.ImagePath))
                        pbCustomerPicture.Image = ctrlCustomerShortInfo1.Customer.Gender ? 
                        Properties.Resources.icons8_person_female_skin_type_1_and_2_80 : Properties.Resources.icons8_person_80;
                }
                else
                {
                    btnOpenOrUpdateAccount.Enabled = false;
                    btnSavingsAccountType.Enabled = false;
                    nupMinBalance.Enabled = false;
                    nupOpeningBalance.Enabled = false;
                }
            };

            if (clsAccounts.IsAccountExists(_accountNumber))
            {
                _loadAccountInfo();
                _currentMode = enMode.Update;
                return;
            }

            _currentMode = enMode.Add;
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            lblOpenedByUsername.Text = clsGlobal.ActiveUser.Username;
        }

        private void _loadAccountInfo()
        {
            _selectedAccount = clsAccounts.Find(_accountNumber);
            if (_selectedAccount == null)
            {
                MessageBox.Show("No account found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                lblAddOrUpdate.Text = "Update Account";
                btnOpenOrUpdateAccount.Text = "Update Account";
                lblInforamtionAboutForm.Text = $"You are updating the account information of {_selectedAccount.Customer.FirstName} {_selectedAccount.Customer.LastName}";

                ctrlCustomerShortInfo1.LoadCustomerInfo(_selectedAccount.Customer?.NationalID);
                tbAccountNumber.Text = _selectedAccount.AccountNumber;
                nupMinBalance.Value = _selectedAccount.MinimumBalance;
                nupOpeningBalance.Value = _selectedAccount.Balance;
                lblBalanceLiveView.Text = "$" + _selectedAccount.Balance.ToString("C");
                lblMinBalanceLiveView.Text = "$" + _selectedAccount.MinimumBalance.ToString("C");
                lblAccountTypeLiveView.Text = _selectedAccount.AccountType.ToString();
                lblDate.Text = _selectedAccount.OpenedDate?.ToString("MMMM dd, yyyy") ?? "N/A";
                lblOpenedByUsername.Text = clsUsers.Find(_selectedAccount.CreatedByUserID)?.Username ?? "N/A";
            }
        }

        private void _loadAutomatedAccountID()
        {
            string accountNumber = $"SB-{DateTime.Now.Year}-{ctrlCustomerShortInfo1.Customer.NationalID.Substring(ctrlCustomerShortInfo1.Customer.NationalID.Length - 4)}";
            tbAccountNumber.Text = accountNumber;
            lblAccountNumberLiveView.Text = accountNumber;
        }

        private void btnSavingsAccountType_Click(object sender, EventArgs e)
        {
            lblSavingOrCheckingsAccountType.Text = $"Savings - {(_currentMode == enMode.Update ? "Update Account" : "New Account")}";
            lblAccountTypeLiveView.Text = "Savings";
            lblAccountTypeLiveView.ForeColor = Color.Lime;

            nupMinBalance.Minimum = 500;
            nupMinBalance.Value = nupMinBalance.Value == 0 ? 500 : nupMinBalance.Minimum;
        }

        private void btnCheckingAccountType_Click(object sender, EventArgs e)
        {
            lblSavingOrCheckingsAccountType.Text = $"Checking - {(_currentMode == enMode.Update ? "Update Account" : "New Account")}";
            lblAccountTypeLiveView.Text = "Checking";
            lblAccountTypeLiveView.ForeColor = Color.FromArgb(192, 192, 255);

            nupMinBalance.Minimum = 0;
            nupMinBalance.Value = nupMinBalance.Value == 0 ? 0 : nupMinBalance.Minimum;
        }

        private void nupOpeningBalance_ValueChanged(object sender, EventArgs e) => lblBalanceLiveView.Text = nupOpeningBalance.Value.ToString("C");

        private void nupMinBalance_ValueChanged(object sender, EventArgs e) => lblMinBalanceLiveView.Text = nupMinBalance.Value.ToString("C");

        private void nupMinBalance_Validating(object sender, CancelEventArgs e)
        {
            if (nupMinBalance.Value < nupOpeningBalance.Value * 0.1m)
            {
                e.Cancel = true;
                errorProvider1.SetError(nupMinBalance, "Minimum balance must be at least 10% of the opening balance.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(nupMinBalance, null);
            }
        }

        private void btnOpenOrUpdateAccount_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;
        }
    }
}
