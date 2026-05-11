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

        public clsAccounts CurrentAccount;
        public async Task LoadAccount(string accountNumber , Action onAccountLoad = null)
        {
            CurrentAccount = await clsAccounts.FindAsync(accountNumber);
            if (CurrentAccount == null)
            {
                MessageBox.Show("Failed to load account details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isSavings = CurrentAccount.AccountType == clsAccounts.enAccountType.Savings;
            lblAccountName.Text = CurrentAccount.AccountNumber;
            lblSavingsOrChecking.Text = CurrentAccount.AccountType.ToString();
            lblSavingsOrChecking.ForeColor = isSavings ? Color.FromArgb(0, 200, 0) : Color.Orange;
            pbAccountTypePhoto.Image = isSavings ? Properties.Resources.icons8_wallet_64 : Properties.Resources.icons8_bank_64;
            lblCurrentBalance.Text = $"${CurrentAccount.Balance}";
            lblCurrentBalance.ForeColor = CurrentAccount.Balance >= 0 ? Color.FromArgb(0, 200, 0) : Color.Red;
            lblMinimunBalance.Text = $"${CurrentAccount.MinimumBalance}";
            lblCustomerAccountFullName.Text = $"{CurrentAccount.Customer?.FirstName} {CurrentAccount.Customer?.LastName}".Trim();
            lblAccountType.Text = lblSavingsOrChecking.Text;
            lblOpenDate.Text = CurrentAccount.OpenedDate?.ToShortDateString();
            lblOpenByUsername.Text = (await clsUsers.FindAsync(CurrentAccount.CreatedByUserID))?.Username ?? "Unknown";
            onAccountLoad?.Invoke();
        }
    }
}
