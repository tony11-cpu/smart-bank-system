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

namespace SmartBank_UI.Transaction.Transactions_User_Controls
{
    public partial class ctrlDepositOrWithdrawlTransactionTypeAndInfo : UserControl
    {
        public ctrlDepositOrWithdrawlTransactionTypeAndInfo()
        {
            InitializeComponent();
        }

        public enum enTransactionAction
        {
            Deposit,
            Withdrawl
        }

        public static event Action<string> OnAccountNumberChanged;
        private string _accountNumber;

        private enTransactionAction _formType;
        public enTransactionAction FormType
        {
            get => _formType;
            set
            {
                _formType = value;

                lblDestinationAccountLable.Text = _formType == enTransactionAction.Deposit ? "Destination Account" : "Source Account";
                pbDestinationAccountPic.Image = _formType == enTransactionAction.Deposit ? Properties.Resources.icons8_coin_wallet_48 : Properties.Resources.icons8_withdrawal_24;
                lblDestinationAccountLable.ForeColor = _formType == enTransactionAction.Deposit ? Color.FromArgb(0, 192, 0) : Color.Red;
                pbDepositDetailsPic.Image = _formType == enTransactionAction.Deposit ? Properties.Resources.icons8_up_arrow_38 : Properties.Resources.icons8_down_arrow_38;
                lblDepositeDetails.ForeColor = _formType == enTransactionAction.Deposit ? Color.FromArgb(0, 192, 0) : Color.Red;
                lblAuthorization.ForeColor = _formType == enTransactionAction.Deposit ? Color.FromArgb(0, 192, 0) : Color.Red;
                cbConfirmTransactionFund.Text = _formType == enTransactionAction.Deposit ? "I confirm the deposited funds have been received and counted." : "Sufficient balance confirmed.";
            }
        }

        public ctrlDepositOrWithdrawlTransactionTypeAndInfo(string accountNumber , enTransactionAction formType)
        {
            InitializeComponent();
            _accountNumber = accountNumber;
            FormType = formType;
        }

        private bool _isIdle(TextBox sender) => sender.Tag.ToString().StartsWith("Idle");

        private void tb_Enter(object sender, EventArgs e) => _setTextboxStates((TextBox)sender, _isIdle((TextBox)sender), true);

        private void _setTextboxStates(TextBox textBox, bool idle, bool entering)
        {
            string[] textBoxField = textBox.Tag.ToString().Split('/');
            textBox.Tag = $"{(idle ? "Idle" : "Working")}/{textBoxField[1]}/{textBoxField[2]}";
            textBox.Text = idle ? (entering ? string.Empty : textBoxField[2]) : textBox.Text;
            textBox.ForeColor = entering ? Color.White : Color.DimGray;
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string[] textBoxFields = tb.Tag.ToString().Split('/');
            if (!string.IsNullOrWhiteSpace(tb.Text) && tb.Text.Trim() != textBoxFields[2])
            {
                tb.Tag = $"Working/{textBoxFields[1]}/{textBoxFields[2]}";
                return;
            }

            _setTextboxStates(tb, true, false);
        }

        private void ctrlDepositTransactionTypeAndInfo_Load(object sender, EventArgs e)
        {
            mtbTransactionDate.Text = DateTime.Now.ToString("MM/dd/yyyy/HH:mm:ss");

            if(!string.IsNullOrEmpty(_accountNumber))
            {
                tbAccountNumber.Text = _accountNumber;
                _setTextboxStates(tbAccountNumber, false, true);
                _enableOrDisableTransactionProps(true);
            }
        }

        private void btnLookUp_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbAccountNumber.Text) || _isIdle(tbAccountNumber))
            {
                MessageBox.Show("Please enter a valid account number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OnAccountNumberChanged?.Invoke(tbAccountNumber.Text.Trim());
            _enableOrDisableTransactionProps(true);
        }

        private void _enableOrDisableTransactionProps(bool enable)
        {
            nupAmountInUSD.Enabled = enable;
            tbRemarks.Enabled = enable;
        }

        private void nupAmountInUSD_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = nupAmountInUSD.Value > 0;
            errorProvider1.SetError(nupAmountInUSD, nupAmountInUSD.Value > 0 ? null : "Please enter a valid amount greater than zero.");
        }

        private void cbValidation(object sender, CancelEventArgs e)
        {
            e.Cancel = !cbConfirmTransactionFund.Checked || !cbAccountValid.Checked;
            errorProvider1.SetError(cbConfirmTransactionFund, !cbConfirmTransactionFund.Checked ? "You must confirm the transaction details before proceeding." : null);
            errorProvider1.SetError(cbAccountValid, !cbAccountValid.Checked ? "You must confirm the account details before proceeding." : null);
        }
    }
}
