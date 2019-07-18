using System;
using System.Windows.Forms;

namespace SlaughterHouseClient
{
    public partial class CustomMessageBox : Form
    {

        public CustomMessageBox(string body)
        {
            InitializeComponent();
            labelBody.Text = body;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
