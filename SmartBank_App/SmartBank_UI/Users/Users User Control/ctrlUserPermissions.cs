using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBank_UI.Users.Users_User_Control
{
    public partial class ctrlUserPermissions : UserControl
    {
        public ctrlUserPermissions()
        {
            InitializeComponent();
        }

        public int Permissions { get; private set; }
    }
}
