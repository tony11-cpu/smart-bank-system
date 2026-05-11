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

namespace SmartBank_UI.Accounts
{
    public partial class frmAccountShortInfo : Form
    {
        private string _accountNumber;
        private event Action _onAccountLoading;

        public frmAccountShortInfo(string accountNumber , Action onAccountLoad = null)
        {
            InitializeComponent();
            _accountNumber = accountNumber;
            this._onAccountLoading = onAccountLoad;
        }

        private async void frmAccountShortInfo_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_accountNumber) || !(await clsAccounts.IsAccountExistsAsync(_accountNumber)))
            {
                MessageBox.Show("Invalid account number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = $"Account Short Info - {_accountNumber}";
            await ctrlAccountShortInfo1.LoadAccount(_accountNumber , _onAccountLoading);
        }
    }
}
