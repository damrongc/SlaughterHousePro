using nucs.JsonSettings;
using SlaughterHouseEF;
using System;
using System.Data.Entity;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using ToastNotifications;
namespace SlaughterHouseClient.Issued
{
    public partial class Form_CarcassForSales : Form
    {
        private readonly SettingsBag MySettings = JsonSettings.Load<SettingsBag>("config.json");
        readonly int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
        const string PRODUCT_CODE = "00-0031";
        product product;
        private readonly string lotNo = string.Empty;
        private DateTime productionDate;
        private bool isStart = false;
        private bool isZero = true;
        //bool lockWeight = false;
        //int stableCount = 0;
        private int stableTarget = 0;
        private int displayTime = 3;
        private int scaleDivision = 100;
        bool firstTime = true;
        readonly FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        readonly FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;
        delegate void SetTextCallback(string text);
        string InputData = string.Empty;
        public Form_CarcassForSales()
        {
            InitializeComponent();
            UserInitialization();
        }
        private void UserInitialization()
        {
            serialPort1.DataReceived += port_DataReceived;
            FormClosing += new FormClosingEventHandler(Form_FormClosing);
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
            //btnAcceptWeight.Enabled = false;
            LoadSetting();
            LoadProduct();
            lblMessage.Text = Constants.CHOOSE_QUEUE;
            if (System.Diagnostics.Debugger.IsAttached)
                plSimulator.Visible = true;
            else
                plSimulator.Visible = false;
        }
        private void BtnNumber_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (lblWeight.Text.Length >= 5)
                return;
            if (btn.Text == "0" && string.IsNullOrEmpty(lblWeight.Text))
                return;
            else
            {
                if (firstTime)
                {
                    lblWeight.Text = btn.Text;
                    firstTime = false;
                }
                else
                {
                    lblWeight.Text += btn.Text;
                    //lblWeight.Text = (lblWeight.Text + btn.Text).ToInt16().ToString();
                }
            }
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
            //Thread.Sleep(100);
            //if (serialPort1.IsOpen)
            //    InputData = serialPort1.ReadExisting();
            //if (InputData != string.Empty)
            //{
            //    BeginInvoke(new SetTextCallback(DisplayWeight), new object[] { InputData });
            //}
        }
        //private void DisplayWeight(string DataInvoke)
        //{
        //    if (lockWeight == false)
        //    {
        //        double num = 0.0;
        //        if (DataInvoke.Length == 40)
        //        {
        //            short stateOfScale = DataInvoke.Substring(6, 1).ToInt16();
        //            short stableWt = DataInvoke.Substring(5, 1).ToInt16();
        //            if (stableWt == 2)
        //            {
        //                lblWeight.Text = "---.---";
        //            }
        //            else
        //            {
        //                if (stateOfScale == 0)
        //                {
        //                    num = DataInvoke.Substring(16, 6).ToDouble() / scaleDivision;
        //                }
        //                else if (stateOfScale == 1)
        //                {
        //                    num = -1.0 * DataInvoke.Substring(16, 6).ToDouble() / scaleDivision;
        //                }
        //                lblWeight.Text = (num).ToFormat2Double();//ScaleHelper.GetWeightIWX(DataInvoke);
        //                if (isStart && isZero)
        //                {
        //                    if (num > 0 && num > product.min_weight.ToString().ToDouble())
        //                    {
        //                        if (stableWt == 0)
        //                            stableCount += 1;
        //                        else
        //                            stableCount = 0;
        //                        lblStable.Text = stableCount.ToString();
        //                        lblStable.Refresh();
        //                    }
        //                    if (stableCount >= Constants.STABLE_TARGET.ToInt16())
        //                    {
        //                        lockWeight = true;
        //                        ProcessData();
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        private void ProcessData()
        {
            try
            {
                isZero = false;
                if (string.IsNullOrEmpty(lblOrderNo.Text))
                {
                    throw new Exception("กรุณาระบุ เลือกลูกค้า!");
                }
                if (string.IsNullOrEmpty(lblWeight.Text))
                {
                    throw new Exception("กรุณาระบุ น้ำหนัก!");
                }
                decimal.TryParse(lblWeight.Text, out decimal scaleWeight);
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
                DisplayNotification("Success", $"บันทึกรายการขาย เลขที่ {lblOrderNo.Text}\rเรียบร้อยแล้ว", Color.Green);
                LoadData();
                //clear weight
                //lockWeight = false;
                //timerMinWeight.Enabled = true;
                lblWeight.Text = "0.00";
                lblMessage.Text = Constants.START_WAITING;
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
            finally
            {
                btnAcceptWeight.Enabled = true;
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
                var order = db.orders.Find(orderNo);
                var orderItems = order.orders_item.Where(p => p.product_code == product.product_code).ToList();
                if (orderItems.Count == 0)
                {
                    lblOrderNo.Text = "";
                    lblProduct.Text = "";
                    lblCustomer.Text = "";
                    lblOrderQty.Text = "0";
                    lblOrderWgh.Text = "0";
                    lblUnloadedQty.Text = "0";
                    lblUnloadedWgh.Text = "0";
                    throw new Exception("ไม่พบสินค้า หมุซีก 1 ซีีก\rในรายการขาย");
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
                //if (string.IsNullOrEmpty(orderNo))
                //{
                //    //Load ข้อมูลจ่ายตัดแต่ง
                //    var issuedInfo = db.issued_info.Find(productionDate, PRODUCT_CODE, lotNo);
                //    if (issuedInfo != null)
                //    {
                //        lblUnloadedQty.Text = issuedInfo.issued_qty.ToComma();
                //        lblUnloadedWgh.Text = issuedInfo.issued_wgh.ToFormat2Decimal();
                //    }
                //}
                //else
                //{
                //    var order = db.orders.Find(orderNo);
                //    var orderItems = order.orders_item.Where(p => p.product_code == product.product_code).ToList();
                //    if (orderItems.Count == 0)
                //    {
                //        lblOrderNo.Text = "";
                //        lblProduct.Text = "";
                //        lblCustomer.Text = "";
                //        lblOrderQty.Text = "0";
                //        lblOrderWgh.Text = "0";
                //        lblUnloadedQty.Text = "0";
                //        lblUnloadedWgh.Text = "0";
                //        throw new Exception("ไม่พบสินค้า จ่ายหมุซีก\rในรายการขาย");
                //    }
                //    lblProduct.Text = orderItems[0].product.product_name;
                //    lblOrderQty.Text = orderItems[0].order_qty.ToComma();
                //    lblOrderWgh.Text = orderItems[0].order_wgh.ToFormat2Decimal();
                //    lblUnloadedQty.Text = orderItems[0].unload_qty.ToComma();
                //    lblUnloadedWgh.Text = orderItems[0].unload_wgh.ToFormat2Decimal();
                //    lblCustomer.Text = order.customer.customer_name;
                //    var transport = db.transports.Where(p => p.ref_document_no == order.order_no).SingleOrDefault();
                //    if (transport != null)
                //    {
                //        cboTruckNo.SelectedValue = transport.truck_id;
                //        cboTruckNo.Enabled = false;
                //    }
                //}
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
        private bool SaveData()
        {
            try
            {
                var orderNo = lblOrderNo.Text;
                var scaleWeight = lblWeight.Text.ToDecimal();
                var refDocumentNo = "";
                var refDocumentType = "";
                string stockNo = "";
                string transportNo = "";
                int transportItem = 0;
                var truckId = cboTruckNo.SelectedValue.ToString().ToInt16();
                string createBy = Helper.GetLocalIPAddress();
                using (var db = new SlaughterhouseEntities())
                {

                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
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

                            var transport = db.transports.Where(p => p.ref_document_no == orderNo).SingleOrDefault();
                            if (transport == null)
                            {
                                transportNo = Helper.GetDocGenerator(Constants.TP);
                                transportItem = 1;
                            }
                            else
                            {
                                transportNo = transport.transport_no;
                                transportItem = transport.transport_item.Count() + 1;
                            }

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
                                seq = transportItem,
                                transport_qty = 1,
                                transport_wgh = scaleWeight,
                                stock_no = stockNo,
                                lot_no = lotNo,
                                truck_id = truckId,
                                barcode_no = 0,
                                bom_code = 0,
                                create_at = DateTime.Now,
                                create_by = createBy
                            };
                            db.transport_item.Add(transItem);

                            orderItem.unload_qty += 1;
                            orderItem.unload_wgh += scaleWeight;
                            orderItem.modified_at = DateTime.Now;
                            orderItem.modified_by = createBy;
                            db.Entry(orderItem).State = EntityState.Modified;

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
        private void BtnAcceptWeight_Click(object sender, EventArgs e)
        {
            ProcessData();
        }
        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        }
        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //double scaleWeight = lblWeight.Text.ToDouble();
            //double minWeight = lblMinWeight.Text.ToDouble();
            //if (scaleWeight <= minWeight)
            //{
            //    lblMessage.Text = Constants.WEIGHT_WAITING;
            //    isZero = true;
            //    stableCount = 0;
            //    lblStable.Text = stableCount.ToString();
            //    timerMinWeight.Enabled = false;
            //    btnAcceptWeight.Enabled = true;
            //    lotNo = "";
            //    //var orderNo = lblOrderNo.Text;
            //    //if (!string.IsNullOrEmpty(orderNo))
            //    //{
            //    //    LoadData(lblOrderNo.Text);
            //    //}
            //    //LoadLotNo();
            //}
            //else
            //{
            //    lblMessage.Text = Constants.MINWEIGHT_WAITING;
            //}
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
                    lblMessage.Text = Constants.WEIGHT_WAITING;
                }
            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblWeight.Text = "";
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblWeight.Text.IndexOf(".") >= 0)
            {
                return;
            }
            lblWeight.Text += ".";
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblWeight.Text.Length == 0)
            {
                return;
            }
            lblWeight.Text = lblWeight.Text.Substring(0, lblWeight.Text.Length - 1);
        }
    }
}
