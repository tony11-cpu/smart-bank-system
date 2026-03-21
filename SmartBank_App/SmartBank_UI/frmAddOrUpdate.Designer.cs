namespace SmartBank_UI
{
    partial class frmAddOrUpdateCustomers
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
            this.ctrlAddOrUpdateCustomer1 = new SmartBank_UI.Main_Form_UC.ctrlAddOrUpdateCustomer();
            this.SuspendLayout();
            // 
            // ctrlAddOrUpdateCustomer1
            // 
            this.ctrlAddOrUpdateCustomer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ctrlAddOrUpdateCustomer1.ForeColor = System.Drawing.Color.White;
            this.ctrlAddOrUpdateCustomer1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddOrUpdateCustomer1.Name = "ctrlAddOrUpdateCustomer1";
            this.ctrlAddOrUpdateCustomer1.Size = new System.Drawing.Size(904, 936);
            this.ctrlAddOrUpdateCustomer1.TabIndex = 0;
            // 
            // frmAddOrUpdateCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(903, 940);
            this.Controls.Add(this.ctrlAddOrUpdateCustomer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddOrUpdateCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddOrUpdate";
            this.Load += new System.EventHandler(this.frmAddOrUpdateCustomers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Main_Form_UC.ctrlAddOrUpdateCustomer ctrlAddOrUpdateCustomer1;
    }
}