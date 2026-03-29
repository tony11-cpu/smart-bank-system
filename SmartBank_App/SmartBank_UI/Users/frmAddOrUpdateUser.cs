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

namespace SmartBank_UI.Users
{
    public partial class frmAddOrUpdateUser : Form
    {
        private enum enMode { Add, Update };
        private enMode _mode;
        private clsUsers _selectedUser;
        private string _userName;
        public event Action<string> OnNewUserAdded;
        private (bool isPasswordValid , bool is2PasswordsSame) _isPassValid;

        public frmAddOrUpdateUser()
        {
            InitializeComponent();
        }

        public frmAddOrUpdateUser(string username)
        {
            InitializeComponent();
            _userName = username;
        }

        private bool _handleCustomerImage()
        {
            if (_selectedUser.ImagePath == pbUserPhoto.ImageLocation)
                return true;

            if (File.Exists(_selectedUser.ImagePath))
            {
                pbUserPhoto.Image?.Dispose();
                pbUserPhoto.Image = Resources.icons8_user_50;

                File.Delete(_selectedUser.ImagePath);
            }

            if (!string.IsNullOrWhiteSpace(pbUserPhoto.ImageLocation))
            {
                string newPath = pbUserPhoto.ImageLocation;

                if (!clsUtil.CopyImageToProjectImagesFolder(ref newPath))
                    throw new IOException("Error copying image file");

                pbUserPhoto.ImageLocation = newPath;
            }

            return true;
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren() || !_isPassValid.is2PasswordsSame)
                return;

            _fetchUserInfo();
            if(_selectedUser.Save())
            {
                _mode = enMode.Update;
                lblAddOrUpdateUser.Text = "Update User";
                MessageBox.Show("User data saved successfuly!", $"{(_mode == enMode.Add ? "Added Successfuly" : "Updated Successfulu")}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnNewUserAdded?.Invoke(_selectedUser.Username);
            }
            else
            {
                MessageBox.Show("Errr while saving user's data please try again!", "Error saving user", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _fetchUserInfo()
        {
            if (!_handleCustomerImage())
                return;

            _selectedUser.FullName = tbFullName.Text.Trim();
            _selectedUser.Username = tbUsername.Text.Trim();
            _selectedUser.Password = tbConfirmPassword.Text.Trim();
            _selectedUser.Permissions = ctrlUserPermissions1.Permissions;
            _selectedUser.ImagePath = pbUserPhoto.ImageLocation;
            _selectedUser.IsLocked = !(rbDefaut.Checked || rbFree.Checked);
        }

        private void _loadUserInfo()
        {
            tbFullName.Text = _selectedUser.FullName;
            _setTextboxStates(tbFullName, false, true);

            tbUsername.Text = _selectedUser.Username;
            _setTextboxStates(tbUsername, false, true);

            if(string.IsNullOrEmpty(_selectedUser.ImagePath))
                pbUserPhoto.Image = Resources.icons8_user_50;
            else
                pbUserPhoto.ImageLocation = _selectedUser.ImagePath;

            btnRemovePhoto.Visible = !string.IsNullOrEmpty(pbUserPhoto.ImageLocation);

            rbFree.Checked = !_selectedUser.IsLocked;
            rbLocked.Checked = _selectedUser.IsLocked;
        }

        private void frmAddOrUpdateUser_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_userName) || !clsUsers.IsUserExists(_userName))
            {
                _selectedUser = new clsUsers();
                _mode = enMode.Add;
                rbDefaut.Checked = true;
            }
            else
            {
                lblAddOrUpdateUser.Text = "Update User";
                lblUserAfterEditOrAddDetails.Text = "You can update the user information in this form.";

                _selectedUser = clsUsers.Find(_userName);
                _mode = enMode.Update;
                _loadUserInfo();
                _checkPasswordStrength();
                ctrlUserPermissions1.LoadPermissions(_selectedUser.Permissions.Permissions);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private bool _isIdle(TextBox sender) => sender.Tag.ToString().StartsWith("Idle");

        private void tb_Enter(object sender, EventArgs e) => _setTextboxStates((TextBox)sender, _isIdle((TextBox)sender), true);

        private void _setTextboxStates(TextBox textBox, bool idle, bool entering)
        {
            string[] textBoxField = textBox.Tag.ToString().Split('/');
            textBox.Tag = $"{(idle ? "Idle" : "Working")}/{textBoxField[1]}/{textBoxField[2]}";
            textBox.Text = idle ? (entering ? string.Empty : textBoxField[2]) : textBox.Text;
            textBox.ForeColor = entering ? Color.White : Color.DimGray;
            textBox.PasswordChar = textBoxField[1].Contains("Password") && entering ? '*' : default;
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

        private void tbFullName_Validating(object sender, CancelEventArgs e)
        {
            bool isIdle = _isIdle(tbFullName);
            errorProvider1.SetError(tbFullName, isIdle ? "Full name cannot be empty!" : null);
            e.Cancel = isIdle;
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbUserPhoto.ImageLocation = openFileDialog1.FileName;
                btnRemovePhoto.Visible = true;
            }
        }

        private void btnRemovePhoto_Click(object sender, EventArgs e)
        {
            btnRemovePhoto.Visible = false;
            pbUserPhoto.ImageLocation = null;
            pbUserPhoto.Image = Resources.icons8_user_50;
        }

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if(_isIdle(tbUsername))
            {
                errorProvider1.SetError(tbUsername, "Username cannot be empty!");
                e.Cancel = true;
            }
            else if(clsUsers.IsUserExists(tbUsername.Text) && _mode == enMode.Add)
            {
                errorProvider1.SetError(tbUsername, "Username already exists, try use other one!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbUsername, null);
            }
        }

        private void _setPasswordStrengthProgress(int? StrengthPercent)
        {
            if(StrengthPercent == null)
            {
                lblPasswordStrength.Text = "Valid Password";
                lblPasswordStrength.ForeColor = Color.BlueViolet;
                StrengthPercent = 100;
            }
            else
            {
                if (pbPasswordStrength.Maximum < StrengthPercent)
                    throw new InvalidOperationException("Password Strength Progress Can Only Set For 100 Or Below");

                if (StrengthPercent <= 25)
                {
                    lblPasswordStrength.Text = "Low";
                    lblPasswordStrength.ForeColor = Color.Red;
                }
                else if (StrengthPercent <= 50)
                {
                    lblPasswordStrength.Text = "Medium";
                    lblPasswordStrength.ForeColor = Color.Orange;
                }
                else if (StrengthPercent <= 75)
                {
                    lblPasswordStrength.Text = "Strong";
                    lblPasswordStrength.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lblPasswordStrength.Text = "Very Strong";
                    lblPasswordStrength.ForeColor = Color.Green;
                }
            }

            lblPasswordStrength.Refresh();
            pbPasswordStrength.Value = StrengthPercent ?? 0;
            pbPasswordStrength.Refresh();
        }

        private bool _checkPasswordStrength()
        {
            if (_isIdle(tbPassword))
            {
                if (_mode == enMode.Update)
                {
                    _setPasswordStrengthProgress(null);
                    errorProvider1.SetError(tbPassword, null);
                    return true;
                }

                errorProvider1.SetError(tbPassword, "Password cannot be empty!");
                _setPasswordStrengthProgress(0);
                return false;
            }
            else if (tbPassword.Text.Trim().Length < 8)
            {
                errorProvider1.SetError(tbPassword, "Password can only be 8 charecters or more!");
                _setPasswordStrengthProgress(15);
                return false;
            }
            else if (tbPassword.Text.All(c => char.IsDigit(c) || !tbPassword.Text.Any(n => char.IsDigit(n))))
            {
                _setPasswordStrengthProgress(50);
                errorProvider1.SetError(tbPassword, "Passowrd must be mix of letters and numeric values!");
                return false;
            }
            else if (!tbPassword.Text.Any(n => !char.IsLetterOrDigit(n)))
            {
                _setPasswordStrengthProgress(75);
                errorProvider1.SetError(tbPassword, "Passowrd will be more secured when sepcial chars are added!");
            }
            else
            {
                _setPasswordStrengthProgress(100);
                errorProvider1.SetError(tbPassword, null);
            }

            return true;
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e) => _isPassValid.isPasswordValid = _checkPasswordStrength();

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_mode == enMode.Update && _isIdle(tbConfirmPassword))
            {
                _isPassValid.is2PasswordsSame = true;
            }
            else if(tbPassword.Text != tbConfirmPassword.Text)
            {
                errorProvider1.SetError(tbConfirmPassword, "Password is not the same!");
                _isPassValid.is2PasswordsSame = false;
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, null);
                _isPassValid.is2PasswordsSame = true;
            }
        }

        private void btnShow_Click(object sender, EventArgs e) => tbPassword.PasswordChar = _isIdle(tbPassword) ? default : (tbPassword.PasswordChar == default ? '*' : default);

        private void btnShow2_Click(object sender, EventArgs e) => tbConfirmPassword.PasswordChar = _isIdle(tbConfirmPassword) ? default : (tbConfirmPassword.PasswordChar == default ? '*' : default);

        private void tbPassword_TextChanged(object sender, EventArgs e) => _checkPasswordStrength();

    }
}
