
using System;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SlaughterHouseClient.Receiving
{
    public partial class Form_ByProductWithParts : Form
    {
        private string productCode = "";
        private int _productGroupCode;
        private const int LOCATION_CODE = 3;
        private bool IsStart = false;


        const string CHOOSE_QUEUE = "กรุณาเลือกคิว";
        const string START_WAITING = "กรุณาเริ่มชั่ง";
        const string WEIGHT_WAITING = "กรุณาชั่งน้ำหนัก";
        public Form_ByProductWithParts(int productGroupCode)
        {
            InitializeComponent();
            Shown += Form_Shown;
            _productGroupCode = productGroupCode;
        }

        private void Form_Shown(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_SwineReceive_Load(object sender, EventArgs e)
        {
            lblCurrentDatetime.Text = DateTime.Today.ToString("dd.MM.yyyy");
            lblMessage.Text = CHOOSE_QUEUE;



        }

        private void btnReceiveNo_Click(object sender, EventArgs e)
        {
            var frm = new Form_Receive(1);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(frm.receiveNo);
                LoadProduct();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblReceiveNo.Text))
            {
                lblMessage.Text = "กรุณาเลือกข้อมูล!";
                return;
            }
            if (string.IsNullOrEmpty(productCode))
            {
                lblMessage.Text = "กรุณาเลือกสินค้า!";
                return;
            }
            IsStart = true;
            lblMessage.Text = WEIGHT_WAITING;


        }


        private void LoadProduct()
        {

            flowLayoutPanel1.Controls.Clear();
            using (var db = new SlaughterhouseEntities())
            {
                var products = db.products.Where(p => p.product_group_code == _productGroupCode).ToList();

                foreach (var item in products)
                {
                    var btn = new Button
                    {
                        Text = item.product_name,
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
            productCode = btn.Tag.ToString();
            lblMessage.Text = WEIGHT_WAITING;
        }

        private void LoadData(string receiveNo)
        {

            using (var db = new SlaughterhouseEntities())
            {
                var receive = db.receives.Where(p => p.receive_no == receiveNo).SingleOrDefault();
                //int stock_qty = receive.receive_item.Where(p => p.product_code.Equals(productCode)).Sum(p => p.receive_qty);
                //decimal stock_wgh = receive.receive_item.Where(p => p.product_code.Equals(productCode)).Sum(p => p.receive_wgh);

                lblReceiveNo.Text = receive.receive_no;
                lblFarm.Text = receive.farm.farm_name;
                lblBreeder.Text = receive.breeder.breeder_name;
                lblTruckNo.Text = receive.truck_no;
                lblQueueNo.Text = receive.queue_no.ToString();
                lblSwineQty.Text = receive.factory_qty.ToComma();
                //lblStockQty.Text = stock_qty.ToComma();
                //lblStockWgh.Text = stock_wgh.ToFormat2Decimal();
                //lblRemainQty.Text = (receive.farm_qty - stock_qty).ToComma();
            }

            lblMessage.Text = START_WAITING;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {

                var ret = SaveData();
                if (ret)
                {
                    LoadData(lblReceiveNo.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //var animationDirection = FormAnimator.AnimationDirection.Up;
                //var animationMethod = FormAnimator.AnimationMethod.Slide;
                //var toastNotification = new Notification("Notification", ex.Message, -1, animationMethod, animationDirection);
                //PlayNotificationSound("normal");
                //toastNotification.Show();

            }

        }

        private static void PlayNotificationSound(string sound)
        {
            var soundsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");
            var soundFile = Path.Combine(soundsFolder, sound + ".wav");

            using (var player = new System.Media.SoundPlayer(soundFile))
            {
                player.Play();
            }
        }

        private bool SaveData()
        {
            try
            {
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
                        sex_flag = "",
                        receive_qty = 1,
                        receive_wgh = 85,
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
    }
}
