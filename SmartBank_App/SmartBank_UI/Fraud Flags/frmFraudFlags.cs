using SmartBank;
using SmartBank_BLL;
using SmartBank_UI.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI.Fraud_Flags
{
    public partial class ctrlFraudFlagsMainScreen : UserControl
    {
        private enum enStatusFilter { All, Unresolved, Resolved }

        private List<clsFraudFlags> _allFraudFlags = new List<clsFraudFlags>();
        private List<clsFraudFlags> _fraudFlagsView = new List<clsFraudFlags>();
        private clsFraudFlags _currentFraudFlag = null;
        private enStatusFilter _statusFilter = enStatusFilter.All;
        private bool _isRefreshingData = false;

        public ctrlFraudFlagsMainScreen()
        {
            InitializeComponent();
        }

        private bool _canResolveFlags() => clsGlobal.ActiveUser?.Permissions?.Has(clsPermissions.enPermission.CanResolveFraudFlags) ?? false;

        private void _applyPermissions()
        {
            bool canResolveFlags = _canResolveFlags();
            btnResolveFlag.Visible = canResolveFlags;
            btnManualFlag.Enabled = canResolveFlags;
        }

        private async Task<List<clsFraudFlags>> _loadFraudFlagsList()
        {
            _allFraudFlags = await clsFraudFlags.GetAllFraudFlagsAsync();
            return _allFraudFlags;
        }

        private bool _isHighRisk(clsFraudFlags fraudFlag)
        {
            string text = $"{fraudFlag?.FlagType} {fraudFlag?.Details}".ToLower();
            return text.Contains("rapid") || text.Contains("large") || text.Contains("failed");
        }

        private void _refreshCardsNumbers()
        {
            lblStatTotalValue.Text = _allFraudFlags.Count.ToString();
            lblStatOpenValue.Text = _allFraudFlags.Count(n => !n.IsResolved).ToString();
            lblStatResolvedValue.Text = _allFraudFlags.Count(n => n.IsResolved && n.ResolvedDate.HasValue && n.ResolvedDate.Value.Date == DateTime.Today).ToString();
            lblStatHighRiskValue.Text = _allFraudFlags.Count(_isHighRisk).ToString();
        }

        private bool _isTypeMatchingFilter(clsFraudFlags fraudFlag, string typeFilter)
        {
            if (typeFilter == "All Types")
                return true;

            string flagType = fraudFlag?.FlagType?.Trim() ?? string.Empty;
            return string.Equals(flagType, typeFilter, StringComparison.OrdinalIgnoreCase);
        }

        private string _getRiskLevel(clsFraudFlags fraudFlag)
        {
            string type = fraudFlag?.FlagType?.ToLower() ?? string.Empty;

            if (type.Contains("large") || type.Contains("rapid"))
                return "High";

            if (type.Contains("failed"))
                return "Medium";

            if (type.Contains("manual"))
                return "Low";

            return _isHighRisk(fraudFlag) ? "High" : "Normal";
        }

        private void _clearDetails()
        {
            tbAccount.Text = "N/A";
            tbCustomer.Text = "N/A";
            tbFlaggedDate.Text = "N/A";
            tbDetectedBy.Text = "N/A";
            tbRisk.Text = "N/A";
            tbAccountStatus.Text = "N/A";
            tbDetails.Text = "No details.";
            tbRecentActivity.Text = "No activity.";
            tbResolutionNotes.Text = "No notes.";
            lblRightSub.Text = "No flag selected";

            btnViewAccount.Enabled = false;
            btnKeepOpen.Enabled = false;
            btnResolveFlag.Enabled = false;
        }

        private void _bindGrid(List<clsFraudFlags> fraudFlagsView)
        {
            _fraudFlagsView = fraudFlagsView ?? new List<clsFraudFlags>();
            dgvFraudFlags.Rows.Clear();

            foreach (clsFraudFlags fraudFlag in _fraudFlagsView)
            {
                int rowIndex = dgvFraudFlags.Rows.Add();
                DataGridViewRow row = dgvFraudFlags.Rows[rowIndex];
                row.Tag = fraudFlag.FlagID;

                row.Cells["colFlag"].Value = $"{fraudFlag.FlagType} - {fraudFlag.Account?.AccountNumber ?? "N/A"}";
                row.Cells["colDetails"].Value = string.IsNullOrWhiteSpace(fraudFlag.Details) ? "No details." : fraudFlag.Details;
                row.Cells["colDate"].Value = fraudFlag.FlaggedDate.ToString("g");
                row.Cells["colStatus"].Value = fraudFlag.IsResolved ? "Resolved" : "Unresolved";
            }

            lblLeftFooterCount.Text = $"Showing {_fraudFlagsView.Count} of {_allFraudFlags.Count} fraud flags";
            lblLeftFooterHint.Visible = _fraudFlagsView.Count > 0;

            if (_fraudFlagsView.Count == 0)
            {
                _currentFraudFlag = null;
                _clearDetails();
                return;
            }

            dgvFraudFlags.ClearSelection();
            dgvFraudFlags.Rows[0].Selected = true;
            _loadFraudFlagDetailsFromDGV();
        }

        private void _loadFraudFlagDetails(clsFraudFlags fraudFlag)
        {
            if (fraudFlag == null)
            {
                _clearDetails();
                return;
            }

            tbAccount.Text = fraudFlag.Account?.AccountNumber ?? "N/A";
            tbCustomer.Text = fraudFlag.Account?.Customer == null ? "N/A" : $"{fraudFlag.Account.Customer.FirstName} {fraudFlag.Account.Customer.LastName}".Trim();
            tbFlaggedDate.Text = fraudFlag.FlaggedDate.ToString("g");
            tbDetectedBy.Text = fraudFlag.FlagType == "Manual Review" ? "Manual Flag" : "Monitoring Service";
            tbRisk.Text = _getRiskLevel(fraudFlag);
            tbAccountStatus.Text = fraudFlag.Account?.Status.ToString() ?? "N/A";
            tbDetails.Text = string.IsNullOrWhiteSpace(fraudFlag.Details) ? "No details." : fraudFlag.Details;
            tbRecentActivity.Text = fraudFlag.IsResolved ? $"Resolved at {fraudFlag.ResolvedDate?.ToString("g")}" : "Awaiting resolution.";
            tbResolutionNotes.Text = fraudFlag.IsResolved
                ? $"Resolved by {fraudFlag.ResolvedByUser?.FullName ?? "Unknown"} at {fraudFlag.ResolvedDate?.ToString("g")}"
                : "No notes.";

            lblRightSub.Text = $"Selected: {fraudFlag.FlagType}";

            btnViewAccount.Enabled = fraudFlag.Account != null;
            btnKeepOpen.Enabled = !fraudFlag.IsResolved;
            btnResolveFlag.Enabled = !fraudFlag.IsResolved && _canResolveFlags();
        }

        private void _loadFraudFlagDetailsFromDGV()
        {
            if (dgvFraudFlags.CurrentRow?.Tag == null)
            {
                _currentFraudFlag = null;
                _clearDetails();
                return;
            }

            int flagID = Convert.ToInt32(dgvFraudFlags.CurrentRow.Tag);
            _currentFraudFlag = _fraudFlagsView.FirstOrDefault(n => n.FlagID == flagID);
            _loadFraudFlagDetails(_currentFraudFlag);
        }

        private void tbSearch_EnterLeave(object sender, System.EventArgs e)
        {
            string filterTag = tbSearch.Tag.ToString();
            tbSearch.Text = tbSearch.Focused && tbSearch.Text == filterTag ? string.Empty : !tbSearch.Focused && string.IsNullOrWhiteSpace(tbSearch.Text) ? filterTag : tbSearch.Text;
            tbSearch.ForeColor = tbSearch.Text == filterTag ? Color.DimGray : Color.White;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvFraudFlags == null || dgvFraudFlags.Rows.Count == 0)
            {
                MessageBox.Show("No fraud flags to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    var columns = dgvFraudFlags.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();
                    sw.WriteLine(string.Join(",", columns.Select(c => c.HeaderText)));

                    foreach (DataGridViewRow row in dgvFraudFlags.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        sw.WriteLine(string.Join(",", columns.Select(c => $"\"{(Convert.ToString(row.Cells[c.Name].Value) ?? string.Empty).Replace("\"", "\"\"")}\"")));
                    }
                }

                MessageBox.Show("Fraud flags exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
