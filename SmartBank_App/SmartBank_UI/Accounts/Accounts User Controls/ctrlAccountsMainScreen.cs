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
        public ctrlAccounts()
        {
            InitializeComponent();
        }

        private void tbSearchBar_EnterLeave(object sender, EventArgs e)
        {
            string tbFilterTag = tbSearchBar.Tag.ToString().Trim();
            tbSearchBar.Text = tbSearchBar.Focused && tbSearchBar.Text == tbFilterTag ? string.Empty : !tbSearchBar.Focused && string.IsNullOrWhiteSpace(tbSearchBar.Text) ? tbFilterTag : tbSearchBar.Text;
            tbSearchBar.ForeColor = tbSearchBar.Text == tbFilterTag ? Color.DimGray : Color.White;
        }

        private List<clsAccounts> _allAccounts = new List<clsAccounts>();
        private clsAccounts _currentAccount = null;

        private List<clsAccounts> _loadAccountsList()
        {
            _allAccounts = clsAccounts.GetAllAccounts();
            return _allAccounts;
        }

        private void _bindGrid(IEnumerable<clsAccounts> accountView)
        {
            if (accountView == null)
                return;

            dgvAccounts.DataSource = accountView.Select(a => new
            {
                a.AccountID, a.AccountNumber,
                CustomerName = $"{a.Customer?.FirstName} {a.Customer?.LastName}".Trim(),
                a.AccountType, a.Balance, a.MinimumBalance,
                a.Status, a.OpenedDate, ClosedDate = a.ClosedDate.HasValue ? a.ClosedDate.Value.ToShortDateString() : "Not Closed",
                a.CreatedByUserID
            }).ToList();

            int numberOfAccounts = accountView.Count();
            lblNumberOfAccounts.Text = $"Showing {numberOfAccounts} of {_allAccounts.Count} account{(numberOfAccounts != 1 ? "s" : "")}";
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
            }
            else
            {
                string textFilter = tbSearchBar.Text.Trim();
                _bindGrid(_allAccounts.Where(n =>
                {
                    return n.AccountNumber.StartsWith(textFilter) || 
                          (n.Customer.FirstName + " " + n.Customer.LastName).StartsWith(textFilter) || 
                           n.Balance.ToString().StartsWith(textFilter) ||
                           n.AccountType.ToString().StartsWith(textFilter);
                }).ToList());
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_allAccounts == null || !_allAccounts.Any())
            {
                MessageBox.Show("No accounts to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<clsAccounts> currentView = _allAccounts;
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) 
                return;

            try
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine("Account Number,Customer Name,Account Type,Balance,Status,Closed Date");
                    foreach (clsAccounts acc in currentView)
                    {
                        sw.WriteLine($"{acc.AccountNumber},\"{$"{acc.Customer?.FirstName} {acc.Customer?.LastName}".Trim()}" +
                            $"\",{acc.AccountType},{acc.Balance},{acc.Status}," +
                            $"{(acc.ClosedDate.HasValue ? acc.ClosedDate.Value.ToShortDateString() : "Not Closed")}");
                    }
                }

                MessageBox.Show("Accounts exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) => _loadUserFromDGV();

        private void _loadUserFromDGV()
        {
            if (dgvAccounts.Rows.Count > 0)
            {
                _loadAccount(dgvAccounts.CurrentRow.Cells["AccountNumber"].Value.ToString());
            }
        }

        private void _loadAccount(string accountNumber)
        {
            _currentAccount = clsAccounts.Find(accountNumber);
            if(_currentAccount == null)
            {
                MessageBox.Show("Failed to load account details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblAccountName.Text = _currentAccount.AccountNumber;
            lblSavingsOrChecking.Text = _currentAccount.AccountType.ToString();
            lblSavingsOrChecking.ForeColor = _currentAccount.AccountType == clsAccounts.enAccountType.Savings ? Color.FromArgb(0, 200, 0) : Color.Orange;
            pbAccountTypePhoto.Image = _currentAccount.AccountType == clsAccounts.enAccountType.Savings ? Properties.Resources.icons8_wallet_64 : Properties.Resources.icons8_bank_64;
            lblCurrentBalance.Text = $"${_currentAccount.Balance}";
            lblCurrentBalance.ForeColor = _currentAccount.Balance >= 0 ? Color.FromArgb(0, 200, 0) : Color.Red;
            lblMinimunBalance.Text = $"${_currentAccount.MinimumBalance}";
            lblCustomerAccountFullName.Text = $"{_currentAccount.Customer?.FirstName} {_currentAccount.Customer?.LastName}".Trim();
            lblAccountType.Text = lblSavingsOrChecking.Text;
            lblOpenDate.Text = _currentAccount.OpenedDate?.ToShortDateString();
            lblOpenByUsername.Text = clsUsers.Find(_currentAccount.CreatedByUserID)?.Username ?? "Unknown";
        }

        private void OpenAccount_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateAccount frm = new frmAddOrUpdateAccount();
            frm.ShowDialog();

            _bindGrid(_loadAccountsList());
        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e) => _loadUserFromDGV();
    }
}
