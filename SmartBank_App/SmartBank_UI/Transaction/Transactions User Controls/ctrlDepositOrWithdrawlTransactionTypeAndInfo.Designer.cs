namespace SmartBank_UI.Transaction.Transactions_User_Controls
{
    partial class ctrlDepositOrWithdrawalTransactionTypeAndInfo
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLookUp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAccountNumber = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pbDestinationAccountPic = new System.Windows.Forms.PictureBox();
            this.lblDestinationAccountLable = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbDepositDetailsPic = new System.Windows.Forms.PictureBox();
            this.lblDepositeDetails = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cbAccountValid = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cbConfirmTransactionFund = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblAuthorization = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.mtbTransactionDate = new System.Windows.Forms.MaskedTextBox();
            this.nupAmountInUSD = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDestinationAccountPic)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDepositDetailsPic)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAmountInUSD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnLookUp);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.tbAccountNumber);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(754, 125);
            this.panel3.TabIndex = 25;
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
            this.btnLookUp.Location = new System.Drawing.Point(633, 67);
            this.btnLookUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnLookUp.Name = "btnLookUp";
            this.btnLookUp.Size = new System.Drawing.Size(105, 43);
            this.btnLookUp.TabIndex = 65;
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
            this.label3.Location = new System.Drawing.Point(14, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Account Number ";
            // 
            // tbAccountNumber
            // 
            this.tbAccountNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAccountNumber.ForeColor = System.Drawing.Color.DimGray;
            this.tbAccountNumber.Location = new System.Drawing.Point(17, 81);
            this.tbAccountNumber.Name = "tbAccountNumber";
            this.tbAccountNumber.Size = new System.Drawing.Size(602, 29);
            this.tbAccountNumber.TabIndex = 1;
            this.tbAccountNumber.Tag = "Idle/AccountNumber/e.g. SB-2026-12345";
            this.tbAccountNumber.Text = "e.g. SB-2026-12345";
            this.tbAccountNumber.Enter += new System.EventHandler(this.tb_Enter);
            this.tbAccountNumber.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pbDestinationAccountPic);
            this.panel4.Controls.Add(this.lblDestinationAccountLable);
            this.panel4.Location = new System.Drawing.Point(-1, -1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(754, 51);
            this.panel4.TabIndex = 0;
            // 
            // pbDestinationAccountPic
            // 
            this.pbDestinationAccountPic.Image = global::SmartBank_UI.Properties.Resources.icons8_coin_wallet_48;
            this.pbDestinationAccountPic.Location = new System.Drawing.Point(17, 3);
            this.pbDestinationAccountPic.Name = "pbDestinationAccountPic";
            this.pbDestinationAccountPic.Size = new System.Drawing.Size(47, 43);
            this.pbDestinationAccountPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDestinationAccountPic.TabIndex = 1;
            this.pbDestinationAccountPic.TabStop = false;
            // 
            // lblDestinationAccountLable
            // 
            this.lblDestinationAccountLable.AutoSize = true;
            this.lblDestinationAccountLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinationAccountLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblDestinationAccountLable.Location = new System.Drawing.Point(70, 13);
            this.lblDestinationAccountLable.Name = "lblDestinationAccountLable";
            this.lblDestinationAccountLable.Size = new System.Drawing.Size(177, 24);
            this.lblDestinationAccountLable.TabIndex = 0;
            this.lblDestinationAccountLable.Text = "Destination Account";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pbDepositDetailsPic);
            this.panel2.Controls.Add(this.lblDepositeDetails);
            this.panel2.Location = new System.Drawing.Point(-2, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 51);
            this.panel2.TabIndex = 2;
            // 
            // pbDepositDetailsPic
            // 
            this.pbDepositDetailsPic.Image = global::SmartBank_UI.Properties.Resources.icons8_up_arrow_38;
            this.pbDepositDetailsPic.Location = new System.Drawing.Point(17, 3);
            this.pbDepositDetailsPic.Name = "pbDepositDetailsPic";
            this.pbDepositDetailsPic.Size = new System.Drawing.Size(47, 43);
            this.pbDepositDetailsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDepositDetailsPic.TabIndex = 1;
            this.pbDepositDetailsPic.TabStop = false;
            // 
            // lblDepositeDetails
            // 
            this.lblDepositeDetails.AutoSize = true;
            this.lblDepositeDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepositeDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblDepositeDetails.Location = new System.Drawing.Point(70, 13);
            this.lblDepositeDetails.Name = "lblDepositeDetails";
            this.lblDepositeDetails.Size = new System.Drawing.Size(133, 24);
            this.lblDepositeDetails.TabIndex = 0;
            this.lblDepositeDetails.Text = "Deposit Details";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(1, 373);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(753, 146);
            this.panel7.TabIndex = 28;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.cbAccountValid);
            this.panel9.Location = new System.Drawing.Point(15, 97);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(722, 38);
            this.panel9.TabIndex = 1;
            // 
            // cbAccountValid
            // 
            this.cbAccountValid.AutoSize = true;
            this.cbAccountValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAccountValid.ForeColor = System.Drawing.Color.White;
            this.cbAccountValid.Location = new System.Drawing.Point(20, 7);
            this.cbAccountValid.Name = "cbAccountValid";
            this.cbAccountValid.Size = new System.Drawing.Size(342, 24);
            this.cbAccountValid.TabIndex = 0;
            this.cbAccountValid.Text = "The account holder identity has been verified";
            this.cbAccountValid.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.cbConfirmTransactionFund);
            this.panel8.Location = new System.Drawing.Point(15, 53);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(722, 38);
            this.panel8.TabIndex = 0;
            // 
            // cbConfirmTransactionFund
            // 
            this.cbConfirmTransactionFund.AutoSize = true;
            this.cbConfirmTransactionFund.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConfirmTransactionFund.ForeColor = System.Drawing.Color.White;
            this.cbConfirmTransactionFund.Location = new System.Drawing.Point(20, 7);
            this.cbConfirmTransactionFund.Name = "cbConfirmTransactionFund";
            this.cbConfirmTransactionFund.Size = new System.Drawing.Size(468, 24);
            this.cbConfirmTransactionFund.TabIndex = 0;
            this.cbConfirmTransactionFund.Text = "I confirm the deposited funds have been received and counted";
            this.cbConfirmTransactionFund.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lblAuthorization);
            this.panel6.Location = new System.Drawing.Point(1, 373);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(752, 39);
            this.panel6.TabIndex = 29;
            // 
            // lblAuthorization
            // 
            this.lblAuthorization.AutoSize = true;
            this.lblAuthorization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorization.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAuthorization.Location = new System.Drawing.Point(13, 9);
            this.lblAuthorization.Name = "lblAuthorization";
            this.lblAuthorization.Size = new System.Drawing.Size(103, 20);
            this.lblAuthorization.TabIndex = 0;
            this.lblAuthorization.Text = "Authorization";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.tbRemarks);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.mtbTransactionDate);
            this.panel5.Controls.Add(this.nupAmountInUSD);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(1, 131);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(753, 236);
            this.panel5.TabIndex = 74;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label7.Location = new System.Drawing.Point(14, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 67;
            this.label7.Text = "Remarks";
            // 
            // tbRemarks
            // 
            this.tbRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbRemarks.Enabled = false;
            this.tbRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemarks.ForeColor = System.Drawing.Color.DimGray;
            this.tbRemarks.Location = new System.Drawing.Point(17, 160);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(721, 59);
            this.tbRemarks.TabIndex = 66;
            this.tbRemarks.Tag = "Idle/Remarks/Optional internal note...";
            this.tbRemarks.Text = "Optional internal note...";
            this.tbRemarks.Enter += new System.EventHandler(this.tb_Enter);
            this.tbRemarks.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // mtbTransactionDate
            // 
            this.mtbTransactionDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.mtbTransactionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbTransactionDate.ForeColor = System.Drawing.Color.White;
            this.mtbTransactionDate.Location = new System.Drawing.Point(275, 88);
            this.mtbTransactionDate.Mask = "00/00/0000 90:00";
            this.mtbTransactionDate.Name = "mtbTransactionDate";
            this.mtbTransactionDate.ReadOnly = true;
            this.mtbTransactionDate.Size = new System.Drawing.Size(463, 31);
            this.mtbTransactionDate.TabIndex = 69;
            this.mtbTransactionDate.ValidatingType = typeof(System.DateTime);
            // 
            // nupAmountInUSD
            // 
            this.nupAmountInUSD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.nupAmountInUSD.Enabled = false;
            this.nupAmountInUSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupAmountInUSD.ForeColor = System.Drawing.Color.White;
            this.nupAmountInUSD.Location = new System.Drawing.Point(17, 88);
            this.nupAmountInUSD.Maximum = new decimal(new int[] {
            -1486618624,
            232830643,
            0,
            0});
            this.nupAmountInUSD.Name = "nupAmountInUSD";
            this.nupAmountInUSD.Size = new System.Drawing.Size(230, 31);
            this.nupAmountInUSD.TabIndex = 68;
            this.nupAmountInUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupAmountInUSD.ThousandsSeparator = true;
            this.nupAmountInUSD.ValueChanged += new System.EventHandler(this.nupAmountInUSD_ValueChanged);
            this.nupAmountInUSD.Validating += new System.ComponentModel.CancelEventHandler(this.nupAmountInUSD_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label8.Location = new System.Drawing.Point(271, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 67;
            this.label8.Text = "Date ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label9.Location = new System.Drawing.Point(14, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 20);
            this.label9.TabIndex = 66;
            this.label9.Text = "Amount (USD)";
            // 
            // ctrlDepositOrWithdrawalTransactionTypeAndInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Name = "ctrlDepositOrWithdrawalTransactionTypeAndInfo";
            this.Size = new System.Drawing.Size(754, 522);
            this.Load += new System.EventHandler(this.ctrlDepositTransactionTypeAndInfo_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDestinationAccountPic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDepositDetailsPic)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAmountInUSD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLookUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAccountNumber;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pbDestinationAccountPic;
        private System.Windows.Forms.Label lblDestinationAccountLable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbDepositDetailsPic;
        private System.Windows.Forms.Label lblDepositeDetails;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckBox cbConfirmTransactionFund;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.CheckBox cbAccountValid;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblAuthorization;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbRemarks;
        private System.Windows.Forms.MaskedTextBox mtbTransactionDate;
        private System.Windows.Forms.NumericUpDown nupAmountInUSD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}
