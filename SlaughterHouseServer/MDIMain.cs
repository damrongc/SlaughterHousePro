using SlaughterHouseServer.Reports;
using System;
using System.Windows.Forms;

namespace SlaughterHouseServer
{
    public partial class MDIMain : Form
    {
        //private int childFormNumber = 0;

        public MDIMain()
        {
            InitializeComponent();

        }

        //private void ShowNewForm(object sender, EventArgs e)
        //{
        //    Form childForm = new Form
        //    {
        //        MdiParent = this,
        //        Text = "Window " + childFormNumber++
        //    };
        //    childForm.Show();
        //}

        void CloseAllForm()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MnuReceive_Click(object sender, EventArgs e)
        {

            CloseAllForm();
            var frm = new Form_Receive
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
            //Form childForm = new Form();
            //childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            //childForm.Show();
        }

        private void MenuFarm_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_Farm
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow

            };
            frm.Show();
        }

        private void MenuProductGroup_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_ProductGroup
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuProduct_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_Product
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuUnit_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_Unit
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuBreeder_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_Breeder
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuCustomer_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_Customer
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuCustomerGroup_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_MasterClass
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuClassPrice_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_PriceList
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuTruckType_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_TruckType
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuTruck_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_Truck
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuBOM_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_Bom
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuSalesman_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_Salesman
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuReportReceived_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_ReportSwineReceiveByDate
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuReportYieldReceived_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_ReportSwineYeild
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuReportOrders_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_ReportDailySales
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuReportStockMovement_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_ReportStockMovement
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuReportStockBalance_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_ReportStockBalance
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuOrders_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_Order
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuInvoices_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_Invoice
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuUserGroup_Click(object sender, EventArgs e)
        {

        }

        private void MenuUser_Click(object sender, EventArgs e)
        {

        }

        private void MenuPermission_Click(object sender, EventArgs e)
        {

        }

        private void MenuPlant_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_Plant
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuCloseProductionDate_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_ClosePeriod
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }

        private void MenuReportOrderWithInvoice_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            var frm = new Form_ReportSoMapInv
            {
                MdiParent = this,
                Padding = new Padding(10),
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            frm.Show();
        }
    }
}
