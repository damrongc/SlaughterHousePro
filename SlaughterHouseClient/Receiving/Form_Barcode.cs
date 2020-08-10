using CrystalDecisions.CrystalReports.Engine;
using SlaughterHouseEF;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ToastNotifications;
namespace SlaughterHouseClient.Receiving
{
    public partial class Form_Barcode : Form
    {
        //int ReceiveFlag { get; set; }
        readonly FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        readonly FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;
        private int displayTime = 3;
        public string ReceiveNo { get; set; }
        public string ProductCode { get; set; }
        public string CoreProductCode { get; set; }
        ReportDocument doc = new ReportDocument();
        public Form_Barcode()
        {
            InitializeComponent();
            Load += Form_Load;
            Shown += Form_Shown;
            //ReceiveFlag = _receiveFlag;
            UserSettingsComponent();
        }
        private void Form_Shown(object sender, EventArgs e)
        {
            //txtBarcodeNo.Focus();
        }
        private void UserSettingsComponent()
        {
            gv.CellContentClick += Gv_CellContentClick;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;
            //txtBarcodeNo.KeyDown += TxtBarcodeNo_KeyDown;
        }
        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    string barcode_no = gv.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (senderGrid.Columns[e.ColumnIndex].Name == "btnDelete")
                    {
                        if (MessageBox.Show($"ต้องการลบข้อมูล บาร์โค็ด {barcode_no} Yes/No?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        //delete barcode
                        using (var db = new SlaughterhouseEntities())
                        {
                            //string stockNo = "";
                            var createBy = Helper.GetLocalIPAddress();
                            var barcode = db.barcodes.Find(barcode_no.ToLong());
                            var receive = db.receives.Find(ReceiveNo);
                            var delReceiveItem = receive.receive_item.Where(p => p.barcode_no == barcode.barcode_no).SingleOrDefault();
                            using (DbContextTransaction transaction = db.Database.BeginTransaction())
                            {
                                try
                                {
                                    var stock = db.stocks.Where(p => p.stock_date == barcode.production_date &&
                                                    p.product_code == barcode.product_code &&
                                                    p.ref_document_no == receive.receive_no &&
                                                    p.barcode_no == barcode.barcode_no).SingleOrDefault();
                                    //var sqlParams = new[]{
                                    //       new MySqlParameter("@production_date",barcode.production_date),
                                    //       new MySqlParameter("@product_code", barcode.product_code)
                                    //    };
                                    //db.Database.ExecuteSqlCommand("delete from stock where ")
                                    //var stockGenerate = db.document_generate.Find(Constants.DEL);
                                    //stockNo = Constants.DEL + stockGenerate.running.ToString().PadLeft(10 - Constants.DEL.Length, '0');
                                    ////insert stock
                                    //var stock = new stock
                                    //{
                                    //    stock_date = barcode.production_date,
                                    //    stock_no = stockNo,
                                    //    stock_item = 1,
                                    //    product_code = barcode.product_code,
                                    //    stock_qty = barcode.qty,
                                    //    stock_wgh = barcode.wgh,
                                    //    ref_document_no = receive.receive_no,
                                    //    ref_document_type = Constants.REV,
                                    //    lot_no = barcode.lot_no,
                                    //    location_code = (int?)barcode.location_code ?? 0,
                                    //    barcode_no = barcode.barcode_no,
                                    //    transaction_type = 2,
                                    //    create_by = createBy
                                    //};
                                    //db.stocks.Add(stock);
                                    //stockGenerate.running += 1;
                                    //db.Entry(stockGenerate).State = System.Data.Entity.EntityState.Modified;
                                    //update qty,weight
                                    db.stocks.Remove(stock);
                                    switch (CoreProductCode)
                                    {
                                        case "04001":
                                            receive.head_qty -= barcode.qty;
                                            receive.head_wgh -= barcode.wgh;
                                            break;
                                        case "00101":
                                            receive.byproduct_red_qty -= barcode.qty;
                                            receive.byproduct_red_wgh -= barcode.wgh;
                                            break;
                                        case "00201":
                                            receive.byproduct_white_qty -= barcode.qty;
                                            receive.byproduct_white_wgh -= barcode.wgh;
                                            break;
                                    }
                                    db.Entry(receive).State = System.Data.Entity.EntityState.Modified;
                                    //delete receive item
                                    db.receive_item.Remove(delReceiveItem);
                                    db.barcodes.Remove(barcode);
                                    db.SaveChanges();
                                    transaction.Commit();
                                    DisplayNotification("Success", $"ลบข้อมูลบาร์โค็ด {barcode_no} เรียบร้อยแล้ว", Color.Green);
                                    //MessageBox.Show($"ลบข้อมูลบาร์โค็ด {barcode_no} เรียบร้อยแล้ว", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    else
                    {
                        //var reportPath = Application.StartupPath;
                        //ds.WriteXml(string.Format(path, "barcode.xml"), XmlWriteMode.WriteSchema);
                        doc.Load(Constants.REPORT_FILE);
                        //doc.Load(reportPath + $"\\Report\\Rpt\\{Constants.REPORT_FILE}");
                        DataTable dt = Helper.GetBarcode(barcode_no.ToLong());
                        //dt.WriteXml(reportPath + "\\Report\\Rpt\\barcode.xml");
                        doc.SetDataSource(dt);
                        doc.PrintToPrinter(1, true, 0, 0);
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
                if (!string.IsNullOrEmpty(ReceiveNo))
                {
                    var barcodes = db.receive_item.Where(p => p.receive_no == ReceiveNo && p.barcode_no > 0).Select(p => new
                    {
                        p.barcode_no,
                        p.product.product_code,
                        p.product.product_name,
                        p.lot_no,
                        p.create_at,
                        p.receive_qty,
                        p.receive_wgh
                    }).OrderByDescending(p => p.barcode_no).ToList();
                    //var qry = db.receives.Where(p => (p.farm_qty - p.factory_qty) > 0).ToList();
                    var coll = barcodes.AsEnumerable().Select(p => new
                    {
                        p.barcode_no,
                        p.product_code,
                        p.product_name,
                        //production_date = p.create_at.ToString("dd-MM-yyyy"),
                        p.lot_no,
                        qty = p.receive_qty.ToComma(),
                        wgh = p.receive_wgh.ToFormat2Decimal()
                    }).ToList();
                    gv.DataSource = coll;
                }
                else
                {
                    var barcodes = db.barcodes.Where(p => p.active == true
                   && p.product_code == ProductCode).Select(p => new
                   {
                       p.barcode_no,
                       p.product.product_code,
                       p.product.product_name,
                       p.production_date,
                       p.lot_no,
                       p.qty,
                       p.wgh
                   }).OrderByDescending(p => p.barcode_no).ToList();
                    //var qry = db.receives.Where(p => (p.farm_qty - p.factory_qty) > 0).ToList();
                    var coll = barcodes.AsEnumerable().Select(p => new
                    {
                        p.barcode_no,
                        p.product_code,
                        p.product_name,
                        //production_date = p.production_date.ToString("dd-MM-yyyy"),
                        p.lot_no,
                        qty = p.qty.ToComma(),
                        wgh = p.wgh.ToFormat2Decimal()
                    }).ToList();
                    gv.DataSource = coll;
                }
                //gv.Columns[0].HeaderText = "รหัสบาร์โค็ด";
                //gv.Columns[1].HeaderText = "รหัสสินค้า";
                //gv.Columns[2].HeaderText = "ชื่อสินค้า";
                //gv.Columns[3].HeaderText = "วันที่ผลิต";
                //gv.Columns[4].HeaderText = "Lot No.";
                //gv.Columns[5].HeaderText = "จำนวน";
                //gv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //gv.Columns[6].HeaderText = "น้ำหนัก(กิโลกรัม)";
                //gv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void DisplayNotification(string title, string message, Color color)
        {
            var toastNotification = new Notification(title, message, displayTime, color, animationMethod, animationDirection);
            toastNotification.Show();
        }
    }
}
