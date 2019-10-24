using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseClient.Issued
{
    public partial class Form_LookupTruck : Form
    {
        //int ReceiveFlag { get; set; }
        public string TruckNo { get; set; }

        private int Index;
        private int PAGE_SIZE = 20;
        List<Button> buttons;

        public Form_LookupTruck()
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
            LoadTruck();
        }



        private void LoadTruck()
        {
            flowLayoutPanel1.Controls.Clear();
            buttons = new List<Button>();


            using (var db = new SlaughterhouseEntities())
            {

                var trucks = db.trucks.Where(p => p.active == true).Select(p => new
                {
                    p.truck_no,
                })
                    .ToList();
                foreach (var item in trucks)
                {
                    var btn = new Button
                    {
                        Text = item.truck_no,
                        Width = 190,
                        Height = 80,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Kanit", 14),
                        BackColor = Color.WhiteSmoke,
                        Tag = item.truck_no
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
            TruckNo = btn.Tag.ToString();
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
