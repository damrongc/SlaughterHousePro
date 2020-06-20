using SlaughterHouseClient.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseClient.Issued
{
    public partial class Form_Orders : Form
    {
        readonly int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();

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

                var productionDate = db.plants.Find(plantID).production_date;
                var sql = @"select distinct ord.order_no,ord.order_date,ord.customer_code,ord.comments,cus.customer_name,cus.address
                                from orders  as ord,orders_item  as ord_item,customer cus
                                where ord.order_no = ord_item.order_no
                                and ord.customer_code =cus.customer_code
                                and ord.order_flag =0
                                and (ord_item.order_qty - ord_item.unload_qty)>0";

                //var sql = @"select distinct ord.order_no,ord.order_date,ord.customer_code,ord.comments,cus.customer_name,cus.address
                //                from orders  as ord,orders_item  as ord_item,customer cus
                //                where ord.order_no = ord_item.order_no
                //                and ord.customer_code =cus.customer_code
                //                and ord.order_flag =0
                //                and ord.order_date = @order_date
                //                and (ord_item.order_qty - ord_item.unload_qty)>0";

                //if (string.IsNullOrEmpty(_productCode))
                //{
                //    sql = @"select distinct ord.order_no,ord.order_date,ord.customer_code,ord.comments,cus.customer_name,cus.address
                //                from orders  as ord,orders_item  as ord_item,customer cus
                //                where ord.order_no = ord_item.order_no
                //                and ord.customer_code =cus.customer_code
                //                and ord.order_flag =0
                //                and (ord_item.order_qty - ord_item.unload_qty)>0";

                //}

                //object[] parmas = new object[];
                //MySql.Data.MySqlClient.MySqlParameterCollection mySqlParameter = new MySql.Data.MySqlClient.MySqlParameterCollection();

                //var parameters = new[]
                //{
                //  new MySqlParameter("@order_date",productionDate.ToString("yyyy-MM-dd")  ),
                //};
                var qry = db.Database.SqlQuery<CustomerOrder>(sql).ToList();

                //if (!string.IsNullOrEmpty(_productCode))
                //{
                //    var qry = (from o in db.orders
                //               join item in db.orders_item
                //               on o.order_no equals item.order_no
                //               where o.order_flag.Equals(0) && item.product_code.Equals(_productCode)
                //               select o).ToList();
                //    var coll = qry.AsEnumerable().Select(p => new
                //    {
                //        p.order_no,
                //        order_date = p.order_date.ToString("dd-MM-yyyy"),
                //        p.customer.customer_name,
                //        p.comments
                //    }).ToList();
                //    gv.DataSource = coll;
                //}
                //else
                //{
                //    var qry = (from o in db.orders
                //               join item in db.orders_item
                //               on o.order_no equals item.order_no
                //               where o.order_flag.Equals(0)
                //               select o).ToList();
                //    var coll = qry.AsEnumerable().Select(p => new
                //    {
                //        p.order_no,
                //        order_date = p.order_date.ToString("dd-MM-yyyy"),
                //        p.customer.customer_name,
                //        p.comments
                //    }).ToList();
                //    gv.DataSource = coll;

                //}

                var coll = qry.AsEnumerable().Select(p => new
                {
                    p.order_no,
                    order_date = p.order_date.ToString("dd-MM-yyyy"),
                    p.customer_name,
                    p.address,
                    p.comments
                }).ToList();
                gv.DataSource = coll;
                gv.Columns[0].HeaderText = "เลขที่";
                gv.Columns[1].HeaderText = "วันที่เอกสาร";
                gv.Columns[2].HeaderText = "ลูกค้า";
                gv.Columns[3].HeaderText = "ที่อยู่";
                gv.Columns[4].HeaderText = "หมายเหตุ";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
