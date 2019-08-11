using System;
using System.Windows.Forms;

namespace SlaughterHouseClient
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
            Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            lblCurrentDatetime.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void btnReceiveSwine_Click(object sender, EventArgs e)
        {
            var frm = new Receiving.Form_Swine();
            frm.ShowDialog();
        }

        private void btnReceiveCarcass_Click(object sender, EventArgs e)
        {

            var frm = new Receiving.Form_Carcass();
            frm.ShowDialog();
        }
        private void btnReceiveHead_Click(object sender, EventArgs e)
        {
            var frm = new Receiving.Form_ByProduct("P003");
            frm.ShowDialog();
        }

        private void btnReceiveByProductWhite_Click(object sender, EventArgs e)
        {

            var frm = new Receiving.Form_ByProduct("P005");
            frm.ShowDialog();
        }

        private void btnReceiveByProductRed_Click(object sender, EventArgs e)
        {

            var frm = new Receiving.Form_ByProduct("P004");
            frm.ShowDialog();
        }

        private void btnIssueCarcass_Click(object sender, EventArgs e)
        {
            var frm = new Issued.Form_Carcass();
            frm.ShowDialog();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
