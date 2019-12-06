using MySql.Data.MySqlClient;
using SlaughterHouseClient.Models;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseClient.Issued
{
    public partial class Form_Transport : Form
    {
        public string OrderNo { get; set; }


        const int BARCODE_NO = 0;
        const int TRANSPORT_NO = 6;
        const int PRODUCT_CODE = 7;
        const int SEQ = 8;
        const int STOCK_NO = 9;
        const int BOM_CODE = 10;

        public Form_Transport()
        {
            InitializeComponent();

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

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    long barcodeNo = gv.Rows[e.RowIndex].Cells[BARCODE_NO].Value.ToString().ToLong();
                    if (MessageBox.Show(string.Format("ต้องการยกเลิก รหัสบาร์โค็ด \r\n{0}\r\n ใช่หรือไม่?", barcodeNo), "ยืนยัน",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string transportNo = gv.Rows[e.RowIndex].Cells[TRANSPORT_NO].Value.ToString();
                        string productCode = gv.Rows[e.RowIndex].Cells[PRODUCT_CODE].Value.ToString();
                        int seq = gv.Rows[e.RowIndex].Cells[SEQ].Value.ToString().ToInt16();
                        string stockNo = gv.Rows[e.RowIndex].Cells[STOCK_NO].Value.ToString();
                        int bomCode = gv.Rows[e.RowIndex].Cells[BOM_CODE].Value.ToString().ToInt16();



                        using (var db = new SlaughterhouseEntities())
                        {
                            var productionDate = db.plants.Find(1).production_date;
                            using (DbContextTransaction transaction = db.Database.BeginTransaction())
                            {

                                try
                                {

                                    //update barcode
                                    var barcode = db.barcodes.Find(barcodeNo);
                                    barcode.active = true;
                                    db.Entry(barcode).State = EntityState.Modified;


                                    //update transport item
                                    var transportItem = db.transport_item.Where(p => p.transport_no == transportNo
                                                        && p.product_code == productCode
                                                        && p.seq == seq).SingleOrDefault();

                                    db.transport_item.Remove(transportItem);


                                    //update order item
                                    var orderItem = db.orders_item.Where(p => p.order_no == OrderNo
                                                         && p.product_code == productCode
                                                         && p.bom_code == bomCode).SingleOrDefault();


                                    orderItem.unload_qty -= barcode.qty;
                                    orderItem.unload_wgh -= barcode.wgh;

                                    orderItem.modified_at = null;
                                    orderItem.modified_by = null;
                                    db.Entry(orderItem).State = EntityState.Modified;

                                    //remove stock
                                    var stock = db.stocks.Where(p => p.stock_no == stockNo
                                         && p.stock_date == productionDate
                                         && p.stock_item == seq
                                         && p.product_code == productCode).FirstOrDefault();

                                    db.stocks.Remove(stock);
                                    db.SaveChanges();
                                    transaction.Commit();


                                    MessageBox.Show($"ยกเลิก รหัสบาร์โค็ด {barcodeNo} \r\nเรียบร้อยแล้ว.", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData();


                                }
                                catch (Exception)
                                {
                                    transaction.Rollback();
                                    throw;
                                }
                            }
                        }

                    }



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
                var sql = @"SELECT
                                item.transport_no,
                                stock_no,
                                item.product_code,
                                product_name,
                                seq,
                                transport_qty,
                                transport_wgh,
                                barcode_no,
                                bom_code,
                                lot_no,
                                truck_no,
                                item.create_at,
                                item.create_by
                            FROM
                                transport hd,
                                transport_item item,
                                product p,
                                truck t
                            WHERE
                                ref_document_no = @order_no
                                    AND hd.transport_no = item.transport_no
                                    AND hd.truck_id = t.truck_id
                                    AND item.product_code = p.product_code
                                    AND barcode_no > 0
                            ORDER BY seq DESC";

                var qry = db.Database.SqlQuery<CustomerTransport>(sql, new MySqlParameter("order_no", OrderNo)).ToList();
                var coll = qry.AsEnumerable().Select(p => new
                {
                    p.barcode_no,
                    p.truck_no,
                    p.product_name,
                    transport_qty = p.transport_qty.ToComma(),
                    transport_wgh = p.transport_wgh.ToFormat2Decimal(),
                    create_at = p.create_at.ToString("dd-MM-yyyy HH:mm"),
                    p.transport_no,
                    p.product_code,
                    p.seq,
                    p.stock_no,
                    p.bom_code

                }).ToList();

                gv.DataSource = coll;

                gv.Columns[1].HeaderText = "ทะเบียนรถ";
                gv.Columns[2].HeaderText = "สินค้า";
                gv.Columns[3].HeaderText = "จำนวน";
                gv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                gv.Columns[4].HeaderText = "น้ำหนัก";
                gv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gv.Columns[5].HeaderText = "วันเวลาสแกน";

                gv.Columns[TRANSPORT_NO].Visible = false;
                gv.Columns[PRODUCT_CODE].Visible = false;
                gv.Columns[SEQ].Visible = false;
                gv.Columns[STOCK_NO].Visible = false;
                gv.Columns[BOM_CODE].Visible = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
