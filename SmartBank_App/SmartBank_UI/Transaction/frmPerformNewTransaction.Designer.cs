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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTransfare = new System.Windows.Forms.Button();
            this.btnNewWithdrawl = new System.Windows.Forms.Button();
            this.btnNewDeposite = new System.Windows.Forms.Button();
            this.ctrlAccountShortInfo1 = new SmartBank_UI.Accounts.Accounts_User_Controls.ctrlAccountShortInfo();
            this.ctrlTransactionTypeAndInfo1 = new SmartBank_UI.Transaction.Transactions_User_Controls.ctrlDepositTransactionTypeAndInfo();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTransactionsFormInfoToUser
            // 
            this.lblTransactionsFormInfoToUser.AutoSize = true;
            this.lblTransactionsFormInfoToUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionsFormInfoToUser.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTransactionsFormInfoToUser.Location = new System.Drawing.Point(23, 50);
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
            this.label1.Size = new System.Drawing.Size(151, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Transactions";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ctrlAccountShortInfo1);
            this.panel1.Location = new System.Drawing.Point(770, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 715);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(771, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 68);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(80, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 29);
            this.label2.TabIndex = 16;
            this.label2.Text = "TRANSACTION SUMMARY";
            // 
            // btnTransfare
            // 
            this.btnTransfare.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnTransfare.FlatAppearance.BorderSize = 2;
            this.btnTransfare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnTransfare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfare.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnTransfare.Image = global::SmartBank_UI.Properties.Resources.icons8_right_arrow_38;
            this.btnTransfare.Location = new System.Drawing.Point(521, 105);
            this.btnTransfare.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransfare.Name = "btnTransfare";
            this.btnTransfare.Size = new System.Drawing.Size(244, 68);
            this.btnTransfare.TabIndex = 22;
            this.btnTransfare.Text = "Transfare";
            this.btnTransfare.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTransfare.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTransfare.UseVisualStyleBackColor = true;
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
            this.btnNewDeposite.Text = "Deposit";
            this.btnNewDeposite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewDeposite.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNewDeposite.UseVisualStyleBackColor = true;
            // 
            // ctrlAccountShortInfo1
            // 
            this.ctrlAccountShortInfo1.BackColor = System.Drawing.Color.MidnightBlue;
            this.ctrlAccountShortInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAccountShortInfo1.Location = new System.Drawing.Point(3, 72);
            this.ctrlAccountShortInfo1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrlAccountShortInfo1.Name = "ctrlAccountShortInfo1";
            this.ctrlAccountShortInfo1.Size = new System.Drawing.Size(471, 367);
            this.ctrlAccountShortInfo1.TabIndex = 0;
            // 
            // ctrlTransactionTypeAndInfo1
            // 
            this.ctrlTransactionTypeAndInfo1.Location = new System.Drawing.Point(11, 178);
            this.ctrlTransactionTypeAndInfo1.Name = "ctrlTransactionTypeAndInfo1";
            this.ctrlTransactionTypeAndInfo1.Size = new System.Drawing.Size(754, 642);
            this.ctrlTransactionTypeAndInfo1.TabIndex = 23;
            // 
            // frmPerformNewTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1258, 829);
            this.Controls.Add(this.ctrlTransactionTypeAndInfo1);
            this.Controls.Add(this.btnTransfare);
            this.Controls.Add(this.btnNewWithdrawl);
            this.Controls.Add(this.btnNewDeposite);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTransactionsFormInfoToUser);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPerformNewTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Button btnTransfare;
        private System.Windows.Forms.Button btnNewWithdrawl;
        private System.Windows.Forms.Button btnNewDeposite;
        private Transactions_User_Controls.ctrlDepositTransactionTypeAndInfo ctrlTransactionTypeAndInfo1;
    }
}