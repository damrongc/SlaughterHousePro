
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ToastNotifications;

namespace SlaughterHouseClient.Issued
{
    public partial class Form_MainProduct : Form
    {

        FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;
        int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();


        public Form_MainProduct()
        {
            InitializeComponent();
            Load += Form_Load;

            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1C6BBC");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;

            txtBarcodeNo.KeyDown += TxtBarcodeNo_KeyDown;

        }

        private void Form_Load(object sender, EventArgs e)
        {
            using (var db = new SlaughterhouseEntities())
            {

                var plant = db.plants.Find(plantID);
                lblCurrentDatetime.Text = plant.production_date.ToString("dd-MM-yyyy");

                var trucks = db.trucks.Where(p => p.truck_type_id == 2 && p.active == true).Select(p => new
                {
                    p.truck_id,
                    p.truck_no,
                }).ToList();

                cboTruckNo.DisplayMember = "truck_no";
                cboTruckNo.ValueMember = "truck_id";
                cboTruckNo.DataSource = trucks;

                lblMessage.Text = Constants.CHOOSE_QUEUE;
                btnView.Enabled = false;
            }
        }

        private void TxtBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ProcessData();
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
                    btnView.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblOrderNo.Text = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private void SuggestMessage()
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(lblOrderNo.Text))
        //        {

        //        }
        //        if (string.IsNullOrEmpty(lblTruckNo.Text))
        //        {

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        private void LoadOrder()
        {
            try
            {
                using (var db = new SlaughterhouseEntities())
                {
                    var order = db.orders.Find(lblOrderNo.Text);
                    //lblOrderNo.Text = order.order_no;
                    lblCustomer.Text = order.customer.customer_name;
                    var transport = db.transports.Where(p => p.ref_document_no == order.order_no).SingleOrDefault();
                    if (transport != null)
                    {
                        cboTruckNo.SelectedValue = transport.truck_id;
                        lblMessage.Text = Constants.BARCODE_WAITING;
                    }
                    else
                    {
                        lblMessage.Text = Constants.CHOOSE_TRUCK;
                    }
                    txtBarcodeNo.Focus();

                    var coll = (from or in order.orders_item
                                join bom in db.boms on or.bom_code equals bom.bom_code
                                join p in db.products on bom.product_code equals p.product_code
                                select new
                                {
                                    or.seq,
                                    or.product.product_name,
                                    bom_name = p.product_name,
                                    or.order_qty,
                                    or.order_wgh,
                                    or.unload_qty,
                                    or.unload_wgh
                                }).OrderBy(p => p.seq).ToList();


                    gv.DataSource = coll;
                    gv.Columns[0].HeaderText = "ลำดับ";
                    gv.Columns[1].HeaderText = "สินค้า";
                    gv.Columns[2].HeaderText = "ชื่อชุด";
                    gv.Columns[3].HeaderText = "จำนวนสั่ง";
                    gv.Columns[4].HeaderText = "น้ำหนักสั่ง";
                    gv.Columns[5].HeaderText = "จำนวนจ่าย";
                    gv.Columns[6].HeaderText = "น้ำหนักจ่าย";

                    gv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                //if (string.IsNullOrEmpty(lblTruckNo.Text))
                //{

                //    throw new Exception("กรุณาเลือกทะเบียนรถ!");
                //}
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
                var createBy = Helper.GetLocalIPAddress();
                var orderNo = lblOrderNo.Text;
                var barcodeNo = txtBarcodeNo.Text.ToLong();
                var truckId = cboTruckNo.SelectedValue.ToString().ToInt16();

                string stockNo = "";
                int stockItem = 0;
                string transportNo = "";

                using (var db = new SlaughterhouseEntities())
                {
                    var barcode = db.barcodes.Find(barcodeNo);
                    if (barcode == null)
                    {
                        throw new Exception("ไม่พบข้อมูลบาร์โค็ดนี้!");
                    }
                    if (!barcode.active)
                    {
                        throw new Exception("ข้อมูลบาร์โค็ด ใช้งานแล้ว!");
                    }

                    var orderItems = db.orders_item.Where(p => p.order_no == orderNo
                                && p.product_code == barcode.product_code)
                        .OrderBy(p => p.seq).SingleOrDefault();

                    if (orderItems == null)
                    {
                        throw new Exception("ไม่พบสินค้า ในรายการจ่าย!");
                    }
                    if (orderItems.unload_qty >= orderItems.order_qty)
                    {
                        throw new Exception("จ่ายสินค้านี้ ครบแล้ว!");
                    }

                    var productionDate = db.plants.Find(plantID).production_date;
                    var transport = db.transports.Where(p => p.ref_document_no == orderNo).SingleOrDefault();


                    var transportGenrate = db.document_generate.Find(Constants.TP);
                    if (transport == null)
                    {
                        var stockGenerate = db.document_generate.Find(Constants.STK);
                        stockNo = Constants.STK + stockGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                        stockGenerate.running += 1;
                        db.Entry(stockGenerate).State = EntityState.Modified;
                        db.SaveChanges();
                        stockItem = 1;
                        transportNo = Constants.TP + transportGenrate.running.ToString().PadLeft(10 - Constants.TP.Length, '0');

                    }
                    else
                    {
                        transportNo = transport.transport_no;
                        var transportItem = db.transport_item.Where(p => p.transport_no == transport.transport_no).ToList();
                        if (transportItem.Count == 0)
                        {
                            var stockGenerate = db.document_generate.Find(Constants.STK);
                            stockNo = Constants.STK + stockGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                            stockGenerate.running += 1;
                            db.Entry(stockGenerate).State = EntityState.Modified;
                            db.SaveChanges();
                            transportNo = transport.transport_no;
                        }
                        else
                        {
                            stockNo = transportItem[0].stock_no;

                        }
                        stockItem = transportItem.Count + 1;
                        //if (transport.transport_item.Count == 0)
                        //{
                        //    stockNo = Constants.STK + stockGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                        //    transportNo = transport.transport_no;
                        //}
                        //else
                        //{
                        //    stockNo = transport.transport_item.Select(p => p.stock_no).First();

                        //}
                        //stockItem = transport.transport_item.Count() + 1;
                    }



                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {

                            //insert stock
                            var stock = new stock
                            {
                                stock_date = productionDate,
                                stock_no = stockNo,
                                stock_item = stockItem,
                                product_code = barcode.product_code,
                                stock_qty = barcode.qty,
                                stock_wgh = barcode.wgh,
                                ref_document_no = orderNo,
                                ref_document_type = Constants.SO,
                                lot_no = barcode.lot_no,
                                location_code = 0,
                                barcode_no = barcode.barcode_no,
                                transaction_type = 2,
                                create_by = createBy
                            };

                            db.stocks.Add(stock);

                            //insert transport
                            if (transport == null)
                            {

                                var trans = new transport
                                {
                                    transport_no = transportNo,
                                    transport_date = DateTime.Today,
                                    truck_id = truckId,
                                    ref_document_no = orderNo,
                                    transport_flag = 0,
                                    create_at = DateTime.Now,
                                    create_by = createBy


                                };
                                db.transports.Add(trans);

                                //update transport running

                                transportGenrate.running += 1;
                                db.Entry(transportGenrate).State = EntityState.Modified;
                            }

                            //insert transport item

                            var transItem = new transport_item
                            {
                                transport_no = transportNo,
                                product_code = barcode.product_code,
                                seq = stockItem,
                                transport_qty = barcode.qty,
                                transport_wgh = barcode.wgh,
                                stock_no = stockNo,
                                lot_no = barcode.lot_no,
                                truck_id = truckId,
                                barcode_no = barcode.barcode_no,
                                bom_code = orderItems.bom_code,
                                create_at = DateTime.Now,
                                create_by = createBy
                            };
                            db.transport_item.Add(transItem);

                            //var genDoc = db.document_generate.Find(Constants.STK);


                            //set barcode
                            barcode.active = false;
                            db.Entry(barcode).State = EntityState.Modified;

                            //set unload
                            orderItems.unload_qty += barcode.qty;
                            orderItems.unload_wgh += barcode.wgh;

                            orderItems.modified_by = createBy;
                            orderItems.modified_at = DateTime.Now;
                            db.Entry(orderItems).State = EntityState.Modified;


                            db.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
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

        private void btnView_Click(object sender, EventArgs e)
        {
            var frm = new Form_Transport
            {
                OrderNo = lblOrderNo.Text
            };
            frm.ShowDialog();
            LoadOrder();
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
