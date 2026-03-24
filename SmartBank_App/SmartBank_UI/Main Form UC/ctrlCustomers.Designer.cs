namespace SmartBank_UI.Main_Form_UC
{
    partial class ctrlCustomers
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
            this.viewCustomerAccountHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSearchBar = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumberOfCustomers = new System.Windows.Forms.Label();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
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
            this.lblMorningToUserWithName.Location = new System.Drawing.Point(24, 86);
            this.lblMorningToUserWithName.Name = "lblMorningToUserWithName";
            this.lblMorningToUserWithName.Size = new System.Drawing.Size(566, 26);
            this.lblMorningToUserWithName.TabIndex = 3;
            this.lblMorningToUserWithName.Text = "Search, view, and manage all registered bank customers.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "Search:";
            // 
            // dgvCustomersData
            // 
            this.dgvCustomersData.AllowUserToAddRows = false;
            this.dgvCustomersData.AllowUserToDeleteRows = false;
            this.dgvCustomersData.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvCustomersData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomersData.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCustomersData.Location = new System.Drawing.Point(28, 260);
            this.dgvCustomersData.MultiSelect = false;
            this.dgvCustomersData.Name = "dgvCustomersData";
            this.dgvCustomersData.ReadOnly = true;
            this.dgvCustomersData.RowHeadersWidth = 62;
            this.dgvCustomersData.RowTemplate.Height = 28;
            this.dgvCustomersData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomersData.Size = new System.Drawing.Size(900, 915);
            this.dgvCustomersData.TabIndex = 10;
            this.dgvCustomersData.Click += new System.EventHandler(this.dgvCustomersData_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomerToolStripMenuItem,
            this.updateCustomerToolStripMenuItem,
            this.viewCustomerAccountHistoryToolStripMenuItem,
            this.deactivateCustomerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(344, 132);
            // 
            // addCustomerToolStripMenuItem
            // 
            this.addCustomerToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_user_50;
            this.addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
            this.addCustomerToolStripMenuItem.Size = new System.Drawing.Size(343, 32);
            this.addCustomerToolStripMenuItem.Text = "Add Customer";
            this.addCustomerToolStripMenuItem.Click += new System.EventHandler(this.AddNewCutomer_Click);
            // 
            // updateCustomerToolStripMenuItem
            // 
            this.updateCustomerToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_update_user_48;
            this.updateCustomerToolStripMenuItem.Name = "updateCustomerToolStripMenuItem";
            this.updateCustomerToolStripMenuItem.Size = new System.Drawing.Size(343, 32);
            this.updateCustomerToolStripMenuItem.Text = "Update Customer";
            this.updateCustomerToolStripMenuItem.Click += new System.EventHandler(this.updateCustomerToolStripMenuItem_Click);
            // 
            // viewCustomerAccountHistoryToolStripMenuItem
            // 
            this.viewCustomerAccountHistoryToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_view_50;
            this.viewCustomerAccountHistoryToolStripMenuItem.Name = "viewCustomerAccountHistoryToolStripMenuItem";
            this.viewCustomerAccountHistoryToolStripMenuItem.Size = new System.Drawing.Size(343, 32);
            this.viewCustomerAccountHistoryToolStripMenuItem.Text = "View Customer Account History";
            this.viewCustomerAccountHistoryToolStripMenuItem.Click += new System.EventHandler(this.viewCustomerAccountHistoryToolStripMenuItem_Click);
            // 
            // deactivateCustomerToolStripMenuItem
            // 
            this.deactivateCustomerToolStripMenuItem.Image = global::SmartBank_UI.Properties.Resources.icons8_user_locked_48;
            this.deactivateCustomerToolStripMenuItem.Name = "deactivateCustomerToolStripMenuItem";
            this.deactivateCustomerToolStripMenuItem.Size = new System.Drawing.Size(343, 32);
            this.deactivateCustomerToolStripMenuItem.Text = "Deactivate Customer";
            this.deactivateCustomerToolStripMenuItem.Click += new System.EventHandler(this.DeactivateCustomer_Click);
            // 
            // tbSearchBar
            // 
            this.tbSearchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSearchBar.Location = new System.Drawing.Point(31, 210);
            this.tbSearchBar.Name = "tbSearchBar";
            this.tbSearchBar.Size = new System.Drawing.Size(897, 44);
            this.tbSearchBar.TabIndex = 5;
            this.tbSearchBar.Tag = "";
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
            this.panel1.Location = new System.Drawing.Point(31, 1186);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 56);
            this.panel1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "Number of customers:";
            // 
            // lblNumberOfCustomers
            // 
            this.lblNumberOfCustomers.AutoSize = true;
            this.lblNumberOfCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfCustomers.ForeColor = System.Drawing.Color.White;
            this.lblNumberOfCustomers.Location = new System.Drawing.Point(310, 10);
            this.lblNumberOfCustomers.Name = "lblNumberOfCustomers";
            this.lblNumberOfCustomers.Size = new System.Drawing.Size(46, 32);
            this.lblNumberOfCustomers.TabIndex = 13;
            this.lblNumberOfCustomers.Text = "00";
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
            this.btnAddCustomer.Location = new System.Drawing.Point(1381, 178);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(245, 76);
            this.btnAddCustomer.TabIndex = 4;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.AddNewCutomer_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(343, 32);
            this.toolStripMenuItem2.Text = " ";
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDeactivate.FlatAppearance.BorderSize = 2;
            this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeactivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeactivate.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDeactivate.Location = new System.Drawing.Point(1287, 1142);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(282, 75);
            this.btnDeactivate.TabIndex = 24;
            this.btnDeactivate.Text = "Deactivate";
            this.btnDeactivate.UseVisualStyleBackColor = false;
            this.btnDeactivate.Click += new System.EventHandler(this.DeactivateCustomer_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEdit.FlatAppearance.BorderSize = 2;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEdit.Location = new System.Drawing.Point(978, 1142);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(282, 75);
            this.btnEdit.TabIndex = 23;
            this.btnEdit.Text = "Edit Info";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // ctrlCustomerShortInfo1
            // 
            this.ctrlCustomerShortInfo1.BackColor = System.Drawing.Color.MidnightBlue;
            this.ctrlCustomerShortInfo1.Location = new System.Drawing.Point(947, 260);
            this.ctrlCustomerShortInfo1.Name = "ctrlCustomerShortInfo1";
            this.ctrlCustomerShortInfo1.Size = new System.Drawing.Size(679, 982);
            this.ctrlCustomerShortInfo1.TabIndex = 11;
            // 
            // ctrlCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
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
            this.Name = "ctrlCustomers";
            this.Size = new System.Drawing.Size(1650, 1279);
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
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.Button btnEdit;
    }
}
