using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI.Transaction
{
    public partial class frmPerformNewTransaction : Form
    {
        public enum enTransactionType
        {
            Deposit,
            Withdraw,
            Transfer,
            None
        }

        private enTransactionType _transactionType;
        private string _accountNumber;
        public frmPerformNewTransaction(string accountNumber , enTransactionType transactionType)
        {
            InitializeComponent();
            _transactionType = transactionType;
            _accountNumber = accountNumber;
        }
    }
}
