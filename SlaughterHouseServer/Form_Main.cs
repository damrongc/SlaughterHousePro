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
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            //foreach (Control ctrl in plMenu.Controls)
            //{
            //    if (ctrl is Button)
            //    {
            //        ctrl.BackColor = System.Drawing.ColorTranslator.FromHtml("#27212A");
            //    }
            //}

            //btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#429ADF");


            switch (btn.Name)
            {
                case "BtnFarm":
                    AddFormToContainer(new Form_Farm());
                    break;
                case "BtnReceive":
                    AddFormToContainer(new Form_Receive());
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
                //this.plContainer.Controls.RemoveAt(0);
            }

            Form fh = form as Form;
            fh.TopLevel = false;
            fh.AutoScroll = true;
            fh.Dock = DockStyle.Fill;
            fh.FormBorderStyle = FormBorderStyle.None;
            //fh.Size = this.ClientSize;


            plContainer.Controls.Add(fh);

            //fh.WindowState = FormWindowState.Maximized;
            //this.plContainer.Tag = fh;
            fh.Show();

        }
    }
}
