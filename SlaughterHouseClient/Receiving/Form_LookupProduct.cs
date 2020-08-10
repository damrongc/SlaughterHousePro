using SlaughterHouseEF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseClient.Receiving
{
    public partial class Form_LookupProduct : Form
    {
        public string ProductCode { get; set; }
        public int ProductGroup { get; set; }
        private int Index;
        private readonly int PAGE_SIZE = 35;
        List<Button> buttons;
        public Form_LookupProduct()
        {
            InitializeComponent();
            Load += Form_Load;
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadProductGroup();
        }
        private void LoadProductGroup()
        {
            using (var db = new SlaughterhouseEntities())
            {
                var coll = db.product_group.Where(p => p.product_group_code > 3).ToList();
                coll.Insert(0, new product_group
                {
                    product_group_code = 0,
                    product_group_name = "--เลือก--"
                });
                ddlProductGroup.DisplayMember = "product_group_name";
                ddlProductGroup.ValueMember = "product_group_code";
                ddlProductGroup.DataSource = coll.ToList();
                ddlProductGroup.SelectedIndex = 0;
            }
        }
        private void LoadProduct()
        {
            int productGroupCode = ddlProductGroup.SelectedValue.ToString().ToInt16();
            flowLayoutPanel1.Controls.Clear();
            buttons = new List<Button>();
            string productCode = lblProductCode.Text;
            using (var db = new SlaughterhouseEntities())
            {
                var qry = db.products.Where(p => p.active == true &&
                p.product_group_code == productGroupCode &&
                p.product_code.Contains(productCode));
                //if (!string.IsNullOrEmpty(productCode))
                //{
                //    qry = qry.Where(p => p.product_code.Contains(productCode));
                //}
                //else
                //{
                //    if (productGroupCode > 0)
                //    {
                //        qry = qry.Where(p => p.product_group_code == productGroupCode);
                //    }
                //}
                var products = qry.ToList();
                //var products = db.products.Where(p => p.product_group_code == productGroupCode
                //                && p.active == true
                //                && p.product_code.Contains(productCode))
                //    .Select(p => new
                //    {
                //        p.product_code,
                //        p.product_name
                //    }).ToList();
                foreach (var item in products)
                {
                    var btn = new Button
                    {
                        Text = $"{item.product_code}\r{item.product_name}",
                        Width = 190,
                        Height = 80,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Kanit", 12),
                        BackColor = Color.White,
                        Tag = item.product_code
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
        private void ddlProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblProductCode.Text = "";
            if (ddlProductGroup.SelectedIndex == 0) return;
            LoadProduct();
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
            ProductCode = btn.Tag.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }
        private void BtnUp_Click(object sender, EventArgs e)
        {
            if (Index > 0)
            {
                Index = Index - PAGE_SIZE;
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
                Index = Index + PAGE_SIZE;
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
