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

namespace SmartBank_UI.Main_Form_UC
{
    public partial class ctrlCustomers : UserControl
    {
        public ctrlCustomers()
        {
            InitializeComponent();
        }

        private bool _isManagerOrAdmin = false;

        private void _loadDGV()
        {
            dgvCustomersData.DataSource = clsCustomers.GetAllCustomers();

            if(dgvCustomersData.Rows.Count > 0)
               lblNumberOfCustomers.Text = dgvCustomersData.Rows.Count.ToString();
        }

        private void ctrlCustomers_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode) 
                return;

            _isManagerOrAdmin = (clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Manager
                                || clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Admin);

            _loadDGV();
        }

        private void dgvCustomersData_Click(object sender, EventArgs e)
        {
            if (dgvCustomersData.Rows.Count > 0)
                ctrlCustomerShortInfo1.LoadCustomerInfo(dgvCustomersData.CurrentRow.Cells[2].Value.ToString());
        }

        private void tbSearchBar_EnterLeave(object sender, EventArgs e)
        {
            string defaultSTR = "Search by name,phone , or last 4 digits of National ID...";
            bool entering = tbSearchBar.Focused;
            tbSearchBar.Text = entering && tbSearchBar.Text == defaultSTR ?  string.Empty :
                !entering && string.IsNullOrWhiteSpace(tbSearchBar.Text) ? defaultSTR : tbSearchBar.Text;

            tbSearchBar.ForeColor = tbSearchBar.Text == defaultSTR ? Color.DimGray : Color.White;
        }

        private void AddNewCutomer_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateCustomers frmAddOrUpdateCustomers = new frmAddOrUpdateCustomers();
            frmAddOrUpdateCustomers.ShowDialog();
            _loadDGV();
        }

        private void DeactivateCustomer_Click(object sender, EventArgs e)
        {
            if (!_isManagerOrAdmin)
            {
                MessageBox.Show("You do not have permission to deactivate customers.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to deactivate this customer?", "Confirm Deactivation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes && ctrlCustomerShortInfo1.Customer != null)
            {
                if (ctrlCustomerShortInfo1.Customer.Deactivate())
                {
                    MessageBox.Show("Customer deactivated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _loadDGV();
                }
                else
                {
                    MessageBox.Show("Error while deactivating customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (ctrlCustomerShortInfo1.Customer == null)
            {
                MessageBox.Show("Customer is not exist!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddOrUpdateCustomers addOrUpdateCustomers = new frmAddOrUpdateCustomers(ctrlCustomerShortInfo1.Customer.NationalID);
            addOrUpdateCustomers.ShowDialog();
            _loadDGV();
        }

        private void viewCustomerAccountHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature did not implemented yet!" , "Error" , MessageBoxButtons.OK ,MessageBoxIcon.Error);
        }

        private void updateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCustomersData.Rows.Count == 0)
            {
                MessageBox.Show("No Customer exist!", "No Customer Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddOrUpdateCustomers addOrUpdateCustomers = new frmAddOrUpdateCustomers(dgvCustomersData.CurrentRow.Cells[2].Value.ToString());
            addOrUpdateCustomers.ShowDialog();
            _loadDGV();
        }
    }
}
