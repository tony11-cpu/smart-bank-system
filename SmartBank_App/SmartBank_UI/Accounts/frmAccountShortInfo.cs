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

        public frmAccountShortInfo(string accountNumber)
        {
            InitializeComponent();
            _accountNumber = accountNumber;
        }

        private async void frmAccountShortInfo_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_accountNumber))
            {
                MessageBox.Show("Account number is required to load account information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = $"Account Short Info - {_accountNumber}";
            await ctrlAccountShortInfo1.LoadAccount(_accountNumber);
        }
    }
}
