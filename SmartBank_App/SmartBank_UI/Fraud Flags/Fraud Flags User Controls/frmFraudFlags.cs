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

        private bool _hasViewPermissions() => clsGlobal.ActiveUser?.Permissions?.Has(clsPermissions.enPermission.CanViewFraudFlags) ?? false;
        private bool _canResolveFlags() => clsGlobal.ActiveUser?.Permissions?.Has(clsPermissions.enPermission.CanResolveFraudFlags) ?? false;

        private void _applyPermissions()
        {
            bool canView = _hasViewPermissions();
            bool canResolveFlags = _canResolveFlags();

            btnExport.Enabled = canView;
            btnResolveFlag.Visible = canResolveFlags;
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

            return string.Equals(_mapFilterTypeToStoredType(typeFilter),
                                 (fraudFlag?.FlagType ?? string.Empty).Trim(),
                                 StringComparison.OrdinalIgnoreCase);
        }

        private string _mapFilterTypeToStoredType(string filterType)
        {
            switch ((filterType ?? string.Empty).Trim())
            {
                case "Rapid Transactions":
                    return "RAPID_TRANSACTIONS";
                case "Large Withdrawal":
                    return "LARGE_WITHDRAWAL";
                case "Manual Review":
                    return "RECONCILIATION_MISMATCH";
                default:
                    return (filterType ?? string.Empty).Trim();
            }
        }

        private string _mapStoredTypeToDisplayType(string storedType)
        {
            switch ((storedType ?? string.Empty).Trim().ToUpper())
            {
                case "RAPID_TRANSACTIONS":
                    return "Rapid Transactions";
                case "LARGE_WITHDRAWAL":
                    return "Large Withdrawal";
                case "RECONCILIATION_MISMATCH":
                    return "Manual Review";
                case "OFF_HOURS":
                    return "Off Hours";
                case "REPEATED_FAILURE":
                    return "Repeated Failure";
                default:
                    return storedType ?? string.Empty;
            }
        }

        private string _getRiskLevel(clsFraudFlags fraudFlag)
        {
            string type = fraudFlag?.FlagType?.ToLower() ?? string.Empty;

            if (type.Contains("large") || type.Contains("rapid"))
                return "High";

            if (type.Contains("failed"))
                return "Medium";

            if (type.Contains("manual") || type.Contains("reconciliation"))
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
                DataGridViewRow row = dgvFraudFlags.Rows[dgvFraudFlags.Rows.Add()];
                row.Tag = fraudFlag.FlagID;

                row.Cells["colFlag"].Value = $"{_mapStoredTypeToDisplayType(fraudFlag.FlagType)} - {fraudFlag.Account?.AccountNumber ?? "N/A"}";
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
            tbDetectedBy.Text = string.Equals(fraudFlag.FlagType, "RECONCILIATION_MISMATCH", StringComparison.OrdinalIgnoreCase) ? "Manual Flag" : "Monitoring Service";
            tbRisk.Text = _getRiskLevel(fraudFlag);
            tbAccountStatus.Text = fraudFlag.Account?.Status.ToString() ?? "N/A";
            tbDetails.Text = string.IsNullOrWhiteSpace(fraudFlag.Details) ? "No details." : fraudFlag.Details;
            tbRecentActivity.Text = fraudFlag.IsResolved ? $"Resolved at {fraudFlag.ResolvedDate?.ToString("g")}" : "Awaiting resolution.";
            tbResolutionNotes.Text = fraudFlag.IsResolved ? $"Resolved by {fraudFlag.ResolvedByUser?.FullName ?? "Unknown"} at {fraudFlag.ResolvedDate?.ToString("g")}" : "No notes.";
            lblRightSub.Text = $"Selected: {_mapStoredTypeToDisplayType(fraudFlag.FlagType)}";
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

            _currentFraudFlag = _fraudFlagsView.FirstOrDefault(n => n.FlagID == Convert.ToInt32(dgvFraudFlags.CurrentRow.Tag));
            _loadFraudFlagDetails(_currentFraudFlag);
        }

        private void _applyFilter()
        {
            IEnumerable<clsFraudFlags> filtered = _allFraudFlags;

            if (_statusFilter == enStatusFilter.Unresolved)
                filtered = filtered.Where(n => !n.IsResolved);
            else if (_statusFilter == enStatusFilter.Resolved)
                filtered = filtered.Where(n => n.IsResolved);

            if (cbType.SelectedItem != null)
                filtered = filtered.Where(n => _isTypeMatchingFilter(n, cbType.SelectedItem.ToString()));

            string search = tbSearch.Text.Trim();
            if (!string.IsNullOrWhiteSpace(search) && !string.Equals(search, tbSearch.Tag.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                filtered = filtered.Where(n =>
                {
                    string scope = $"{n.Account?.AccountNumber} {n.Account?.Customer?.FirstName} {n.Account?.Customer?.LastName} {n.FlagType} {n.Details}";
                    return scope.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
                });
            }

            _bindGrid(filtered.ToList());
        }

        private async Task _refreshDataAsync()
        {
            if (_isRefreshingData || !Visible)
                return;

            try
            {
                _isRefreshingData = true;
                await _loadFraudFlagsList();
                _refreshCardsNumbers();
                _applyFilter();
            }
            finally
            {
                _isRefreshingData = false;
            }
        }

        private async void ctrlFraudFlagsMainScreen_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            dgvFraudFlags.RowTemplate.Height = 35;
            dgvFraudFlags.ColumnHeadersHeight = 40;

            cbType.SelectedIndex = 0;
            _applyPermissions();
            _clearDetails();

            if (!_hasViewPermissions())
            {
                MessageBox.Show("You don't have permission to view fraud flags.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnExport.Enabled = false;
                btnViewAccount.Enabled = false;
                btnKeepOpen.Enabled = false;
                btnResolveFlag.Enabled = false;
                return;
            }

            await _refreshDataAsync();
        }

        private async void ctrlFraudFlagsMainScreen_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible || LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            if (!_hasViewPermissions())
                return;

            await _refreshDataAsync();
        }

        private void tbSearch_EnterLeave(object sender, System.EventArgs e)
        {
            string filterTag = tbSearch.Tag.ToString();
            tbSearch.Text = tbSearch.Focused && tbSearch.Text == filterTag ? string.Empty : !tbSearch.Focused && string.IsNullOrWhiteSpace(tbSearch.Text) ? filterTag : tbSearch.Text;
            tbSearch.ForeColor = tbSearch.Text == filterTag ? Color.DimGray : Color.White;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e) => _applyFilter();

        private void btnFilterAll_Click(object sender, EventArgs e)
        {
            _statusFilter = enStatusFilter.All;
            _applyFilter();
        }

        private void btnFilterOpen_Click(object sender, EventArgs e)
        {
            _statusFilter = enStatusFilter.Unresolved;
            _applyFilter();
        }

        private void btnFilterResolved_Click(object sender, EventArgs e)
        {
            _statusFilter = enStatusFilter.Resolved;
            _applyFilter();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e) => _applyFilter();

        private void dgvFraudFlags_CellClick(object sender, DataGridViewCellEventArgs e) => _loadFraudFlagDetailsFromDGV();

        private void btnKeepOpen_Click(object sender, EventArgs e)
        {
            if (_currentFraudFlag == null)
            {
                MessageBox.Show("Please select a flag first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentFraudFlag.IsResolved)
            {
                MessageBox.Show("Selected flag is already resolved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            tbResolutionNotes.Text = "Left unresolved for additional monitoring.";
            MessageBox.Show("Flag remains unresolved.", "Fraud Flag", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentFraudFlag?.Account?.AccountNumber))
            {
                MessageBox.Show("No account is available for this flag.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAccountShortInfo frm = new frmAccountShortInfo(_currentFraudFlag.Account.AccountNumber);
            frm.ShowDialog();
        }

        private async void btnResolveFlag_Click(object sender, EventArgs e)
        {
            if (_currentFraudFlag == null)
            {
                MessageBox.Show("Please select a flag first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_canResolveFlags())
            {
                MessageBox.Show("You do not have permission to resolve flags.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentFraudFlag.IsResolved)
            {
                MessageBox.Show("Flag is already resolved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to resolve this flag?", "Confirm Resolve", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                if (await _currentFraudFlag.ResolveAsync())
                {
                    MessageBox.Show("Flag resolved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _refreshDataAsync();
                }
                else
                {
                    MessageBox.Show("Failed to resolve flag.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to resolve flag: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
