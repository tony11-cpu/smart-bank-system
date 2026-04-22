using SmartBank;
using SmartBank_BLL;
using SmartBank_UI.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace SmartBank_UI.Main_Form_UC
{
    public partial class ctrlAccounts : UserControl
    {
        private List<clsAccounts> _allAccounts = new List<clsAccounts>();
        private clsAccounts _currentAccount = null;

        public ctrlAccounts() => InitializeComponent();

        private void tbSearchBar_EnterLeave(object sender, EventArgs e)
        {
            string tag = tbSearchBar.Tag.ToString().Trim();
            tbSearchBar.Text = tbSearchBar.Focused && tbSearchBar.Text == tag ? string.Empty : !tbSearchBar.Focused && string.IsNullOrWhiteSpace(tbSearchBar.Text) ? tag : tbSearchBar.Text;
            tbSearchBar.ForeColor = tbSearchBar.Text == tag ? Color.DimGray : Color.White;
        }

        private List<clsAccounts> _loadAccountsList()
        {
            _allAccounts = clsAccounts.GetAllAccounts();
            return _allAccounts;
        }

        private void _bindGrid(IEnumerable<clsAccounts> accountView)
        {
            if (!_allAccounts.Any())
                return;

            dgvAccounts.DataSource = accountView.Select(a => new
            {
                a.AccountID, a.AccountNumber, CustomerName = $"{a.Customer?.FirstName} {a.Customer?.LastName}".Trim(),
                a.AccountType, a.Balance, a.MinimumBalance, a.Status, a.OpenedDate,
                ClosedDate = a.ClosedDate.HasValue ? a.ClosedDate.Value.ToShortDateString() : "Not Closed", a.CreatedByUserID
            }).ToList();

            int count = accountView.Count();
            lblNumberOfAccounts.Text = $"Showing {count} of {_allAccounts.Count} account{(count != 1 ? "s" : "")}";
            lblClickToShowRow.Visible = true;

            dgvAccounts.Columns["AccountID"].Visible = false;
            dgvAccounts.Columns["MinimumBalance"].Visible = false;
            dgvAccounts.Columns["OpenedDate"].Visible = false;
            dgvAccounts.Columns["CreatedByUserID"].Visible = false;                

            dgvAccounts.Columns["AccountNumber"].HeaderText = "Account Number";
            dgvAccounts.Columns["AccountType"].HeaderText = "Account Type";
            dgvAccounts.Columns["ClosedDate"].HeaderText = "Closed Date";
            dgvAccounts.Columns["CustomerName"].HeaderText = "Customer Name";

            dgvAccounts.RowTemplate.Height = 35;
            dgvAccounts.ColumnHeadersHeight = 40;
        }

        private void ctrlAccounts_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            _bindGrid(_loadAccountsList());

            if (clsGlobal.ActiveUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Teller)
            {
                updateAccountToolStripMenuItem.Enabled = false;
                freezeAccountToolStripMenuItem.Enabled = false;
                unfreezeAccountToolStripMenuItem.Enabled = false;
            }
        }

        private void btnAllFilter_Click(object sender, EventArgs e) => _bindGrid(_allAccounts);
        private void btnClosedAccountsFilter_Click(object sender, EventArgs e) => _bindGrid(_allAccounts.Where(n => n.Status == clsAccounts.enStatus.Closed));
        private void btnFrozenFilter_Click(object sender, EventArgs e) => _bindGrid(_allAccounts.Where(n => n.Status == clsAccounts.enStatus.Frozen));
        private void btnActiveFilter_Click(object sender, EventArgs e) => _bindGrid(_allAccounts.Where(n => n.Status == clsAccounts.enStatus.Active));

        private void tbSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchBar.Text) || tbSearchBar.Text == tbSearchBar.Tag.ToString())
            {
                _bindGrid(_allAccounts);
                return;
            }

            string search = tbSearchBar.Text.Trim();
            _bindGrid(_allAccounts.Where(n => n.AccountNumber.StartsWith(search) || (n.Customer.FirstName + " " + n.Customer.LastName).StartsWith(search) ||
                                              n.Balance.ToString().StartsWith(search) || n.AccountType.ToString().StartsWith(search)).ToList());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_allAccounts == null || !_allAccounts.Any())
            {
                MessageBox.Show("No accounts to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine("Account Number,Customer Name,Account Type,Balance,Status,Closed Date");
                    foreach (clsAccounts acc in _allAccounts)
                        sw.WriteLine($"{acc.AccountNumber},\"{$"{acc.Customer?.FirstName} {acc.Customer?.LastName}".Trim()}\"" +
                                     $",{acc.AccountType},{acc.Balance},{acc.Status}," +
                                     $"{(acc.ClosedDate.HasValue ? acc.ClosedDate.Value.ToShortDateString() : "Not Closed")}");
                }

                MessageBox.Show("Accounts exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task _loadUserFromDGVAsync()
        {
            if (dgvAccounts.Rows.Count > 0)
                await ctrlAccountShortInfo1.LoadAccount(dgvAccounts.CurrentRow.Cells["AccountNumber"].Value.ToString());
        }

        

        private void OpenAccount_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateAccount frm = new frmAddOrUpdateAccount();
            frm.ShowDialog();

            _bindGrid(_loadAccountsList());
        }

        private async void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e) => await _loadUserFromDGVAsync();

        private async void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {
            await _loadUserFromDGVAsync();

            bool notClosed = _currentAccount != null && _currentAccount?.Status != clsAccounts.enStatus.Closed;
            bool frozen = _currentAccount?.Status == clsAccounts.enStatus.Frozen;
            bool isAdmin = clsGlobal.ActiveUser?.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Admin;
            bool canTransact = !(frozen && !isAdmin);

            updateAccountToolStripMenuItem.Enabled = notClosed && isAdmin;
            unfreezeAccountToolStripMenuItem.Enabled = notClosed && isAdmin && frozen;
            freezeAccountToolStripMenuItem.Enabled = notClosed && isAdmin && !frozen;
            closeToolStripMenuItem.Enabled = notClosed && isAdmin;
            depositeToolStripMenuItem.Enabled = notClosed && canTransact;
            withdrawalToolStripMenuItem.Enabled = notClosed && canTransact;
        }

        private void ctrlAccounts_VisibleChanged(object sender, EventArgs e) => _bindGrid(_loadAccountsList());

        private async void updateAccount_Click(object sender, EventArgs e)
        {
            string nationalID = dgvAccounts.CurrentRow.Cells["AccountNumber"].Value.ToString();
            frmAddOrUpdateAccount frm = new frmAddOrUpdateAccount(nationalID);
            frm.ShowDialog();

            await ctrlAccountShortInfo1.LoadAccount(nationalID);
            _bindGrid(_loadAccountsList());
        }

        private void freezeAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to freeze this account?", "Confirm Freeze", MessageBoxButtons.YesNo, MessageBoxIcon.Question , MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                if (_currentAccount.Freeze())
                {
                    _bindGrid(_loadAccountsList());
                    MessageBox.Show("Account freezed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Failed to freeze account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to freeze account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void unfreezeAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to unfreeze this account?", "Confirm Unfreeze", MessageBoxButtons.YesNo, MessageBoxIcon.Question , MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                if (_currentAccount.UnFreeze())
                {
                    _bindGrid(_loadAccountsList());
                    MessageBox.Show("Account unfrozen successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Failed to unfreeze account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to unfreeze account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to close this account?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question , MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                if (_currentAccount.Close())
                {
                    _bindGrid(_loadAccountsList());
                    MessageBox.Show("Account closed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Failed to close account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to close account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}