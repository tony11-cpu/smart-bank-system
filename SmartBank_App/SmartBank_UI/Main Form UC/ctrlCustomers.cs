using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI.Main_Form_UC
{
    public partial class ctrlCustomers : UserControl
    {
        public ctrlCustomers()
        {
            InitializeComponent();
        }

        private void ctrlCustomers_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode) return;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateCustomers frmAddOrUpdateCustomers = new frmAddOrUpdateCustomers();
            frmAddOrUpdateCustomers.ShowDialog();
        }

        private void tbSearchBar_EnterLeave(object sender, EventArgs e)
        {
            string deafult = "Search by name,phone , or last 4 digits of National ID...";
            bool entering = tbSearchBar.Focused;
            tbSearchBar.Text = entering && tbSearchBar.Text == deafult ? 
                string.Empty : !entering && string.IsNullOrWhiteSpace(tbSearchBar.Text) ? deafult : tbSearchBar.Text;

            tbSearchBar.ForeColor = tbSearchBar.Text == deafult ? Color.DimGray : Color.White;
        }
    }
}
