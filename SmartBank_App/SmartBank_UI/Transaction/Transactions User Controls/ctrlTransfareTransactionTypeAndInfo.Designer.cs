namespace SmartBank_UI.Transaction.Transactions_User_Controls
{
    partial class ctrlTransfareTransactionTypeAndInfo
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbToAccountNumber = new System.Windows.Forms.TextBox();
            this.btnLookUpToAccount = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbRefrenceOrRemark = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mtbTransactionDate = new System.Windows.Forms.MaskedTextBox();
            this.nupAmountInUSD = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cbPriority = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbScheduleTransfare = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbFromAccountNumber = new System.Windows.Forms.TextBox();
            this.btnFromAccountLookUp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAmountInUSD)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.tbToAccountNumber);
            this.panel6.Controls.Add(this.btnLookUpToAccount);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(0, 147);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(754, 136);
            this.panel6.TabIndex = 70;
            // 
            // tbToAccountNumber
            // 
            this.tbToAccountNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbToAccountNumber.Enabled = false;
            this.tbToAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbToAccountNumber.ForeColor = System.Drawing.Color.DimGray;
            this.tbToAccountNumber.Location = new System.Drawing.Point(18, 90);
            this.tbToAccountNumber.Name = "tbToAccountNumber";
            this.tbToAccountNumber.Size = new System.Drawing.Size(602, 29);
            this.tbToAccountNumber.TabIndex = 67;
            this.tbToAccountNumber.Tag = "Idle/AccountNumber/e.g. SB-2026-678910";
            this.tbToAccountNumber.Text = "e.g. SB-2026-678910";
            this.tbToAccountNumber.Enter += new System.EventHandler(this.tb_Enter);
            this.tbToAccountNumber.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // btnLookUpToAccount
            // 
            this.btnLookUpToAccount.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLookUpToAccount.Enabled = false;
            this.btnLookUpToAccount.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLookUpToAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnLookUpToAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnLookUpToAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLookUpToAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLookUpToAccount.ForeColor = System.Drawing.Color.White;
            this.btnLookUpToAccount.Location = new System.Drawing.Point(633, 76);
            this.btnLookUpToAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btnLookUpToAccount.Name = "btnLookUpToAccount";
            this.btnLookUpToAccount.Size = new System.Drawing.Size(105, 43);
            this.btnLookUpToAccount.TabIndex = 65;
            this.btnLookUpToAccount.Text = "Look Up";
            this.btnLookUpToAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLookUpToAccount.UseVisualStyleBackColor = false;
            this.btnLookUpToAccount.Click += new System.EventHandler(this.btnLookUpToAccount_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label10.Location = new System.Drawing.Point(14, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Account Number ";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.pictureBox3);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Location = new System.Drawing.Point(-1, -1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(754, 51);
            this.panel7.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SmartBank_UI.Properties.Resources.icons8_right_arrow_38;
            this.pictureBox3.Location = new System.Drawing.Point(17, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(47, 43);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label11.Location = new System.Drawing.Point(70, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 24);
            this.label11.TabIndex = 0;
            this.label11.Text = "Source Account";
            // 
            // tbRefrenceOrRemark
            // 
            this.tbRefrenceOrRemark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbRefrenceOrRemark.Enabled = false;
            this.tbRefrenceOrRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRefrenceOrRemark.ForeColor = System.Drawing.Color.DimGray;
            this.tbRefrenceOrRemark.Location = new System.Drawing.Point(17, 163);
            this.tbRefrenceOrRemark.Multiline = true;
            this.tbRefrenceOrRemark.Name = "tbRefrenceOrRemark";
            this.tbRefrenceOrRemark.Size = new System.Drawing.Size(477, 54);
            this.tbRefrenceOrRemark.TabIndex = 66;
            this.tbRefrenceOrRemark.Tag = "Idle/tbRefrenceOrRemark/Optional internal note...";
            this.tbRefrenceOrRemark.Text = "Optional internal note...";
            this.tbRefrenceOrRemark.Enter += new System.EventHandler(this.tb_Enter);
            this.tbRefrenceOrRemark.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(755, 51);
            this.panel2.TabIndex = 67;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SmartBank_UI.Properties.Resources.icons8_initiate_money_transfer_50;
            this.pictureBox2.Location = new System.Drawing.Point(17, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(70, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transfer Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mtbTransactionDate
            // 
            this.mtbTransactionDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.mtbTransactionDate.Enabled = false;
            this.mtbTransactionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbTransactionDate.ForeColor = System.Drawing.Color.White;
            this.mtbTransactionDate.Location = new System.Drawing.Point(510, 163);
            this.mtbTransactionDate.Mask = "00/00/0000 90:00";
            this.mtbTransactionDate.Name = "mtbTransactionDate";
            this.mtbTransactionDate.Size = new System.Drawing.Size(228, 31);
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
            this.nupAmountInUSD.Size = new System.Drawing.Size(228, 31);
            this.nupAmountInUSD.TabIndex = 68;
            this.nupAmountInUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label5.Location = new System.Drawing.Point(506, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 67;
            this.label5.Text = "Value Date ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Location = new System.Drawing.Point(14, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 66;
            this.label2.Text = "Amount (USD)";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbPriority);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbScheduleTransfare);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbRefrenceOrRemark);
            this.panel1.Controls.Add(this.mtbTransactionDate);
            this.panel1.Controls.Add(this.nupAmountInUSD);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 289);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 236);
            this.panel1.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label7.Location = new System.Drawing.Point(506, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 20);
            this.label7.TabIndex = 75;
            this.label7.Text = "Priority";
            // 
            // cbPriority
            // 
            this.cbPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriority.Enabled = false;
            this.cbPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPriority.ForeColor = System.Drawing.Color.White;
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Items.AddRange(new object[] {
            "Normal",
            "High",
            "Urgent"});
            this.cbPriority.Location = new System.Drawing.Point(510, 91);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(228, 28);
            this.cbPriority.TabIndex = 74;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label8.Location = new System.Drawing.Point(262, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 20);
            this.label8.TabIndex = 73;
            this.label8.Text = "Schedule";
            // 
            // cbScheduleTransfare
            // 
            this.cbScheduleTransfare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cbScheduleTransfare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScheduleTransfare.Enabled = false;
            this.cbScheduleTransfare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbScheduleTransfare.ForeColor = System.Drawing.Color.White;
            this.cbScheduleTransfare.FormattingEnabled = true;
            this.cbScheduleTransfare.Items.AddRange(new object[] {
            "Immediate",
            "3 hours",
            "6 hours",
            "9 hours",
            "12 hours"});
            this.cbScheduleTransfare.Location = new System.Drawing.Point(266, 91);
            this.cbScheduleTransfare.Name = "cbScheduleTransfare";
            this.cbScheduleTransfare.Size = new System.Drawing.Size(228, 28);
            this.cbScheduleTransfare.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label6.Location = new System.Drawing.Point(14, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 20);
            this.label6.TabIndex = 67;
            this.label6.Text = "Reference / Remarks";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SmartBank_UI.Properties.Resources.icons8_sign_out_30;
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
            this.panel3.Controls.Add(this.tbFromAccountNumber);
            this.panel3.Controls.Add(this.btnFromAccountLookUp);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(754, 138);
            this.panel3.TabIndex = 68;
            // 
            // tbFromAccountNumber
            // 
            this.tbFromAccountNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbFromAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFromAccountNumber.ForeColor = System.Drawing.Color.DimGray;
            this.tbFromAccountNumber.Location = new System.Drawing.Point(18, 92);
            this.tbFromAccountNumber.Name = "tbFromAccountNumber";
            this.tbFromAccountNumber.Size = new System.Drawing.Size(602, 29);
            this.tbFromAccountNumber.TabIndex = 67;
            this.tbFromAccountNumber.Tag = "Idle/AccountNumber/e.g. SB-2026-12345";
            this.tbFromAccountNumber.Text = "e.g. SB-2026-12345";
            this.tbFromAccountNumber.Enter += new System.EventHandler(this.tb_Enter);
            this.tbFromAccountNumber.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // btnFromAccountLookUp
            // 
            this.btnFromAccountLookUp.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFromAccountLookUp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFromAccountLookUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnFromAccountLookUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnFromAccountLookUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromAccountLookUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromAccountLookUp.ForeColor = System.Drawing.Color.White;
            this.btnFromAccountLookUp.Location = new System.Drawing.Point(633, 78);
            this.btnFromAccountLookUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnFromAccountLookUp.Name = "btnFromAccountLookUp";
            this.btnFromAccountLookUp.Size = new System.Drawing.Size(105, 43);
            this.btnFromAccountLookUp.TabIndex = 65;
            this.btnFromAccountLookUp.Text = "Look Up";
            this.btnFromAccountLookUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFromAccountLookUp.UseVisualStyleBackColor = false;
            this.btnFromAccountLookUp.Click += new System.EventHandler(this.btnFromAccountLookUp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label3.Location = new System.Drawing.Point(14, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Account Number ";
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
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(70, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "From Account";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlTransfareTransactionTypeAndInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "ctrlTransfareTransactionTypeAndInfo";
            this.Size = new System.Drawing.Size(756, 528);
            this.Load += new System.EventHandler(this.ctrlTransfareTransactionTypeAndInfo_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAmountInUSD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnLookUpToAccount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbRefrenceOrRemark;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbTransactionDate;
        private System.Windows.Forms.NumericUpDown nupAmountInUSD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnFromAccountLookUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbPriority;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbScheduleTransfare;
        private System.Windows.Forms.TextBox tbToAccountNumber;
        private System.Windows.Forms.TextBox tbFromAccountNumber;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
