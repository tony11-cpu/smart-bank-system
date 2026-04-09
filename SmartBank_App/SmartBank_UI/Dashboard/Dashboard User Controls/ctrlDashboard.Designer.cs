namespace SmartBank_UI
{
    partial class ctrlDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlDashboard));
            this.label1 = new System.Windows.Forms.Label();
            this.lblMorningToUserWithName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblActiveAccounts = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTransactionsToday = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblFraudFlags = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPendingTransfares = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvFraudFlags = new System.Windows.Forms.DataGridView();
            this.dgvRecentTransactions = new System.Windows.Forms.DataGridView();
            this.btnTransfare = new System.Windows.Forms.Button();
            this.btnNewWithdrawl = new System.Windows.Forms.Button();
            this.btnNewDeposite = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFraudFlags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // lblMorningToUserWithName
            // 
            this.lblMorningToUserWithName.AutoSize = true;
            this.lblMorningToUserWithName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMorningToUserWithName.ForeColor = System.Drawing.Color.DarkGray;
            this.lblMorningToUserWithName.Location = new System.Drawing.Point(20, 49);
            this.lblMorningToUserWithName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMorningToUserWithName.Name = "lblMorningToUserWithName";
            this.lblMorningToUserWithName.Size = new System.Drawing.Size(480, 18);
            this.lblMorningToUserWithName.TabIndex = 1;
            this.lblMorningToUserWithName.Text = "Good morning, Username.Here is everything you need to start your shift";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.lblActiveAccounts);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 110);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 99);
            this.panel1.TabIndex = 2;
            // 
            // lblActiveAccounts
            // 
            this.lblActiveAccounts.AutoSize = true;
            this.lblActiveAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveAccounts.ForeColor = System.Drawing.Color.White;
            this.lblActiveAccounts.Location = new System.Drawing.Point(7, 35);
            this.lblActiveAccounts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActiveAccounts.Name = "lblActiveAccounts";
            this.lblActiveAccounts.Size = new System.Drawing.Size(82, 31);
            this.lblActiveAccounts.TabIndex = 3;
            this.lblActiveAccounts.Text = "0.000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(9, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "across all customers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(9, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "ACTIVE ACCOUNTS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblTransactionsToday);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(339, 110);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 99);
            this.panel2.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(9, 70);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "since midnight";
            // 
            // lblTransactionsToday
            // 
            this.lblTransactionsToday.AutoSize = true;
            this.lblTransactionsToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionsToday.ForeColor = System.Drawing.Color.Lime;
            this.lblTransactionsToday.Location = new System.Drawing.Point(10, 35);
            this.lblTransactionsToday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTransactionsToday.Name = "lblTransactionsToday";
            this.lblTransactionsToday.Size = new System.Drawing.Size(82, 31);
            this.lblTransactionsToday.TabIndex = 3;
            this.lblTransactionsToday.Text = "0.000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGray;
            this.label8.Location = new System.Drawing.Point(9, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "TRANSACTIONS TODAY";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.Controls.Add(this.lblFraudFlags);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(668, 110);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(319, 99);
            this.panel3.TabIndex = 5;
            // 
            // lblFraudFlags
            // 
            this.lblFraudFlags.AutoSize = true;
            this.lblFraudFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFraudFlags.ForeColor = System.Drawing.Color.Red;
            this.lblFraudFlags.Location = new System.Drawing.Point(13, 35);
            this.lblFraudFlags.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFraudFlags.Name = "lblFraudFlags";
            this.lblFraudFlags.Size = new System.Drawing.Size(82, 31);
            this.lblFraudFlags.TabIndex = 3;
            this.lblFraudFlags.Text = "0.000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(16, 70);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 18);
            this.label9.TabIndex = 4;
            this.label9.Text = "need review";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkGray;
            this.label11.Location = new System.Drawing.Point(15, 6);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "FRAUD FLAGS";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.lblPendingTransfares);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Location = new System.Drawing.Point(995, 110);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(319, 99);
            this.panel4.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkGray;
            this.label14.Location = new System.Drawing.Point(11, 6);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(195, 20);
            this.label14.TabIndex = 3;
            this.label14.Text = "PENDING TRANSFARES";
            // 
            // lblPendingTransfares
            // 
            this.lblPendingTransfares.AutoSize = true;
            this.lblPendingTransfares.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingTransfares.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblPendingTransfares.Location = new System.Drawing.Point(9, 35);
            this.lblPendingTransfares.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPendingTransfares.Name = "lblPendingTransfares";
            this.lblPendingTransfares.Size = new System.Drawing.Size(82, 31);
            this.lblPendingTransfares.TabIndex = 3;
            this.lblPendingTransfares.Text = "0.000";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(12, 70);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 18);
            this.label12.TabIndex = 4;
            this.label12.Text = "scheduled today";
            // 
            // dgvFraudFlags
            // 
            this.dgvFraudFlags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFraudFlags.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvFraudFlags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFraudFlags.Location = new System.Drawing.Point(668, 213);
            this.dgvFraudFlags.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFraudFlags.Name = "dgvFraudFlags";
            this.dgvFraudFlags.RowHeadersWidth = 62;
            this.dgvFraudFlags.RowTemplate.Height = 28;
            this.dgvFraudFlags.Size = new System.Drawing.Size(646, 502);
            this.dgvFraudFlags.TabIndex = 6;
            // 
            // dgvRecentTransactions
            // 
            this.dgvRecentTransactions.AllowUserToAddRows = false;
            this.dgvRecentTransactions.AllowUserToDeleteRows = false;
            this.dgvRecentTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentTransactions.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvRecentTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentTransactions.Location = new System.Drawing.Point(12, 213);
            this.dgvRecentTransactions.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRecentTransactions.Name = "dgvRecentTransactions";
            this.dgvRecentTransactions.ReadOnly = true;
            this.dgvRecentTransactions.RowHeadersWidth = 62;
            this.dgvRecentTransactions.RowTemplate.Height = 28;
            this.dgvRecentTransactions.Size = new System.Drawing.Size(646, 502);
            this.dgvRecentTransactions.TabIndex = 5;
            // 
            // btnTransfare
            // 
            this.btnTransfare.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnTransfare.FlatAppearance.BorderSize = 6;
            this.btnTransfare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnTransfare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfare.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnTransfare.Image = global::SmartBank_UI.Properties.Resources.icons8_right_arrow_50;
            this.btnTransfare.Location = new System.Drawing.Point(892, 732);
            this.btnTransfare.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransfare.Name = "btnTransfare";
            this.btnTransfare.Size = new System.Drawing.Size(417, 79);
            this.btnTransfare.TabIndex = 10;
            this.btnTransfare.Text = "New Transfare";
            this.btnTransfare.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTransfare.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTransfare.UseVisualStyleBackColor = true;
            // 
            // btnNewWithdrawl
            // 
            this.btnNewWithdrawl.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnNewWithdrawl.FlatAppearance.BorderSize = 6;
            this.btnNewWithdrawl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNewWithdrawl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewWithdrawl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewWithdrawl.ForeColor = System.Drawing.Color.Red;
            this.btnNewWithdrawl.Image = ((System.Drawing.Image)(resources.GetObject("btnNewWithdrawl.Image")));
            this.btnNewWithdrawl.Location = new System.Drawing.Point(454, 732);
            this.btnNewWithdrawl.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewWithdrawl.Name = "btnNewWithdrawl";
            this.btnNewWithdrawl.Size = new System.Drawing.Size(417, 79);
            this.btnNewWithdrawl.TabIndex = 9;
            this.btnNewWithdrawl.Text = "New Withdrawal";
            this.btnNewWithdrawl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewWithdrawl.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNewWithdrawl.UseVisualStyleBackColor = true;
            // 
            // btnNewDeposite
            // 
            this.btnNewDeposite.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnNewDeposite.FlatAppearance.BorderSize = 6;
            this.btnNewDeposite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNewDeposite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewDeposite.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewDeposite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNewDeposite.Image = global::SmartBank_UI.Properties.Resources.icons8_up_arrow_50;
            this.btnNewDeposite.Location = new System.Drawing.Point(14, 732);
            this.btnNewDeposite.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewDeposite.Name = "btnNewDeposite";
            this.btnNewDeposite.Size = new System.Drawing.Size(417, 79);
            this.btnNewDeposite.TabIndex = 7;
            this.btnNewDeposite.Text = "New Deposit";
            this.btnNewDeposite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewDeposite.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNewDeposite.UseVisualStyleBackColor = true;
            // 
            // ctrlDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.btnTransfare);
            this.Controls.Add(this.btnNewWithdrawl);
            this.Controls.Add(this.btnNewDeposite);
            this.Controls.Add(this.dgvFraudFlags);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dgvRecentTransactions);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblMorningToUserWithName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ctrlDashboard";
            this.Size = new System.Drawing.Size(1324, 829);
            this.Load += new System.EventHandler(this.ctrlDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFraudFlags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMorningToUserWithName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblActiveAccounts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTransactionsToday;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblFraudFlags;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblPendingTransfares;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvFraudFlags;
        private System.Windows.Forms.DataGridView dgvRecentTransactions;
        private System.Windows.Forms.Button btnNewDeposite;
        private System.Windows.Forms.Button btnNewWithdrawl;
        private System.Windows.Forms.Button btnTransfare;
    }
}
