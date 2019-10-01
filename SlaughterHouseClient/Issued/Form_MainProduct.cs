
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ToastNotifications;

namespace SlaughterHouseClient.Issued
{
    public partial class Form_MainProduct : Form
    {

        public Form_MainProduct()
        {
            InitializeComponent();
            Shown += Form_Shown;

            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;

            txtBarcodeNo.KeyDown += TxtBarcodeNo_KeyDown;

        }

        private void TxtBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ProcessData();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            lblCurrentDatetime.Text = DateTime.Today.ToString("dd.MM.yyyy");
            lblMessage.Text = Constants.CHOOSE_QUEUE;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOrderNo_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new Form_Orders(string.Empty);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    lblOrderNo.Text = frm.OrderNo;
                    LoadOrder();
                    txtBarcodeNo.Text = "";
                    txtBarcodeNo.Focus();
                }
            }
            catch (Exception ex)
            {
                lblOrderNo.Text = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadOrder()
        {
            try
            {
                using (var db = new SlaughterhouseEntities())
                {
                    var order = db.orders.Find(lblOrderNo.Text);
                    lblOrderNo.Text = order.order_no;
                    lblCustomer.Text = order.customer.customer_name;

                    var coll = order.orders_item.AsEnumerable().Select(p => new
                    {
                        p.product.product_name,
                        p.order_qty,
                        p.order_wgh,
                        p.unload_qty,
                        p.unload_wgh
                    }).ToList();

                    gv.DataSource = coll;

                    gv.Columns[0].HeaderText = "สินค้า";
                    gv.Columns[1].HeaderText = "จำนวนสั่ง";
                    gv.Columns[2].HeaderText = "น้ำหนักสั่ง";
                    gv.Columns[3].HeaderText = "จำนวนจ่าย";
                    gv.Columns[4].HeaderText = "น้ำหนักจ่าย";

                    gv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void ProcessData()
        {
            try
            {
                if (string.IsNullOrEmpty(lblOrderNo.Text))
                {

                    throw new Exception("กรุณาเลือกเอกสาร SO!");
                }
                lblMessage.Text = Constants.PROCESSING;

                SaveData();

                var animationDirection = FormAnimator.AnimationDirection.Up;
                var animationMethod = FormAnimator.AnimationMethod.Slide;
                var toastNotification = new Notification("Success", "บันทึกข้อมูล เรียบร้อย.", 2, Color.Green, animationMethod, animationDirection);
                toastNotification.Show();

                LoadOrder();
                ClearDisplay();
            }
            catch (Exception ex)
            {
                ClearDisplay();
                var animationDirection = FormAnimator.AnimationDirection.Up;
                var animationMethod = FormAnimator.AnimationMethod.Slide;
                var toastNotification = new Notification("Error", ex.Message, 2, Color.Red, animationMethod, animationDirection);
                toastNotification.Show();
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool SaveData()
        {
            try
            {

                var orderNo = lblOrderNo.Text;
                //using (var db = new SlaughterhouseEntities())
                //{
                //    long barcodeNo = txtBarcodeNo.Text.ToLong();
                //    var barcode = db.barcodes.Find(barcodeNo);

                //    if (barcode == null)
                //    {

                //        throw new Exception("ไม่พบข้อมูลบาร์โค็ดนี้!");
                //    }
                //    lblProduct.Text = barcode.product.product_name;
                //    lblLotNo.Text = barcode.lot_no;

                //    //check stock
                //    int count = db.stocks.Where(p => p.ref_document_no.Equals(receiveItem.receive_no) && p.barcode_no.Equals(barcodeNo)).Count();
                //    if (count > 0)
                //    {

                //        throw new Exception("ไม่สามารถรับเข้าคลังได้ \rเนื่องจากบาร์โค็ดรับเข้าคลังแล้ว!");
                //    }


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

        private void ClearDisplay()
        {
            lblProduct.Text = "";
            lblLotNo.Text = "";
            txtBarcodeNo.Text = "";
            txtBarcodeNo.Focus();
        }

        //private bool CloseJob()
        //{
        //    try
        //    {
        //        var poNo = lblOrderNo.Text;
        //        using (var db = new SlaughterhouseEntities())
        //        {
        //            var productionOrder = db.production_order.Where(p => p.po_no == poNo).SingleOrDefault();
        //            productionOrder.po_flag = 1;
        //            db.SaveChanges();


        //        }

        //        lblOrderNo.Text = "";
        //        lblLotNo.Text = "";
        //        lblcus
        //        //lblProductionOrderQty.Text = 0.ToString();
        //        //lblRemainQty.Text = 0.ToString();
        //        //lblUnloadedQty.Text = 0.ToString();
        //        //lblUnloadedWgh.Text = 0m.ToFormat2Decimal();

        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        //private void btnAccept_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(lblOrderNo.Text))
        //        {
        //            lblMessage.Text = "กรุณาเลือกข้อมูล!";
        //            return;
        //        }
        //        if (string.IsNullOrEmpty(lblLotNo.Text))
        //        {
        //            lblMessage.Text = "กรุณาเลือก Lot No!";
        //            return;
        //        }
        //        var ret = SaveData();
        //        if (ret)
        //        {
        //            LoadOrder(lblOrderNo.Text);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        //    }
        //}

    }
}
