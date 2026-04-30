namespace SmartBank_UI.Transaction.Transactions_User_Controls
{
    partial class ctrlTransactionsMainScreen
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
            this.lblTransactionsFormInfoToUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAllTransactions = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClickToShowRow = new System.Windows.Forms.Label();
            this.lblNumberOfTransactions = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTransactionDate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbUserProccessedTheTransaction = new System.Windows.Forms.TextBox();
            this.nupBalanceAfter = new System.Windows.Forms.NumericUpDown();
            this.nupBalanceBefore = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTransactionlStatus = new System.Windows.Forms.Label();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.btnSchedualedFillter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearchBar = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnNewTransactions = new System.Windows.Forms.Button();
            this.pbAccountTypePhoto = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsNewDeposite = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNewWithdrawl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsNewTransfare = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAccountTransactionsLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsCustomerInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlAccountShortInfo1 = new SmartBank_UI.Accounts.Accounts_User_Controls.ctrlAccountShortInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTransactions)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupBalanceAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupBalanceBefore)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccountTypePhoto)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTransactionsFormInfoToUser
            // 
            this.lblTransactionsFormInfoToUser.AutoSize = true;
            this.lblTransactionsFormInfoToUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionsFormInfoToUser.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTransactionsFormInfoToUser.Location = new System.Drawing.Point(25, 43);
            this.lblTransactionsFormInfoToUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTransactionsFormInfoToUser.Name = "lblTransactionsFormInfoToUser";
            this.lblTransactionsFormInfoToUser.Size = new System.Drawing.Size(646, 18);
            this.lblTransactionsFormInfoToUser.TabIndex = 12;
            this.lblTransactionsFormInfoToUser.Text = "Process deposits, withdrawals, and transfers. Every transaction is permanent and " +
    "recorded in full.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "Transactions";
            // 
            // dgvAllTransactions
            // 
            this.dgvAllTransactions.AllowUserToAddRows = false;
            this.dgvAllTransactions.AllowUserToDeleteRows = false;
            this.dgvAllTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllTransactions.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvAllTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllTransactions.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAllTransactions.Location = new System.Drawing.Point(10, 160);
            this.dgvAllTransactions.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAllTransactions.MultiSelect = false;
            this.dgvAllTransactions.Name = "dgvAllTransactions";
            this.dgvAllTransactions.ReadOnly = true;
            this.dgvAllTransactions.RowHeadersVisible = false;
            this.dgvAllTransactions.RowHeadersWidth = 62;
            this.dgvAllTransactions.RowTemplate.Height = 28;
            this.dgvAllTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllTransactions.Size = new System.Drawing.Size(818, 599);
            this.dgvAllTransactions.TabIndex = 13;
            this.dgvAllTransactions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllTransactions_CellClick_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblClickToShowRow);
            this.panel1.Controls.Add(this.lblNumberOfTransactions);
            this.panel1.Location = new System.Drawing.Point(10, 764);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 57);
            this.panel1.TabIndex = 57;
            // 
            // lblClickToShowRow
            // 
            this.lblClickToShowRow.AutoSize = true;
            this.lblClickToShowRow.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblClickToShowRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClickToShowRow.ForeColor = System.Drawing.Color.White;
            this.lblClickToShowRow.Location = new System.Drawing.Point(581, 16);
            this.lblClickToShowRow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClickToShowRow.Name = "lblClickToShowRow";
            this.lblClickToShowRow.Size = new System.Drawing.Size(222, 24);
            this.lblClickToShowRow.TabIndex = 58;
            this.lblClickToShowRow.Text = "Click a row to view details";
            this.lblClickToShowRow.Visible = false;
            // 
            // lblNumberOfTransactions
            // 
            this.lblNumberOfTransactions.AutoSize = true;
            this.lblNumberOfTransactions.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblNumberOfTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfTransactions.ForeColor = System.Drawing.Color.White;
            this.lblNumberOfTransactions.Location = new System.Drawing.Point(13, 16);
            this.lblNumberOfTransactions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumberOfTransactions.Name = "lblNumberOfTransactions";
            this.lblNumberOfTransactions.Size = new System.Drawing.Size(194, 24);
            this.lblNumberOfTransactions.TabIndex = 57;
            this.lblNumberOfTransactions.Text = "Showing 0 transaction";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbDescription);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbTransactionDate);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.tbUserProccessedTheTransaction);
            this.panel2.Controls.Add(this.nupBalanceAfter);
            this.panel2.Controls.Add(this.nupBalanceBefore);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(837, 536);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 285);
            this.panel2.TabIndex = 62;
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescription.ForeColor = System.Drawing.Color.White;
            this.tbDescription.Location = new System.Drawing.Point(185, 206);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.Size = new System.Drawing.Size(264, 26);
            this.tbDescription.TabIndex = 93;
            this.tbDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(53, 206);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 26);
            this.label3.TabIndex = 92;
            this.label3.Text = "Description:";
            // 
            // tbTransactionDate
            // 
            this.tbTransactionDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbTransactionDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTransactionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTransactionDate.ForeColor = System.Drawing.Color.White;
            this.tbTransactionDate.Location = new System.Drawing.Point(185, 241);
            this.tbTransactionDate.Name = "tbTransactionDate";
            this.tbTransactionDate.ReadOnly = true;
            this.tbTransactionDate.Size = new System.Drawing.Size(264, 26);
            this.tbTransactionDate.TabIndex = 89;
            this.tbTransactionDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label16.Location = new System.Drawing.Point(116, 242);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 26);
            this.label16.TabIndex = 88;
            this.label16.Text = "Date:";
            // 
            // tbUserProccessedTheTransaction
            // 
            this.tbUserProccessedTheTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbUserProccessedTheTransaction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserProccessedTheTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserProccessedTheTransaction.ForeColor = System.Drawing.Color.White;
            this.tbUserProccessedTheTransaction.Location = new System.Drawing.Point(185, 171);
            this.tbUserProccessedTheTransaction.Name = "tbUserProccessedTheTransaction";
            this.tbUserProccessedTheTransaction.ReadOnly = true;
            this.tbUserProccessedTheTransaction.Size = new System.Drawing.Size(264, 26);
            this.tbUserProccessedTheTransaction.TabIndex = 86;
            this.tbUserProccessedTheTransaction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nupBalanceAfter
            // 
            this.nupBalanceAfter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.nupBalanceAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nupBalanceAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupBalanceAfter.ForeColor = System.Drawing.Color.White;
            this.nupBalanceAfter.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nupBalanceAfter.Location = new System.Drawing.Point(185, 133);
            this.nupBalanceAfter.Maximum = new decimal(new int[] {
            -402653184,
            -1613725636,
            54210108,
            0});
            this.nupBalanceAfter.Name = "nupBalanceAfter";
            this.nupBalanceAfter.ReadOnly = true;
            this.nupBalanceAfter.Size = new System.Drawing.Size(262, 29);
            this.nupBalanceAfter.TabIndex = 85;
            this.nupBalanceAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nupBalanceBefore
            // 
            this.nupBalanceBefore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.nupBalanceBefore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nupBalanceBefore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupBalanceBefore.ForeColor = System.Drawing.Color.White;
            this.nupBalanceBefore.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nupBalanceBefore.Location = new System.Drawing.Point(185, 95);
            this.nupBalanceBefore.Maximum = new decimal(new int[] {
            -402653184,
            -1613725636,
            54210108,
            0});
            this.nupBalanceBefore.Name = "nupBalanceBefore";
            this.nupBalanceBefore.ReadOnly = true;
            this.nupBalanceBefore.Size = new System.Drawing.Size(262, 29);
            this.nupBalanceBefore.TabIndex = 84;
            this.nupBalanceBefore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label14.Location = new System.Drawing.Point(16, 171);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(164, 26);
            this.label14.TabIndex = 81;
            this.label14.Text = "Proccessed By:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label11.Location = new System.Drawing.Point(31, 136);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 26);
            this.label11.TabIndex = 79;
            this.label11.Text = "Balance After:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label8.Location = new System.Drawing.Point(13, 98);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 26);
            this.label8.TabIndex = 77;
            this.label8.Text = "Balance Before:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblTransactionlStatus);
            this.panel3.Controls.Add(this.pbAccountTypePhoto);
            this.panel3.Controls.Add(this.lblTransactionType);
            this.panel3.Location = new System.Drawing.Point(-1, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(472, 73);
            this.panel3.TabIndex = 0;
            // 
            // lblTransactionlStatus
            // 
            this.lblTransactionlStatus.AutoSize = true;
            this.lblTransactionlStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionlStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblTransactionlStatus.Location = new System.Drawing.Point(150, 42);
            this.lblTransactionlStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTransactionlStatus.Name = "lblTransactionlStatus";
            this.lblTransactionlStatus.Size = new System.Drawing.Size(218, 20);
            this.lblTransactionlStatus.TabIndex = 25;
            this.lblTransactionlStatus.Text = "Status (Pending - Completed)";
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionType.ForeColor = System.Drawing.Color.White;
            this.lblTransactionType.Location = new System.Drawing.Point(150, 14);
            this.lblTransactionType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(156, 24);
            this.lblTransactionType.TabIndex = 24;
            this.lblTransactionType.Text = "Transaction Type";
            // 
            // btnSchedualedFillter
            // 
            this.btnSchedualedFillter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSchedualedFillter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedualedFillter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedualedFillter.ForeColor = System.Drawing.Color.White;
            this.btnSchedualedFillter.Location = new System.Drawing.Point(735, 124);
            this.btnSchedualedFillter.Margin = new System.Windows.Forms.Padding(2);
            this.btnSchedualedFillter.Name = "btnSchedualedFillter";
            this.btnSchedualedFillter.Size = new System.Drawing.Size(93, 32);
            this.btnSchedualedFillter.TabIndex = 63;
            this.btnSchedualedFillter.Text = "Schedualed";
            this.btnSchedualedFillter.UseVisualStyleBackColor = true;
            this.btnSchedualedFillter.Click += new System.EventHandler(this.btnSchedualedFillter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Search:";
            // 
            // tbSearchBar
            // 
            this.tbSearchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSearchBar.Location = new System.Drawing.Point(10, 124);
            this.tbSearchBar.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearchBar.Name = "tbSearchBar";
            this.tbSearchBar.Size = new System.Drawing.Size(721, 32);
            this.tbSearchBar.TabIndex = 16;
            this.tbSearchBar.Tag = "Search using \"from account\" number , customer name or transaction type";
            this.tbSearchBar.Text = "Search using \"from account\" number , customer name or transaction type";
            this.tbSearchBar.TextChanged += new System.EventHandler(this.tbSearchBar_TextChanged);
            this.tbSearchBar.Enter += new System.EventHandler(this.tbSearchBar_EnterLeave);
            this.tbSearchBar.Leave += new System.EventHandler(this.tbSearchBar_EnterLeave);
            // 
            // btnExport
            // 
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.Image = global::SmartBank_UI.Properties.Resources.icons8_export_48;
            this.btnExport.Location = new System.Drawing.Point(1046, 102);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 54);
            this.btnExport.TabIndex = 65;
            this.btnExport.Text = "Export";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnNewTransactions
            // 
            this.btnNewTransactions.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnNewTransactions.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNewTransactions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnNewTransactions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnNewTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTransactions.ForeColor = System.Drawing.Color.White;
            this.btnNewTransactions.Image = global::SmartBank_UI.Properties.Resources.icons8_plus_24;
            this.btnNewTransactions.Location = new System.Drawing.Point(1145, 102);
            this.btnNewTransactions.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewTransactions.Name = "btnNewTransactions";
            this.btnNewTransactions.Size = new System.Drawing.Size(164, 54);
            this.btnNewTransactions.TabIndex = 64;
            this.btnNewTransactions.Text = "New Transaction";
            this.btnNewTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewTransactions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewTransactions.UseVisualStyleBackColor = false;
            // 
            // pbAccountTypePhoto
            // 
            this.pbAccountTypePhoto.Image = global::SmartBank_UI.Properties.Resources.icons8_transaction_50;
            this.pbAccountTypePhoto.Location = new System.Drawing.Point(27, 5);
            this.pbAccountTypePhoto.Name = "pbAccountTypePhoto";
            this.pbAccountTypePhoto.Size = new System.Drawing.Size(107, 63);
            this.pbAccountTypePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAccountTypePhoto.TabIndex = 23;
            this.pbAccountTypePhoto.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsNewDeposite,
            this.cmsNewWithdrawl,
            this.cmsNewTransfare,
            this.toolStripSeparator1,
            this.cmsAccountTransactionsLog,
            this.toolStripMenuItem3,
            this.cmsCustomerInfo});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(220, 188);
            // 
            // cmsNewDeposite
            // 
            this.cmsNewDeposite.Image = global::SmartBank_UI.Properties.Resources.icons8_money_box_50;
            this.cmsNewDeposite.Name = "cmsNewDeposite";
            this.cmsNewDeposite.Size = new System.Drawing.Size(219, 30);
            this.cmsNewDeposite.Text = "New Deposit";
            // 
            // cmsNewWithdrawl
            // 
            this.cmsNewWithdrawl.Image = global::SmartBank_UI.Properties.Resources.icons8_initiate_money_transfer_50;
            this.cmsNewWithdrawl.Name = "cmsNewWithdrawl";
            this.cmsNewWithdrawl.Size = new System.Drawing.Size(219, 30);
            this.cmsNewWithdrawl.Text = "New Withdrawl";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // cmsNewTransfare
            // 
            this.cmsNewTransfare.Image = global::SmartBank_UI.Properties.Resources.icons8_money_with_wings_50;
            this.cmsNewTransfare.Name = "cmsNewTransfare";
            this.cmsNewTransfare.Size = new System.Drawing.Size(219, 30);
            this.cmsNewTransfare.Tag = "DeactivateButton";
            this.cmsNewTransfare.Text = "New Transfare";
            // 
            // cmsAccountTransactionsLog
            // 
            this.cmsAccountTransactionsLog.Image = global::SmartBank_UI.Properties.Resources.icons8_log_50;
            this.cmsAccountTransactionsLog.Name = "cmsAccountTransactionsLog";
            this.cmsAccountTransactionsLog.Size = new System.Drawing.Size(219, 30);
            this.cmsAccountTransactionsLog.Text = "Account Transactions Log";
            this.cmsAccountTransactionsLog.Click += new System.EventHandler(this.cmsAccountTransactionsLog_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(216, 6);
            // 
            // cmsCustomerInfo
            // 
            this.cmsCustomerInfo.Image = global::SmartBank_UI.Properties.Resources.icons8_view_50;
            this.cmsCustomerInfo.Name = "cmsCustomerInfo";
            this.cmsCustomerInfo.Size = new System.Drawing.Size(219, 30);
            this.cmsCustomerInfo.Text = "Customer Information";
            this.cmsCustomerInfo.Click += new System.EventHandler(this.cmsCustomerInfo_Click);
            // 
            // ctrlAccountShortInfo1
            // 
            this.ctrlAccountShortInfo1.BackColor = System.Drawing.Color.MidnightBlue;
            this.ctrlAccountShortInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAccountShortInfo1.Location = new System.Drawing.Point(837, 160);
            this.ctrlAccountShortInfo1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlAccountShortInfo1.Name = "ctrlAccountShortInfo1";
            this.ctrlAccountShortInfo1.Size = new System.Drawing.Size(472, 369);
            this.ctrlAccountShortInfo1.TabIndex = 14;
            // 
            // ctrlTransactionsMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnNewTransactions);
            this.Controls.Add(this.btnSchedualedFillter);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSearchBar);
            this.Controls.Add(this.ctrlAccountShortInfo1);
            this.Controls.Add(this.dgvAllTransactions);
            this.Controls.Add(this.lblTransactionsFormInfoToUser);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ctrlTransactionsMainScreen";
            this.Size = new System.Drawing.Size(1318, 833);
            this.Load += new System.EventHandler(this.ctrlTransactionsMainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTransactions)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupBalanceAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupBalanceBefore)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccountTypePhoto)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTransactionsFormInfoToUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAllTransactions;
        private Accounts.Accounts_User_Controls.ctrlAccountShortInfo ctrlAccountShortInfo1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblClickToShowRow;
        private System.Windows.Forms.Label lblNumberOfTransactions;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSchedualedFillter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSearchBar;
        private System.Windows.Forms.Label lblTransactionlStatus;
        private System.Windows.Forms.PictureBox pbAccountTypePhoto;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbUserProccessedTheTransaction;
        private System.Windows.Forms.NumericUpDown nupBalanceAfter;
        private System.Windows.Forms.NumericUpDown nupBalanceBefore;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnNewTransactions;
        private System.Windows.Forms.TextBox tbTransactionDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmsNewDeposite;
        private System.Windows.Forms.ToolStripMenuItem cmsNewWithdrawl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsNewTransfare;
        private System.Windows.Forms.ToolStripMenuItem cmsAccountTransactionsLog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem cmsCustomerInfo;
    }
}
