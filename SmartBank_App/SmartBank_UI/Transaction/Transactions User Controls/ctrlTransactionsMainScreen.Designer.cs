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
            this.lblTransactionsFormInfoToUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAllTransactions = new System.Windows.Forms.DataGridView();
            this.btnNewTrasaction = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClickToShowRow = new System.Windows.Forms.Label();
            this.lblNumberOfTransaction = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbTransactionDate = new System.Windows.Forms.TextBox();
            this.tbUserProccessedTheTransaction = new System.Windows.Forms.TextBox();
            this.nupBalanceAfter = new System.Windows.Forms.NumericUpDown();
            this.nupBalanceBefore = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbTransactionlStatus = new System.Windows.Forms.Label();
            this.pbAccountTypePhoto = new System.Windows.Forms.PictureBox();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.btnSchedualedFillter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearchBar = new System.Windows.Forms.TextBox();
            this.ctrlAccountShortInfo1 = new SmartBank_UI.Accounts.Accounts_User_Controls.ctrlAccountShortInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTransactions)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupBalanceAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupBalanceBefore)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccountTypePhoto)).BeginInit();
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
            this.dgvAllTransactions.Location = new System.Drawing.Point(18, 168);
            this.dgvAllTransactions.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAllTransactions.MultiSelect = false;
            this.dgvAllTransactions.Name = "dgvAllTransactions";
            this.dgvAllTransactions.ReadOnly = true;
            this.dgvAllTransactions.RowHeadersVisible = false;
            this.dgvAllTransactions.RowHeadersWidth = 62;
            this.dgvAllTransactions.RowTemplate.Height = 28;
            this.dgvAllTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllTransactions.Size = new System.Drawing.Size(813, 599);
            this.dgvAllTransactions.TabIndex = 13;
            // 
            // btnNewTrasaction
            // 
            this.btnNewTrasaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnNewTrasaction.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnNewTrasaction.FlatAppearance.BorderSize = 2;
            this.btnNewTrasaction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnNewTrasaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTrasaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTrasaction.ForeColor = System.Drawing.Color.Lime;
            this.btnNewTrasaction.Image = global::SmartBank_UI.Properties.Resources.icons8_up_arrow_38;
            this.btnNewTrasaction.Location = new System.Drawing.Point(1094, 103);
            this.btnNewTrasaction.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewTrasaction.Name = "btnNewTrasaction";
            this.btnNewTrasaction.Size = new System.Drawing.Size(217, 61);
            this.btnNewTrasaction.TabIndex = 15;
            this.btnNewTrasaction.Text = "New Transaction";
            this.btnNewTrasaction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewTrasaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewTrasaction.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblClickToShowRow);
            this.panel1.Controls.Add(this.lblNumberOfTransaction);
            this.panel1.Location = new System.Drawing.Point(18, 777);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 39);
            this.panel1.TabIndex = 57;
            // 
            // lblClickToShowRow
            // 
            this.lblClickToShowRow.AutoSize = true;
            this.lblClickToShowRow.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblClickToShowRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClickToShowRow.ForeColor = System.Drawing.Color.White;
            this.lblClickToShowRow.Location = new System.Drawing.Point(617, 12);
            this.lblClickToShowRow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClickToShowRow.Name = "lblClickToShowRow";
            this.lblClickToShowRow.Size = new System.Drawing.Size(178, 18);
            this.lblClickToShowRow.TabIndex = 58;
            this.lblClickToShowRow.Text = "Click a row to view details";
            this.lblClickToShowRow.Visible = false;
            // 
            // lblNumberOfTransaction
            // 
            this.lblNumberOfTransaction.AutoSize = true;
            this.lblNumberOfTransaction.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblNumberOfTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfTransaction.ForeColor = System.Drawing.Color.White;
            this.lblNumberOfTransaction.Location = new System.Drawing.Point(7, 12);
            this.lblNumberOfTransaction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumberOfTransaction.Name = "lblNumberOfTransaction";
            this.lblNumberOfTransaction.Size = new System.Drawing.Size(191, 18);
            this.lblNumberOfTransaction.TabIndex = 57;
            this.lblNumberOfTransaction.Text = "Showing 0 transaction done";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbTransactionDate);
            this.panel2.Controls.Add(this.tbUserProccessedTheTransaction);
            this.panel2.Controls.Add(this.nupBalanceAfter);
            this.panel2.Controls.Add(this.nupBalanceBefore);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(840, 549);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 267);
            this.panel2.TabIndex = 62;
            // 
            // tbTransactionDate
            // 
            this.tbTransactionDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbTransactionDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTransactionDate.Enabled = false;
            this.tbTransactionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTransactionDate.ForeColor = System.Drawing.Color.White;
            this.tbTransactionDate.Location = new System.Drawing.Point(182, 227);
            this.tbTransactionDate.Name = "tbTransactionDate";
            this.tbTransactionDate.ReadOnly = true;
            this.tbTransactionDate.Size = new System.Drawing.Size(264, 26);
            this.tbTransactionDate.TabIndex = 87;
            // 
            // tbUserProccessedTheTransaction
            // 
            this.tbUserProccessedTheTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbUserProccessedTheTransaction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserProccessedTheTransaction.Enabled = false;
            this.tbUserProccessedTheTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserProccessedTheTransaction.ForeColor = System.Drawing.Color.White;
            this.tbUserProccessedTheTransaction.Location = new System.Drawing.Point(184, 181);
            this.tbUserProccessedTheTransaction.Name = "tbUserProccessedTheTransaction";
            this.tbUserProccessedTheTransaction.ReadOnly = true;
            this.tbUserProccessedTheTransaction.Size = new System.Drawing.Size(264, 26);
            this.tbUserProccessedTheTransaction.TabIndex = 86;
            // 
            // nupBalanceAfter
            // 
            this.nupBalanceAfter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.nupBalanceAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nupBalanceAfter.Enabled = false;
            this.nupBalanceAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupBalanceAfter.ForeColor = System.Drawing.Color.White;
            this.nupBalanceAfter.Location = new System.Drawing.Point(184, 132);
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
            this.nupBalanceBefore.Enabled = false;
            this.nupBalanceBefore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupBalanceBefore.ForeColor = System.Drawing.Color.White;
            this.nupBalanceBefore.Location = new System.Drawing.Point(185, 86);
            this.nupBalanceBefore.Name = "nupBalanceBefore";
            this.nupBalanceBefore.ReadOnly = true;
            this.nupBalanceBefore.Size = new System.Drawing.Size(262, 29);
            this.nupBalanceBefore.TabIndex = 84;
            this.nupBalanceBefore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label16.Location = new System.Drawing.Point(113, 227);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 26);
            this.label16.TabIndex = 83;
            this.label16.Text = "Date:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label14.Location = new System.Drawing.Point(13, 180);
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
            this.label11.Location = new System.Drawing.Point(28, 134);
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
            this.label8.Location = new System.Drawing.Point(13, 86);
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
            this.panel3.Controls.Add(this.lbTransactionlStatus);
            this.panel3.Controls.Add(this.pbAccountTypePhoto);
            this.panel3.Controls.Add(this.lblTransactionType);
            this.panel3.Location = new System.Drawing.Point(-1, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(472, 73);
            this.panel3.TabIndex = 0;
            // 
            // lbTransactionlStatus
            // 
            this.lbTransactionlStatus.AutoSize = true;
            this.lbTransactionlStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTransactionlStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbTransactionlStatus.Location = new System.Drawing.Point(150, 42);
            this.lbTransactionlStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTransactionlStatus.Name = "lbTransactionlStatus";
            this.lbTransactionlStatus.Size = new System.Drawing.Size(218, 20);
            this.lbTransactionlStatus.TabIndex = 25;
            this.lbTransactionlStatus.Text = "Status (Pending - Completed)";
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
            this.btnSchedualedFillter.Location = new System.Drawing.Point(736, 132);
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
            this.label2.Location = new System.Drawing.Point(16, 112);
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
            this.tbSearchBar.Location = new System.Drawing.Point(18, 132);
            this.tbSearchBar.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearchBar.Name = "tbSearchBar";
            this.tbSearchBar.Size = new System.Drawing.Size(715, 32);
            this.tbSearchBar.TabIndex = 16;
            this.tbSearchBar.Tag = "Search using transaction type: deposite, withrawl, transafare";
            this.tbSearchBar.Text = "Search using transaction type: deposite, withrawl, transafare";
            this.tbSearchBar.Enter += new System.EventHandler(this.tbSearchBar_EnterLeave);
            this.tbSearchBar.Leave += new System.EventHandler(this.tbSearchBar_EnterLeave);
            // 
            // ctrlAccountShortInfo1
            // 
            this.ctrlAccountShortInfo1.BackColor = System.Drawing.Color.MidnightBlue;
            this.ctrlAccountShortInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAccountShortInfo1.Location = new System.Drawing.Point(840, 168);
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
            this.Controls.Add(this.btnSchedualedFillter);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSearchBar);
            this.Controls.Add(this.btnNewTrasaction);
            this.Controls.Add(this.ctrlAccountShortInfo1);
            this.Controls.Add(this.dgvAllTransactions);
            this.Controls.Add(this.lblTransactionsFormInfoToUser);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ctrlTransactionsMainScreen";
            this.Size = new System.Drawing.Size(1327, 833);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTransactionsFormInfoToUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAllTransactions;
        private Accounts.Accounts_User_Controls.ctrlAccountShortInfo ctrlAccountShortInfo1;
        private System.Windows.Forms.Button btnNewTrasaction;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblClickToShowRow;
        private System.Windows.Forms.Label lblNumberOfTransaction;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSchedualedFillter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSearchBar;
        private System.Windows.Forms.Label lbTransactionlStatus;
        private System.Windows.Forms.PictureBox pbAccountTypePhoto;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTransactionDate;
        private System.Windows.Forms.TextBox tbUserProccessedTheTransaction;
        private System.Windows.Forms.NumericUpDown nupBalanceAfter;
        private System.Windows.Forms.NumericUpDown nupBalanceBefore;
    }
}
