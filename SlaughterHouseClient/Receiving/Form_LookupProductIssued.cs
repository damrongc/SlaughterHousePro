using MySql.Data.MySqlClient;
using SlaughterHouseClient.Models;
using SlaughterHouseEF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseClient.Receiving
{
    public partial class Form_LookupProductIssued : Form
    {
        private readonly int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
        //public string ProductCode { get; set; }
        //public string LotNo { get; set; }
        public RMIssuedInfo productIssuedSelected;
        private List<RMIssuedInfo> productIssueds;
        private int Index;
        private readonly int PAGE_SIZE = 35;
        List<Button> buttons;
        public Form_LookupProductIssued()
        {
            InitializeComponent();
            Load += Form_Load;
        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadProduct();
        }
        private void LoadProduct()
        {
            flowLayoutPanel1.Controls.Clear();
            buttons = new List<Button>();
            string productCode = lblProductCode.Text;
            using (var db = new SlaughterhouseEntities())
            {
                var plant = db.plants.Find(plantID);
                var productionDate = plant.production_date;
                var sql = @"SELECT DISTINCT a.product_code, a.lot_no,b.product_name
                            FROM rm_issued_info a,product b
                            WHERE a.product_code =b.product_code
                            AND production_date = @production_date";
                var qry = db.Database.SqlQuery<RMIssuedInfo>(sql, new MySqlParameter("production_date", productionDate)).ToList();
                productIssueds = qry.ToList();
                for (int i = 0; i < productIssueds.Count; i++)
                {
                    var btn = new Button
                    {
                        Text = $"{productIssueds[i].product_code}\r{productIssueds[i].product_name}\r{productIssueds[i].lot_no}",
                        Width = 190,
                        Height = 100,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Kanit", 12),
                        BackColor = Color.White,
                        Tag = i.ToString()
                    };
                    buttons.Add(btn);
                    btn.Click += Btn_Click;
                    Index = 0;
                }
                DisplayPaging();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                var b = (Button)ctrl;
                b.BackColor = Color.WhiteSmoke;
                b.ForeColor = Color.Black;
            }
            var btn = (Button)sender;
            btn.BackColor = ColorTranslator.FromHtml("#1C6BBC");
            btn.ForeColor = Color.White;
            productIssuedSelected = productIssueds[btn.Tag.ToString().ToInt16()];
            //ProductCode = btn.Tag.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }
        private void BtnUp_Click(object sender, EventArgs e)
        {
            if (Index > 0)
            {
                Index -= PAGE_SIZE;
                if (Index < 0)
                {
                    Index = 0;
                }
                DisplayPaging();
            }
        }
        private void BtnDown_Click(object sender, EventArgs e)
        {
            if (Index < buttons.Count - 1)
            {
                Index += PAGE_SIZE;
                if (Index > buttons.Count - 1)
                {
                    Index = buttons.Count - 1;
                }
            }
            DisplayPaging();
        }
        private void DisplayPaging()
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = Index; i <= (Index + PAGE_SIZE); i++)
            {
                if (i < buttons.Count)
                {
                    flowLayoutPanel1.Controls.Add(buttons[i]);
                }
            }
            flowLayoutPanel1.Visible = true;
            //btnPageUp.Enabled = (Index > 0);
            //btnPageDown.Enabled = ((Index + (PAGE_SIZE + 1)) <= (lables.Count - 1));
        }
        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new Form_NumericPad();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    lblProductCode.Text = frm.ReturnValue == 0 ? "" : frm.ReturnValue.ToString();
                    LoadProduct();
                }
            }
            catch (Exception ex)
            {
                lblProductCode.Text = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblProductCode.Text = "";
            LoadProduct();
        }
    }
}
