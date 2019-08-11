
using SerialPortListener.Serial;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlaughterHouseClient.Receiving
{
    public partial class Form_Carcass : Form
    {
        private string productCode = "P002";
        private bool isStart = false;
        string sumText;
        bool lockWeight = false;
        bool minWeightReset = false;
        int minWeightTime = 0;


        //const string CHOOSE_QUEUE = "กรุณาเลือกคิว";
        //const string START_WAITING = "กรุณาเริ่มชั่ง";
        //const string WEIGHT_WAITING = "กรุณาชั่งน้ำหนัก";

        SerialPortManager _spManager;


        public Form_Carcass()
        {
            InitializeComponent();
            UserInitialization();
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
            BtnOK.Enabled = false;
            //BtnCloseQueue.Enabled = false;

        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isStart)
                _spManager.StopListening();
            _spManager.Dispose();
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


        private void DisplayWeight(string str)
        {
            if (str.Length == 38 && !lockWeight)
            {
                var weight = str.Substring(14, 7).ToDecimal() / 1000;
                lblWeight.Text = weight.ToFormat2Decimal();

            }
            //tbData.AppendText(str);
            //tbData.ScrollToCaret();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_SwineReceive_Load(object sender, EventArgs e)
        {
            lblCurrentDatetime.Text = DateTime.Today.ToString("dd.MM.yyyy");
            lblMessage.Text = Constants.CHOOSE_QUEUE;
        }

        private void btnReceiveNo_Click(object sender, EventArgs e)
        {
            var frm = new Form_Receive(1);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(frm.receiveNo);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isStart = true;
            lblMessage.Text = Constants.WEIGHT_WAITING;
            if (_spManager.CurrentSerialSettings.PortName != "")
                _spManager.StartListening();


            lblWeight.Text = "80.23";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            BtnOK.Enabled = true;
        }


        private void LoadData(string receiveNo)
        {

            using (var db = new SlaughterhouseEntities())
            {
                var receive = db.receives.Where(p => p.receive_no == receiveNo).SingleOrDefault();
                int stock_qty = receive.receive_item.Where(p => p.product_code.Equals(productCode)).Sum(p => p.receive_qty);
                decimal stock_wgh = receive.receive_item.Where(p => p.product_code.Equals(productCode)).Sum(p => p.receive_wgh);
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
            }


            lblMessage.Text = Constants.START_WAITING;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            if (_spManager.CurrentSerialSettings.PortName != "")
                _spManager.StopListening();


            lblWeight.Text = "0.00";
            btnStart.Enabled = true;
            btnStop.Enabled = false;

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
                var receive_wgh = lblWeight.Text.ToDecimal();
                using (var db = new SlaughterhouseEntities())
                {
                    //update receive
                    var receive = db.receives.Where(p => p.receive_no.Equals(lblReceiveNo.Text)).SingleOrDefault();

                    int stock_qty = receive.receive_item.Where(p => p.product_code.Equals(productCode)).Sum(p => p.receive_qty);
                    if (receive.factory_qty - stock_qty == 0)
                    {
                        throw new Exception("จำนวนรับครบแล้ว ไม่สามารถรับเพิ่มได้!");
                    }


                    int seq = receive.receive_item.Where(p => p.product_code.Equals(productCode)).Count();
                    //int seq = db.receive_item.Where(p => p.receive_no == receive.receive_no).Count();
                    seq += 1;
                    var item = new receive_item
                    {
                        receive_no = receive.receive_no,
                        product_code = productCode,
                        seq = seq,
                        lot_no = receive.lot_no,
                        sex_flag = "",
                        receive_qty = 1,
                        receive_wgh = receive_wgh,
                        chill_qty = 0,
                        chill_wgh = 0,
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
                                location_code = 2, //ห้องเย็นเก็บหมุซีก
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


                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                lockWeight = true;
                string msg = string.Format("{0}", lblWeight.Text);
                var frmConfirm = new CustomMessageBox(msg);
                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    BtnOK.Enabled = false;
                    btnStop.Enabled = false;
                    lblMessage.Text = Constants.PROCESSING;
                    //Thread.Sleep(1000);
                    SaveData();
                    Console.Beep();
                    lblWeight.BackColor = Color.FromArgb(33, 150, 83);
                    lblWeight.ForeColor = Color.White;
                    await Task.Delay(1000);
                    lblWeight.BackColor = Color.White;
                    lblWeight.ForeColor = Color.Black;
                    //รอรับน้ำหนัก  MinWeight
                    lockWeight = false;
                    TmMinWeight.Enabled = true;
                }
                lockWeight = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            lblWeight.Text = "0.00";
        }


        #region MinWeightProcess


        private void TmMinWeight_Tick(object sender, EventArgs e)
        {
            if (!BgwMinWeight.IsBusy)
                BgwMinWeight.RunWorkerAsync();

        }

        private void BgwMinWeight_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            minWeightTime += 1;
        }

        private void BgwMinWeight_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            var scaleWeight = lblWeight.Text.ToDecimal();
            if (scaleWeight > Constants.MIN_WEIGHT_RESET)
            {
                lblMessage.Text = string.Format("บันทึกเรียบร้อย. กรุณานำสินค้า ออกจากตาชั่ง ! {0} วินาที", minWeightTime);
            }
            else
            {
                TmMinWeight.Enabled = false;
                LoadData(lblReceiveNo.Text);
                minWeightReset = true;
                minWeightTime = 0;
                lblMessage.Text = Constants.WEIGHT_WAITING;
            }
        }


        #endregion
    }
}
