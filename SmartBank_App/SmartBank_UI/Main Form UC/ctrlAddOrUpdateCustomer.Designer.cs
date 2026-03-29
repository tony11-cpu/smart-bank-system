namespace SmartBank_UI.Main_Form_UC
{
    partial class ctrlAddOrUpdateCustomer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.btnRemovePhoto = new System.Windows.Forms.Button();
            this.lblInforamtionAboutForm = new System.Windows.Forms.Label();
            this.lblAddOrUpdate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.mtbDateOfBirth = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNationalID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSaveCustomer = new System.Windows.Forms.Button();
            this.pbCustomerPhoto = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomerPhoto)).BeginInit();
            this.SuspendLayout();
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
            this.btnUploadPhoto.Location = new System.Drawing.Point(34, 425);
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.Size = new System.Drawing.Size(275, 60);
            this.btnUploadPhoto.TabIndex = 1;
            this.btnUploadPhoto.Text = "Upload Photo";
            this.btnUploadPhoto.UseVisualStyleBackColor = true;
            this.btnUploadPhoto.Click += new System.EventHandler(this.btnUploadPhoto_Click);
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
            this.btnRemovePhoto.Location = new System.Drawing.Point(35, 503);
            this.btnRemovePhoto.Name = "btnRemovePhoto";
            this.btnRemovePhoto.Size = new System.Drawing.Size(275, 60);
            this.btnRemovePhoto.TabIndex = 2;
            this.btnRemovePhoto.Text = "Remove Photo";
            this.btnRemovePhoto.UseVisualStyleBackColor = true;
            this.btnRemovePhoto.Visible = false;
            this.btnRemovePhoto.Click += new System.EventHandler(this.btnRemovePhoto_Click);
            // 
            // lblInforamtionAboutForm
            // 
            this.lblInforamtionAboutForm.AutoSize = true;
            this.lblInforamtionAboutForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInforamtionAboutForm.ForeColor = System.Drawing.Color.DarkGray;
            this.lblInforamtionAboutForm.Location = new System.Drawing.Point(30, 65);
            this.lblInforamtionAboutForm.Name = "lblInforamtionAboutForm";
            this.lblInforamtionAboutForm.Size = new System.Drawing.Size(692, 26);
            this.lblInforamtionAboutForm.TabIndex = 5;
            this.lblInforamtionAboutForm.Text = "Fill in all required fields and upload a photo to register a new customer.";
            // 
            // lblAddOrUpdate
            // 
            this.lblAddOrUpdate.AutoSize = true;
            this.lblAddOrUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddOrUpdate.ForeColor = System.Drawing.Color.White;
            this.lblAddOrUpdate.Location = new System.Drawing.Point(28, 25);
            this.lblAddOrUpdate.Name = "lblAddOrUpdate";
            this.lblAddOrUpdate.Size = new System.Drawing.Size(347, 40);
            this.lblAddOrUpdate.TabIndex = 4;
            this.lblAddOrUpdate.Text = "Add New Customers";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbGender);
            this.panel1.Controls.Add(this.mtbDateOfBirth);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbNationalID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbLastName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbFirstName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(345, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 418);
            this.panel1.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkGray;
            this.label9.Location = new System.Drawing.Point(304, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 32);
            this.label9.TabIndex = 19;
            this.label9.Text = "Gender";
            // 
            // cbGender
            // 
            this.cbGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGender.ForeColor = System.Drawing.Color.White;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbGender.Location = new System.Drawing.Point(310, 349);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(193, 40);
            this.cbGender.TabIndex = 18;
            this.cbGender.SelectedIndexChanged += new System.EventHandler(this.cbGender_SelectedIndexChanged);
            // 
            // mtbDateOfBirth
            // 
            this.mtbDateOfBirth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.mtbDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDateOfBirth.ForeColor = System.Drawing.Color.Transparent;
            this.mtbDateOfBirth.Location = new System.Drawing.Point(25, 350);
            this.mtbDateOfBirth.Mask = "00/00/0000";
            this.mtbDateOfBirth.Name = "mtbDateOfBirth";
            this.mtbDateOfBirth.Size = new System.Drawing.Size(248, 39);
            this.mtbDateOfBirth.TabIndex = 17;
            this.mtbDateOfBirth.Tag = "";
            this.mtbDateOfBirth.ValidatingType = typeof(System.DateTime);
            this.mtbDateOfBirth.Validating += new System.ComponentModel.CancelEventHandler(this.mtbDateOfBirth_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(19, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 32);
            this.label5.TabIndex = 16;
            this.label5.Text = "Date Of Birth";
            // 
            // tbNationalID
            // 
            this.tbNationalID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbNationalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNationalID.ForeColor = System.Drawing.Color.DimGray;
            this.tbNationalID.Location = new System.Drawing.Point(25, 251);
            this.tbNationalID.Name = "tbNationalID";
            this.tbNationalID.Size = new System.Drawing.Size(478, 39);
            this.tbNationalID.TabIndex = 15;
            this.tbNationalID.Tag = "Idle/NationalID/e.g. 123-45-6789";
            this.tbNationalID.Text = "e.g. 123-45-6789";
            this.tbNationalID.Enter += new System.EventHandler(this.tb_Enter);
            this.tbNationalID.Leave += new System.EventHandler(this.tb_Leave);
            this.tbNationalID.Validating += new System.ComponentModel.CancelEventHandler(this.tbNationalID_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(21, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 32);
            this.label4.TabIndex = 14;
            this.label4.Text = "National ID";
            // 
            // tbLastName
            // 
            this.tbLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastName.ForeColor = System.Drawing.Color.DimGray;
            this.tbLastName.Location = new System.Drawing.Point(25, 152);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(478, 39);
            this.tbLastName.TabIndex = 13;
            this.tbLastName.Tag = "Idle/LastName/Enter Last Name...";
            this.tbLastName.Text = "Enter Last Name...";
            this.tbLastName.Enter += new System.EventHandler(this.tb_Enter);
            this.tbLastName.Leave += new System.EventHandler(this.tb_Leave);
            this.tbLastName.Validating += new System.ComponentModel.CancelEventHandler(this.tb_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(21, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "Last Name";
            // 
            // tbFirstName
            // 
            this.tbFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFirstName.ForeColor = System.Drawing.Color.DimGray;
            this.tbFirstName.Location = new System.Drawing.Point(25, 53);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(477, 39);
            this.tbFirstName.TabIndex = 11;
            this.tbFirstName.Tag = "Idle/FirstName/Enter First Name...";
            this.tbFirstName.Text = "Enter First Name...";
            this.tbFirstName.Enter += new System.EventHandler(this.tb_Enter);
            this.tbFirstName.Leave += new System.EventHandler(this.tb_Leave);
            this.tbFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.tb_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(19, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 32);
            this.label2.TabIndex = 10;
            this.label2.Text = "First Name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.tbPhone);
            this.panel2.Controls.Add(this.tbAddress);
            this.panel2.Controls.Add(this.tbEmail);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(35, 593);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 224);
            this.panel2.TabIndex = 7;
            // 
            // tbPhone
            // 
            this.tbPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPhone.ForeColor = System.Drawing.Color.DimGray;
            this.tbPhone.Location = new System.Drawing.Point(19, 55);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(376, 37);
            this.tbPhone.TabIndex = 24;
            this.tbPhone.Tag = "Idle/Phone/e.g. 718-555-0000";
            this.tbPhone.Text = "e.g. 718-555-0000";
            this.tbPhone.Enter += new System.EventHandler(this.tb_Enter);
            this.tbPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPhone_KeyPress);
            this.tbPhone.Leave += new System.EventHandler(this.tb_Leave);
            this.tbPhone.Validating += new System.ComponentModel.CancelEventHandler(this.tbPhone_Validating);
            // 
            // tbAddress
            // 
            this.tbAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress.ForeColor = System.Drawing.Color.DimGray;
            this.tbAddress.Location = new System.Drawing.Point(19, 157);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(794, 37);
            this.tbAddress.TabIndex = 23;
            this.tbAddress.Tag = "Idle/Address/Street address, City, State, ZIP";
            this.tbAddress.Text = "Street address, City, State, ZIP";
            this.tbAddress.Enter += new System.EventHandler(this.tb_Enter);
            this.tbAddress.Leave += new System.EventHandler(this.tb_Leave);
            this.tbAddress.Validating += new System.ComponentModel.CancelEventHandler(this.tb_Validating);
            // 
            // tbEmail
            // 
            this.tbEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.ForeColor = System.Drawing.Color.DimGray;
            this.tbEmail.Location = new System.Drawing.Point(428, 55);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(385, 37);
            this.tbEmail.TabIndex = 18;
            this.tbEmail.Tag = "Idle/Email/customer@gmail.com";
            this.tbEmail.Text = "customer@gmail.com";
            this.tbEmail.Enter += new System.EventHandler(this.tb_Enter);
            this.tbEmail.Leave += new System.EventHandler(this.tb_Leave);
            this.tbEmail.Validating += new System.ComponentModel.CancelEventHandler(this.tbEmail_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGray;
            this.label8.Location = new System.Drawing.Point(422, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 32);
            this.label8.TabIndex = 22;
            this.label8.Text = "Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGray;
            this.label7.Location = new System.Drawing.Point(19, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 32);
            this.label7.TabIndex = 20;
            this.label7.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGray;
            this.label6.Location = new System.Drawing.Point(13, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 32);
            this.label6.TabIndex = 18;
            this.label6.Text = "Phone";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCancel.Location = new System.Drawing.Point(408, 839);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(229, 80);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 500;
            this.errorProvider1.ContainerControl = this;
            // 
            // btnSaveCustomer
            // 
            this.btnSaveCustomer.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSaveCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCustomer.Image = global::SmartBank_UI.Properties.Resources.icons8_tick_24;
            this.btnSaveCustomer.Location = new System.Drawing.Point(643, 839);
            this.btnSaveCustomer.Name = "btnSaveCustomer";
            this.btnSaveCustomer.Size = new System.Drawing.Size(229, 80);
            this.btnSaveCustomer.TabIndex = 8;
            this.btnSaveCustomer.Text = "Save Customer";
            this.btnSaveCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveCustomer.UseVisualStyleBackColor = false;
            this.btnSaveCustomer.Click += new System.EventHandler(this.btnSaveCustomer_Click);
            // 
            // pbCustomerPhoto
            // 
            this.pbCustomerPhoto.Location = new System.Drawing.Point(33, 145);
            this.pbCustomerPhoto.Name = "pbCustomerPhoto";
            this.pbCustomerPhoto.Size = new System.Drawing.Size(276, 260);
            this.pbCustomerPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCustomerPhoto.TabIndex = 0;
            this.pbCustomerPhoto.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "jpg";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Select an Image";
            // 
            // ctrlAddOrUpdateCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveCustomer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblInforamtionAboutForm);
            this.Controls.Add(this.lblAddOrUpdate);
            this.Controls.Add(this.btnRemovePhoto);
            this.Controls.Add(this.btnUploadPhoto);
            this.Controls.Add(this.pbCustomerPhoto);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ctrlAddOrUpdateCustomer";
            this.Size = new System.Drawing.Size(904, 936);
            this.Load += new System.EventHandler(this.ctrlAddOrUpdateCustomer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomerPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCustomerPhoto;
        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.Button btnRemovePhoto;
        private System.Windows.Forms.Label lblInforamtionAboutForm;
        private System.Windows.Forms.Label lblAddOrUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSaveCustomer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNationalID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.MaskedTextBox mtbDateOfBirth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
