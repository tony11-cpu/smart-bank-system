namespace SmartBank_UI.Main_Form_UC
{
    partial class ctrlCustomerShortInfo
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lblCustomerServedDate = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNationalID = new System.Windows.Forms.TextBox();
            this.lblLinkToFullID = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.mtbDateOfBarth = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbCustomerPhoto = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomerPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(452, 148);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // lblCustomerServedDate
            // 
            this.lblCustomerServedDate.AutoSize = true;
            this.lblCustomerServedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerServedDate.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCustomerServedDate.Location = new System.Drawing.Point(202, 62);
            this.lblCustomerServedDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerServedDate.Name = "lblCustomerServedDate";
            this.lblCustomerServedDate.Size = new System.Drawing.Size(214, 20);
            this.lblCustomerServedDate.TabIndex = 6;
            this.lblCustomerServedDate.Text = "Customer Since Jan 12,2024";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Location = new System.Drawing.Point(201, 31);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(172, 26);
            this.lblCustomerName.TabIndex = 5;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "NATIONAL ID";
            // 
            // tbNationalID
            // 
            this.tbNationalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNationalID.Location = new System.Drawing.Point(15, 38);
            this.tbNationalID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbNationalID.Name = "tbNationalID";
            this.tbNationalID.Size = new System.Drawing.Size(399, 26);
            this.tbNationalID.TabIndex = 9;
            this.tbNationalID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNationalID_KeyPress);
            // 
            // lblLinkToFullID
            // 
            this.lblLinkToFullID.AutoSize = true;
            this.lblLinkToFullID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkToFullID.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblLinkToFullID.Location = new System.Drawing.Point(12, 70);
            this.lblLinkToFullID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLinkToFullID.Name = "lblLinkToFullID";
            this.lblLinkToFullID.Size = new System.Drawing.Size(314, 20);
            this.lblLinkToFullID.TabIndex = 10;
            this.lblLinkToFullID.TabStop = true;
            this.lblLinkToFullID.Text = "Click here to view the full ID (Manager Only)";
            this.lblLinkToFullID.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkToFullID_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "DATE OF BIRTH";
            // 
            // mtbDateOfBarth
            // 
            this.mtbDateOfBarth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.mtbDateOfBarth.Location = new System.Drawing.Point(15, 136);
            this.mtbDateOfBarth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mtbDateOfBarth.Mask = "00/00/0000";
            this.mtbDateOfBarth.Name = "mtbDateOfBarth";
            this.mtbDateOfBarth.ReadOnly = true;
            this.mtbDateOfBarth.Size = new System.Drawing.Size(399, 26);
            this.mtbDateOfBarth.TabIndex = 12;
            this.mtbDateOfBarth.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(12, 192);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "PHONE NUMBER";
            // 
            // mtbPhoneNumber
            // 
            this.mtbPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.mtbPhoneNumber.Location = new System.Drawing.Point(15, 211);
            this.mtbPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mtbPhoneNumber.Mask = "(999) 000-0000";
            this.mtbPhoneNumber.Name = "mtbPhoneNumber";
            this.mtbPhoneNumber.ReadOnly = true;
            this.mtbPhoneNumber.Size = new System.Drawing.Size(399, 26);
            this.mtbPhoneNumber.TabIndex = 15;
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.Location = new System.Drawing.Point(19, 283);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.ReadOnly = true;
            this.tbEmail.Size = new System.Drawing.Size(395, 26);
            this.tbEmail.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(16, 265);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "EMAIL";
            // 
            // tbAddress
            // 
            this.tbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress.Location = new System.Drawing.Point(19, 359);
            this.tbAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.ReadOnly = true;
            this.tbAddress.Size = new System.Drawing.Size(395, 26);
            this.tbAddress.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(16, 340);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "ADDRESS";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbAddress);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbEmail);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.mtbPhoneNumber);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.mtbDateOfBarth);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblLinkToFullID);
            this.panel1.Controls.Add(this.tbNationalID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 151);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 405);
            this.panel1.TabIndex = 20;
            // 
            // pbCustomerPhoto
            // 
            this.pbCustomerPhoto.Image = global::SmartBank_UI.Properties.Resources.icons8_person_80;
            this.pbCustomerPhoto.Location = new System.Drawing.Point(20, 16);
            this.pbCustomerPhoto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbCustomerPhoto.Name = "pbCustomerPhoto";
            this.pbCustomerPhoto.Size = new System.Drawing.Size(177, 118);
            this.pbCustomerPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCustomerPhoto.TabIndex = 4;
            this.pbCustomerPhoto.TabStop = false;
            // 
            // ctrlCustomerShortInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblCustomerServedDate);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.pbCustomerPhoto);
            this.Controls.Add(this.splitter1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ctrlCustomerShortInfo";
            this.Size = new System.Drawing.Size(452, 562);
            this.Load += new System.EventHandler(this.ctrlCustomerShortInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomerPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label lblCustomerServedDate;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.PictureBox pbCustomerPhoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNationalID;
        private System.Windows.Forms.LinkLabel lblLinkToFullID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtbDateOfBarth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtbPhoneNumber;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
    }
}
