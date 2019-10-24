
using SerialPortListener.Serial;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using System.Collections.Generic;
using ToastNotifications;
using System.IO.Ports;
using System.IO;
using System.Net;
using System.Net.Sockets;
using nucs.JsonSettings;

namespace SlaughterHouseClient.Receiving
{
    public partial class Form_ReceiveProduct : Form
    {
        SettingsBag MySettings = JsonSettings.Load<SettingsBag>("config.json");
        int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();

        product product;
        private int Index;
        private int PAGE_SIZE = 15;
        List<Button> buttons;

        //CrystalReportViewer reportViewer = new CrystalReportViewer();

        private int locationCode = 7;
        private bool isStart = false;
        private bool isTare = false;
        private bool isZero = true;
        bool lockWeight = false;
        int stableCount = 0;
        int stableCountTarget = 0;

        //SerialPortManager _spManager;
        long barcodeNo = 0;
        string lot_no = "";
        string product_code = "";
        ReportDocument doc = new ReportDocument();


        FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;


        delegate void SetTextCallback(string text);
        public Form_ReceiveProduct()
        {
            InitializeComponent();
            UserInitialization();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                lblCurrentDatetime.Text = DateTime.Today.ToString("dd.MM.yyyy");
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

            serialPort1.PortName = Constants.SCALEPORT;
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            LoadSetting();

            using (var db = new SlaughterhouseEntities())
            {

                var plant = db.plants.Find(plantID);
                lblCurrentDatetime.Text = plant.production_date.ToString("dd-MM-yyyy");
            }

            var reportPath = Application.StartupPath;
            doc.Load(reportPath + "\\Report\\Rpt\\barcode.rpt");
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

                stableCountTarget = MySettings["StableTarget"].ToString().ToInt16();
            }
        }

        string InputData = String.Empty;
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);
            InputData = serialPort1.ReadExisting();
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(DisplayWeight), new object[] { InputData });
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
                    short stateOfScale = DataInvoke.Substring(7, 1).ToInt16();
                    short stableWt = DataInvoke.Substring(6, 1).ToInt16();

                    if (stableWt == 2)
                    {
                        lblWeight.Text = "--.---";
                    }
                    else
                    {

                        if (stateOfScale == 0)
                        {
                            num = DataInvoke.Substring(16, 6).ToDouble() / 1000;
                        }
                        else if (stateOfScale == 1)
                        {
                            num = -1.0 * DataInvoke.Substring(16, 6).ToDouble() / 1000;
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
                            if (stableCount >= stableCountTarget)
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

                lblMessage.Text = Constants.PROCESSING;


                SaveData();
                //PlayNotificationSound("normal");

                var toastNotification = new Notification("Success", "บันทึกข้อมูล เรียบร้อย. \rกรุณายกสินค้าออก", 2, Color.Green, animationMethod, animationDirection);
                toastNotification.Show();

                LoadStock();
                //LoadProduct();

                //lblWeight.BackColor = Color.FromArgb(33, 150, 83);
                //lblWeight.ForeColor = Color.White;
                //lblMessage.Text = Constants.SAVE_SUCCESS;
                //await Task.Delay(1000);

                //lblWeight.BackColor = Color.White;
                //lblWeight.ForeColor = Color.Black;
                //LoadProduct(lblReceiveNo.Text);

                //clear weight
                lblLastWeight.Text = lblWeight.Text;
                lockWeight = false;
                timerMinWeight.Enabled = true;

            }
            catch (Exception ex)
            {
                var toastNotification = new Notification("Error", ex.Message, 2, Color.Red, animationMethod, animationDirection);
                toastNotification.Show();
            }

        }

        //private void LoadProduct()
        //{

        //    //flowLayoutPanel1.Controls.Clear();
        //    using (var db = new SlaughterhouseEntities())
        //    {
        //        var products = db.products.Where(p => p.product_group_code == 2).ToList();

        //        foreach (var item in products)
        //        {
        //            var btn = new Button
        //            {
        //                Text = item.product_name,
        //                Width = 150,
        //                Height = 80,
        //                FlatStyle = FlatStyle.Flat,
        //                Font = new Font("Kanit", 16),
        //                BackColor = Color.WhiteSmoke,
        //                Tag = item.product_code



        //            };

        //            btn.Click += Btn_Click;
        //            flowLayoutPanel1.Controls.Add(btn);
        //        }
        //    }
        //}

        //private void Btn_Click(object sender, EventArgs e)
        //{
        //    foreach (Control ctrl in flowLayoutPanel1.Controls)
        //    {
        //        var b = (Button)ctrl;
        //        b.BackColor = Color.WhiteSmoke;
        //        b.ForeColor = Color.Black;
        //    }
        //    var btn = (Button)sender;
        //    btn.BackColor = ColorTranslator.FromHtml("#2D9CDB");
        //    btn.ForeColor = Color.White;
        //    productCode = btn.Tag.ToString();
        //    lblMessage.Text = WEIGHT_WAITING;
        //}

        private void LoadData(string receiveNo)
        {

            using (var db = new SlaughterhouseEntities())
            {
                var receive = db.receives.Where(p => p.receive_no == receiveNo).SingleOrDefault();
                //int stock_qty = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Sum(p => p.receive_qty);
                //decimal stock_wgh = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Sum(p => p.receive_wgh);

                //int remain_qty = receive.farm_qty - stock_qty;
                lblProduct.Text = receive.receive_no;

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

        private void LoadStock()
        {
            using (var db = new SlaughterhouseEntities())
            {
                var productionDate = db.plants.Find(plantID).production_date;
                var stocks = db.stocks.Where(p => p.stock_date == productionDate
                && p.product_code == product_code
                && p.lot_no == lot_no
                && p.transaction_type == 1).Select(p => new
                {
                    p.barcode_no,
                    p.stock_qty,
                    p.stock_wgh
                }).ToList();

                //var stock = (from s in db.stocks
                //             where (s.product_code == product_code && s.lot_no == lot_no && s.transaction_type == 1 && s.stock_date == DateTime.Today)
                //             group s by 1 into g
                //             select new
                //             {
                //                 stock_qty = g.Sum(x => x.stock_qty),
                //                 stock_wgh = g.Sum(x => x.stock_wgh),
                //             });

                //from p in m.Items
                //group p by 1 into g
                //select new
                //{
                //    SumTotal = g.Sum(x => x.Total),
                //    SumDone = g.Sum(x => x.Done)
                //};

                int stock_qty = stocks.Sum(p => p.stock_qty);
                decimal stock_wgh = stocks.Sum(p => p.stock_wgh);

                lblStockQty.Text = stock_qty.ToComma();
                lblStockWgh.Text = stock_wgh.ToFormat2Decimal();
                if (stocks.Count > 0)
                {
                    lblLastWeight.Text = stocks[stocks.Count - 1].stock_wgh.ToFormat2Decimal();
                    barcodeNo = stocks[stocks.Count - 1].barcode_no;
                }
            }
        }

        private void LoadLotNo()
        {
            using (var db = new SlaughterhouseEntities())
            {
                var lotNoList = db.receive_item.Where(p => p.chill_qty > 0
                    && p.transfer_qty == 0
                    && p.product_code == "P002").ToList();

                flowLayoutPanel1.Controls.Clear();

                buttons = new List<Button>();
                foreach (var item in lotNoList)
                {
                    var day = (DateTime.Today - DateTime.Parse(item.modified_at.ToString())).TotalDays;
                    if (day <= 30)
                    {
                        var count = buttons.Where(p => p.Text.Equals(item.lot_no)).Count();
                        if (count == 0)
                        {
                            var btn = new Button
                            {
                                Text = item.lot_no,
                                Width = 200,
                                Height = 80,
                                FlatStyle = FlatStyle.Flat,
                                Font = new Font("Kanit", 14),
                                BackColor = Color.WhiteSmoke,
                                Tag = item.lot_no
                            };

                            buttons.Add(btn);
                            btn.Click += Btn_Click;
                        }
                    }

                    //flowLayoutPanel1.Controls.Add(btn);

                    DisplayPaging();
                }
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
            lot_no = btn.Text;
            LoadProduct();
            LoadStock();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {


            //if (_spManager.CurrentSerialSettings.PortName != "")
            //    _spManager.StartListening();


            try
            {

                if (product == null)
                {
                    throw new Exception("กรุณาเลือกสินค้า!");
                }
                if (!serialPort1.IsOpen)
                    serialPort1.Open();


                isStart = true;
                isZero = true;
                lblMessage.Text = Constants.WEIGHT_WAITING;

                lblWeight.Text = "0.00";
                btnProduct.Enabled = !isStart;
                btnStart.Enabled = !isStart;
                btnStop.Enabled = isStart;
                //btnPrint.Enabled = !isStart;

                lblMessage.Text = Constants.WEIGHT_WAITING;
            }
            catch (Exception ex)
            {
                var toastNotification = new Notification("Error", ex.Message, 2, Color.Red, animationMethod, animationDirection);
                toastNotification.Show();
            }


        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            //if (_spManager.CurrentSerialSettings.PortName != "")
            //    _spManager.StopListening();

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

                btnProduct.Enabled = !isStart;
                btnStart.Enabled = !isStart;
                btnStop.Enabled = isStart;
                //btnPrint.Enabled = !isStart;
            }
            catch (Exception ex)
            {
                var toastNotification = new Notification("Error", ex.Message, 2, Color.Red, animationMethod, animationDirection);
                toastNotification.Show();
            }

        }

        private void SaveData()
        {
            try
            {
                decimal receiveWgh = lblWeight.Text.ToDecimal();
                string createBy = Helper.GetLocalIPAddress();
                string stockNo = "";
                int stockItem = 0;
                using (var db = new SlaughterhouseEntities())
                {
                    var productionDate = db.plants.Find(plantID).production_date;
                    var stocks = db.stocks.Where(p => p.stock_date == productionDate
                        && p.product_code == product_code
                        && p.lot_no == lot_no
                        && p.transaction_type == 1).ToList();

                    if (stocks.Count == 0)
                    {
                        var stockGenerate = db.document_generate.Find(Constants.STK);

                        stockNo = Constants.STK + stockGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                        stockItem = 1;

                        stockGenerate.running += 1;
                        db.Entry(stockGenerate).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        stockNo = stocks[0].stock_no;
                        stockItem = stocks[0].stock_item + 1;
                    }

                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            barcodeNo = db.barcodes.Max(p => p.barcode_no) + 1;
                            //insert barcode
                            var barcode = new barcode
                            {
                                barcode_no = barcodeNo,
                                product_code = product_code,
                                production_date = productionDate,
                                lot_no = lot_no,
                                qty = 1,
                                wgh = receiveWgh,
                                active = true,
                                create_by = createBy
                            };

                            db.barcodes.Add(barcode);
                            //insert receive_item
                            //db.receive_item.Add(item);
                            //insert stock
                            var stock = new stock
                            {
                                stock_date = productionDate,
                                stock_no = stockNo,
                                stock_item = stockItem,
                                product_code = barcode.product_code,
                                stock_qty = barcode.qty,
                                stock_wgh = barcode.wgh,
                                //ref_document_no = receive.receive_no,
                                //ref_document_type = Constants.REV,
                                lot_no = barcode.lot_no,
                                location_code = locationCode,
                                barcode_no = barcodeNo,
                                transaction_type = 1,
                                create_by = createBy
                            };

                            db.stocks.Add(stock);
                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        finally
                        {
                            PrintBarcode();
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
                DataTable dt = Helper.GetBarcode(barcodeNo);
                doc.SetDataSource(dt);
                doc.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void btnSetWgh_Click(object sender, EventArgs e)
        {
            try
            {
                if (product == null)
                {
                    throw new Exception("กรุณาเลือกสินค้า!");
                }
                isStart = true;
                isZero = true;
                lblMessage.Text = Constants.WEIGHT_WAITING;

                lblWeight.Text = "0.00";
                btnProduct.Enabled = !isStart;
                btnStart.Enabled = !isStart;
                btnStop.Enabled = isStart;
                //btnPrint.Enabled = !isStart;

                lblMessage.Text = Constants.WEIGHT_WAITING;
                lblWeight.Text = txtSimWeight.Text.ToDecimal().ToFormat2Decimal();
                ProcessData();
            }
            catch (Exception ex)
            {
                var toastNotification = new Notification("Error", ex.Message, 2, Color.Red, animationMethod, animationDirection);
                toastNotification.Show();
            }


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

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(product_code))
                {
                    var frm = new Form_Barcode();
                    frm.ProductCode = product_code;
                    frm.ShowDialog();
                }
                else
                {
                    throw new Exception("กรุณาเลือกสินค้า!");
                }


            }
            catch (Exception ex)
            {
                var toastNotification = new Notification("Error", ex.Message, 2, Color.Red, animationMethod, animationDirection);
                toastNotification.Show();
            }
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

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    //LoadData(frm.ReceiveNo);
                    //LoadBomItem(bom.bom_code);

                    //lblMessage.Text = Constants.PRODUCT_WAITING;
                    //int stock_qty = 0;
                    //decimal stock_wgh = 0;

                    ////int remain_qty = lblSwineQty.Text.ToInt16() - stock_qty;
                    //lblStockQty.Text = stock_qty.ToComma();
                    //lblStockWgh.Text = stock_wgh.ToFormat2Decimal();
                    ////lblRemainQty.Text = remain_qty.ToComma();
                }
            }
            catch (Exception ex)
            {
                var toastNotification = new Notification("Error", ex.Message, 2, Color.Red, animationMethod, animationDirection);
                toastNotification.Show();
            }
        }

    }
}
