﻿//using System.IO;
using nucs.JsonSettings;
using SlaughterHouseEF;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
//using CrystalDecisions.CrystalReports.Engine;
using ToastNotifications;
//using System.Collections.Generic;
namespace SlaughterHouseClient.Receiving
{
    public partial class Form_CarcassReceive : Form
    {
        const string PRODUCT_CODE = "00-0001";
        //const int RECEIVE_QTY = 2;
        SettingsBag MySettings = JsonSettings.Load<SettingsBag>("config.json");
        product product;
        private bool isStart = false;
        private bool isTare = false;
        private bool isZero = true;
        private string sexFlag = "F";
        readonly string color = "#1C6BBC";
        bool lockWeight = false;
        int stableCount = 0;
        private int stableTarget = 0;
        private int displayTime = 3;
        private int scaleDivision = 100;
        private int captureTime = 10;
        private plant plant;
        FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;
        delegate void SetTextCallback(string text);
        public Form_CarcassReceive()
        {
            InitializeComponent();
            UserInitialization();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
                using (var db = new SlaughterhouseEntities())
                {
                    plant = db.plants.Find(plantID);
                    lblProductionDate.Text = plant.production_date.ToString("dd-MM-yyyy");
                    product = db.products.Find(PRODUCT_CODE);
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
            //btnAcceptWeight.Enabled = false;
            LoadSetting();
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
                captureTime = MySettings["CaptureTime"].ToString().ToInt16();
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
        string InputData = string.Empty;
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
                    short stateOfScale = DataInvoke.Substring(6, 1).ToInt16();
                    short stableWt = DataInvoke.Substring(5, 1).ToInt16();
                    if (stableWt == 2)
                    {
                        lblWeight.Text = "--.--";
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

                        if (stableTarget > 0)
                        {
                            //For Auto Capture
                            if (isStart && isZero)
                            {
                                if (num > 0 && num > product.min_weight.ToString().ToDouble())
                                {
                                    if (stableWt == 0)
                                        stableCount += 1;
                                    else
                                        stableCount = 0;
                                    lblStable.Text = stableCount.ToString();
                                    lblStable.Refresh();
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
            }
        }
        private void LoadData()
        {
            using (var db = new SlaughterhouseEntities())
            {
                lblMinWeight.Text = product.min_weight.ToString();
                lblMaxWeight.Text = product.max_weight.ToString();
                var receive = db.receives.Where(p => p.receive_no == lblReceiveNo.Text).SingleOrDefault();
                //int stock_qty = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Sum(p => p.receive_qty);
                //decimal stock_wgh = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Sum(p => p.receive_wgh);
                var receive_item = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).LastOrDefault();
                int stock_qty = Convert.ToInt16(receive.carcass_qty);
                decimal stock_wgh = Convert.ToDecimal(receive.carcass_wgh);
                int remain_qty = receive.farm_qty - stock_qty;
                lblReceiveNo.Text = receive.receive_no;
                lblFarm.Text = receive.farm.farm_name;
                lblBreeder.Text = receive.breeder.breeder_name;
                //lblTruckNo.Text = receive.truck.truck_no;
                //lblQueueNo.Text = receive.queue_no.ToString();
                lblLotNo.Text = receive.lot_no;
                lblFarmQty.Text = receive.farm_qty.ToComma();
                lblFactoryQty.Text = stock_qty.ToComma();
                lblFactoryWgh.Text = stock_wgh.ToFormat2Decimal();
                lblRemainQty.Text = remain_qty.ToComma();
                if (receive_item != null)
                    lblLastWgh.Text = receive_item.receive_wgh.ToFormat2Decimal();
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
                var frm = new Form_LookupSwine(PRODUCT_CODE);
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
                if (System.Diagnostics.Debugger.IsAttached == false)
                {
                    if (!serialPort1.IsOpen)
                        serialPort1.Open();
                }
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
                if (System.Diagnostics.Debugger.IsAttached == false)
                {
                    if (serialPort1.IsOpen)
                        serialPort1.Close();
                }
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
            //isStart = true;
            //isZero = true;
            //lblMessage.Text = Constants.WEIGHT_WAITING;
            //btnReceiveNo.Enabled = false;
            //btnStart.Enabled = false;
            //btnStop.Enabled = true;
            //btnAcceptWeight.Enabled = true;
            //ProcessData();
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
            double minWeight = lblMinWeight.Text.ToDouble();
            if (scaleWeight <= minWeight)
            {
                lblMessage.Text = Constants.WEIGHT_WAITING;
                isZero = true;
                stableCount = 0;
                lblStable.Text = stableCount.ToString();
                timerMinWeight.Enabled = false;
                btnAcceptWeight.Enabled = true;
                sexFlag = "F";
                btnFemale.BackColor = ColorTranslator.FromHtml("#459CDB");
                btnFemale.ForeColor = Color.White;
                btnMale.BackColor = Color.Silver;
                btnUndified.BackColor = Color.Silver;
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
                btnAcceptWeight.Enabled = false;
                lblMessage.Text = Constants.PROCESSING;
                SaveData();
                var toastNotification = new Notification("Success", "บันทึกข้อมูล เรียบร้อย. \rกรุณานำสินค้าออก", displayTime, Color.Green, animationMethod, animationDirection);
                toastNotification.Show();
                LoadData();
                lblLastWgh.Text = lblWeight.Text;
                //clear weight
                lockWeight = false; //unlock weight เพื่อรอให้น้ำหนักเข้ามาใหม่หลังจาก Save
                timerMinWeight.Enabled = true; //on timer เพื่อ check min weight
            }
            catch (Exception ex)
            {
                var toastNotification = new Notification("Error", ex.Message, displayTime, Color.Red, animationMethod, animationDirection);
                toastNotification.Show();
            }
        }
        private void SaveData()
        {
            try
            {
                var receiveWgh = lblWeight.Text.ToDecimal();
                string createBy = Helper.GetLocalIPAddress();
                var productionDate = plant.production_date;
                using (var db = new SlaughterhouseEntities())
                {
                    var receive = db.receives.Where(p => p.receive_no.Equals(lblReceiveNo.Text)).SingleOrDefault();
                    //var carcassQty = receive.carcass_qty == 0 ? receive.carcass_qty : (receive.carcass_qty / RECEIVE_QTY);
                    if (receive.farm_qty - receive.carcass_qty == 0)
                    {
                        throw new Exception("จำนวนรับครบแล้ว\rไม่สามารถรับเพิ่มได้!");
                    }
                    int seq = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Count();
                    ////หารับหมูเป็นมาตัดออกจาก stock
                    //var swine = receive.receive_item.Where(p => p.product_code == "P001"
                    //    && p.seq == seq).Select(p => new { p.receive_qty, p.receive_wgh }).SingleOrDefault();
                    seq += 1;
                    //string stock_no = db.stock_item_running.Where(p => p.doc_no.Equals(receive.receive_no)).Select(p => p.stock_no).SingleOrDefault();
                    string stock_no = "";
                    var stockDocument = (from p in db.document_generate where p.document_type == Constants.STK select p).SingleOrDefault();
                    //check stock_item_running
                    var stockItemRunning = db.stock_item_running.Where(p => p.doc_no.Equals(receive.receive_no)).SingleOrDefault();
                    if (stockItemRunning == null)
                    {
                        //get new stock doc no
                        stock_no = Constants.STK + stockDocument.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                    }
                    else
                    {
                        stock_no = stockItemRunning.stock_no;
                    }
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var item = new receive_item
                            {
                                receive_no = receive.receive_no,
                                product_code = product.product_code,
                                seq = seq,
                                lot_no = receive.lot_no,
                                sex_flag = sexFlag,
                                receive_qty = 1,
                                receive_wgh = receiveWgh,
                                chill_qty = 0,
                                chill_wgh = 0,
                                create_by = createBy
                            };
                            db.receive_item.Add(item);
                            //var stocks = new List<stock>();
                            //stocks.Add(new stock
                            //{
                            //    stock_date = productionDate,
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
                                stock_qty = 1,
                                stock_wgh = receiveWgh,
                                ref_document_no = receive.receive_no,
                                ref_document_type = Constants.REV,
                                lot_no = receive.lot_no,
                                location_code = 2, //ห้องเย็นเก็บหมุซีก
                                barcode_no = 0,
                                transaction_type = 1,
                                create_by = createBy
                            };
                            db.stocks.Add(stock);
                            receive.carcass_qty += 1;
                            receive.carcass_wgh += receiveWgh;
                            if (stockItemRunning == null)
                            {
                                //insert stock_item_running
                                var newStockItem = new stock_item_running
                                {
                                    doc_no = receive.receive_no,
                                    stock_no = stock_no,
                                    stock_item = 1,
                                    create_by = createBy
                                };
                                db.stock_item_running.Add(newStockItem);
                                //update document_generate
                                stockDocument.running += 1;
                                db.Entry(stockDocument).State = System.Data.Entity.EntityState.Modified;
                            }
                            else
                            {
                                //update stock_item_running
                                stockItemRunning.stock_item += 1;
                                db.Entry(stockItemRunning).State = System.Data.Entity.EntityState.Modified;
                            }
                            db.SaveChanges();
                            transaction.Commit();
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

        private void btnFemale_Click(object sender, EventArgs e)
        {
            sexFlag = "F";
            btnFemale.BackColor = ColorTranslator.FromHtml(color);
            btnFemale.ForeColor = Color.White;
            btnMale.BackColor = Color.Silver;
            btnUndified.BackColor = Color.Silver;
        }

        private void btnMale_Click(object sender, EventArgs e)
        {
            sexFlag = "M";
            btnFemale.BackColor = Color.Silver;
            btnMale.BackColor = ColorTranslator.FromHtml(color);
            btnMale.ForeColor = Color.White;
            btnUndified.BackColor = Color.Silver;
        }

        private void btnUndified_Click(object sender, EventArgs e)
        {
            sexFlag = "NA";
            btnFemale.BackColor = Color.Silver;
            btnMale.BackColor = Color.Silver;
            btnUndified.BackColor = ColorTranslator.FromHtml(color);
            btnUndified.ForeColor = Color.White;
        }
    }
}
