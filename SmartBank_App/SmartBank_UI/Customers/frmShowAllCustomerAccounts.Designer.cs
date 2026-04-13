namespace SmartBank_UI.Accounts
{
    partial class frmShowAllCustomerAccounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ctrlCustomerShortInfo1 = new SmartBank_UI.Main_Form_UC.ctrlCustomerShortInfo();
            this.dgvAllCustomerAccounts = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumberOfAccounts = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllCustomerAccounts)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlCustomerShortInfo1
            // 
            this.ctrlCustomerShortInfo1.BackColor = System.Drawing.Color.MidnightBlue;
            this.ctrlCustomerShortInfo1.Location = new System.Drawing.Point(4, 2);
            this.ctrlCustomerShortInfo1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrlCustomerShortInfo1.Name = "ctrlCustomerShortInfo1";
            this.ctrlCustomerShortInfo1.Size = new System.Drawing.Size(678, 862);
            this.ctrlCustomerShortInfo1.TabIndex = 0;
            // 
            // dgvAllCustomerAccounts
            // 
            this.dgvAllCustomerAccounts.AllowUserToAddRows = false;
            this.dgvAllCustomerAccounts.AllowUserToDeleteRows = false;
            this.dgvAllCustomerAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllCustomerAccounts.BackgroundColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllCustomerAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllCustomerAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllCustomerAccounts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllCustomerAccounts.Location = new System.Drawing.Point(688, 2);
            this.dgvAllCustomerAccounts.MultiSelect = false;
            this.dgvAllCustomerAccounts.Name = "dgvAllCustomerAccounts";
            this.dgvAllCustomerAccounts.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllCustomerAccounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAllCustomerAccounts.RowHeadersWidth = 62;
            this.dgvAllCustomerAccounts.RowTemplate.Height = 28;
            this.dgvAllCustomerAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllCustomerAccounts.Size = new System.Drawing.Size(1004, 862);
            this.dgvAllCustomerAccounts.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNumberOfAccounts);
            this.panel1.Location = new System.Drawing.Point(4, 872);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1688, 80);
            this.panel1.TabIndex = 57;
            // 
            // lblNumberOfAccounts
            // 
            this.lblNumberOfAccounts.AutoSize = true;
            this.lblNumberOfAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfAccounts.ForeColor = System.Drawing.Color.White;
            this.lblNumberOfAccounts.Location = new System.Drawing.Point(25, 20);
            this.lblNumberOfAccounts.Name = "lblNumberOfAccounts";
            this.lblNumberOfAccounts.Size = new System.Drawing.Size(431, 37);
            this.lblNumberOfAccounts.TabIndex = 57;
            this.lblNumberOfAccounts.Text = "Showing 6 of 2,847 accounts";
            // 
            // frmShowAllCustomerAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1696, 958);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvAllCustomerAccounts);
            this.Controls.Add(this.ctrlCustomerShortInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmShowAllCustomerAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmShowAllCustomerAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllCustomerAccounts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Main_Form_UC.ctrlCustomerShortInfo ctrlCustomerShortInfo1;
        private System.Windows.Forms.DataGridView dgvAllCustomerAccounts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumberOfAccounts;
    }
}