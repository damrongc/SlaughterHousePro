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
    public partial class Form_ByProductReceive : Form
    {
        readonly FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        readonly FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;
        SettingsBag MySettings = JsonSettings.Load<SettingsBag>("config.json");
        private product productSelected;
        private product coreProduct;
        private bool isStart = false;
        private bool isTare = false;
        private bool isZero = true;
        bool lockWeight = false;
        int stableCount = 0;
        private int plantID = 0;
        private DateTime productionDate;
        private int stableTarget = 0;
        private int displayTime = 3;
        private int scaleDivision = 100;
        public int LocationCode { get; set; }
        List<System.Windows.Forms.Button> buttons;
        private int Index;
        private readonly int PAGE_SIZE = 12;
        public int ProductGroup { get; set; }
        public string CoreProductCode { get; set; }
        long barcode_no = 0;
        ReportDocument doc = new ReportDocument();
        const int DEFAULT_QTY = 1;
        delegate void SetTextCallback(string text);
        private List<CustomProduct> customProducts;
        private bool firstTime = true;
        public Form_ByProductReceive()
        {
            InitializeComponent();
            UserInitialization();
            btn0.Click += BtnNumber_Click;
            btn1.Click += BtnNumber_Click;
            btn2.Click += BtnNumber_Click;
            btn3.Click += BtnNumber_Click;
            btn4.Click += BtnNumber_Click;
            btn5.Click += BtnNumber_Click;
            btn6.Click += BtnNumber_Click;
            btn7.Click += BtnNumber_Click;
            btn8.Click += BtnNumber_Click;
            btn9.Click += BtnNumber_Click;
        }
        private void BtnNumber_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (lblQty.Text.Length >= 2)
                return;
            if (btn.Text == "0" && string.IsNullOrEmpty(lblQty.Text))
                return;
            else
            {
                if (firstTime)
                {
                    lblQty.Text = btn.Text;
                    firstTime = false;
                }
                else
                {
                    lblQty.Text = (lblQty.Text + btn.Text).ToInt16().ToString();
                }
            }
            if (productSelected != null)
            {
                var qty = lblQty.Text.ToInt16();
                lblMinWeight.Text = (productSelected.min_weight * qty).ToString();
                lblMaxWeight.Text = (productSelected.max_weight * qty).ToString();
            }
        }
        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new SlaughterhouseEntities())
                {
                    coreProduct = db.products.Find(CoreProductCode);
                    lblCaption.Text = coreProduct.product_name;
                    //lblMinWeight.Text = product.min_weight.ToString();
                    //lblMaxWeight.Text = product.max_weight.ToString();
                    //lblProduct.Text = product.product_name;
                    //lblCaption.Text = product.product_name;
                    plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
                    productionDate = db.plants.Find(plantID).production_date;
                    lblCurrentDatetime.Text = productionDate.ToString("dd-MM-yyyy");
                    lblWeight.Text = 0.00.ToString();
                    //lblQty.Text = DEFAULT_QTY.ToString();
                    //var products = db.products.Where(p => p.product_group_code == product.product_group_code).ToList();
                    //flowLayoutPanel1.Controls.Clear();
                    //buttons = new List<System.Windows.Forms.Button>();
                    //foreach (var item in products)
                    //{
                    //    var btn = new System.Windows.Forms.Button
                    //    {
                    //        Text = $"{item.product_code}\r{item.product_name}",
                    //        Width = 180,
                    //        Height = 80,
                    //        FlatStyle = FlatStyle.Flat,
                    //        Font = new Font("Kanit", 14),
                    //        BackColor = Color.WhiteSmoke,
                    //        Tag = item.product_code
                    //    };
                    //    buttons.Add(btn);
                    //    btn.Click += Btn_Click;
                    //}
                    //DisplayPaging();
                    //productList = new List<product>();
                }
                customProducts = new List<CustomProduct>();
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
            serialPort1.DataReceived += port_DataReceived;
            FormClosing += new FormClosingEventHandler(Form_FormClosing);
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            btnAcceptWeight.Enabled = false;
            LoadSetting();
            //var reportPath = Application.StartupPath;
            //doc.Load(reportPath + "\\Report\\Rpt\\barcode.rpt");
            doc.Load(Constants.REPORT_FILE);
            if (System.Diagnostics.Debugger.IsAttached)
                plSimulator.Visible = true;
            else
                plSimulator.Visible = false;
        }
        private void DisplayNotification(string title, string message, Color color)
        {
            var toastNotification = new Notification(title, message, displayTime, color, animationMethod, animationDirection);
            toastNotification.Show();
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
                if (stableTarget == 0)
                {
                    btnAcceptWeight.Visible = true;
                }
                else
                {
                    btnAcceptWeight.Visible = false;
                }
            }
        }
        string InputData = String.Empty;
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
                    //double scaleDecimal = DataInvoke.Substring(22, 2).ToDouble();
                    //double scaleDivision = Math.Pow(10.0, scaleDecimal);
                    //string strFormatWt = scaleDecimal == 0 ? "#0" : "#0." + "0".PadRight(scaleDecimal, '0');
                    short stateOfScale = DataInvoke.Substring(6, 1).ToInt16();
                    short stableWt = DataInvoke.Substring(5, 1).ToInt16();
                    if (stableWt == 2)
                    {
                        lblWeight.Text = "---.---";
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
                            if (num > 0 && num > productSelected.min_weight.ToString().ToDouble())
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
                                ProcessData();
                            }
                        }
                    }
                }
            }
        }
        private void LoadProductByProductGroup()
        {
            using (var db = new SlaughterhouseEntities())
            {
                var receive = db.receives.Where(p => p.receive_no == lblReceiveNo.Text).SingleOrDefault();
                //int stock_qty = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Sum(p => p.receive_qty);
                //decimal stock_wgh = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Sum(p => p.receive_wgh);
                //var receive_item = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).LastOrDefault();
                //int remain_qty = receive.farm_qty - stock_qty;
                lblReceiveNo.Text = receive.receive_no;
                lblFarm.Text = receive.farm.farm_name;
                //lblBreeder.Text = receive.breeder.breeder_name;
                //lblTruckNo.Text = receive.truck.truck_no;
                lblLotNo.Text = receive.lot_no;
                lblFarmQty.Text = receive.farm_qty.ToComma();
                //lblFactoryQty.Text = stock_qty.ToComma();
                //lblFactoryWgh.Text = stock_wgh.ToFormat2Decimal();
                //lblRemainQty.Text = remain_qty.ToComma();
                var products = db.products.Where(p => p.product_group_code == coreProduct.product_group_code).ToList();
                flowLayoutPanel1.Controls.Clear();
                buttons = new List<System.Windows.Forms.Button>();
                var coreProductQty = 0;
                customProducts.Clear();
                //bool foundByProductCompleted = false;
                foreach (var product in products)
                {
                    var sqlParams = new[]{
                           new MySqlParameter("@product_code",product.product_code),
                           new MySqlParameter("@lot_no", receive.lot_no)
                        };
                    var sql = "SELECT sum(qty) AS qty FROM slaughterhouse.barcode where product_code=@product_code  and lot_no =@lot_no group by product_code";
                    var receiveQty = db.Database.SqlQuery<int>(sql, sqlParams).SingleOrDefault();
                    if (product.product_code == CoreProductCode)
                    {
                        coreProductQty = receiveQty;
                    }
                    var btn = new System.Windows.Forms.Button
                    {
                        Text = $"{product.product_code}\r{product.product_name} ({receiveQty})",
                        Width = 180,
                        Height = 80,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Kanit", 14),
                        BackColor = Color.White,
                        Tag = product.product_code
                    };
                    var customProduct = new CustomProduct
                    {
                        ProductCode = product.product_code,
                        ProductName = product.product_name,
                        ReciveQty = receiveQty
                    };
                    customProducts.Add(customProduct);
                    buttons.Add(btn);
                    btn.Click += Btn_Click;
                    //check ถ้าเครื่องในชุด + จำนวนเครื่องในชนิดนั้น ถ้าเท่ากับจำนวนฟาร์ม ห้ามเลือกได้
                    //if ((customProduct.ReciveQty + coreProductQty) >= receive.farm_qty)
                    //{
                    //    btn.Enabled = false;
                    //    btn.BackColor = Color.Gray;
                    //    foundByProductCompleted = true;
                    //}
                }
                // check จำนวนเครื่องในชุด + เครื่องในแต่ละชนิด ถ้ามากกว่าหรือเท่ากับ จำนวนฟาร์ม เครื่องในชุดห้ามเลือกได้
                //if (foundByProductCompleted)
                //{
                //    var btn = buttons.Where(p => p.Tag.ToString() == CoreProductCode).SingleOrDefault();
                //    btn.Enabled = false;
                //    btn.BackColor = Color.Gray;
                //}
                DisplayPaging();
            }
            lblMessage.Text = Constants.START_WAITING;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnReceiveNo_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new Form_LookupSwine(CoreProductCode);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    lblReceiveNo.Text = frm.ReceiveNo;
                    lblQty.Text = "";
                    lblSelectedProduct.Text = "";
                    productSelected = null;
                    LoadProductByProductGroup();
                    //var remain_qty = lblRemainQty.Text.ToInt16();
                    //btnStart.Enabled = remain_qty == 0 ? false : true;
                }
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Diagnostics.Debugger.IsAttached == false)
                {
                    if (!serialPort1.IsOpen)
                        serialPort1.Open();
                }
                if (string.IsNullOrEmpty(lblReceiveNo.Text))
                {
                    throw new Exception("กรุณาเลือก ข้อมูลการรับ!");
                }
                if (productSelected == null)
                {
                    throw new Exception("กรุณาเลือก สินค้า!");
                }
                if (string.IsNullOrEmpty(lblQty.Text))
                {
                    throw new Exception("กรุณาระบุ จำนวนชั่ง!");
                }
                else
                {
                    if (lblQty.Text.ToInt16() == 0)
                    {
                        throw new Exception("กรุณาระบุ จำนวนชั่ง!");
                    }
                }
                //var farmQty = lblFarmQty.Text.ToInt16();
                var scaleQty = lblQty.Text.ToInt16();
                //int coreProductQty = 0;
                //foreach (var item in customProducts)
                //{
                //    if (item.ProductCode == CoreProductCode)
                //    {
                //        coreProductQty = item.ReciveQty;
                //        break;
                //    }
                //}
                //var customProduct = customProducts.Where(p => p.ProductCode == productSelected.product_code).SingleOrDefault();
                //if ((customProduct.ReciveQty + coreProductQty + scaleQty) > farmQty)
                //{
                //    lblQty.Text = "1";
                //    firstTime = true;
                //    throw new Exception("จำนวนชั่ง มากกว่า จำนวนรับ!");
                //}
                bool isValid = ValidateReceiveQty();
                if (!isValid)
                {
                    throw new Exception("จำนวนชั่ง มากกว่า จำนวนรับ!");
                }
                ControlProductBtnAndNumberBtn(false);
                lblMinWeight.Text = (productSelected.min_weight * scaleQty).ToString();
                lblMaxWeight.Text = (productSelected.max_weight * scaleQty).ToString();
                isStart = true;
                isZero = true;
                lblMessage.Text = Constants.WEIGHT_WAITING;
                lblWeight.Text = "0.00";
                btnReceiveNo.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnAcceptWeight.Enabled = true;
                //var frm = new Form_NumericPad();
                //frm.DefaultValue = "1";
                ////var remainQty = lblRemainQty.Text.ToInt16();
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    int scaleQty = frm.ReturnValue;
                //    if (scaleQty <= 0)
                //    {
                //        throw new Exception("จำนวน น้อยกว่า 0");
                //    }
                //    var minWeight = (productSelected.min_weight * scaleQty);
                //    var maxWeight = (productSelected.max_weight * scaleQty);
                //    lblQty.Text = scaleQty.ToString();
                //    lblMinWeight.Text = minWeight.ToString();
                //    lblMaxWeight.Text = maxWeight.ToString();
                //    int coreProductQty = 0;
                //    foreach (var item in customProducts)
                //    {
                //        if (item.ProductCode == CoreProductCode)
                //        {
                //            coreProductQty = item.ReciveQty;
                //            break;
                //        }
                //    }
                //    var customProduct = customProducts.Where(p => p.ProductCode == productSelected.product_code).SingleOrDefault();
                //    if ((customProduct.ReciveQty + coreProductQty + frm.ReturnValue) > farmQty)
                //    {
                //        throw new Exception("จำนวนชั่ง มากกว่า จำนวนรับ!");
                //    }
                //}
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
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
                btnReceiveNo.Enabled = true;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                btnAcceptWeight.Enabled = false;
                ControlProductBtnAndNumberBtn(true);
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }
        private void btnSetWgh_Click(object sender, EventArgs e)
        {
            lblWeight.Text = txtSimWeight.Text.ToDecimal().ToFormat2Decimal();
            if (stableTarget > 0)
            {
                ProcessData();
            }
            //isStart = true;
            //btnReceiveNo.Enabled = false;
            //btnStart.Enabled = false;
            //btnStop.Enabled = true;
            //btnAcceptWeight.Enabled = true;
        }
        private void btnZero_Click(object sender, EventArgs e)
        {
            lblWeight.Text = 0m.ToFormat2Decimal();
            isZero = true;
        }
        private void BtnTareWeight_Click(object sender, EventArgs e)
        {
            isTare = true;
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
            double minWeight = lblMinWeight.Text.ToDouble();
            if (scaleWeight <= minWeight)
            {
                lblMessage.Text = Constants.WEIGHT_WAITING;
                isZero = true;
                stableCount = 0;
                lblStable.Text = stableCount.ToString();
                timerMinWeight.Enabled = false;
                btnAcceptWeight.Enabled = true;
            }
            else
            {
                lblMessage.Text = Constants.MINWEIGHT_WAITING;
            }
        }
        private void BtnAcceptWeight_Click(object sender, EventArgs e)
        {
            ProcessData();
        }
        private void ProcessData()
        {
            try
            {
                isZero = false;
                if (!isStart)
                {
                    throw new Exception("กรุณา เริ่มชั่ง");
                }
                bool isValid = ValidateReceiveQty();
                if (!isValid)
                {
                    throw new Exception("สินค้าชั่งครบแล้ว!");
                }
                decimal scaleWeight = lblWeight.Text.ToDecimal();
                //if (scaleWeight < 0)
                //{
                //    throw new Exception("น้ำหนัก น้อยกว่า 0");
                //}
                if (productSelected == null)
                {
                    throw new Exception("กรุณาเลือก สินค้า!");
                }
                int farmQty = lblFarmQty.Text.ToInt16();
                var minWeight = lblMinWeight.Text.ToDecimal();
                var maxWeight = lblMaxWeight.Text.ToDecimal();
                if (scaleWeight < minWeight)
                {
                    throw new Exception(string.Format("น้ำหนัก น้อยกว่า Min: {0}", minWeight));
                }
                if (scaleWeight > maxWeight)
                {
                    throw new Exception(string.Format("น้ำหนัก มากกว่า Max: {0}", maxWeight));
                }
                btnAcceptWeight.Enabled = false;
                lblMessage.Text = Constants.PROCESSING;
                SaveData();
                DisplayNotification("Success", "บันทึกข้อมูล เรียบร้อย.\rกรุณานำสินค้าออก", Color.Green);
                PrintBarcode();
                LoadProductByProductGroup();
                //clear weight
                lockWeight = false;
                timerMinWeight.Enabled = true;
                //btnReceiveNo.Enabled = true;
                //btnStart.Enabled = true;
                //btnStop.Enabled = false;
                //btnAcceptWeight.Enabled = false;
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }
        private void SaveData()
        {
            try
            {
                var receiveNo = lblReceiveNo.Text;
                var receiveWgh = lblWeight.Text.ToDecimal();
                var receiveQty = lblQty.Text.ToInt16();
                var createBy = Helper.GetLocalIPAddress();
                using (var db = new SlaughterhouseEntities())
                {
                    //int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
                    //var productionDate = db.plants.Find(plantID).production_date;
                    //update receive
                    var receive = db.receives.Find(receiveNo);
                    //int receive_qty = receive.receive_item.Where(p => p.product_code.Equals(productSelected.product_code)).Sum(p => p.receive_qty);
                    //if (receive.farm_qty - receive_qty == 0)
                    //{
                    //    throw new Exception("จำนวนรับครบแล้ว\rไม่สามารถรับเพิ่มได้!");
                    //}
                    int seq = receive.receive_item.Where(p => p.barcode_no > 0).Count();
                    //var receiveByProductBom = db.receive_item_by_product.Find(receiveNo, CoreProductCode, CoreProductCode);
                    //var receiveByProduct = db.receive_item_by_product.Find(receiveNo, CoreProductCode, productSelected.product_code);
                    //if (receiveByProductBom.target_qty - receiveByProduct.actual_qty == 0)
                    //{
                    //    throw new Exception("จำนวนรับครบแล้ว\rไม่สามารถรับเพิ่มได้!");
                    //}
                    //var maxValue = db.barcodes.Max(x => (long?)x.barcode_no) ?? 0;
                    //if (maxValue == 0)
                    //{
                    //    barcode_no = string.Format("{0}0000000001", plantID).ToLong();
                    //}
                    //else
                    //{
                    //    barcode_no = maxValue + 1;
                    //}
                    //int count = db.barcodes.Count();
                    //if (count == 0)
                    //{
                    //    barcode_no = string.Format("{0}0000000001", plantID).ToLong();
                    //}
                    //else
                    //{
                    //    barcode_no = db.barcodes.Max(p => p.barcode_no) + 1;
                    //    if (barcode_no.ToString().Length > 11)
                    //    {
                    //        var tempBarcode = barcode_no.ToString().TrimStart('1');
                    //        var running = tempBarcode.ToLong();
                    //        var code = running.ToString().PadLeft(10, '0');
                    //        barcode_no = string.Format("{0}{1}", plantID, code).ToLong();
                    //    }
                    //}
                    //int seq = db.receive_item.Where(p => p.receive_no == receive.receive_no).Count();
                    //
                    seq += 1;
                    barcode_no = Helper.GetMaxBarcode();
                    var item = new receive_item
                    {
                        receive_no = receive.receive_no,
                        product_code = productSelected.product_code,
                        seq = seq,
                        lot_no = receive.lot_no,
                        sex_flag = "",
                        receive_qty = receiveQty,
                        receive_wgh = receiveWgh,
                        chill_qty = 0,
                        chill_wgh = 0,
                        barcode_no = barcode_no,
                        create_by = createBy
                    };
                    //string stock_no = "";
                    //var stockDocument = (from p in db.document_generate where p.document_type == Constants.STK select p).SingleOrDefault();
                    ////check stock_item_running
                    //var stockItemRunning = db.stock_item_running.Where(p => p.doc_no.Equals(receive.receive_no)).SingleOrDefault();
                    //if (stockItemRunning == null)
                    //{
                    //    //get new stock doc no
                    //    stock_no = Constants.STK + stockDocument.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                    //}
                    //else
                    //{
                    //    stock_no = stockItemRunning.stock_no;
                    //}
                    //var stockNo = StockHelper.GetStockNo(receiveNo).stock_no;
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            //var qrData = string.Format("{0}|00{1}{2}", barcode_no, item.product_code, Convert.ToInt64(receiveWgh * 10000).ToString().PadLeft(6, '0'));
                            //insert barcode
                            var barcode = new barcode
                            {
                                barcode_no = barcode_no,
                                product_code = productSelected.product_code,
                                production_date = productionDate,
                                lot_no = receive.lot_no,
                                qty = receiveQty,
                                wgh = receiveWgh,
                                active = true,
                                create_by = createBy,
                                qrcode_image = Helper.GenerateQRCode(barcode_no.ToString()),
                                //location_code = LocationCode,
                            };
                            db.barcodes.Add(barcode);
                            db.receive_item.Add(item);
                            //var stocks = new List<stock>();
                            //stocks.Add(new stock
                            //{
                            //    stock_date = DateTime.Today,
                            //    stock_no = stock_no,
                            //    stock_item = item.seq,
                            //    product_code = item.product_code,
                            //    stock_qty = item.receive_qty,
                            //    stock_wgh = item.receive_wgh,
                            //    ref_document_no = receive.receive_no,
                            //    ref_document_type = Constants.REV,
                            //    lot_no = receive.lot_no,
                            //    location_code = 1,
                            //    barcode_no = 0,
                            //    transaction_type = 2,
                            //    create_by = item.create_by
                            //});
                            //insert stock
                            //var stock = new stock
                            //{
                            //    stock_date = productionDate,
                            //    stock_no = stockNo,
                            //    stock_item = seq,
                            //    product_code = productSelected.product_code,
                            //    stock_qty = receiveQty,
                            //    stock_wgh = receiveWgh,
                            //    ref_document_no = receive.receive_no,
                            //    ref_document_type = Constants.REV,
                            //    lot_no = receive.lot_no,
                            //    location_code = LocationCode,
                            //    barcode_no = barcode_no,
                            //    transaction_type = 1,
                            //    create_by = createBy
                            //};
                            //db.stocks.Add(stock);
                            switch (CoreProductCode)
                            {
                                //case "04001":
                                //    receive.head_qty += item.receive_qty;
                                //    receive.head_wgh += item.receive_wgh;
                                //    break;
                                case "00-0101":
                                    receive.byproduct_red_qty += receiveQty;
                                    receive.byproduct_red_wgh += receiveWgh;
                                    break;
                                case "00-0201":
                                    receive.byproduct_white_qty += receiveQty;
                                    receive.byproduct_white_wgh += receiveWgh;
                                    break;
                            }
                            db.Entry(receive).State = System.Data.Entity.EntityState.Modified;

                            //if (CoreProductCode == productSelected.product_code)
                            //{
                            //    //var bomItems = (from a in db.boms
                            //    //                join b in db.bom_item on a.bom_code equals b.bom_code
                            //    //                where a.product_code == BomProductCode
                            //    //                select b).ToList();
                            //    var listOfByProduct = db.receive_item_by_product.Where(p => p.receive_no.Equals(receiveNo)
                            //    && p.bom_product_code == CoreProductCode
                            //    && p.product_code != CoreProductCode).ToList();
                            //    foreach (var proudct in listOfByProduct)
                            //    {
                            //        proudct.actual_qty += 1;
                            //        proudct.actual_wgh += 1;
                            //        //db.Entry(proudct).State = System.Data.Entity.EntityState.Modified;
                            //    }
                            //    receiveByProductBom.actual_qty += listOfByProduct.Count;
                            //    receiveByProductBom.actual_wgh += item.receive_wgh;
                            //    //listOfByProduct.ForEach(p => p.actual_qty += item.receive_qty, p.actual_wgh = item.receive_wgh);
                            //}
                            //else
                            //{
                            //    receiveByProductBom.actual_qty += item.receive_qty;
                            //    receiveByProductBom.actual_wgh += item.receive_wgh;
                            //    receiveByProduct.actual_qty += item.receive_qty;
                            //    receiveByProduct.actual_wgh += item.receive_wgh;
                            //    //db.Entry(receiveByProduct).State = System.Data.Entity.EntityState.Modified;
                            //}
                            db.SaveChanges();
                            transaction.Commit();
                            //PrintBarcode();
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
                btnPrint.Enabled = false;
                DataTable dt = Helper.GetBarcode(barcode_no);
                lblMessage.Text = "กำลังพิมพ์สติกเกอร์...";
                //string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report\xml\"));
                //dt.WriteXml(path + @"barcode.xml", XmlWriteMode.WriteSchema);
                doc.SetDataSource(dt);
                doc.PrintToPrinter(1, true, 0, 0);
                lblMessage.Text = Constants.WEIGHT_WAITING;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                btnPrint.Enabled = true;
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblReceiveNo.Text))
                    throw new Exception("กรุณาเลือกข้อมูล");
                var frmBarcode = new Form_Barcode
                {
                    ReceiveNo = lblReceiveNo.Text,
                    ProductCode = "",
                    CoreProductCode = CoreProductCode
                };
                frmBarcode.ShowDialog();
                LoadProductByProductGroup();
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }
        //private void LoadProduct()
        //{
        //    productCode = "";
        //    try
        //    {
        //        using (var db = new SlaughterhouseEntities())
        //        {
        //            var products = db.products.Where(p => p.product_group_code == this.ProductGroup).ToList();
        //            flowLayoutPanel1.Controls.Clear();
        //            buttons = new List<Button>();
        //            foreach (var product in products)
        //            {
        //                var btn = new Button
        //                {
        //                    Text = $"{product.product_code}:{product.product_name}",
        //                    Width = 180,
        //                    Height = 80,
        //                    FlatStyle = FlatStyle.Flat,
        //                    Font = new Font("Kanit", 14),
        //                    BackColor = Color.WhiteSmoke,
        //                    Tag = product.product_code
        //                };
        //                buttons.Add(btn);
        //                btn.Click += Btn_Click;
        //                //flowLayoutPanel1.Controls.Add(btn);
        //            }
        //            DisplayPaging();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        private void btnShowProduct_Click(object sender, EventArgs e)
        {
            var frm = new Form_LookupProduct();
            frm.ProductGroup = 4;
            frm.ShowDialog();
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
        private void Btn_Click(object sender, EventArgs e)
        {
            try
            {
                //var foundPart = false;
                //foreach (var item in customProducts)
                //{
                //    if (item.ProductCode != CoreProductCode)
                //    {
                //        if (item.ReciveQty > 0)
                //        {
                //            foundPart = true;
                //            break;
                //        }
                //    }
                //}
                //if (foundPart)
                //{
                //    throw new Exception("ไม่สามารถรับสินค้าชุดได้\rเนื่องจากรับชิ้น");
                //}
                var btn = (System.Windows.Forms.Button)sender;
                var receiveNo = lblReceiveNo.Text;
                var productSelectedCode = btn.Tag.ToString();
                using (var db = new SlaughterhouseEntities())
                {
                    productSelected = db.products.Find(productSelectedCode);
                    if (productSelected == null) return;
                    lblQty.Text = DEFAULT_QTY.ToString();
                    lblMinWeight.Text = (productSelected.min_weight * int.Parse(lblQty.Text)).ToString();
                    lblMaxWeight.Text = (productSelected.max_weight * int.Parse(lblQty.Text)).ToString();
                    btnStart.Enabled = true;
                    lblSelectedProduct.Text = $"{productSelected.product_code}: {productSelected.product_name}";
                    firstTime = true;
                }
                //btn.BackColor = ColorTranslator.FromHtml("#1C6BBC");
                //btn.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }
        private void lblQty_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int qty = DEFAULT_QTY;
            //    var frm = new Form_NumericPad();
            //    //var remainQty = lblRemainQty.Text.ToInt16();
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        qty = frm.ReturnValue;
            //        //if (qty > remainQty)
            //        //{
            //        //    throw new Exception("จำนวน มากกว่า จำนวนรอชั่ง!");
            //        //}
            //    }
            //    lblQty.Text = qty.ToString();
            //    if (productSelected == null) return;
            //    lblMinWeight.Text = (productSelected.min_weight * int.Parse(lblQty.Text)).ToString();
            //    lblMaxWeight.Text = (productSelected.max_weight * int.Parse(lblQty.Text)).ToString();
            //}
            //catch (Exception ex)
            //{
            //    DisplayNotification("Error", ex.Message, Color.Red);
            //}
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblQty.Text = "";
        }
        private void ControlProductBtnAndNumberBtn(bool isEnabled)
        {
            foreach (Button btn in flowLayoutPanel1.Controls)
            {
                btn.Enabled = isEnabled;
                btn.BackColor = isEnabled ? Color.White : Color.Gray;
            }
            btn0.Enabled = isEnabled;
            btn1.Enabled = isEnabled;
            btn2.Enabled = isEnabled;
            btn3.Enabled = isEnabled;
            btn4.Enabled = isEnabled;
            btn5.Enabled = isEnabled;
            btn6.Enabled = isEnabled;
            btn7.Enabled = isEnabled;
            btn8.Enabled = isEnabled;
            btn9.Enabled = isEnabled;
            btnClear.Enabled = isEnabled;
        }
        private bool ValidateReceiveQty()
        {
            bool isValid = true;
            try
            {
                var farmQty = lblFarmQty.Text.ToInt16();
                var scaleQty = lblQty.Text.ToInt16();
                int coreProductQty = 0;
                foreach (var item in customProducts)
                {
                    if (item.ProductCode == CoreProductCode)
                    {
                        coreProductQty = item.ReciveQty;
                        break;
                    }
                }
                var customProduct = customProducts.Where(p => p.ProductCode == productSelected.product_code).SingleOrDefault();
                if ((customProduct.ReciveQty + coreProductQty + scaleQty) > farmQty)
                {
                    lblQty.Text = "1";
                    firstTime = true;
                    isValid = false;
                }
                return isValid;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
