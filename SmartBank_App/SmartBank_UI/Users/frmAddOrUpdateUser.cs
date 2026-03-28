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
            if (!ValidateChildren())
                return;

            _fetchUserInfo();
            if(_selectedUser.Save())
            {
                _mode = enMode.Update;
                lblAddOrUpdateUser.Text = "Update User";

                MessageBox.Show("User data saved successfuly!", $"{(_mode == enMode.Add ? "Added Successfuly" : "Updated Successfulu")}", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            _selectedUser.Permissions = new clsPermissions(ctrlUserPermissions1.Permissions);
        }

        private void _loadUserInfo()
        {
            tbFullName.Text = _selectedUser.FullName;
            tbUsername.Text = _selectedUser.Username;
            pbUserPhoto.ImageLocation = _selectedUser.ImagePath;
        }

        private void frmAddOrUpdateUser_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_userName))
            {
                _selectedUser = new clsUsers();
                _mode = enMode.Add;
            }
            else
            {
                _selectedUser = clsUsers.Find(_userName);
                if (_selectedUser == null)
                    return;

                _mode = enMode.Update;
                _loadUserInfo();

                lblAddOrUpdateUser.Text = "Update User";
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
        }

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if(_isIdle(tbUsername))
            {
                errorProvider1.SetError(tbUsername, "Username cannot be empty!");
                e.Cancel = true;
            }
            else if(clsUsers.IsUserExists(tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "Username already exists, try use other one!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbUsername, null);
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if(_isIdle(tbPassword))
            {
                errorProvider1.SetError(tbPassword, "Password cannot be empty!");
                e.Cancel = true;
            }
            else if(tbPassword.Text.Trim().Length < 8)
            {
                errorProvider1.SetError(tbPassword, "Password can only be 8 charecters or more!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbPassword, null);
            }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(tbPassword.Text != tbConfirmPassword.Text)
            {
                errorProvider1.SetError(tbConfirmPassword, "Password is not the same");
                e.Cancel = true;
                return;
            }

            errorProvider1.SetError(tbConfirmPassword, null);
        }

        private void btnShow_Click(object sender, EventArgs e) => tbPassword.PasswordChar = tbPassword.PasswordChar == '*' ? default : '*';

        private void btnShow2_Click(object sender, EventArgs e) => tbConfirmPassword.PasswordChar = tbConfirmPassword.PasswordChar == '*' ? default : '*';

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbPassword.Text))
                tbPassword.PasswordChar = default;
            else 
                tbPassword.PasswordChar = '*';
        }

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbConfirmPassword.Text))
                tbConfirmPassword.PasswordChar = default;
            else
                tbConfirmPassword.PasswordChar = '*';
        }
    }
}
