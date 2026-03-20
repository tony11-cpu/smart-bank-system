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
    public partial class ctrlCustomerShortInfo : UserControl
    {
        private bool _isManagerOrAdmin;
        private clsCustomers _customer;

        public ctrlCustomerShortInfo()
        {
            InitializeComponent();
        }

        private void _defaultLoad()
        {
            lblCustomerName.Text = "Customer Name";
            lblCustomerServedDate.Text = "Customer Since Jan, 00/00/0000";
            pbCustomerPhoto.Image = Properties.Resources.icons8_person_80;
            mtbDateOfBarth.Text = "00/00/0000";
            mtbPhoneNumber.Text = "0000000000";
            tbEmail.Text = "User Email";
            tbAddress.Text = "User Address";
        }

        private void _loadCustomerPhoto()
        {
            if (!string.IsNullOrEmpty(_customer.ImagePath))
            {
                try
                {
                    using (var imgStream = new System.IO.FileStream(_customer.ImagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        pbCustomerPhoto.Image = Image.FromStream(imgStream);
                    }
                }
                catch
                {
                    pbCustomerPhoto.Image = Properties.Resources.icons8_person_80;
                }
            }
            else
            {
                pbCustomerPhoto.Image = _customer.Gender ? Properties.Resources.icons8_person_female_skin_type_1_and_2_80
                                                         : Properties.Resources.icons8_person_80;
            }
        }

        private void _loadCustomerInfo()
        {
            lblCustomerName.Text = $"{_customer.FirstName} {_customer.LastName}";
            lblCustomerServedDate.Text = $"Customer Since {_customer.RegisteredDate.ToString("MMM, dd/yyyy")}";
            tbAddress.Text = _customer.Address;
            tbEmail.Text = _customer.Email;
            mtbPhoneNumber.Text = _customer.Phone;
            mtbDateOfBarth.Text = _customer.DateOfBirth.ToString("MM/dd/yyyy");
            tbNationalID.Text = _customer.NationalID.Length >= 4 ? "***-**-" + _customer.NationalID.Substring(_customer.NationalID.Length - 4) : "***-**-????";

            _loadCustomerPhoto();
        }

        public void LoadCustomerInfo(string nationalID)
        {
            _customer = clsCustomers.Find(nationalID);
            if (_customer == null)
            {
                _defaultLoad();
                return;
            }

            _loadCustomerInfo();
        }

        private void lblLinkToFullID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!_isManagerOrAdmin)
            {
                MessageBox.Show("You do not have permission to view full customer information.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tbNationalID.Text = _customer == null ? tbNationalID.Text : _customer.NationalID;
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (!_isManagerOrAdmin)
            {
                MessageBox.Show("You do not have permission to deactivate customers.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to deactivate this customer?", "Confirm Deactivation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes && _customer != null && _customer.Deactivate())
            {
                MessageBox.Show("Customer deactivated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _loadCustomerInfo();
            }
        }

        private void ctrlCustomerShortInfo_Load(object sender, EventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            _isManagerOrAdmin = (clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Manager
                             || clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Admin);

            _defaultLoad();
        }

        private void tbNationalID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadCustomerInfo(tbNationalID.Text.Trim());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
