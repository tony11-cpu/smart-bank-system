using SmartBank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI
{
    public partial class frmMain : Form
    {
        public frmMain(clsUsers admin)
        {
            InitializeComponent();
            clsGlobal.ActiveUser = admin;
        }
    }
}
