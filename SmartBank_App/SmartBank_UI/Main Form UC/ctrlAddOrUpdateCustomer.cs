using SmartBank;
using SmartBank_BLL;
using SmartBank_UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SmartBank_UI.Main_Form_UC
{
    public partial class ctrlAddOrUpdateCustomer : UserControl
    {
        private enum enMode { Add, Update };
        private enMode _mode;
        private string _nationalID;
        private clsCustomers _selectedCustomer;

        public ctrlAddOrUpdateCustomer()
        {
            InitializeComponent();
            _mode = enMode.Add;
        }

        public void LoadCustomer(string nationalID)
        {
            this._nationalID = nationalID;
            _mode = nationalID == null ? enMode.Add : enMode.Update;
        }

        private void _loadCustomerData()
        {
            tbFirstName.Text = _selectedCustomer.FirstName;
            tbLastName.Text = _selectedCustomer.LastName;
            tbEmail.Text = _selectedCustomer.Email ?? "No Email";
            tbAddress.Text = _selectedCustomer.Address;
            tbPhone.Text = _selectedCustomer.Phone;
            mtbDateOfBirth.Text = _selectedCustomer.DateOfBirth.ToString("yyyy-MM-dd");
            cbGender.SelectedIndex = _selectedCustomer.Gender ? 1 : 0;
        }

        private void ctrlAddOrUpdateCustomer_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            if(_mode == enMode.Add && _nationalID == null)
            {
                _selectedCustomer = new clsCustomers();
                cbGender.SelectedIndex = 0;

                lblAddOrUpdate.Text = "Add New Customers";
                lblInforamtionAboutForm.Text = "Fill in all required fields and upload a photo to register a new customer.";
            }
            else 
            {
                _selectedCustomer = clsCustomers.Find(_nationalID);

                if (_selectedCustomer != null)
                {
                    _mode = enMode.Update;
                    lblAddOrUpdate.Text = "Update Customer";
                    lblInforamtionAboutForm.Text = "You can update the customer information in this form.";
                    _loadCustomerData();
                }
            }            
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.ParentForm.Close();

        private bool _handleCustomerImage()
        {
            if (_selectedCustomer.ImagePath == pbCustomerPhoto.ImageLocation)
                return true;

            if (File.Exists(_selectedCustomer.ImagePath))
            {
                pbCustomerPhoto.Image?.Dispose();
                pbCustomerPhoto.Image = cbGender.SelectedIndex == 0 ? Resources.icons8_person_80 : Resources.icons8_person_female_skin_type_1_and_2_80;

                File.Delete(_selectedCustomer.ImagePath);
            }

            if (!string.IsNullOrWhiteSpace(pbCustomerPhoto.ImageLocation))
            {
                string newPath = pbCustomerPhoto.ImageLocation;
                if (!clsUtil.CopyImageToProjectImagesFolder(ref newPath)) 
                    throw new IOException("Error copying image file");

                pbCustomerPhoto.ImageLocation = newPath;
                _selectedCustomer.ImagePath = newPath;
            }

            return true;
        }

        private bool _fillCustomerData()
        {
            _selectedCustomer.FirstName = tbFirstName.Text.Trim();
            _selectedCustomer.LastName = tbLastName.Text.Trim();
            _selectedCustomer.NationalID = tbNationalID.Text.Trim();
            _selectedCustomer.DateOfBirth = Convert.ToDateTime(mtbDateOfBirth.Text.Trim());
            _selectedCustomer.Gender = cbGender.SelectedIndex == 0 ? false : true;
            _selectedCustomer.Phone = tbPhone.Text.Trim();
            _selectedCustomer.Email = tbEmail.Text.Trim();
            _selectedCustomer.Address = tbAddress.Text.Trim();
            _selectedCustomer.ImagePath = pbCustomerPhoto.ImageLocation;

            return _handleCustomerImage();
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            if (_fillCustomerData() && _selectedCustomer.Save())
            {
                lblAddOrUpdate.Text = "Update Customer";
                lblInforamtionAboutForm.Text = "You can update the customer information in this form.";

                MessageBox.Show("Customer info saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Failed to save customer info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _chooseImageByGender() => pbCustomerPhoto.Image = cbGender.SelectedIndex == 0 ? Resources.icons8_person_80 : 
                                                                                                     Resources.icons8_person_female_skin_type_1_and_2_80;

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(pbCustomerPhoto.ImageLocation)) 
                _chooseImageByGender();
        }

        private bool _isTBidle(TextBox sender) => sender.Tag.ToString().StartsWith("Idle");

        private void tb_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.ForeColor = Color.White;
            if (_isTBidle(tb))
                tb.Text = string.Empty;
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string[] textBoxField = tb.Tag.ToString().Split('/');

            if (!string.IsNullOrWhiteSpace(tb.Text) && tb.Text.Trim() != textBoxField[2])
            {
                tb.Tag = $"Working/{textBoxField[1]}/{textBoxField[2]}";
                return;
            }

            tb.Tag = $"Idle/{textBoxField[1]}/{textBoxField[2]}";
            tb.ForeColor = Color.DimGray;
            tb.Text = textBoxField[2];
        }

        private void mtb_Validating(object sender, CancelEventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            errorProvider1.SetError(mtb, !mtb.MaskCompleted ? "This field cannot be empty!" : null);
        }

        private void tb_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            errorProvider1.SetError(tb, _isTBidle(tb) ? "This field cannot be empty! "  : null);
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            string[] isValid = tbEmail.Text.Trim().Split('@');
            errorProvider1.SetError(tbEmail, (isValid.Length > 1 &&
                isValid[1].Length >= 4 && isValid[1].Contains('.')
                && isValid[1].Split('.')[1].Length > 1 || _isTBidle(tbEmail)) 
                ? null : "Email field is not valid! ");
        }

        private void tbPhone_Validating(object sender, CancelEventArgs e) => errorProvider1.SetError(tbPhone, !_isTBidle(tbPhone) && tbPhone.Text.All(char.IsDigit) ? null : "Phone is not valid!");

        private void tbNationalID_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(tbNationalID, null);

            if (clsCustomers.IsCustomerExists(tbNationalID.Text.Trim()))
                errorProvider1.SetError(tbNationalID, "National ID is already in use!");

            if(_isTBidle(tbNationalID))
                errorProvider1.SetError(tbNationalID, "National ID is invalid!");
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbCustomerPhoto.ImageLocation = openFileDialog1.FileName;
                btnRemovePhoto.Visible = true;
            }
        }

        private void btnRemovePhoto_Click(object sender, EventArgs e)
        {
            btnRemovePhoto.Visible = false;
            pbCustomerPhoto.ImageLocation = null;

            _chooseImageByGender();
        }
    }
}
