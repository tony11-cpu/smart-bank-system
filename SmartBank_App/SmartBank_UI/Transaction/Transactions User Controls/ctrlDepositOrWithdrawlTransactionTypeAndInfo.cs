using SmartBank_BLL;
using System;
using System.Collections;
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
    public partial class ctrlDepositOrWithdrawalTransactionTypeAndInfo : UserControl
    {
        public event Action<string> OnAccountNumberChanged;
        public event Action<decimal, bool> OnAmountChanged;

        public enum enTransactionAction
        {
            Deposit,
            Withdrawal
        }

        private string _accountNumber;
        private enTransactionAction _formType;

        public decimal CurrentAmount => nupAmountInUSD.Value;
        public string Description => _isIdle(tbRemarks) ? string.Empty : tbRemarks.Text.Trim();

        public enTransactionAction FormType
        {
            get => _formType;
            set
            {
                _formType = value;
                _UpdateUI();
            }
        }

        public ctrlDepositOrWithdrawalTransactionTypeAndInfo(string accountNumber, enTransactionAction formType)
        {
            InitializeComponent();
            _accountNumber = accountNumber;
            FormType = formType;
        }

        private void _UpdateUI()
        {
            bool isDeposit = _formType == enTransactionAction.Deposit;
            Color themeColor = isDeposit ? Color.FromArgb(0, 192, 0) : Color.Red;

            lblDestinationAccountLable.Text = isDeposit ? "Destination Account" : "Source Account";
            lblDestinationAccountLable.ForeColor = themeColor;
            lblDepositeDetails.ForeColor = themeColor;
            lblAuthorization.ForeColor = themeColor;

            pbDestinationAccountPic.Image = isDeposit ? Properties.Resources.icons8_coin_wallet_48 : Properties.Resources.icons8_withdrawal_24;
            pbDepositDetailsPic.Image = isDeposit ? Properties.Resources.icons8_up_arrow_38 : Properties.Resources.icons8_down_arrow_38;

            cbConfirmTransactionFund.Text = isDeposit ? "I confirm the deposited funds have been received and counted." : "Sufficient balance confirmed.";
        }

        private bool _isIdle(TextBox sender) => sender.Tag.ToString().StartsWith("Idle");

        private void tb_Enter(object sender, EventArgs e) => _setTextboxStates((TextBox)sender, _isIdle((TextBox)sender), true);

        private void _setTextboxStates(TextBox textBox, bool idle, bool entering)
        {
            if (textBox.Tag == null) 
                return;

            string[] textBoxField = textBox.Tag.ToString().Split('/');
            if (textBoxField.Length < 3) 
                return;

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
            mtbTransactionDate.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm");

            if (!string.IsNullOrEmpty(_accountNumber))
            {
                tbAccountNumber.Text = _accountNumber;
                _setTextboxStates(tbAccountNumber, false, true);
                _enableOrDisableTransactionProps(true);
            }
        }

        private void btnLookUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAccountNumber.Text) || _isIdle(tbAccountNumber))
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

        private void nupAmountInUSD_Validating(object sender, CancelEventArgs e) => errorProvider1.SetError(nupAmountInUSD, nupAmountInUSD.Value > 0 ? null : "Please enter a valid amount greater than zero.");

        private void nupAmountInUSD_ValueChanged(object sender, EventArgs e) => OnAmountChanged?.Invoke(nupAmountInUSD.Value, _formType == enTransactionAction.Deposit);

        public override bool ValidateChildren()
        {
            bool isValid = base.ValidateChildren();

            if (!cbConfirmTransactionFund.Checked)
            {
                errorProvider1.SetError(cbConfirmTransactionFund, "You must confirm the transaction details.");
                isValid = false;
            }
            else
                errorProvider1.SetError(cbConfirmTransactionFund, null);

            if (!cbAccountValid.Checked)
            {
                errorProvider1.SetError(cbAccountValid, "You must confirm the account details.");
                isValid = false;
            }
            else
                errorProvider1.SetError(cbAccountValid, null);

            return isValid;
        }

        private void tbAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                _setTextboxStates(tbAccountNumber, false , true);
                btnLookUp.PerformClick();
            }
        }
    }
}
