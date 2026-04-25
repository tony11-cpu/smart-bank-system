namespace SmartBank_UI.Main_Form_UC
{
    partial class ctrlCustomersMainScreen
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
            this.lblMorningToUserWithName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCustomersData = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deactivateCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.viewCustomerAccountHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSearchBar = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumberOfCustomers = new System.Windows.Forms.Label();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.ctrlCustomerShortInfo1 = new SmartBank_UI.Main_Form_UC.ctrlCustomerShortInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomersData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMorningToUserWithName
            // 
            this.lblMorningToUserWithName.AutoSize = true;
            this.lblMorningToUserWithName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMorningToUserWithName.ForeColor = System.Drawing.Color.DarkGray;
            this.lblMorningToUserWithName.Location = new System.Drawing.Point(23, 47);
            this.lblMorningToUserWithName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMorningToUserWithName.Name = "lblMorningToUserWithName";
            this.lblMorningToUserWithName.Size = new System.Drawing.Size(383, 18);
            this.lblMorningToUserWithName.TabIndex = 3;
            this.lblMorningToUserWithName.Text = "Search, view, and manage all registered bank customers.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Search:";
            // 
            // dgvCustomersData
            // 
            this.dgvCustomersData.AllowUserToAddRows = false;
            this.dgvCustomersData.AllowUserToDeleteRows = false;
            this.dgvCustomersData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomersData.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvCustomersData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomersData.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCustomersData.Location = new System.Drawing.Point(11, 152);
            this.dgvCustomersData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCustomersData.MultiSelect = false;
            this.dgvCustomersData.Name = "dgvCustomersData";
            this.dgvCustomersData.ReadOnly = true;
            this.dgvCustomersData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCustomersData.RowHeadersVisible = false;
            this.dgvCustomersData.RowHeadersWidth = 62;
            this.dgvCustomersData.RowTemplate.Height = 28;
            this.dgvCustomersData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomersData.Size = new System.Drawing.Size(862, 613);
            this.dgvCustomersData.TabIndex = 10;
            this.dgvCustomersData.Click += new System.EventHandler(this.dgvCustomersData_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomerToolStripMenuItem,
            this.updateCustomerToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deactivateCustomerToolStripMenuItem,
            this.activateToolStripMenuItem,
            this.toolStripMenuItem3,
            this.viewCustomerAccountHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(252, 166);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // addCustomerToolStripMenuItem
            // 
            this.addCustomerToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_user_50;
            this.addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
            this.addCustomerToolStripMenuItem.Size = new System.Drawing.Size(251, 30);
            this.addCustomerToolStripMenuItem.Text = "Add New Customer";
            this.addCustomerToolStripMenuItem.Click += new System.EventHandler(this.AddNewCutomer_Click);
            // 
            // updateCustomerToolStripMenuItem
            // 
            this.updateCustomerToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_update_user_48;
            this.updateCustomerToolStripMenuItem.Name = "updateCustomerToolStripMenuItem";
            this.updateCustomerToolStripMenuItem.Size = new System.Drawing.Size(251, 30);
            this.updateCustomerToolStripMenuItem.Text = "Update Customer";
            this.updateCustomerToolStripMenuItem.Click += new System.EventHandler(this.updateCustomerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(248, 6);
            // 
            // deactivateCustomerToolStripMenuItem
            // 
            this.deactivateCustomerToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_user_locked_48;
            this.deactivateCustomerToolStripMenuItem.Name = "deactivateCustomerToolStripMenuItem";
            this.deactivateCustomerToolStripMenuItem.Size = new System.Drawing.Size(251, 30);
            this.deactivateCustomerToolStripMenuItem.Tag = "DeactivateButton";
            this.deactivateCustomerToolStripMenuItem.Text = "Deactivate Customer";
            this.deactivateCustomerToolStripMenuItem.Click += new System.EventHandler(this.DeactivateCustomer_Click);
            // 
            // activateToolStripMenuItem
            // 
            this.activateToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_attendance_50;
            this.activateToolStripMenuItem.Name = "activateToolStripMenuItem";
            this.activateToolStripMenuItem.Size = new System.Drawing.Size(251, 30);
            this.activateToolStripMenuItem.Text = "Activate Customer";
            this.activateToolStripMenuItem.Click += new System.EventHandler(this.Activate_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(248, 6);
            // 
            // viewCustomerAccountHistoryToolStripMenuItem
            // 
            this.viewCustomerAccountHistoryToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_view_50;
            this.viewCustomerAccountHistoryToolStripMenuItem.Name = "viewCustomerAccountHistoryToolStripMenuItem";
            this.viewCustomerAccountHistoryToolStripMenuItem.Size = new System.Drawing.Size(251, 30);
            this.viewCustomerAccountHistoryToolStripMenuItem.Text = "View Customer Account History";
            this.viewCustomerAccountHistoryToolStripMenuItem.Click += new System.EventHandler(this.viewCustomerAccountHistoryToolStripMenuItem_Click);
            // 
            // tbSearchBar
            // 
            this.tbSearchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSearchBar.Location = new System.Drawing.Point(13, 115);
            this.tbSearchBar.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearchBar.Name = "tbSearchBar";
            this.tbSearchBar.Size = new System.Drawing.Size(1308, 32);
            this.tbSearchBar.TabIndex = 5;
            this.tbSearchBar.Tag = "Search by name, phone, or last 4 digits of national ID...";
            this.tbSearchBar.Text = "Search by name, phone, or last 4 digits of national ID...";
            this.tbSearchBar.TextChanged += new System.EventHandler(this.tbSearchBar_TextChanged);
            this.tbSearchBar.Enter += new System.EventHandler(this.tbSearchBar_EnterLeave);
            this.tbSearchBar.Leave += new System.EventHandler(this.tbSearchBar_EnterLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblNumberOfCustomers);
            this.panel1.Location = new System.Drawing.Point(13, 769);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 36);
            this.panel1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Number of customers:";
            // 
            // lblNumberOfCustomers
            // 
            this.lblNumberOfCustomers.AutoSize = true;
            this.lblNumberOfCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfCustomers.ForeColor = System.Drawing.Color.White;
            this.lblNumberOfCustomers.Location = new System.Drawing.Point(207, 6);
            this.lblNumberOfCustomers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumberOfCustomers.Name = "lblNumberOfCustomers";
            this.lblNumberOfCustomers.Size = new System.Drawing.Size(30, 24);
            this.lblNumberOfCustomers.TabIndex = 13;
            this.lblNumberOfCustomers.Text = "00";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(343, 32);
            this.toolStripMenuItem2.Text = " ";
            // 
            // btnActivate
            // 
            this.btnActivate.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnActivate.FlatAppearance.BorderSize = 2;
            this.btnActivate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivate.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnActivate.Location = new System.Drawing.Point(1108, 728);
            this.btnActivate.Margin = new System.Windows.Forms.Padding(2);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(184, 57);
            this.btnActivate.TabIndex = 28;
            this.btnActivate.Tag = "ActivateButton";
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = false;
            this.btnActivate.Visible = false;
            this.btnActivate.Click += new System.EventHandler(this.Activate_Click);
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDeactivate.FlatAppearance.BorderSize = 2;
            this.btnDeactivate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeactivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeactivate.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDeactivate.Location = new System.Drawing.Point(1108, 728);
            this.btnDeactivate.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(184, 57);
            this.btnDeactivate.TabIndex = 27;
            this.btnDeactivate.Tag = "DeactivateButton";
            this.btnDeactivate.Text = "Deactivate";
            this.btnDeactivate.UseVisualStyleBackColor = false;
            this.btnDeactivate.Click += new System.EventHandler(this.DeactivateCustomer_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEdit.FlatAppearance.BorderSize = 2;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEdit.Location = new System.Drawing.Point(900, 728);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(184, 57);
            this.btnEdit.TabIndex = 26;
            this.btnEdit.Text = "Edit Info";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddCustomer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnAddCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.ForeColor = System.Drawing.Color.White;
            this.btnAddCustomer.Image = global::SmartBank_UI.Properties.Resources.icons8_plus_24;
            this.btnAddCustomer.Location = new System.Drawing.Point(1158, 62);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(163, 49);
            this.btnAddCustomer.TabIndex = 4;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.AddNewCutomer_Click);
            // 
            // ctrlCustomerShortInfo1
            // 
            this.ctrlCustomerShortInfo1.BackColor = System.Drawing.Color.MidnightBlue;
            this.ctrlCustomerShortInfo1.Location = new System.Drawing.Point(876, 152);
            this.ctrlCustomerShortInfo1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlCustomerShortInfo1.Name = "ctrlCustomerShortInfo1";
            this.ctrlCustomerShortInfo1.Size = new System.Drawing.Size(445, 653);
            this.ctrlCustomerShortInfo1.TabIndex = 11;
            // 
            // ctrlCustomersMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.btnDeactivate);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ctrlCustomerShortInfo1);
            this.Controls.Add(this.dgvCustomersData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSearchBar);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.lblMorningToUserWithName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ctrlCustomersMainScreen";
            this.Size = new System.Drawing.Size(1329, 819);
            this.Load += new System.EventHandler(this.ctrlCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomersData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMorningToUserWithName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCustomersData;
        private ctrlCustomerShortInfo ctrlCustomerShortInfo1;
        private System.Windows.Forms.TextBox tbSearchBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumberOfCustomers;
        private System.Windows.Forms.ToolStripMenuItem addCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCustomerAccountHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateCustomerToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem activateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    }
}
