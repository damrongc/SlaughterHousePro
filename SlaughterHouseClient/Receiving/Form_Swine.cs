﻿
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
    public partial class Form_Swine : Form
    {
        private string productCode = "P001";
        private string sexFlag = "F";
        private bool isStart = false;
        string sumText;
        bool lockWeight = false;
        bool minWeightReset = false;
        int minWeightTime = 0;

        //const string CHOOSE_QUEUE = "กรุณาเลือกคิว";
        //const string START_WAITING = "กรุณาเริ่มชั่ง";
        //const string WEIGHT_WAITING = "กรุณาชั่งน้ำหนัก";

        SerialPortManager _spManager;

        public Form_Swine()
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
            BtnCloseQueue.Enabled = false;


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
            var frm = new Form_Receive(0);
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


            lblWeight.Text = "100.00";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            BtnOK.Enabled = true;


        }

        private void btnFemale_Click(object sender, EventArgs e)
        {

            sexFlag = "F";
            btnFemale.BackColor = System.Drawing.ColorTranslator.FromHtml("#459CDB");
            btnMale.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            btnUndified.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
        }

        private void btnMale_Click(object sender, EventArgs e)
        {

            sexFlag = "M";
            btnFemale.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            btnMale.BackColor = System.Drawing.ColorTranslator.FromHtml("#459CDB");
            btnUndified.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");

        }

        private void btnUndified_Click(object sender, EventArgs e)
        {

            sexFlag = "NA";
            btnFemale.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            btnMale.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            btnUndified.BackColor = System.Drawing.ColorTranslator.FromHtml("#459CDB");

        }

        private void LoadData(string receiveNo)
        {

            using (var db = new SlaughterhouseEntities())
            {
                var receive = db.receives.Where(p => p.receive_no == receiveNo).SingleOrDefault();

                lblReceiveNo.Text = receive.receive_no;
                lblFarm.Text = receive.farm.farm_name;
                lblBreeder.Text = receive.breeder.breeder_name;
                lblTruckNo.Text = receive.truck_no;
                lblQueueNo.Text = receive.queue_no.ToString();
                lblFarmQty.Text = receive.farm_qty.ToComma();
                lblFactoryQty.Text = receive.factory_qty.ToComma();
                lblFactoryWgh.Text = receive.factory_wgh.ToFormatNoDecimal();

                var remain_qty = receive.farm_qty - receive.factory_qty;
                lblRemainQty.Text = remain_qty.ToComma();

                if (remain_qty == 0)
                {
                    btnStart.Enabled = false;
                    BtnCloseQueue.Enabled = true;
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

        private async void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                lockWeight = true;
                string msg = string.Format("ต้องการบันทึกน้ำหนัก: {0} kg.", lblWeight.Text);
                var frmConfirm = new CustomMessageBox(msg);
                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    BtnOK.Enabled = false;
                    btnStop.Enabled = false;
                    //BtnControl(false, false, false);
                    lblMessage.Text = Constants.PROCESSING;
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

        //private void BtnControl(bool start, bool ok, bool close)
        //{
        //    btnStart.Enabled = start;

        //    BtnOK.Enabled = ok;
        //    btnStop.Enabled = close;
        //}

        private bool SaveData()
        {
            try
            {
                var weight = lblWeight.Text.ToDecimal();
                using (var db = new SlaughterhouseEntities())
                {
                    //update receive
                    var receive = db.receives.Where(p => p.receive_no.Equals(lblReceiveNo.Text)).SingleOrDefault();

                    if (receive.farm_qty - receive.factory_qty == 0)
                    {
                        throw new Exception("จำนวนรับครบแล้ว ไม่สามารถรับเพิ่มได้!");
                    }


                    int seq = receive.receive_item.Count();
                    //int seq = db.receive_item.Where(p => p.receive_no == receive.receive_no).Count();
                    seq += 1;
                    var item = new receive_item
                    {
                        receive_no = receive.receive_no,
                        product_code = productCode,
                        seq = seq,
                        lot_no = receive.lot_no,
                        sex_flag = sexFlag,
                        receive_qty = 1,
                        receive_wgh = weight,
                        chill_qty = 0,
                        chill_wgh = 0,
                        create_by = Constants.CREATE_BY

                    };

                    string stock_no = "";

                    var documentGenerate = (from p in db.document_generate where p.document_type == Constants.STK select p).SingleOrDefault();


                    //check stock_item_running
                    var stockItemRunning = db.stock_item_running.Where(p => p.doc_no.Equals(receive.receive_no)).SingleOrDefault();
                    if (stockItemRunning == null)
                    {
                        //get new stock doc no
                        stock_no = Constants.STK + documentGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                    }
                    else
                    {

                        stock_no = stockItemRunning.stock_no;

                    }
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {



                            receive.factory_qty += item.receive_qty;
                            receive.factory_wgh += item.receive_wgh;
                            db.Entry(receive).State = EntityState.Modified;

                            db.receive_item.Add(item);

                            //insert stock
                            var stock = new stock
                            {
                                stock_date = receive.receive_date,
                                stock_no = stock_no,
                                stock_item = item.seq,
                                product_code = item.product_code,
                                stock_qty = item.receive_qty,
                                stock_wgh = item.receive_wgh,
                                ref_document_no = receive.receive_no,
                                ref_document_type = Constants.REV,
                                lot_no = receive.lot_no,
                                location_code = 1,
                                barcode_no = 0,
                                transaction_type = 1,
                                create_by = item.create_by
                            };

                            if (stockItemRunning == null)
                            {
                                //insert stock_item_running
                                var newStockItem = new stock_item_running
                                {
                                    doc_no = receive.receive_no,
                                    stock_no = stock_no,
                                    stock_item = 1,
                                    create_by = item.create_by
                                };

                                db.stock_item_running.Add(newStockItem);

                                //update document_generate
                                documentGenerate.running += 1;
                                db.Entry(documentGenerate).State = EntityState.Modified;


                            }
                            else
                            {
                                //update stock_item_running
                                stockItemRunning.stock_item += 1;
                                db.Entry(stockItemRunning).State = EntityState.Modified;
                            }



                            db.stocks.Add(stock);
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
        private void BgwMinWeight_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

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

        private void BtnCloseQueue_Click(object sender, EventArgs e)
        {
            try
            {
                var remainQty = lblRemainQty.Text.ToInt16();
                if (remainQty > 0)
                    throw new Exception("ไม่สามารถปิดคิว \nเนื่องจากรับไม่ครบ!");


                var receive_no = lblReceiveNo.Text;
                using (var db = new SlaughterhouseEntities())
                {
                    var receive = db.receives.Where(p => p.receive_no == receive_no).SingleOrDefault();

                    receive.receive_flag = 1;
                    receive.modified_at = DateTime.Now;
                    db.SaveChanges();

                    lblMessage.Text = "ปิดคิว เรียบร้อยแล้ว";
                }

                lblReceiveNo.Text = "";
                lblFarm.Text = "";
                lblBreeder.Text = "";
                lblTruckNo.Text = "";
                lblQueueNo.Text = "";
                lblFarmQty.Text = "0";
                lblFactoryQty.Text = "0";
                lblFactoryWgh.Text = "0";
                lblRemainQty.Text = "0";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            lblWeight.Text = "0";
        }

    }
}