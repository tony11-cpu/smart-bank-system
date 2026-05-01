namespace SmartBank_UI.Transaction
{
    partial class frmPerformNewTransaction
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
            this.lblTransactionsFormInfoToUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNewTransfare = new System.Windows.Forms.Button();
            this.btnNewWithdrawl = new System.Windows.Forms.Button();
            this.btnNewDeposite = new System.Windows.Forms.Button();
            this.pMain = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTransactionDetails = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTransactionTypeInDetails = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTransactionTypeAmount = new System.Windows.Forms.Label();
            this.lblAccountBalanceAfterTransaction = new System.Windows.Forms.Label();
            this.ctrlAccountShortInfo1 = new SmartBank_UI.Accounts.Accounts_User_Controls.ctrlAccountShortInfo();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTransactionsFormInfoToUser
            // 
            this.lblTransactionsFormInfoToUser.AutoSize = true;
            this.lblTransactionsFormInfoToUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionsFormInfoToUser.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTransactionsFormInfoToUser.Location = new System.Drawing.Point(23, 53);
            this.lblTransactionsFormInfoToUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTransactionsFormInfoToUser.Name = "lblTransactionsFormInfoToUser";
            this.lblTransactionsFormInfoToUser.Size = new System.Drawing.Size(646, 18);
            this.lblTransactionsFormInfoToUser.TabIndex = 14;
            this.lblTransactionsFormInfoToUser.Text = "Process deposits, withdrawals, and transfers. Every transaction is permanent and " +
    "recorded in full.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Perform Transaction";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.ctrlAccountShortInfo1);
            this.panel1.Location = new System.Drawing.Point(771, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 525);
            this.panel1.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(-1, 371);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(473, 153);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(771, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 68);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Location = new System.Drawing.Point(80, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 29);
            this.label2.TabIndex = 16;
            this.label2.Text = "TRANSACTION SUMMARY";
            // 
            // btnNewTransfare
            // 
            this.btnNewTransfare.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnNewTransfare.FlatAppearance.BorderSize = 2;
            this.btnNewTransfare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnNewTransfare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTransfare.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTransfare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnNewTransfare.Image = global::SmartBank_UI.Properties.Resources.icons8_right_arrow_38;
            this.btnNewTransfare.Location = new System.Drawing.Point(521, 105);
            this.btnNewTransfare.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewTransfare.Name = "btnNewTransfare";
            this.btnNewTransfare.Size = new System.Drawing.Size(244, 68);
            this.btnNewTransfare.TabIndex = 22;
            this.btnNewTransfare.Text = "Transfare";
            this.btnNewTransfare.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewTransfare.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNewTransfare.UseVisualStyleBackColor = true;
            this.btnNewTransfare.Click += new System.EventHandler(this.btnTransfare_Click);
            // 
            // btnNewWithdrawl
            // 
            this.btnNewWithdrawl.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnNewWithdrawl.FlatAppearance.BorderSize = 2;
            this.btnNewWithdrawl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNewWithdrawl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewWithdrawl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewWithdrawl.ForeColor = System.Drawing.Color.Red;
            this.btnNewWithdrawl.Image = global::SmartBank_UI.Properties.Resources.icons8_down_arrow_38;
            this.btnNewWithdrawl.Location = new System.Drawing.Point(266, 105);
            this.btnNewWithdrawl.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewWithdrawl.Name = "btnNewWithdrawl";
            this.btnNewWithdrawl.Size = new System.Drawing.Size(244, 68);
            this.btnNewWithdrawl.TabIndex = 21;
            this.btnNewWithdrawl.Text = "Withdrawal";
            this.btnNewWithdrawl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewWithdrawl.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNewWithdrawl.UseVisualStyleBackColor = true;
            this.btnNewWithdrawl.Click += new System.EventHandler(this.btnNewWithdrawl_Click);
            // 
            // btnNewDeposite
            // 
            this.btnNewDeposite.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnNewDeposite.FlatAppearance.BorderSize = 2;
            this.btnNewDeposite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNewDeposite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewDeposite.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewDeposite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNewDeposite.Image = global::SmartBank_UI.Properties.Resources.icons8_up_arrow_38;
            this.btnNewDeposite.Location = new System.Drawing.Point(11, 105);
            this.btnNewDeposite.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewDeposite.Name = "btnNewDeposite";
            this.btnNewDeposite.Size = new System.Drawing.Size(244, 68);
            this.btnNewDeposite.TabIndex = 20;
            this.btnNewDeposite.Text = "Deposit\r\n";
            this.btnNewDeposite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewDeposite.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNewDeposite.UseVisualStyleBackColor = true;
            this.btnNewDeposite.Click += new System.EventHandler(this.btnNewDeposite_Click);
            // 
            // pMain
            // 
            this.pMain.Location = new System.Drawing.Point(11, 178);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(753, 524);
            this.pMain.TabIndex = 23;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.lblTransactionDetails);
            this.panel4.Location = new System.Drawing.Point(771, 550);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(469, 44);
            this.panel4.TabIndex = 3;
            // 
            // lblTransactionDetails
            // 
            this.lblTransactionDetails.AutoSize = true;
            this.lblTransactionDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionDetails.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblTransactionDetails.Location = new System.Drawing.Point(81, 9);
            this.lblTransactionDetails.Name = "lblTransactionDetails";
            this.lblTransactionDetails.Size = new System.Drawing.Size(168, 24);
            this.lblTransactionDetails.TabIndex = 0;
            this.lblTransactionDetails.Text = "Transaction Details";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SmartBank_UI.Properties.Resources.icons8_transaction_50;
            this.pictureBox2.Location = new System.Drawing.Point(28, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel5.Controls.Add(this.lblAccountBalanceAfterTransaction);
            this.panel5.Controls.Add(this.lblTransactionTypeAmount);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.lblTransactionTypeInDetails);
            this.panel5.Location = new System.Drawing.Point(15, 53);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(443, 88);
            this.panel5.TabIndex = 0;
            // 
            // lblTransactionTypeInDetails
            // 
            this.lblTransactionTypeInDetails.AutoSize = true;
            this.lblTransactionTypeInDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionTypeInDetails.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblTransactionTypeInDetails.Location = new System.Drawing.Point(21, 14);
            this.lblTransactionTypeInDetails.Name = "lblTransactionTypeInDetails";
            this.lblTransactionTypeInDetails.Size = new System.Drawing.Size(165, 24);
            this.lblTransactionTypeInDetails.TabIndex = 3;
            this.lblTransactionTypeInDetails.Text = "Deposite Amount: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label5.Location = new System.Drawing.Point(22, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(397, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------------------------";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label6.Location = new System.Drawing.Point(22, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "New Account Balance:";
            // 
            // lblTransactionTypeAmount
            // 
            this.lblTransactionTypeAmount.AutoSize = true;
            this.lblTransactionTypeAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionTypeAmount.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblTransactionTypeAmount.Location = new System.Drawing.Point(192, 14);
            this.lblTransactionTypeAmount.Name = "lblTransactionTypeAmount";
            this.lblTransactionTypeAmount.Size = new System.Drawing.Size(30, 24);
            this.lblTransactionTypeAmount.TabIndex = 6;
            this.lblTransactionTypeAmount.Text = "00";
            // 
            // lblAccountBalanceAfterTransaction
            // 
            this.lblAccountBalanceAfterTransaction.AutoSize = true;
            this.lblAccountBalanceAfterTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountBalanceAfterTransaction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAccountBalanceAfterTransaction.Location = new System.Drawing.Point(230, 51);
            this.lblAccountBalanceAfterTransaction.Name = "lblAccountBalanceAfterTransaction";
            this.lblAccountBalanceAfterTransaction.Size = new System.Drawing.Size(30, 24);
            this.lblAccountBalanceAfterTransaction.TabIndex = 7;
            this.lblAccountBalanceAfterTransaction.Text = "00";
            // 
            // ctrlAccountShortInfo1
            // 
            this.ctrlAccountShortInfo1.BackColor = System.Drawing.Color.MidnightBlue;
            this.ctrlAccountShortInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAccountShortInfo1.Location = new System.Drawing.Point(-1, -1);
            this.ctrlAccountShortInfo1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrlAccountShortInfo1.Name = "ctrlAccountShortInfo1";
            this.ctrlAccountShortInfo1.Size = new System.Drawing.Size(471, 367);
            this.ctrlAccountShortInfo1.TabIndex = 0;
            // 
            // frmPerformNewTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1248, 710);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.btnNewTransfare);
            this.Controls.Add(this.btnNewWithdrawl);
            this.Controls.Add(this.btnNewDeposite);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTransactionsFormInfoToUser);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPerformNewTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPerformNewTransaction_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTransactionsFormInfoToUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Accounts.Accounts_User_Controls.ctrlAccountShortInfo ctrlAccountShortInfo1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNewTransfare;
        private System.Windows.Forms.Button btnNewWithdrawl;
        private System.Windows.Forms.Button btnNewDeposite;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTransactionDetails;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblAccountBalanceAfterTransaction;
        private System.Windows.Forms.Label lblTransactionTypeAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTransactionTypeInDetails;
    }
}