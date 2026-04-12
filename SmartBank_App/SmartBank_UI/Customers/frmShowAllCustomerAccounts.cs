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

namespace SmartBank_UI.Accounts
{
    public partial class frmShowAllCustomerAccounts : Form
    {
        private int? customerID;
        public frmShowAllCustomerAccounts(int? customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
        }

        private void frmShowAllCustomerAccounts_Load(object sender, EventArgs e)
        {
            if (!customerID.HasValue || !clsCustomers.IsCustomerExists(customerID.Value))
            {
                MessageBox.Show("No customer found!" , "Not Found!" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _loadAccountsForCustomer(customerID.Value);
        }

        private void _loadAccountsForCustomer(int customerID)
        {
            ctrlCustomerShortInfo1.CustomerNationalIDVisibility = false;
            ctrlCustomerShortInfo1.LoadCustomerInfo(customerID);
            dgvAllCustomerAccounts.DataSource = clsAccounts.GetAccountsByCustomerID(customerID);

            int count = dgvAllCustomerAccounts.RowCount;
            lblNumberOfAccounts.Text = $"Showing {count} account{(count != 1 ? "s" : "")}";

            if (count == 0)
                MessageBox.Show("No account found for the selected customer!", "No account found", MessageBoxButtons.OK, MessageBoxIcon.Error);

            dgvAllCustomerAccounts.Columns["AccountID"].Visible = false;
            dgvAllCustomerAccounts.Columns["CreatedByUserID"].Visible = false;
            dgvAllCustomerAccounts.Columns["Customer"].Visible = false;

            dgvAllCustomerAccounts.Columns["AccountNumber"].HeaderText = "Account Number";
            dgvAllCustomerAccounts.Columns["AccountType"].HeaderText = "Account Type";
            dgvAllCustomerAccounts.Columns["ClosedDate"].HeaderText = "Closed Date";
            dgvAllCustomerAccounts.Columns["MinimumBalance"].HeaderText = "Minimum Balance";
            dgvAllCustomerAccounts.Columns["OpenedDate"].HeaderText = "Open Date";

            dgvAllCustomerAccounts.RowTemplate.Height = 35;
            dgvAllCustomerAccounts.ColumnHeadersHeight = 40;
        }
    }
}
