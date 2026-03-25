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
        private bool _isManagerOrAdmin;
        public clsCustomers Customer { get; private set; }
        
        public ctrlCustomerShortInfo()
        {
            InitializeComponent();
        }
        
        private void _loadCustomerImage()
        {
            if(string.IsNullOrEmpty(Customer.ImagePath))
            {
                pbCustomerPhoto.Image = Customer.Gender ? Resources.icons8_person_female_skin_type_1_and_2_80 : Resources.icons8_person_80;
            }
            else
            {
                pbCustomerPhoto.ImageLocation = Customer.ImagePath;
            }
        }

        private void _loadCustomerInfo()
        {
            lblCustomerName.Text = $"{Customer.FirstName} {Customer.LastName}";
            lblCustomerServedDate.Text = $"Customer Since {Customer.RegisteredDate.ToString("MMM, dd/yyyy")}";
            tbAddress.Text = Customer.Address;
            tbEmail.Text = Customer.Email;
            mtbPhoneNumber.Text = Customer.Phone;
            mtbDateOfBarth.Text = Customer.DateOfBirth.ToString("MM/dd/yyyy");
            tbNationalID.Text = _isManagerOrAdmin ? Customer.NationalID : 
                (Customer.NationalID.Length >= 4 ? "***-**-" + Customer.NationalID.Substring(Customer.NationalID.Length - 4) : "***-**-????");

            _loadCustomerImage();
        }

        public void LoadCustomerInfo(string nationalID)
        {
            Customer = clsCustomers.Find(nationalID);

            if (Customer == null)
            {
                MessageBox.Show("No customer found!" , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                _loadDefault();
                return;
            }

            _loadCustomerInfo();
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
            if (!_isManagerOrAdmin)
            {
                MessageBox.Show("You do not have permission to view full customer information.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tbNationalID.Text = Customer.NationalID;
        }

        private void ctrlCustomerShortInfo_Load(object sender, EventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            _isManagerOrAdmin = (clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Manager
                               ||clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Admin);


            _loadDefault();
            frmAddOrUpdateCustomers.OnAddingOrUpdatingCustomer += LoadCustomerInfo;
        }

        private void tbNationalID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) 
                LoadCustomerInfo(tbNationalID.Text.Trim());
        }
    }
}
