using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using nucs.JsonSettings;
using SlaughterHouseClient.Models;
using SlaughterHouseEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ToastNotifications;
namespace SlaughterHouseClient.Receiving
{
    public partial class Form_ReceiveSpecialProduct : Form
    {
        readonly SettingsBag MySettings = JsonSettings.Load<SettingsBag>("config.json");
        private readonly int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
        //const string PRODUCT_CODE = "00000";
        private List<RMIssuedInfo> issuedProducts;
        private RMIssuedInfo issuedProductSelected;
        product product;
        private DateTime productionDate;
        private int Index;
        private readonly int PAGE_SIZE = 15;
        List<Button> buttons;
        //CrystalReportViewer reportViewer = new CrystalReportViewer();
        //private int locationCode = 7;
        private bool isStart = false;
        //private bool isTare = false;
        private bool isZero = true;
        bool lockWeight = false;
        int stableCount = 0;
        private int stableTarget = 0;
        private int displayTime = 3;
        private int scaleDivision = 100;
        //SerialPortManager _spManager;
        long barcode_no = 0;
        //string lot_no = string.Empty;
        string product_code = string.Empty;
        string InputData = string.Empty;
        readonly ReportDocument doc = new ReportDocument();
        FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;
        delegate void SetTextCallback(string text);
        public Form_ReceiveSpecialProduct()
        {
            InitializeComponent();
            UserInitialization();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new SlaughterhouseEntities())
                {
                    //product = db.products.Find(ProductCode);
                    //lblMinWeight.Text = product.min_weight.ToString();
                    //lblMaxWeight.Text = product.max_weight.ToString();
                    //lblProduct.Text = product.product_name;
                    //lblCaption.Text = product.product_name;
                    var plant = db.plants.Find(plantID);
                    productionDate = plant.production_date;
                    lblCurrentDatetime.Text = productionDate.ToString("dd-MM-yyyy");
                }
                lblMessage.Text = Constants.CHOOSE_QUEUE;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
            //    _spManager.StopListening();
            //_spManager.Dispose();
        }
        private void UserInitialization()
        {
            //_spManager = new SerialPortManager();
            //SerialSettings mySerialSettings = _spManager.CurrentSerialSettings;
            //_spManager.CurrentSerialSettings.PortName = Constants.SCALEPORT;
            //mySerialSettings.PortName = "COM1";
            //serialSettingsBindingSource.DataSource = mySerialSettings;
            //portNameComboBox.DataSource = mySerialSettings.PortNameCollection;
            //baudRateComboBox.DataSource = mySerialSettings.BaudRateCollection;
            //dataBitsComboBox.DataSource = mySerialSettings.DataBitsCollection;
            //parityComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.Parity));
            //stopBitsComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.StopBits));
            //_spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
            serialPort1.DataReceived += port_DataReceived;
            FormClosing += new FormClosingEventHandler(Form_FormClosing);
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            LoadSetting();
            doc.Load(Constants.REPORT_FILE);
            //var reportPath = Application.StartupPath;
            //doc.Load(reportPath + "\\Report\\Rpt\\barcode_and_qrcode.rpt");
            if (System.Diagnostics.Debugger.IsAttached)
                plSimulator.Visible = true;
            else
                plSimulator.Visible = false;
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
        private void DisplayNotification(string title, string message, Color color)
        {
            var toastNotification = new Notification(title, message, displayTime, color, animationMethod, animationDirection);
            toastNotification.Show();
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
                    //int scaleDecimal = DataInvoke.Substring(20, 2).ToInt32();
                    //int scaleDivision = (int)Math.Round(Math.Pow(10.0, unchecked(scaleDecimal)));
                    //string strFormatWt = scaleDecimal == 0 ? "#0" : "#0." + "0".PadRight(scaleDecimal, '0');
                    //short stateOfScale = DataInvoke.Substring(2, 1).ToInt16();
                    //short stableWt = DataInvoke.Substring(4, 1).ToInt16();
                    //if (stateOfScale == 0)
                    //{
                    //    num = DataInvoke.Substring(14, 6).ToDouble() / scaleDivision;
                    //}
                    //else
                    //{
                    //    num = -1.0 * DataInvoke.Substring(14, 6).ToDouble() / scaleDivision;
                    //}
                    //int scaleDecimal = DataInvoke.Substring(22, 2).ToInt32();
                    //int scaleDivision = (int)Math.Round(Math.Pow(10.0, unchecked(scaleDecimal)));
                    //string strFormatWt = scaleDecimal == 0 ? "#0" : "#0." + "0".PadRight(scaleDecimal, '0');
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
        private void LoadProduct()
        {
            using (var db = new SlaughterhouseEntities())
            {
                product = db.products.Where(p => p.product_code.Equals(product_code)).SingleOrDefault();
                lblProduct.Text = product.product_name;
                lblMinWeight.Text = product.min_weight.ToString();
                lblMaxWeight.Text = product.max_weight.ToString();
            }
        }
        //private void LoadStock()
        //{
        //    using (var db = new SlaughterhouseEntities())
        //    {
        //        var stocks = db.stocks.Where(p => p.stock_date == productionDate
        //        && p.product_code == product_code
        //        && p.lot_no == lot_no
        //        && p.transaction_type == 1).Select(p => new
        //        {
        //            p.barcode_no,
        //            p.stock_qty,
        //            p.stock_wgh
        //        }).ToList();
        //        //var stock = (from s in db.stocks
        //        //             where (s.product_code == product_code && s.lot_no == lot_no && s.transaction_type == 1 && s.stock_date == DateTime.Today)
        //        //             group s by 1 into g
        //        //             select new
        //        //             {
        //        //                 stock_qty = g.Sum(x => x.stock_qty),
        //        //                 stock_wgh = g.Sum(x => x.stock_wgh),
        //        //             });
        //        //from p in m.Items
        //        //group p by 1 into g
        //        //select new
        //        //{
        //        //    SumTotal = g.Sum(x => x.Total),
        //        //    SumDone = g.Sum(x => x.Done)
        //        //};
        //        int stock_qty = stocks.Sum(p => p.stock_qty);
        //        decimal stock_wgh = stocks.Sum(p => p.stock_wgh);
        //        lblStockQty.Text = stock_qty.ToComma();
        //        lblStockWgh.Text = stock_wgh.ToFormat2Decimal();
        //        if (stocks.Count > 0)
        //        {
        //            lblLastWeight.Text = stocks[stocks.Count - 1].stock_wgh.ToFormat2Decimal();
        //            barcode_no = stocks[stocks.Count - 1].barcode_no;
        //        }
        //        else
        //        {
        //            lblLastWeight.Text = 0.0.ToFormat2Double();
        //            barcode_no = 0;
        //        }
        //    }
        //}
        private void LoadLotNo()
        {
            flowLayoutPanel1.Controls.Clear();
            buttons = new List<Button>();
            List<string> lotNoList = new List<string>();
            using (var db = new SlaughterhouseEntities())
            {
                //var sql = @"SELECT distinct a.product_code,a.lot_no,b.product_name
                //                FROM issued_info a,product b
                //                WHERE a.product_code =b.product_code
                //                and a.product_code <>'00000'
                //                and issued_date =@issued_date";
                var sql = @"SELECT distinct a.product_code,a.lot_no,b.product_name
                                FROM rm_issued_info a,product b
                                WHERE a.product_code =b.product_code
                                and a.production_date =@production_date";
                issuedProducts = db.Database.SqlQuery<RMIssuedInfo>(sql, new MySqlParameter("production_date", productionDate)).ToList();
                var idx = 0;
                foreach (var item in issuedProducts)
                {
                    var btn = new Button
                    {
                        Text = $"{item.product_code}-{item.product_name}\r{item.lot_no}",
                        Width = 180,
                        Height = 80,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Kanit", 14),
                        BackColor = Color.WhiteSmoke,
                        Tag = idx
                    };
                    buttons.Add(btn);
                    btn.Click += Btn_Click;
                }
                Index = 0;
                DisplayPaging();
            }
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
            btn.BackColor = ColorTranslator.FromHtml("#2D9CDB");
            btn.ForeColor = Color.White;
            //lot_no = $"{btn.Text}{plantID}{productionDate.ToString("ddMM")}";
            issuedProductSelected = issuedProducts[btn.Tag.ToString().ToInt16()];
            //LoadProduct();
            //LoadStock();
        }
        private void BtnUp_Click(object sender, EventArgs e)
        {
            if (Index > 0)
            {
                Index -= PAGE_SIZE;
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
                Index += PAGE_SIZE;
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (product == null)
                {
                    throw new Exception("กรุณาเลือก สินค้าพิเศษ!");
                }
                if (issuedProductSelected == null)
                {
                    throw new Exception("กรุณาเลือก สินค้าหลักและล็อต!");
                }
                if (System.Diagnostics.Debugger.IsAttached == false)
                {
                    if (!serialPort1.IsOpen)
                        serialPort1.Open();
                }
                isStart = true;
                isZero = true;
                lblMessage.Text = Constants.WEIGHT_WAITING;
                lblWeight.Text = "0.00";
                btnProduct.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
            //try
            //{
            //    if (product == null)
            //    {
            //        throw new Exception("กรุณาเลือกสินค้า!");
            //    }
            //    if (!serialPort1.IsOpen)
            //        serialPort1.Open();
            //    isStart = true;
            //    isZero = true;
            //    lblMessage.Text = Constants.WEIGHT_WAITING;
            //    lblWeight.Text = "0.00";
            //    btnProduct.Enabled = !isStart;
            //    btnStart.Enabled = !isStart;
            //    btnStop.Enabled = isStart;
            //    //btnPrint.Enabled = !isStart;
            //    lblMessage.Text = Constants.WEIGHT_WAITING;
            //}
            //catch (Exception ex)
            //{
            //    var toastNotification = new Notification("Error", ex.Message, displayTime, Color.Red, animationMethod, animationDirection);
            //    toastNotification.Show();
            //}
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                    serialPort1.Close();
                stableCount = 0;
                isStart = false;
                lockWeight = false;
                lblWeight.Text = "0.00";
                lblWeight.Refresh();
                lblStable.Text = stableCount.ToString();
                lblStable.Refresh();
                btnProduct.Enabled = true;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
            ////if (_spManager.CurrentSerialSettings.PortName != "")
            ////    _spManager.StopListening();
            //try
            //{
            //    if (serialPort1.IsOpen)
            //        serialPort1.Close();
            //    stableCount = 0;
            //    isStart = false;
            //    lockWeight = false;
            //    lblWeight.Text = "0.00";
            //    lblWeight.Refresh();
            //    lblStable.Text = stableCount.ToString();
            //    lblStable.Refresh();
            //    btnProduct.Enabled = !isStart;
            //    btnStart.Enabled = !isStart;
            //    btnStop.Enabled = isStart;
            //    //btnPrint.Enabled = !isStart;
            //}
            //catch (Exception ex)
            //{
            //    var toastNotification = new Notification("Error", ex.Message, displayTime, Color.Red, animationMethod, animationDirection);
            //    toastNotification.Show();
            //}
        }
        private void ProcessData()
        {
            try
            {
                if (product == null)
                {
                    throw new Exception("กรุณาเลือก สินค้าพิเศษ!");
                }
                if (issuedProductSelected == null)
                {
                    throw new Exception("กรุณาเลือก สินค้าหลักและล็อต!");
                }
                decimal scaleWeight = lblWeight.Text.ToDecimal();
                if (scaleWeight < 0)
                {
                    throw new Exception("น้ำหนัก น้อยกว่า 0");
                }
                if (scaleWeight < product.min_weight)
                {
                    throw new Exception($"น้ำหนัก น้อยกว่า Min: {product.min_weight}");
                }
                if (scaleWeight > product.max_weight)
                {
                    throw new Exception($"น้ำหนัก มากกว่า Max: {product.max_weight}");
                }
                isZero = false;
                lblMessage.Text = Constants.PROCESSING;
                SaveData();
                DisplayNotification("Success", "บันทึกข้อมูล เรียบร้อย.\rกรุณานำสินค้าออก", Color.Green);
                PrintBarcode();
                //LoadStock();
                //clear weight
                //lblLastWeight.Text = lblWeight.Text;
                lockWeight = false;
                timerMinWeight.Enabled = true;
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }
        private bool SaveData()
        {
            try
            {
                decimal receiveWgh = lblWeight.Text.ToDecimal();
                string createBy = Helper.GetLocalIPAddress();
                //string stockNo = "";
                //int stockItem = 0;
                barcode_no = Helper.GetMaxBarcode();
                using (var db = new SlaughterhouseEntities())
                {
                    //var barcodeGenerate = db.document_generate.Find(Constants.BAR);
                    //barcodeGenerate.running += 1;
                    //barcodeNo = barcodeGenerate.running;
                    //db.Entry(barcodeGenerate).State = System.Data.Entity.EntityState.Modified;
                    //db.SaveChanges();
                    //var stocks = db.stocks.Where(p => p.stock_date == productionDate
                    //    && p.product_code == product_code
                    //    && p.lot_no == lot_no
                    //    && p.transaction_type == 1).ToList();
                    //if (stocks.Count == 0)
                    //{
                    //    var stockGenerate = db.document_generate.Find(Constants.STK);
                    //    stockNo = Constants.STK + stockGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                    //    stockItem = 1;
                    //    stockGenerate.running += 1;
                    //    db.Entry(stockGenerate).State = System.Data.Entity.EntityState.Modified;
                    //    db.SaveChanges();
                    //}
                    //else
                    //{
                    //    stockNo = stocks[0].stock_no;
                    //    stockItem = stocks.Count + 1;
                    //}
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            //Get Barcode
                            //var maxValue = db.barcodes.Max(x => (long?)x.barcode_no) ?? 0;
                            //if (maxValue == 0)
                            //{
                            //    barcode_no = string.Format("{0}0000000001", plantID).ToLong();
                            //}
                            //else
                            //{
                            //    barcode_no = maxValue + 1;
                            //}
                            //var barString = barcodeNo.ToString().PadLeft(12, '0');
                            //barcode_no = string.Format("{0}{1}", plantID, barString).ToLong();
                            //insert barcode
                            var barcode = new barcode
                            {
                                barcode_no = barcode_no,
                                product_code = product_code,
                                production_date = productionDate,
                                lot_no = issuedProductSelected.lot_no,
                                qty = 1,
                                wgh = receiveWgh,
                                active = true,
                                create_by = createBy,
                                qrcode_image = Helper.GenerateQRCode(barcode_no.ToString()),
                                //location_code = locationCode
                            };
                            db.barcodes.Add(barcode);
                            //insert basic_yield_info
                            var specialYield = new special_yield_info
                            {
                                production_date = productionDate,
                                product_code = barcode.product_code,
                                lot_no = barcode.lot_no,
                                quantity = barcode.qty,
                                weight = barcode.wgh,
                                ref_product_code = issuedProductSelected.product_code,
                                ref_lot_no = issuedProductSelected.lot_no,
                                barcode_no = barcode_no,
                                create_by = createBy
                            };
                            db.special_yield_info.Add(specialYield);
                            //insert receive_item
                            //db.receive_item.Add(item);
                            //insert stock
                            //var stock = new stock
                            //{
                            //    stock_date = productionDate,
                            //    stock_no = stockNo,
                            //    stock_item = stockItem,
                            //    product_code = barcode.product_code,
                            //    stock_qty = barcode.qty,
                            //    stock_wgh = barcode.wgh,
                            //    //ref_document_no = receive.receive_no,
                            //    //ref_document_type = Constants.REV,
                            //    lot_no = barcode.lot_no,
                            //    location_code = locationCode,
                            //    barcode_no = barcode_no,
                            //    transaction_type = 1,
                            //    create_by = createBy
                            //};
                            //db.stocks.Add(stock);
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
        private void PrintBarcode()
        {
            try
            {
                DataTable dt = Helper.GetBarcode(barcode_no);
                doc.SetDataSource(dt);
                lblMessage.Text = "กำลังพิมพ์สติกเกอร์...";
                doc.PrintToPrinter(1, true, 0, 0);
                lblMessage.Text = Constants.WEIGHT_WAITING;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnSetWgh_Click(object sender, EventArgs e)
        {
            lblWeight.Text = txtSimWeight.Text.ToDecimal().ToFormat2Decimal();
            ProcessData();
            //try
            //{
            //    if (product == null)
            //    {
            //        throw new Exception("กรุณาเลือกสินค้า!");
            //    }
            //    isStart = true;
            //    isZero = true;
            //    lblMessage.Text = Constants.WEIGHT_WAITING;
            //    lblWeight.Text = "0.00";
            //    btnProduct.Enabled = !isStart;
            //    btnStart.Enabled = !isStart;
            //    btnStop.Enabled = isStart;
            //    //btnPrint.Enabled = !isStart;
            //    lblMessage.Text = Constants.WEIGHT_WAITING;
            //    lblWeight.Text = txtSimWeight.Text.ToDecimal().ToFormat2Decimal();
            //    ProcessData();
            //}
            //catch (Exception ex)
            //{
            //    var toastNotification = new Notification("Error", ex.Message, displayTime, Color.Red, animationMethod, animationDirection);
            //    toastNotification.Show();
            //}
        }
        private void btnZero_Click(object sender, EventArgs e)
        {
            lblWeight.Text = 0m.ToFormat2Decimal();
        }
        //const string PaperSizeName = "6 x 6";
        //public Int32 GetPaperSize(String sPrinterName, String sPaperSizeName)
        //{
        //    PrintDocument docPrintDoc = new PrintDocument();
        //    docPrintDoc.PrinterSettings.PrinterName = sPrinterName;
        //    for (int i = 0; i < docPrintDoc.PrinterSettings.PaperSizes.Count; i++)
        //    {
        //        int raw = docPrintDoc.PrinterSettings.PaperSizes[i].RawKind;
        //        if (docPrintDoc.PrinterSettings.PaperSizes[i].PaperName == sPaperSizeName)
        //        {
        //            return raw;
        //        }
        //    }
        //    return 0;
        //}
        //private void CrystalReportCustomPaperSize(string ProgramCode, string ReportID, ref ReportDocument Report)
        //{
        //    string PrinterName = null;
        //    string[] PaperSizeList = null;
        //    System.Drawing.Printing.PrinterSettings aPrinterSettings = new System.Drawing.Printing.PrinterSettings();
        //    PrinterName = aPrinterSettings.PrinterName.ToString();
        //    if ((PaperSizeName != null))
        //    {
        //        System.Drawing.Printing.PrintDocument DocToPrint = new System.Drawing.Printing.PrintDocument();
        //        DocToPrint.PrinterSettings.PrinterName = PrinterName;
        //        PaperSizeList = new string[DocToPrint.PrinterSettings.PaperSizes.Count + 1];
        //        for (int i = 0; i <= DocToPrint.PrinterSettings.PaperSizes.Count - 1; i++)
        //        {
        //            int rawKind = 0;
        //            // PaperSizeList(i) = DocToPrint.PrinterSettings.PaperSizes(i).PaperName;
        //            if (DocToPrint.PrinterSettings.PaperSizes[i].PaperName == PaperSizeName)
        //            {
        //                rawKind = Convert.ToInt32(DocToPrint.PrinterSettings.PaperSizes[i].GetType().GetField("kind", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(DocToPrint.PrinterSettings.PaperSizes[i]));
        //                Report.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                CrystalDecisions.Shared.PageMargins Margins = new CrystalDecisions.Shared.PageMargins();
        //                Margins = Report.PrintOptions.PageMargins;
        //                Margins.leftMargin = 0;
        //                Margins.topMargin = 0;
        //                Margins.rightMargin = 0;
        //                Margins.bottomMargin = 0;
        //                //if (LefMargin >= 0)
        //                //    Margins.leftMargin = LefMargin * TWIP;
        //                //if (RightMargin >= 0)
        //                //    Margins.rightMargin = RightMargin * TWIP;
        //                //if (TopMargin >= 0)
        //                //    Margins.topMargin = TopMargin * TWIP;
        //                //if (ButtomMargin >= 0)
        //                //    Margins.bottomMargin = ButtomMargin * TWIP;
        //                //Report.PrintOptions.ApplyPageMargins(Margins);
        //                break; // TODO: might not be correct. Was : Exit For
        //            }
        //        }
        //    }
        //}
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            var frm = new Form_BarcodeProduct
            {
                IsMainProduct = false
            };
            frm.ShowDialog();
            //try
            //{
            //    if (!string.IsNullOrEmpty(product_code))
            //    {
            //        var frm = new Form_Barcode
            //        {
            //            ProductCode = product_code
            //        };
            //        frm.ShowDialog();
            //    }
            //    else
            //    {
            //        throw new Exception("กรุณาเลือก สินค้า!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    DisplayNotification("Error", ex.Message, Color.Red);
            //}
        }
        private void TimerMinWeight_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }
        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        }
        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
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
        private void btnZeroWeight_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("Z \r\n");
                }
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new Form_LookupProduct();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    product_code = frm.ProductCode;
                    LoadProduct();
                    LoadLotNo();
                    btnStart.Enabled = true;
                    issuedProductSelected = null;
                }
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }
    }
}
