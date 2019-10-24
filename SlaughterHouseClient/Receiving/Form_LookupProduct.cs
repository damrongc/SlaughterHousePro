using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseClient.Receiving
{
    public partial class Form_LookupProduct : Form
    {
        //int ReceiveFlag { get; set; }
        public string ProductCode { get; set; }

        private int Index;
        private int PAGE_SIZE = 20;
        List<Button> buttons;

        public Form_LookupProduct()
        {
            InitializeComponent();
            Load += Form_Load;

            //ReceiveFlag = _receiveFlag;

            UserSettingsComponent();

        }

        private void UserSettingsComponent()
        {
            //gv.CellContentClick += Gv_CellContentClick;
            //gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            ////gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            //gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            //gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ////gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            //gv.EnableHeadersVisualStyles = false;



        }

        //private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        DataGridView senderGrid = (DataGridView)sender;

        //        if (e.RowIndex >= 0)
        //        {
        //            ProductCode = gv.Rows[e.RowIndex].Cells[0].Value.ToString();
        //            DialogResult = DialogResult.OK;
        //            Close();


        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadProductGroup();
        }

        private void LoadProductGroup()
        {

            using (var db = new SlaughterhouseEntities())
            {
                var coll = db.product_group.Select(p => new
                {
                    p.product_group_code,
                    p.product_group_name

                });
                ddlProductGroup.DisplayMember = "product_group_name";
                ddlProductGroup.ValueMember = "product_group_code";
                ddlProductGroup.DataSource = coll.ToList();
            }
        }

        private void LoadProduct()
        {
            flowLayoutPanel1.Controls.Clear();
            buttons = new List<Button>();

            int productGroupCode = ddlProductGroup.SelectedValue.ToString().ToInt16();
            using (var db = new SlaughterhouseEntities())
            {

                var products = db.products.Where(p => p.product_group_code == productGroupCode && p.active == true).ToList();
                foreach (var item in products)
                {
                    var btn = new Button
                    {
                        Text = item.product_name,
                        Width = 190,
                        Height = 80,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Kanit", 14),
                        BackColor = Color.WhiteSmoke,
                        Tag = item.product_code
                    };

                    buttons.Add(btn);

                    btn.Click += Btn_Click;
                    DisplayPaging();
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ddlProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
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
    }
}
