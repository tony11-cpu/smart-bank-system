using SmartBank_UI.Accounts;
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
    public partial class ctrlTransfareTransactionTypeAndInfo : UserControl
    {
        public ctrlTransfareTransactionTypeAndInfo()
        {
            InitializeComponent();
        }

        private string _accountNumber;
        public static event Action<string> OnFromAccountNumberChanged;

        public ctrlTransfareTransactionTypeAndInfo(string accountNumber)
        {
            InitializeComponent();
            _accountNumber = accountNumber;
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

        private void ctrlTransfareTransactionTypeAndInfo_Load(object sender, EventArgs e)
        {
            mtbTransactionDate.Text = DateTime.Now.ToString("MM/dd/yyyy/HH:mm:ss");

            if (!string.IsNullOrEmpty(_accountNumber))
            {
                tbFromAccountNumber.Text = _accountNumber;
                _setTextboxStates(tbFromAccountNumber, false, true);
                _enableOrDisableTransactionProps(true);
            }
        }

        private void btnFromAccountLookUp_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbFromAccountNumber.Text) || _isIdle(tbFromAccountNumber))
            {
                MessageBox.Show("Please enter a valid account number to transfer from.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OnFromAccountNumberChanged?.Invoke(tbFromAccountNumber.Text);
            _enableOrDisableTransactionProps(true);
        }

        private void btnLookUpToAccount_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbToAccountNumber.Text) || _isIdle(tbToAccountNumber))
            {
                MessageBox.Show("Please enter a valid account number to transfer to.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAccountShortInfo toAccountInfo = new frmAccountShortInfo(tbToAccountNumber.Text , () => MessageBox.Show("Account Found!" , "To Account Found" , MessageBoxButtons.OK , MessageBoxIcon.Information));
            toAccountInfo.Show();
        }

        private void _enableOrDisableTransactionProps(bool enable)
        {
            tbToAccountNumber.Enabled = enable;
            btnLookUpToAccount.Enabled = enable;
            tbRefrenceOrRemark.Enabled = enable;
            cbPriority.Enabled = enable;
            cbScheduleTransfare.Enabled = enable;
            nupAmountInUSD.Enabled = enable;
            mtbTransactionDate.Enabled = enable;
        }

        private void tbAccountNumber_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
