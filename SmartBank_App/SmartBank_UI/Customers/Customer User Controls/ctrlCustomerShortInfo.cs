using SmartBank;
using SmartBank_BLL;
using SmartBank_UI.Properties;
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

namespace SmartBank_UI.Main_Form_UC
{
    public partial class ctrlCustomerShortInfo : UserControl
    {
        public clsCustomers Customer { get; private set; }
        public event Action OnCustomerSelected;
        private bool _canSeeCustomerID;

        public bool CustomerNationalIDVisibility
        {
            set
            {
                tbNationalID.Enabled = value;
            }
        }

        public ctrlCustomerShortInfo()
        {
            InitializeComponent();
        }
        
        private void _loadCustomerImage()
        {
            if(string.IsNullOrEmpty(Customer.ImagePath))
                pbCustomerPhoto.Image = Customer.Gender ? Resources.icons8_person_female_skin_type_1_and_2_80 : Resources.icons8_person_80;
            else
                pbCustomerPhoto.ImageLocation = Customer.ImagePath;
        }

        private void _loadCustomerInfo()
        {
            lblCustomerName.Text = $"{Customer.FirstName} {Customer.LastName}";
            lblCustomerServedDate.Text = $"Customer Since {Customer.RegisteredDate.ToString("MMM, dd/yyyy")}";
            tbAddress.Text = Customer.Address;
            tbEmail.Text = Customer.Email;
            mtbPhoneNumber.Text = Customer.Phone;
            mtbDateOfBarth.Text = Customer.DateOfBirth.ToString("MM/dd/yyyy");
            tbNationalID.Text = _canSeeCustomerID ? Customer.NationalID : (Customer.NationalID.Length >= 4 ? "***-**-" + Customer.NationalID.Substring(Customer.NationalID.Length - 4) : "***-**-????");

            _loadCustomerImage();
        }

        public async Task LoadCustomerInfoAsync(string nationalID)
        {
            Customer = await clsCustomers.FindAsync(nationalID);

            if (Customer == null)
            {
                MessageBox.Show("No customer found!" , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                _loadDefault();
            }
            else
            {
                _loadCustomerInfo();
                OnCustomerSelected?.Invoke();
            }
        }

        public async Task LoadCustomerInfoAsync(int customerID)
        {
            Customer = await clsCustomers.FindAsync(customerID);

            if (Customer == null)
            {
                MessageBox.Show("No customer found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _loadDefault();
            }
            else
            {
                _loadCustomerInfo();
                OnCustomerSelected?.Invoke();
            }
        }

        private void _loadDefault()
        {
            lblCustomerName.Text = "Customer Name";
            lblCustomerServedDate.Text = "Customer Since Jan, 00/00/0000";
            pbCustomerPhoto.Image = Resources.icons8_person_80;
            mtbDateOfBarth.Text = "00/00/0000";
            mtbPhoneNumber.Text = "0000000000";
            tbEmail.Text = "User Email";
            tbAddress.Text = "User Address";
        }

        private void lblLinkToFullID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(Customer == null)
            {
                MessageBox.Show("No customer loaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!_canSeeCustomerID)
            {
                MessageBox.Show("You do not have permission to view full customer information.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tbNationalID.Text = Customer.NationalID;
            }
        }

        private void ctrlCustomerShortInfo_Load(object sender, EventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            _canSeeCustomerID = clsGlobal.ActiveUser.Permissions.Has(clsPermissions.enPermission.CanViewCustomerNationalId);

            _loadDefault();
            frmAddOrUpdateCustomers.OnAddingOrUpdatingCustomer += async (task) => await LoadCustomerInfoAsync(task);
        }

        private async void tbNationalID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                await LoadCustomerInfoAsync(tbNationalID.Text.Trim());
        }
    }
}
