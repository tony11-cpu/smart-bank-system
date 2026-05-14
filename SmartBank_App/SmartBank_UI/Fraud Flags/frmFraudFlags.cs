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
