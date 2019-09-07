
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

namespace SlaughterHouseClient.Receiving
{
    public partial class Form_ByProduct : Form
    {
        product product;


        private const int LOCATION_CODE = 3;
        private bool isStart = false;
        string sumText;
        bool lockWeight = false;

        SerialPortManager _spManager;


        public Form_ByProduct(string productCode)
        {
            InitializeComponent();
            UserInitialization();
            LoadProduct(productCode);
            lblCaption.Text = string.Format("รับ{0}", product.product_name);
            lblMinWeight.Text = product.min_weight.ToString();
            lblMaxWeight.Text = product.max_weight.ToString();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            lblCurrentDatetime.Text = DateTime.Today.ToString("dd.MM.yyyy");
            lblMessage.Text = Constants.CHOOSE_QUEUE;



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
                int stock_qty = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Sum(p => p.receive_qty);
                decimal stock_wgh = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Sum(p => p.receive_wgh);

                int remain_qty = receive.farm_qty - stock_qty;
                lblReceiveNo.Text = receive.receive_no;
                lblFarm.Text = receive.farm.farm_name;
                lblBreeder.Text = receive.breeder.breeder_name;
                lblTruckNo.Text = receive.truck_no;
                lblQueueNo.Text = receive.queue_no.ToString();
                lblSwineQty.Text = receive.factory_qty.ToComma();
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


            lblMessage.Text = Constants.START_WAITING;
        }

        private void LoadProduct(string productCode)
        {
            using (var db = new SlaughterhouseEntities())
            {
                product = db.products.Where(p => p.product_code == productCode).SingleOrDefault();
                lblMinWeight.Text = product.min_weight.ToString();
                lblMaxWeight.Text = product.max_weight.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReceiveNo_Click(object sender, EventArgs e)
        {
            var frm = new Form_LookupSwine();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(frm.receiveNo);

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            //var animationDirection = FormAnimator.AnimationDirection.Up;
            //var animationMethod = FormAnimator.AnimationMethod.Slide;
            //var toastNotification = new Notification("Notification", "Start", -1, animationMethod, animationDirection);
            //toastNotification.Show();

            isStart = true;
            lblMessage.Text = Constants.WEIGHT_WAITING;
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

            //try
            //{

            //    var ret = SaveData();
            //    if (ret)
            //    {
            //        LoadData(lblReceiveNo.Text);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //var animationDirection = FormAnimator.AnimationDirection.Up;
            //    //var animationMethod = FormAnimator.AnimationMethod.Slide;
            //    //var toastNotification = new Notification("Notification", ex.Message, -1, animationMethod, animationDirection);
            //    //PlayNotificationSound("normal");
            //    //toastNotification.Show();

            //}

        }

        //private static void PlayNotificationSound(string sound)
        //{
        //    var soundsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");
        //    var soundFile = Path.Combine(soundsFolder, sound + ".wav");

        //    using (var player = new System.Media.SoundPlayer(soundFile))
        //    {
        //        player.Play();
        //    }
        //}

        private bool SaveData()
        {
            try
            {

                decimal weight = lblWeight.Text.ToDecimal();
                using (var db = new SlaughterhouseEntities())
                {
                    //update receive
                    var receive = db.receives.Where(p => p.receive_no.Equals(lblReceiveNo.Text)).SingleOrDefault();

                    int stock_qty = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Sum(p => p.receive_qty);
                    if (receive.factory_qty - stock_qty == 0)
                    {
                        throw new Exception("จำนวนรับครบแล้ว ไม่สามารถรับเพิ่มได้!");
                    }


                    int seq = receive.receive_item.Where(p => p.product_code.Equals(product.product_code)).Count();
                    //int seq = db.receive_item.Where(p => p.receive_no == receive.receive_no).Count();
                    seq += 1;
                    var item = new receive_item
                    {
                        receive_no = receive.receive_no,
                        product_code = product.product_code,
                        seq = seq,
                        sex_flag = "",
                        receive_qty = 1,
                        receive_wgh = weight,
                        create_by = Constants.CREATE_BY

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



                            //receive.factory_qty += item.receive_qty;
                            //receive.factory_wgh += item.receive_wgh;
                            //db.Entry(receive).State = EntityState.Modified;

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
                                barcode_no = 0,
                                transaction_type = 1,
                                create_by = item.create_by
                            };

                            db.stocks.Add(stock);

                            //รับหมูซีก เครื่องใน ไม่ต้อง update stock_item_running เพราะเริ่มตาม receive_item.seq

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
                            //    documentGenerate.running += 1;
                            //    db.Entry(documentGenerate).State = EntityState.Modified;


                            //}
                            //else
                            //{

                            //    //update stock_item_running
                            //    stockItemRunning.stock_item += 1;
                            //    db.Entry(stockItemRunning).State = EntityState.Modified;
                            //}




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

                //ReceiveItem receiveItem = new ReceiveItem
                //{
                //    ReceiveNo = receive.ReceiveNo,
                //    ProductCode = this.productCode,
                //    SexFlag = sexFlag,
                //    ReceiveQty = 1,
                //    ReceiveWgh = lblWeight.Text.ToDecimal(),
                //    CreateBy = "Auto"
                //};
                //return ReceiveController.InsertItem(receiveItem);
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
        }
    }
}
