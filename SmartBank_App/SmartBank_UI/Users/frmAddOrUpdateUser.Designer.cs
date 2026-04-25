namespace SmartBank_UI.Users
{
    partial class frmAddOrUpdateUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddOrUpdateUser));
            this.lblAddOrUpdateUser = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemovePhoto = new System.Windows.Forms.Button();
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.pbUserPhoto = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.lblPasswordStrength = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pbPasswordStrength = new System.Windows.Forms.ProgressBar();
            this.btnShow2 = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUserAfterEditOrAddDetails = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.ctrlUserPermissions1 = new SmartBank_UI.Users.Users_User_Control.ctrlUserPermissions();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPhoto)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddOrUpdateUser
            // 
            this.lblAddOrUpdateUser.AutoSize = true;
            this.lblAddOrUpdateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddOrUpdateUser.ForeColor = System.Drawing.Color.White;
            this.lblAddOrUpdateUser.Location = new System.Drawing.Point(23, 23);
            this.lblAddOrUpdateUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddOrUpdateUser.Name = "lblAddOrUpdateUser";
            this.lblAddOrUpdateUser.Size = new System.Drawing.Size(202, 29);
            this.lblAddOrUpdateUser.TabIndex = 4;
            this.lblAddOrUpdateUser.Text = "Adding New User";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemovePhoto);
            this.groupBox1.Controls.Add(this.btnUploadPhoto);
            this.groupBox1.Controls.Add(this.pbUserPhoto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbUsername);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbFullName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(8, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(834, 281);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Information";
            // 
            // btnRemovePhoto
            // 
            this.btnRemovePhoto.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnRemovePhoto.FlatAppearance.BorderSize = 2;
            this.btnRemovePhoto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemovePhoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnRemovePhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemovePhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemovePhoto.ForeColor = System.Drawing.Color.Red;
            this.btnRemovePhoto.Location = new System.Drawing.Point(626, 219);
            this.btnRemovePhoto.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemovePhoto.Name = "btnRemovePhoto";
            this.btnRemovePhoto.Size = new System.Drawing.Size(183, 39);
            this.btnRemovePhoto.TabIndex = 28;
            this.btnRemovePhoto.Text = "Remove Photo";
            this.btnRemovePhoto.UseVisualStyleBackColor = true;
            this.btnRemovePhoto.Visible = false;
            this.btnRemovePhoto.Click += new System.EventHandler(this.btnRemovePhoto_Click);
            // 
            // btnUploadPhoto
            // 
            this.btnUploadPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUploadPhoto.FlatAppearance.BorderSize = 2;
            this.btnUploadPhoto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnUploadPhoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnUploadPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadPhoto.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnUploadPhoto.Location = new System.Drawing.Point(626, 173);
            this.btnUploadPhoto.Margin = new System.Windows.Forms.Padding(2);
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.Size = new System.Drawing.Size(183, 39);
            this.btnUploadPhoto.TabIndex = 27;
            this.btnUploadPhoto.Text = "Upload Photo";
            this.btnUploadPhoto.UseVisualStyleBackColor = true;
            this.btnUploadPhoto.Click += new System.EventHandler(this.btnUploadPhoto_Click);
            // 
            // pbUserPhoto
            // 
            this.pbUserPhoto.Image = global::SmartBank_UI.Properties.Resources.icons8_user_50;
            this.pbUserPhoto.Location = new System.Drawing.Point(626, 24);
            this.pbUserPhoto.Margin = new System.Windows.Forms.Padding(2);
            this.pbUserPhoto.Name = "pbUserPhoto";
            this.pbUserPhoto.Size = new System.Drawing.Size(184, 135);
            this.pbUserPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUserPhoto.TabIndex = 26;
            this.pbUserPhoto.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(20, 207);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Used for login — lowercase, no spaces";
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.ForeColor = System.Drawing.Color.DimGray;
            this.tbUsername.Location = new System.Drawing.Point(20, 176);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(2);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(548, 29);
            this.tbUsername.TabIndex = 23;
            this.tbUsername.Tag = "Idle/Username/Enter Username";
            this.tbUsername.Text = "Enter Username";
            this.tbUsername.Enter += new System.EventHandler(this.tb_Enter);
            this.tbUsername.Leave += new System.EventHandler(this.tb_Leave);
            this.tbUsername.Validating += new System.ComponentModel.CancelEventHandler(this.tbUsername_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(19, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(20, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "This name will appear across the entire system";
            // 
            // tbFullName
            // 
            this.tbFullName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFullName.ForeColor = System.Drawing.Color.DimGray;
            this.tbFullName.Location = new System.Drawing.Point(22, 64);
            this.tbFullName.Margin = new System.Windows.Forms.Padding(2);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(546, 29);
            this.tbFullName.TabIndex = 13;
            this.tbFullName.Tag = "Idle/FullName/Enter Full Name";
            this.tbFullName.Text = "Enter Full Name";
            this.tbFullName.Enter += new System.EventHandler(this.tb_Enter);
            this.tbFullName.Leave += new System.EventHandler(this.tb_Leave);
            this.tbFullName.Validating += new System.ComponentModel.CancelEventHandler(this.tbFullName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(19, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Full Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUnlock);
            this.groupBox2.Controls.Add(this.btnLock);
            this.groupBox2.Controls.Add(this.lblPasswordStrength);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.pbPasswordStrength);
            this.groupBox2.Controls.Add(this.btnShow2);
            this.groupBox2.Controls.Add(this.btnShow);
            this.groupBox2.Controls.Add(this.tbConfirmPassword);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbPassword);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(8, 380);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(837, 197);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Password && Activity";
            // 
            // btnUnlock
            // 
            this.btnUnlock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlock.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnUnlock.Image = global::SmartBank_UI.Properties.Resources.icons8_unlocked_48;
            this.btnUnlock.Location = new System.Drawing.Point(527, 114);
            this.btnUnlock.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(269, 61);
            this.btnUnlock.TabIndex = 36;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUnlock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Visible = false;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // btnLock
            // 
            this.btnLock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLock.ForeColor = System.Drawing.Color.Red;
            this.btnLock.Image = global::SmartBank_UI.Properties.Resources.icons8_locked_48;
            this.btnLock.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLock.Location = new System.Drawing.Point(527, 114);
            this.btnLock.Margin = new System.Windows.Forms.Padding(2);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(269, 61);
            this.btnLock.TabIndex = 35;
            this.btnLock.Text = "Lock";
            this.btnLock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // lblPasswordStrength
            // 
            this.lblPasswordStrength.AutoSize = true;
            this.lblPasswordStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordStrength.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordStrength.Location = new System.Drawing.Point(194, 125);
            this.lblPasswordStrength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPasswordStrength.Name = "lblPasswordStrength";
            this.lblPasswordStrength.Size = new System.Drawing.Size(45, 24);
            this.lblPasswordStrength.TabIndex = 34;
            this.lblPasswordStrength.Text = "Low";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGray;
            this.label7.Location = new System.Drawing.Point(18, 125);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 24);
            this.label7.TabIndex = 33;
            this.label7.Text = "Password Strength:";
            // 
            // pbPasswordStrength
            // 
            this.pbPasswordStrength.Location = new System.Drawing.Point(22, 152);
            this.pbPasswordStrength.Name = "pbPasswordStrength";
            this.pbPasswordStrength.Size = new System.Drawing.Size(479, 23);
            this.pbPasswordStrength.TabIndex = 32;
            // 
            // btnShow2
            // 
            this.btnShow2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow2.Image = ((System.Drawing.Image)(resources.GetObject("btnShow2.Image")));
            this.btnShow2.Location = new System.Drawing.Point(758, 57);
            this.btnShow2.Name = "btnShow2";
            this.btnShow2.Size = new System.Drawing.Size(38, 29);
            this.btnShow2.TabIndex = 31;
            this.btnShow2.Tag = "ShowConfirmPassword";
            this.btnShow2.UseVisualStyleBackColor = true;
            this.btnShow2.Click += new System.EventHandler(this.btnShow2_Click);
            // 
            // btnShow
            // 
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Image = ((System.Drawing.Image)(resources.GetObject("btnShow.Image")));
            this.btnShow.Location = new System.Drawing.Point(361, 57);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(38, 29);
            this.btnShow.TabIndex = 30;
            this.btnShow.Tag = "ShowPassword";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmPassword.ForeColor = System.Drawing.Color.DimGray;
            this.tbConfirmPassword.Location = new System.Drawing.Point(419, 57);
            this.tbConfirmPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(322, 29);
            this.tbConfirmPassword.TabIndex = 29;
            this.tbConfirmPassword.Tag = "Idle/ConfirmPassword/Confirm Password";
            this.tbConfirmPassword.Text = "Confirm Password";
            this.tbConfirmPassword.Enter += new System.EventHandler(this.tb_Enter);
            this.tbConfirmPassword.Leave += new System.EventHandler(this.tb_Leave);
            this.tbConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbConfirmPassword_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGray;
            this.label8.Location = new System.Drawing.Point(415, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 24);
            this.label8.TabIndex = 28;
            this.label8.Text = "Confirm Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(20, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(368, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Minimum 8 characters — mix of letters, numbers, and symbols ";
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.ForeColor = System.Drawing.Color.DimGray;
            this.tbPassword.Location = new System.Drawing.Point(20, 57);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(325, 29);
            this.tbPassword.TabIndex = 26;
            this.tbPassword.TabStop = false;
            this.tbPassword.Tag = "Idle/Password/Enter Password";
            this.tbPassword.Text = "Enter Password";
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            this.tbPassword.Enter += new System.EventHandler(this.tb_Enter);
            this.tbPassword.Leave += new System.EventHandler(this.tb_Leave);
            this.tbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbPassword_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGray;
            this.label6.Location = new System.Drawing.Point(19, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "Password";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Silver;
            this.btnCancel.Location = new System.Drawing.Point(535, 945);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(153, 52);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblUserAfterEditOrAddDetails
            // 
            this.lblUserAfterEditOrAddDetails.AutoSize = true;
            this.lblUserAfterEditOrAddDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAfterEditOrAddDetails.ForeColor = System.Drawing.Color.DarkGray;
            this.lblUserAfterEditOrAddDetails.Location = new System.Drawing.Point(25, 52);
            this.lblUserAfterEditOrAddDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserAfterEditOrAddDetails.Name = "lblUserAfterEditOrAddDetails";
            this.lblUserAfterEditOrAddDetails.Size = new System.Drawing.Size(410, 18);
            this.lblUserAfterEditOrAddDetails.TabIndex = 5;
            this.lblUserAfterEditOrAddDetails.Text = "Fill in all required fields and upload a photo to create new user";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSaveUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUser.ForeColor = System.Drawing.Color.White;
            this.btnSaveUser.Image = global::SmartBank_UI.Properties.Resources.icons8_tick_24;
            this.btnSaveUser.Location = new System.Drawing.Point(692, 945);
            this.btnSaveUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(153, 52);
            this.btnSaveUser.TabIndex = 19;
            this.btnSaveUser.Text = "Save Customer";
            this.btnSaveUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveUser.UseVisualStyleBackColor = false;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // ctrlUserPermissions1
            // 
            this.ctrlUserPermissions1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ctrlUserPermissions1.Location = new System.Drawing.Point(8, 583);
            this.ctrlUserPermissions1.Name = "ctrlUserPermissions1";
            this.ctrlUserPermissions1.Size = new System.Drawing.Size(837, 357);
            this.ctrlUserPermissions1.TabIndex = 22;
            this.ctrlUserPermissions1.Enter += new System.EventHandler(this.ctrlUserPermissions1_Enter);
            // 
            // frmAddOrUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(854, 1005);
            this.Controls.Add(this.ctrlUserPermissions1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveUser);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblUserAfterEditOrAddDetails);
            this.Controls.Add(this.lblAddOrUpdateUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddOrUpdateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddOrUpdateUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPhoto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAddOrUpdateUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUserAfterEditOrAddDetails;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label lblPasswordStrength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar pbPasswordStrength;
        private Users_User_Control.ctrlUserPermissions ctrlUserPermissions1;
        private System.Windows.Forms.Button btnRemovePhoto;
        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.PictureBox pbUserPhoto;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnShow2;
    }
}