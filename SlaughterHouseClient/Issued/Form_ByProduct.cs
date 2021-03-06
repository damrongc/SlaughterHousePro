﻿using nucs.JsonSettings;
using SlaughterHouseClient.Receiving;
using SlaughterHouseEF;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ToastNotifications;
namespace SlaughterHouseClient.Issued
{
    public partial class Form_ByProduct : Form
    {
        readonly FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        readonly FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;
        private readonly SettingsBag MySettings = JsonSettings.Load<SettingsBag>("config.json");
        //const string PRODUCT_CODE = "00000";
        readonly int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
        private int displayTime = 3;
        private DateTime productionDate;
        public Form_ByProduct()
        {
            InitializeComponent();
            Load += Form_Load;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //gv.ColumnHeadersDefaultCellStyle.Font = new Font(Constants.FONT_FAMILY, Constants.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gv.DefaultCellStyle.Font = new Font(Constants.FONT_FAMILY, Constants.FONT_SIZE);
            gv.EnableHeadersVisualStyles = false;
            //gvTransport.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //gvTransport.ColumnHeadersDefaultCellStyle.Font = new Font(Constants.FONT_FAMILY, Constants.FONT_SIZE);
            //gvTransport.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            //gvTransport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //gvTransport.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gvTransport.DefaultCellStyle.Font = new Font(Constants.FONT_FAMILY, Constants.FONT_SIZE);
            //gvTransport.EnableHeadersVisualStyles = false;
            //gvTransport.CellContentClick += Gv_CellContentClick;
            txtBarcodeNo.KeyDown += TxtBarcodeNo_KeyDown;
        }
        //private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        DataGridView senderGrid = (DataGridView)sender;
        //        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
        //        {
        //            string barcode_no = gvTransport.Rows[e.RowIndex].Cells[0].Value.ToString();
        //            string orderNo = lblOrderNo.Text;
        //            if (MessageBox.Show($"ต้องการยกเลิก ข้อมูลบาร์โค็ด {barcode_no} Yes/No?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        //            {
        //                return;
        //            }
        //            using (var db = new SlaughterhouseEntities())
        //            {
        //                var barcode = db.barcodes.Find(barcode_no.ToLong());
        //                var productCode = barcode.product_code;
        //                var barcodeQty = barcode.qty;
        //                var barcodeWgh = barcode.wgh;
        //                var orderItem = db.orders_item.Where(p => p.product_code == productCode &&
        //                                                p.order_no == orderNo).SingleOrDefault();
        //                var transport = db.transports.Where(p => p.ref_document_no == orderNo).SingleOrDefault();
        //                var transportItems = db.transport_item.Where(p => p.transport_no == transport.transport_no &&
        //                                                p.product_code == productCode &&
        //                                                p.barcode_no == barcode.barcode_no).SingleOrDefault();
        //                var stockNo = transportItems.stock_no;
        //                var stockItem = transportItems.seq;
        //                var stock = db.stocks.Find(productionDate, stockNo, stockItem, productCode);
        //                using (DbContextTransaction transaction = db.Database.BeginTransaction())
        //                {
        //                    try
        //                    {
        //                        //delete stock
        //                        db.stocks.Remove(stock);
        //                        //delete transport item
        //                        db.transport_item.Remove(transportItems);
        //                        //update unload data at order item
        //                        orderItem.unload_qty -= barcodeQty;
        //                        orderItem.unload_wgh -= barcodeWgh;
        //                        db.Entry(orderItem).State = EntityState.Modified;
        //                        //update active at barcode
        //                        barcode.active = true;
        //                        db.Entry(barcode).State = EntityState.Modified;
        //                        db.SaveChanges();
        //                        transaction.Commit();
        //                        DisplayNotification("Success", "ยกเลิกข้อมูล เรียบร้อย.", Color.Green);
        //                        LoadOrder();
        //                    }
        //                    catch (Exception)
        //                    {
        //                        transaction.Rollback();
        //                        throw;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void Form_Load(object sender, EventArgs e)
        {
            LoadSetting();
            using (var db = new SlaughterhouseEntities())
            {
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
                lblMessage.Text = Constants.CHOOSE_QUEUE;
            }
        }
        void LoadSetting()
        {
            if (MySettings.Data.Count > 0)
            {
                displayTime = MySettings["DisplayTime"].ToString().ToInt16();
            }
        }
        private void DisplayNotification(string title, string message, Color color)
        {
            var toastNotification = new Notification(title, message, displayTime, color, animationMethod, animationDirection);
            toastNotification.Show();
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
                    lblProduct.Text = "";
                    lblLotNo.Text = "";
                    txtBarcodeNo.Text = "";
                    txtBarcodeNo.Focus();
                    lblMessage.Text = Constants.PLEASE_SCAN;
                }
            }
            catch (Exception ex)
            {
                lblOrderNo.Text = "";
                DisplayNotification("Error", ex.Message, Color.Red);
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
                    lblOrderDate.Text = order.order_date.ToString("dd-MM-yyyy");
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
                    //var coll = order.orders_item.Where(p => p.product_code != PRODUCT_CODE).AsEnumerable().Select(p => new
                    //{
                    //    p.product.product_name,
                    //    p.order_qty,
                    //    p.order_wgh,
                    //    p.unload_qty,
                    //    p.unload_wgh
                    //}).ToList();
                    //gv.DataSource = coll;
                    //gv.Columns[0].HeaderText = "สินค้า";
                    //gv.Columns[1].HeaderText = "จำนวนสั่ง";
                    //gv.Columns[2].HeaderText = "น้ำหนักสั่ง";
                    //gv.Columns[3].HeaderText = "จำนวนจ่าย";
                    //gv.Columns[4].HeaderText = "น้ำหนักจ่าย";
                    //gv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //gv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //gv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //gv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //var transport = db.transports.Where(p => p.ref_document_no == order.order_no).SingleOrDefault();
                    //if (transport != null)
                    //{
                    //    cboTruckNo.SelectedValue = transport.truck_id;
                    //    cboTruckNo.Enabled = false;
                    //    var transportItems = db.transport_item.Where(p => p.transport_no == transport.transport_no).ToList();
                    //    var collItem = transportItems.Select(p => new
                    //    {
                    //        p.barcode_no,
                    //        p.product.product_name,
                    //        p.transport_qty,
                    //        p.transport_wgh,
                    //        create_at = p.create_at.ToString("dd-MM-yyyy HH:mm")
                    //    }).OrderByDescending(p => p.create_at).ToList();
                    //    gvTransport.DataSource = collItem;
                    //    gvTransport.Columns[0].HeaderText = "รหัสบาร์โค็ด";
                    //    gvTransport.Columns[1].HeaderText = "สินค้า";
                    //    gvTransport.Columns[2].HeaderText = "จำนวน";
                    //    gvTransport.Columns[3].HeaderText = "น้ำหนัก";
                    //    gvTransport.Columns[4].HeaderText = "วันเวลาสแกน";
                    //    gvTransport.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //    gvTransport.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //}
                    var transport = db.transports.Where(p => p.ref_document_no == order.order_no).SingleOrDefault();
                    if (transport != null)
                    {
                        cboTruckNo.SelectedValue = transport.truck_id;
                        cboTruckNo.Enabled = false;
                    }
                    txtBarcodeNo.Focus();
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
                    throw new Exception("กรุณาเลือกใบสั่งขาย!");
                lblMessage.Text = Constants.PROCESSING;
                SaveData();
                DisplayNotification("Success", "บันทึกข้อมูล เรียบร้อย.", Color.Green);
                LoadOrder();
                ClearDisplay();
                lblMessage.Text = Constants.PLEASE_SCAN;
            }
            catch (Exception ex)
            {
                ClearDisplay();
                DisplayNotification("Error", ex.Message, Color.Red);
                lblMessage.Text = Constants.PLEASE_SCAN;
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
                int transportItem = 0;
                using (var db = new SlaughterhouseEntities())
                {
                    var barcode = db.barcodes.Find(barcodeNo);
                    if (barcode == null)
                    {
                        throw new Exception("ไม่พบข้อมูลบาร์โค็ดนี้! \rหรือจ่ายออกแล้ว");
                    }
                    //if (!barcode.active)
                    //{
                    //    throw new Exception("ข้อมูลบาร์โค็ด จ่ายออกแล้ว!");
                    //}
                    lblProduct.Text = barcode.product.product_name;
                    lblLotNo.Text = barcode.lot_no;
                    var orderItems = db.orders_item.Where(p => p.order_no == orderNo
                                && p.product_code == barcode.product_code)
                        .OrderBy(p => p.seq).SingleOrDefault();
                    if (orderItems == null)
                    {
                        throw new Exception("ไม่พบสินค้า ในรายการจ่าย!");
                    }
                    int remainQty = orderItems.order_qty - orderItems.unload_qty;
                    if (barcode.qty > remainQty)
                    {
                        throw new Exception("จำนวนสินค้าของบาร์โค็ดนี้ มากกว่า จำนวนสั่งซื้อคงเหลือ!");
                    }
                    if (remainQty == 0)
                    {
                        throw new Exception("จ่ายสินค้านี้ ครบแล้ว!");
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

                    var stockItemRunning = db.stock_item_running.Where(p => p.doc_no == orderNo).SingleOrDefault();
                    if (stockItemRunning == null)
                    {
                        //gen stock docno
                        stockNo = Helper.GetDocGenerator(Constants.STK);
                        stockItem = 1;
                    }
                    else
                    {
                        stockNo = stockItemRunning.stock_no;
                        stockItem = stockItemRunning.stock_item;
                    }

                    //var stockGenerate = db.document_generate.Find(Constants.STK);

                    //var transportGenrate = db.document_generate.Find(Constants.TP);
                    //if (transport == null)
                    //{
                    //    stockNo = Constants.STK + stockGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                    //    stockItem = 1;
                    //    transportNo = Constants.TP + transportGenrate.running.ToString().PadLeft(10 - Constants.TP.Length, '0');
                    //}
                    //else
                    //{
                    //    transportNo = transport.transport_no;
                    //    var transportItem = db.transport_item.Where(p => p.transport_no == transport.transport_no).ToList();
                    //    if (transportItem.Count == 0)
                    //    {
                    //        stockNo = Constants.STK + stockGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                    //    }
                    //    else
                    //    {
                    //        stockNo = transportItem[0].stock_no;
                    //    }
                    //    stockItem = transportItem.Count + 1;
                    //}

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
                                //transportGenrate.running += 1;
                                //db.Entry(transportGenrate).State = EntityState.Modified;
                            }
                            //insert transport item
                            var transItem = new transport_item
                            {
                                transport_no = transportNo,
                                product_code = barcode.product_code,
                                seq = transportItem,
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
                            //if (stockItem == 1)
                            //{
                            //    stockGenerate.running += 1;
                            //    db.Entry(stockGenerate).State = EntityState.Modified;
                            //}
                            //set barcode
                            db.barcodes.Remove(barcode);
                            //barcode.active = false;
                            //db.Entry(barcode).State = EntityState.Modified;
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
            txtBarcodeNo.Text = "";
            txtBarcodeNo.Focus();
        }
        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new Form_NumericPad();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtBarcodeNo.Text = frm.ReturnValue.ToString();
                    ProcessData();
                }
            }
            catch (Exception ex)
            {
                txtBarcodeNo.Text = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
