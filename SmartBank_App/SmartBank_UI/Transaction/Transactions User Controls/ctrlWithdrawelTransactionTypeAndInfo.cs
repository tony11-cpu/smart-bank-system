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
    public partial class ctrlWithdrawelTransactionTypeAndInfo : UserControl
    {
        public ctrlWithdrawelTransactionTypeAndInfo()
        {
            InitializeComponent();
        }

        private string _accountNumber;
        public static event Action<string> OnAccountNumberChanged;

        public ctrlWithdrawelTransactionTypeAndInfo(string accountNumber)
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

        private void ctrlWithdrawelTransactionTypeAndInfo_Load(object sender, EventArgs e)
        {
            mtbTransactionDate.Text = DateTime.Now.ToString("MM/dd/yyyy/HH:mm:ss");

            if (!string.IsNullOrEmpty(_accountNumber))
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
    }
}
