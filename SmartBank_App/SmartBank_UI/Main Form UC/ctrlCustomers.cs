using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI.Main_Form_UC
{
    public partial class ctrlCustomers : UserControl
    {
        public ctrlCustomers()
        {
            InitializeComponent();
        }

        private void tbSearchBar_Click(object sender, EventArgs e)
        {
            if(tbSearchBar.Text == "Search by name,phone , or last 4 digits of National ID...")
            {
                tbSearchBar.Text = "";
                tbSearchBar.ForeColor = Color.White;
            }
        }
    }
}
