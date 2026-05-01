namespace SmartBank_UI.Transaction.Transactions_User_Controls
{
    partial class ctrlWithdrawelTransactionTypeAndInfo
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLookUp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAccountNumber = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cbSufficientBalanceConfirmed = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cbCustomerValidForAccount = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nupAmountInUSD = new System.Windows.Forms.NumericUpDown();
            this.mtbTransactionDate = new System.Windows.Forms.MaskedTextBox();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAmountInUSD)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SmartBank_UI.Properties.Resources.icons8_withdrawal_24;
            this.pictureBox1.Location = new System.Drawing.Point(17, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnLookUp);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.tbAccountNumber);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(754, 125);
            this.panel3.TabIndex = 68;
            // 
            // btnLookUp
            // 
            this.btnLookUp.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLookUp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLookUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnLookUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnLookUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLookUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLookUp.ForeColor = System.Drawing.Color.White;
            this.btnLookUp.Location = new System.Drawing.Point(632, 68);
            this.btnLookUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnLookUp.Name = "btnLookUp";
            this.btnLookUp.Size = new System.Drawing.Size(105, 43);
            this.btnLookUp.TabIndex = 68;
            this.btnLookUp.Text = "Look Up";
            this.btnLookUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLookUp.UseVisualStyleBackColor = false;
            this.btnLookUp.Click += new System.EventHandler(this.btnLookUp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label3.Location = new System.Drawing.Point(13, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 67;
            this.label3.Text = "Account Number ";
            // 
            // tbAccountNumber
            // 
            this.tbAccountNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAccountNumber.ForeColor = System.Drawing.Color.DimGray;
            this.tbAccountNumber.Location = new System.Drawing.Point(16, 82);
            this.tbAccountNumber.Name = "tbAccountNumber";
            this.tbAccountNumber.Size = new System.Drawing.Size(602, 29);
            this.tbAccountNumber.TabIndex = 66;
            this.tbAccountNumber.Tag = "Idle/AccountNumber/e.g. SB-2026-12345";
            this.tbAccountNumber.Text = "e.g. SB-2026-12345";
            this.tbAccountNumber.Enter += new System.EventHandler(this.tb_Enter);
            this.tbAccountNumber.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(-1, -1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(754, 51);
            this.panel4.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(70, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Source Account";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(1, 374);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(753, 148);
            this.panel7.TabIndex = 70;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label10);
            this.panel6.Location = new System.Drawing.Point(0, -1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(752, 39);
            this.panel6.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(13, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Authorization && Checking";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.cbSufficientBalanceConfirmed);
            this.panel9.Location = new System.Drawing.Point(15, 99);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(722, 38);
            this.panel9.TabIndex = 1;
            // 
            // cbSufficientBalanceConfirmed
            // 
            this.cbSufficientBalanceConfirmed.AutoSize = true;
            this.cbSufficientBalanceConfirmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSufficientBalanceConfirmed.ForeColor = System.Drawing.Color.White;
            this.cbSufficientBalanceConfirmed.Location = new System.Drawing.Point(20, 7);
            this.cbSufficientBalanceConfirmed.Name = "cbSufficientBalanceConfirmed";
            this.cbSufficientBalanceConfirmed.Size = new System.Drawing.Size(229, 24);
            this.cbSufficientBalanceConfirmed.TabIndex = 0;
            this.cbSufficientBalanceConfirmed.Text = "Sufficient balance confirmed";
            this.cbSufficientBalanceConfirmed.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.cbCustomerValidForAccount);
            this.panel8.Location = new System.Drawing.Point(15, 55);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(722, 38);
            this.panel8.TabIndex = 0;
            // 
            // cbCustomerValidForAccount
            // 
            this.cbCustomerValidForAccount.AutoSize = true;
            this.cbCustomerValidForAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomerValidForAccount.ForeColor = System.Drawing.Color.White;
            this.cbCustomerValidForAccount.Location = new System.Drawing.Point(20, 7);
            this.cbCustomerValidForAccount.Name = "cbCustomerValidForAccount";
            this.cbCustomerValidForAccount.Size = new System.Drawing.Size(467, 24);
            this.cbCustomerValidForAccount.TabIndex = 0;
            this.cbCustomerValidForAccount.Text = "I have verified the customer\'s identity against the presented ID";
            this.cbCustomerValidForAccount.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(755, 51);
            this.panel2.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(70, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Withdrawal Details";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SmartBank_UI.Properties.Resources.icons8_down_arrow_38;
            this.pictureBox2.Location = new System.Drawing.Point(17, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbRemarks);
            this.panel1.Controls.Add(this.mtbTransactionDate);
            this.panel1.Controls.Add(this.nupAmountInUSD);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 236);
            this.panel1.TabIndex = 69;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label9.Location = new System.Drawing.Point(15, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 20);
            this.label9.TabIndex = 71;
            this.label9.Text = "Amount (USD)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label8.Location = new System.Drawing.Point(272, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 73;
            this.label8.Text = "Date ";
            // 
            // nupAmountInUSD
            // 
            this.nupAmountInUSD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.nupAmountInUSD.Enabled = false;
            this.nupAmountInUSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupAmountInUSD.ForeColor = System.Drawing.Color.White;
            this.nupAmountInUSD.Location = new System.Drawing.Point(18, 87);
            this.nupAmountInUSD.Maximum = new decimal(new int[] {
            -1486618624,
            232830643,
            0,
            0});
            this.nupAmountInUSD.Name = "nupAmountInUSD";
            this.nupAmountInUSD.Size = new System.Drawing.Size(230, 31);
            this.nupAmountInUSD.TabIndex = 74;
            this.nupAmountInUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mtbTransactionDate
            // 
            this.mtbTransactionDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.mtbTransactionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbTransactionDate.ForeColor = System.Drawing.Color.White;
            this.mtbTransactionDate.Location = new System.Drawing.Point(276, 87);
            this.mtbTransactionDate.Mask = "00/00/0000 90:00";
            this.mtbTransactionDate.Name = "mtbTransactionDate";
            this.mtbTransactionDate.ReadOnly = true;
            this.mtbTransactionDate.Size = new System.Drawing.Size(463, 31);
            this.mtbTransactionDate.TabIndex = 75;
            this.mtbTransactionDate.ValidatingType = typeof(System.DateTime);
            // 
            // tbRemarks
            // 
            this.tbRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbRemarks.Enabled = false;
            this.tbRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemarks.ForeColor = System.Drawing.Color.DimGray;
            this.tbRemarks.Location = new System.Drawing.Point(19, 160);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(721, 59);
            this.tbRemarks.TabIndex = 76;
            this.tbRemarks.Tag = "Idle/Remarks/Optional internal note...";
            this.tbRemarks.Text = "Optional internal note...";
            this.tbRemarks.Enter += new System.EventHandler(this.tb_Enter);
            this.tbRemarks.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label7.Location = new System.Drawing.Point(16, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 77;
            this.label7.Text = "Remarks";
            // 
            // ctrlWithdrawelTransactionTypeAndInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "ctrlWithdrawelTransactionTypeAndInfo";
            this.Size = new System.Drawing.Size(756, 525);
            this.Load += new System.EventHandler(this.ctrlWithdrawelTransactionTypeAndInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAmountInUSD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.CheckBox cbSufficientBalanceConfirmed;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckBox cbCustomerValidForAccount;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLookUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAccountNumber;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbRemarks;
        private System.Windows.Forms.MaskedTextBox mtbTransactionDate;
        private System.Windows.Forms.NumericUpDown nupAmountInUSD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}
