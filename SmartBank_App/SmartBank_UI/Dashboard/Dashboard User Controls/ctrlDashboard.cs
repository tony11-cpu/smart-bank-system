using SmartBank;
using SmartBank_BLL;
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

        private async void ctrlDashboard_Load(object sender, EventArgs e)
        {
            if(LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            lblMorningToUserWithName.Text = $"Good Morning, {clsGlobal.ActiveUser.FullName}. Here is everything you need to start your shift. ";
            lblActiveAccounts.Text = (await clsAccounts.NumberOfActiveAccountsAsync()).ToString();

            await _loadTransactions();
        }

        private async Task _loadTransactions()
        {
            dgvRecentTransactions.DataSource = await clsTransactionLog.GetAllUserTransactionsListAsync(clsGlobal.ActiveUser.UserID);

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
    }
}
