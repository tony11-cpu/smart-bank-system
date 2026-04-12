using SmartBank;
using SmartBank_BLL;
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
    public partial class ctrlDashboard : UserControl
    {
        public ctrlDashboard()
        {
            InitializeComponent();
        }

        private void ctrlDashboard_Load(object sender, EventArgs e)
        {
            if(LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            lblMorningToUserWithName.Text = $"Good Morning, {clsGlobal.ActiveUser.FullName}. Here is everything you need to start your shift. ";
            lblActiveAccounts.Text = clsAccounts.NumberOfActiveAccounts.ToString();
        }
    }
}
