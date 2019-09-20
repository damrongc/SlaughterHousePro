using SlaughterHouseServer.Masters;
using System;
using System.Windows.Forms;

namespace SlaughterHouseServer
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
            UserSettingComponent();
        }

        private void UserSettingComponent()
        {
            BtnMaster.Click += Btn_Click;
            BtnOrder.Click += Btn_Click;
            BtnProductionOrder.Click += Btn_Click;
            BtnReceive.Click += Btn_Click;
            BtnCarcass.Click += Btn_Click;
            BtnInvoice.Click += Btn_Click;
            BtnReport.Click += Btn_Click;
        }



        private void Btn_Click(object sender, EventArgs e)
        {

            foreach (Button item in plMenu.Controls)
            {
                item.BackColor = System.Drawing.ColorTranslator.FromHtml("#27212A");
            }
            var btn = (Button)sender;
            btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#007ACC");
            switch (btn.Name)
            {
                case "BtnMaster":
                    AddFormToContainer(new Form_MasterMenu());
                    break;
                case "BtnReceive":
                    AddFormToContainer(new Form_Receive());
                    break;
                case "BtnCarcass":
                    AddFormToContainer(new Form_ReceiveCarcass());
                    break;
                case "BtnOrder":
                    AddFormToContainer(new Form_Order());
                    break;
                case "BtnProductionOrder":
                    AddFormToContainer(new Form_ProductionOrder());
                    break;

                case "BtnInvoice":
                    AddFormToContainer(new Form_Invoice());
                    break;
                case "BtnReport":
                    AddFormToContainer(new Form_Report());
                    break;

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddFormToContainer(object form)
        {
            if (plContainer.Controls.Count > 0)
            {
                var frm = plContainer.Controls[0] as Form;
                frm.Close();
            }
            Form fh = form as Form;
            fh.TopLevel = false;
            fh.AutoScroll = true;
            fh.Dock = DockStyle.Fill;
            fh.FormBorderStyle = FormBorderStyle.None;

            plContainer.Controls.Add(fh);

            //fh.WindowState = FormWindowState.Maximized;
            //this.plContainer.Tag = fh;
            fh.Show();
        }
    }
}
