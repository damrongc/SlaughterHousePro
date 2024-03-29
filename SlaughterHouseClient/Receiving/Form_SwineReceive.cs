﻿using nucs.JsonSettings;
using SlaughterHouseEF;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ToastNotifications;
namespace SlaughterHouseClient.Receiving
{
    public partial class Form_SwineReceive : Form
    {
        SettingsBag MySettings = JsonSettings.Load<SettingsBag>("config.json");
        int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
        private const string PRODUCT_CODE = "00-0000";
        private DateTime productionDate;
        product product;
        private string sexFlag = "F";
        private bool isStart = false;
        //private bool isTare = false;
        private bool isZero = true;
        bool lockWeight = false;
        readonly string color = "#1C6BBC";
        int stableCount = 0;
        private int stableTarget = 0;
        private int displayTime = 3;
        private int scaleDivision = 1;
        string InputData = string.Empty;
        string createBy;
        FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;
        delegate void SetTextCallback(string text);
        public Form_SwineReceive()
        {
            InitializeComponent();
            UserInitialization();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                createBy = Helper.GetLocalIPAddress();
                using (var db = new SlaughterhouseEntities())
                {
                    //int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
                    productionDate = db.plants.Find(plantID).production_date;
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
                btnAcceptWeight.Visible = stableTarget == 0;
                //if (stableTarget == 0)
                //{
                //    btnAcceptWeight.Visible = true;
                //}
                //else
                //{
                //    btnAcceptWeight.Visible = false;
                //}
            }
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);
            if (serialPort1.IsOpen)
                InputData = serialPort1.ReadExisting();
            if (InputData != string.Empty)
            {
                this.BeginInvoke(new SetTextCallback(DisplayWeightIWX), new object[] { InputData });
            }
        }
        //private void DisplayWeightJadever(string DataInvoke)
        //{
        //    if (lockWeight == false)
        //    {
        //        double num = 0.0;
        //        if (DataInvoke.Length == 19)
        //        {
        //            string stateOfScale = DataInvoke.Substring(6, 1);
        //            string weightText = DataInvoke.Substring(7, 8);
        //            if (double.TryParse(weightText, out num))
        //            {
        //            }
        //            if (stateOfScale == "+")
        //            {
        //                //num = weightText.ToDouble();
        //            }
        //            else
        //            {
        //                num = -1.0 * num;
        //            }
        //            lblWeight.Text = num.ToFormat2Double();//ScaleHelper.GetWeightIWX(DataInvoke);
        //        }
        //    }
        //}
        private void DisplayWeightIWX(string DataInvoke)
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
                        lblWeight.Text = (num).ToFormatNoDouble();//ScaleHelper.GetWeightIWX(DataInvoke);
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
                if (isStart && isZero)
                {
                    decimal scaleWeight = lblWeight.Text.ToDecimal();
                    if (scaleWeight < product.min_weight)
                    {
                        throw new Exception(string.Format("น้ำหนักต้อง มากกว่า {0}", product.min_weight));
                    }
                    if (scaleWeight > product.max_weight)
                    {
                        throw new Exception(string.Format("น้ำหนักต้อง น้อยกว่า {0}", product.max_weight));
                    }
                    btnAcceptWeight.Enabled = false;
                    lblMessage.Text = Constants.PROCESSING;
                    SaveData();
                    DisplayNotification("Success", "บันทึกข้อมูล เรียบร้อย. \rกรุณานำสินค้าออก", Color.Green);
                    LoadData();
                    isZero = false;
                    //clear weight
                    lockWeight = false;
                    timerMinWeight.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
            //try
            //{
            //    lblMessage.Text = Constants.PROCESSING;
            //    SaveData();
            //    DisplayNotification("Success", "บันทึกข้อมูล เรียบร้อย. \rกรุณานำสินค้าออก", Color.Green);
            //    LoadData();
            //    //clear weight
            //    lockWeight = false;
            //    timerMinWeight.Enabled = true;
            //}
            //catch (Exception ex)
            //{
            //    DisplayNotification("Error", ex.Message, Color.Red);
            //}
        }
        private void LoadData()
        {
            using (var db = new SlaughterhouseEntities())
            {
                product = db.products.Find(PRODUCT_CODE);
                lblMinWeight.Text = product.min_weight.ToString();
                lblMaxWeight.Text = product.max_weight.ToString();
                var receive = db.receives.Where(p => p.receive_no == lblReceiveNo.Text).SingleOrDefault();
                lblReceiveNo.Text = receive.receive_no;
                lblFarm.Text = receive.farm.farm_name;
                lblBreeder.Text = receive.breeder.breeder_name;
                lblTruckNo.Text = receive.truck.truck_no;
                lblQueueNo.Text = receive.queue_no.ToString();
                lblFarmQty.Text = receive.farm_qty.ToComma();
                lblFactoryQty.Text = receive.factory_qty.ToComma();
                lblFactoryWgh.Text = receive.factory_wgh.ToFormatNoDecimal();
                lblRemainQty.Text = (receive.farm_qty - receive.factory_qty).ToComma();
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
                var frm = new Form_Receive();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    lblReceiveNo.Text = frm.ReceiveNo;
                    LoadData();
                    var remain_qty = lblRemainQty.Text.ToInt16();
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
                lblMessage.Text = Constants.START_WAITING;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void SaveData()
        {
            try
            {
                var weight = lblWeight.Text.ToDecimal();
                using (var db = new SlaughterhouseEntities())
                {
                    //update receive
                    var receive = db.receives.Find(lblReceiveNo.Text);
                    if (receive.farm_qty - receive.factory_qty == 0)
                    {
                        throw new Exception("ไม่สามารถรับเพิ่มได้! \rจำนวนรับครบแล้ว");
                    }
                    int seq = receive.receive_item.Count();
                    //int seq = db.receive_item.Where(p => p.receive_no == receive.receive_no).Count();
                    seq += 1;
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
                                receive_wgh = weight,
                                chill_qty = 0,
                                chill_wgh = 0,
                                create_by = createBy
                            };
                            db.receive_item.Add(item);
                            receive.factory_qty += 1;
                            receive.factory_wgh += weight;
                            receive.receive_flag = 1;
                            db.Entry(receive).State = System.Data.Entity.EntityState.Modified;
                            ////insert stock
                            //var stock = new stock
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
                            //    transaction_type = 1,
                            //    create_by = item.create_by
                            //};
                            //if (stockItemRunning == null)
                            //{
                            //    //insert stock_item_running
                            //    var newStockItem = new stock_item_running
                            //    {
                            //        doc_no = receive.receive_no,
                            //        stock_no = stock_no,
                            //        stock_item = 1,
                            //        create_by = item.create_by
                            //    };
                            //    db.stock_item_running.Add(newStockItem);
                            //    //update document_generate
                            //    stockDocument.running += 1;
                            //    db.Entry(stockDocument).State = System.Data.Entity.EntityState.Modified;
                            //}
                            //else
                            //{
                            //    //update stock_item_running
                            //    stockItemRunning.stock_item += 1;
                            //    db.Entry(stockItemRunning).State = System.Data.Entity.EntityState.Modified;
                            //}
                            //db.stocks.Add(stock);
                            db.SaveChanges();
                            transaction.Commit();
                            lblMessage.Text = Constants.SAVE_SUCCESS;
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
        private void btnSetWgh_Click(object sender, EventArgs e)
        {
            isStart = true;
            btnStart.Enabled = false;
            lblWeight.Text = txtSimWeight.Text.ToDecimal().ToString();
            //isStart = true;
            //isZero = true;
            //lblMessage.Text = Constants.WEIGHT_WAITING;
            //btnReceiveNo.Enabled = false;
            //btnStart.Enabled = false;
            //btnStop.Enabled = true;
            //btnAcceptWeight.Enabled = true;
            //lblMessage.Text = Constants.WEIGHT_WAITING;
            //ProcessData();
        }
        private void btnZero_Click(object sender, EventArgs e)
        {
            lblWeight.Text = 0m.ToString();
        }
        private void BtnTareWeight_Click(object sender, EventArgs e)
        {
            //isTare = true;
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
        private void BtnFemale_Click(object sender, EventArgs e)
        {
            sexFlag = "F";
            btnFemale.BackColor = ColorTranslator.FromHtml(color);
            btnFemale.ForeColor = Color.White;
            btnMale.BackColor = Color.Silver;
            btnUndified.BackColor = Color.Silver;
        }
        private void BtnMale_Click(object sender, EventArgs e)
        {
            sexFlag = "M";
            btnFemale.BackColor = Color.Silver;
            btnMale.BackColor = ColorTranslator.FromHtml(color);
            btnMale.ForeColor = Color.White;
            btnUndified.BackColor = Color.Silver;
        }
        private void BtnUndified_Click(object sender, EventArgs e)
        {
            sexFlag = "NA";
            btnFemale.BackColor = Color.Silver;
            btnMale.BackColor = Color.Silver;
            btnUndified.BackColor = ColorTranslator.FromHtml(color);
            btnUndified.ForeColor = Color.White;
        }
        private void BtnAcceptWeight_Click(object sender, EventArgs e)
        {
            ProcessData();
        }
    }
}
