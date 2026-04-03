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

namespace SmartBank_UI.System_Config
{
    public partial class ctrlMainSysConfigScreen : UserControl
    {
        public ctrlMainSysConfigScreen()
        {
            InitializeComponent();
        }

        private void _loadDefault()
        {
            lblNumberOfChnages.Text = "0 unsaved changes";
            lblNumberOfChnages.ForeColor = Color.FromArgb(0, 192, 0);
            pnlChnages.BackColor = Color.DarkGreen;

            nupNumberOfLogin.Value = clsConfigurations.MaxLoginAttempts;
            nupWithdrawalThreshold.Value = clsConfigurations.LargeWithdrawalThreshold;
            nupRapidTransaction.Value = clsConfigurations.RapidTransactionWindowMinutes;
            nupRapidTransactionMax.Value = clsConfigurations.RapidTransactionMaxCount;
            tbTellerPermissions.Text = clsPermissions.TellerPermissions.ToString();
            tbManagerPermissions.Text = clsPermissions.ManagerPermissions.ToString();
            tbAdminPermissions.Text = clsPermissions.AdminPermissions.ToString();
            nupServiceCheckIntervel.Value = clsConfigurations.ScheduledTransferCheckIntervalSeconds;
        }

        private void ctrlMainSysConfigScreen_Load(object sender, EventArgs e)
        {
            _loadDefault();

            // 1)Service changes configuration values updated in the UI accordingly

            if(clsUtil.IsDatabaseConnected())
            {
                lblIsDataBaseConnected.Text = "Connected";
                lblIsDataBaseConnected.ForeColor = Color.Green;
            }
            else
            {
                lblIsDataBaseConnected.Text = "Not Connected";
                lblIsDataBaseConnected.ForeColor = Color.Red;
            }
        }
    }
}
