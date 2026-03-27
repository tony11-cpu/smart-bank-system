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
    public partial class ctrlCustomersMainScreen : UserControl
    {
        public ctrlCustomersMainScreen()
        {
            InitializeComponent();
        }

        private bool _isManagerOrAdmin = false;
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
            {
                ctrlCustomerShortInfo1.LoadCustomerInfo(dgvCustomersData.CurrentRow.Cells[3].Value.ToString());
                if(ctrlCustomerShortInfo1.Customer != null)
                {
                    btnActivate.Visible = !ctrlCustomerShortInfo1.Customer.IsActive;
                    btnDeactivate.Visible = ctrlCustomerShortInfo1.Customer.IsActive;
                }
            }
        }

        private void tbSearchBar_EnterLeave(object sender, EventArgs e)
        {
            string filterTag = tbSearchBar.Tag.ToString();
            tbSearchBar.Text = tbSearchBar.Focused && tbSearchBar.Text == filterTag ? string.Empty :
                !tbSearchBar.Focused && string.IsNullOrWhiteSpace(tbSearchBar.Text) ? filterTag : tbSearchBar.Text;

            tbSearchBar.ForeColor = tbSearchBar.Text == filterTag ? Color.DimGray : Color.White;
        }

        private void AddNewCutomer_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateCustomers frmAddOrUpdateCustomers = new frmAddOrUpdateCustomers();
            frmAddOrUpdateCustomers.ShowDialog();
            _bindGrid(_loadCustomersList());
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
            if (string.IsNullOrEmpty(tbSearchBar.Text) || tbSearchBar.Text == tbSearchBar.Tag.ToString())
            {
                _bindGrid(_allCustomers);
                return;
            }

            string search = tbSearchBar.Text.Trim();
            _bindGrid(_allCustomers.Where(n =>
            {
                string last4 = n.NationalID.Substring(search.Length - 4);
                return last4.StartsWith(search, StringComparison.Ordinal) ||
                       n.FirstName.StartsWith(search, StringComparison.OrdinalIgnoreCase) ||
                       n.LastName.StartsWith(search, StringComparison.OrdinalIgnoreCase) ||
                       n.Phone.StartsWith(search, StringComparison.OrdinalIgnoreCase);
            }).ToList());
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

        private void DeactivateCustomer_Click(object sender, EventArgs e)
        {
            if (_checkCutomerStates(ctrlCustomerShortInfo1.Customer, true) == enCustomerStatesError.ReadyToDeactivate
                && MessageBox.Show("Are you sure you want to deactivate this customer?", "Confirm Deactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (ctrlCustomerShortInfo1.Customer.Deactivate())
                {
                    _bindGrid(_loadCustomersList());
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

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if(_checkCutomerStates(ctrlCustomerShortInfo1.Customer, false) == enCustomerStatesError.ReadyToActivate 
               && MessageBox.Show("Are you sure you want to activate this customer?", "Confirm activation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (ctrlCustomerShortInfo1.Customer.Activate())
                {
                    _bindGrid(_loadCustomersList());
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
