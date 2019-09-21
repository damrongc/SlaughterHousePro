
using SerialPortListener.Serial;
using System;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToastNotifications;
using CrystalDecisions.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing.Printing;

namespace SlaughterHouseClient.Receiving
{
    public partial class Form_ByProduct : Form
    {
        product product;
        bom bom;

        CrystalReportViewer reportViewer = new CrystalReportViewer();

        private const int LOCATION_CODE = 3;
        private bool isStart = false;
        string sumText;
        bool lockWeight = false;

        SerialPortManager _spManager;


        public Form_ByProduct(string title, int bomCode)
        {
            InitializeComponent();
            UserInitialization();


            using (var db = new SlaughterhouseEntities())
            {
                bom = db.boms.Where(p => p.bom_code == bomCode).SingleOrDefault();
            }
            lblCaption.Text = title;
            plSimulator.Visible = true;

            //LoadProduct(productCode);
            //LoadBomItem(bomCode);
            //lblCaption.Text = string.Format("รับ{0}", product.product_name);
            //lblMinWeight.Text = product.min_weight.ToString();
            //lblMaxWeight.Text = product.max_weight.ToString();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                lblCurrentDatetime.Text = DateTime.Today.ToString("dd.MM.yyyy");
                lblMessage.Text = Constants.CHOOSE_QUEUE;

                //serialPort1.PortName = Constants.TWPORT;
                //serialPort1.Open();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }



        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isStart)
                _spManager.StopListening();
            _spManager.Dispose();
        }

        private void UserInitialization()
        {
            _spManager = new SerialPortManager();

            SerialSettings mySerialSettings = _spManager.CurrentSerialSettings;
            //mySerialSettings.PortName = "COM1";
            //serialSettingsBindingSource.DataSource = mySerialSettings;
            //portNameComboBox.DataSource = mySerialSettings.PortNameCollection;
            //baudRateComboBox.DataSource = mySerialSettings.BaudRateCollection;
            //dataBitsComboBox.DataSource = mySerialSettings.DataBitsCollection;
            //parityComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.Parity));
            //stopBitsComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.StopBits));

            _spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
            FormClosing += new FormClosingEventHandler(Form_FormClosing);


            btnStart.Enabled = false;
            btnStop.Enabled = false;

        }


        private void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            Thread.Sleep(100);
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            //int maxTextLength = 1000; // maximum text length in text box
            //if (tbData.TextLength > maxTextLength)
            //    tbData.Text = tbData.Text.Remove(0, tbData.TextLength - maxTextLength);
            //string str = Encoding.ASCII.GetString(e.Data);
            //DisplayWeight(str);

            for (int i = 0; i < e.Data.Length; i++)
            {
                char kk = (char)e.Data[i];
                if (kk == 2)
                {
                    //Found Start
                    sumText = "";
                }
                else if (kk == 3)
                {
                    //Found Stop
                    DisplayWeight(sumText);
                }
                else
                {
                    sumText += kk.ToString();
                }
            }

        }


        private void DisplayWeight(string DataInvoke)
        {
            if (lockWeight == false)
            {

                lblWeight.Text = ScaleHelper.GetWeightIWX(DataInvoke);
                ProcessData();
                //if (DataInvoke.Length == 40)
                //{

                //    int scaleDecimal = DataInvoke.Substring(22, 2).ToInt32();
                //    int scaleDivision = (int)Math.Round(Math.Pow(10.0, unchecked(scaleDecimal)));

                //    string strFormatWt = scaleDecimal == 0 ? "#0" : "#0." + "0".PadRight(scaleDecimal, '0');
                //    short stateOfScale = DataInvoke.Substring(7, 1).ToInt16();
                //    short stableWt = DataInvoke.Substring(6, 1).ToInt16();

                //    if (stateOfScale == 0)
                //    {
                //        num = DataInvoke.Substring(16, 6).ToDouble() / scaleDivision;
                //    }
                //    else
                //    {
                //        num = -1.0 * DataInvoke.Substring(16, 6).ToDouble() / scaleDivision;
                //    }
                //    //var weight = str.Substring(14, 7).ToDecimal() / 1000;
                //    lblWeight.Text = num.ToString(strFormatWt);
                //    ProcessData();

                //}
            }

            //tbData.AppendText(str);
            //tbData.ScrollToCaret();
        }


        private async void ProcessData()
        {
            try
            {
                lockWeight = true;
                lblMessage.Text = Constants.PROCESSING;
                SaveData();
                //PlayNotificationSound("savanna");
                lblWeight.BackColor = Color.FromArgb(33, 150, 83);
                lblWeight.ForeColor = Color.White;
                lblMessage.Text = Constants.SAVE_SUCCESS;
                await Task.Delay(1000);
                lblWeight.BackColor = Color.White;
                lblWeight.ForeColor = Color.Black;
                LoadData(lblReceiveNo.Text);

                //clear weight
                lblWeight.Text = 0m.ToFormat2Decimal();
                lblMessage.Text = Constants.WEIGHT_WAITING;

                lockWeight = false;
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
                lblSwineQty.Text = receive.factory_qty.ToComma();
                //lblStockQty.Text = stock_qty.ToComma();
                //lblStockWgh.Text = stock_wgh.ToFormat2Decimal();
                //lblRemainQty.Text = remain_qty.ToComma();

                //if (remain_qty == 0)
                //{
                //    btnStart.Enabled = false;
                //}
                //else
                //{
                //    btnStart.Enabled = true;

                //}
            }


            lblMessage.Text = Constants.START_WAITING;
        }

        private void LoadProduct(string productCode)
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

                int remain_qty = lblSwineQty.Text.ToInt16() - stock_qty;
                lblStockQty.Text = stock_qty.ToComma();
                lblStockWgh.Text = stock_wgh.ToFormat2Decimal();
                lblRemainQty.Text = remain_qty.ToComma();

                if (remain_qty == 0)
                {
                    btnStart.Enabled = false;
                }
                else
                {
                    btnStart.Enabled = true;

                }


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
                foreach (var item in bomItems)
                {
                    var btn = new Button
                    {
                        Text = item.product.product_name,
                        Width = 150,
                        Height = 80,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Kanit", 16),
                        BackColor = Color.WhiteSmoke,
                        Tag = item.product_code
                    };

                    btn.Click += Btn_Click;
                    flowLayoutPanel1.Controls.Add(btn);
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

            LoadProduct(btn.Tag.ToString());

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
                    LoadData(frm.receiveNo);
                    LoadBomItem(bom.bom_code);

                    int stock_qty = 0;
                    decimal stock_wgh = 0;

                    int remain_qty = lblSwineQty.Text.ToInt16() - stock_qty;
                    lblStockQty.Text = stock_qty.ToComma();
                    lblStockWgh.Text = stock_wgh.ToFormat2Decimal();
                    lblRemainQty.Text = remain_qty.ToComma();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isStart = true;
            lblMessage.Text = Constants.WEIGHT_WAITING;
            _spManager.CurrentSerialSettings.PortName = Constants.SCALEPORT;
            if (_spManager.CurrentSerialSettings.PortName != "")
                _spManager.StartListening();

            lblWeight.Text = "0.00";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblMessage.Text = Constants.WEIGHT_WAITING;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_spManager.CurrentSerialSettings.PortName != "")
                _spManager.StopListening();
            lblWeight.Text = "0.00";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }



        private bool SaveData()
        {
            try
            {
                decimal weight = lblWeight.Text.ToDecimal();
                using (var db = new SlaughterhouseEntities())
                {
                    //update receive
                    var receive = db.receives.Where(p => p.receive_no.Equals(lblReceiveNo.Text)).SingleOrDefault();
                    //int stock_qty = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Sum(p => p.receive_qty);
                    //if (receive.factory_qty - stock_qty == 0)
                    //{
                    //    throw new Exception("จำนวนรับครบแล้ว ไม่สามารถรับเพิ่มได้!");
                    //}
                    int seq = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Count();
                    //int seq = db.receive_item.Where(p => p.receive_no == receive.receive_no).Count();
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
                        create_by = Constants.CREATE_BY

                    };

                    var barcode_no = db.barcodes.Max(p => p.barcode_no) + 1;
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
                                qty = item.receive_qty,
                                wgh = item.receive_wgh,
                                create_by = item.create_by
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
                                product_code = item.product_code,
                                stock_qty = item.receive_qty,
                                stock_wgh = item.receive_wgh,
                                ref_document_no = receive.receive_no,
                                ref_document_type = Constants.REV,
                                lot_no = receive.lot_no,
                                location_code = LOCATION_CODE, //ห้องเย็นเก็บหมุซีก
                                barcode_no = barcode_no,
                                transaction_type = 1,
                                create_by = item.create_by
                            };

                            db.stocks.Add(stock);
                            db.SaveChanges();
                            transaction.Commit();


                            barcode = db.barcodes.Where(p => p.barcode_no == 1000000000107).SingleOrDefault();

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

                            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report"));
                            //dt.WriteXml(path + @"\xml\barcode.xml", XmlWriteMode.WriteSchema);


                            ReportDocument doc = new ReportDocument();
                            doc.Load(path + @"\Rpt\barcode.rpt");
                            doc.SetDataSource(dt);

                            doc.PrintToPrinter(1, true, 0, 0);

                            //reportViewer.ReportSource = doc;

                            //reportViewer.Zoom(100);
                            //rptViewer.RefreshReport();

                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                }
                return true;
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

            using (var db = new SlaughterhouseEntities())
            {
                var barcode = db.barcodes.Where(p => p.barcode_no == 1000000000107).SingleOrDefault();

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

                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report"));
                //dt.WriteXml(path + @"\Xml\barcode.xml", XmlWriteMode.WriteSchema);


                ReportDocument doc = new ReportDocument();


                lblMessage.Text = path;
                doc.Load(path + @"\Rpt\barcode.rpt");
                doc.SetDataSource(dt);

                //PageMargins margins = new PageMargins();
                //margins.bottomMargin = 0;

                //margins.leftMargin = 0;

                //margins.rightMargin = 0;

                //margins.topMargin = 0;
                //doc.PrintOptions.ApplyPageMargins(margins);


                //System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
                //doctoprint.PrinterSettings.PrinterName = "ZDesigner GK420t"; //'(ex. "Epson SQ-1170 ESC/P 2")

                //for (int i = 0; i < doctoprint.PrinterSettings.PaperSizes.Count; i++)
                //{
                //    int rawKind;
                //    if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "6 x 6")
                //    {
                //        rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                //        //crPrintOut.PrintOptions.PaperSize = rawKind;
                //        doc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;

                //        break;
                //    }
                //}

                //CrystalReportCustomPaperSize("", "", ref doc);

                doc.PrintToPrinter(1, true, 0, 0);


            }

        }


        const string PaperSizeName = "6 x 6";
        public Int32 GetPaperSize(String sPrinterName, String sPaperSizeName)
        {
            PrintDocument docPrintDoc = new PrintDocument();
            docPrintDoc.PrinterSettings.PrinterName = sPrinterName;
            for (int i = 0; i < docPrintDoc.PrinterSettings.PaperSizes.Count; i++)
            {
                int raw = docPrintDoc.PrinterSettings.PaperSizes[i].RawKind;
                if (docPrintDoc.PrinterSettings.PaperSizes[i].PaperName == sPaperSizeName)
                {
                    return raw;
                }
            }
            return 0;
        }

        private void CrystalReportCustomPaperSize(string ProgramCode, string ReportID, ref ReportDocument Report)
        {
            string PrinterName = null;

            string[] PaperSizeList = null;

            System.Drawing.Printing.PrinterSettings aPrinterSettings = new System.Drawing.Printing.PrinterSettings();
            PrinterName = aPrinterSettings.PrinterName.ToString();
            if ((PaperSizeName != null))
            {
                System.Drawing.Printing.PrintDocument DocToPrint = new System.Drawing.Printing.PrintDocument();
                DocToPrint.PrinterSettings.PrinterName = PrinterName;

                PaperSizeList = new string[DocToPrint.PrinterSettings.PaperSizes.Count + 1];
                for (int i = 0; i <= DocToPrint.PrinterSettings.PaperSizes.Count - 1; i++)
                {
                    int rawKind = 0;

                    // PaperSizeList(i) = DocToPrint.PrinterSettings.PaperSizes(i).PaperName;

                    if (DocToPrint.PrinterSettings.PaperSizes[i].PaperName == PaperSizeName)
                    {
                        rawKind = Convert.ToInt32(DocToPrint.PrinterSettings.PaperSizes[i].GetType().GetField("kind", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(DocToPrint.PrinterSettings.PaperSizes[i]));
                        Report.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;

                        CrystalDecisions.Shared.PageMargins Margins = new CrystalDecisions.Shared.PageMargins();
                        Margins = Report.PrintOptions.PageMargins;
                        Margins.leftMargin = 0;
                        Margins.topMargin = 0;
                        Margins.rightMargin = 0;
                        Margins.bottomMargin = 0;

                        //if (LefMargin >= 0)
                        //    Margins.leftMargin = LefMargin * TWIP;
                        //if (RightMargin >= 0)
                        //    Margins.rightMargin = RightMargin * TWIP;
                        //if (TopMargin >= 0)
                        //    Margins.topMargin = TopMargin * TWIP;
                        //if (ButtomMargin >= 0)
                        //    Margins.bottomMargin = ButtomMargin * TWIP;

                        //Report.PrintOptions.ApplyPageMargins(Margins);

                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
        }

    }
}
