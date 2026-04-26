using SmartBank;
using SmartBank_BLL;
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

        private void _bindGrid(IEnumerable<clsTransactionLog> transactions)
        {
            dgvAllTransactions.DataSource = transactions;

            if(transactions == null || !transactions.Any())
                return;

            dgvAllTransactions.Columns["BalanceAfterTransaction"].Visible = false;

            dgvAllTransactions.Columns["TransactionType"].HeaderText = "Transaction Type";
            dgvAllTransactions.Columns["FromAccount"].HeaderText = "From Account";
            dgvAllTransactions.Columns["ToAccount"].HeaderText = "To Account";
            dgvAllTransactions.Columns["TransactionDate"].HeaderText = "Date";
            dgvAllTransactions.Columns["IsScheduled"].HeaderText = "Scheduled";
            dgvAllTransactions.Columns["UserResponsibleID"].HeaderText = "User Responsible";
            dgvAllTransactions.Columns["TransactionID"].HeaderText = "Transaction ID";

            dgvAllTransactions.RowTemplate.Height = 35;
            dgvAllTransactions.ColumnHeadersHeight = 40;
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

            _bindGrid(await _loadTransactionsLog());
        }

        private void btnSchedualedFillter_Click(object sender, EventArgs e)
        {
            if (_transactionsLogs.Any())
                _bindGrid(_transactionsLogs.Where(n => n.IsScheduled));
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
                    //sw.WriteLine("Account Number,Customer Name,Account Type,Balance,Status,Closed Date");
                    //foreach (clsTransactionLog tr in _transactionsLogs)
                    //    sw.WriteLine($"{tr.AccountNumber},\"{$"{tr.Customer?.FirstName} {tr.Customer?.LastName}".Trim()}\"" +
                    //                 $",{tr.AccountType},{tr.Balance},{tr.Status}," +
                    //                 $"{(tr.ClosedDate.HasValue ? tr.ClosedDate.Value.ToShortDateString() : "Not Closed")}");
                }

                MessageBox.Show("Accounts exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
