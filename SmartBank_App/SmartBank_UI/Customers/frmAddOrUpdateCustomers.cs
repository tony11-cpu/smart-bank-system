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

namespace SmartBank_UI
{
    public partial class frmAddOrUpdateCustomers : Form
    {
        private enum enMode { Add, Update };
        private enMode _mode;
        private clsCustomers _selectedCustomer = null;
        public static event Action<string> OnAddingOrUpdatingCustomer = null;
        private string _nationalID = null;

        public frmAddOrUpdateCustomers(string nationalID)
        {
            InitializeComponent();
            _nationalID = nationalID;
        }

        public frmAddOrUpdateCustomers()
        {
            InitializeComponent();
        }

        private void _loadDeafultFormValues()
        {
            _mode = enMode.Add;

            _selectedCustomer = new clsCustomers();
            cbGender.SelectedIndex = 0;
            lblAddOrUpdate.Text = "Add New Customers";
            lblInforamtionAboutForm.Text = "Fill in all required fields and upload a photo to register a new customer.";
        }

        private void _loadCustomerData()
        {
            mtbDateOfBirth.Text = _selectedCustomer.DateOfBirth.ToString("MM-dd-yyyy");
            cbGender.SelectedIndex = _selectedCustomer.Gender ? 1 : 0;

            if (string.IsNullOrEmpty(_selectedCustomer.ImagePath))
                _chooseImageByGender();
            else
                pbCustomerPhoto.ImageLocation = _selectedCustomer.ImagePath;

            tbFirstName.Text = _selectedCustomer.FirstName;
            _setTextboxStates(tbFirstName, false, true);

            tbLastName.Text = _selectedCustomer.LastName;
            _setTextboxStates(tbLastName, false, true);

            bool isEmpty = string.IsNullOrEmpty(_selectedCustomer.Email);
            tbEmail.Text = isEmpty ? string.Empty : _selectedCustomer.Email;
            _setTextboxStates(tbEmail, isEmpty , !isEmpty);

            tbAddress.Text = _selectedCustomer.Address;
            _setTextboxStates(tbAddress, false, true);

            tbPhone.Text = _selectedCustomer.Phone;
            _setTextboxStates(tbPhone, false, true);

            tbNationalID.Text = _selectedCustomer.NationalID;
            _setTextboxStates(tbNationalID, false, true);
        }

        private bool _isIdle(TextBox sender) => sender.Tag.ToString().StartsWith("Idle");

        private void tb_Enter(object sender, EventArgs e) => _setTextboxStates((TextBox)sender, _isIdle((TextBox)sender), true);

        private void _setTextboxStates(TextBox textBox, bool idle, bool entering)
        {
            string[] textBoxField = textBox.Tag.ToString().Split('/');
            textBox.Tag = $"{(idle ? "Idle" : "Working")}/{textBoxField[1]}/{textBoxField[2]}";
            textBox.Text = idle ? (entering ? string.Empty : textBoxField[2]) : textBox.Text;
            textBox.ForeColor = entering ? Color.White : Color.DimGray; 
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string[] textBoxFields = tb.Tag.ToString().Split('/');
            if (!string.IsNullOrWhiteSpace(tb.Text) && tb.Text.Trim() != textBoxFields[2])
            {
                tb.Tag = $"Working/{textBoxFields[1]}/{textBoxFields[2]}";
                return;
            }

            _setTextboxStates(tb, true, false);
        }

        private void ctrlAddOrUpdateCustomer_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            if (string.IsNullOrEmpty(_nationalID) || !clsCustomers.IsCustomerExists(_nationalID))
            {
                _loadDeafultFormValues();
            }
            else
            {
                _selectedCustomer = clsCustomers.Find(_nationalID);
                _mode = enMode.Update;
                _loadCustomerData();
                btnRemovePhoto.Visible = !string.IsNullOrEmpty(pbCustomerPhoto.ImageLocation);
                tbNationalID.ReadOnly = true;
                lblAddOrUpdate.Text = "Update Customer";
                lblInforamtionAboutForm.Text = "You can update the customer information in this form.";
            }
        }

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
                string newPath = @pbCustomerPhoto.ImageLocation;

                if (!clsUtil.CopyImageToProjectImagesFolder(ref newPath)) 
                    throw new IOException("Error copying image file");

                pbCustomerPhoto.ImageLocation = newPath;
            }

            return true;
        }

        private bool _fillCustomerData()
        {
            if (!_handleCustomerImage())
                return false;

            _selectedCustomer.FirstName = tbFirstName.Text.Trim();
            _selectedCustomer.LastName = tbLastName.Text.Trim();
            _selectedCustomer.NationalID = tbNationalID.Text.Trim();
            _selectedCustomer.DateOfBirth = Convert.ToDateTime(mtbDateOfBirth.Text.Trim());
            _selectedCustomer.Gender = cbGender.SelectedIndex != 0;
            _selectedCustomer.Phone = tbPhone.Text.Trim();
            _selectedCustomer.Email = _isIdle(tbEmail) ? null : tbEmail.Text.Trim();
            _selectedCustomer.Address = tbAddress.Text.Trim();
            _selectedCustomer.ImagePath = pbCustomerPhoto.ImageLocation;
            return true;
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            if (_fillCustomerData() && _selectedCustomer.Save())
            {
                _mode = enMode.Update;
                tbNationalID.ReadOnly = true;
                OnAddingOrUpdatingCustomer?.Invoke(_selectedCustomer.NationalID);
                lblAddOrUpdate.Text = "Update Customer";
                lblInforamtionAboutForm.Text = "You can update the customer information in this form.";
                MessageBox.Show("Customer info saved successfully.", $"{(_mode == enMode.Add ? "Added Successfuly" : "Updated Successfuly")}", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save customer info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _chooseImageByGender() => pbCustomerPhoto.Image = cbGender.SelectedIndex == 0 ? Resources.icons8_person_80 :
                                                                                                     Resources.icons8_person_female_skin_type_1_and_2_80;
        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pbCustomerPhoto.ImageLocation))
            {
                _chooseImageByGender();
            }
        }

        private void mtbDateOfBirth_Validating(object sender, CancelEventArgs e)
        {
            if (!mtbDateOfBirth.MaskCompleted)
            {
                errorProvider1.SetError(mtbDateOfBirth, "Date of birth field cannot be empty!");
                e.Cancel = true;
            }
            else if (!DateTime.TryParse(mtbDateOfBirth.Text, out DateTime dateOfBirth))
            {
                errorProvider1.SetError(mtbDateOfBirth, "Invalid date!");
                e.Cancel = true;
            }
            else
            {
                bool isValid = dateOfBirth.CompareTo(DateTime.Now.AddYears(-100)) >= 0 && dateOfBirth.CompareTo(DateTime.Now.AddYears(-18)) <= 0;
                errorProvider1.SetError(mtbDateOfBirth, isValid ? null : "Age must be between 18 and 100 years!");
                e.Cancel = !isValid;
            }
        }

        private void tb_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            bool isIdle = _isIdle(tb);
            errorProvider1.SetError(tb, isIdle ? "This field cannot be empty!" : null);
            e.Cancel = isIdle;
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            string text = tbEmail.Text.Trim();
            if (_isIdle(tbEmail) || string.IsNullOrWhiteSpace(text))
            {
                errorProvider1.SetError(tbEmail, null);
                return;
            }

            string[] parts = text.Split('@');
            bool isValidEmail = parts.Length == 2 &&
                                parts[0].Length >= 3 &&
                                parts[1].Length >= 4 &&
                                parts[1].Contains('.') &&
                                parts[1].Split('.')[1].Length > 1 &&
                                parts[1].Split('.')[0].Length >= 3;

            errorProvider1.SetError(tbEmail, isValidEmail ? null : "Email is not valid!");
            e.Cancel = !isValidEmail;
        }

        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(tbPhone, null);

            if (_isIdle(tbPhone))
            {
                errorProvider1.SetError(tbPhone, "Phone must be filled.");
                e.Cancel = true;
            }
            else if (!tbPhone.Text.Trim().All(char.IsDigit))
            {
                errorProvider1.SetError(tbPhone, "Phone can only contain digits.");
                e.Cancel = true;
            }
            else if(tbPhone.Text.Trim().Length < 9)
            {
                errorProvider1.SetError(tbPhone, "Phone can not be less than 9 digits.");
                e.Cancel = true;
            }
        }

        private void tbNationalID_Validating(object sender, CancelEventArgs e)
        {
            if (_isIdle(tbNationalID))
            {
                errorProvider1.SetError(tbNationalID, "National id cannot be empty!");
                e.Cancel = true;
            }
            else if (clsCustomers.IsCustomerExists(tbNationalID.Text.Trim()) && _mode == enMode.Add)
            {
                errorProvider1.SetError(tbNationalID, "National id is already in use!");
                e.Cancel = true;
            }
            else if(tbNationalID.Text.Trim().Length < 9)
            {
                errorProvider1.SetError(tbNationalID, "National id cannot be less than 9 letters/digits!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbNationalID, null);
            }
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
