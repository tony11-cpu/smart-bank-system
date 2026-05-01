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
            Withdraw,
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

        private void btnNewWithdrawl_Click(object sender, EventArgs e) => _loadTransactionType(enTransactionType.Withdraw);

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

                case enTransactionType.Withdraw:
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
                    control = new ctrlDepositTransactionTypeAndInfo(_accountNumber);
                    break;
                case enTransactionType.Withdraw:
                    control = new ctrlWithdrawelTransactionTypeAndInfo(_accountNumber);
                    break;
                case enTransactionType.Transfer:
                    control = new ctrlTransfareTransactionTypeAndInfo(_accountNumber);
                    break;
                default:
                    control = new ctrlDepositTransactionTypeAndInfo(_accountNumber);
                    break;
            }

            pMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pMain.Controls.Add(control);
        }

        private async void _onAccountNumberLoad(string accountNumber) => await ctrlAccountShortInfo1.LoadAccount(accountNumber);

        private async void frmPerformNewTransaction_Load(object sender, EventArgs e)
        {
            ctrlDepositTransactionTypeAndInfo.OnAccountNumberChanged += _onAccountNumberLoad;
            ctrlWithdrawelTransactionTypeAndInfo.OnAccountNumberChanged += _onAccountNumberLoad;
            ctrlTransfareTransactionTypeAndInfo.OnFromAccountNumberChanged += _onAccountNumberLoad;

            if (!string.IsNullOrEmpty(_accountNumber))
                await ctrlAccountShortInfo1.LoadAccount(_accountNumber);

            _loadTransactionType(_transactionType == enTransactionType.None ? enTransactionType.Deposit : _transactionType);
        }
    }
}
