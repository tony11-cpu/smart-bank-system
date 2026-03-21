using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI
{
    public partial class frmAddOrUpdateCustomers : Form
    {
        private string _nationalID = null;

        public frmAddOrUpdateCustomers() => InitializeComponent();

        public frmAddOrUpdateCustomers(string nationalID)
        {
            InitializeComponent();
            _nationalID = nationalID;
        }

        private void frmAddOrUpdateCustomers_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode) return;

            if(_nationalID != null)
               ctrlAddOrUpdateCustomer1.LoadCustomer(_nationalID);
        }
    }
}
