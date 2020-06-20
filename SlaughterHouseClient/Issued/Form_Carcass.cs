
using nucs.JsonSettings;
using SlaughterHouseClient.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ToastNotifications;

namespace SlaughterHouseClient.Issued
{
    public partial class Form_Carcass : Form
    {
        private readonly SettingsBag MySettings = JsonSettings.Load<SettingsBag>("config.json");
        readonly int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
        const string PRODUCT_CODE = "00000";
        product product;
        private string lotNo = string.Empty;
        private DateTime productionDate;
        private bool isStart = false;
        private bool isZero = true;
        bool lockWeight = false;
        int stableCount = 0;
        private int stableTarget = 0;
        private int displayTime = 3;
        private int scaleDivision = 100;

        List<Button> buttons;
        private int Index;
        private readonly int PAGE_SIZE = 12;
        readonly FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        readonly FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;
        delegate void SetTextCallback(string text);
        string InputData = string.Empty;

        public Form_Carcass()
        {
            InitializeComponent();
            UserInitialization();

        }

        private void UserInitialization()
        {

            serialPort1.DataReceived += port_DataReceived;
            FormClosing += new FormClosingEventHandler(Form_FormClosing);
            btnStop.Enabled = false;
            btnAcceptWeight.Enabled = false;

            LoadSetting();
            LoadProduct();
            LoadLotNo();

            lblMessage.Text = Constants.CHOOSE_QUEUE;
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

        private void DisplayNotification(string title, string message, Color color)
        {
            var toastNotification = new Notification(title, message, displayTime, color, animationMethod, animationDirection);
            toastNotification.Show();
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
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
                            if (num > 0 && num > product.min_weight.ToString().ToDouble())
                            {
                                if (stableWt == 0)
                                    stableCount += 1;
                                else
                                    stableCount = 0;
                                lblStable.Text = stableCount.ToString();
                                lblStable.Refresh();


                            }
                            if (stableCount >= Constants.STABLE_TARGET.ToInt16())
                            {
                                lockWeight = true;
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
                if (string.IsNullOrEmpty(lotNo))
                {
                    throw new Exception("กรุณาเลือก Lot No!");
                }
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
                DisplayNotification("Success", $"จ่ายซีก Lot {lotNo}\rเรียบร้อยแล้ว", Color.Green);
                LoadData();
                LoadLotNo();

                //clear weight
                lockWeight = false;
                timerMinWeight.Enabled = true;
                lblMessage.Text = Constants.START_WAITING;

            }
            catch (Exception ex)
            {
                btnAcceptWeight.Enabled = true;
                DisplayNotification("Error", ex.Message, Color.Red);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadData()
        {

            using (var db = new SlaughterhouseEntities())
            {


                var orderNo = lblOrderNo.Text;
                if (string.IsNullOrEmpty(orderNo))
                {
                    //Load ข้อมูลจ่ายตัดแต่ง

                    var issuedInfo = db.issued_info.Find(productionDate, PRODUCT_CODE, lotNo);
                    if (issuedInfo != null)
                    {
                        lblUnloadedQty.Text = issuedInfo.issued_qty.ToComma();
                        lblUnloadedWgh.Text = issuedInfo.issued_wgh.ToFormat2Decimal();
                    }
                }
                else
                {
                    var order = db.orders.Find(orderNo);
                    var orderItems = order.orders_item.Where(p => p.product_code == product.product_code).ToList();
                    if (orderItems.Count == 0)
                    {
                        lblOrderNo.Text = "";
                        throw new Exception("ไม่พบสินค้า จ่ายหมุซีก\rในรายการขาย");
                    }
                    lblProduct.Text = orderItems[0].product.product_name;
                    lblOrderQty.Text = orderItems[0].order_qty.ToComma();
                    lblOrderWgh.Text = orderItems[0].order_wgh.ToFormat2Decimal();
                    lblUnloadedQty.Text = orderItems[0].unload_qty.ToComma();
                    lblUnloadedWgh.Text = orderItems[0].unload_wgh.ToFormat2Decimal();
                    lblCustomer.Text = order.customer.customer_name;
                    var transport = db.transports.Where(p => p.ref_document_no == order.order_no).SingleOrDefault();
                    if (transport != null)
                    {
                        cboTruckNo.SelectedValue = transport.truck_id;
                        cboTruckNo.Enabled = false;
                    }

                }
            }




        }

        private void LoadProduct()
        {
            using (var db = new SlaughterhouseEntities())
            {
                product = db.products.Find(PRODUCT_CODE);
                lblMinWeight.Text = product.min_weight.ToString();
                lblMaxWeight.Text = product.max_weight.ToString();

                var plant = db.plants.Find(plantID);
                productionDate = plant.production_date;
                lblCurrentDatetime.Text = productionDate.ToString("dd-MM-yyyy");

                var trucks = db.trucks.Where(p => p.truck_type_id == 2 && p.active == true).Select(p => new
                {
                    p.truck_id,
                    p.truck_no,
                }).ToList();

                cboTruckNo.DisplayMember = "truck_no";
                cboTruckNo.ValueMember = "truck_id";
                cboTruckNo.DataSource = trucks;

            }
        }

        private void LoadLotNo()
        {

            lotNo = "";
            try
            {
                var sql = @"SELECT lot_no,
                                SUM(receive_qty - chill_qty) as stock_qty,
                                SUM(receive_wgh - chill_wgh) as stock_wgh
                                FROM receive_item
                                WHERE product_code='{0}'
                                AND (receive_qty - chill_qty) > 0
                                GROUP BY lot_no
                                ORDER BY lot_no ASC";
                using (var db = new SlaughterhouseEntities())
                {
                    var stockLots = db.Database.SqlQuery<StockLot>(string.Format(sql, PRODUCT_CODE)).ToList();
                    flowLayoutPanel1.Controls.Clear();
                    buttons = new List<Button>();
                    foreach (var item in stockLots)
                    {
                        var btn = new Button
                        {
                            Text = string.Format("{0}\r{1} : {2} Kg.", item.lot_no, item.stock_qty.ToComma(), item.stock_wgh.ToFormat2Double()),
                            Width = 180,
                            Height = 80,
                            FlatStyle = FlatStyle.Flat,
                            Font = new Font("Kanit", 14),
                            BackColor = Color.WhiteSmoke,
                            Tag = item.lot_no
                        };

                        buttons.Add(btn);

                        btn.Click += Btn_Click;
                        //flowLayoutPanel1.Controls.Add(btn);

                    }
                    Index = 0;
                    DisplayPaging();

                }
            }
            catch (Exception)
            {

                throw;
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
            btn.BackColor = ColorTranslator.FromHtml("#1C6BBC");
            btn.ForeColor = Color.White;
            lotNo = btn.Tag.ToString();
        }

        private bool SaveData()
        {
            try
            {
                var orderNo = lblOrderNo.Text;
                var scaleWeight = lblWeight.Text.ToDecimal();

                var refDocumentNo = "";
                var refDocumentType = "";
                var transportNo = "";
                var truckId = cboTruckNo.SelectedValue.ToString().ToInt16();

                string createBy = Helper.GetLocalIPAddress();
                using (var db = new SlaughterhouseEntities())
                {

                    var receiveItem = db.receive_item.Where(p => p.product_code == product.product_code
                                                                      && p.lot_no == lotNo
                                                                      && p.chill_qty == 0)
                                                                      .OrderBy(p => p.seq).Take(1).SingleOrDefault();

                    if (receiveItem == null)
                    {
                        LoadLotNo();
                        throw new Exception("ไม่พบ Lot No\rกรุณาเลือก Lot No ใหม่!");
                    }

                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            int seq = 0;
                            string stockNo = "";
                            int bomCode = 0;
                            if (!string.IsNullOrEmpty(orderNo))
                            {
                                refDocumentNo = orderNo;
                                refDocumentType = Constants.SO;
                                //update order
                                var orderItem = db.orders_item.Where(p => p.order_no == orderNo
                                                   && p.product_code == product.product_code).SingleOrDefault();

                                if (orderItem.order_qty - orderItem.unload_qty == 0)
                                {
                                    throw new Exception("ไม่สามารถจ่ายได้!\rจำนวนจ่ายครบแล้ว");
                                }


                                bomCode = orderItem.bom_code;
                                //update production order
                                orderItem.unload_qty += 1;
                                orderItem.unload_wgh += scaleWeight;
                                orderItem.modified_at = DateTime.Now;
                                orderItem.modified_by = createBy;
                                db.Entry(orderItem).State = EntityState.Modified;

                                var transport = db.transports.Where(p => p.ref_document_no == orderNo).SingleOrDefault();
                                var transportGenrate = db.document_generate.Find(Constants.TP);
                                if (transport == null)
                                {
                                    transportNo = Constants.TP + transportGenrate.running.ToString().PadLeft(10 - Constants.TP.Length, '0');

                                    //update transport running
                                    transportGenrate.running += 1;
                                    db.Entry(transportGenrate).State = EntityState.Modified;

                                }
                                else
                                {
                                    transportNo = transport.transport_no;

                                }
                            }
                            else
                            {
                                var issDoc = db.document_generate.Find(Constants.ISS);// (from p in db.document_generate where p.document_type == Constants.ISS select p).SingleOrDefault();
                                refDocumentNo = Constants.ISS + issDoc.running.ToString().PadLeft(10 - Constants.ISS.Length, '0');
                                refDocumentType = Constants.ISS;
                            }

                            var stockGenerate = db.document_generate.Find(Constants.STK);
                            //check stock_item_running
                            var stockItemRunning = db.stock_item_running.Where(p => p.doc_no.Equals(refDocumentNo)).SingleOrDefault();
                            if (stockItemRunning == null)
                            {
                                //get new stock doc no
                                stockNo = Constants.STK + stockGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                                seq = 1;
                            }
                            else
                            {
                                stockNo = stockItemRunning.stock_no;
                                seq = stockItemRunning.stock_item + 1;
                            }

                            if (!string.IsNullOrEmpty(orderNo))
                            {
                                //update receive item
                                receiveItem.transfer_qty = 1;
                                receiveItem.transfer_wgh = scaleWeight;

                                var transport = db.transports.Find(transportNo);
                                if (transport == null)
                                {
                                    var trans = new transport
                                    {
                                        transport_no = transportNo,
                                        transport_date = DateTime.Today,
                                        ref_document_no = orderNo,
                                        truck_id = truckId,
                                        transport_flag = 0,
                                        create_at = DateTime.Now,
                                        create_by = createBy
                                    };
                                    db.transports.Add(trans);
                                }
                                else
                                {
                                    transport.truck_id = truckId;
                                    db.Entry(transport).State = EntityState.Modified;
                                }
                                //insert transport item
                                var transItem = new transport_item
                                {
                                    transport_no = transportNo,
                                    product_code = product.product_code,
                                    seq = seq,
                                    transport_qty = 1,
                                    transport_wgh = scaleWeight,
                                    stock_no = stockNo,
                                    lot_no = lotNo,
                                    truck_id = truckId,
                                    barcode_no = 0,
                                    bom_code = bomCode,
                                    create_at = DateTime.Now,
                                    create_by = createBy
                                };
                                db.transport_item.Add(transItem);
                            }
                            else
                            {
                                //var issued = db.issued_info.Where(p => p.issued_date == productionDate
                                //                                && p.product_code == product.product_code
                                //                                && p.lot_no == lotNo).SingleOrDefault();
                                var issuedInfo = db.issued_info.Find(productionDate, product.product_code, lotNo);
                                if (issuedInfo == null)
                                {
                                    var newIssued = new issued_info
                                    {
                                        issued_date = productionDate,
                                        product_code = product.product_code,
                                        lot_no = lotNo,
                                        issued_qty = 1,
                                        issued_wgh = scaleWeight,
                                        usage_qty = 0,
                                        usage_wgh = 0,
                                        active = true,
                                        create_at = DateTime.Now,
                                        create_by = createBy
                                    };
                                    db.issued_info.Add(newIssued);

                                }
                                else
                                {
                                    issuedInfo.issued_qty += 1;
                                    issuedInfo.issued_wgh += scaleWeight;
                                    issuedInfo.modified_at = DateTime.Now;
                                    issuedInfo.modified_by = createBy;
                                    db.Entry(issuedInfo).State = EntityState.Modified;
                                }

                            }
                            //update receive item
                            receiveItem.chill_qty = 1;
                            receiveItem.chill_wgh = scaleWeight;
                            receiveItem.modified_at = DateTime.Now;
                            receiveItem.modified_by = createBy;
                            db.Entry(receiveItem).State = EntityState.Modified;

                            //insert stock
                            var stock = new stock
                            {
                                stock_date = productionDate,
                                stock_no = stockNo,
                                stock_item = seq,
                                product_code = product.product_code,
                                stock_qty = 1,
                                stock_wgh = scaleWeight,
                                ref_document_no = refDocumentNo,
                                ref_document_type = refDocumentType,
                                lot_no = lotNo,
                                location_code = 2, //ห้องเย็นเก็บหมุซีก
                                barcode_no = 0,
                                transaction_type = 2,
                                create_by = createBy
                            };

                            db.stocks.Add(stock);
                            //รับหมูซีก เครื่องใน ไม่ต้อง update stock_item_running เพราะเริ่มตาม receive_item.seq
                            if (stockItemRunning == null)
                            {
                                //insert stock_item_running
                                var newStockItem = new stock_item_running
                                {
                                    doc_no = refDocumentNo,
                                    stock_no = stockNo,
                                    stock_item = 1,
                                    create_by = createBy

                                };

                                db.stock_item_running.Add(newStockItem);
                                //update document_generate
                                stockGenerate.running += 1;
                                db.Entry(stockGenerate).State = EntityState.Modified;
                            }
                            else
                            {
                                //update stock_item_running
                                stockItemRunning.stock_item += 1;
                                db.Entry(stockItemRunning).State = EntityState.Modified;
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

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //private static readonly Random random = new Random();

        //private static double RandomNumberBetween(double minValue, double maxValue)
        //{
        //    var next = random.NextDouble();

        //    return minValue + (next * (maxValue - minValue));
        //}

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

        private void btnZero_Click(object sender, EventArgs e)
        {
            lblWeight.Text = 0m.ToFormat2Decimal();
        }

        private void btnSetWgh_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lotNo))
                {
                    throw new Exception("กรุณาเลือก Lot No!");
                }


                lblWeight.Text = txtSimWeight.Text;
                isStart = true;
                isZero = true;

                btnOrderNo.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnAcceptWeight.Enabled = true;
                lblMessage.Text = Constants.WEIGHT_WAITING;
                ProcessData();
            }
            catch (Exception ex)
            {
                var toastNotification = new Notification("Error", ex.Message, displayTime, Color.Red, animationMethod, animationDirection);
                toastNotification.Show();
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(lblOrderNo.Text))
                {
                    if (string.IsNullOrEmpty(cboTruckNo.Text))
                    {
                        throw new Exception("กรุณาเลือก ทะเบียนรถ!");

                    }
                }
                if (string.IsNullOrEmpty(lotNo))
                {
                    throw new Exception("กรุณาเลือก Lot No!");
                }


                if (System.Diagnostics.Debugger.IsAttached == false)
                {
                    if (!serialPort1.IsOpen)
                        serialPort1.Open();
                }

                isStart = true;
                isZero = true;
                btnOrderNo.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnAcceptWeight.Enabled = true;
                lblMessage.Text = Constants.WEIGHT_WAITING;


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

                btnOrderNo.Enabled = true;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                btnAcceptWeight.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BtnAcceptWeight_Click(object sender, EventArgs e)
        {
            ProcessData();
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
                lotNo = "";

                //var orderNo = lblOrderNo.Text;
                //if (!string.IsNullOrEmpty(orderNo))
                //{
                //    LoadData(lblOrderNo.Text);
                //}

                //LoadLotNo();
            }
            else
            {
                lblMessage.Text = Constants.MINWEIGHT_WAITING;
            }
        }

        private void TimerMinWeight_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void BtnOrderNo_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new Form_Orders(product.product_code);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    lblOrderNo.Text = frm.OrderNo;
                    LoadData();
                    LoadLotNo();
                }
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }

        }

        private void BtnShowTruck_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var frm = new Form_LookupTruck();

            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        lblTruckNo.Text = frm.TruckNo;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    DisplayNotification("Error", ex.Message, Color.Red);
            //}
        }
    }
}
