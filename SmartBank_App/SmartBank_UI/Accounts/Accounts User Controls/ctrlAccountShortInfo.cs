using SmartBank;
using SmartBank_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI.Accounts.Accounts_User_Controls
{
    public partial class ctrlAccountShortInfo : UserControl
    {
        public ctrlAccountShortInfo()
        {
            InitializeComponent();
        }

        public async Task LoadAccount(string accountNumber)
        {
            clsAccounts _currentAccount = await clsAccounts.FindAsync(accountNumber);
            if (_currentAccount == null)
            {
                MessageBox.Show("Failed to load account details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isSavings = _currentAccount.AccountType == clsAccounts.enAccountType.Savings;
            lblAccountName.Text = _currentAccount.AccountNumber;
            lblSavingsOrChecking.Text = _currentAccount.AccountType.ToString();
            lblSavingsOrChecking.ForeColor = isSavings ? Color.FromArgb(0, 200, 0) : Color.Orange;
            pbAccountTypePhoto.Image = isSavings ? Properties.Resources.icons8_wallet_64 : Properties.Resources.icons8_bank_64;
            lblCurrentBalance.Text = $"${_currentAccount.Balance}";
            lblCurrentBalance.ForeColor = _currentAccount.Balance >= 0 ? Color.FromArgb(0, 200, 0) : Color.Red;
            lblMinimunBalance.Text = $"${_currentAccount.MinimumBalance}";
            lblCustomerAccountFullName.Text = $"{_currentAccount.Customer?.FirstName} {_currentAccount.Customer?.LastName}".Trim();
            lblAccountType.Text = lblSavingsOrChecking.Text;
            lblOpenDate.Text = _currentAccount.OpenedDate?.ToShortDateString();
            lblOpenByUsername.Text = (await clsUsers.FindAsync(_currentAccount.CreatedByUserID))?.Username ?? "Unknown";
        }
    }
}
