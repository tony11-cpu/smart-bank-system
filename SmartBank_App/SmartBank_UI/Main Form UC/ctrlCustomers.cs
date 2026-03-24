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
        private string _defaultSearchBarSTR = "Search by name, phone, or last 4 digits of national ID...";
        private List<clsCustomers> _allCustomers = new List<clsCustomers>();

        private void _bindGrid(List<clsCustomers> customerView)
        {
            if (customerView == null) 
                return;

            dgvCustomersData.DataSource = customerView;
            lblNumberOfCustomers.Text = customerView.Count.ToString();

            dgvCustomersData.Columns["ImagePath"].Visible = false;
            dgvCustomersData.Columns["CreatedByUserID"].Visible = false;
            dgvCustomersData.Columns["LastName"].Visible = false;
            dgvCustomersData.Columns["CustomerID"].Visible = false;
            dgvCustomersData.Columns["Gender"].Visible = false;

            dgvCustomersData.Columns["FirstName"].HeaderText = "Full Name";
            dgvCustomersData.Columns["DateOfBirth"].HeaderText = "Date of Birth";
            dgvCustomersData.Columns["RegisteredDate"].HeaderText = "Join Date";
            dgvCustomersData.Columns["IsActive"].HeaderText = "Status";
            dgvCustomersData.Columns["NationalID"].HeaderText = "National ID";

            foreach (DataGridViewRow row in dgvCustomersData.Rows)
            {
                row.Cells["FirstName"].Value = $"{row.Cells["FirstName"].Value} {row.Cells["LastName"].Value}".Trim();
            }
        }

        private List<clsCustomers> _loadCustomersList()
        {
            _allCustomers = clsCustomers.GetAllCustomers();
            return _allCustomers;
        }

        private void ctrlCustomers_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode) 
                return;

            _isManagerOrAdmin = clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Manager
                                || clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Admin;

            _bindGrid(_loadCustomersList());
        }

        private void dgvCustomersData_Click(object sender, EventArgs e)
        {
            if (dgvCustomersData.Rows.Count > 0)
                ctrlCustomerShortInfo1.LoadCustomerInfo(dgvCustomersData.CurrentRow.Cells[3].Value.ToString());
        }

        private void tbSearchBar_EnterLeave(object sender, EventArgs e)
        {
            tbSearchBar.Text = tbSearchBar.Focused && tbSearchBar.Text == _defaultSearchBarSTR ? string.Empty :
                !tbSearchBar.Focused && string.IsNullOrWhiteSpace(tbSearchBar.Text) ? _defaultSearchBarSTR : tbSearchBar.Text;

            tbSearchBar.ForeColor = tbSearchBar.Text == _defaultSearchBarSTR ? Color.DimGray : Color.White;
        }

        private void AddNewCutomer_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateCustomers frmAddOrUpdateCustomers = new frmAddOrUpdateCustomers();
            frmAddOrUpdateCustomers.ShowDialog();
            _bindGrid(_loadCustomersList());
        }

        private void DeactivateCustomer_Click(object sender, EventArgs e)
        {
            if (!_isManagerOrAdmin)
            {
                MessageBox.Show("You do not have permission to deactivate customers.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(dgvCustomersData.Rows.Count <= 0)
            {
                MessageBox.Show("No customer exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!ctrlCustomerShortInfo1.Customer.IsActive)
            {
                MessageBox.Show("Customer is already inactive!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MessageBox.Show("Are you sure you want to deactivate this customer?", "Confirm Deactivation",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes && ctrlCustomerShortInfo1.Customer != null)
            {
                if (ctrlCustomerShortInfo1.Customer.Deactivate())
                {
                    MessageBox.Show("Customer deactivated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _bindGrid(_loadCustomersList());
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
            _bindGrid(_loadCustomersList());
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

            frmAddOrUpdateCustomers addOrUpdateCustomers = new frmAddOrUpdateCustomers(dgvCustomersData.CurrentRow.Cells["NationalID"].Value.ToString());
            addOrUpdateCustomers.ShowDialog();
            _bindGrid(_loadCustomersList());
        }

        private void tbSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchBar.Text) || tbSearchBar.Text == _defaultSearchBarSTR)
            {
                _bindGrid(_allCustomers);
                return;
            }

            var filtered = _allCustomers.Where(n =>
            {
                string last4 = n.NationalID.Substring(n.NationalID.Length - 4);
                return last4.StartsWith(tbSearchBar.Text.Trim(), StringComparison.Ordinal) ||
                       n.FirstName.StartsWith(tbSearchBar.Text, StringComparison.OrdinalIgnoreCase) ||
                       n.LastName.StartsWith(tbSearchBar.Text, StringComparison.OrdinalIgnoreCase) ||
                       n.Phone.StartsWith(tbSearchBar.Text, StringComparison.OrdinalIgnoreCase);
            }).ToList();

            _bindGrid(filtered);
        }
    }
}
