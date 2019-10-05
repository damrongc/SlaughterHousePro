﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseClient.Issued
{
    public partial class Form_Orders : Form
    {
        public string OrderNo { get; set; }

        private readonly string _productCode;
        public Form_Orders(string productCode)
        {
            InitializeComponent();

            _productCode = productCode;
            Load += Form_Load;
            UserSettingsComponent();
        }

        private void UserSettingsComponent()
        {

            gv.CellClick += Gv_CellClick;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;
        }

        private void Gv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;

                if (e.RowIndex >= 0)
                {
                    OrderNo = gv.Rows[e.RowIndex].Cells[0].Value.ToString();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new SlaughterhouseEntities())
            {

                if (!string.IsNullOrEmpty(_productCode))
                {
                    var qry = (from o in db.orders
                               join item in db.orders_item
                               on o.order_no equals item.order_no
                               where o.order_flag.Equals(0) && item.product_code.Equals(_productCode)
                               select o).ToList();
                    var coll = qry.AsEnumerable().Select(p => new
                    {
                        p.order_no,
                        order_date = p.order_date.ToString("dd-MM-yyyy"),
                        p.customer.customer_name,
                        p.comments
                    }).ToList();
                    gv.DataSource = coll;
                }
                else
                {
                    var qry = (from o in db.orders
                               join item in db.orders_item
                               on o.order_no equals item.order_no
                               where o.order_flag.Equals(0)
                               select o).ToList();
                    var coll = qry.AsEnumerable().Select(p => new
                    {
                        p.order_no,
                        order_date = p.order_date.ToString("dd-MM-yyyy"),
                        p.customer.customer_name,
                        p.comments
                    }).ToList();
                    gv.DataSource = coll;

                }
                gv.Columns[0].HeaderText = "เลขที่ SO";
                gv.Columns[1].HeaderText = "วันที่เอกสาร";
                gv.Columns[2].HeaderText = "ลูกค้า";
                gv.Columns[3].HeaderText = "หมายเหตุ";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}