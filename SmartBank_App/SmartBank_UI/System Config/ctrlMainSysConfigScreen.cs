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
        private int _unsavedChangesCount = 0;
        private bool _isReady = false;
        private readonly (NumericUpDown Control, enConfigKey Key)[] _fields;
        private Dictionary<enConfigKey, (int Saved, bool Changed)> _changes = new Dictionary<enConfigKey, (int Saved, bool Changed)>();

        public ctrlMainSysConfigScreen()
        {
            InitializeComponent();
            _fields = new (NumericUpDown, enConfigKey)[]
            {
                (nupNumberOfLogin,        enConfigKey.MaxLoginAttempts),
                (nupWithdrawalThreshold,  enConfigKey.LargeWithdrawalThreshold),
                (nupRapidTransaction,     enConfigKey.RapidTransactionWindowMinutes),
                (nupRapidTransactionMax,  enConfigKey.RapidTransactionMaxCount),
                (nupServiceCheckIntervel, enConfigKey.ScheduledTransferCheckIntervalSeconds),
            };
        }

        private async Task _loadDefault()
        {
            foreach (var f in _fields)
            {
                int val = (await clsConfigurations.GetConfigValueAsync(f.Key)).Value;
                f.Control.Value = val;
                _changes[f.Key] = (val, false);
            }

            _unsavedChangesCount = 0;
            _loadChanges(0);
            tbTellerPermissions.Text = clsPermissions.TellerPermissions.ToString();
            tbManagerPermissions.Text = clsPermissions.ManagerPermissions.ToString();
            tbAdminPermissions.Text = clsPermissions.AdminPermissions.ToString();
        }

        private async Task _loadForm()
        {
            await _loadDefault();
            if (clsUtil.IsDatabaseConnected())
            {
                lblIsDataBaseConnected.Text = "Connected";
                lblIsDataBaseConnected.ForeColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                lblIsDataBaseConnected.Text = "Not Connected";
                lblIsDataBaseConnected.ForeColor = Color.Red;
            }

            lblTotalActiveAccountsCount.Text = (await clsAccounts.NumberOfActiveAccountsAsync()).ToString();
            lblTotalUsersCount.Text = (await clsUsers.GetAllUsersAsync()).Count.ToString();
        }

        private void _loadChanges(int unsavedChangesCount)
        {
            if (unsavedChangesCount != 0)
            {
                lblNumberOfChnages.ForeColor = Color.Orange;
                pnlChnages.BackColor = Color.FromArgb(128, 64, 64);
            }
            else
            {
                lblNumberOfChnages.ForeColor = Color.FromArgb(0, 192, 0);
                pnlChnages.BackColor = Color.FromArgb(0, 64, 0);
            }

            lblNumberOfChnages.Text = $"{unsavedChangesCount} unsaved change{(unsavedChangesCount != 1 ? "s" : "")}";
        }

        private void _handleValueChanged(enConfigKey key, decimal newValue)
        {
            if (!_changes.ContainsKey(key)) 
                return;

            bool isDifferent = newValue != _changes[key].Saved;

            if (isDifferent && !_changes[key].Changed)
                _unsavedChangesCount++;
            else if (!isDifferent && _changes[key].Changed)
                _unsavedChangesCount--;

            _changes[key] = (_changes[key].Saved, isDifferent);
            _loadChanges(_unsavedChangesCount);
        }

        private async void ctrlMainSysConfigScreen_Load(object sender, EventArgs e)
        {
            _isReady = true;
            await _loadForm();
        }

        private async void ctrlMainSysConfigScreen_VisibleChanged(object sender, EventArgs e)
        {
            if (!_isReady) 
                return;

            await _loadForm();
        }

        private async void btnResetToDefault_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset all configuration values to their default settings? This action cannot be undone.", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            if (await clsConfigurations.ResetToDefaultAsync())
            {
                await _loadDefault();
                MessageBox.Show("All configurations have been reset to their default values successfully.", "Reset Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("An error occurred while resetting configurations to default. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void nupNumberOfLogin_ValueChanged(object sender, EventArgs e) => _handleValueChanged(enConfigKey.MaxLoginAttempts, nupNumberOfLogin.Value);
        
        private void nupWithdrawalThreshold_ValueChanged(object sender, EventArgs e) => _handleValueChanged(enConfigKey.LargeWithdrawalThreshold, nupWithdrawalThreshold.Value);
        
        private void nupRapidTransaction_ValueChanged(object sender, EventArgs e) => _handleValueChanged(enConfigKey.RapidTransactionWindowMinutes, nupRapidTransaction.Value);
       
        private void nupRapidTransactionMax_ValueChanged(object sender, EventArgs e) => _handleValueChanged(enConfigKey.RapidTransactionMaxCount, nupRapidTransactionMax.Value);
       
        private void nupServiceCheckIntervel_ValueChanged(object sender, EventArgs e) => _handleValueChanged(enConfigKey.ScheduledTransferCheckIntervalSeconds, nupServiceCheckIntervel.Value);

        private async void btnSaveConfigs_Click(object sender, EventArgs e)
        {
            if (_unsavedChangesCount == 0)
            {
                MessageBox.Show("There are no changes to save.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var f in _fields)
            {
                if (!_changes[f.Key].Changed)
                    continue;

                clsConfigurations config = await clsConfigurations.FindAsync(f.Key);
                config.ConfigValue = (int)f.Control.Value;

                try
                {
                    if (!await config.UpdateAsync())
                    {
                        MessageBox.Show($"An error occurred while updating {f.Key}. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while updating {f.Key}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            await _loadDefault();
            MessageBox.Show("All changes have been saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
