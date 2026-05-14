using System.Drawing;
using System.Windows.Forms;

namespace SmartBank_UI.Fraud_Flags
{
    public partial class ctrlFraudFlagsMainScreen : UserControl
    {
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
    }
}
