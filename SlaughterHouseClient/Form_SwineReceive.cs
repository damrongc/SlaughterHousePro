
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseClient
{
    public partial class Form_SwineReceive : Form
    {
        private string productCode = "P001";
        private string sexFlag = "F";
        private bool isStart = false;

        const string CHOOSE_QUEUE = "กรุณาเลือกคิว";
        const string START_WAITING = "กรุณาเริ่มชั่ง";
        const string WEIGHT_WAITING = "กรุณาชั่งน้ำหนัก";
        public Form_SwineReceive()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_SwineReceive_Load(object sender, EventArgs e)
        {
            lblCurrentDatetime.Text = DateTime.Today.ToString("dd.MM.yyyy");
            lblMessage.Text = CHOOSE_QUEUE;
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
            lblMessage.Text = WEIGHT_WAITING;
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
                lblFactoryWgh.Text = receive.factory_wgh.ToFormat2Decimal();
                lblRemainQty.Text = (receive.farm_qty - receive.factory_qty).ToComma();
            }

            lblMessage.Text = START_WAITING;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                //StockController.InsertStockSwineReceive(receive.ReceiveNo);
                var ret = SaveData();
                if (ret)
                {
                    LoadData(lblReceiveNo.Text);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        sex_flag = sexFlag,
                        receive_qty = 1,
                        receive_wgh = 100,
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
