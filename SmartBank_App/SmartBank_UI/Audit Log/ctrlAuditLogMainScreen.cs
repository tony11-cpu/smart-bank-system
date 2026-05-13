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
        private List<clsAuditLog> _lastAuditLogsView = new List<clsAuditLog>();

        public ctrlAuditLogMainScreen()
        {
            InitializeComponent();
            _wireEvents();
        }

        private void _wireEvents()
        {
            tbSearchBar.Enter += tbSearchBar_EnterLeave;
            tbSearchBar.Leave += tbSearchBar_EnterLeave;
            tbSearchBar.TextChanged += mainFilterChanged;
            cbActionFilter.SelectedIndexChanged += mainFilterChanged;
            cbResultFilter.SelectedIndexChanged += mainFilterChanged;
            dtpFromDate.ValueChanged += mainFilterChanged;
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
            if (this.DesignMode)
                return;

            _loadForm();
            await _loadAuditLogsAsync();
        }

        private async Task _loadAuditLogsAsync()
        {
            _allAuditLogs = await clsAuditLog.GetAllAuditLogsAsync();
            _updateCardsNumbers(_allAuditLogs);
            _applyFilters();
        }

        private void _updateCardsNumbers(List<clsAuditLog> logs)
        {
            logs = logs ?? new List<clsAuditLog>();

            lblStatTodayValue.Text = logs.Count(n => n.Timestamp.Date == DateTime.Today).ToString();
            lblStatSensitiveValue.Text = logs.Count(n => !string.IsNullOrWhiteSpace(n.OldValue) || !string.IsNullOrWhiteSpace(n.NewValue)).ToString();
            lblStatSecurityValue.Text = logs.Count(n => _isSecurityAction(n.Action)).ToString();
            lblStatFailedValue.Text = logs.Count(n => _getResultType(n.Action) == "Failed").ToString();
        }

        private void _applyFilters()
        {
            IEnumerable<clsAuditLog> filteredLogs = _allAuditLogs ?? new List<clsAuditLog>();

            string search = tbSearchBar.Text.Trim();
            string searchTag = tbSearchBar.Tag?.ToString() ?? string.Empty;

            filteredLogs = filteredLogs.Where(n => n.Timestamp.Date >= dtpFromDate.Value.Date);

            if (cbActionFilter.SelectedIndex > 0)
                filteredLogs = filteredLogs.Where(n => _matchesActionFilter(n, cbActionFilter.SelectedItem.ToString()));

            if (cbResultFilter.SelectedIndex > 0)
                filteredLogs = filteredLogs.Where(n => _getResultType(n.Action) == cbResultFilter.SelectedItem.ToString());

            if (!string.IsNullOrWhiteSpace(search) && !search.Equals(searchTag, StringComparison.OrdinalIgnoreCase))
            {
                filteredLogs = filteredLogs.Where(n =>
                    (n.Username ?? "System").StartsWith(search, StringComparison.OrdinalIgnoreCase) ||
                    (n.Action ?? string.Empty).StartsWith(search, StringComparison.OrdinalIgnoreCase) ||
                    (n.EntityType ?? string.Empty).StartsWith(search, StringComparison.OrdinalIgnoreCase) ||
                    (n.EntityID?.ToString() ?? string.Empty).StartsWith(search, StringComparison.OrdinalIgnoreCase));
            }

            _bindGrid(filteredLogs.OrderByDescending(n => n.Timestamp).ToList());
        }

        private bool _matchesActionFilter(clsAuditLog log, string actionFilterName)
        {
            string action = (log.Action ?? string.Empty).ToUpper();
            string entity = (log.EntityType ?? string.Empty).ToUpper();

            switch (actionFilterName)
            {
                case "Customer":
                    return action.Contains("CUSTOMER") || entity.Contains("CUSTOMER");

                case "Account":
                    return action.Contains("ACCOUNT") || entity.Contains("ACCOUNT");

                case "Transaction":
                    return action.Contains("DEPOSIT") || action.Contains("WITHDRAW") || action.Contains("TRANSFER") ||
                           action.Contains("TRANSFARE") || action.Contains("TRANSACTION") || entity.Contains("TRANSACTION");

                case "Security":
                    return _isSecurityAction(action);

                case "Permission":
                    return action.Contains("PERMISSION") || action.Contains("ROLE");

                case "Config":
                    return action.Contains("CONFIG") || action.Contains("SYSTEM");

                default:
                    return true;
            }
        }

        private bool _isSecurityAction(string action)
        {
            action = (action ?? string.Empty).ToUpper();
            return action.Contains("LOGIN") || action.Contains("LOCK") || action.Contains("UNLOCK") ||
                   action.Contains("PASSWORD") || action.Contains("SECURITY");
        }

        private string _getResultType(string action)
        {
            action = (action ?? string.Empty).ToUpper();
            if (action.Contains("FAIL") || action.Contains("ERROR") || action.Contains("DENIED") || action.Contains("REJECT"))
                return "Failed";

            if (action.Contains("WARN"))
                return "Warning";

            return "Success";
        }

        private void _bindGrid(List<clsAuditLog> logsView)
        {
            logsView = logsView ?? new List<clsAuditLog>();
            _lastAuditLogsView = logsView;

            dgvAuditTrail.DataSource = logsView.Select(n => new
            {
                n.AuditID,
                User = string.IsNullOrWhiteSpace(n.Username) ? "System" : n.Username,
                n.Action,
                Entity = n.EntityType,
                RecordID = n.EntityID,
                Result = _getResultType(n.Action),
                TimeStamp = n.Timestamp,
                n.Notes
            }).ToList();

            int count = logsView.Count;
            lblNumberOfAuditLogs.Text = $"Showing {count} audit record{(count == 1 ? string.Empty : "s")}";
            lblClickToInspectAudit.Visible = count > 0;

            if (dgvAuditTrail.RowCount == 0)
                return;

            dgvAuditTrail.Columns["AuditID"].HeaderText = "Audit ID";
            dgvAuditTrail.Columns["RecordID"].HeaderText = "Record ID";
            dgvAuditTrail.Columns["TimeStamp"].HeaderText = "Time Stamp";

            dgvAuditTrail.RowTemplate.Height = 35;
            dgvAuditTrail.ColumnHeadersHeight = 40;
        }

        private void tbSearchBar_EnterLeave(object sender, EventArgs e)
        {
            string filterTag = tbSearchBar.Tag.ToString();
            tbSearchBar.Text = tbSearchBar.Focused && tbSearchBar.Text == filterTag ? string.Empty : !tbSearchBar.Focused && string.IsNullOrWhiteSpace(tbSearchBar.Text) ? filterTag : tbSearchBar.Text;
            tbSearchBar.ForeColor = tbSearchBar.Text == filterTag ? Color.DimGray : Color.White;
        }

        private void mainFilterChanged(object sender, EventArgs e) => _applyFilters();

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
