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
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openNewAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.unfreezeAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freezeAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.depositeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withdrawalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ctrlAccountShortInfo1 = new SmartBank_UI.Accounts.Accounts_User_Controls.ctrlAccountShortInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.dgvAccounts.RowHeadersVisible = false;
            this.dgvAccounts.RowHeadersWidth = 62;
            this.dgvAccounts.RowTemplate.Height = 28;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(820, 611);
            this.dgvAccounts.TabIndex = 45;
            this.dgvAccounts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccounts_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openNewAccountToolStripMenuItem,
            this.updateAccountToolStripMenuItem,
            this.toolStripMenuItem1,
            this.unfreezeAccountToolStripMenuItem,
            this.freezeAccountToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.depositeToolStripMenuItem,
            this.withdrawalToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 226);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening_1);
            // 
            // openNewAccountToolStripMenuItem
            // 
            this.openNewAccountToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_user_50;
            this.openNewAccountToolStripMenuItem.Name = "openNewAccountToolStripMenuItem";
            this.openNewAccountToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.openNewAccountToolStripMenuItem.Text = "Open New Account";
            this.openNewAccountToolStripMenuItem.Click += new System.EventHandler(this.OpenAccount_Click);
            // 
            // updateAccountToolStripMenuItem
            // 
            this.updateAccountToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_update_user_48;
            this.updateAccountToolStripMenuItem.Name = "updateAccountToolStripMenuItem";
            this.updateAccountToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.updateAccountToolStripMenuItem.Text = "Update Account";
            this.updateAccountToolStripMenuItem.Click += new System.EventHandler(this.updateAccount_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // unfreezeAccountToolStripMenuItem
            // 
            this.unfreezeAccountToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_unlocked_48;
            this.unfreezeAccountToolStripMenuItem.Name = "unfreezeAccountToolStripMenuItem";
            this.unfreezeAccountToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.unfreezeAccountToolStripMenuItem.Text = "Unfreeze Account";
            this.unfreezeAccountToolStripMenuItem.Click += new System.EventHandler(this.unfreezeAccountToolStripMenuItem_Click);
            // 
            // freezeAccountToolStripMenuItem
            // 
            this.freezeAccountToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_user_locked_48;
            this.freezeAccountToolStripMenuItem.Name = "freezeAccountToolStripMenuItem";
            this.freezeAccountToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.freezeAccountToolStripMenuItem.Text = "Freeze Account";
            this.freezeAccountToolStripMenuItem.Click += new System.EventHandler(this.freezeAccountToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_close_40;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(183, 6);
            // 
            // depositeToolStripMenuItem
            // 
            this.depositeToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_money_box_50;
            this.depositeToolStripMenuItem.Name = "depositeToolStripMenuItem";
            this.depositeToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.depositeToolStripMenuItem.Text = "Deposite";
            // 
            // withdrawalToolStripMenuItem
            // 
            this.withdrawalToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_initiate_money_transfer_50;
            this.withdrawalToolStripMenuItem.Name = "withdrawalToolStripMenuItem";
            this.withdrawalToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.withdrawalToolStripMenuItem.Text = "Withdrawal";
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
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
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
            this.lblClickToShowRow.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblClickToShowRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblClickToShowRow.ForeColor = System.Drawing.Color.White;
            this.lblClickToShowRow.Location = new System.Drawing.Point(585, 10);
            this.lblClickToShowRow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClickToShowRow.Name = "lblClickToShowRow";
            this.lblClickToShowRow.Size = new System.Drawing.Size(222, 24);
            this.lblClickToShowRow.TabIndex = 58;
            this.lblClickToShowRow.Text = "Click a row to view details";
            this.lblClickToShowRow.Visible = false;
            // 
            // lblNumberOfAccounts
            // 
            this.lblNumberOfAccounts.AutoSize = true;
            this.lblNumberOfAccounts.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblNumberOfAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblNumberOfAccounts.ForeColor = System.Drawing.Color.White;
            this.lblNumberOfAccounts.Location = new System.Drawing.Point(15, 10);
            this.lblNumberOfAccounts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumberOfAccounts.Name = "lblNumberOfAccounts";
            this.lblNumberOfAccounts.Size = new System.Drawing.Size(250, 24);
            this.lblNumberOfAccounts.TabIndex = 57;
            this.lblNumberOfAccounts.Text = "Showing 6 of 2,847 accounts";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvAccountRecentTransactions);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Location = new System.Drawing.Point(842, 537);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(473, 277);
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
            this.dgvAccountRecentTransactions.Location = new System.Drawing.Point(2, 48);
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
            this.dgvAccountRecentTransactions.RowHeadersVisible = false;
            this.dgvAccountRecentTransactions.RowHeadersWidth = 62;
            this.dgvAccountRecentTransactions.RowTemplate.Height = 28;
            this.dgvAccountRecentTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccountRecentTransactions.Size = new System.Drawing.Size(474, 225);
            this.dgvAccountRecentTransactions.TabIndex = 21;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label12);
            this.panel7.Location = new System.Drawing.Point(-1, -1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(473, 43);
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
            // ctrlAccountShortInfo1
            // 
            this.ctrlAccountShortInfo1.BackColor = System.Drawing.Color.MidnightBlue;
            this.ctrlAccountShortInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAccountShortInfo1.Location = new System.Drawing.Point(842, 153);
            this.ctrlAccountShortInfo1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlAccountShortInfo1.Name = "ctrlAccountShortInfo1";
            this.ctrlAccountShortInfo1.Size = new System.Drawing.Size(473, 380);
            this.ctrlAccountShortInfo1.TabIndex = 59;
            // 
            // ctrlAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.ctrlAccountShortInfo1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClosedAccountsFilter);
            this.Controls.Add(this.btnActiveFilter);
            this.Controls.Add(this.btnFrozenFilter);
            this.Controls.Add(this.btnAllFilter);
            this.Controls.Add(this.btnOpenAccount);
            this.Controls.Add(this.dgvAccounts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSearchBar);
            this.Controls.Add(this.lblInforamtionAboutForm);
            this.Controls.Add(this.lblAddOrUpdate);
            this.Name = "ctrlAccounts";
            this.Size = new System.Drawing.Size(1330, 828);
            this.Load += new System.EventHandler(this.ctrlAccounts_Load);
            this.VisibleChanged += new System.EventHandler(this.ctrlAccounts_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openNewAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem unfreezeAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freezeAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem depositeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withdrawalToolStripMenuItem;
        private Accounts.Accounts_User_Controls.ctrlAccountShortInfo ctrlAccountShortInfo1;
    }
}
