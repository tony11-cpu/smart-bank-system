namespace SmartBank_UI
{
    partial class frmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUSerFullName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCurrentUserAccount = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnSystemConfig = new System.Windows.Forms.Button();
            this.btnAuditLog = new System.Windows.Forms.Button();
            this.btnFraudFlags = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.btnScheduled = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnDashBoard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.pMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSignOut);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2338, 107);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblUserRole);
            this.panel2.Controls.Add(this.lblUSerFullName);
            this.panel2.Location = new System.Drawing.Point(1738, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 90);
            this.panel2.TabIndex = 8;
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblUserRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserRole.ForeColor = System.Drawing.Color.DarkGray;
            this.lblUserRole.Location = new System.Drawing.Point(86, 50);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(164, 25);
            this.lblUserRole.TabIndex = 1;
            this.lblUserRole.Text = "User Permissions";
            // 
            // lblUSerFullName
            // 
            this.lblUSerFullName.AutoSize = true;
            this.lblUSerFullName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblUSerFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUSerFullName.ForeColor = System.Drawing.Color.LightGray;
            this.lblUSerFullName.Location = new System.Drawing.Point(86, 12);
            this.lblUSerFullName.Name = "lblUSerFullName";
            this.lblUSerFullName.Size = new System.Drawing.Size(272, 29);
            this.lblUSerFullName.TabIndex = 0;
            this.lblUSerFullName.Text = "First Name + Last Name";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Rockwell", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.DarkGray;
            this.lblDate.Location = new System.Drawing.Point(394, 40);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(521, 38);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Month/Day/Year - Time (PM/AM)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(341, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 63);
            this.label2.TabIndex = 6;
            this.label2.Text = "|";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 63);
            this.label1.TabIndex = 5;
            this.label1.Text = "Smart Bank";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.Controls.Add(this.btnCurrentUserAccount);
            this.panel3.Controls.Add(this.btnUsers);
            this.panel3.Controls.Add(this.btnSystemConfig);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.btnAuditLog);
            this.panel3.Controls.Add(this.btnFraudFlags);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.btnAccounts);
            this.panel3.Controls.Add(this.btnScheduled);
            this.panel3.Controls.Add(this.btnTransactions);
            this.panel3.Controls.Add(this.btnCustomers);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnDashBoard);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(5, 112);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(346, 1284);
            this.panel3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "DASHBOARD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(7, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "BANKING";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(7, 639);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "OVER NIGHT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(7, 902);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "ADMIN";
            // 
            // btnCurrentUserAccount
            // 
            this.btnCurrentUserAccount.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCurrentUserAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrentUserAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurrentUserAccount.ForeColor = System.Drawing.Color.Silver;
            this.btnCurrentUserAccount.Image = global::SmartBank_UI.Properties.Resources.icons8_account_50;
            this.btnCurrentUserAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurrentUserAccount.Location = new System.Drawing.Point(7, 1163);
            this.btnCurrentUserAccount.Name = "btnCurrentUserAccount";
            this.btnCurrentUserAccount.Size = new System.Drawing.Size(325, 104);
            this.btnCurrentUserAccount.TabIndex = 14;
            this.btnCurrentUserAccount.Text = "  Account";
            this.btnCurrentUserAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCurrentUserAccount.UseVisualStyleBackColor = true;
            // 
            // btnUsers
            // 
            this.btnUsers.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.Silver;
            this.btnUsers.Image = global::SmartBank_UI.Properties.Resources.icons8_admin_64;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(7, 1053);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(325, 104);
            this.btnUsers.TabIndex = 13;
            this.btnUsers.Text = "Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = true;
            // 
            // btnSystemConfig
            // 
            this.btnSystemConfig.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSystemConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSystemConfig.ForeColor = System.Drawing.Color.Silver;
            this.btnSystemConfig.Image = global::SmartBank_UI.Properties.Resources.icons8_administrative_tools_50;
            this.btnSystemConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystemConfig.Location = new System.Drawing.Point(7, 943);
            this.btnSystemConfig.Name = "btnSystemConfig";
            this.btnSystemConfig.Size = new System.Drawing.Size(325, 104);
            this.btnSystemConfig.TabIndex = 12;
            this.btnSystemConfig.Text = "  System Config";
            this.btnSystemConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystemConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSystemConfig.UseVisualStyleBackColor = true;
            // 
            // btnAuditLog
            // 
            this.btnAuditLog.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAuditLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuditLog.ForeColor = System.Drawing.Color.Silver;
            this.btnAuditLog.Image = global::SmartBank_UI.Properties.Resources.icons8_log_50;
            this.btnAuditLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditLog.Location = new System.Drawing.Point(7, 781);
            this.btnAuditLog.Name = "btnAuditLog";
            this.btnAuditLog.Size = new System.Drawing.Size(325, 94);
            this.btnAuditLog.TabIndex = 10;
            this.btnAuditLog.Text = "  Audit Log";
            this.btnAuditLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAuditLog.UseVisualStyleBackColor = true;
            // 
            // btnFraudFlags
            // 
            this.btnFraudFlags.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnFraudFlags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFraudFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFraudFlags.ForeColor = System.Drawing.Color.Silver;
            this.btnFraudFlags.Image = global::SmartBank_UI.Properties.Resources.icons8_customers_50;
            this.btnFraudFlags.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFraudFlags.Location = new System.Drawing.Point(7, 681);
            this.btnFraudFlags.Name = "btnFraudFlags";
            this.btnFraudFlags.Size = new System.Drawing.Size(325, 94);
            this.btnFraudFlags.TabIndex = 9;
            this.btnFraudFlags.Text = "  Fraud Flags";
            this.btnFraudFlags.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFraudFlags.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFraudFlags.UseVisualStyleBackColor = true;
            // 
            // btnAccounts
            // 
            this.btnAccounts.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccounts.ForeColor = System.Drawing.Color.Silver;
            this.btnAccounts.Image = global::SmartBank_UI.Properties.Resources.icons8_merchant_account_50;
            this.btnAccounts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccounts.Location = new System.Drawing.Point(7, 323);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(325, 94);
            this.btnAccounts.TabIndex = 7;
            this.btnAccounts.Text = "  Accounts";
            this.btnAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccounts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccounts.UseVisualStyleBackColor = true;
            // 
            // btnScheduled
            // 
            this.btnScheduled.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnScheduled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScheduled.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScheduled.ForeColor = System.Drawing.Color.Silver;
            this.btnScheduled.Image = global::SmartBank_UI.Properties.Resources.icons8_scheduled_delivery_58;
            this.btnScheduled.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScheduled.Location = new System.Drawing.Point(7, 523);
            this.btnScheduled.Name = "btnScheduled";
            this.btnScheduled.Size = new System.Drawing.Size(325, 100);
            this.btnScheduled.TabIndex = 5;
            this.btnScheduled.Text = "  Scheduled";
            this.btnScheduled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScheduled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnScheduled.UseVisualStyleBackColor = true;
            // 
            // btnTransactions
            // 
            this.btnTransactions.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactions.ForeColor = System.Drawing.Color.Silver;
            this.btnTransactions.Image = global::SmartBank_UI.Properties.Resources.icons8_transaction_50;
            this.btnTransactions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.Location = new System.Drawing.Point(7, 423);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(325, 94);
            this.btnTransactions.TabIndex = 4;
            this.btnTransactions.Text = "  Transactions";
            this.btnTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransactions.UseVisualStyleBackColor = true;
            // 
            // btnCustomers
            // 
            this.btnCustomers.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.ForeColor = System.Drawing.Color.Silver;
            this.btnCustomers.Image = global::SmartBank_UI.Properties.Resources.icons8_customers_50;
            this.btnCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.Location = new System.Drawing.Point(7, 223);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(325, 94);
            this.btnCustomers.TabIndex = 3;
            this.btnCustomers.Text = "  Customers";
            this.btnCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomers.UseVisualStyleBackColor = true;
            // 
            // btnDashBoard
            // 
            this.btnDashBoard.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDashBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashBoard.ForeColor = System.Drawing.Color.Silver;
            this.btnDashBoard.Image = global::SmartBank_UI.Properties.Resources.icons8_dashboard_48;
            this.btnDashBoard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashBoard.Location = new System.Drawing.Point(7, 72);
            this.btnDashBoard.Name = "btnDashBoard";
            this.btnDashBoard.Size = new System.Drawing.Size(325, 84);
            this.btnDashBoard.TabIndex = 1;
            this.btnDashBoard.Text = "  Dashboard";
            this.btnDashBoard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashBoard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashBoard.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SmartBank_UI.Properties.Resources.icons8_user_50;
            this.pictureBox1.Location = new System.Drawing.Point(14, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.Navy;
            this.btnSignOut.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSignOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSignOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOut.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.ForeColor = System.Drawing.Color.LightGray;
            this.btnSignOut.Image = global::SmartBank_UI.Properties.Resources.icons8_sign_out_30;
            this.btnSignOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSignOut.Location = new System.Drawing.Point(2126, 17);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(197, 75);
            this.btnSignOut.TabIndex = 0;
            this.btnSignOut.Text = "  Sign Out";
            this.btnSignOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // pMain
            // 
            this.pMain.Location = new System.Drawing.Point(356, 122);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1986, 1262);
            this.pMain.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(2347, 1396);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Label lblUSerFullName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDashBoard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.Button btnScheduled;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnFraudFlags;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAuditLog;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnSystemConfig;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCurrentUserAccount;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Button button2;
    }
}