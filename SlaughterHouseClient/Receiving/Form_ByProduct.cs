
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
    public partial class Form_ByProduct : Form
    {
        SettingsBag MySettings = JsonSettings.Load<SettingsBag>("config.json");
        product product;
        string productCode;

        bom bom;
        private int Index;
        private int PAGE_SIZE = 15;
        List<Button> buttons;

        //CrystalReportViewer reportViewer = new CrystalReportViewer();

        private int _locationCode;
        private bool isStart = false;
        private bool isTare = false;
        private bool isZero = true;
        bool lockWeight = false;
        int stableCount = 0;
        int stableCountTarget = 0;

        //SerialPortManager _spManager;
        long barcode_no = 0;
        ReportDocument doc = new ReportDocument();


        delegate void SetTextCallback(string text);
        public Form_ByProduct(string title, int bomCode, int locationCode)
        {
            InitializeComponent();
            UserInitialization();


            _locationCode = locationCode;
            lblCaption.Text = title;
            using (var db = new SlaughterhouseEntities())
            {
                bom = db.boms.Where(p => p.bom_code == bomCode).SingleOrDefault();
            }




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


            var reportPath = Application.StartupPath;
            doc.Load(reportPath + "\\Report\\Rpt\\barcode.rpt");
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

                    int scaleDecimal = DataInvoke.Substring(22, 2).ToInt32();
                    int scaleDivision = (int)Math.Round(Math.Pow(10.0, unchecked(scaleDecimal)));

                    string strFormatWt = scaleDecimal == 0 ? "#0" : "#0." + "0".PadRight(scaleDecimal, '0');
                    short stateOfScale = DataInvoke.Substring(7, 1).ToInt16();
                    short stableWt = DataInvoke.Substring(5, 1).ToInt16();

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
                            if (num > 0 && num > lblMinWeight.Text.ToDouble())
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
                var animationDirection = FormAnimator.AnimationDirection.Up;
                var animationMethod = FormAnimator.AnimationMethod.Slide;
                var toastNotification = new Notification("Success", "บันทึกข้อมูล เรียบร้อย. \rกรุณายกสินค้าออก", 2, Color.Green, animationMethod, animationDirection);
                toastNotification.Show();
                LoadProduct();

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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lblReceiveNo.Text = receive.receive_no;
                lblFarm.Text = receive.farm.farm_name;
                lblBreeder.Text = receive.breeder.breeder_name;
                lblTruckNo.Text = receive.truck_no;
                lblQueueNo.Text = receive.queue_no.ToString();
            }

        }

        private void LoadProduct()
        {
            using (var db = new SlaughterhouseEntities())
            {
                product = db.products.Where(p => p.product_code == productCode).SingleOrDefault();

                lblMinWeight.Text = product.min_weight.ToString();
                lblMaxWeight.Text = product.max_weight.ToString();


                var receiveItems = db.receive_item.Where(p => p.product_code.Equals(product.product_code)
                && p.receive_no.Equals(lblReceiveNo.Text)).ToList();

                int stock_qty = 0;
                decimal stock_wgh = 0;
                foreach (var item in receiveItems)
                {
                    stock_qty += item.receive_qty;
                    stock_wgh += item.receive_wgh;
                }

                //int remain_qty = lblSwineQty.Text.ToInt16() - stock_qty;
                lblStockQty.Text = stock_qty.ToComma();
                lblStockWgh.Text = stock_wgh.ToFormat2Decimal();
                btnStart.Enabled = true;
                lblMessage.Text = Constants.START_WAITING;

            }

        }

        private void LoadBomItem(int bomCode)
        {
            using (var db = new SlaughterhouseEntities())
            {
                //var bom = db.boms.Where(p => p.bom_code == bomCode).SingleOrDefault();
                //lblCaption.Text = bom.product.product_name;
                var bomItems = db.bom_item.Where(p => p.bom_code == bomCode).ToList();
                //lblMinWeight.Text = product.min_weight.ToString();
                //lblMaxWeight.Text = product.max_weight.ToString();
                flowLayoutPanel1.Controls.Clear();

                buttons = new List<Button>();
                foreach (var item in bomItems)
                {
                    var btn = new Button
                    {
                        Text = item.product.product_name,
                        Width = 200,
                        Height = 80,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Kanit", 14),
                        BackColor = Color.WhiteSmoke,
                        Tag = item.product_code
                    };

                    buttons.Add(btn);

                    btn.Click += Btn_Click;
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
            productCode = btn.Tag.ToString();
            LoadProduct();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReceiveNo_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new Form_LookupSwine();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(frm.ReceiveNo);
                    LoadBomItem(bom.bom_code);

                    lblMessage.Text = Constants.PRODUCT_WAITING;
                    int stock_qty = 0;
                    decimal stock_wgh = 0;

                    //int remain_qty = lblSwineQty.Text.ToInt16() - stock_qty;
                    lblStockQty.Text = stock_qty.ToComma();
                    lblStockWgh.Text = stock_wgh.ToFormat2Decimal();
                    //lblRemainQty.Text = remain_qty.ToComma();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {


            //if (_spManager.CurrentSerialSettings.PortName != "")
            //    _spManager.StartListening();


            try
            {
                if (!serialPort1.IsOpen)
                    serialPort1.Open();


                isStart = true;
                isZero = true;
                lblMessage.Text = Constants.WEIGHT_WAITING;

                lblWeight.Text = "0.00";
                btnReceiveNo.Enabled = !isStart;
                btnStart.Enabled = !isStart;
                btnStop.Enabled = isStart;
                btnPrint.Enabled = !isStart;

                lblMessage.Text = Constants.WEIGHT_WAITING;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                btnReceiveNo.Enabled = !isStart;
                btnStart.Enabled = !isStart;
                btnStop.Enabled = isStart;
                btnPrint.Enabled = !isStart;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private bool SaveData()
        {
            try
            {
                using (var db = new SlaughterhouseEntities())
                {
                    decimal weight = lblWeight.Text.ToDecimal();
                    //update receive
                    var receive = db.receives.Where(p => p.receive_no.Equals(lblReceiveNo.Text)).SingleOrDefault();
                    int seq = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Count();

                    barcode_no = db.barcodes.Max(p => p.barcode_no) + 1;
                    //int seq = db.receive_item.Where(p => p.receive_no == receive.receive_no).Count();
                    string create_by = Helper.GetLocalIPAddress();
                    seq += 1;
                    var item = new receive_item
                    {
                        receive_no = receive.receive_no,
                        product_code = product.product_code,
                        seq = seq,
                        sex_flag = "",
                        lot_no = receive.lot_no,
                        receive_qty = 1,
                        receive_wgh = weight,
                        barcode_no = barcode_no,
                        create_by = create_by
                    };


                    string stock_no = db.stock_item_running.Where(p => p.doc_no.Equals(receive.receive_no)).Select(p => p.stock_no).SingleOrDefault();
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            //insert barcode
                            var barcode = new barcode
                            {
                                barcode_no = barcode_no,
                                product_code = item.product_code,
                                production_date = DateTime.Today,
                                lot_no = receive.lot_no,
                                qty = 1,
                                wgh = weight,
                                create_by = create_by
                            };

                            db.barcodes.Add(barcode);
                            //insert receive_item
                            db.receive_item.Add(item);
                            //insert stock
                            var stock = new stock
                            {
                                stock_date = DateTime.Today,
                                stock_no = stock_no,
                                stock_item = item.seq,
                                product_code = barcode.product_code,
                                stock_qty = barcode.qty,
                                stock_wgh = barcode.wgh,
                                ref_document_no = receive.receive_no,
                                ref_document_type = Constants.REV,
                                lot_no = barcode.lot_no,
                                location_code = _locationCode,
                                barcode_no = barcode_no,
                                transaction_type = 1,
                                create_by = create_by
                            };

                            db.stocks.Add(stock);
                            db.SaveChanges();
                            transaction.Commit();
                            PrintBarcode();
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

                using (var db = new SlaughterhouseEntities())
                {

                    var barcode = db.barcodes.Where(p => p.barcode_no == barcode_no).SingleOrDefault();
                    DataTable dt = new DataTable("Barcode");
                    dt.Columns.Add("barcode_no", typeof(string));
                    dt.Columns.Add("barcode_no_text", typeof(string));
                    dt.Columns.Add("product_code", typeof(string));
                    dt.Columns.Add("product_name", typeof(string));
                    dt.Columns.Add("production_date", typeof(DateTime));
                    dt.Columns.Add("expired_date", typeof(DateTime));
                    dt.Columns.Add("lot_no", typeof(string));
                    dt.Columns.Add("qty", typeof(int));
                    dt.Columns.Add("qty_unit", typeof(string));
                    dt.Columns.Add("wgh", typeof(double));
                    dt.Columns.Add("wgh_unit", typeof(string));

                    DataRow dr = dt.NewRow();
                    dr["barcode_no"] = string.Format("*{0}*", barcode.barcode_no);
                    dr["barcode_no_text"] = barcode.barcode_no.ToString();
                    dr["product_code"] = barcode.product_code;
                    dr["product_name"] = barcode.product.product_name;
                    dr["production_date"] = barcode.production_date;
                    dr["expired_date"] = barcode.production_date.AddDays(barcode.product.shelflife.ToString().ToDouble());
                    dr["lot_no"] = barcode.lot_no;
                    dr["qty"] = barcode.qty;
                    dr["qty_unit"] = barcode.product.unit_of_measurement.unit_name;
                    dr["wgh"] = barcode.wgh;
                    dr["wgh_unit"] = barcode.product.unit_of_measurement1.unit_name;
                    dt.Rows.Add(dr);

                    //string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\Report\Rpt\"));//Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report"));
                    //dt.WriteXml(path + @"\xml\barcode.xml", XmlWriteMode.WriteSchema);
                    doc.SetDataSource(dt);
                    doc.PrintToPrinter(1, true, 0, 0);
                    btnPrint.Enabled = false;
                }




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
                btnPrint.Enabled = false;
                if (barcode_no > 0)
                {
                    PrintBarcode();
                }
                else
                {
                    throw new Exception("ไม่พบข้อมูล BARCODE!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTareWeight_Click(object sender, EventArgs e)
        {
            //if (_spManager.CurrentSerialSettings.PortName != "")
            //    _spManager.StartListening();


            isTare = true;

            //lblWeight.Text = 0.0.ToFormat2Double();

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



    }
}
