using SmartBank;
using SmartBank_BLL;
using SmartBank_UI.Accounts;
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
    public partial class ctrlCustomersMainScreen : UserControl
    {
        public ctrlCustomersMainScreen()
        {
            InitializeComponent();
        }

        private bool _isManagerOrAdmin = false;
        private List<clsCustomers> _allCustomers = new List<clsCustomers>();

        private void _bindGrid(List<clsCustomers> customerView , bool isFilter = false)
        {
            if (!customerView.Any() && !isFilter) 
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

        private async Task<List<clsCustomers>> _loadCustomersList()
        {
            _allCustomers = await clsCustomers.GetAllCustomersAsync();
            return _allCustomers;
        }

        private async void ctrlCustomers_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode) 
                return;

            _isManagerOrAdmin = clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Manager
                                || clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Admin;

            dgvCustomersData.RowTemplate.Height = 35;
            dgvCustomersData.ColumnHeadersHeight = 40;

            _bindGrid(await _loadCustomersList());
        }

        private async void _loadCustomerFromDGV()
        {
            if (dgvCustomersData.Rows.Count > 0)
            {
                object value = dgvCustomersData.CurrentRow?.Cells["NationalID"].Value;
                if (value == null || value == DBNull.Value) return;

                await ctrlCustomerShortInfo1.LoadCustomerInfo(value.ToString());
                if (ctrlCustomerShortInfo1.Customer != null)
                {
                    btnActivate.Visible = !ctrlCustomerShortInfo1.Customer.IsActive;
                    btnDeactivate.Visible = ctrlCustomerShortInfo1.Customer.IsActive;
                    activateToolStripMenuItem.Enabled = !ctrlCustomerShortInfo1.Customer.IsActive;
                    deactivateCustomerToolStripMenuItem.Enabled = ctrlCustomerShortInfo1.Customer.IsActive;
                }
            }
            else
            {
                activateToolStripMenuItem.Enabled = false;
                deactivateCustomerToolStripMenuItem.Enabled = false;
            }
        }

        private void dgvCustomersData_Click(object sender, EventArgs e) => _loadCustomerFromDGV();

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) => _loadCustomerFromDGV();

        private void tbSearchBar_EnterLeave(object sender, EventArgs e)
        {
            string filterTag = tbSearchBar.Tag.ToString();
            tbSearchBar.Text = tbSearchBar.Focused && tbSearchBar.Text == filterTag ? string.Empty : !tbSearchBar.Focused && string.IsNullOrWhiteSpace(tbSearchBar.Text) ? filterTag : tbSearchBar.Text;
            tbSearchBar.ForeColor = tbSearchBar.Text == filterTag ? Color.DimGray : Color.White;
        }

        private async void AddNewCutomer_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateCustomers frmAddOrUpdateCustomers = new frmAddOrUpdateCustomers();
            frmAddOrUpdateCustomers.ShowDialog();
            _bindGrid(await _loadCustomersList());
        }

        private async void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (ctrlCustomerShortInfo1.Customer == null)
            {
                MessageBox.Show("Customer is not exist!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddOrUpdateCustomers addOrUpdateCustomers = new frmAddOrUpdateCustomers(ctrlCustomerShortInfo1.Customer.NationalID);
            addOrUpdateCustomers.ShowDialog();
            _bindGrid(await _loadCustomersList());
        }

        private async void viewCustomerAccountHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? customerId = (int?)dgvCustomersData.CurrentRow?.Cells["CustomerID"]?.Value;
            if(customerId.HasValue && await clsCustomers.IsCustomerExistsAsync(customerId.Value))
            {
                frmShowAllCustomerAccounts frm = new frmShowAllCustomerAccounts(customerId);
                frm.ShowDialog();
            }

            MessageBox.Show("No customer selected!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void updateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCustomersData.Rows.Count == 0)
            {
                MessageBox.Show("No Customer exist!", "Select customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nationalId = dgvCustomersData.CurrentRow?.Cells["NationalID"].Value?.ToString();
            if(string.IsNullOrEmpty(nationalId))
            {
                MessageBox.Show("No customer selected!", "Select customer!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddOrUpdateCustomers addOrUpdateCustomers = new frmAddOrUpdateCustomers(nationalId);
            addOrUpdateCustomers.ShowDialog();
            _bindGrid(await _loadCustomersList());
        }

        private void tbSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchBar.Text) || tbSearchBar.Text == tbSearchBar.Tag.ToString())
            {
                _bindGrid(_allCustomers);
                return;
            }

            string search = tbSearchBar.Text.Trim();
            _bindGrid(_allCustomers.Where(n =>
            {
                return n.NationalID.Substring(n.NationalID.Length - 4).StartsWith(search, StringComparison.Ordinal) ||
                       n.FirstName.StartsWith(search, StringComparison.OrdinalIgnoreCase) ||
                       n.LastName.StartsWith(search, StringComparison.OrdinalIgnoreCase) ||
                       n.Phone.StartsWith(search, StringComparison.OrdinalIgnoreCase);
            }).ToList() , true);
        }

        private enum enCustomerStatesError { RecordNotExists = 1 , CustomerAlreadyActive = 2 , CustomerAlreadyInActive = 3 , CurrentUserNotAdminOrManager = 4 , ReadyToDeactivate = 5 , ReadyToActivate = 6 }

        private enCustomerStatesError _checkCutomerStates(clsCustomers customer , bool deactivation)
        {
            if(customer == null)
            {
                MessageBox.Show("Customer not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return enCustomerStatesError.RecordNotExists;
            }

            if(!_isManagerOrAdmin)
            {
                MessageBox.Show("You do not have permission to deactivate customers.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return enCustomerStatesError.CurrentUserNotAdminOrManager;
            }

            if(!customer.IsActive && deactivation)
            {
                MessageBox.Show("Customer is already inactive!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return enCustomerStatesError.CustomerAlreadyInActive;
            }

            if(customer.IsActive && !deactivation)
            {
                MessageBox.Show("Customer is already active!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return enCustomerStatesError.CustomerAlreadyActive;
            }

            return deactivation ? enCustomerStatesError.ReadyToDeactivate : enCustomerStatesError.ReadyToActivate;
        }

        private async void DeactivateCustomer_Click(object sender, EventArgs e)
        {
            if (_checkCutomerStates(ctrlCustomerShortInfo1.Customer, true) == enCustomerStatesError.ReadyToDeactivate
                && MessageBox.Show("Are you sure you want to deactivate this customer?", "Confirm Deactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning , MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (await ctrlCustomerShortInfo1.Customer.DeactivateAsync())
                {
                    _bindGrid(await _loadCustomersList());
                    btnDeactivate.Visible = false;
                    btnActivate.Visible = true;
                    MessageBox.Show("Customer deactivated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error while deactivating customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void Activate_Click(object sender, EventArgs e)
        {
            if(_checkCutomerStates(ctrlCustomerShortInfo1.Customer, false) == enCustomerStatesError.ReadyToActivate 
               && MessageBox.Show("Are you sure you want to activate this customer?", "Confirm activation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning , MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (await ctrlCustomerShortInfo1.Customer.ActivateAsync())
                {
                    _bindGrid(await _loadCustomersList());
                    btnDeactivate.Visible = true;
                    btnActivate.Visible = false;
                    MessageBox.Show("Customer activated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error while activating customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
