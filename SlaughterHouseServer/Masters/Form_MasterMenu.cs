using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlaughterHouseServer.Masters
{
    public partial class Form_MasterMenu : Form
    {
        public Form_MasterMenu()
        {
            InitializeComponent();
            Load += Form_MasterMenu_Load;
        }

        private void Form_MasterMenu_Load(object sender, EventArgs e)
        {
            BtnFarm.Click += Btn_Click;

            BtnCustomer.Click += Btn_Click;
            BtnProduct.Click += Btn_Click;
            BtnProductGroup.Click += Btn_Click;
            BtnUnit.Click += Btn_Click;
            BtnPriceList.Click += Btn_Click;
            BtnBreeder.Click += Btn_Click;
            BtnTruck.Click += Btn_Click;
            BtnBom.Click += Btn_Click;
            BtnPlant.Click += Btn_Click;
            BtnTruckType.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            foreach (Button item in plMenu.Controls)
            {
                item.BackColor = ColorTranslator.FromHtml("#27212A");
            }
            var btn = (Button)sender;
            btn.BackColor = ColorTranslator.FromHtml("#007ACC");
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
                case "BtnPriceList":
                    AddFormToContainer(new Form_PriceList());
                    break;
                case "BtnBom":
                    AddFormToContainer(new Form_Bom());
                    break;
                case "BtnTruck":
                    AddFormToContainer(new Form_Truck());
                    break;
                case "BtnBreeder":
                    AddFormToContainer(new Form_Breeder());
                    break;
                case "BtnPlant":
                    AddFormToContainer(new Form_Plant());
                    break;
                case "BtnTruckType":
                    AddFormToContainer(new Form_TruckType());
                    break;
            }
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
