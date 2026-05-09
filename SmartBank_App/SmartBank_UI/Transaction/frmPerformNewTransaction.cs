using SmartBank;
using SmartBank_BLL;
using SmartBank_UI.Transaction.Transactions_User_Controls;
using System;
using System.Drawing;
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
        private string _fromAccountNumber;
        private string _toAccountNumber;

        public frmPerformNewTransaction(string acc, enTransactionType type)
        {
            InitializeComponent();
            _fromAccountNumber = acc;
            _transactionType = type;
        }

        private void btnNewDeposite_Click(object sender, EventArgs e) => LoadForm(enTransactionType.Deposit);
        private void btnNewWithdrawl_Click(object sender, EventArgs e) => LoadForm(enTransactionType.Withdrawl);
        private void btnTransfare_Click(object sender, EventArgs e) => LoadForm(enTransactionType.Transfer);

        private void LoadForm(enTransactionType type)
        {
            LoadControl(type);
            _subscribeToControlEvents();
            SetTransactionLabels(type);

            _transactionType = type;
            lblTransactionTypeAmount.Text = 0.ToString("C");
            lblAccountBalanceAfterTransaction.Text = ctrlAccountShortInfo1.CurrentAccount != null ? ctrlAccountShortInfo1.CurrentAccount.Balance.ToString("C") : 0.ToString("C");
        }

        private void _subscribeToControlEvents()
        {
            if (pMain.Controls[0] is ctrlDepositOrWithdrawalTransactionTypeAndInfo depositControl)
            {
                depositControl.OnAccountNumberChanged += acc => _ = CheckAccount(acc);
                depositControl.OnAmountChanged += (amount, isDeposit) => HandleUpdated(amount, isDeposit);
            }
            else if (pMain.Controls[0] is ctrlTransfareTransactionTypeAndInfo transferControl)
            {
                transferControl.OnFromAccountNumberChanged += acc => _ = CheckAccount(acc);
                transferControl.OnToAccountNumberChanged += acc => _toAccountNumber = acc;
                transferControl.OnAmountChanged += amount => HandleUpdated(amount, false);
            }
        }

        private void SetTransactionLabels(enTransactionType type)
        {
            if (type == enTransactionType.Deposit)
            {
                lblTransactionDetails.Text = "Deposit Details";
                lblTransactionTypeInDetails.Text = "Deposit Amount:";
                lblTransactionTypeAmount.ForeColor = Color.FromArgb(0, 192, 0);
            }
            else if (type == enTransactionType.Withdrawl)
            {
                lblTransactionDetails.Text = "Withdraw Details";
                lblTransactionTypeInDetails.Text = "Withdraw Amount:";
                lblTransactionTypeAmount.ForeColor = Color.Red;
            }
            else if (type == enTransactionType.Transfer)
            {
                lblTransactionDetails.Text = "Transfer Details";
                lblTransactionTypeInDetails.Text = "Transfer Amount:";
                lblTransactionTypeAmount.ForeColor = Color.LightSteelBlue;
            }
        }

        private void LoadControl(enTransactionType type)
        {
            UserControl control;
            if (type == enTransactionType.Deposit) control = new ctrlDepositOrWithdrawalTransactionTypeAndInfo(_fromAccountNumber, ctrlDepositOrWithdrawalTransactionTypeAndInfo.enTransactionAction.Deposit);
            else if (type == enTransactionType.Withdrawl) control = new ctrlDepositOrWithdrawalTransactionTypeAndInfo(_fromAccountNumber, ctrlDepositOrWithdrawalTransactionTypeAndInfo.enTransactionAction.Withdrawal);
            else control = new ctrlTransfareTransactionTypeAndInfo(_fromAccountNumber);

            pMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pMain.Controls.Add(control);
        }

        private async Task CheckAccount(string acc)
        {
            if (!string.IsNullOrEmpty(acc) && !await clsAccounts.IsAccountExistsAsync(acc))
            {
                MessageBox.Show("Invalid account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnPerformTransaction.Enabled = false;
                return;
            }

            _fromAccountNumber = acc;
            await ctrlAccountShortInfo1.LoadAccount(acc);

            clsAccounts account = ctrlAccountShortInfo1.CurrentAccount;

            lblAccountBalanceAfterTransaction.Text = account.Balance.ToString("C");
            lblAccountBalanceAfterTransaction.ForeColor = account.Balance >= 0 ? Color.FromArgb(0, 192, 0) : Color.Red;

            bool closed = account.Status == clsAccounts.enStatus.Closed;
            bool frozen = account.Status == clsAccounts.enStatus.Frozen;
            bool admin = clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Admin;

            if (closed)
            {
                MessageBox.Show("Account is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnPerformTransaction.Enabled = false;
                this.Close();
            }

            if (frozen && !admin)
            {
                MessageBox.Show("Account is frozen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnPerformTransaction.Enabled = false;
                return;
            }

            if (frozen && admin)
                MessageBox.Show("Frozen account (Admin override).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            btnPerformTransaction.Enabled = true;
        }

        private string ApplyRules(decimal amount , bool isDeposit)
        {       
            if (amount <= 0)
                return "Amount must be greater than zero.";
            else if (isDeposit)
                return string.Empty;
            else if (ctrlAccountShortInfo1.CurrentAccount == null)
                return "Please enter a valid account number.";
            else if (amount > ctrlAccountShortInfo1.CurrentAccount.Balance)
                return "Insufficient funds.";

            return string.Empty;
        }

        private async void frmPerformNewTransaction_Load(object sender, EventArgs e)
        {
            LoadForm(_transactionType == enTransactionType.None ? enTransactionType.Deposit : _transactionType);

            if (!string.IsNullOrEmpty(_fromAccountNumber))
                await CheckAccount(_fromAccountNumber);
        }

        private void HandleUpdated(decimal amount, bool isDeposit)
        {
            string msg = ApplyRules(amount , isDeposit);
            bool isValid = string.IsNullOrEmpty(msg);
            btnPerformTransaction.Enabled = isValid;

            if (!isValid)
            {
                MessageBox.Show(msg, "Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Update(amount, isDeposit);
        }

        private void Update(decimal amount, bool isDeposit)
        {
            decimal balance = ctrlAccountShortInfo1.CurrentAccount.Balance;
            lblAccountBalanceAfterTransaction.Text = (isDeposit ? balance + amount : balance - amount).ToString("C");
            lblTransactionTypeAmount.Text = amount.ToString("C");
        }

        private async void btnPerformTransaction_Click(object sender, EventArgs e)
        {
            UserControl uc = pMain.Controls[0] as UserControl;
            if (uc == null || !uc.ValidateChildren()) 
                return;

            try
            {
                clsAccounts account = await clsAccounts.FindAsync(_fromAccountNumber);
                decimal amount = _getCurrentAmount();
                string desc = _getCurrentDescription();
                bool ok = false;

                if (_transactionType == enTransactionType.Transfer)
                {
                    var tc = pMain.Controls[0] as ctrlTransfareTransactionTypeAndInfo;
                    string toAccountNumber = tc?.ToAccountNumber ?? _toAccountNumber;

                    if (toAccountNumber == _fromAccountNumber)
                    {
                        MessageBox.Show("Cannot transfer to the same account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    clsAccounts to = await clsAccounts.FindAsync(toAccountNumber);
                    if (to == null || to.Status != clsAccounts.enStatus.Active) 
                    { 
                        MessageBox.Show("Invalid account");
                        return; 
                    }

                    bool scheduled = tc.ScheduledDate > DateTime.Now;
                    ok = scheduled  ? await account.ScheduleTransferToAsync(to, amount, desc, tc.ScheduledDate) : await account.TransferToAsync(to, amount, desc);
                }
                else
                {
                    ok = _transactionType == enTransactionType.Deposit ? await account.DepositAsync(amount, desc) : await account.WithdrawAsync(amount, desc);
                }

                if (ok) 
                    clsGlobal.FireTransactionCompleted();

                MessageBox.Show(ok ? "Transaction completed successfully." : "Transaction failed.", ok ? "Success" : "Error", MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error); 
            }

            this.Close();
        }

        private decimal _getCurrentAmount()
        {
            if (pMain.Controls[0] is ctrlTransfareTransactionTypeAndInfo tc) return tc.CurrentAmount;
            if (pMain.Controls[0] is ctrlDepositOrWithdrawalTransactionTypeAndInfo dc) return dc.CurrentAmount;
            return 0;
        }

        private string _getCurrentDescription()
        {
            if (pMain.Controls[0] is ctrlTransfareTransactionTypeAndInfo tc) return tc.Description;
            if (pMain.Controls[0] is ctrlDepositOrWithdrawalTransactionTypeAndInfo dc) return dc.Description;
            return null;
        }
    }
}
