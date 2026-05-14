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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbUserPhoto = new System.Windows.Forms.PictureBox();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUSerFullName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCurrentUserAccount = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnSystemConfig = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAuditLog = new System.Windows.Forms.Button();
            this.btnFraudFlags = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.btnScheduled = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDashBoard = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pMain = new System.Windows.Forms.Panel();
            this.DayTime = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPhoto)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSignOut);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2342, 106);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pbUserPhoto);
            this.panel2.Controls.Add(this.lblUserRole);
            this.panel2.Controls.Add(this.lblUSerFullName);
            this.panel2.Location = new System.Drawing.Point(1747, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 89);
            this.panel2.TabIndex = 8;
            // 
            // pbUserPhoto
            // 
            this.pbUserPhoto.Image = global::SmartBank_UI.Properties.Resources.icons8_user_50;
            this.pbUserPhoto.Location = new System.Drawing.Point(14, 17);
            this.pbUserPhoto.Name = "pbUserPhoto";
            this.pbUserPhoto.Size = new System.Drawing.Size(64, 54);
            this.pbUserPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUserPhoto.TabIndex = 2;
            this.pbUserPhoto.TabStop = false;
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblUserRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserRole.ForeColor = System.Drawing.Color.DarkGray;
            this.lblUserRole.Location = new System.Drawing.Point(86, 49);
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
            this.lblDate.Location = new System.Drawing.Point(366, 35);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(521, 38);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Month/Day/Year - Time (PM/AM)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(316, 15);
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
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 63);
            this.label1.TabIndex = 5;
            this.label1.Text = "Smart Bank";
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
            this.btnSignOut.Location = new System.Drawing.Point(2139, 6);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(196, 88);
            this.btnSignOut.TabIndex = 0;
            this.btnSignOut.Text = "  Sign Out";
            this.btnSignOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel3.Location = new System.Drawing.Point(4, 112);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(346, 1284);
            this.panel3.TabIndex = 1;
            // 
            // btnCurrentUserAccount
            // 
            this.btnCurrentUserAccount.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCurrentUserAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrentUserAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurrentUserAccount.ForeColor = System.Drawing.Color.Silver;
            this.btnCurrentUserAccount.Image = global::SmartBank_UI.Properties.Resources.icons8_account_50;
            this.btnCurrentUserAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurrentUserAccount.Location = new System.Drawing.Point(8, 925);
            this.btnCurrentUserAccount.Name = "btnCurrentUserAccount";
            this.btnCurrentUserAccount.Size = new System.Drawing.Size(326, 105);
            this.btnCurrentUserAccount.TabIndex = 14;
            this.btnCurrentUserAccount.Text = " User Account";
            this.btnCurrentUserAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCurrentUserAccount.UseVisualStyleBackColor = true;
            this.btnCurrentUserAccount.Click += new System.EventHandler(this.btnCurrentUserAccount_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.Silver;
            this.btnUsers.Image = global::SmartBank_UI.Properties.Resources.icons8_admin_64;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(8, 1162);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(326, 105);
            this.btnUsers.TabIndex = 13;
            this.btnUsers.Text = "Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnSystemConfig
            // 
            this.btnSystemConfig.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSystemConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSystemConfig.ForeColor = System.Drawing.Color.Silver;
            this.btnSystemConfig.Image = global::SmartBank_UI.Properties.Resources.icons8_administrative_tools_50;
            this.btnSystemConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystemConfig.Location = new System.Drawing.Point(8, 1043);
            this.btnSystemConfig.Name = "btnSystemConfig";
            this.btnSystemConfig.Size = new System.Drawing.Size(326, 105);
            this.btnSystemConfig.TabIndex = 12;
            this.btnSystemConfig.Text = "  System Config";
            this.btnSystemConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystemConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSystemConfig.UseVisualStyleBackColor = true;
            this.btnSystemConfig.Click += new System.EventHandler(this.btnSystemConfig_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(8, 891);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "ADMIN";
            // 
            // btnAuditLog
            // 
            this.btnAuditLog.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAuditLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuditLog.ForeColor = System.Drawing.Color.Silver;
            this.btnAuditLog.Image = global::SmartBank_UI.Properties.Resources.icons8_log_50;
            this.btnAuditLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditLog.Location = new System.Drawing.Point(8, 771);
            this.btnAuditLog.Name = "btnAuditLog";
            this.btnAuditLog.Size = new System.Drawing.Size(326, 94);
            this.btnAuditLog.TabIndex = 10;
            this.btnAuditLog.Text = "  Audit Log";
            this.btnAuditLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAuditLog.UseVisualStyleBackColor = true;
            this.btnAuditLog.Click += new System.EventHandler(this.btnAuditLog_Click);
            // 
            // btnFraudFlags
            // 
            this.btnFraudFlags.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnFraudFlags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFraudFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFraudFlags.ForeColor = System.Drawing.Color.Silver;
            this.btnFraudFlags.Image = global::SmartBank_UI.Properties.Resources.icons8_customers_50;
            this.btnFraudFlags.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFraudFlags.Location = new System.Drawing.Point(8, 671);
            this.btnFraudFlags.Name = "btnFraudFlags";
            this.btnFraudFlags.Size = new System.Drawing.Size(326, 94);
            this.btnFraudFlags.TabIndex = 9;
            this.btnFraudFlags.Text = "  Fraud Flags";
            this.btnFraudFlags.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFraudFlags.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFraudFlags.UseVisualStyleBackColor = true;
            this.btnFraudFlags.Click += new System.EventHandler(this.btnFraudFlags_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(8, 628);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "OVER NIGHT";
            // 
            // btnAccounts
            // 
            this.btnAccounts.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccounts.ForeColor = System.Drawing.Color.Silver;
            this.btnAccounts.Image = global::SmartBank_UI.Properties.Resources.icons8_merchant_account_50;
            this.btnAccounts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccounts.Location = new System.Drawing.Point(8, 312);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(326, 94);
            this.btnAccounts.TabIndex = 7;
            this.btnAccounts.Text = "  Accounts";
            this.btnAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccounts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccounts.UseVisualStyleBackColor = true;
            this.btnAccounts.Click += new System.EventHandler(this.btnAccounts_Click);
            // 
            // btnScheduled
            // 
            this.btnScheduled.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnScheduled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScheduled.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScheduled.ForeColor = System.Drawing.Color.Silver;
            this.btnScheduled.Image = global::SmartBank_UI.Properties.Resources.icons8_scheduled_delivery_58;
            this.btnScheduled.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScheduled.Location = new System.Drawing.Point(8, 512);
            this.btnScheduled.Name = "btnScheduled";
            this.btnScheduled.Size = new System.Drawing.Size(326, 100);
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
            this.btnTransactions.Location = new System.Drawing.Point(8, 412);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(326, 94);
            this.btnTransactions.TabIndex = 4;
            this.btnTransactions.Text = "  Transactions";
            this.btnTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransactions.UseVisualStyleBackColor = true;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.ForeColor = System.Drawing.Color.Silver;
            this.btnCustomers.Image = global::SmartBank_UI.Properties.Resources.icons8_customers_50;
            this.btnCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.Location = new System.Drawing.Point(8, 212);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(326, 94);
            this.btnCustomers.TabIndex = 3;
            this.btnCustomers.Text = "  Customers";
            this.btnCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(8, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "BANKING";
            // 
            // btnDashBoard
            // 
            this.btnDashBoard.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDashBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashBoard.ForeColor = System.Drawing.Color.Silver;
            this.btnDashBoard.Image = global::SmartBank_UI.Properties.Resources.icons8_dashboard_48;
            this.btnDashBoard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashBoard.Location = new System.Drawing.Point(8, 62);
            this.btnDashBoard.Name = "btnDashBoard";
            this.btnDashBoard.Size = new System.Drawing.Size(326, 85);
            this.btnDashBoard.TabIndex = 1;
            this.btnDashBoard.Text = "  Dashboard";
            this.btnDashBoard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashBoard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashBoard.UseVisualStyleBackColor = true;
            this.btnDashBoard.Click += new System.EventHandler(this.btnDashBoard_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "DASHBOARD";
            // 
            // pMain
            // 
            this.pMain.Location = new System.Drawing.Point(357, 117);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1990, 1272);
            this.pMain.TabIndex = 2;
            // 
            // DayTime
            // 
            this.DayTime.Interval = 1000;
            this.DayTime.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(2352, 1395);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPhoto)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.PictureBox pbUserPhoto;
        private System.Windows.Forms.Button btnCurrentUserAccount;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Timer DayTime;
    }
}
