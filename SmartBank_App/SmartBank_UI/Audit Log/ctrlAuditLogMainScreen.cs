using SmartBank;
using SmartBank_BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI.Audit_Log
{
    public partial class ctrlAuditLogMainScreen : UserControl
    {
        private List<clsAuditLog> _allAuditLogs = new List<clsAuditLog>();
        private List<clsAuditLog> _auditLogsView = new List<clsAuditLog>();

        public ctrlAuditLogMainScreen()
        {
            InitializeComponent();
        }

        private void _loadForm()
        {
            dtpFromDate.Value = DateTime.Today;
            cbActionFilter.SelectedIndex = 0;
            cbResultFilter.SelectedIndex = 0;
            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.FileName = $"audit_logs_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
        }

        private async void ctrlAuditLogMainScreen_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            _loadForm();
            if (!_hasViewPermissions())
            {
                MessageBox.Show("You don't have permission to view audit logs.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _applyPermissions();
            await _reloadAuditLogs();
        }

        private bool _hasViewPermissions() => clsGlobal.ActiveUser?.Permissions?.Has(clsPermissions.enPermission.CanViewAuditLog) ?? false;

        private void _applyPermissions()
        {
            bool canView = _hasViewPermissions();
            bool canExport = clsGlobal.ActiveUser?.Permissions?.Has(clsPermissions.enPermission.CanExportAuditLog) ?? false;

            btnExportCsv.Enabled = canExport;
            btnCopyAuditID.Enabled = canView;
        }

        private async Task _reloadAuditLogs()
        {
            _allAuditLogs = await clsAuditLog.GetAllAuditLogsAsync();
            _refreshCardsNumbers(_allAuditLogs);
            _applyFillter();
        }

        private void _refreshCardsNumbers(List<clsAuditLog> logs)
        {
            lblStatTodayValue.Text = logs.Count(n => n.Timestamp.Date == DateTime.Today).ToString();
            lblStatSensitiveValue.Text = logs.Count(n => !string.IsNullOrWhiteSpace(n.OldValue) || !string.IsNullOrWhiteSpace(n.NewValue)).ToString();
            lblStatSecurityValue.Text = logs.Count(n => _isSecurityAction(n.Action ?? string.Empty)).ToString();
            lblStatFailedValue.Text = logs.Count(n => _getResultTypeByAction(n.Action ?? string.Empty) == "Failed").ToString();
        }

        private void _applyFillter()
        {
            IEnumerable<clsAuditLog> filteredLogs = _allAuditLogs ?? new List<clsAuditLog>();
            string search = tbSearchBar.Text.Trim();
            string filterTag = tbSearchBar.Tag?.ToString() ?? string.Empty;

            filteredLogs = filteredLogs.Where(n => n.Timestamp.Date >= dtpFromDate.Value.Date);

            if (cbActionFilter.SelectedIndex > 0)
            {
                string actionFilter = cbActionFilter.SelectedItem.ToString();
                filteredLogs = filteredLogs.Where(n => (n.Action ?? string.Empty).IndexOf(actionFilter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                       (n.EntityType ?? string.Empty).IndexOf(actionFilter, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (cbResultFilter.SelectedIndex > 0)
            {
                string resultFilter = cbResultFilter.SelectedItem.ToString();
                filteredLogs = filteredLogs.Where(n => _getResultTypeByAction(n.Action ?? string.Empty) == resultFilter);
            }

            if (!string.IsNullOrWhiteSpace(search) && !search.Equals(filterTag, StringComparison.OrdinalIgnoreCase))
            {
                search = search.ToLower();
                filteredLogs = filteredLogs.Where(n =>
                {
                    string searchText = $"{n.AuditID} AUD-{n.AuditID:D6} {n.Username} {n.Action} {n.EntityType} {n.EntityID}";
                    return searchText.ToLower().Contains(search);
                });
            }

            _bindGridToAuditDGV(filteredLogs.OrderByDescending(n => n.Timestamp).ToList());
        }

        private bool _isSecurityAction(string action)
        {
            action = action.ToUpper();
            return action.Contains("LOGIN") || action.Contains("LOCK") || action.Contains("UNLOCK") ||
                   action.Contains("PASSWORD") || action.Contains("SECURITY");
        }

        private string _getResultTypeByAction(string action)
        {
            action = action.ToUpper();
            if (action.Contains("FAIL") || action.Contains("ERROR") || action.Contains("DENIED") || action.Contains("REJECT"))
                return "Failed";

            if (action.Contains("WARN"))
                return "Warning";

            return "Success";
        }

        private void _bindGridToAuditDGV(List<clsAuditLog> logsView)
        {
            logsView = logsView ?? new List<clsAuditLog>();
            _auditLogsView = logsView;

            dgvAuditTrail.DataSource = logsView.Select(n => new
            {
                n.AuditID, User = string.IsNullOrWhiteSpace(n.Username) ? "System" : n.Username, n.Action,
                Entity = n.EntityType, RecordID = n.EntityID, Result = _getResultTypeByAction(n.Action ?? string.Empty),
                TimeStamp = n.Timestamp, n.Notes
            }).ToList();

            int count = logsView.Count;
            lblNumberOfAuditLogs.Text = $"Showing {count} audit record{(count == 1 ? string.Empty : "s")}";
            lblClickToInspectAudit.Visible = count > 0;

            if (dgvAuditTrail.RowCount == 0)
            {
                _clearDetails();
                return;
            }

            dgvAuditTrail.Columns["AuditID"].HeaderText = "Audit ID";
            dgvAuditTrail.Columns["RecordID"].HeaderText = "Record ID";
            dgvAuditTrail.Columns["TimeStamp"].HeaderText = "Time Stamp";

            dgvAuditTrail.RowTemplate.Height = 35;
            dgvAuditTrail.ColumnHeadersHeight = 40;

            _loadAuditDetailsByAuditID(logsView[0].AuditID);
        }

        private void tbSearchBar_EnterLeave(object sender, EventArgs e)
        {
            string filterTag = tbSearchBar.Tag.ToString();
            if (tbSearchBar.Focused)
            {
                if (tbSearchBar.Text == filterTag)
                    tbSearchBar.Text = string.Empty;

                _resetMainFillters();
                _applyFillter();
            }
            else if (string.IsNullOrWhiteSpace(tbSearchBar.Text))
                tbSearchBar.Text = filterTag;

            tbSearchBar.ForeColor = tbSearchBar.Text == filterTag ? Color.DimGray : Color.White;
        }

        private void _resetMainFillters()
        {
            cbActionFilter.SelectedIndex = 0;
            cbResultFilter.SelectedIndex = 0;
            dtpFromDate.Value = _allAuditLogs.Any() ? _allAuditLogs.Min(n => n.Timestamp).Date : DateTime.Today;
        }

        private void filter_Changed(object sender, EventArgs e) => _applyFillter();

        private void dgvAuditTrail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAuditTrail.CurrentRow?.Cells["AuditID"]?.Value == null)
                return;

            _loadAuditDetailsByAuditID(Convert.ToInt32(dgvAuditTrail.CurrentRow.Cells["AuditID"].Value));
        }

        private void _loadAuditDetailsByAuditID(int auditID)
        {
            clsAuditLog selectedLog = _auditLogsView.FirstOrDefault(n => n.AuditID == auditID);
            if (selectedLog == null)
                selectedLog = _allAuditLogs.FirstOrDefault(n => n.AuditID == auditID);

            if (selectedLog == null)
            {
                _clearDetails();
                return;
            }

            tbAuditID.Text = $"AUD-{selectedLog.AuditID:D6}";
            tbResult.Text = _getResultTypeByAction(selectedLog.Action ?? string.Empty);
            tbUser.Text = string.IsNullOrWhiteSpace(selectedLog.Username) ? "System" : selectedLog.Username;
            tbRole.Text = selectedLog.UserID.HasValue ? "User" : "System";
            tbEntity.Text = selectedLog.EntityType ?? "N/A";
            tbRecordID.Text = selectedLog.EntityID.HasValue ? selectedLog.EntityID.Value.ToString() : "N/A";
            tbDescription.Text = string.IsNullOrWhiteSpace(selectedLog.Action) ? "No Description" : selectedLog.Action.Replace("_", " ");
            tbOldValue.Text = string.IsNullOrWhiteSpace(selectedLog.OldValue) ? "NULL" : selectedLog.OldValue;
            tbNewValue.Text = string.IsNullOrWhiteSpace(selectedLog.NewValue) ? "NULL" : selectedLog.NewValue;
            tbTimestamp.Text = selectedLog.Timestamp.ToString("MM/dd/yyyy HH:mm:ss");

            lblAuditSubTitle.Text = $"Selected Action: {tbDescription.Text}";
        }

        private void _clearDetails()
        {
            tbAuditID.Text = "AUD-000000";
            tbResult.Text = "Result";
            tbUser.Text = "User";
            tbRole.Text = "Role";
            tbEntity.Text = "Entity";
            tbRecordID.Text = "REC-000";
            tbDescription.Text = "Audit action description";
            tbOldValue.Text = "Previous state";
            tbNewValue.Text = "Updated state";
            tbTimestamp.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            lblAuditSubTitle.Text = "Select an audit record to inspect.";
        }

        private void btnCopyAuditID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAuditID.Text))
                return;

            Clipboard.SetText(tbAuditID.Text.Trim());
            MessageBox.Show("Audit ID copied.", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void ctrlAuditLogMainScreen_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible || DesignMode)
                return;

            if (!_hasViewPermissions())
                return;

            _applyPermissions();
            await _reloadAuditLogs();
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (dgvAuditTrail == null || dgvAuditTrail.Rows.Count == 0)
            {
                MessageBox.Show("No audit logs to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    var columns = dgvAuditTrail.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();
                    sw.WriteLine(string.Join(",", columns.Select(c => c.HeaderText)));

                    foreach (DataGridViewRow row in dgvAuditTrail.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        sw.WriteLine(string.Join(",", columns.Select(c =>
                        {
                            string value = Convert.ToString(row.Cells[c.Name].Value);
                            return $"\"{value?.Replace("\"", "\"\"")}\"";
                        })));
                    }
                }

                MessageBox.Show("Audit logs exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
