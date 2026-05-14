using SmartBank;
using SmartBank_BLL;
using System;
using System.Collections.Generic;
using System.Data;
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
        private const int _loginAttemptAuditBaseID = 900000000;

        public ctrlAuditLogMainScreen()
        {
            InitializeComponent();
        }

        private void _loadForm()
        {
            dtpFromDate.Value = DateTime.Today;
            cbActionFilter.SelectedIndex = 0;
            cbResultFilter.SelectedIndex = 0;
            _setTextboxStates(tbSearchBar, true, false);
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
                btnExportCsv.Enabled = false;
                btnCopyAuditID.Enabled = false;
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
            _allAuditLogs.AddRange(await _getLoginAttemptsAuditLogsAsync());
            _refreshCardsNumbers(_allAuditLogs);
            _applyFillter();
        }

        private async Task<List<clsAuditLog>> _getLoginAttemptsAuditLogsAsync()
        {
            List<clsAuditLog> loginAuditLogs = new List<clsAuditLog>();
            DataTable dt = await clsUsers.GetAllLoginAttemptsAsync();
            if (dt == null || dt.Rows.Count == 0)
                return loginAuditLogs;

            foreach (DataRow row in dt.Rows)
            {
                int userID = Convert.ToInt32(row["UserID"]);
                loginAuditLogs.Add(new clsAuditLog(_loginAttemptAuditBaseID + Convert.ToInt32(row["AttemptID"]), userID, row["Username"] == DBNull.Value ? "Unknown User" : row["Username"].ToString(),
                                       Convert.ToBoolean(row["WasSuccessful"]) ? "LOGIN_SUCCESS" : "LOGIN_FAILED", "Users", userID, null, null, Convert.ToDateTime(row["AttemptDate"]), "LoginAttempts"));
            }

            return loginAuditLogs;
        }

        private void _refreshCardsNumbers(List<clsAuditLog> logs)
        {
            lblStatTodayValue.Text = logs.Count(n => n.Timestamp.Date == DateTime.Today).ToString();
            lblStatSensitiveValue.Text = logs.Count(n => _isSensitiveLog(n)).ToString();
            lblStatSecurityValue.Text = logs.Count(n => _isSecurityAction(n)).ToString();
            lblStatFailedValue.Text = logs.Count(n => _getResultTypeByAction(n) == "Failed").ToString();
        }

        private void _applyFillter()
        {
            IEnumerable<clsAuditLog> filteredLogs = _allAuditLogs ?? new List<clsAuditLog>();
            string search = tbSearchBar.Text.Trim();
            string filterTag = _getTextboxTagText(tbSearchBar);

            filteredLogs = filteredLogs.Where(n => n.Timestamp.Date == dtpFromDate.Value.Date);

            if (cbActionFilter.SelectedIndex > 0)
            {
                string actionFilter = cbActionFilter.SelectedItem.ToString();
                filteredLogs = filteredLogs.Where(n => _isActionMatchingFilter(n, actionFilter));
            }

            if (cbResultFilter.SelectedIndex > 0)
            {
                string resultFilter = cbResultFilter.SelectedItem.ToString();
                filteredLogs = filteredLogs.Where(n => _getResultTypeByAction(n) == resultFilter);
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

        private bool _isIdle(TextBox sender) => sender.Tag.ToString().StartsWith("Idle");

        private string _getTextboxTagText(TextBox textBox)
        {
            string[] textBoxField = textBox.Tag.ToString().Split('/');
            return textBoxField.Length >= 3 ? textBoxField[2] : textBox.Tag.ToString();
        }

        private void tb_Enter(object sender, EventArgs e) => _setTextboxStates((TextBox)sender, _isIdle((TextBox)sender), true);

        private void _setTextboxStates(TextBox textBox, bool idle, bool entering)
        {
            string[] textBoxField = textBox.Tag.ToString().Split('/');
            if (textBoxField.Length < 3)
                return;

            textBox.Tag = $"{(idle ? "Idle" : "Working")}/{textBoxField[1]}/{textBoxField[2]}";
            textBox.Text = idle ? (entering ? string.Empty : textBoxField[2]) : textBox.Text;
            textBox.ForeColor = entering ? Color.White : Color.DimGray;
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string[] textBoxFields = tb.Tag.ToString().Split('/');
            if (!string.IsNullOrWhiteSpace(tb.Text) && tb.Text.Trim() != textBoxFields[2])
            {
                tb.Tag = $"Working/{textBoxFields[1]}/{textBoxFields[2]}";
                return;
            }

            _setTextboxStates(tb, true, false);
        }

        private bool _isActionMatchingFilter(clsAuditLog log, string actionFilter)
        {
            string action = (log.Action ?? string.Empty).ToUpper();
            string entityType = (log.EntityType ?? string.Empty).ToUpper();

            switch (actionFilter)
            {
                case "Customer":
                    return action.Contains("CUSTOMER") || entityType.Contains("CUSTOMER");

                case "Account":
                    return action.Contains("ACCOUNT") || entityType.Contains("ACCOUNT");

                case "Transaction":
                    return action.Contains("DEPOSIT") || action.Contains("WITHDRAW") || action.Contains("TRANSFER") ||
                           action.Contains("TRANSFARE") || action.Contains("SCHEDULE") || entityType.Contains("TRANSACTION");

                case "Security":
                    return _isSecurityAction(log);

                case "Permission":
                    return action.Contains("PERMISSION") || action.Contains("ROLE");

                case "Config":
                    return action.Contains("CONFIG") || entityType.Contains("CONFIG") || action.Contains("SYSTEM");

                default:
                    return true;
            }
        }

        private bool _isSensitiveLog(clsAuditLog log)
        {
            string action = (log.Action ?? string.Empty).ToUpper();
            string entityType = (log.EntityType ?? string.Empty).ToUpper();

            if (action.Contains("PASSWORD") || action.Contains("SALT") || action.Contains("PERMISSION") ||
                action.Contains("NATIONALID") || action.Contains("IMAGE") || action.Contains("LOCK") ||
                action.Contains("UNLOCK") || action.Contains("LOGIN") || action.Contains("USER_UPDATED") ||
                entityType.Contains("USERS") || entityType.Contains("SYSTEMCONFIG"))
                return true;

            return !string.IsNullOrWhiteSpace(log.OldValue) && !string.IsNullOrWhiteSpace(log.NewValue);
        }

        private bool _isSecurityAction(clsAuditLog log)
        {
            string text = $"{log.Action} {log.Notes}".ToUpper();
            return text.Contains("LOGIN") || text.Contains("LOCK") || text.Contains("UNLOCK") ||
                   text.Contains("PASSWORD") || text.Contains("SECURITY") || text.Contains("FRAUD") ||
                   text.Contains("ATTEMPT") || text.Contains("USER_UPDATED");
        }

        private string _getResultTypeByAction(clsAuditLog log)
        {
            string text = $"{log.Action} {log.Notes}".ToUpper();
            if (text.Contains("LOGIN_SUCCESS"))
                return "Success";

            if (text.Contains("LOGIN_FAILED"))
                return "Failed";

            if (text.Contains("FAIL") || text.Contains("ERROR") || text.Contains("DENIED") || text.Contains("REJECT") ||
                text.Contains("INVALID") || text.Contains("BLOCK"))
                return "Failed";

            if (text.Contains("WARN") || text.Contains("PENDING") || text.Contains("REVIEW"))
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
                Entity = n.EntityType, RecordID = n.EntityID, Result = _getResultTypeByAction(n),
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
            tbResult.Text = _getResultTypeByAction(selectedLog);
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

                        sw.WriteLine(string.Join(",", columns.Select(c => $"\"{Convert.ToString(row.Cells[c.Name].Value)?.Replace("\"", "\"\"")}\"")));
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
