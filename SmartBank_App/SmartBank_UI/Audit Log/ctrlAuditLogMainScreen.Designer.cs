namespace SmartBank_UI.Audit_Log
{
    partial class ctrlAuditLogMainScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblAuditLogFormInfoToUser = new System.Windows.Forms.Label();
            this.tbSearchBar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.cbActionFilter = new System.Windows.Forms.ComboBox();
            this.cbResultFilter = new System.Windows.Forms.ComboBox();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatTodayValue = new System.Windows.Forms.Label();
            this.lblStatTodayText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStatSensitiveValue = new System.Windows.Forms.Label();
            this.lblStatSensitiveText = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblStatSecurityValue = new System.Windows.Forms.Label();
            this.lblStatSecurityText = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblStatFailedValue = new System.Windows.Forms.Label();
            this.lblStatFailedText = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.dgvAuditTrail = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblClickToInspectAudit = new System.Windows.Forms.Label();
            this.lblNumberOfAuditLogs = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnCopyAuditID = new System.Windows.Forms.Button();
            this.btnOpenRelatedRecord = new System.Windows.Forms.Button();
            this.tbTimestamp = new System.Windows.Forms.TextBox();
            this.lblTimeStamp = new System.Windows.Forms.Label();
            this.tbNewValue = new System.Windows.Forms.TextBox();
            this.lblNewValue = new System.Windows.Forms.Label();
            this.tbOldValue = new System.Windows.Forms.TextBox();
            this.lblOldValue = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbRecordID = new System.Windows.Forms.TextBox();
            this.lblRecordID = new System.Windows.Forms.Label();
            this.tbEntity = new System.Windows.Forms.TextBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.tbRole = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.tbAuditID = new System.Windows.Forms.TextBox();
            this.lblAuditID = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblAuditSubTitle = new System.Windows.Forms.Label();
            this.lblAuditDetailTitle = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditTrail)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Audit Log";
            // 
            // lblAuditLogFormInfoToUser
            // 
            this.lblAuditLogFormInfoToUser.AutoSize = true;
            this.lblAuditLogFormInfoToUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditLogFormInfoToUser.ForeColor = System.Drawing.Color.DarkGray;
            this.lblAuditLogFormInfoToUser.Location = new System.Drawing.Point(25, 43);
            this.lblAuditLogFormInfoToUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAuditLogFormInfoToUser.Name = "lblAuditLogFormInfoToUser";
            this.lblAuditLogFormInfoToUser.Size = new System.Drawing.Size(798, 18);
            this.lblAuditLogFormInfoToUser.TabIndex = 1;
            this.lblAuditLogFormInfoToUser.Text = "Complete immutable record of security, customer, account, transaction, and configuration actions.";
            // 
            // tbSearchBar
            // 
            this.tbSearchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSearchBar.Location = new System.Drawing.Point(10, 190);
            this.tbSearchBar.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearchBar.Name = "tbSearchBar";
            this.tbSearchBar.Size = new System.Drawing.Size(625, 26);
            this.tbSearchBar.TabIndex = 10;
            this.tbSearchBar.Tag = "Search by user, action, account, customer, table, or record ID...";
            this.tbSearchBar.Text = "Search by user, action, account, customer, table, or record ID...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Search:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFromDate.CalendarMonthBackground = System.Drawing.Color.MidnightBlue;
            this.dtpFromDate.CalendarTitleBackColor = System.Drawing.Color.MidnightBlue;
            this.dtpFromDate.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFromDate.CalendarTrailingForeColor = System.Drawing.Color.DarkGray;
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(639, 189);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(170, 26);
            this.dtpFromDate.TabIndex = 11;
            // 
            // cbActionFilter
            // 
            this.cbActionFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cbActionFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbActionFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbActionFilter.ForeColor = System.Drawing.Color.White;
            this.cbActionFilter.FormattingEnabled = true;
            this.cbActionFilter.Items.AddRange(new object[] {
            "All Actions",
            "Customer",
            "Account",
            "Transaction",
            "Security",
            "Permission",
            "Config"});
            this.cbActionFilter.Location = new System.Drawing.Point(813, 189);
            this.cbActionFilter.Margin = new System.Windows.Forms.Padding(2);
            this.cbActionFilter.Name = "cbActionFilter";
            this.cbActionFilter.SelectedIndex = 0;
            this.cbActionFilter.Size = new System.Drawing.Size(165, 28);
            this.cbActionFilter.TabIndex = 12;
            // 
            // cbResultFilter
            // 
            this.cbResultFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cbResultFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResultFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbResultFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbResultFilter.ForeColor = System.Drawing.Color.White;
            this.cbResultFilter.FormattingEnabled = true;
            this.cbResultFilter.Items.AddRange(new object[] {
            "All Results",
            "Success",
            "Failed",
            "Warning"});
            this.cbResultFilter.Location = new System.Drawing.Point(983, 189);
            this.cbResultFilter.Margin = new System.Windows.Forms.Padding(2);
            this.cbResultFilter.Name = "cbResultFilter";
            this.cbResultFilter.SelectedIndex = 0;
            this.cbResultFilter.Size = new System.Drawing.Size(165, 28);
            this.cbResultFilter.TabIndex = 13;
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExportCsv.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExportCsv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnExportCsv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnExportCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCsv.ForeColor = System.Drawing.Color.White;
            this.btnExportCsv.Image = global::SmartBank_UI.Properties.Resources.icons8_plus_24;
            this.btnExportCsv.Location = new System.Drawing.Point(1149, 66);
            this.btnExportCsv.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(164, 54);
            this.btnExportCsv.TabIndex = 7;
            this.btnExportCsv.Text = "Export CSV";
            this.btnExportCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportCsv.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblStatTodayValue);
            this.panel1.Controls.Add(this.lblStatTodayText);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(10, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 74);
            this.panel1.TabIndex = 2;
            // 
            // lblStatTodayValue
            // 
            this.lblStatTodayValue.AutoSize = true;
            this.lblStatTodayValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatTodayValue.ForeColor = System.Drawing.Color.White;
            this.lblStatTodayValue.Location = new System.Drawing.Point(146, 36);
            this.lblStatTodayValue.Name = "lblStatTodayValue";
            this.lblStatTodayValue.Size = new System.Drawing.Size(30, 24);
            this.lblStatTodayValue.TabIndex = 2;
            this.lblStatTodayValue.Text = "0";
            // 
            // lblStatTodayText
            // 
            this.lblStatTodayText.AutoSize = true;
            this.lblStatTodayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatTodayText.ForeColor = System.Drawing.Color.White;
            this.lblStatTodayText.Location = new System.Drawing.Point(60, 12);
            this.lblStatTodayText.Name = "lblStatTodayText";
            this.lblStatTodayText.Size = new System.Drawing.Size(72, 17);
            this.lblStatTodayText.TabIndex = 1;
            this.lblStatTodayText.Text = "Logs Today";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SmartBank_UI.Properties.Resources.icons8_log_50;
            this.pictureBox1.Location = new System.Drawing.Point(10, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblStatSensitiveValue);
            this.panel2.Controls.Add(this.lblStatSensitiveText);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(224, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 74);
            this.panel2.TabIndex = 3;
            // 
            // lblStatSensitiveValue
            // 
            this.lblStatSensitiveValue.AutoSize = true;
            this.lblStatSensitiveValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatSensitiveValue.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblStatSensitiveValue.Location = new System.Drawing.Point(146, 36);
            this.lblStatSensitiveValue.Name = "lblStatSensitiveValue";
            this.lblStatSensitiveValue.Size = new System.Drawing.Size(30, 24);
            this.lblStatSensitiveValue.TabIndex = 2;
            this.lblStatSensitiveValue.Text = "0";
            // 
            // lblStatSensitiveText
            // 
            this.lblStatSensitiveText.AutoSize = true;
            this.lblStatSensitiveText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatSensitiveText.ForeColor = System.Drawing.Color.White;
            this.lblStatSensitiveText.Location = new System.Drawing.Point(60, 12);
            this.lblStatSensitiveText.Name = "lblStatSensitiveText";
            this.lblStatSensitiveText.Size = new System.Drawing.Size(65, 17);
            this.lblStatSensitiveText.TabIndex = 1;
            this.lblStatSensitiveText.Text = "Sensitive";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SmartBank_UI.Properties.Resources.icons8_view_50;
            this.pictureBox2.Location = new System.Drawing.Point(10, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblStatSecurityValue);
            this.panel3.Controls.Add(this.lblStatSecurityText);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Location = new System.Drawing.Point(438, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 74);
            this.panel3.TabIndex = 4;
            // 
            // lblStatSecurityValue
            // 
            this.lblStatSecurityValue.AutoSize = true;
            this.lblStatSecurityValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatSecurityValue.ForeColor = System.Drawing.Color.Orange;
            this.lblStatSecurityValue.Location = new System.Drawing.Point(146, 36);
            this.lblStatSecurityValue.Name = "lblStatSecurityValue";
            this.lblStatSecurityValue.Size = new System.Drawing.Size(30, 24);
            this.lblStatSecurityValue.TabIndex = 2;
            this.lblStatSecurityValue.Text = "0";
            // 
            // lblStatSecurityText
            // 
            this.lblStatSecurityText.AutoSize = true;
            this.lblStatSecurityText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatSecurityText.ForeColor = System.Drawing.Color.White;
            this.lblStatSecurityText.Location = new System.Drawing.Point(60, 12);
            this.lblStatSecurityText.Name = "lblStatSecurityText";
            this.lblStatSecurityText.Size = new System.Drawing.Size(56, 17);
            this.lblStatSecurityText.TabIndex = 1;
            this.lblStatSecurityText.Text = "Security";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SmartBank_UI.Properties.Resources.icons8_lock_64;
            this.pictureBox3.Location = new System.Drawing.Point(10, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(42, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblStatFailedValue);
            this.panel4.Controls.Add(this.lblStatFailedText);
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Location = new System.Drawing.Point(652, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(210, 74);
            this.panel4.TabIndex = 5;
            // 
            // lblStatFailedValue
            // 
            this.lblStatFailedValue.AutoSize = true;
            this.lblStatFailedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatFailedValue.ForeColor = System.Drawing.Color.Red;
            this.lblStatFailedValue.Location = new System.Drawing.Point(146, 36);
            this.lblStatFailedValue.Name = "lblStatFailedValue";
            this.lblStatFailedValue.Size = new System.Drawing.Size(30, 24);
            this.lblStatFailedValue.TabIndex = 2;
            this.lblStatFailedValue.Text = "0";
            // 
            // lblStatFailedText
            // 
            this.lblStatFailedText.AutoSize = true;
            this.lblStatFailedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatFailedText.ForeColor = System.Drawing.Color.White;
            this.lblStatFailedText.Location = new System.Drawing.Point(60, 12);
            this.lblStatFailedText.Name = "lblStatFailedText";
            this.lblStatFailedText.Size = new System.Drawing.Size(44, 17);
            this.lblStatFailedText.TabIndex = 1;
            this.lblStatFailedText.Text = "Failed";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::SmartBank_UI.Properties.Resources.icons8_close_40;
            this.pictureBox4.Location = new System.Drawing.Point(10, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(42, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // dgvAuditTrail
            // 
            this.dgvAuditTrail.AllowUserToAddRows = false;
            this.dgvAuditTrail.AllowUserToDeleteRows = false;
            this.dgvAuditTrail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuditTrail.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvAuditTrail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditTrail.Location = new System.Drawing.Point(10, 225);
            this.dgvAuditTrail.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAuditTrail.MultiSelect = false;
            this.dgvAuditTrail.Name = "dgvAuditTrail";
            this.dgvAuditTrail.ReadOnly = true;
            this.dgvAuditTrail.RowHeadersVisible = false;
            this.dgvAuditTrail.RowHeadersWidth = 62;
            this.dgvAuditTrail.RowTemplate.Height = 28;
            this.dgvAuditTrail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditTrail.Size = new System.Drawing.Size(818, 532);
            this.dgvAuditTrail.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblClickToInspectAudit);
            this.panel5.Controls.Add(this.lblNumberOfAuditLogs);
            this.panel5.Location = new System.Drawing.Point(10, 761);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(818, 57);
            this.panel5.TabIndex = 16;
            // 
            // lblClickToInspectAudit
            // 
            this.lblClickToInspectAudit.AutoSize = true;
            this.lblClickToInspectAudit.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblClickToInspectAudit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClickToInspectAudit.ForeColor = System.Drawing.Color.White;
            this.lblClickToInspectAudit.Location = new System.Drawing.Point(567, 16);
            this.lblClickToInspectAudit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClickToInspectAudit.Name = "lblClickToInspectAudit";
            this.lblClickToInspectAudit.Size = new System.Drawing.Size(234, 24);
            this.lblClickToInspectAudit.TabIndex = 1;
            this.lblClickToInspectAudit.Text = "Click a row to inspect details";
            // 
            // lblNumberOfAuditLogs
            // 
            this.lblNumberOfAuditLogs.AutoSize = true;
            this.lblNumberOfAuditLogs.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblNumberOfAuditLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfAuditLogs.ForeColor = System.Drawing.Color.White;
            this.lblNumberOfAuditLogs.Location = new System.Drawing.Point(13, 16);
            this.lblNumberOfAuditLogs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumberOfAuditLogs.Name = "lblNumberOfAuditLogs";
            this.lblNumberOfAuditLogs.Size = new System.Drawing.Size(214, 24);
            this.lblNumberOfAuditLogs.TabIndex = 0;
            this.lblNumberOfAuditLogs.Text = "Showing 0 audit records";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnCopyAuditID);
            this.panel6.Controls.Add(this.btnOpenRelatedRecord);
            this.panel6.Controls.Add(this.tbTimestamp);
            this.panel6.Controls.Add(this.lblTimeStamp);
            this.panel6.Controls.Add(this.tbNewValue);
            this.panel6.Controls.Add(this.lblNewValue);
            this.panel6.Controls.Add(this.tbOldValue);
            this.panel6.Controls.Add(this.lblOldValue);
            this.panel6.Controls.Add(this.tbDescription);
            this.panel6.Controls.Add(this.lblDescription);
            this.panel6.Controls.Add(this.tbRecordID);
            this.panel6.Controls.Add(this.lblRecordID);
            this.panel6.Controls.Add(this.tbEntity);
            this.panel6.Controls.Add(this.lblEntity);
            this.panel6.Controls.Add(this.tbRole);
            this.panel6.Controls.Add(this.lblRole);
            this.panel6.Controls.Add(this.tbUser);
            this.panel6.Controls.Add(this.lblUser);
            this.panel6.Controls.Add(this.tbResult);
            this.panel6.Controls.Add(this.lblResult);
            this.panel6.Controls.Add(this.tbAuditID);
            this.panel6.Controls.Add(this.lblAuditID);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(837, 225);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(471, 593);
            this.panel6.TabIndex = 17;
            // 
            // btnCopyAuditID
            // 
            this.btnCopyAuditID.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnCopyAuditID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyAuditID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyAuditID.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnCopyAuditID.Location = new System.Drawing.Point(240, 548);
            this.btnCopyAuditID.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyAuditID.Name = "btnCopyAuditID";
            this.btnCopyAuditID.Size = new System.Drawing.Size(208, 33);
            this.btnCopyAuditID.TabIndex = 24;
            this.btnCopyAuditID.Text = "Copy Audit ID";
            this.btnCopyAuditID.UseVisualStyleBackColor = true;
            // 
            // btnOpenRelatedRecord
            // 
            this.btnOpenRelatedRecord.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnOpenRelatedRecord.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOpenRelatedRecord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnOpenRelatedRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnOpenRelatedRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenRelatedRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenRelatedRecord.ForeColor = System.Drawing.Color.White;
            this.btnOpenRelatedRecord.Location = new System.Drawing.Point(21, 548);
            this.btnOpenRelatedRecord.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenRelatedRecord.Name = "btnOpenRelatedRecord";
            this.btnOpenRelatedRecord.Size = new System.Drawing.Size(208, 33);
            this.btnOpenRelatedRecord.TabIndex = 23;
            this.btnOpenRelatedRecord.Text = "Open Related Record";
            this.btnOpenRelatedRecord.UseVisualStyleBackColor = false;
            // 
            // tbTimestamp
            // 
            this.tbTimestamp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbTimestamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTimestamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimestamp.ForeColor = System.Drawing.Color.White;
            this.tbTimestamp.Location = new System.Drawing.Point(21, 514);
            this.tbTimestamp.Margin = new System.Windows.Forms.Padding(2);
            this.tbTimestamp.Name = "tbTimestamp";
            this.tbTimestamp.ReadOnly = true;
            this.tbTimestamp.Size = new System.Drawing.Size(427, 24);
            this.tbTimestamp.TabIndex = 21;
            this.tbTimestamp.Text = "Timestamp";
            this.tbTimestamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTimeStamp
            // 
            this.lblTimeStamp.AutoSize = true;
            this.lblTimeStamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeStamp.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTimeStamp.Location = new System.Drawing.Point(18, 494);
            this.lblTimeStamp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimeStamp.Name = "lblTimeStamp";
            this.lblTimeStamp.Size = new System.Drawing.Size(95, 18);
            this.lblTimeStamp.TabIndex = 20;
            this.lblTimeStamp.Text = "TIMESTAMP";
            // 
            // tbNewValue
            // 
            this.tbNewValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbNewValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNewValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewValue.ForeColor = System.Drawing.Color.LimeGreen;
            this.tbNewValue.Location = new System.Drawing.Point(240, 374);
            this.tbNewValue.Margin = new System.Windows.Forms.Padding(2);
            this.tbNewValue.Multiline = true;
            this.tbNewValue.Name = "tbNewValue";
            this.tbNewValue.ReadOnly = true;
            this.tbNewValue.Size = new System.Drawing.Size(208, 110);
            this.tbNewValue.TabIndex = 18;
            this.tbNewValue.Text = "After value";
            // 
            // lblNewValue
            // 
            this.lblNewValue.AutoSize = true;
            this.lblNewValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewValue.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblNewValue.Location = new System.Drawing.Point(237, 354);
            this.lblNewValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewValue.Name = "lblNewValue";
            this.lblNewValue.Size = new System.Drawing.Size(88, 18);
            this.lblNewValue.TabIndex = 17;
            this.lblNewValue.Text = "NEW VALUE";
            // 
            // tbOldValue
            // 
            this.tbOldValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbOldValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOldValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOldValue.ForeColor = System.Drawing.Color.Red;
            this.tbOldValue.Location = new System.Drawing.Point(21, 374);
            this.tbOldValue.Margin = new System.Windows.Forms.Padding(2);
            this.tbOldValue.Multiline = true;
            this.tbOldValue.Name = "tbOldValue";
            this.tbOldValue.ReadOnly = true;
            this.tbOldValue.Size = new System.Drawing.Size(208, 110);
            this.tbOldValue.TabIndex = 16;
            this.tbOldValue.Text = "Before value";
            // 
            // lblOldValue
            // 
            this.lblOldValue.AutoSize = true;
            this.lblOldValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldValue.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblOldValue.Location = new System.Drawing.Point(18, 354);
            this.lblOldValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOldValue.Name = "lblOldValue";
            this.lblOldValue.Size = new System.Drawing.Size(84, 18);
            this.lblOldValue.TabIndex = 15;
            this.lblOldValue.Text = "OLD VALUE";
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescription.ForeColor = System.Drawing.Color.White;
            this.tbDescription.Location = new System.Drawing.Point(21, 308);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(2);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.Size = new System.Drawing.Size(427, 38);
            this.tbDescription.TabIndex = 14;
            this.tbDescription.Text = "Audit action description";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblDescription.Location = new System.Drawing.Point(18, 288);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(102, 18);
            this.lblDescription.TabIndex = 13;
            this.lblDescription.Text = "DESCRIPTION";
            // 
            // tbRecordID
            // 
            this.tbRecordID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbRecordID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRecordID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRecordID.ForeColor = System.Drawing.Color.White;
            this.tbRecordID.Location = new System.Drawing.Point(240, 258);
            this.tbRecordID.Margin = new System.Windows.Forms.Padding(2);
            this.tbRecordID.Name = "tbRecordID";
            this.tbRecordID.ReadOnly = true;
            this.tbRecordID.Size = new System.Drawing.Size(208, 24);
            this.tbRecordID.TabIndex = 12;
            this.tbRecordID.Text = "REC-000";
            this.tbRecordID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRecordID
            // 
            this.lblRecordID.AutoSize = true;
            this.lblRecordID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordID.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblRecordID.Location = new System.Drawing.Point(237, 238);
            this.lblRecordID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordID.Name = "lblRecordID";
            this.lblRecordID.Size = new System.Drawing.Size(84, 18);
            this.lblRecordID.TabIndex = 11;
            this.lblRecordID.Text = "RECORD ID";
            // 
            // tbEntity
            // 
            this.tbEntity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbEntity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEntity.ForeColor = System.Drawing.Color.White;
            this.tbEntity.Location = new System.Drawing.Point(21, 258);
            this.tbEntity.Margin = new System.Windows.Forms.Padding(2);
            this.tbEntity.Name = "tbEntity";
            this.tbEntity.ReadOnly = true;
            this.tbEntity.Size = new System.Drawing.Size(208, 24);
            this.tbEntity.TabIndex = 10;
            this.tbEntity.Text = "Entity";
            this.tbEntity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntity.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblEntity.Location = new System.Drawing.Point(18, 238);
            this.lblEntity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(56, 18);
            this.lblEntity.TabIndex = 9;
            this.lblEntity.Text = "ENTITY";
            // 
            // tbRole
            // 
            this.tbRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRole.ForeColor = System.Drawing.Color.White;
            this.tbRole.Location = new System.Drawing.Point(240, 210);
            this.tbRole.Margin = new System.Windows.Forms.Padding(2);
            this.tbRole.Name = "tbRole";
            this.tbRole.ReadOnly = true;
            this.tbRole.Size = new System.Drawing.Size(208, 24);
            this.tbRole.TabIndex = 8;
            this.tbRole.Text = "Role";
            this.tbRole.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblRole.Location = new System.Drawing.Point(237, 190);
            this.lblRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(44, 18);
            this.lblRole.TabIndex = 7;
            this.lblRole.Text = "ROLE";
            // 
            // tbUser
            // 
            this.tbUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUser.ForeColor = System.Drawing.Color.White;
            this.tbUser.Location = new System.Drawing.Point(21, 210);
            this.tbUser.Margin = new System.Windows.Forms.Padding(2);
            this.tbUser.Name = "tbUser";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(208, 24);
            this.tbUser.TabIndex = 6;
            this.tbUser.Text = "User";
            this.tbUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblUser.Location = new System.Drawing.Point(18, 190);
            this.lblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(45, 18);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "USER";
            // 
            // tbResult
            // 
            this.tbResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbResult.ForeColor = System.Drawing.Color.White;
            this.tbResult.Location = new System.Drawing.Point(240, 162);
            this.tbResult.Margin = new System.Windows.Forms.Padding(2);
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.Size = new System.Drawing.Size(208, 24);
            this.tbResult.TabIndex = 4;
            this.tbResult.Text = "Result";
            this.tbResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblResult.Location = new System.Drawing.Point(237, 142);
            this.lblResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(62, 18);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "RESULT";
            // 
            // tbAuditID
            // 
            this.tbAuditID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbAuditID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAuditID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAuditID.ForeColor = System.Drawing.Color.White;
            this.tbAuditID.Location = new System.Drawing.Point(21, 162);
            this.tbAuditID.Margin = new System.Windows.Forms.Padding(2);
            this.tbAuditID.Name = "tbAuditID";
            this.tbAuditID.ReadOnly = true;
            this.tbAuditID.Size = new System.Drawing.Size(208, 24);
            this.tbAuditID.TabIndex = 2;
            this.tbAuditID.Text = "AUD-000000";
            this.tbAuditID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAuditID
            // 
            this.lblAuditID.AutoSize = true;
            this.lblAuditID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditID.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblAuditID.Location = new System.Drawing.Point(18, 142);
            this.lblAuditID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAuditID.Name = "lblAuditID";
            this.lblAuditID.Size = new System.Drawing.Size(67, 18);
            this.lblAuditID.TabIndex = 1;
            this.lblAuditID.Text = "AUDIT ID";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblAuditSubTitle);
            this.panel7.Controls.Add(this.lblAuditDetailTitle);
            this.panel7.Controls.Add(this.pictureBox5);
            this.panel7.Location = new System.Drawing.Point(-1, 1);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(472, 122);
            this.panel7.TabIndex = 0;
            // 
            // lblAuditSubTitle
            // 
            this.lblAuditSubTitle.AutoSize = true;
            this.lblAuditSubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditSubTitle.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblAuditSubTitle.Location = new System.Drawing.Point(121, 68);
            this.lblAuditSubTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAuditSubTitle.Name = "lblAuditSubTitle";
            this.lblAuditSubTitle.Size = new System.Drawing.Size(215, 17);
            this.lblAuditSubTitle.TabIndex = 2;
            this.lblAuditSubTitle.Text = "Select an audit record to inspect.";
            // 
            // lblAuditDetailTitle
            // 
            this.lblAuditDetailTitle.AutoSize = true;
            this.lblAuditDetailTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditDetailTitle.ForeColor = System.Drawing.Color.White;
            this.lblAuditDetailTitle.Location = new System.Drawing.Point(121, 38);
            this.lblAuditDetailTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAuditDetailTitle.Name = "lblAuditDetailTitle";
            this.lblAuditDetailTitle.Size = new System.Drawing.Size(196, 24);
            this.lblAuditDetailTitle.TabIndex = 1;
            this.lblAuditDetailTitle.Text = "Audit Record - Details";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::SmartBank_UI.Properties.Resources.icons8_log_50;
            this.pictureBox5.Location = new System.Drawing.Point(19, 28);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(84, 66);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // ctrlAuditLogMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.dgvAuditTrail);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExportCsv);
            this.Controls.Add(this.cbResultFilter);
            this.Controls.Add(this.cbActionFilter);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.tbSearchBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAuditLogFormInfoToUser);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ctrlAuditLogMainScreen";
            this.Size = new System.Drawing.Size(1318, 833);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditTrail)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAuditLogFormInfoToUser;
        private System.Windows.Forms.TextBox tbSearchBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.ComboBox cbActionFilter;
        private System.Windows.Forms.ComboBox cbResultFilter;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatTodayValue;
        private System.Windows.Forms.Label lblStatTodayText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStatSensitiveValue;
        private System.Windows.Forms.Label lblStatSensitiveText;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblStatSecurityValue;
        private System.Windows.Forms.Label lblStatSecurityText;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblStatFailedValue;
        private System.Windows.Forms.Label lblStatFailedText;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.DataGridView dgvAuditTrail;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblClickToInspectAudit;
        private System.Windows.Forms.Label lblNumberOfAuditLogs;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblAuditSubTitle;
        private System.Windows.Forms.Label lblAuditDetailTitle;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox tbAuditID;
        private System.Windows.Forms.Label lblAuditID;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox tbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox tbRecordID;
        private System.Windows.Forms.Label lblRecordID;
        private System.Windows.Forms.TextBox tbEntity;
        private System.Windows.Forms.Label lblEntity;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbNewValue;
        private System.Windows.Forms.Label lblNewValue;
        private System.Windows.Forms.TextBox tbOldValue;
        private System.Windows.Forms.Label lblOldValue;
        private System.Windows.Forms.TextBox tbTimestamp;
        private System.Windows.Forms.Label lblTimeStamp;
        private System.Windows.Forms.Button btnCopyAuditID;
        private System.Windows.Forms.Button btnOpenRelatedRecord;
    }
}
