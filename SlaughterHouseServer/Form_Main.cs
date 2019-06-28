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
            BtnFarm.Click += Btn_Click;
            BtnCustomer.Click += Btn_Click;
            BtnProduct.Click += Btn_Click;
            BtnProductGroup.Click += Btn_Click;
            BtnUnit.Click += Btn_Click;
            BtnOrder.Click += Btn_Click;
            BtnIssue.Click += Btn_Click;
            BtnReceive.Click += Btn_Click;
            BtnCarcass.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            switch (btn.Name)
            {
                case "BtnFarm":
                    AddFormToContainer(new Form_Farm());
                    break;
                case "BtnCustomer":
                    AddFormToContainer(new Form_Customer());
                    break;
                case "BtnProduct":
                    AddFormToContainer(new Form_Product());
                    break;
                case "BtnProductGroup":
                    AddFormToContainer(new Form_ProductGroup());
                    break;
                case "BtnUnit":
                    AddFormToContainer(new Form_Unit());
                    break;
                case "BtnReceive":
                    AddFormToContainer(new Form_Receive());
                    break;
                case "BtnCarcass":
                    AddFormToContainer(new Form_ReceiveCarcass());
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
