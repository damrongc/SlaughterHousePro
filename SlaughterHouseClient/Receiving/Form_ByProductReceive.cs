using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using ToastNotifications;
using System.IO.Ports;
using System.IO;
using nucs.JsonSettings;
using System.Collections.Generic;

namespace SlaughterHouseClient.Receiving
{
    public partial class Form_ByProductReceive : Form
    {
        SettingsBag MySettings = JsonSettings.Load<SettingsBag>("config.json");
        product product;
        private bool isStart = false;
        private bool isTare = false;
        private bool isZero = true;
        bool lockWeight = false;
        int stableCount = 0;

        public int LocationCode { get; set; }
        public string ProductCode { get; set; }
        long barcode_no = 0;
        ReportDocument doc = new ReportDocument();


        FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;

        delegate void SetTextCallback(string text);
        public Form_ByProductReceive()
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
                    product = db.products.Find(ProductCode);
                    lblMinWeight.Text = product.min_weight.ToString();
                    lblMaxWeight.Text = product.max_weight.ToString();
                    lblProduct.Text = product.product_name;

                    int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
                    var plant = db.plants.Find(plantID);
                    lblCurrentDatetime.Text = plant.production_date.ToString("dd-MM-yyyy");
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
            serialPort1.DataReceived += port_DataReceived;
            FormClosing += new FormClosingEventHandler(Form_FormClosing);
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            btnAcceptWeight.Enabled = false;

            LoadSetting();

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

            }
        }

        string InputData = String.Empty;
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);
            if (serialPort1.IsOpen)
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
                            num = DataInvoke.Substring(16, 6).ToDouble() / 1000;
                        }
                        else if (stateOfScale == 1)
                        {
                            num = -1.0 * DataInvoke.Substring(16, 6).ToDouble() / 1000;
                        }
                        lblWeight.Text = (num).ToFormat2Double();//ScaleHelper.GetWeightIWX(DataInvoke);
                        //if (isStart && isZero)
                        //{
                        //    if (num > 0 && num > product.min_weight.ToString().ToDouble())
                        //    {
                        //        if (stableWt == 0)
                        //            stableCount += 1;
                        //        else
                        //            stableCount = 0;
                        //        lblStable.Text = stableCount.ToString();
                        //        lblStable.Refresh();


                        //    }
                        //    if (stableCount >= Constants.STABLE_TARGET.ToInt16())
                        //    {
                        //        lockWeight = true;
                        //        isZero = false;

                        //        ProcessData();
                        //    }
                        //}
                    }


                }

            }
        }

        private void ProcessData()
        {
            try
            {
                //lblMessage.Text = Constants.PROCESSING;
                //SaveData();

                //var toastNotification = new Notification("Success", "บันทึกข้อมูล เรียบร้อย. \rกรุณานำสินค้าออก", 2, Color.Green, animationMethod, animationDirection);
                //toastNotification.Show();
                //LoadData();

                ////clear weight
                //lockWeight = false;
                //timerMinWeight.Enabled = true;
                if (isStart && isZero)
                {
                    btnAcceptWeight.Enabled = false;
                    decimal scaleWeight = lblWeight.Text.ToDecimal();

                    if (scaleWeight < 0)
                    {
                        throw new Exception(string.Format("น้ำหนัก น้อยกว่า 0"));
                    }

                    if (scaleWeight < product.min_weight)
                    {
                        throw new Exception(string.Format("น้ำหนัก น้อยกว่า Min: {0}", product.min_weight));
                    }
                    if (scaleWeight > product.max_weight)
                    {
                        throw new Exception(string.Format("น้ำหนัก มากกว่า Max: {0}", product.max_weight));
                    }

                    lblMessage.Text = Constants.PROCESSING;
                    SaveData();
                    var toastNotification = new Notification("Success", "บันทึกข้อมูล เรียบร้อย. \rกรุณานำสินค้าออก", 3, Color.Green, animationMethod, animationDirection);
                    toastNotification.Show();
                    LoadData();

                    lblLastWgh.Text = lblWeight.Text;
                    isZero = false;
                    //clear weight
                    lockWeight = false;
                    timerMinWeight.Enabled = true;
                }


            }
            catch (Exception ex)
            {

                var toastNotification = new Notification("Error", ex.Message, 2, Color.Red, animationMethod, animationDirection);
                toastNotification.Show();
            }
            finally
            {
                btnAcceptWeight.Enabled = true;
            }

        }

        private void LoadData()
        {

            using (var db = new SlaughterhouseEntities())
            {


                var receive = db.receives.Where(p => p.receive_no == lblReceiveNo.Text).SingleOrDefault();
                int stock_qty = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Sum(p => p.receive_qty);
                decimal stock_wgh = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Sum(p => p.receive_wgh);
                var receive_item = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).LastOrDefault();

                int remain_qty = receive.farm_qty - stock_qty;
                lblReceiveNo.Text = receive.receive_no;
                lblFarm.Text = receive.farm.farm_name;
                lblBreeder.Text = receive.breeder.breeder_name;
                lblTruckNo.Text = receive.truck.truck_no;
                lblLotNo.Text = receive.lot_no;
                lblQueueNo.Text = receive.queue_no.ToString();
                lblFarmQty.Text = receive.farm_qty.ToComma();
                lblFactoryQty.Text = stock_qty.ToComma();
                lblFactoryWgh.Text = stock_wgh.ToFormat2Decimal();
                lblRemainQty.Text = remain_qty.ToComma();

                if (receive_item != null)
                    lblLastWgh.Text = receive_item.receive_wgh.ToFormat2Decimal();

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReceiveNo_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new Form_LookupSwine();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    lblReceiveNo.Text = frm.ReceiveNo;
                    LoadData();

                    var remain_qty = lblRemainQty.Text.ToInt16();
                    btnStart.Enabled = remain_qty == 0 ? false : true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort1.IsOpen)
                    serialPort1.Open();

                isStart = true;
                isZero = true;
                lblMessage.Text = Constants.WEIGHT_WAITING;

                lblWeight.Text = "0.00";
                btnReceiveNo.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnAcceptWeight.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnSetWgh_Click(object sender, EventArgs e)
        {
            lblWeight.Text = txtSimWeight.Text.ToDecimal().ToFormat2Decimal();

            isStart = true;
            isZero = true;



            btnReceiveNo.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnAcceptWeight.Enabled = true;


            ProcessData();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            lblWeight.Text = 0m.ToFormat2Decimal();
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
            if (scaleWeight <= 0)
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
            //try
            //{

            //    if (isStart && isZero)
            //    {

            //        decimal scaleWeight = lblWeight.Text.ToDecimal();

            //        if (scaleWeight < 0)
            //        {
            //            throw new Exception(string.Format("น้ำหนักไม่สามารถ น้อยกว่า 0"));
            //        }

            //        if (scaleWeight < product.min_weight)
            //        {
            //            throw new Exception(string.Format("น้ำหนักไม่สามารถ น้อยกว่า {0}", product.min_weight));
            //        }
            //        if (scaleWeight > product.max_weight)
            //        {
            //            throw new Exception(string.Format("น้ำหนักไม่สามารถ มากกว่า {0}", product.max_weight));
            //        }
            //        btnAcceptWeight.Enabled = false;
            //        lblMessage.Text = Constants.PROCESSING;
            //        SaveData();
            //        var toastNotification = new Notification("Success", "บันทึกข้อมูล เรียบร้อย. \rกรุณานำสินค้าออก", 3, Color.Green, animationMethod, animationDirection);
            //        toastNotification.Show();
            //        LoadData();

            //        lblLastWgh.Text = lblWeight.Text;
            //        isZero = false;
            //        //clear weight
            //        lockWeight = false;
            //        timerMinWeight.Enabled = true;
            //    }


            //}
            //catch (Exception ex)
            //{
            //    btnAcceptWeight.Enabled = true;
            //    var toastNotification = new Notification("Error", ex.Message, 2, Color.Red, animationMethod, animationDirection);
            //    toastNotification.Show();
            //}
        }

        private void SaveData()
        {
            try
            {
                var receiveWgh = lblWeight.Text.ToDecimal();
                var createBy = Helper.GetLocalIPAddress();
                using (var db = new SlaughterhouseEntities())
                {
                    int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
                    var productionDate = db.plants.Find(plantID).production_date;

                    //update receive
                    var receive = db.receives.Where(p => p.receive_no.Equals(lblReceiveNo.Text)).SingleOrDefault();

                    int receive_qty = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Sum(p => p.receive_qty);
                    if (receive.factory_qty - receive_qty == 0)
                    {
                        throw new Exception("จำนวนรับครบแล้ว ไม่สามารถรับเพิ่มได้!");
                    }
                    int seq = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Count();

                    barcode_no = db.barcodes.Max(p => p.barcode_no) + 1;

                    //int seq = db.receive_item.Where(p => p.receive_no == receive.receive_no).Count();
                    seq += 1;
                    var item = new receive_item
                    {
                        receive_no = receive.receive_no,
                        product_code = product.product_code,
                        seq = seq,
                        lot_no = receive.lot_no,
                        sex_flag = "",
                        receive_qty = 1,
                        receive_wgh = receiveWgh,
                        chill_qty = 0,
                        chill_wgh = 0,
                        barcode_no = barcode_no,
                        create_by = createBy
                    };

                    string stock_no = db.stock_item_running.Where(p => p.doc_no.Equals(receive.receive_no)).Select(p => p.stock_no).SingleOrDefault();

                    //var documentGenerate = (from p in db.document_generate where p.document_type == Constants.STK select p).SingleOrDefault();


                    //check stock_item_running
                    //var stockItemRunning = db.stock_item_running.Where(p => p.doc_no.Equals(receive.receive_no)).SingleOrDefault();
                    //if (stockItemRunning == null)
                    //{
                    //    //get new stock doc no
                    //    stock_no = Constants.STK + documentGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                    //}
                    //else
                    //{
                    //    stock_no = stockItemRunning.stock_no;
                    //}


                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            //insert barcode
                            var barcode = new barcode
                            {
                                barcode_no = barcode_no,
                                product_code = item.product_code,
                                production_date = productionDate,
                                lot_no = receive.lot_no,
                                qty = 1,
                                wgh = receiveWgh,
                                active = true,
                                create_by = createBy
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
                            var stock = new stock
                            {
                                stock_date = productionDate,
                                stock_no = stock_no,
                                stock_item = item.seq,
                                product_code = item.product_code,
                                stock_qty = item.receive_qty,
                                stock_wgh = item.receive_wgh,
                                ref_document_no = receive.receive_no,
                                ref_document_type = Constants.REV,
                                lot_no = receive.lot_no,
                                location_code = LocationCode,
                                barcode_no = barcode_no,
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
                btnPrint.Enabled = false;
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

                    //var reportPath = Application.StartupPath;
                    //dt.WriteXml(reportPath + @"\xml\barcode.xml", XmlWriteMode.WriteSchema);

                    doc.SetDataSource(dt);
                    doc.PrintToPrinter(1, true, 0, 0);
                }
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

                PrintBarcode();
            }
            catch (Exception ex)
            {
                var toastNotification = new Notification("Error", ex.Message, 2, Color.Red, animationMethod, animationDirection);
                toastNotification.Show();
            }

        }
    }
}
