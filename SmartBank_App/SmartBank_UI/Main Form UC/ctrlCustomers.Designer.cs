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
            this.lblMorningToUserWithName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearchBar = new System.Windows.Forms.TextBox();
            this.btnAllFilterSearch = new System.Windows.Forms.Button();
            this.btnActiveFilterSearch = new System.Windows.Forms.Button();
            this.btnInactiveFilterSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCustomersData = new System.Windows.Forms.DataGridView();
            this.pCustomerInfo = new System.Windows.Forms.Panel();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomersData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMorningToUserWithName
            // 
            this.lblMorningToUserWithName.AutoSize = true;
            this.lblMorningToUserWithName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMorningToUserWithName.ForeColor = System.Drawing.Color.DarkGray;
            this.lblMorningToUserWithName.Location = new System.Drawing.Point(56, 87);
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
            this.label1.Location = new System.Drawing.Point(54, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customers";
            // 
            // tbSearchBar
            // 
            this.tbSearchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSearchBar.Location = new System.Drawing.Point(60, 185);
            this.tbSearchBar.Name = "tbSearchBar";
            this.tbSearchBar.Size = new System.Drawing.Size(1254, 44);
            this.tbSearchBar.TabIndex = 5;
            this.tbSearchBar.Text = "Search by name,phone , or last 4 digits of National ID...";
            this.tbSearchBar.Click += new System.EventHandler(this.tbSearchBar_Click);
            // 
            // btnAllFilterSearch
            // 
            this.btnAllFilterSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAllFilterSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAllFilterSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnAllFilterSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAllFilterSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllFilterSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllFilterSearch.ForeColor = System.Drawing.Color.White;
            this.btnAllFilterSearch.Location = new System.Drawing.Point(1320, 186);
            this.btnAllFilterSearch.Name = "btnAllFilterSearch";
            this.btnAllFilterSearch.Size = new System.Drawing.Size(73, 44);
            this.btnAllFilterSearch.TabIndex = 6;
            this.btnAllFilterSearch.Text = "All";
            this.btnAllFilterSearch.UseVisualStyleBackColor = false;
            // 
            // btnActiveFilterSearch
            // 
            this.btnActiveFilterSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnActiveFilterSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnActiveFilterSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnActiveFilterSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnActiveFilterSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActiveFilterSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveFilterSearch.ForeColor = System.Drawing.Color.White;
            this.btnActiveFilterSearch.Location = new System.Drawing.Point(1399, 186);
            this.btnActiveFilterSearch.Name = "btnActiveFilterSearch";
            this.btnActiveFilterSearch.Size = new System.Drawing.Size(95, 44);
            this.btnActiveFilterSearch.TabIndex = 7;
            this.btnActiveFilterSearch.Text = "Active";
            this.btnActiveFilterSearch.UseVisualStyleBackColor = false;
            // 
            // btnInactiveFilterSearch
            // 
            this.btnInactiveFilterSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnInactiveFilterSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInactiveFilterSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnInactiveFilterSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnInactiveFilterSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInactiveFilterSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInactiveFilterSearch.ForeColor = System.Drawing.Color.White;
            this.btnInactiveFilterSearch.Location = new System.Drawing.Point(1500, 186);
            this.btnInactiveFilterSearch.Name = "btnInactiveFilterSearch";
            this.btnInactiveFilterSearch.Size = new System.Drawing.Size(117, 44);
            this.btnInactiveFilterSearch.TabIndex = 8;
            this.btnInactiveFilterSearch.Text = "Inactive";
            this.btnInactiveFilterSearch.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(56, 153);
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
            this.dgvCustomersData.Location = new System.Drawing.Point(58, 275);
            this.dgvCustomersData.MultiSelect = false;
            this.dgvCustomersData.Name = "dgvCustomersData";
            this.dgvCustomersData.ReadOnly = true;
            this.dgvCustomersData.RowHeadersWidth = 62;
            this.dgvCustomersData.RowTemplate.Height = 28;
            this.dgvCustomersData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomersData.Size = new System.Drawing.Size(900, 963);
            this.dgvCustomersData.TabIndex = 10;
            // 
            // pCustomerInfo
            // 
            this.pCustomerInfo.Location = new System.Drawing.Point(964, 275);
            this.pCustomerInfo.Name = "pCustomerInfo";
            this.pCustomerInfo.Size = new System.Drawing.Size(652, 963);
            this.pCustomerInfo.TabIndex = 11;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddCustomer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnAddCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.ForeColor = System.Drawing.Color.White;
            this.btnAddCustomer.Image = global::SmartBank_UI.Properties.Resources.icons8_plus_24;
            this.btnAddCustomer.Location = new System.Drawing.Point(1371, 79);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(245, 82);
            this.btnAddCustomer.TabIndex = 4;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            // 
            // ctrlCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.pCustomerInfo);
            this.Controls.Add(this.dgvCustomersData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnInactiveFilterSearch);
            this.Controls.Add(this.btnActiveFilterSearch);
            this.Controls.Add(this.btnAllFilterSearch);
            this.Controls.Add(this.tbSearchBar);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.lblMorningToUserWithName);
            this.Controls.Add(this.label1);
            this.Name = "ctrlCustomers";
            this.Size = new System.Drawing.Size(1655, 1279);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomersData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMorningToUserWithName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.TextBox tbSearchBar;
        private System.Windows.Forms.Button btnAllFilterSearch;
        private System.Windows.Forms.Button btnActiveFilterSearch;
        private System.Windows.Forms.Button btnInactiveFilterSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCustomersData;
        private System.Windows.Forms.Panel pCustomerInfo;
    }
}
