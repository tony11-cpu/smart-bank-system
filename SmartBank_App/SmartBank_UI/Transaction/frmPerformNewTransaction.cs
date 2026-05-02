using SmartBank;
using SmartBank_BLL;
using SmartBank_UI.Transaction.Transactions_User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI.Transaction
{
    public partial class frmPerformNewTransaction : Form
    {
        public enum enTransactionType
        {
            Deposit,
            Withdrawl,
            Transfer,
            None
        }

        private enTransactionType _transactionType;
        private string _accountNumber;
        public frmPerformNewTransaction(string accountNumber, enTransactionType transactionType)
        {
            InitializeComponent();
            _transactionType = transactionType;
            _accountNumber = accountNumber;
        }

        private void btnNewDeposite_Click(object sender, EventArgs e) => _loadTransactionType(enTransactionType.Deposit);

        private void btnNewWithdrawl_Click(object sender, EventArgs e) => _loadTransactionType(enTransactionType.Withdrawl);

        private void btnTransfare_Click(object sender, EventArgs e) => _loadTransactionType(enTransactionType.Transfer);

        private void _loadTransactionType(enTransactionType transactionType)
        {
            _loadTransactionTypeUS(transactionType);

            switch (transactionType)
            {
                case enTransactionType.Deposit:
                    lblTransactionDetails.Text = "Deposit Details";
                    lblTransactionTypeInDetails.Text = "Deposit Amount:";
                    break;

                case enTransactionType.Withdrawl:
                    lblTransactionDetails.Text = "Withdraw Details";
                    lblTransactionTypeInDetails.Text = "Withdraw Amount:";
                    break;

                case enTransactionType.Transfer:
                    lblTransactionDetails.Text = "Transfer Details";
                    lblTransactionTypeInDetails.Text = "Transfer Amount:";
                    break;

                default:
                    _loadTransactionType(enTransactionType.Deposit);
                    break;
            }
        }

        private void _loadTransactionTypeUS(enTransactionType transactionType)
        {
            UserControl control;

            switch (transactionType)
            {
                case enTransactionType.Deposit:
                    control = new ctrlDepositOrWithdrawlTransactionTypeAndInfo(_accountNumber , ctrlDepositOrWithdrawlTransactionTypeAndInfo.enTransactionAction.Deposit);
                    break;
                case enTransactionType.Withdrawl:
                    control = new ctrlDepositOrWithdrawlTransactionTypeAndInfo(_accountNumber , ctrlDepositOrWithdrawlTransactionTypeAndInfo.enTransactionAction.Withdrawl);
                    break;
                case enTransactionType.Transfer:
                    control = new ctrlTransfareTransactionTypeAndInfo(_accountNumber);
                    break;
                default:
                    control = new ctrlDepositOrWithdrawlTransactionTypeAndInfo(_accountNumber, ctrlDepositOrWithdrawlTransactionTypeAndInfo.enTransactionAction.Deposit);
                    break;
            }

            pMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pMain.Controls.Add(control);
        }

        private async void _checkAndLoadAccount(string accountNumber)
        {
            if (!string.IsNullOrEmpty(accountNumber) && !await clsAccounts.IsAccountExistsAsync(accountNumber))
            {
                MessageBox.Show("Account number is invalid.", "Invalid Account Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnPerformTransaction.Enabled = false;
                return;
            }

            await ctrlAccountShortInfo1.LoadAccount(accountNumber);

            if(ctrlAccountShortInfo1.CurrentAccount.Status == clsAccounts.enStatus.Closed)
            {
                MessageBox.Show("Account is closed and cannot perform any type of transaction.", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnPerformTransaction.Enabled = false;
                return;
            }
            else if(ctrlAccountShortInfo1.CurrentAccount.Status == clsAccounts.enStatus.Frozen && clsGlobal.ActiveUser.Permissions.PermissionPresenter != clsPermissions.enPermissionPresenter.Admin)
            {
                MessageBox.Show("Account is frozen and cannot perform any transaction. Please choose another account or call an admin to perform the current transaction.", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnPerformTransaction.Enabled = false;
                return;
            }
            else if(clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Admin && ctrlAccountShortInfo1.CurrentAccount.Status == clsAccounts.enStatus.Frozen)
            {
                MessageBox.Show("Account is frozen but you have admin permissions, so make sure of the transaction your are proccessing very well.", "Frozen Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            btnPerformTransaction.Enabled = true;
        }

        private void frmPerformNewTransaction_Load(object sender, EventArgs e)
        {
            ctrlDepositOrWithdrawlTransactionTypeAndInfo.OnAccountNumberChanged += _checkAndLoadAccount;
            ctrlTransfareTransactionTypeAndInfo.OnFromAccountNumberChanged += _checkAndLoadAccount;

            if(!string.IsNullOrEmpty(_accountNumber))
                _checkAndLoadAccount(_accountNumber);

            _loadTransactionType(_transactionType == enTransactionType.None ? enTransactionType.Deposit : _transactionType);
        }

        private void btnPerformTransaction_Click(object sender, EventArgs e)
        {
            foreach (UserControl control in pMain.Controls)
            {
                if (!control.ValidateChildren())
                {
                    return;
                }
            }
        }
    }
}
