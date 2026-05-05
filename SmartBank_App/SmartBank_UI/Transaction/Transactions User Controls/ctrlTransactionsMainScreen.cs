using SmartBank;
using SmartBank_BLL;
using SmartBank_UI.Accounts;
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

namespace SmartBank_UI.Transaction.Transactions_User_Controls
{
    public partial class ctrlTransactionsMainScreen : UserControl
    {
        public ctrlTransactionsMainScreen()
        {
            InitializeComponent();
        }

        private List<clsTransactionLog> _transactionsLogs;

        private void tbSearchBar_EnterLeave(object sender, EventArgs e)
        {
            string filterTag = tbSearchBar.Tag.ToString();
            tbSearchBar.Text = tbSearchBar.Focused && tbSearchBar.Text == filterTag ? string.Empty : !tbSearchBar.Focused && string.IsNullOrWhiteSpace(tbSearchBar.Text) ? filterTag : tbSearchBar.Text;
            tbSearchBar.ForeColor = tbSearchBar.Text == filterTag ? Color.DimGray : Color.White;
        }

        private void _bindGrid(List<clsTransactionLog> transactions)
        {
            dgvAllTransactions.DataSource = transactions;

            if(dgvAllTransactions.RowCount == 0)
                return;

            dgvAllTransactions.Columns["BalanceAfterTransaction"].Visible = false;
            dgvAllTransactions.Columns["UserResponsibleID"].Visible = false;
            dgvAllTransactions.Columns["TransactionID"].Visible = false;

            dgvAllTransactions.Columns["TransactionType"].HeaderText = "Transaction Type";
            dgvAllTransactions.Columns["FromAccount"].HeaderText = "From Account";
            dgvAllTransactions.Columns["ToAccount"].HeaderText = "To Account";
            dgvAllTransactions.Columns["TransactionDate"].HeaderText = "Date";
            dgvAllTransactions.Columns["IsScheduled"].HeaderText = "Scheduled";

            dgvAllTransactions.RowTemplate.Height = 35;
            dgvAllTransactions.ColumnHeadersHeight = 40;

            int count = transactions.Count();
            lblNumberOfTransactions.Text = $"Showing {count} Transactions";
            lblClickToShowRow.Visible = count > 0;
        }

        private async Task<List<clsTransactionLog>> _loadTransactionsLog()
        {
            _transactionsLogs = await clsTransactionLog.GetAllTransactionsAsync();
            return _transactionsLogs;
        }

        private async void ctrlTransactionsMainScreen_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            dgvAllTransactions.RowTemplate.Height = 35;
            dgvAllTransactions.ColumnHeadersHeight = 40;

            _bindGrid(await _loadTransactionsLog());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_transactionsLogs == null || !_transactionsLogs.Any())
            {
                MessageBox.Show("No transactions to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine("Transaction Type, Transaction ID, From Account, To Account, Amount, Transaction Date, User Responsible ID, Is Scheduled, Balance After Transaction");
                    foreach (clsTransactionLog tr in _transactionsLogs)
                        sw.WriteLine($"{tr.TransactionType},\"{$"{tr.TransactionID} {tr.FromAccount.AccountNumber}".Trim()}\"" +
                                     $",{tr.ToAccount.AccountNumber},{tr.Amount},{tr.TransactionDate},{tr.UserResponsibleID}" +
                                     $",{tr.IsScheduled},{tr.BalanceAfterTransaction}");
                }

                MessageBox.Show("Transactions exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSchedualedFillter_Click(object sender, EventArgs e) => _fillter(clsTransactionLog.enTransactionType.Scheduled);

        private void _fillter(clsTransactionLog.enTransactionType transactionType) =>  _bindGrid(_transactionsLogs.Any() ? _transactionsLogs.Where(n => n.TransactionType == transactionType).ToList() : _transactionsLogs);

        private void tbSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchBar.Text) || tbSearchBar.Text == tbSearchBar.Tag.ToString())
            {
                _bindGrid(_transactionsLogs);
                return;
            }

            string search = tbSearchBar.Text.Trim();
            decimal searchAmount;
            bool isNumeric = decimal.TryParse(search, out searchAmount);

            _bindGrid(_transactionsLogs.Where(t => t.FromAccount.AccountNumber.StartsWith(search) || 
                                                  (t.FromAccount.Customer != null && (t.FromAccount.Customer.FirstName + " " + t.FromAccount.Customer.LastName).StartsWith(search)) ||
                                                   t.TransactionType.ToString().StartsWith(search) || 
                                                   (isNumeric && t.FromAccount.Balance.Equals(searchAmount))).ToList());
        }

        private async void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            var transactionID = dgvAllTransactions.CurrentRow?.Cells["TransactionID"]?.Value;
            if (transactionID == null)
                return;
            
            await _loadDefaultTransactionFullData((int)transactionID);
        }

        private async Task _loadTransaction(int transactionID)
        {
            try
            {
                clsTransactionLog transactionData = await clsTransactionLog.FindAsyncWithTransactionID(transactionID);

                if (transactionData == null || transactionData.FromAccount == null)
                {
                    MessageBox.Show("Transaction data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblTransactionType.Text = transactionData.TransactionType.ToString();
                lblTransactionlStatus.Text = transactionData.IsScheduled ? "Scheduled" : "Completed";

                nupBalanceBefore.Value = transactionData.BalanceAfterTransaction - transactionData.Amount;
                nupBalanceAfter.Value = transactionData.BalanceAfterTransaction;
                tbDescription.Text = string.IsNullOrWhiteSpace(transactionData.Description) ? "No Description" : transactionData.Description;
                tbTransactionDate.Text = transactionData.TransactionDate.ToString("g");
                tbUserProccessedTheTransaction.Text = (await clsUsers.FindAsync(transactionData.UserResponsibleID))?.FullName ?? "Unknown";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task _loadDefaultTransactionFullData(int transactionID)
        {
            if (dgvAllTransactions.Rows.Count == 0)
            {
                MessageBox.Show("No transactions available to view details.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (transactionID <= 0)
                return;

            try
            {
                clsTransactionLog transactionData = await clsTransactionLog.FindAsyncWithTransactionID(transactionID);

                if(transactionData == null)
                {
                    MessageBox.Show("Failed to load transaction details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await ctrlAccountShortInfo1.LoadAccount(transactionData.FromAccount.AccountNumber);
                await _loadTransaction(transactionID);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvAllTransactions_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvAllTransactions.CurrentRow;
            if (row == null) 
                return;

            await _loadDefaultTransactionFullData(Convert.ToInt32(row.Cells["TransactionID"].Value));
        }

        private void cmsAccountTransactionsLog_Click(object sender, EventArgs e)
        {
            if(_transactionsLogs == null || !_transactionsLogs.Any())
            {
                MessageBox.Show("No transactions available to filter.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvAllTransactions.CurrentRow;
            if (row?.Cells["FromAccount"]?.Value == null)
                return;

            _bindGrid(_transactionsLogs.Where(n => n.FromAccount?.AccountNumber == row.Cells["FromAccount"].Value.ToString()).ToList());
        }

        private async void cmsCustomerInfo_Click(object sender, EventArgs e)
        {
            if (_transactionsLogs == null || !_transactionsLogs.Any())
            {
                MessageBox.Show("No transactions available to filter.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmShowAllCustomerAccounts showAllCustomerAccounts = new frmShowAllCustomerAccounts((await clsAccounts.FindAsync(dgvAllTransactions.CurrentRow?.Cells["FromAccount"].Value.ToString()))?.Customer.CustomerID);
            showAllCustomerAccounts.ShowDialog();
        }

        private async void ctrlTransactionsMainScreen_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                _bindGrid(await _loadTransactionsLog());
        }

        private async void btnNewTransactions_Click(object sender, EventArgs e) => await _openTransactionForm(frmPerformNewTransaction.enTransactionType.None);

        private async Task _openTransactionForm(frmPerformNewTransaction.enTransactionType transactionType, string accountNumber = null)
        {
            if(string.IsNullOrEmpty(accountNumber))
            {
                transactionType = frmPerformNewTransaction.enTransactionType.None;
            }

            frmPerformNewTransaction performNewTransaction = new frmPerformNewTransaction(accountNumber, transactionType);
            performNewTransaction.ShowDialog();

            _bindGrid(await _loadTransactionsLog());
        }

        private async void cmsNewDeposite_Click(object sender, EventArgs e) => await _openTransactionForm(frmPerformNewTransaction.enTransactionType.Deposit, dgvAllTransactions.CurrentRow?.Cells["FromAccount"].Value.ToString());

        private async void cmsNewWithdrawl_Click(object sender, EventArgs e) => await _openTransactionForm(frmPerformNewTransaction.enTransactionType.Withdrawl, dgvAllTransactions.CurrentRow?.Cells["FromAccount"].Value.ToString());

        private async void cmsNewTransfare_Click(object sender, EventArgs e) => await _openTransactionForm(frmPerformNewTransaction.enTransactionType.Transfer, dgvAllTransactions.CurrentRow?.Cells["FromAccount"].Value.ToString());
    }
}
