namespace SmartBank_UI.Accounts
{
    partial class frmAccountShortInfo
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
            this.ctrlAccountShortInfo1 = new SmartBank_UI.Accounts.Accounts_User_Controls.ctrlAccountShortInfo();
            this.SuspendLayout();
            // 
            // ctrlAccountShortInfo1
            // 
            this.ctrlAccountShortInfo1.BackColor = System.Drawing.Color.MidnightBlue;
            this.ctrlAccountShortInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAccountShortInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAccountShortInfo1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrlAccountShortInfo1.Name = "ctrlAccountShortInfo1";
            this.ctrlAccountShortInfo1.Size = new System.Drawing.Size(471, 367);
            this.ctrlAccountShortInfo1.TabIndex = 0;
            // 
            // frmAccountShortInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 367);
            this.Controls.Add(this.ctrlAccountShortInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAccountShortInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Number";
            this.Load += new System.EventHandler(this.frmAccountShortInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Accounts_User_Controls.ctrlAccountShortInfo ctrlAccountShortInfo1;
    }
}