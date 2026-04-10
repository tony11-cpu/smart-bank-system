namespace SmartBank_UI.Main_Form_UC
{
    partial class ctrlAccounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblInforamtionAboutForm = new System.Windows.Forms.Label();
            this.lblAddOrUpdate = new System.Windows.Forms.Label();
            this.btnActiveFilter = new System.Windows.Forms.Button();
            this.btnFrozenFilter = new System.Windows.Forms.Button();
            this.btnAllFilter = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblOpenByUsername = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblOpenDate = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCustomerAccountFullName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMinimunBalance = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblSavingsOrChecking = new System.Windows.Forms.Label();
            this.pbAccountTypePhoto = new System.Windows.Forms.PictureBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearchBar = new System.Windows.Forms.TextBox();
            this.btnClosedAccountsFilter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClickToShowRow = new System.Windows.Forms.Label();
            this.lblNumberOfAccounts = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvAccountRecentTransactions = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnOpenAccount = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccountTypePhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountRecentTransactions)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInforamtionAboutForm
            // 
            this.lblInforamtionAboutForm.AutoSize = true;
            this.lblInforamtionAboutForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInforamtionAboutForm.ForeColor = System.Drawing.Color.DarkGray;
            this.lblInforamtionAboutForm.Location = new System.Drawing.Point(23, 51);
            this.lblInforamtionAboutForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInforamtionAboutForm.Name = "lblInforamtionAboutForm";
            this.lblInforamtionAboutForm.Size = new System.Drawing.Size(373, 18);
            this.lblInforamtionAboutForm.TabIndex = 16;
            this.lblInforamtionAboutForm.Text = "View, open, freeze, and close customer bank accounts.";
            // 
            // lblAddOrUpdate
            // 
            this.lblAddOrUpdate.AutoSize = true;
            this.lblAddOrUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddOrUpdate.ForeColor = System.Drawing.Color.White;
            this.lblAddOrUpdate.Location = new System.Drawing.Point(21, 22);
            this.lblAddOrUpdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddOrUpdate.Name = "lblAddOrUpdate";
            this.lblAddOrUpdate.Size = new System.Drawing.Size(110, 29);
            this.lblAddOrUpdate.TabIndex = 15;
            this.lblAddOrUpdate.Text = "Accounts";
            // 
            // btnActiveFilter
            // 
            this.btnActiveFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnActiveFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActiveFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveFilter.ForeColor = System.Drawing.Color.White;
            this.btnActiveFilter.Location = new System.Drawing.Point(1026, 116);
            this.btnActiveFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnActiveFilter.Name = "btnActiveFilter";
            this.btnActiveFilter.Size = new System.Drawing.Size(95, 32);
            this.btnActiveFilter.TabIndex = 53;
            this.btnActiveFilter.Text = "Active";
            this.btnActiveFilter.UseVisualStyleBackColor = true;
            this.btnActiveFilter.Click += new System.EventHandler(this.btnActiveFilter_Click);
            // 
            // btnFrozenFilter
            // 
            this.btnFrozenFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrozenFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrozenFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFrozenFilter.ForeColor = System.Drawing.Color.White;
            this.btnFrozenFilter.Location = new System.Drawing.Point(1125, 116);
            this.btnFrozenFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnFrozenFilter.Name = "btnFrozenFilter";
            this.btnFrozenFilter.Size = new System.Drawing.Size(95, 32);
            this.btnFrozenFilter.TabIndex = 52;
            this.btnFrozenFilter.Text = "Frozen";
            this.btnFrozenFilter.UseVisualStyleBackColor = true;
            this.btnFrozenFilter.Click += new System.EventHandler(this.btnFrozenFilter_Click);
            // 
            // btnAllFilter
            // 
            this.btnAllFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAllFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllFilter.ForeColor = System.Drawing.Color.White;
            this.btnAllFilter.Location = new System.Drawing.Point(949, 116);
            this.btnAllFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnAllFilter.Name = "btnAllFilter";
            this.btnAllFilter.Size = new System.Drawing.Size(73, 32);
            this.btnAllFilter.TabIndex = 42;
            this.btnAllFilter.Text = "All";
            this.btnAllFilter.UseVisualStyleBackColor = true;
            this.btnAllFilter.Click += new System.EventHandler(this.btnAllFilter_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel4.Controls.Add(this.lblOpenByUsername);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.lblOpenDate);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.lblAccountType);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.lblCustomerAccountFullName);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Location = new System.Drawing.Point(840, 153);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(479, 378);
            this.panel4.TabIndex = 49;
            // 
            // lblOpenByUsername
            // 
            this.lblOpenByUsername.AutoSize = true;
            this.lblOpenByUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenByUsername.ForeColor = System.Drawing.Color.White;
            this.lblOpenByUsername.Location = new System.Drawing.Point(21, 334);
            this.lblOpenByUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOpenByUsername.Name = "lblOpenByUsername";
            this.lblOpenByUsername.Size = new System.Drawing.Size(288, 24);
            this.lblOpenByUsername.TabIndex = 64;
            this.lblOpenByUsername.Text = "Username Opened This Account";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label16.Location = new System.Drawing.Point(22, 316);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 18);
            this.label16.TabIndex = 65;
            this.label16.Text = "Opened By:";
            // 
            // lblOpenDate
            // 
            this.lblOpenDate.AutoSize = true;
            this.lblOpenDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenDate.ForeColor = System.Drawing.Color.White;
            this.lblOpenDate.Location = new System.Drawing.Point(21, 282);
            this.lblOpenDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOpenDate.Name = "lblOpenDate";
            this.lblOpenDate.Size = new System.Drawing.Size(136, 24);
            this.lblOpenDate.TabIndex = 62;
            this.lblOpenDate.Text = "Month dd, yyyy";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label14.Location = new System.Drawing.Point(22, 264);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 18);
            this.label14.TabIndex = 63;
            this.label14.Text = "Opened Date:";
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountType.ForeColor = System.Drawing.Color.White;
            this.lblAccountType.Location = new System.Drawing.Point(22, 232);
            this.lblAccountType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(128, 24);
            this.lblAccountType.TabIndex = 60;
            this.lblAccountType.Text = "Account Type";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label11.Location = new System.Drawing.Point(22, 212);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 18);
            this.label11.TabIndex = 61;
            this.label11.Text = "Account Type:";
            // 
            // lblCustomerAccountFullName
            // 
            this.lblCustomerAccountFullName.AutoSize = true;
            this.lblCustomerAccountFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerAccountFullName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerAccountFullName.Location = new System.Drawing.Point(22, 178);
            this.lblCustomerAccountFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerAccountFullName.Name = "lblCustomerAccountFullName";
            this.lblCustomerAccountFullName.Size = new System.Drawing.Size(183, 24);
            this.lblCustomerAccountFullName.TabIndex = 23;
            this.lblCustomerAccountFullName.Text = "Customer Full Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label8.Location = new System.Drawing.Point(23, 160);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 18);
            this.label8.TabIndex = 27;
            this.label8.Text = "Account Owner:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblMinimunBalance);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblCurrentBalance);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(6, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 68);
            this.panel2.TabIndex = 59;
            // 
            // lblMinimunBalance
            // 
            this.lblMinimunBalance.AutoSize = true;
            this.lblMinimunBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimunBalance.ForeColor = System.Drawing.Color.Peru;
            this.lblMinimunBalance.Location = new System.Drawing.Point(326, 29);
            this.lblMinimunBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinimunBalance.Name = "lblMinimunBalance";
            this.lblMinimunBalance.Size = new System.Drawing.Size(84, 29);
            this.lblMinimunBalance.TabIndex = 26;
            this.lblMinimunBalance.Text = "$00.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(328, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 18);
            this.label7.TabIndex = 25;
            this.label7.Text = "Minimum Balance";
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.AutoSize = true;
            this.lblCurrentBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCurrentBalance.Location = new System.Drawing.Point(14, 29);
            this.lblCurrentBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(84, 29);
            this.lblCurrentBalance.TabIndex = 24;
            this.lblCurrentBalance.Text = "$00.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(15, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 18);
            this.label4.TabIndex = 23;
            this.label4.Text = "Current Balance";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lblSavingsOrChecking);
            this.panel6.Controls.Add(this.pbAccountTypePhoto);
            this.panel6.Controls.Add(this.lblAccountName);
            this.panel6.Location = new System.Drawing.Point(2, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(472, 71);
            this.panel6.TabIndex = 18;
            // 
            // lblSavingsOrChecking
            // 
            this.lblSavingsOrChecking.AutoSize = true;
            this.lblSavingsOrChecking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavingsOrChecking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblSavingsOrChecking.Location = new System.Drawing.Point(125, 41);
            this.lblSavingsOrChecking.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSavingsOrChecking.Name = "lblSavingsOrChecking";
            this.lblSavingsOrChecking.Size = new System.Drawing.Size(57, 20);
            this.lblSavingsOrChecking.TabIndex = 22;
            this.lblSavingsOrChecking.Text = "Saving";
            // 
            // pbAccountTypePhoto
            // 
            this.pbAccountTypePhoto.Image = global::SmartBank_UI.Properties.Resources.icons8_wallet_64;
            this.pbAccountTypePhoto.Location = new System.Drawing.Point(3, 3);
            this.pbAccountTypePhoto.Name = "pbAccountTypePhoto";
            this.pbAccountTypePhoto.Size = new System.Drawing.Size(107, 63);
            this.pbAccountTypePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAccountTypePhoto.TabIndex = 20;
            this.pbAccountTypePhoto.TabStop = false;
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.ForeColor = System.Drawing.Color.White;
            this.lblAccountName.Location = new System.Drawing.Point(125, 13);
            this.lblAccountName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(136, 24);
            this.lblAccountName.TabIndex = 21;
            this.lblAccountName.Text = "SB-2024-00142";
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.AllowUserToDeleteRows = false;
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccounts.BackgroundColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccounts.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAccounts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAccounts.Location = new System.Drawing.Point(15, 153);
            this.dgvAccounts.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAccounts.MultiSelect = false;
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAccounts.RowHeadersWidth = 62;
            this.dgvAccounts.RowTemplate.Height = 28;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(820, 611);
            this.dgvAccounts.TabIndex = 45;
            this.dgvAccounts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccounts_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Search:";
            // 
            // tbSearchBar
            // 
            this.tbSearchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSearchBar.Location = new System.Drawing.Point(15, 116);
            this.tbSearchBar.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearchBar.Name = "tbSearchBar";
            this.tbSearchBar.Size = new System.Drawing.Size(930, 32);
            this.tbSearchBar.TabIndex = 43;
            this.tbSearchBar.Tag = "search by account number, customer name, balance, or account type...";
            this.tbSearchBar.Text = "search by account number, customer name, balance, or account type...";
            this.tbSearchBar.TextChanged += new System.EventHandler(this.tbSearchBar_TextChanged);
            this.tbSearchBar.Enter += new System.EventHandler(this.tbSearchBar_EnterLeave);
            this.tbSearchBar.Leave += new System.EventHandler(this.tbSearchBar_EnterLeave);
            // 
            // btnClosedAccountsFilter
            // 
            this.btnClosedAccountsFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClosedAccountsFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosedAccountsFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClosedAccountsFilter.ForeColor = System.Drawing.Color.White;
            this.btnClosedAccountsFilter.Location = new System.Drawing.Point(1224, 116);
            this.btnClosedAccountsFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnClosedAccountsFilter.Name = "btnClosedAccountsFilter";
            this.btnClosedAccountsFilter.Size = new System.Drawing.Size(95, 32);
            this.btnClosedAccountsFilter.TabIndex = 54;
            this.btnClosedAccountsFilter.Text = "Closed";
            this.btnClosedAccountsFilter.UseVisualStyleBackColor = true;
            this.btnClosedAccountsFilter.Click += new System.EventHandler(this.btnClosedAccountsFilter_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblClickToShowRow);
            this.panel1.Controls.Add(this.lblNumberOfAccounts);
            this.panel1.Location = new System.Drawing.Point(15, 769);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 44);
            this.panel1.TabIndex = 56;
            // 
            // lblClickToShowRow
            // 
            this.lblClickToShowRow.AutoSize = true;
            this.lblClickToShowRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClickToShowRow.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblClickToShowRow.Location = new System.Drawing.Point(629, 12);
            this.lblClickToShowRow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClickToShowRow.Name = "lblClickToShowRow";
            this.lblClickToShowRow.Size = new System.Drawing.Size(178, 18);
            this.lblClickToShowRow.TabIndex = 58;
            this.lblClickToShowRow.Text = "Click a row to view details";
            this.lblClickToShowRow.Visible = false;
            // 
            // lblNumberOfAccounts
            // 
            this.lblNumberOfAccounts.AutoSize = true;
            this.lblNumberOfAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfAccounts.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblNumberOfAccounts.Location = new System.Drawing.Point(7, 12);
            this.lblNumberOfAccounts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumberOfAccounts.Name = "lblNumberOfAccounts";
            this.lblNumberOfAccounts.Size = new System.Drawing.Size(199, 18);
            this.lblNumberOfAccounts.TabIndex = 57;
            this.lblNumberOfAccounts.Text = "Showing 6 of 2,847 accounts";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel5.Controls.Add(this.dgvAccountRecentTransactions);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Location = new System.Drawing.Point(840, 537);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(481, 276);
            this.panel5.TabIndex = 58;
            // 
            // dgvAccountRecentTransactions
            // 
            this.dgvAccountRecentTransactions.AllowUserToAddRows = false;
            this.dgvAccountRecentTransactions.AllowUserToDeleteRows = false;
            this.dgvAccountRecentTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccountRecentTransactions.BackgroundColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccountRecentTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAccountRecentTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAccountRecentTransactions.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAccountRecentTransactions.Location = new System.Drawing.Point(2, 51);
            this.dgvAccountRecentTransactions.Name = "dgvAccountRecentTransactions";
            this.dgvAccountRecentTransactions.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccountRecentTransactions.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAccountRecentTransactions.RowTemplate.Height = 28;
            this.dgvAccountRecentTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccountRecentTransactions.Size = new System.Drawing.Size(474, 222);
            this.dgvAccountRecentTransactions.TabIndex = 21;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label12);
            this.panel7.Location = new System.Drawing.Point(2, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(477, 43);
            this.panel7.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(156, 12);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(156, 20);
            this.label12.TabIndex = 20;
            this.label12.Text = "Recent Transactions";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Accounts_Export.csv";
            this.saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            // 
            // btnExport
            // 
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.Image = global::SmartBank_UI.Properties.Resources.icons8_export_48;
            this.btnExport.Location = new System.Drawing.Point(1056, 58);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 54);
            this.btnExport.TabIndex = 55;
            this.btnExport.Text = "Export";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnOpenAccount
            // 
            this.btnOpenAccount.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnOpenAccount.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOpenAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnOpenAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnOpenAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenAccount.ForeColor = System.Drawing.Color.White;
            this.btnOpenAccount.Image = global::SmartBank_UI.Properties.Resources.icons8_plus_24;
            this.btnOpenAccount.Location = new System.Drawing.Point(1155, 58);
            this.btnOpenAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenAccount.Name = "btnOpenAccount";
            this.btnOpenAccount.Size = new System.Drawing.Size(164, 54);
            this.btnOpenAccount.TabIndex = 51;
            this.btnOpenAccount.Text = "Open Account";
            this.btnOpenAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenAccount.UseVisualStyleBackColor = false;
            this.btnOpenAccount.Click += new System.EventHandler(this.OpenAccount_Click);
            // 
            // ctrlAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClosedAccountsFilter);
            this.Controls.Add(this.btnActiveFilter);
            this.Controls.Add(this.btnFrozenFilter);
            this.Controls.Add(this.btnAllFilter);
            this.Controls.Add(this.btnOpenAccount);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dgvAccounts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSearchBar);
            this.Controls.Add(this.lblInforamtionAboutForm);
            this.Controls.Add(this.lblAddOrUpdate);
            this.Name = "ctrlAccounts";
            this.Size = new System.Drawing.Size(1330, 828);
            this.Load += new System.EventHandler(this.ctrlAccounts_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccountTypePhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountRecentTransactions)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInforamtionAboutForm;
        private System.Windows.Forms.Label lblAddOrUpdate;
        private System.Windows.Forms.Button btnActiveFilter;
        private System.Windows.Forms.Button btnFrozenFilter;
        private System.Windows.Forms.Button btnAllFilter;
        private System.Windows.Forms.Button btnOpenAccount;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSearchBar;
        private System.Windows.Forms.Button btnClosedAccountsFilter;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblClickToShowRow;
        private System.Windows.Forms.Label lblNumberOfAccounts;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvAccountRecentTransactions;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pbAccountTypePhoto;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Label lblSavingsOrChecking;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOpenByUsername;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblOpenDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCustomerAccountFullName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMinimunBalance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
