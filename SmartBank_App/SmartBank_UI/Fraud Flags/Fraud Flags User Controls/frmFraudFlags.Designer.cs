namespace SmartBank_UI.Fraud_Flags
{
    partial class ctrlFraudFlagsMainScreen
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.panelStatOpen = new System.Windows.Forms.Panel();
            this.lblStatOpenSub = new System.Windows.Forms.Label();
            this.lblStatOpenValue = new System.Windows.Forms.Label();
            this.lblStatOpenTitle = new System.Windows.Forms.Label();
            this.panelStatHighRisk = new System.Windows.Forms.Panel();
            this.lblStatHighRiskSub = new System.Windows.Forms.Label();
            this.lblStatHighRiskValue = new System.Windows.Forms.Label();
            this.lblStatHighRiskTitle = new System.Windows.Forms.Label();
            this.panelStatResolved = new System.Windows.Forms.Panel();
            this.lblStatResolvedSub = new System.Windows.Forms.Label();
            this.lblStatResolvedValue = new System.Windows.Forms.Label();
            this.lblStatResolvedTitle = new System.Windows.Forms.Label();
            this.panelStatTotal = new System.Windows.Forms.Panel();
            this.lblStatTotalSub = new System.Windows.Forms.Label();
            this.lblStatTotalValue = new System.Windows.Forms.Label();
            this.lblStatTotalTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnFilterAll = new System.Windows.Forms.Button();
            this.btnFilterOpen = new System.Windows.Forms.Button();
            this.btnFilterResolved = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvFraudFlags = new System.Windows.Forms.DataGridView();
            this.colFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelLeftFooter = new System.Windows.Forms.Panel();
            this.lblLeftFooterHint = new System.Windows.Forms.Label();
            this.lblLeftFooterCount = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnResolveFlag = new System.Windows.Forms.Button();
            this.btnKeepOpen = new System.Windows.Forms.Button();
            this.btnViewAccount = new System.Windows.Forms.Button();
            this.tbResolutionNotes = new System.Windows.Forms.TextBox();
            this.lblResolutionNotes = new System.Windows.Forms.Label();
            this.tbRecentActivity = new System.Windows.Forms.TextBox();
            this.lblRecentActivity = new System.Windows.Forms.Label();
            this.tbDetails = new System.Windows.Forms.TextBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.tbAccountStatus = new System.Windows.Forms.TextBox();
            this.lblAccountStatusTitle = new System.Windows.Forms.Label();
            this.tbRisk = new System.Windows.Forms.TextBox();
            this.lblRiskTitle = new System.Windows.Forms.Label();
            this.tbDetectedBy = new System.Windows.Forms.TextBox();
            this.lblDetectedByTitle = new System.Windows.Forms.Label();
            this.tbFlaggedDate = new System.Windows.Forms.TextBox();
            this.lblFlaggedDateTitle = new System.Windows.Forms.Label();
            this.tbCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomerTitle = new System.Windows.Forms.Label();
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.lblAccountTitle = new System.Windows.Forms.Label();
            this.panelRightHeader = new System.Windows.Forms.Panel();
            this.lblRightSub = new System.Windows.Forms.Label();
            this.lblRightTitle = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelStatOpen.SuspendLayout();
            this.panelStatHighRisk.SuspendLayout();
            this.panelStatResolved.SuspendLayout();
            this.panelStatTotal.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFraudFlags)).BeginInit();
            this.panelLeftFooter.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelRightHeader.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(142, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Fraud Flags";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.DarkGray;
            this.lblSubtitle.Location = new System.Drawing.Point(20, 42);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(653, 18);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Review suspicious activity detected automatically by the monitoring service and r" +
    "esolve fraud flags.";
            // 
            // btnExport
            // 
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.Image = global::SmartBank_UI.Properties.Resources.icons8_export_48;
            this.btnExport.Location = new System.Drawing.Point(1208, 184);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 54);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panelStatOpen
            // 
            this.panelStatOpen.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelStatOpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatOpen.Controls.Add(this.lblStatOpenSub);
            this.panelStatOpen.Controls.Add(this.lblStatOpenValue);
            this.panelStatOpen.Controls.Add(this.lblStatOpenTitle);
            this.panelStatOpen.Location = new System.Drawing.Point(39, 75);
            this.panelStatOpen.Name = "panelStatOpen";
            this.panelStatOpen.Size = new System.Drawing.Size(250, 95);
            this.panelStatOpen.TabIndex = 2;
            // 
            // lblStatOpenSub
            // 
            this.lblStatOpenSub.AutoSize = true;
            this.lblStatOpenSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatOpenSub.ForeColor = System.Drawing.Color.DarkGray;
            this.lblStatOpenSub.Location = new System.Drawing.Point(18, 67);
            this.lblStatOpenSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatOpenSub.Name = "lblStatOpenSub";
            this.lblStatOpenSub.Size = new System.Drawing.Size(148, 18);
            this.lblStatOpenSub.TabIndex = 2;
            this.lblStatOpenSub.Text = "need manager review";
            // 
            // lblStatOpenValue
            // 
            this.lblStatOpenValue.AutoSize = true;
            this.lblStatOpenValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatOpenValue.ForeColor = System.Drawing.Color.Red;
            this.lblStatOpenValue.Location = new System.Drawing.Point(17, 37);
            this.lblStatOpenValue.Name = "lblStatOpenValue";
            this.lblStatOpenValue.Size = new System.Drawing.Size(20, 24);
            this.lblStatOpenValue.TabIndex = 1;
            this.lblStatOpenValue.Text = "0";
            // 
            // lblStatOpenTitle
            // 
            this.lblStatOpenTitle.AutoSize = true;
            this.lblStatOpenTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatOpenTitle.ForeColor = System.Drawing.Color.White;
            this.lblStatOpenTitle.Location = new System.Drawing.Point(17, 6);
            this.lblStatOpenTitle.Name = "lblStatOpenTitle";
            this.lblStatOpenTitle.Size = new System.Drawing.Size(106, 24);
            this.lblStatOpenTitle.TabIndex = 0;
            this.lblStatOpenTitle.Text = "Unresolved";
            // 
            // panelStatHighRisk
            // 
            this.panelStatHighRisk.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelStatHighRisk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatHighRisk.Controls.Add(this.lblStatHighRiskSub);
            this.panelStatHighRisk.Controls.Add(this.lblStatHighRiskValue);
            this.panelStatHighRisk.Controls.Add(this.lblStatHighRiskTitle);
            this.panelStatHighRisk.Location = new System.Drawing.Point(305, 75);
            this.panelStatHighRisk.Name = "panelStatHighRisk";
            this.panelStatHighRisk.Size = new System.Drawing.Size(250, 95);
            this.panelStatHighRisk.TabIndex = 3;
            // 
            // lblStatHighRiskSub
            // 
            this.lblStatHighRiskSub.AutoSize = true;
            this.lblStatHighRiskSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatHighRiskSub.ForeColor = System.Drawing.Color.DarkGray;
            this.lblStatHighRiskSub.Location = new System.Drawing.Point(18, 67);
            this.lblStatHighRiskSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatHighRiskSub.Name = "lblStatHighRiskSub";
            this.lblStatHighRiskSub.Size = new System.Drawing.Size(136, 18);
            this.lblStatHighRiskSub.TabIndex = 2;
            this.lblStatHighRiskSub.Text = "large rapid activities";
            // 
            // lblStatHighRiskValue
            // 
            this.lblStatHighRiskValue.AutoSize = true;
            this.lblStatHighRiskValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatHighRiskValue.ForeColor = System.Drawing.Color.Orange;
            this.lblStatHighRiskValue.Location = new System.Drawing.Point(17, 37);
            this.lblStatHighRiskValue.Name = "lblStatHighRiskValue";
            this.lblStatHighRiskValue.Size = new System.Drawing.Size(20, 24);
            this.lblStatHighRiskValue.TabIndex = 1;
            this.lblStatHighRiskValue.Text = "0";
            // 
            // lblStatHighRiskTitle
            // 
            this.lblStatHighRiskTitle.AutoSize = true;
            this.lblStatHighRiskTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatHighRiskTitle.ForeColor = System.Drawing.Color.White;
            this.lblStatHighRiskTitle.Location = new System.Drawing.Point(17, 6);
            this.lblStatHighRiskTitle.Name = "lblStatHighRiskTitle";
            this.lblStatHighRiskTitle.Size = new System.Drawing.Size(90, 24);
            this.lblStatHighRiskTitle.TabIndex = 0;
            this.lblStatHighRiskTitle.Text = "High Risk";
            // 
            // panelStatResolved
            // 
            this.panelStatResolved.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelStatResolved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatResolved.Controls.Add(this.lblStatResolvedSub);
            this.panelStatResolved.Controls.Add(this.lblStatResolvedValue);
            this.panelStatResolved.Controls.Add(this.lblStatResolvedTitle);
            this.panelStatResolved.Location = new System.Drawing.Point(571, 75);
            this.panelStatResolved.Name = "panelStatResolved";
            this.panelStatResolved.Size = new System.Drawing.Size(250, 95);
            this.panelStatResolved.TabIndex = 4;
            // 
            // lblStatResolvedSub
            // 
            this.lblStatResolvedSub.AutoSize = true;
            this.lblStatResolvedSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatResolvedSub.ForeColor = System.Drawing.Color.DarkGray;
            this.lblStatResolvedSub.Location = new System.Drawing.Point(18, 67);
            this.lblStatResolvedSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatResolvedSub.Name = "lblStatResolvedSub";
            this.lblStatResolvedSub.Size = new System.Drawing.Size(131, 18);
            this.lblStatResolvedSub.TabIndex = 2;
            this.lblStatResolvedSub.Text = "closed after review";
            // 
            // lblStatResolvedValue
            // 
            this.lblStatResolvedValue.AutoSize = true;
            this.lblStatResolvedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatResolvedValue.ForeColor = System.Drawing.Color.LightGreen;
            this.lblStatResolvedValue.Location = new System.Drawing.Point(17, 37);
            this.lblStatResolvedValue.Name = "lblStatResolvedValue";
            this.lblStatResolvedValue.Size = new System.Drawing.Size(20, 24);
            this.lblStatResolvedValue.TabIndex = 1;
            this.lblStatResolvedValue.Text = "0";
            // 
            // lblStatResolvedTitle
            // 
            this.lblStatResolvedTitle.AutoSize = true;
            this.lblStatResolvedTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatResolvedTitle.ForeColor = System.Drawing.Color.White;
            this.lblStatResolvedTitle.Location = new System.Drawing.Point(17, 6);
            this.lblStatResolvedTitle.Name = "lblStatResolvedTitle";
            this.lblStatResolvedTitle.Size = new System.Drawing.Size(147, 24);
            this.lblStatResolvedTitle.TabIndex = 0;
            this.lblStatResolvedTitle.Text = "Resolved Today";
            // 
            // panelStatTotal
            // 
            this.panelStatTotal.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelStatTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatTotal.Controls.Add(this.lblStatTotalSub);
            this.panelStatTotal.Controls.Add(this.lblStatTotalValue);
            this.panelStatTotal.Controls.Add(this.lblStatTotalTitle);
            this.panelStatTotal.Location = new System.Drawing.Point(837, 75);
            this.panelStatTotal.Name = "panelStatTotal";
            this.panelStatTotal.Size = new System.Drawing.Size(250, 95);
            this.panelStatTotal.TabIndex = 5;
            // 
            // lblStatTotalSub
            // 
            this.lblStatTotalSub.AutoSize = true;
            this.lblStatTotalSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatTotalSub.ForeColor = System.Drawing.Color.DarkGray;
            this.lblStatTotalSub.Location = new System.Drawing.Point(18, 67);
            this.lblStatTotalSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatTotalSub.Name = "lblStatTotalSub";
            this.lblStatTotalSub.Size = new System.Drawing.Size(109, 18);
            this.lblStatTotalSub.TabIndex = 2;
            this.lblStatTotalSub.Text = "all time records";
            // 
            // lblStatTotalValue
            // 
            this.lblStatTotalValue.AutoSize = true;
            this.lblStatTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatTotalValue.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblStatTotalValue.Location = new System.Drawing.Point(17, 37);
            this.lblStatTotalValue.Name = "lblStatTotalValue";
            this.lblStatTotalValue.Size = new System.Drawing.Size(20, 24);
            this.lblStatTotalValue.TabIndex = 1;
            this.lblStatTotalValue.Text = "0";
            // 
            // lblStatTotalTitle
            // 
            this.lblStatTotalTitle.AutoSize = true;
            this.lblStatTotalTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatTotalTitle.ForeColor = System.Drawing.Color.White;
            this.lblStatTotalTitle.Location = new System.Drawing.Point(17, 6);
            this.lblStatTotalTitle.Name = "lblStatTotalTitle";
            this.lblStatTotalTitle.Size = new System.Drawing.Size(102, 24);
            this.lblStatTotalTitle.TabIndex = 0;
            this.lblStatTotalTitle.Text = "Total Flags";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(19, 184);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(64, 20);
            this.lblSearch.TabIndex = 9;
            this.lblSearch.Text = "Search:";
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSearch.Location = new System.Drawing.Point(23, 207);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(621, 32);
            this.tbSearch.TabIndex = 10;
            this.tbSearch.Tag = "Search by account number, customer name, flag type, or details...";
            this.tbSearch.Text = "Search by account number, customer name, flag type, or details...";
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_EnterLeave);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_EnterLeave);
            // 
            // btnFilterAll
            // 
            this.btnFilterAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFilterAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterAll.ForeColor = System.Drawing.Color.White;
            this.btnFilterAll.Location = new System.Drawing.Point(648, 206);
            this.btnFilterAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilterAll.Name = "btnFilterAll";
            this.btnFilterAll.Size = new System.Drawing.Size(73, 32);
            this.btnFilterAll.TabIndex = 11;
            this.btnFilterAll.Text = "All";
            this.btnFilterAll.UseVisualStyleBackColor = true;
            this.btnFilterAll.Click += new System.EventHandler(this.btnFilterAll_Click);
            // 
            // btnFilterOpen
            // 
            this.btnFilterOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFilterOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterOpen.ForeColor = System.Drawing.Color.White;
            this.btnFilterOpen.Location = new System.Drawing.Point(725, 206);
            this.btnFilterOpen.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilterOpen.Name = "btnFilterOpen";
            this.btnFilterOpen.Size = new System.Drawing.Size(95, 32);
            this.btnFilterOpen.TabIndex = 12;
            this.btnFilterOpen.Text = "Unresolved";
            this.btnFilterOpen.UseVisualStyleBackColor = true;
            this.btnFilterOpen.Click += new System.EventHandler(this.btnFilterOpen_Click);
            // 
            // btnFilterResolved
            // 
            this.btnFilterResolved.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFilterResolved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterResolved.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterResolved.ForeColor = System.Drawing.Color.White;
            this.btnFilterResolved.Location = new System.Drawing.Point(824, 206);
            this.btnFilterResolved.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilterResolved.Name = "btnFilterResolved";
            this.btnFilterResolved.Size = new System.Drawing.Size(95, 32);
            this.btnFilterResolved.TabIndex = 13;
            this.btnFilterResolved.Text = "Resolved";
            this.btnFilterResolved.UseVisualStyleBackColor = true;
            this.btnFilterResolved.Click += new System.EventHandler(this.btnFilterResolved_Click);
            // 
            // cbType
            // 
            this.cbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.ForeColor = System.Drawing.Color.White;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "All Types",
            "Rapid Transactions",
            "Large Withdrawal",
            "Failed Attempts",
            "Manual Review"});
            this.cbType.Location = new System.Drawing.Point(923, 206);
            this.cbType.Margin = new System.Windows.Forms.Padding(2);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(172, 32);
            this.cbType.TabIndex = 14;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.dgvFraudFlags);
            this.panelLeft.Controls.Add(this.panelLeftFooter);
            this.panelLeft.Location = new System.Drawing.Point(23, 246);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(818, 573);
            this.panelLeft.TabIndex = 15;
            // 
            // dgvFraudFlags
            // 
            this.dgvFraudFlags.AllowUserToAddRows = false;
            this.dgvFraudFlags.AllowUserToDeleteRows = false;
            this.dgvFraudFlags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFraudFlags.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvFraudFlags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFraudFlags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFlag,
            this.colDetails,
            this.colDate,
            this.colStatus});
            this.dgvFraudFlags.Location = new System.Drawing.Point(0, 0);
            this.dgvFraudFlags.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFraudFlags.MultiSelect = false;
            this.dgvFraudFlags.Name = "dgvFraudFlags";
            this.dgvFraudFlags.ReadOnly = true;
            this.dgvFraudFlags.RowHeadersVisible = false;
            this.dgvFraudFlags.RowHeadersWidth = 62;
            this.dgvFraudFlags.RowTemplate.Height = 28;
            this.dgvFraudFlags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFraudFlags.Size = new System.Drawing.Size(816, 524);
            this.dgvFraudFlags.TabIndex = 13;
            this.dgvFraudFlags.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFraudFlags_CellClick);
            // 
            // colFlag
            // 
            this.colFlag.HeaderText = "Flag";
            this.colFlag.Name = "colFlag";
            this.colFlag.ReadOnly = true;
            // 
            // colDetails
            // 
            this.colDetails.HeaderText = "Details";
            this.colDetails.Name = "colDetails";
            this.colDetails.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // panelLeftFooter
            // 
            this.panelLeftFooter.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelLeftFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftFooter.Controls.Add(this.lblLeftFooterHint);
            this.panelLeftFooter.Controls.Add(this.lblLeftFooterCount);
            this.panelLeftFooter.Location = new System.Drawing.Point(-1, 524);
            this.panelLeftFooter.Name = "panelLeftFooter";
            this.panelLeftFooter.Size = new System.Drawing.Size(818, 49);
            this.panelLeftFooter.TabIndex = 14;
            // 
            // lblLeftFooterHint
            // 
            this.lblLeftFooterHint.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblLeftFooterHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblLeftFooterHint.ForeColor = System.Drawing.Color.White;
            this.lblLeftFooterHint.Location = new System.Drawing.Point(410, 12);
            this.lblLeftFooterHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLeftFooterHint.Name = "lblLeftFooterHint";
            this.lblLeftFooterHint.Size = new System.Drawing.Size(391, 23);
            this.lblLeftFooterHint.TabIndex = 4;
            this.lblLeftFooterHint.Text = "Click a row to inspect full flag details";
            this.lblLeftFooterHint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLeftFooterCount
            // 
            this.lblLeftFooterCount.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblLeftFooterCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblLeftFooterCount.ForeColor = System.Drawing.Color.White;
            this.lblLeftFooterCount.Location = new System.Drawing.Point(12, 12);
            this.lblLeftFooterCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLeftFooterCount.Name = "lblLeftFooterCount";
            this.lblLeftFooterCount.Size = new System.Drawing.Size(397, 23);
            this.lblLeftFooterCount.TabIndex = 3;
            this.lblLeftFooterCount.Text = "Showing 0 of 0 fraud flags";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.btnResolveFlag);
            this.panelRight.Controls.Add(this.btnKeepOpen);
            this.panelRight.Controls.Add(this.btnViewAccount);
            this.panelRight.Controls.Add(this.tbResolutionNotes);
            this.panelRight.Controls.Add(this.lblResolutionNotes);
            this.panelRight.Controls.Add(this.tbRecentActivity);
            this.panelRight.Controls.Add(this.lblRecentActivity);
            this.panelRight.Controls.Add(this.tbDetails);
            this.panelRight.Controls.Add(this.lblDetails);
            this.panelRight.Controls.Add(this.tbAccountStatus);
            this.panelRight.Controls.Add(this.lblAccountStatusTitle);
            this.panelRight.Controls.Add(this.tbRisk);
            this.panelRight.Controls.Add(this.lblRiskTitle);
            this.panelRight.Controls.Add(this.tbDetectedBy);
            this.panelRight.Controls.Add(this.lblDetectedByTitle);
            this.panelRight.Controls.Add(this.tbFlaggedDate);
            this.panelRight.Controls.Add(this.lblFlaggedDateTitle);
            this.panelRight.Controls.Add(this.tbCustomer);
            this.panelRight.Controls.Add(this.lblCustomerTitle);
            this.panelRight.Controls.Add(this.tbAccount);
            this.panelRight.Controls.Add(this.lblAccountTitle);
            this.panelRight.Controls.Add(this.panelRightHeader);
            this.panelRight.Location = new System.Drawing.Point(852, 246);
            this.panelRight.Margin = new System.Windows.Forms.Padding(2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(451, 573);
            this.panelRight.TabIndex = 17;
            // 
            // btnResolveFlag
            // 
            this.btnResolveFlag.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnResolveFlag.Enabled = false;
            this.btnResolveFlag.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnResolveFlag.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnResolveFlag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnResolveFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResolveFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResolveFlag.ForeColor = System.Drawing.Color.White;
            this.btnResolveFlag.Image = global::SmartBank_UI.Properties.Resources.icons8_tick_24;
            this.btnResolveFlag.Location = new System.Drawing.Point(287, 515);
            this.btnResolveFlag.Margin = new System.Windows.Forms.Padding(2);
            this.btnResolveFlag.Name = "btnResolveFlag";
            this.btnResolveFlag.Size = new System.Drawing.Size(153, 45);
            this.btnResolveFlag.TabIndex = 95;
            this.btnResolveFlag.Text = "Resolve";
            this.btnResolveFlag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResolveFlag.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResolveFlag.UseVisualStyleBackColor = false;
            this.btnResolveFlag.Click += new System.EventHandler(this.btnResolveFlag_Click);
            // 
            // btnKeepOpen
            // 
            this.btnKeepOpen.Enabled = false;
            this.btnKeepOpen.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnKeepOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnKeepOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeepOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeepOpen.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnKeepOpen.Location = new System.Drawing.Point(161, 515);
            this.btnKeepOpen.Margin = new System.Windows.Forms.Padding(2);
            this.btnKeepOpen.Name = "btnKeepOpen";
            this.btnKeepOpen.Size = new System.Drawing.Size(122, 45);
            this.btnKeepOpen.TabIndex = 94;
            this.btnKeepOpen.Text = "Keep Open";
            this.btnKeepOpen.UseVisualStyleBackColor = true;
            this.btnKeepOpen.Click += new System.EventHandler(this.btnKeepOpen_Click);
            // 
            // btnViewAccount
            // 
            this.btnViewAccount.Enabled = false;
            this.btnViewAccount.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnViewAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAccount.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnViewAccount.Location = new System.Drawing.Point(12, 515);
            this.btnViewAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewAccount.Name = "btnViewAccount";
            this.btnViewAccount.Size = new System.Drawing.Size(145, 45);
            this.btnViewAccount.TabIndex = 93;
            this.btnViewAccount.Text = "View Account";
            this.btnViewAccount.UseVisualStyleBackColor = true;
            this.btnViewAccount.Click += new System.EventHandler(this.btnViewAccount_Click);
            // 
            // tbResolutionNotes
            // 
            this.tbResolutionNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbResolutionNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbResolutionNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbResolutionNotes.ForeColor = System.Drawing.Color.White;
            this.tbResolutionNotes.Location = new System.Drawing.Point(12, 445);
            this.tbResolutionNotes.Multiline = true;
            this.tbResolutionNotes.Name = "tbResolutionNotes";
            this.tbResolutionNotes.ReadOnly = true;
            this.tbResolutionNotes.Size = new System.Drawing.Size(428, 56);
            this.tbResolutionNotes.TabIndex = 92;
            this.tbResolutionNotes.Text = "No notes.";
            // 
            // lblResolutionNotes
            // 
            this.lblResolutionNotes.AutoSize = true;
            this.lblResolutionNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResolutionNotes.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblResolutionNotes.Location = new System.Drawing.Point(9, 425);
            this.lblResolutionNotes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResolutionNotes.Name = "lblResolutionNotes";
            this.lblResolutionNotes.Size = new System.Drawing.Size(161, 18);
            this.lblResolutionNotes.TabIndex = 91;
            this.lblResolutionNotes.Text = "RESOLUTION NOTES";
            // 
            // tbRecentActivity
            // 
            this.tbRecentActivity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbRecentActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRecentActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRecentActivity.ForeColor = System.Drawing.Color.White;
            this.tbRecentActivity.Location = new System.Drawing.Point(12, 347);
            this.tbRecentActivity.Multiline = true;
            this.tbRecentActivity.Name = "tbRecentActivity";
            this.tbRecentActivity.ReadOnly = true;
            this.tbRecentActivity.Size = new System.Drawing.Size(428, 69);
            this.tbRecentActivity.TabIndex = 90;
            this.tbRecentActivity.Text = "No recent activity.";
            // 
            // lblRecentActivity
            // 
            this.lblRecentActivity.AutoSize = true;
            this.lblRecentActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentActivity.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblRecentActivity.Location = new System.Drawing.Point(9, 326);
            this.lblRecentActivity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecentActivity.Name = "lblRecentActivity";
            this.lblRecentActivity.Size = new System.Drawing.Size(136, 18);
            this.lblRecentActivity.TabIndex = 89;
            this.lblRecentActivity.Text = "RECENT ACTIVITY";
            // 
            // tbDetails
            // 
            this.tbDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDetails.ForeColor = System.Drawing.Color.White;
            this.tbDetails.Location = new System.Drawing.Point(12, 245);
            this.tbDetails.Multiline = true;
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.ReadOnly = true;
            this.tbDetails.Size = new System.Drawing.Size(428, 69);
            this.tbDetails.TabIndex = 88;
            this.tbDetails.Text = "No details.";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblDetails.Location = new System.Drawing.Point(9, 224);
            this.lblDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(68, 18);
            this.lblDetails.TabIndex = 87;
            this.lblDetails.Text = "DETAILS";
            // 
            // tbAccountStatus
            // 
            this.tbAccountStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbAccountStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAccountStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAccountStatus.ForeColor = System.Drawing.Color.White;
            this.tbAccountStatus.Location = new System.Drawing.Point(231, 190);
            this.tbAccountStatus.Name = "tbAccountStatus";
            this.tbAccountStatus.ReadOnly = true;
            this.tbAccountStatus.Size = new System.Drawing.Size(209, 24);
            this.tbAccountStatus.TabIndex = 86;
            this.tbAccountStatus.Text = "N/A";
            this.tbAccountStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAccountStatusTitle
            // 
            this.lblAccountStatusTitle.AutoSize = true;
            this.lblAccountStatusTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountStatusTitle.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblAccountStatusTitle.Location = new System.Drawing.Point(228, 170);
            this.lblAccountStatusTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccountStatusTitle.Name = "lblAccountStatusTitle";
            this.lblAccountStatusTitle.Size = new System.Drawing.Size(144, 18);
            this.lblAccountStatusTitle.TabIndex = 85;
            this.lblAccountStatusTitle.Text = "ACCOUNT STATUS";
            // 
            // tbRisk
            // 
            this.tbRisk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbRisk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRisk.ForeColor = System.Drawing.Color.White;
            this.tbRisk.Location = new System.Drawing.Point(12, 190);
            this.tbRisk.Name = "tbRisk";
            this.tbRisk.ReadOnly = true;
            this.tbRisk.Size = new System.Drawing.Size(209, 24);
            this.tbRisk.TabIndex = 84;
            this.tbRisk.Text = "N/A";
            this.tbRisk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRiskTitle
            // 
            this.lblRiskTitle.AutoSize = true;
            this.lblRiskTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRiskTitle.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblRiskTitle.Location = new System.Drawing.Point(9, 170);
            this.lblRiskTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRiskTitle.Name = "lblRiskTitle";
            this.lblRiskTitle.Size = new System.Drawing.Size(91, 18);
            this.lblRiskTitle.TabIndex = 83;
            this.lblRiskTitle.Text = "RISK LEVEL";
            // 
            // tbDetectedBy
            // 
            this.tbDetectedBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbDetectedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDetectedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDetectedBy.ForeColor = System.Drawing.Color.White;
            this.tbDetectedBy.Location = new System.Drawing.Point(231, 140);
            this.tbDetectedBy.Name = "tbDetectedBy";
            this.tbDetectedBy.ReadOnly = true;
            this.tbDetectedBy.Size = new System.Drawing.Size(209, 24);
            this.tbDetectedBy.TabIndex = 82;
            this.tbDetectedBy.Text = "N/A";
            this.tbDetectedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDetectedByTitle
            // 
            this.lblDetectedByTitle.AutoSize = true;
            this.lblDetectedByTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetectedByTitle.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblDetectedByTitle.Location = new System.Drawing.Point(228, 120);
            this.lblDetectedByTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDetectedByTitle.Name = "lblDetectedByTitle";
            this.lblDetectedByTitle.Size = new System.Drawing.Size(112, 18);
            this.lblDetectedByTitle.TabIndex = 81;
            this.lblDetectedByTitle.Text = "DETECTED BY";
            // 
            // tbFlaggedDate
            // 
            this.tbFlaggedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbFlaggedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFlaggedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFlaggedDate.ForeColor = System.Drawing.Color.White;
            this.tbFlaggedDate.Location = new System.Drawing.Point(12, 140);
            this.tbFlaggedDate.Name = "tbFlaggedDate";
            this.tbFlaggedDate.ReadOnly = true;
            this.tbFlaggedDate.Size = new System.Drawing.Size(209, 24);
            this.tbFlaggedDate.TabIndex = 80;
            this.tbFlaggedDate.Text = "N/A";
            this.tbFlaggedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFlaggedDateTitle
            // 
            this.lblFlaggedDateTitle.AutoSize = true;
            this.lblFlaggedDateTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlaggedDateTitle.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblFlaggedDateTitle.Location = new System.Drawing.Point(9, 120);
            this.lblFlaggedDateTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFlaggedDateTitle.Name = "lblFlaggedDateTitle";
            this.lblFlaggedDateTitle.Size = new System.Drawing.Size(122, 18);
            this.lblFlaggedDateTitle.TabIndex = 79;
            this.lblFlaggedDateTitle.Text = "FLAGGED DATE";
            // 
            // tbCustomer
            // 
            this.tbCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomer.ForeColor = System.Drawing.Color.White;
            this.tbCustomer.Location = new System.Drawing.Point(231, 90);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.ReadOnly = true;
            this.tbCustomer.Size = new System.Drawing.Size(209, 24);
            this.tbCustomer.TabIndex = 78;
            this.tbCustomer.Text = "N/A";
            this.tbCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCustomerTitle
            // 
            this.lblCustomerTitle.AutoSize = true;
            this.lblCustomerTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerTitle.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCustomerTitle.Location = new System.Drawing.Point(228, 70);
            this.lblCustomerTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerTitle.Name = "lblCustomerTitle";
            this.lblCustomerTitle.Size = new System.Drawing.Size(95, 18);
            this.lblCustomerTitle.TabIndex = 77;
            this.lblCustomerTitle.Text = "CUSTOMER";
            // 
            // tbAccount
            // 
            this.tbAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAccount.ForeColor = System.Drawing.Color.White;
            this.tbAccount.Location = new System.Drawing.Point(12, 90);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.ReadOnly = true;
            this.tbAccount.Size = new System.Drawing.Size(209, 24);
            this.tbAccount.TabIndex = 76;
            this.tbAccount.Text = "N/A";
            this.tbAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAccountTitle
            // 
            this.lblAccountTitle.AutoSize = true;
            this.lblAccountTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountTitle.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblAccountTitle.Location = new System.Drawing.Point(9, 70);
            this.lblAccountTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccountTitle.Name = "lblAccountTitle";
            this.lblAccountTitle.Size = new System.Drawing.Size(82, 18);
            this.lblAccountTitle.TabIndex = 75;
            this.lblAccountTitle.Text = "ACCOUNT";
            // 
            // panelRightHeader
            // 
            this.panelRightHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelRightHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRightHeader.Controls.Add(this.lblRightSub);
            this.panelRightHeader.Controls.Add(this.lblRightTitle);
            this.panelRightHeader.Location = new System.Drawing.Point(-1, -1);
            this.panelRightHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelRightHeader.Name = "panelRightHeader";
            this.panelRightHeader.Size = new System.Drawing.Size(451, 62);
            this.panelRightHeader.TabIndex = 0;
            // 
            // lblRightSub
            // 
            this.lblRightSub.AutoSize = true;
            this.lblRightSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightSub.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblRightSub.Location = new System.Drawing.Point(18, 36);
            this.lblRightSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRightSub.Name = "lblRightSub";
            this.lblRightSub.Size = new System.Drawing.Size(114, 18);
            this.lblRightSub.TabIndex = 2;
            this.lblRightSub.Text = "No flag selected";
            // 
            // lblRightTitle
            // 
            this.lblRightTitle.AutoSize = true;
            this.lblRightTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightTitle.ForeColor = System.Drawing.Color.White;
            this.lblRightTitle.Location = new System.Drawing.Point(18, 10);
            this.lblRightTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRightTitle.Name = "lblRightTitle";
            this.lblRightTitle.Size = new System.Drawing.Size(107, 24);
            this.lblRightTitle.TabIndex = 1;
            this.lblRightTitle.Text = "Flag Details";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "FraudFlags_Export.csv";
            this.saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAccountToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // viewAccountToolStripMenuItem
            // 
            this.viewAccountToolStripMenuItem.Name = "viewAccountToolStripMenuItem";
            this.viewAccountToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewAccountToolStripMenuItem.Text = "View Account";
            // 
            // ctrlFraudFlagsMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.btnFilterResolved);
            this.Controls.Add(this.btnFilterOpen);
            this.Controls.Add(this.btnFilterAll);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.panelStatTotal);
            this.Controls.Add(this.panelStatResolved);
            this.Controls.Add(this.panelStatHighRisk);
            this.Controls.Add(this.panelStatOpen);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "ctrlFraudFlagsMainScreen";
            this.Size = new System.Drawing.Size(1331, 833);
            this.Load += new System.EventHandler(this.ctrlFraudFlagsMainScreen_Load);
            this.VisibleChanged += new System.EventHandler(this.ctrlFraudFlagsMainScreen_VisibleChanged);
            this.panelStatOpen.ResumeLayout(false);
            this.panelStatOpen.PerformLayout();
            this.panelStatHighRisk.ResumeLayout(false);
            this.panelStatHighRisk.PerformLayout();
            this.panelStatResolved.ResumeLayout(false);
            this.panelStatResolved.PerformLayout();
            this.panelStatTotal.ResumeLayout(false);
            this.panelStatTotal.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFraudFlags)).EndInit();
            this.panelLeftFooter.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelRightHeader.ResumeLayout(false);
            this.panelRightHeader.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panelStatOpen;
        private System.Windows.Forms.Label lblStatOpenSub;
        private System.Windows.Forms.Label lblStatOpenValue;
        private System.Windows.Forms.Label lblStatOpenTitle;
        private System.Windows.Forms.Panel panelStatHighRisk;
        private System.Windows.Forms.Label lblStatHighRiskSub;
        private System.Windows.Forms.Label lblStatHighRiskValue;
        private System.Windows.Forms.Label lblStatHighRiskTitle;
        private System.Windows.Forms.Panel panelStatResolved;
        private System.Windows.Forms.Label lblStatResolvedSub;
        private System.Windows.Forms.Label lblStatResolvedValue;
        private System.Windows.Forms.Label lblStatResolvedTitle;
        private System.Windows.Forms.Panel panelStatTotal;
        private System.Windows.Forms.Label lblStatTotalSub;
        private System.Windows.Forms.Label lblStatTotalValue;
        private System.Windows.Forms.Label lblStatTotalTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnFilterAll;
        private System.Windows.Forms.Button btnFilterOpen;
        private System.Windows.Forms.Button btnFilterResolved;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.DataGridView dgvFraudFlags;
        private System.Windows.Forms.Panel panelLeftFooter;
        private System.Windows.Forms.Label lblLeftFooterHint;
        private System.Windows.Forms.Label lblLeftFooterCount;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnResolveFlag;
        private System.Windows.Forms.Button btnKeepOpen;
        private System.Windows.Forms.Button btnViewAccount;
        private System.Windows.Forms.TextBox tbResolutionNotes;
        private System.Windows.Forms.Label lblResolutionNotes;
        private System.Windows.Forms.TextBox tbRecentActivity;
        private System.Windows.Forms.Label lblRecentActivity;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.TextBox tbAccountStatus;
        private System.Windows.Forms.Label lblAccountStatusTitle;
        private System.Windows.Forms.TextBox tbRisk;
        private System.Windows.Forms.Label lblRiskTitle;
        private System.Windows.Forms.TextBox tbDetectedBy;
        private System.Windows.Forms.Label lblDetectedByTitle;
        private System.Windows.Forms.TextBox tbFlaggedDate;
        private System.Windows.Forms.Label lblFlaggedDateTitle;
        private System.Windows.Forms.TextBox tbCustomer;
        private System.Windows.Forms.Label lblCustomerTitle;
        private System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.Label lblAccountTitle;
        private System.Windows.Forms.Panel panelRightHeader;
        private System.Windows.Forms.Label lblRightSub;
        private System.Windows.Forms.Label lblRightTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewAccountToolStripMenuItem;
    }
}
