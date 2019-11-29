using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ToastNotifications;

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
            using (var db = new SlaughterhouseEntities())
            {
                int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
                var plant = db.plants.Find(plantID);
                lblCurrentDatetime.Text = plant.production_date.ToString("dd-MM-yyyy");
            }

        }

        private void btnReceiveSwine_Click(object sender, EventArgs e)
        {
            var frm = new Receiving.Form_SwineReceive();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();

            //var animationDirection = FormAnimator.AnimationDirection.Up;
            //var animationMethod = FormAnimator.AnimationMethod.Slide;
            //var toastNotification = new Notification("Notification", "บันทึกข้อมูล เรียบร้อย.", 2, animationMethod, animationDirection);
            ////PlayNotificationSound("normal");
            //toastNotification.Show();
            ////toastNotification.Hide();
        }

        private void btnReceiveCarcass_Click(object sender, EventArgs e)
        {

            var frm = new Receiving.Form_CarcassReceive();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }
        private void btnReceiveHead_Click(object sender, EventArgs e)
        {
            //var frm = new Receiving.Form_ByProduct("รับหัว", 4, 0);
            //frm.ShowInTaskbar = false;
            //frm.ShowDialog();

            var frm = new Receiving.Form_HeadReceive();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();

        }

        private void btnReceiveByProductWhite_Click(object sender, EventArgs e)
        {
            var frm = new Receiving.Form_ByProductReceive
            {
                LocationCode = 4,
                ProductCode = "00201",
                //var frm = new Receiving.Form_ByProduct("รับเครื่องในขาว", 3, 4);
                ShowInTaskbar = false
            };
            frm.ShowDialog();
        }

        private void btnReceiveByProductRed_Click(object sender, EventArgs e)
        {
            var frm = new Receiving.Form_ByProductReceive
            {
                LocationCode = 3,
                ProductCode = "00101",
                //var frm = new Receiving.Form_ByProduct("รับเครื่องในแดง", 2, 3);
                ShowInTaskbar = false
            };
            frm.ShowDialog();
        }

        private void btnIssueCarcass_Click(object sender, EventArgs e)
        {
            var frm = new Issued.Form_Carcass();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }


        private void btnReceivePart_Click(object sender, EventArgs e)
        {
            ////location code 7 :ห้องตัดแต่ง
            var frm = new Receiving.Form_ReceiveProduct();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }



        private void btnIssuePart_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnConfirmStock_Click(object sender, EventArgs e)
        {
            var frm = new Receiving.Form_ConfirmStock(new List<int> { 5, 6 });
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void BtnIssueProductForSales_Click(object sender, EventArgs e)
        {
            var frm = new Issued.Form_MainProduct
            {
                ShowInTaskbar = false
            };
            frm.ShowDialog();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var frm = new Form_Settings();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnIssueByProduct_Click(object sender, EventArgs e)
        {
            var frm = new Issued.Form_ByProduct
            {
                ShowInTaskbar = false
            };
            frm.ShowDialog();
        }
    }
}
