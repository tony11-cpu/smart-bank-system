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

        private enTransactionType transactionType;
        private string accountNumber;

        public frmPerformNewTransaction(string acc, enTransactionType type)
        {
            InitializeComponent();
            accountNumber = acc;
            transactionType = type;
        }

        private void btnNewDeposite_Click(object sender, EventArgs e) => LoadForm(enTransactionType.Deposit);
        private void btnNewWithdrawl_Click(object sender, EventArgs e) => LoadForm(enTransactionType.Withdrawl);
        private void btnTransfare_Click(object sender, EventArgs e) => LoadForm(enTransactionType.Transfer);

        private void LoadForm(enTransactionType type)
        {
            LoadControl(type);
            SetLabels(type);

            lblTransactionTypeAmount.Text = 0.ToString("C");
        }

        private void SetLabels(enTransactionType type)
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
            if (type == enTransactionType.Deposit) control = new ctrlDepositOrWithdrawlTransactionTypeAndInfo(accountNumber, ctrlDepositOrWithdrawlTransactionTypeAndInfo.enTransactionAction.Deposit);
            else if (type == enTransactionType.Withdrawl) control = new ctrlDepositOrWithdrawlTransactionTypeAndInfo(accountNumber, ctrlDepositOrWithdrawlTransactionTypeAndInfo.enTransactionAction.Withdrawl);
            else control = new ctrlTransfareTransactionTypeAndInfo(accountNumber);

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

            await ctrlAccountShortInfo1.LoadAccount(acc);

            clsAccounts account = ctrlAccountShortInfo1.CurrentAccount;

            lblAccountBalanceAfterTransaction.Text = account.Balance.ToString("C");
            lblAccountBalanceAfterTransaction.ForeColor = account.Balance >= 0 ? Color.FromArgb(0 , 192 , 0) : Color.Red;

            bool closed = account.Status == clsAccounts.enStatus.Closed;
            bool frozen = account.Status == clsAccounts.enStatus.Frozen;
            bool admin = clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Admin;

            if (closed)
            {
                MessageBox.Show("Account is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnPerformTransaction.Enabled = false;
                return;
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

        private string ApplyRules(decimal amount, bool isDeposit)
        {
            if (!isDeposit && amount > ctrlAccountShortInfo1.CurrentAccount.Balance)
                return "Insufficient funds.";

            return string.Empty;
        }

        private async void frmPerformNewTransaction_Load(object sender, EventArgs e)
        {
            ctrlDepositOrWithdrawlTransactionTypeAndInfo.OnAccountNumberChanged += acc => _ = CheckAccount(acc);
            ctrlTransfareTransactionTypeAndInfo.OnFromAccountNumberChanged += acc => _ = CheckAccount(acc);
            ctrlDepositOrWithdrawlTransactionTypeAndInfo.OnAmountChanged += (amount, isDeposit) => HandleUpdated(amount, isDeposit);
            ctrlTransfareTransactionTypeAndInfo.OnAmountChanged += amount => HandleUpdated(amount, false);

            if (!string.IsNullOrEmpty(accountNumber))
                await CheckAccount(accountNumber);

            LoadForm(transactionType == enTransactionType.None ? enTransactionType.Deposit : transactionType);
        }

        private void HandleUpdated(decimal amount, bool isDeposit)
        {
            string msg = ApplyRules(amount, isDeposit);
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

        private void btnPerformTransaction_Click(object sender, EventArgs e)
        {
            foreach (UserControl c in pMain.Controls)
                if (!c.ValidateChildren())
                    return;


        }
    }
}