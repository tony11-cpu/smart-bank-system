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
        private sealed class clsFraudFlagView
        {
            public string Flag { get; set; }
            public string Details { get; set; }
            public string Date { get; set; }
            public string Status { get; set; }
        }

        private readonly Timer _liveRefreshTimer;
        private bool _isRefreshing = false;

        public ctrlDashboard()
        {
            InitializeComponent();
            _liveRefreshTimer = new Timer()
            {
                Interval = 5000
            };
            _liveRefreshTimer.Tick += _liveRefreshTimer_Tick;
            this.Disposed += (s, e) =>
            {
                clsGlobal.OnTransactionCompleted -= _onTransactionCompleted;
                _liveRefreshTimer.Dispose();
            };
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

            clsGlobal.OnTransactionCompleted += _onTransactionCompleted;
            this.VisibleChanged += ctrlDashboard_VisibleChanged;

            dgvRecentTransactions.RowTemplate.Height = 35;
            dgvRecentTransactions.ColumnHeadersHeight = 40;
            dgvFraudFlags.RowTemplate.Height = 35;
            dgvFraudFlags.ColumnHeadersHeight = 40;
            dgvFraudFlags.AllowUserToAddRows = false;
            dgvFraudFlags.AllowUserToDeleteRows = false;
            dgvFraudFlags.ReadOnly = true;
            dgvFraudFlags.MultiSelect = false;
            dgvFraudFlags.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            lblMorningToUserWithName.Text = $"Good Morning, {clsGlobal.ActiveUser.FullName}. Here is everything you need to start your shift. ";
            await _refreshDashboardDataSafely();
            _liveRefreshTimer.Start();
        }

        private async void _onTransactionCompleted()
        {
            await _refreshDashboardDataSafely();
        }

        public async Task RefreshDashboardData()
        {
            lblActiveAccounts.Text = (await clsAccounts.NumberOfActiveAccountsAsync()).ToString();
            await _refreshTransactionWidgets();
            await _refreshFraudWidgets();
        }

        private static bool _isPendingScheduledTransfer(clsTransactionLog transaction) => transaction.IsScheduled && transaction.BalanceBeforeTransaction == transaction.BalanceAfterTransaction;

        private string _mapStoredTypeToDisplayType(string storedType)
        {
            switch ((storedType ?? string.Empty).Trim().ToUpper())
            {
                case "RAPID_TRANSACTIONS":
                    return "Rapid Transactions";
                case "LARGE_WITHDRAWAL":
                    return "Large Withdrawal";
                case "RECONCILIATION_MISMATCH":
                    return "Manual Review";
                case "OFF_HOURS":
                    return "Off Hours";
                case "REPEATED_FAILURE":
                    return "Repeated Failure";
                default:
                    return storedType ?? string.Empty;
            }
        }

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

        private void _bindFraudFlags(List<clsFraudFlags> fraudFlags)
        {
            fraudFlags = fraudFlags ?? new List<clsFraudFlags>();
            lblFraudFlags.Text = fraudFlags.Count.ToString();

            dgvFraudFlags.DataSource = fraudFlags.Select(n => new clsFraudFlagView
            {
                Flag = $"{_mapStoredTypeToDisplayType(n.FlagType)} - {n.Account?.AccountNumber ?? "N/A"}",
                Details = string.IsNullOrWhiteSpace(n.Details) ? "No details." : n.Details,
                Date = n.FlaggedDate.ToString("g"),
                Status = n.IsResolved ? "Resolved" : "Unresolved"
            }).ToList();

            if (dgvFraudFlags.RowCount <= 0)
                return;

            dgvFraudFlags.Columns["Flag"].HeaderText = "Flag";
            dgvFraudFlags.Columns["Details"].HeaderText = "Details";
            dgvFraudFlags.Columns["Date"].HeaderText = "Date";
            dgvFraudFlags.Columns["Status"].HeaderText = "Status";
        }

        private async Task _refreshFraudWidgets()
        {
            List<clsFraudFlags> unresolvedFraudFlags = await clsFraudFlags.GetUnresolvedFraudFlagsAsync();
            _bindFraudFlags(unresolvedFraudFlags);
        }

        private async void ctrlDashboard_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible || LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
            {
                _liveRefreshTimer.Stop();
                return;
            }

            await _refreshDashboardDataSafely();
            _liveRefreshTimer.Start();
        }

        private async Task _refreshDashboardDataSafely()
        {
            if (_isRefreshing || !this.Visible)
                return;

            try
            {
                _isRefreshing = true;
                await RefreshDashboardData();
            }
            finally
            {
                _isRefreshing = false;
            }
        }

        private async void _liveRefreshTimer_Tick(object sender, EventArgs e) => await _refreshDashboardDataSafely();

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
