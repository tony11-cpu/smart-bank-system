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
using static SmartBank_BLL.clsConfigurations;

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

            nupNumberOfLogin.Value = GetConfigValue(enConfigKey.MaxLoginAttempts) ?? 0;
            nupWithdrawalThreshold.Value = GetConfigValue(enConfigKey.LargeWithdrawalThreshold) ?? 0;
            nupRapidTransaction.Value = GetConfigValue(enConfigKey.RapidTransactionWindowMinutes) ?? 0;
            nupRapidTransactionMax.Value = GetConfigValue(enConfigKey.RapidTransactionMaxCount) ?? 0;
            tbTellerPermissions.Text = clsPermissions.TellerPermissions.ToString();
            tbManagerPermissions.Text = clsPermissions.ManagerPermissions.ToString();
            tbAdminPermissions.Text = clsPermissions.AdminPermissions.ToString();
            nupServiceCheckIntervel.Value = GetConfigValue(enConfigKey.ScheduledTransferCheckIntervalSeconds) ?? 0;
        }

        private void ctrlMainSysConfigScreen_Load(object sender, EventArgs e)
        {
            _loadDefault();

            // 1)Service changes configuration values updated in the UI accordingly

            if(clsUtil.IsDatabaseConnected())
            {
                lblIsDataBaseConnected.Text = "Connected";
                lblIsDataBaseConnected.ForeColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                lblIsDataBaseConnected.Text = "Not Connected";
                lblIsDataBaseConnected.ForeColor = Color.Red;
            }
        }
    }
}
