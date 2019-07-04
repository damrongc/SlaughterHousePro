using System;
using System.Windows.Forms;

namespace SlaughterHouseClient
{
    public partial class CustomMessageBox : Form
    {

        public CustomMessageBox()
        {
            InitializeComponent();
            Load += CustomMessageBox_Load;
        }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
