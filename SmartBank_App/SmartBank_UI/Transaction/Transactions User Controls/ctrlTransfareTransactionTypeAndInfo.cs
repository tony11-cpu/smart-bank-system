using SmartBank_BLL;
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
        public event Action<decimal> OnAmountChanged;
        public event Action<string> OnFromAccountNumberChanged;
        public event Action<string> OnToAccountNumberChanged;

        public decimal CurrentAmount => nupAmountInUSD.Value;
        public string Description => _isIdle(tbRefrenceOrRemark) ? string.Empty : tbRefrenceOrRemark.Text.Trim();
        public string ToAccountNumber => _isIdle(tbToAccountNumber) ? string.Empty : tbToAccountNumber.Text.Trim();
        public DateTime ScheduledDate => DateTime.TryParse(mtbTransactionDate.Text, out DateTime date) ? date : DateTime.Now;

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
            mtbTransactionDate.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm");

            if (!string.IsNullOrEmpty(_accountNumber))
            {
                tbFromAccountNumber.Text = _accountNumber;
                _setTextboxStates(tbFromAccountNumber, false, true);
                _enableOrDisableTransactionProps(true);
            }

            cbScheduleTransfare.SelectedIndex = 0;
            cbPriority.SelectedIndex = 0;
        }

        private void btnFromAccountLookUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFromAccountNumber.Text) || _isIdle(tbFromAccountNumber))
            {
                MessageBox.Show("Please enter a valid account number to transfer from.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _accountNumber = tbFromAccountNumber.Text.Trim();
            OnFromAccountNumberChanged?.Invoke(_accountNumber);
            _enableOrDisableTransactionProps(true);
        }

        private void btnLookUpToAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbToAccountNumber.Text) || _isIdle(tbToAccountNumber))
            {
                MessageBox.Show("Please enter a valid account number to transfer to.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fromAccountNumber = _isIdle(tbFromAccountNumber) ? _accountNumber : tbFromAccountNumber.Text.Trim();
            if (!string.IsNullOrWhiteSpace(fromAccountNumber) && tbToAccountNumber.Text.Trim() == fromAccountNumber)
            {
                tbToAccountNumber.Text = string.Empty;
                _setTextboxStates(tbToAccountNumber, true, false);
                MessageBox.Show("Cannot transfer to the same account.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OnToAccountNumberChanged?.Invoke(tbToAccountNumber.Text.Trim());

            frmAccountShortInfo toAccountInfo = new frmAccountShortInfo(tbToAccountNumber.Text, () => MessageBox.Show("Account Found!", "To Account Found", MessageBoxButtons.OK, MessageBoxIcon.Information));
            toAccountInfo.ShowDialog();
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

        private async void tbAccountNumber_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (_isIdle(textBox))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox, "Please enter a valid account number.");
                return;
            }

            string accountNumber = textBox.Text.Trim();
            if (!await clsAccounts.IsAccountExistsAsync(accountNumber))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox, "The account number does not exist.");
                return;
            }

            if (textBox == tbToAccountNumber && !_isIdle(tbFromAccountNumber) && accountNumber == tbFromAccountNumber.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox, "Cannot transfer to the same account.");
                return;
            }

            e.Cancel = false;
            errorProvider1.SetError(textBox, null);
        }

        private void nupAmountInUSD_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = nupAmountInUSD.Value <= 0;
            errorProvider1.SetError(nupAmountInUSD, nupAmountInUSD.Value <= 0 ? "Please enter a valid amount greater than zero." : null);
        }

        private void mtbTransactionDate_Validating(object sender, CancelEventArgs e)
        {
            bool isInvalidDate = string.IsNullOrEmpty(mtbTransactionDate.Text) || !DateTime.TryParse(mtbTransactionDate.Text, out _);
            e.Cancel = isInvalidDate;
            errorProvider1.SetError(mtbTransactionDate, isInvalidDate ? "Please enter a valid transaction date and time." : null);
        }

        private void cbScheduleTransfare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbScheduleTransfare.SelectedIndex >= 0)
                mtbTransactionDate.Text = DateTime.Now.AddHours(cbScheduleTransfare.SelectedIndex * 3).ToString("MM/dd/yyyy HH:mm");
        }

        private void nupAmountInUSD_ValueChanged(object sender, EventArgs e) => OnAmountChanged?.Invoke(nupAmountInUSD.Value);

        private void tbAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
                return;

            if (sender is TextBox textBox)
            {
                _setTextboxStates(textBox, false, true);

                if (textBox == tbFromAccountNumber)
                    btnFromAccountLookUp.PerformClick();
                else if (textBox == tbToAccountNumber)
                    btnLookUpToAccount.PerformClick();

                return;
            }

            (sender as Button)?.PerformClick();
        }
    }
}
