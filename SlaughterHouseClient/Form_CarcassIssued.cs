
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SlaughterHouseClient
{
    public partial class Form_CarcassIssued : Form
    {
        private string productCode = "P002";
        private bool IsStart = false;
        private const string CHOOSE_DATA = "กรุณาเลือกข้อมูล";
        private const string START_WAITING = "กรุณาเริ่มชั่ง";
        private const string WEIGHT_WAITING = "กรุณาชั่งน้ำหนัก";
        public Form_CarcassIssued()
        {
            InitializeComponent();
            Shown += Form_Shown;
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            lblMessage.Text = CHOOSE_DATA;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_SwineReceive_Load(object sender, EventArgs e)
        {
            lblCurrentDatetime.Text = DateTime.Today.ToString("dd.MM.yyyy");
            lblMessage.Text = CHOOSE_DATA;
        }

        private void btnReceiveNo_Click(object sender, EventArgs e)
        {
            var frm = new Form_Issued();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(frm.issuedNo);
            }
        }

        private void btnLotNo_Click(object sender, EventArgs e)
        {
            var frm = new Form_Lot(productCode);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                lblLotNo.Text = frm.LotNoSelected;
                IsStart = true;
                lblMessage.Text = WEIGHT_WAITING;
                lblWeight.Text = RandomNumberBetween(20, 50).ToFormat2Double();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            //if (string.IsNullOrEmpty(lblProductionOrderNo.Text))
            //{
            //    lblMessage.Text = "กรุณาเลือกข้อมูล!";
            //    return;
            //}
            //if (string.IsNullOrEmpty(lblLotNo.Text))
            //{
            //    lblMessage.Text = "กรุณาเลือก Lot No!";
            //    return;
            //}

            //IsStart = true;
            //lblMessage.Text = WEIGHT_WAITING;
            //lblWeight.Text = RandomNumberBetween(20, 50).ToFormat2Double();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {

                CloseJob();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }

        private void LoadData(string poNo)
        {

            using (var db = new SlaughterhouseEntities())
            {
                var productionOrder = db.production_order.Where(p => p.po_no == poNo).SingleOrDefault();
                var productionOrderItems = productionOrder.production_order_item.Where(p => p.product_code == productCode).ToList();


                lblProductionOrderNo.Text = productionOrder.po_no;
                lblProduct.Text = productionOrderItems[0].product.product_name;
                lblProductionOrderQty.Text = productionOrderItems[0].po_qty.ToComma();
                lblRemainQty.Text = (productionOrderItems[0].po_qty - productionOrderItems[0].unload_qty).ToComma();
                lblUnloadedQty.Text = productionOrderItems[0].unload_qty.ToComma();
                lblUnloadedWgh.Text = productionOrderItems[0].unload_wgh.ToFormat2Decimal();

            }

            lblMessage.Text = START_WAITING;
        }

        private bool SaveData()
        {
            try
            {

                var poNo = lblProductionOrderNo.Text;
                var unloadWeight = lblWeight.Text.ToDecimal();
                var lotNo = lblLotNo.Text;
                using (var db = new SlaughterhouseEntities())
                {
                    //update production order
                    var productionItem = db.production_order_item.Where(p => p.po_no == poNo
                                                           && p.product_code == productCode).SingleOrDefault();


                    if (productionItem.po_qty - productionItem.unload_qty == 0)
                    {
                        throw new Exception("จำนวนเบิกครบแล้ว ไม่สามารถเบิกเพิ่มได้!");
                    }

                    var receiveItem = db.receive_item.Where(p => p.product_code == productCode
                                                               && p.lot_no == lotNo
                                                               && p.chill_qty == 0)
                                                               .OrderBy(p => p.seq).Take(1).SingleOrDefault();

                    if (receiveItem == null)
                    {
                        lblLotNo.Text = "";
                        throw new Exception("ไม่พบ Lot No นี้ในคลัง กรุณาเลือก Lot ใหม่!");
                    }



                    int seq = 0;
                    string stock_no = "";

                    var documentGenerate = (from p in db.document_generate where p.document_type == Constants.STK select p).SingleOrDefault();

                    //check stock_item_running
                    var stockItemRunning = db.stock_item_running.Where(p => p.doc_no.Equals(poNo)).SingleOrDefault();
                    if (stockItemRunning == null)
                    {
                        //get new stock doc no

                        stock_no = Constants.STK + documentGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                        seq = 1;
                    }
                    else
                    {

                        stock_no = stockItemRunning.stock_no;
                        seq = stockItemRunning.stock_item + 1;

                    }




                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {

                            //update production order
                            productionItem.unload_qty += 1;
                            productionItem.unload_wgh += unloadWeight;
                            productionItem.modified_at = DateTime.Now;
                            productionItem.modified_by = Constants.CREATE_BY;
                            db.Entry(productionItem).State = EntityState.Modified;


                            //update receive item 
                            receiveItem.chill_qty = 1;
                            receiveItem.chill_wgh = unloadWeight;
                            receiveItem.modified_at = DateTime.Now;
                            receiveItem.modified_by = Constants.CREATE_BY;
                            db.Entry(receiveItem).State = EntityState.Modified;

                            //insert stock
                            var stock = new stock
                            {
                                stock_date = DateTime.Today,
                                stock_no = stock_no,
                                stock_item = seq,
                                product_code = productionItem.product_code,
                                stock_qty = productionItem.unload_qty,
                                stock_wgh = productionItem.unload_wgh,
                                ref_document_no = poNo,
                                ref_document_type = Constants.PO,
                                lot_no = lotNo,
                                location_code = 2, //ห้องเย็นเก็บหมุซีก
                                barcode_no = 0,
                                transaction_type = 2,
                                create_by = Constants.CREATE_BY
                            };

                            db.stocks.Add(stock);

                            //รับหมูซีก เครื่องใน ไม่ต้อง update stock_item_running เพราะเริ่มตาม receive_item.seq

                            if (stockItemRunning == null)
                            {
                                //insert stock_item_running
                                var newStockItem = new stock_item_running
                                {
                                    doc_no = poNo,
                                    stock_no = stock_no,
                                    stock_item = 1,
                                    create_by = Constants.CREATE_BY

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
                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
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

        private bool CloseJob()
        {
            try
            {
                var poNo = lblProductionOrderNo.Text;
                using (var db = new SlaughterhouseEntities())
                {
                    var productionOrder = db.production_order.Where(p => p.po_no == poNo).SingleOrDefault();
                    productionOrder.po_flag = 1;
                    db.SaveChanges();


                }

                lblProductionOrderNo.Text = "";
                lblProduct.Text = "";
                lblLotNo.Text = "";
                lblProductionOrderQty.Text = 0.ToString();
                lblRemainQty.Text = 0.ToString();
                lblUnloadedQty.Text = 0.ToString();
                lblUnloadedWgh.Text = 0m.ToFormat2Decimal();
                lblWeight.Text = 0m.ToFormat2Decimal();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static readonly Random random = new Random();

        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblProductionOrderNo.Text))
                {
                    lblMessage.Text = "กรุณาเลือกข้อมูล!";
                    return;
                }
                if (string.IsNullOrEmpty(lblLotNo.Text))
                {
                    lblMessage.Text = "กรุณาเลือก Lot No!";
                    return;
                }
                var ret = SaveData();
                if (ret)
                {
                    LoadData(lblProductionOrderNo.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
    }
}
