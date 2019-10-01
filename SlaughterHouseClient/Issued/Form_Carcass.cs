
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SlaughterHouseClient.Issued
{
    public partial class Form_Carcass : Form
    {
        private string productCode = "P002";
        private bool IsStart = false;
        private const string CHOOSE_DATA = "กรุณาเลือกข้อมูล";
        private const string START_WAITING = "กรุณาเริ่มชั่ง";
        private const string WEIGHT_WAITING = "กรุณาชั่งน้ำหนัก";
        public Form_Carcass()
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
            var frm = new Form_Orders(productCode);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(frm.OrderNo);
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



        private void LoadData(string orderNo)
        {

            using (var db = new SlaughterhouseEntities())
            {
                var oreder = db.orders.Where(p => p.order_no == orderNo).SingleOrDefault();
                var orderItems = oreder.orders_item.Where(p => p.product_code == productCode).ToList();
                lblOrderNo.Text = oreder.order_no;
                lblProduct.Text = orderItems[0].product.product_name;
                lblOrderQty.Text = orderItems[0].order_qty.ToComma();
                lblOrderWgh.Text = orderItems[0].order_wgh.ToFormat2Decimal();
                lblUnloadedQty.Text = orderItems[0].unload_qty.ToComma();
                lblUnloadedWgh.Text = orderItems[0].unload_wgh.ToFormat2Decimal();
            }
            lblMessage.Text = START_WAITING;
        }

        private bool SaveData()
        {
            try
            {

                //var poNo = lblProductionOrderNo.Text;
                //var unloadWeight = lblWeight.Text.ToDecimal();
                //var lotNo = lblLotNo.Text;
                //using (var db = new SlaughterhouseEntities())
                //{
                //    //update production order
                //    var productionItem = db.production_order_item.Where(p => p.po_no == poNo
                //                                           && p.product_code == productCode).SingleOrDefault();


                //    if (productionItem.po_qty - productionItem.unload_qty == 0)
                //    {
                //        throw new Exception("จำนวนเบิกครบแล้ว ไม่สามารถเบิกเพิ่มได้!");
                //    }

                //    var receiveItem = db.receive_item.Where(p => p.product_code == productCode
                //                                               && p.lot_no == lotNo
                //                                               && p.chill_qty == 0)
                //                                               .OrderBy(p => p.seq).Take(1).SingleOrDefault();

                //    if (receiveItem == null)
                //    {
                //        lblLotNo.Text = "";
                //        throw new Exception("ไม่พบ Lot No นี้ในคลัง กรุณาเลือก Lot ใหม่!");
                //    }



                //    int seq = 0;
                //    string stock_no = "";

                //    var documentGenerate = (from p in db.document_generate where p.document_type == Constants.STK select p).SingleOrDefault();

                //    //check stock_item_running
                //    var stockItemRunning = db.stock_item_running.Where(p => p.doc_no.Equals(poNo)).SingleOrDefault();
                //    if (stockItemRunning == null)
                //    {
                //        //get new stock doc no

                //        stock_no = Constants.STK + documentGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                //        seq = 1;
                //    }
                //    else
                //    {

                //        stock_no = stockItemRunning.stock_no;
                //        seq = stockItemRunning.stock_item + 1;

                //    }




                //    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                //    {
                //        try
                //        {

                //            //update production order
                //            productionItem.unload_qty += 1;
                //            productionItem.unload_wgh += unloadWeight;
                //            productionItem.modified_at = DateTime.Now;
                //            productionItem.modified_by = Constants.CREATE_BY;
                //            db.Entry(productionItem).State = EntityState.Modified;


                //            //update receive item
                //            receiveItem.chill_qty = 1;
                //            receiveItem.chill_wgh = unloadWeight;
                //            receiveItem.modified_at = DateTime.Now;
                //            receiveItem.modified_by = Constants.CREATE_BY;
                //            db.Entry(receiveItem).State = EntityState.Modified;

                //            //insert stock
                //            var stock = new stock
                //            {
                //                stock_date = DateTime.Today,
                //                stock_no = stock_no,
                //                stock_item = seq,
                //                product_code = productionItem.product_code,
                //                stock_qty = productionItem.unload_qty,
                //                stock_wgh = productionItem.unload_wgh,
                //                ref_document_no = poNo,
                //                ref_document_type = Constants.PO,
                //                lot_no = lotNo,
                //                location_code = 2, //ห้องเย็นเก็บหมุซีก
                //                barcode_no = 0,
                //                transaction_type = 2,
                //                create_by = Constants.CREATE_BY
                //            };

                //            db.stocks.Add(stock);

                //            //รับหมูซีก เครื่องใน ไม่ต้อง update stock_item_running เพราะเริ่มตาม receive_item.seq

                //            if (stockItemRunning == null)
                //            {
                //                //insert stock_item_running
                //                var newStockItem = new stock_item_running
                //                {
                //                    doc_no = poNo,
                //                    stock_no = stock_no,
                //                    stock_item = 1,
                //                    create_by = Constants.CREATE_BY

                //                };

                //                db.stock_item_running.Add(newStockItem);
                //                //update document_generate
                //                documentGenerate.running += 1;
                //                db.Entry(documentGenerate).State = EntityState.Modified;


                //            }
                //            else
                //            {
                //                //update stock_item_running
                //                stockItemRunning.stock_item += 1;
                //                db.Entry(stockItemRunning).State = EntityState.Modified;
                //            }
                //            db.SaveChanges();
                //            transaction.Commit();
                //        }
                //        catch (Exception ex)
                //        {
                //            Console.WriteLine(ex.Message);
                //            transaction.Rollback();
                //            throw;
                //        }

                //    }

                //}

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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblOrderNo.Text))
                {
                    lblMessage.Text = "กรุณาเลือกข้อมูล!";
                    return;
                }
                //if (string.IsNullOrEmpty(lblLotNo.Text))
                //{
                //    lblMessage.Text = "กรุณาเลือก Lot No!";
                //    return;
                //}
                var ret = SaveData();
                if (ret)
                {
                    LoadData(lblOrderNo.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
    }
}
