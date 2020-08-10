using nucs.JsonSettings;
using SlaughterHouseClient.Receiving;
using SlaughterHouseEF;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ToastNotifications;
namespace SlaughterHouseClient.Issued
{
    public partial class Form_StockIssued : Form
    {
        private readonly SettingsBag MySettings = JsonSettings.Load<SettingsBag>("config.json");
        private readonly int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
        private DateTime productionDate;
        private bool isStart = false;
        //private bool isTare = false;
        private bool isZero = true;
        bool lockWeight = false;
        int stableCount = 0;
        private int stableTarget = 0;
        private int displayTime = 3;
        private int scaleDivision = 100;
        string InputData = string.Empty;
        private barcode barcode;
        //private List<barcode> barcodeIssuedList = new List<barcode>();
        readonly FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        readonly FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;
        private string modifiedBy = string.Empty;
        delegate void SetTextCallback(string text);
        public Form_StockIssued()
        {
            InitializeComponent();
            UserSettingsComponent();
            LoadSetting();
            Shown += Form_Shown;
            txtBarcodeNo.KeyDown += TxtBarcodeNo_KeyDown;
            serialPort1.DataReceived += port_DataReceived;
            FormClosing += new FormClosingEventHandler(Form_FormClosing);
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            if (System.Diagnostics.Debugger.IsAttached)
                plSimulator.Visible = true;
            else
                plSimulator.Visible = false;
        }
        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new SlaughterhouseEntities())
                {
                    var plant = db.plants.Find(plantID);
                    productionDate = plant.production_date;
                    lblCurrentDatetime.Text = productionDate.ToString("dd-MM-yyyy");
                }
                lblMessage.Text = Constants.PLEASE_SCAN;
                modifiedBy = Helper.GetLocalIPAddress();
                LoadRMIssuedInfo();
                //timer.Interval = 1000;
                //timer.Enabled = true;
                //timer.Tick += Timer_Tick;
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }
        private void Form_Shown(object sender, EventArgs e)
        {
            txtBarcodeNo.Focus();
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }
        private void DisplayNotification(string title, string message, Color color)
        {
            var toastNotification = new Notification(title, message, displayTime, color, animationMethod, animationDirection);
            toastNotification.Show();
        }
        private void UserSettingsComponent()
        {
            //gv.CellContentClick += Gv_CellContentClick;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        void LoadSetting()
        {
            if (MySettings.Data.Count > 0)
            {
                serialPort1.PortName = MySettings["Comport"].ToString();
                serialPort1.BaudRate = MySettings["Baudrate"].ToString().ToInt16();
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                stableTarget = MySettings["StableTarget"].ToString().ToInt16();
                displayTime = MySettings["DisplayTime"].ToString().ToInt16();
                scaleDivision = MySettings["Division"].ToString().ToInt16();
            }
        }
        private void TxtBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    LoadBarcode();
            }
            catch (Exception ex)
            {
                txtBarcodeNo.Text = "";
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }
        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new Form_NumericPad();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtBarcodeNo.Text = frm.ReturnValue.ToString();
                    LoadBarcode();
                }
            }
            catch (Exception ex)
            {
                txtBarcodeNo.Text = "";
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }
        private void LoadBarcode()
        {
            try
            {
                using (var db = new SlaughterhouseEntities())
                {
                    lblProduct.Text = "";
                    lblLotNo.Text = "";
                    lblBarcodeWeight.Text = "";
                    lblMinWeight.Text = "0.00";
                    lblMaxWeight.Text = "0.00";

                    var barcodeNo = txtBarcodeNo.Text.ToLong();
                    barcode = db.barcodes.Find(barcodeNo);
                    if (barcode == null)
                    {
                        throw new Exception("ไม่พบข้อมูลบาร์โค็ดนี้!");
                    }
                    //if (barcode.active == false)
                    //{
                    //    throw new Exception("ข้อมูลบาร์โค็ด จ่ายออกแล้ว!");
                    //}
                    if (barcode.location_code == null)
                    {
                        throw new Exception("รหัสบาร์โค็ดนี้ ยังไม่ได้รับเข้าคลัง!");
                    }
                    lblProduct.Text = barcode.product.product_name;
                    lblLotNo.Text = barcode.lot_no;
                    lblBarcodeWeight.Text = barcode.wgh.ToFormat2Decimal();
                    lblMinWeight.Text = barcode.product.min_weight.ToString();
                    lblMaxWeight.Text = barcode.product.max_weight.ToString();
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);
            if (serialPort1.IsOpen)
                InputData = serialPort1.ReadExisting();
            if (InputData != string.Empty)
            {
                BeginInvoke(new SetTextCallback(DisplayWeight), new object[] { InputData });
            }
        }
        private void DisplayWeight(string DataInvoke)
        {
            if (lockWeight == false)
            {
                double num = 0.0;
                if (DataInvoke.Length == 40)
                {
                    short stateOfScale = DataInvoke.Substring(6, 1).ToInt16();
                    short stableWt = DataInvoke.Substring(5, 1).ToInt16();
                    if (stableWt == 2)
                    {
                        lblWeight.Text = "--.---";
                    }
                    else
                    {
                        if (stateOfScale == 0)
                        {
                            num = DataInvoke.Substring(16, 6).ToDouble() / scaleDivision;
                        }
                        else if (stateOfScale == 1)
                        {
                            num = -1.0 * DataInvoke.Substring(16, 6).ToDouble() / scaleDivision;
                        }
                        lblWeight.Text = (num).ToFormat2Double();//ScaleHelper.GetWeightIWX(DataInvoke);
                        if (isStart && isZero)
                        {
                            if (num > lblMinWeight.Text.ToDouble())
                            {
                                if (stableWt == 0)
                                    stableCount += 1;
                                else
                                    stableCount = 0;
                                lblStable.Text = stableCount.ToString();
                                lblStable.Refresh();
                            }
                            if (stableCount >= stableTarget)
                            {
                                lockWeight = true;
                                isZero = false;
                                ProcessData();
                            }
                        }
                    }
                }
            }
        }
        private void ProcessData()
        {
            try
            {
                isZero = false;
                decimal scaleWeight = lblWeight.Text.ToDecimal();
                if (barcode == null)
                {
                    throw new Exception("กรุณา สแกนสินค้า!");
                }
                if (scaleWeight < 0)
                {
                    throw new Exception("น้ำหนัก น้อยกว่า 0");
                }
                if (scaleWeight < barcode.product.min_weight)
                {
                    throw new Exception($"น้ำหนัก น้อยกว่า Min: {barcode.product.min_weight}");
                }
                if (scaleWeight > barcode.product.max_weight)
                {
                    throw new Exception($"น้ำหนัก มากกว่า Max: {barcode.product.max_weight}");
                }
                lblMessage.Text = Constants.PROCESSING;
                SaveData();
                DisplayNotification("Success", "บันทึกข้อมูล เรียบร้อย.", Color.Green);
                LoadRMIssuedInfo();
                lockWeight = false;
                timerMinWeight.Enabled = true;
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
            finally
            {
                ClearDisplay();
            }
        }
        private bool SaveData()
        {
            try
            {
                string createBy = Helper.GetLocalIPAddress();
                string stockNo = "";
                int stockItem = 1;
                decimal scaleWeight = lblWeight.Text.ToDecimal();
                using (var db = new SlaughterhouseEntities())
                {
                    long barcodeNo = txtBarcodeNo.Text.ToLong();
                    var barcode = db.barcodes.Find(barcodeNo);
                    if (barcode == null)
                    {
                        //throw new Exception("ข้อมูลบาร์โค็ด จ่ายออกแล้ว!");
                        throw new Exception("ไม่พบข้อมูลบาร์โค็ดนี้ \rหรือจ่ายออกแล้ว!");
                    }
                    //if (barcode.active == false)
                    //{
                    //    throw new Exception("ข้อมูลบาร์โค็ด จ่ายออกแล้ว!");
                    //}
                    //barcodeIssuedList.Add(barcode);
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            //var issDoc = db.document_generate.Find(Constants.ISS);// (from p in db.document_generate where p.document_type == Constants.ISS select p).SingleOrDefault();
                            //var refDocumentNo = Constants.ISS + issDoc.running.ToString().PadLeft(10 - Constants.ISS.Length, '0');
                            //var refDocumentType = Constants.ISS;
                            var rmIssuedInfo = new rm_issued_info
                            {
                                production_date = productionDate,
                                product_code = barcode.product_code,
                                lot_no = barcode.lot_no,
                                quantity = barcode.qty,
                                weight = scaleWeight,
                                barcode_no = barcode.barcode_no,
                                create_at = DateTime.Now,
                                create_by = createBy
                            };
                            db.rm_issued_info.Add(rmIssuedInfo);
                            //var issuedInfo = db.issued_info.Find(productionDate, barcode.product_code, barcode.lot_no);
                            //if (issuedInfo == null)
                            //{
                            //    var newIssued = new issued_info
                            //    {
                            //        issued_date = productionDate,
                            //        product_code = barcode.product_code,
                            //        lot_no = barcode.lot_no,
                            //        issued_qty = barcode.qty,
                            //        issued_wgh = scaleWeight,
                            //        usage_qty = 0,
                            //        usage_wgh = 0,
                            //        active = true,
                            //        create_at = DateTime.Now,
                            //        create_by = createBy
                            //    };
                            //    db.issued_info.Add(newIssued);
                            //}
                            //else
                            //{
                            //    issuedInfo.issued_qty += barcode.qty;
                            //    issuedInfo.issued_wgh += scaleWeight;
                            //    issuedInfo.modified_at = DateTime.Now;
                            //    issuedInfo.modified_by = createBy;
                            //    db.Entry(issuedInfo).State = System.Data.Entity.EntityState.Modified;
                            //}
                            //var stockGenerate = db.document_generate.Find(Constants.STK);
                            ////check stock_item_running
                            //var stockItemRunning = db.stock_item_running.Where(p => p.doc_no.Equals(refDocumentNo)).SingleOrDefault();
                            //if (stockItemRunning == null)
                            //{
                            //    //get new stock doc no
                            //    stockNo = Constants.STK + stockGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                            //    stockItem = 1;
                            //}
                            //else
                            //{
                            //    stockNo = stockItemRunning.stock_no;
                            //    stockItem = stockItemRunning.stock_item + 1;
                            //}
                            //insert stock

                            stockNo = Helper.GetDocGenerator(Constants.STK);

                            var stock = new stock
                            {
                                stock_date = productionDate,
                                stock_no = stockNo,
                                stock_item = stockItem,
                                product_code = barcode.product_code,
                                stock_qty = barcode.qty,
                                stock_wgh = scaleWeight,
                                //ref_document_no = refDocumentNo,
                                //ref_document_type = refDocumentType,
                                lot_no = barcode.lot_no,
                                location_code = 0,
                                barcode_no = barcode.barcode_no,
                                transaction_type = 2,
                                create_by = createBy
                            };
                            db.stocks.Add(stock);
                            //if (stockItem == 1)
                            //{
                            //    stockGenerate.running += 1;
                            //    db.Entry(stockGenerate).State = System.Data.Entity.EntityState.Modified;
                            //}
                            //set barcode
                            db.barcodes.Remove(barcode);
                            //barcode.active = false;
                            //db.Entry(barcode).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LoadRMIssuedInfo()
        {
            try
            {
                using (var db = new SlaughterhouseEntities())
                {
                    //var barcode = db.barcodes.Find(txtBarcodeNo.Text.ToLong());
                    //barcodeIssuedList.Add(new barcode
                    //{
                    //    barcode_no = barcode.barcode_no,
                    //    product_code = barcode.product_code,
                    //    product = barcode.product,
                    //    lot_no = barcode.lot_no,
                    //    qty = barcode.qty,
                    //    wgh = barcode.wgh,
                    //    modified_at = barcode.modified_at
                    //});
                    var qry = db.rm_issued_info.Where(p => p.production_date == productionDate)
                        .OrderByDescending(p => p.create_at).ToList();
                    var coll = qry.AsEnumerable().Select(p => new
                    {
                        p.barcode_no,
                        p.product_code,
                        p.product.product_name,
                        p.lot_no,
                        p.quantity,
                        p.weight,
                        create_at = p.create_at.ToString("dd/MM/yyyy HH:mm")
                    }).ToList();
                    gv.DataSource = coll;
                    gv.Columns[0].HeaderText = "รหัส";
                    gv.Columns[1].HeaderText = "รหัสสินค้า";
                    gv.Columns[2].HeaderText = "ชื่อสินค้า";
                    gv.Columns[3].HeaderText = "Lot No.";
                    gv.Columns[4].HeaderText = "จำนวน";
                    gv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gv.Columns[5].HeaderText = "น้ำหนัก";
                    gv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gv.Columns[6].HeaderText = "วันเวลาสแกน";
                }
                //var coll = barcodeIssuedList.Select(p => new
                //{
                //    p.barcode_no,
                //    p.product_code,
                //    p.product.product_name,
                //    p.lot_no,
                //    qty = p.qty.ToComma(),
                //    wgh = p.wgh.ToFormat2Decimal(),
                //    modified_at = p.modified_at == null ? "" : Convert.ToDateTime(p.modified_at).ToString("dd-MM-yyyy HH:mm")
                //}).OrderByDescending(p => p.modified_at).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ClearDisplay()
        {
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            txtBarcodeNo.Text = "";
            txtBarcodeNo.Focus();
            lblMessage.Text = Constants.PLEASE_SCAN;
        }
        private void btnSetWgh_Click(object sender, EventArgs e)
        {
            lblWeight.Text = txtSimWeight.Text.ToDecimal().ToFormat2Decimal();
            ProcessData();
        }
        private void btnZero_Click(object sender, EventArgs e)
        {
            lblWeight.Text = 0m.ToFormat2Decimal();
        }
        private void timerMinWeight_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            double scaleWeight = lblWeight.Text.ToDouble();
            if (scaleWeight <= 0)
            {
                lblMessage.Text = Constants.WEIGHT_WAITING;
                isZero = true;
                stableCount = 0;
                lblStable.Text = stableCount.ToString();
                timerMinWeight.Enabled = false;
            }
            else
            {
                lblMessage.Text = Constants.MINWEIGHT_WAITING;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached == false)
            {
                if (!serialPort1.IsOpen)
                    serialPort1.Open();
            }
            isStart = true;
            isZero = true;
            lblMessage.Text = Constants.WEIGHT_WAITING;
            lblWeight.Text = "0.00";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            txtBarcodeNo.Enabled = false;
            btnKeyboard.Enabled = false;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            txtBarcodeNo.Enabled = true;
            btnKeyboard.Enabled = true;
            txtBarcodeNo.Focus();
        }
    }
}
