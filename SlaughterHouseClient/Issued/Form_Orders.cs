using MySql.Data.MySqlClient;
using SlaughterHouseClient.Models;
using SlaughterHouseEF;
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
                var sql = "";
                MySqlParameter[] parameters;
                if (string.IsNullOrEmpty(_productCode))
                {
                    sql = @"select distinct ord.order_no,ord.order_date,ord.customer_code,ord.comments,cus.customer_name,cus.address
                                from orders  as ord,orders_item  as ord_item,customer cus
                                where ord.order_no = ord_item.order_no
                                and ord.customer_code =cus.customer_code
                                and ord.order_flag =0
                                and ord.invoice_flag =0
                                and (ord_item.order_qty - ord_item.unload_qty)>0";
                    var qry = db.Database.SqlQuery<CustomerOrder>(sql).ToList();
                    var coll = qry.AsEnumerable().Select(p => new
                    {
                        p.order_no,
                        order_date = p.order_date.ToString("dd-MM-yyyy"),
                        p.customer_name,
                        p.address,
                        p.comments
                    }).ToList();
                    gv.DataSource = coll;
                }
                else
                {
                    sql = @"select distinct ord.order_no,ord.order_date,ord.customer_code,ord.comments,cus.customer_name,cus.address
                                from orders  as ord,orders_item  as ord_item,customer cus
                                where ord.order_no = ord_item.order_no
                                and ord.customer_code =cus.customer_code
                                and ord_item.product_code =@product_code
                                and ord.order_flag =0
                                and ord.invoice_flag =0
                                and (ord_item.order_qty - ord_item.unload_qty)>0";
                    parameters = new[]
                    {
                        new MySqlParameter("@product_code",_productCode),
                    };
                    var qry = db.Database.SqlQuery<CustomerOrder>(sql, parameters).ToList();
                    var coll = qry.AsEnumerable().Select(p => new
                    {
                        p.order_no,
                        order_date = p.order_date.ToString("dd-MM-yyyy"),
                        p.customer_name,
                        p.address,
                        p.comments
                    }).ToList();
                    gv.DataSource = coll;
                }
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
