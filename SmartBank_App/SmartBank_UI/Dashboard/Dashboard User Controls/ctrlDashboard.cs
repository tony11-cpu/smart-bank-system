using SmartBank;
using SmartBank_BLL;
using SmartBank_UI.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI
{
    public partial class ctrlDashboard : UserControl
    {
        public ctrlDashboard()
        {
            InitializeComponent();
        }

        private bool _hasPermissionForTransaction(frmPerformNewTransaction.enTransactionType transactionType)
        {
            if (clsGlobal.ActiveUser?.Permissions == null)
                return false;

            switch (transactionType)
            {
                case frmPerformNewTransaction.enTransactionType.Deposit: return clsGlobal.ActiveUser.Permissions.Has(clsPermissions.enPermission.CanDeposit);
                case frmPerformNewTransaction.enTransactionType.Withdrawl: return clsGlobal.ActiveUser.Permissions.Has(clsPermissions.enPermission.CanWithdraw);
                case frmPerformNewTransaction.enTransactionType.Transfer: return clsGlobal.ActiveUser.Permissions.Has(clsPermissions.enPermission.CanTransfer);
                default: return true;
            }
        }

        private async void ctrlDashboard_Load(object sender, EventArgs e)
        {
            if(LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            clsGlobal.OnTransactionCompleted += async () => await _onTransactionCompleted();
            this.VisibleChanged += ctrlDashboard_VisibleChanged;

            lblMorningToUserWithName.Text = $"Good Morning, {clsGlobal.ActiveUser.FullName}. Here is everything you need to start your shift. ";
            await RefreshDashboardData();
        }

        private async Task _onTransactionCompleted()
        {
            if (this.Visible)
                await RefreshDashboardData();
        }

        public async Task RefreshDashboardData()
        {
            lblActiveAccounts.Text = (await clsAccounts.NumberOfActiveAccountsAsync()).ToString();
            await _refreshTransactionWidgets();
        }

        private static bool _isPendingScheduledTransfer(clsTransactionLog transaction) => transaction.IsScheduled && transaction.BalanceBeforeTransaction == transaction.BalanceAfterTransaction;

        private async Task _refreshTransactionWidgets()
        {
            List<clsTransactionLog> transactions = await clsTransactionLog.GetAllTransactionsAsync();

            lblTransactionsToday.Text = transactions.Count(n => n.TransactionDate.Date == DateTime.Today).ToString();
            lblPendingTransfares.Text = transactions.Count(_isPendingScheduledTransfer).ToString();

            if (clsGlobal.ActiveUser == null || !clsGlobal.ActiveUser.UserID.HasValue)
            {
                _bindTransactions(new List<clsTransactionLog>());
                return;
            }

            _bindTransactions(transactions.Where(n => n.UserResponsibleID == clsGlobal.ActiveUser.UserID.Value).ToList());
        }

        private void _bindTransactions(List<clsTransactionLog> transactions)
        {
            dgvRecentTransactions.DataSource = transactions;

            if (dgvRecentTransactions.RowCount <= 0)
                return;

            dgvRecentTransactions.Columns["UserResponsibleID"].Visible = false;
            dgvRecentTransactions.Columns["BalanceAfterTransaction"].Visible = false;

            dgvRecentTransactions.Columns["TransactionType"].HeaderText = "Transaction Type";
            dgvRecentTransactions.Columns["FromAccount"].HeaderText = "From Account";
            dgvRecentTransactions.Columns["ToAccount"].HeaderText = "To Account";
            dgvRecentTransactions.Columns["TransactionDate"].HeaderText = "Date";
            dgvRecentTransactions.Columns["IsScheduled"].HeaderText = "Scheduled";

            dgvRecentTransactions.RowTemplate.Height = 35;
            dgvRecentTransactions.ColumnHeadersHeight = 40;
        }

        private async void ctrlDashboard_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible || LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            await RefreshDashboardData();
        }

        private void btnNewDeposite_Click(object sender, EventArgs e) => _loadTransactionType(frmPerformNewTransaction.enTransactionType.Deposit);

        private void btnNewWithdrawl_Click(object sender, EventArgs e) => _loadTransactionType(frmPerformNewTransaction.enTransactionType.Withdrawl);

        private void btnTransfare_Click(object sender, EventArgs e) => _loadTransactionType(frmPerformNewTransaction.enTransactionType.Transfer);

        private void _loadTransactionType(frmPerformNewTransaction.enTransactionType transactionType)
        {
           if (!_hasPermissionForTransaction(transactionType))
           {
               MessageBox.Show("You do not have permission for this transaction type.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
           }

           frmPerformNewTransaction frm = new frmPerformNewTransaction(string.Empty, transactionType);
           frm.ShowDialog();
        }
    }
}
