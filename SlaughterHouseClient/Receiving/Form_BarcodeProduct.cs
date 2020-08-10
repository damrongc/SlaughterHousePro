using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using SlaughterHouseClient.Models;
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
    public partial class Form_BarcodeProduct : Form
    {
        //int ReceiveFlag { get; set; }
        private readonly int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
        readonly FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        readonly FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;
        readonly ReportDocument doc = new ReportDocument();
        public bool IsMainProduct { get; set; }
        public Form_BarcodeProduct()
        {
            InitializeComponent();
            Load += Form_Load;
            Shown += Form_Shown;
            //ReceiveFlag = _receiveFlag;
            UserSettingsComponent();
        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            //LoadProductGroup();
            LoadProduct();
            //LoadData();
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
        private void LoadProduct()
        {
            using (var db = new SlaughterhouseEntities())
            {
                var plant = db.plants.Find(plantID);
                var sql = "";
                if (IsMainProduct)
                {
                    sql = @"SELECT distinct a.product_code,b.product_name
                            FROM basic_yield_info a,product b
                            WHERE a.product_code =b.product_code
                            and a.production_date =@production_date";
                }
                else
                {
                    sql = @"SELECT distinct a.product_code,b.product_name
                            FROM special_yield_info a,product b
                            WHERE a.product_code =b.product_code
                            and a.production_date =@production_date";
                }
                var coll = db.Database.SqlQuery<ProductReceived>(sql, new MySqlParameter("production_date", plant.production_date)).ToList();
                //var coll = db.barcodes.Where(p => p.production_date == plant.production_date).ToList();
                //coll.Insert(0, new ProductReceived
                //{
                //    product_code = "",
                //    product_name = "--เลือก--"
                //});
                ddlProduct.DisplayMember = "product_name";
                ddlProduct.ValueMember = "product_code";
                ddlProduct.DataSource = coll.ToList();
                //ddlProduct.SelectedIndex = 0;
            }
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
                            var barcode = db.barcodes.Find(barcode_no.ToLong());
                            if (barcode.location_code != null)
                            {
                                throw new Exception("ไม่สามารถ ลบข้อมูลบาร์โค็ด\r เนื่องจากรับเข้าคลังแล้ว.");
                            }
                            using (DbContextTransaction transaction = db.Database.BeginTransaction())
                            {
                                try
                                {
                                    if (IsMainProduct)
                                    {
                                        var mainProduct = db.basic_yield_info.Where(p => p.barcode_no == barcode.barcode_no).SingleOrDefault();
                                        db.basic_yield_info.Remove(mainProduct);
                                    }
                                    else
                                    {
                                        var specialProduct = db.special_yield_info.Where(p => p.barcode_no == barcode.barcode_no).SingleOrDefault();
                                        db.special_yield_info.Remove(specialProduct);
                                    }
                                    db.barcodes.Remove(barcode);
                                    db.SaveChanges();
                                    transaction.Commit();
                                    DisplayNotification("Success", $"ลบข้อมูลบาร์โค็ด {barcode_no} เรียบร้อยแล้ว", Color.Green);
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
                        doc.Load(Constants.REPORT_FILE);
                        DataTable dt = Helper.GetBarcode(barcode_no.ToLong());
                        doc.SetDataSource(dt);
                        doc.PrintToPrinter(1, true, 0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }
        private void LoadData()
        {
            var productCode = ddlProduct.SelectedValue.ToString();
            //if (string.IsNullOrEmpty(productCode))
            //{
            //    return;
            //}
            using (var db = new SlaughterhouseEntities())
            {
                var plant = db.plants.Find(plantID);
                var barcodes = db.barcodes.Where(p => p.production_date == plant.production_date && p.product_code == productCode);
                //if (!string.IsNullOrEmpty(productCode))
                //{
                //    barcodes = barcodes.Where(p => p.product_code == productCode);
                //}
                var coll = barcodes.Select(p => new
                {
                    p.barcode_no,
                    p.product.product_code,
                    p.product.product_name,
                    p.lot_no,
                    quantity = p.qty,
                    weight = p.wgh
                }).OrderByDescending(p => p.barcode_no).ToList();
                gv.DataSource = coll;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void DisplayNotification(string title, string message, Color color)
        {
            var toastNotification = new Notification(title, message, 3, color, animationMethod, animationDirection);
            toastNotification.Show();
        }
        private void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
