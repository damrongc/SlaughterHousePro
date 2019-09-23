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
            lblCurrentDatetime.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void btnReceiveSwine_Click(object sender, EventArgs e)
        {
            var frm = new Receiving.Form_SwineReceive();
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

            var frm = new Receiving.Form_Carcass();
            frm.ShowDialog();
        }
        private void btnReceiveHead_Click(object sender, EventArgs e)
        {
            var frm = new Receiving.Form_ByProduct("รับหัว", 4, 0);
            frm.ShowDialog();
        }

        private void btnReceiveByProductWhite_Click(object sender, EventArgs e)
        {

            var frm = new Receiving.Form_ByProduct("รับเครื่องในขาว", 3, 4);
            frm.ShowDialog();
        }

        private void btnReceiveByProductRed_Click(object sender, EventArgs e)
        {

            var frm = new Receiving.Form_ByProduct("รับเครื่องในแดง", 2, 3);
            frm.ShowDialog();
        }

        private void btnIssueCarcass_Click(object sender, EventArgs e)
        {
            var frm = new Receiving.Form_Carcass();
            frm.ShowDialog();
        }

        private void btnIssueCarcassForSales_Click(object sender, EventArgs e)
        {

        }

        private void btnReceivePart_Click(object sender, EventArgs e)
        {
            //location code 7 :ห้องตัดแต่ง
            var frm = new Receiving.Form_ByProduct("รับผลได้ชิ้นส่วน", 5, 7);
            frm.ShowDialog();
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

        private void BtnConfirmStock_Click(object sender, EventArgs e)
        {
            var frm = new Receiving.Form_ConfirmStock(new List<int> { 5, 6 });
            frm.ShowDialog();
        }

        private void BtnIssuePart_Click_1(object sender, EventArgs e)
        {

        }

        private void BtnIssueProductForSales_Click(object sender, EventArgs e)
        {
            var frm = new Issued.Form_MainProduct();
            frm.ShowDialog();
        }
    }
}
