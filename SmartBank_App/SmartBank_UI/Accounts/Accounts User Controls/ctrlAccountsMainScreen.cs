using SmartBank;
using SmartBank_BLL;
using SmartBank_UI.Accounts;
using SmartBank_UI.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace SmartBank_UI.Main_Form_UC
{
    public partial class ctrlAccounts : UserControl
    {
        private List<clsAccounts> _allAccounts = new List<clsAccounts>();
        private clsAccounts _currentAccount = null;
        private bool _isRefreshingLiveData = false;

        public ctrlAccounts() => InitializeComponent();

        private void tbSearchBar_EnterLeave(object sender, EventArgs e)
        {
            string tag = tbSearchBar.Tag.ToString().Trim();
            tbSearchBar.Text = tbSearchBar.Focused && tbSearchBar.Text == tag ? string.Empty : !tbSearchBar.Focused && string.IsNullOrWhiteSpace(tbSearchBar.Text) ? tag : tbSearchBar.Text;
            tbSearchBar.ForeColor = tbSearchBar.Text == tag ? Color.DimGray : Color.White;
        }

        private async Task<List<clsAccounts>> _loadAccountsList()
        {
            _allAccounts = await clsAccounts.GetAllAccountsAsync();
            return _allAccounts;
        }

        private void _bindRecentTransactionsGrid(List<clsTransactionLog> transactions)
        {
            dgvAccountRecentTransactions.DataSource = transactions.Select(n => new
            {
                Date = n.TransactionDate,
                Type = n.TransactionType.ToString().Replace("_", " "),
                n.Amount,
                Status = (n.IsScheduled && n.BalanceBeforeTransaction == n.BalanceAfterTransaction) ? "Pending" : "Completed"
            }).ToList();

            if (dgvAccountRecentTransactions.RowCount == 0)
                return;

            dgvAccountRecentTransactions.Columns["Date"].HeaderText = "Date";
            dgvAccountRecentTransactions.Columns["Type"].HeaderText = "Type";
            dgvAccountRecentTransactions.Columns["Amount"].HeaderText = "Amount";
            dgvAccountRecentTransactions.Columns["Status"].HeaderText = "Status";

            dgvAccountRecentTransactions.RowTemplate.Height = 35;
            dgvAccountRecentTransactions.ColumnHeadersHeight = 40;
        }

        private async Task _loadRecentTransactionsForCurrentAccountAsync()
        {
            if (_currentAccount?.AccountID == null)
            {
                _bindRecentTransactionsGrid(new List<clsTransactionLog>());
                return;
            }

            List<clsTransactionLog> allTransactions = await clsTransactionLog.GetAllTransactionsAsync();
            if (allTransactions == null || !allTransactions.Any())
            {
                _bindRecentTransactionsGrid(new List<clsTransactionLog>());
                return;
            }

            _bindRecentTransactionsGrid(allTransactions.Where(n => n.FromAccount?.AccountID == _currentAccount.AccountID ||
                 n.ToAccount?.AccountID == _currentAccount.AccountID).OrderByDescending(n => n.TransactionDate).Take(100).ToList());
        }

        private void _bindGrid(IEnumerable<clsAccounts> accountView)
        {
            if (!_allAccounts.Any())
                return;

            dgvAccounts.DataSource = accountView.Select(a => new
            {
                a.AccountID, a.AccountNumber, CustomerName = $"{a.Customer?.FirstName} {a.Customer?.LastName}".Trim(),
                a.AccountType, a.Balance, a.MinimumBalance, a.Status, a.OpenedDate,
                ClosedDate = a.ClosedDate.HasValue ? a.ClosedDate.Value.ToShortDateString() : "Not Closed", a.CreatedByUserID
            }).ToList();

            int count = accountView.Count();
            lblNumberOfAccounts.Text = $"Showing {count} of {_allAccounts.Count} account{(count != 1 ? "s" : "")}";
            lblClickToShowRow.Visible = true;

            dgvAccounts.Columns["AccountID"].Visible = false;
            dgvAccounts.Columns["MinimumBalance"].Visible = false;
            dgvAccounts.Columns["OpenedDate"].Visible = false;
            dgvAccounts.Columns["CreatedByUserID"].Visible = false;                

            dgvAccounts.Columns["AccountNumber"].HeaderText = "Account Number";
            dgvAccounts.Columns["AccountType"].HeaderText = "Account Type";
            dgvAccounts.Columns["ClosedDate"].HeaderText = "Closed Date";
            dgvAccounts.Columns["CustomerName"].HeaderText = "Customer Name";
        }

        private async void ctrlAccounts_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            clsGlobal.OnTransactionCompleted += _onTransactionCompleted;
            this.Disposed += (s, args) => clsGlobal.OnTransactionCompleted -= _onTransactionCompleted;

            dgvAccounts.RowTemplate.Height = 35;
            dgvAccounts.ColumnHeadersHeight = 40;
            dgvAccountRecentTransactions.RowTemplate.Height = 35;
            dgvAccountRecentTransactions.ColumnHeadersHeight = 40;

            await _refreshLiveDataAsync();

            if (clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Teller)
            {
                updateAccountToolStripMenuItem.Enabled = false;
                freezeAccountToolStripMenuItem.Enabled = false;
                unfreezeAccountToolStripMenuItem.Enabled = false;
            }
        }

        private void btnAllFilter_Click(object sender, EventArgs e) => _bindGrid(_allAccounts);
        private void btnClosedAccountsFilter_Click(object sender, EventArgs e) => _bindGrid(_allAccounts.Where(n => n.Status == clsAccounts.enStatus.Closed));
        private void btnFrozenFilter_Click(object sender, EventArgs e) => _bindGrid(_allAccounts.Where(n => n.Status == clsAccounts.enStatus.Frozen));
        private void btnActiveFilter_Click(object sender, EventArgs e) => _bindGrid(_allAccounts.Where(n => n.Status == clsAccounts.enStatus.Active));

        private void tbSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchBar.Text) || tbSearchBar.Text == tbSearchBar.Tag.ToString())
            {
                _bindGrid(_allAccounts);
                return;
            }

            string search = tbSearchBar.Text.Trim();
            _bindGrid(_allAccounts.Where(n => n.AccountNumber.StartsWith(search) || (n.Customer.FirstName + " " + n.Customer.LastName).StartsWith(search) ||
                                              n.Balance.ToString().StartsWith(search) || n.AccountType.ToString().StartsWith(search)).ToList());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_allAccounts == null || !_allAccounts.Any())
            {
                MessageBox.Show("No accounts to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine("Account Number,Customer Name,Account Type,Balance,Status,Closed Date");
                    foreach (clsAccounts acc in _allAccounts)
                        sw.WriteLine($"{acc.AccountNumber},\"{$"{acc.Customer?.FirstName} {acc.Customer?.LastName}".Trim()}\"" +
                                     $",{acc.AccountType},{acc.Balance},{acc.Status}," +
                                     $"{(acc.ClosedDate.HasValue ? acc.ClosedDate.Value.ToShortDateString() : "Not Closed")}");
                }

                MessageBox.Show("Accounts exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task _loadUserFromDGVAsync()
        {
            if (dgvAccounts.Rows.Count == 0)
            {
                _currentAccount = null;
                _bindRecentTransactionsGrid(new List<clsTransactionLog>());
                return;
            }

            string accountNumber = dgvAccounts.CurrentRow?.Cells["AccountNumber"].Value.ToString();
            if(string.IsNullOrEmpty(accountNumber))
                return;

            _currentAccount = await clsAccounts.FindAsync(accountNumber);
            await ctrlAccountShortInfo1.LoadAccount(accountNumber);
            await _loadRecentTransactionsForCurrentAccountAsync();
        }
        
        private async void OpenAccount_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateAccount frm = new frmAddOrUpdateAccount();
            frm.ShowDialog();

            _bindGrid(await _loadAccountsList());
        }

        private async void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e) => await _loadUserFromDGVAsync();

        private async void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {
            await _loadUserFromDGVAsync();

            bool notClosed = _currentAccount != null && _currentAccount?.Status != clsAccounts.enStatus.Closed;
            bool frozen = _currentAccount?.Status == clsAccounts.enStatus.Frozen;
            bool isAdmin = clsGlobal.ActiveUser?.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Admin;
            bool canTransact = !(frozen && !isAdmin);
            bool canTransfer = clsGlobal.ActiveUser?.Permissions?.Has(clsPermissions.enPermission.CanTransfer) ?? false;

            updateAccountToolStripMenuItem.Enabled = notClosed && isAdmin;
            unfreezeAccountToolStripMenuItem.Enabled = notClosed && isAdmin && frozen;
            freezeAccountToolStripMenuItem.Enabled = notClosed && isAdmin && !frozen;
            closeToolStripMenuItem.Enabled = notClosed && isAdmin;
            depositeToolStripMenuItem.Enabled = notClosed && canTransact;
            withdrawalToolStripMenuItem.Enabled = notClosed && canTransact;
            transfareToolStripMenuItem.Enabled = notClosed && canTransact && canTransfer;
        }

        private async void ctrlAccounts_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible || LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            await _refreshLiveDataAsync();
        }

        private async void _onTransactionCompleted() => await _refreshLiveDataAsync();

        private async Task _refreshLiveDataAsync()
        {
            if (_isRefreshingLiveData || !this.Visible)
                return;

            try
            {
                _isRefreshingLiveData = true;
                _bindGrid(await _loadAccountsList());
                await _loadUserFromDGVAsync();
            }
            finally
            {
                _isRefreshingLiveData = false;
            }
        }

        private async Task _openTransactionFormFromContextAsync(frmPerformNewTransaction.enTransactionType transactionType)
        {
            if (dgvAccounts.CurrentRow?.Cells["AccountNumber"]?.Value == null)
                return;

            string accountNumber = dgvAccounts.CurrentRow.Cells["AccountNumber"].Value.ToString();
            if (string.IsNullOrWhiteSpace(accountNumber))
                return;

            frmPerformNewTransaction form = new frmPerformNewTransaction(accountNumber, transactionType);
            form.ShowDialog();

            _bindGrid(await _loadAccountsList());
            await _loadUserFromDGVAsync();
        }

        private async void updateAccount_Click(object sender, EventArgs e)
        {
            string nationalID = dgvAccounts.CurrentRow.Cells["AccountNumber"].Value.ToString();
            frmAddOrUpdateAccount frm = new frmAddOrUpdateAccount(nationalID);
            frm.ShowDialog();

            await ctrlAccountShortInfo1.LoadAccount(nationalID);
            _bindGrid(await _loadAccountsList());
        }

        private async void freezeAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to freeze this account?", "Confirm Freeze", MessageBoxButtons.YesNo, MessageBoxIcon.Question , MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                if (await _currentAccount.FreezeAsync())
                {
                    _bindGrid(await _loadAccountsList());
                    MessageBox.Show("Account freezed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Failed to freeze account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to freeze account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void unfreezeAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to unfreeze this account?", "Confirm Unfreeze", MessageBoxButtons.YesNo, MessageBoxIcon.Question , MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                if (await _currentAccount.UnFreezeAsync())
                {
                    _bindGrid(await _loadAccountsList());
                    MessageBox.Show("Account unfrozen successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Failed to unfreeze account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to unfreeze account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to close this account?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question , MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                if (await _currentAccount.CloseAsync())
                {
                    _bindGrid(await _loadAccountsList());
                    MessageBox.Show("Account closed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Failed to close account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to close account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void depositeToolStripMenuItem_Click(object sender, EventArgs e) => await _openTransactionFormFromContextAsync(frmPerformNewTransaction.enTransactionType.Deposit);

        private async void withdrawalToolStripMenuItem_Click(object sender, EventArgs e) => await _openTransactionFormFromContextAsync(frmPerformNewTransaction.enTransactionType.Withdrawl);

        private async void transfareToolStripMenuItem_Click(object sender, EventArgs e) => await _openTransactionFormFromContextAsync(frmPerformNewTransaction.enTransactionType.Transfer);
    }
}
