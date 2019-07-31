using System;
using System.Windows.Forms;

namespace SlaughterHouseClient
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
        }

        private void btnReceiveSwine_Click(object sender, EventArgs e)
        {
            var frm = new Form_SwineReceive();
            frm.Show();
        }

        private void btnReceiveCarcass_Click(object sender, EventArgs e)
        {

        }

        private void btnReceiveByProductWhite_Click(object sender, EventArgs e)
        {

        }

        private void btnReceiveByProductRed_Click(object sender, EventArgs e)
        {

        }

        private void btnIssueCarcass_Click(object sender, EventArgs e)
        {

        }

        private void btnIssueCarcassForSales_Click(object sender, EventArgs e)
        {

        }

        private void btnReceivePart_Click(object sender, EventArgs e)
        {

        }

        private void btnIssueHead_Click(object sender, EventArgs e)
        {

        }

        private void btnIssueByProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnIssuePart_Click(object sender, EventArgs e)
        {

        }
    }
}
