using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using ToastNotifications;

namespace SlaughterHouseClient.Receiving
{
    public partial class Form_ConfirmStock : Form
    {
        location locationSelected;

        private int Index;
        private int PAGE_SIZE = 15;
        List<Button> buttons;
        public Form_ConfirmStock(List<int> locations)
        {
            InitializeComponent();
            Shown += Form_ConfirmStock_Shown;
            txtBarcodeNo.KeyDown += TxtBarcodeNo_KeyDown;
            LoadLocation(locations);

        }

        private void TxtBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ProcessData();


        }

        private void Form_ConfirmStock_Shown(object sender, EventArgs e)
        {
            txtBarcodeNo.Focus();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                lblCurrentDatetime.Text = DateTime.Today.ToString("dd.MM.yyyy");
                lblMessage.Text = Constants.CHOOSE_WH;

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        private void LoadLocation(List<int> _locations)
        {
            using (var db = new SlaughterhouseEntities())
            {

                var locations = db.locations.Where(p => _locations.Contains(p.location_code)).ToList();

                flowLayoutPanel1.Controls.Clear();

                buttons = new List<Button>();
                foreach (var item in locations)
                {
                    var btn = new Button
                    {
                        Text = item.location_name,
                        Width = 150,
                        Height = 80,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Kanit", 14),
                        BackColor = Color.WhiteSmoke,
                        Tag = item.location_code
                    };

                    buttons.Add(btn);
                    btn.Click += Btn_Click;
                    DisplayPaging();
                }
            }

        }

        private void ProcessData()
        {
            try
            {
                if (locationSelected == null)
                {

                    throw new Exception("กรุณาเลือกคลังสินค้า!");
                }
                lblMessage.Text = Constants.PROCESSING;

                SaveData();

                var animationDirection = FormAnimator.AnimationDirection.Up;
                var animationMethod = FormAnimator.AnimationMethod.Slide;
                var toastNotification = new Notification("Success", "บันทึกข้อมูล เรียบร้อย.", 2, Color.Green, animationMethod, animationDirection);
                toastNotification.Show();

                lblLastProduct.Text = lblProduct.Text;
                lblLastLotNo.Text = lblLotNo.Text;
                lblLastBarcode.Text = txtBarcodeNo.Text;

                int totalQty = lblStockQty.Text.ToInt16();
                lblStockQty.Text = (totalQty + 1).ToString();

                double totalWeight = lblStockWgh.Text.ToDouble();
                double weight = lblWeight.Text.ToDouble();
                lblStockWgh.Text = (totalWeight + weight).ToFormat2Double();
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

        private void ClearDisplay()
        {
            lblProduct.Text = "";
            lblLotNo.Text = "";
            txtBarcodeNo.Text = "";
            txtBarcodeNo.Focus();
            lblWeight.Text = 0.0.ToFormat2Double();
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
            var locationCode = btn.Tag.ToString().ToInt16();
            using (var db = new SlaughterhouseEntities())
            {
                locationSelected = db.locations.Where(p => p.location_code == locationCode).SingleOrDefault();




                //var receiveItems = db.receive_item.Where(p => p.product_code.Equals(locationSelected.product_code)
                //&& p.receive_no.Equals(lblReceiveNo.Text)).ToList();

                //int stock_qty = 0;
                //decimal stock_wgh = 0;
                //foreach (var item in receiveItems)
                //{
                //    stock_qty += item.receive_qty;
                //    stock_wgh += item.receive_wgh;
                //}

                ////int remain_qty = lblSwineQty.Text.ToInt16() - stock_qty;
                //lblStockQty.Text = stock_qty.ToComma();
                //lblStockWgh.Text = stock_wgh.ToFormat2Decimal();

                lblMessage.Text = Constants.BARCODE_WAITING;
                txtBarcodeNo.Focus();

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool SaveData()
        {
            try
            {

                using (var db = new SlaughterhouseEntities())
                {
                    long barcodeNo = txtBarcodeNo.Text.ToLong();
                    var barcode = db.barcodes.Find(barcodeNo);

                    if (barcode == null)
                    {
                        throw new Exception("ไม่พบข้อมูลบาร์โค็ดนี้!");
                    }
                    lblWeight.Text = barcode.wgh.ToFormat2Decimal();
                    lblProduct.Text = barcode.product.product_name;
                    lblLotNo.Text = barcode.lot_no;

                    var receiveItem = db.receive_item.Where(p => p.barcode_no.Equals(barcodeNo)).FirstOrDefault();
                    if (receiveItem == null)
                    {

                        throw new Exception("ไม่พบข้อมูลบาร์โค็ดนี้!");
                    }

                    var stock = db.stocks.Where(p => p.barcode_no.Equals(barcodeNo)
                                        && p.transaction_type == 1).FirstOrDefault();
                    string stock_no = "";
                    int stock_item = 0;
                    //var documentGenerate = (from p in db.document_generate where p.document_type == Constants.STK select p).SingleOrDefault();
                    var documentGenerate = db.document_generate.Find(Constants.STK);
                    //check stock_item_running
                    var stockItemRunning = db.stock_item_running.Where(p => p.doc_no.Equals(stock.stock_no)).SingleOrDefault();
                    if (stockItemRunning == null)
                    {
                        //get new stock doc no
                        stock_no = Constants.STK + documentGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                        stock_item = 1;
                    }
                    else
                    {
                        stock_no = stockItemRunning.stock_no;
                        stock_item += 1;
                    }



                    ////check stock
                    //int count = db.stocks.Where(p => p.ref_document_no.Equals(receiveItem.receive_no) && p.barcode_no.Equals(barcodeNo)).Count();
                    //if (count > 0)
                    //{

                    //    throw new Exception("ไม่สามารถรับเข้าคลังได้ \rเนื่องจากบาร์โค็ดรับเข้าคลังแล้ว!");
                    //}
                    ////insert stock

                    //string stock_no = db.stock_item_running.Where(p => p.doc_no.Equals(receiveItem.receive_no)).Select(p => p.stock_no).SingleOrDefault();
                    var stocks = new List<stock>();

                    //add issued
                    stocks.Add(new stock
                    {
                        stock_date = DateTime.Today,
                        stock_no = stock_no,
                        stock_item = stock.stock_item,
                        product_code = stock.product_code,
                        stock_qty = stock.stock_qty,
                        stock_wgh = stock.stock_wgh,
                        ref_document_no = stock.stock_no,
                        ref_document_type = Constants.STK,
                        lot_no = stock.lot_no,
                        location_code = stock.location_code,
                        barcode_no = stock.barcode_no,
                        transaction_type = 2,
                        create_by = Helper.GetLocalIPAddress()
                    });

                    //add receive
                    stocks.Add(new stock
                    {
                        stock_date = DateTime.Today,
                        stock_no = stock_no,
                        stock_item = stock_item,
                        product_code = stock.product_code,
                        stock_qty = stock.stock_qty,
                        stock_wgh = stock.stock_wgh,
                        ref_document_no = stock.ref_document_no,
                        ref_document_type = stock.ref_document_type,
                        lot_no = stock.lot_no,
                        location_code = locationSelected.location_code,
                        barcode_no = stock.barcode_no,
                        transaction_type = 1,
                        create_by = Helper.GetLocalIPAddress()
                    });

                    //var newStock = new stock
                    //{
                    //    stock_date = DateTime.Today,
                    //    stock_no = stock_no,
                    //    stock_item = receiveItem.seq,
                    //    product_code = receiveItem.product_code,
                    //    stock_qty = receiveItem.receive_qty,
                    //    stock_wgh = receiveItem.receive_wgh,
                    //    ref_document_no = receiveItem.receive_no,
                    //    ref_document_type = Constants.REV,
                    //    lot_no = receiveItem.lot_no,
                    //    location_code = locationSelected.location_code,
                    //    barcode_no = receiveItem.barcode_no,
                    //    transaction_type = 1,
                    //    create_by = Helper.GetLocalIPAddress()
                    //};

                    if (stockItemRunning == null)
                    {
                        //insert stock_item_running
                        var newStockItem = new stock_item_running
                        {
                            doc_no = stock.stock_no,
                            stock_no = stock_no,
                            stock_item = 1,
                            create_by = Helper.GetLocalIPAddress()
                        };

                        db.stock_item_running.Add(newStockItem);

                        //update document_generate
                        documentGenerate.running += 1;
                        db.Entry(documentGenerate).State = System.Data.Entity.EntityState.Modified;


                    }
                    else
                    {
                        //update stock_item_running
                        stockItemRunning.stock_item += 1;
                        db.Entry(stockItemRunning).State = System.Data.Entity.EntityState.Modified;
                    }


                    db.stocks.AddRange(stocks);
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            if (Index > 0)
            {
                Index = Index - PAGE_SIZE;
                if (Index < 0)
                {
                    Index = 0;
                }
                DisplayPaging();
            }
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            if (Index < buttons.Count - 1)
            {
                Index = Index + PAGE_SIZE;
                if (Index > buttons.Count - 1)
                {
                    Index = buttons.Count - 1;
                }

            }
            DisplayPaging();
        }

        private void DisplayPaging()
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = Index; i <= (Index + PAGE_SIZE); i++)
            {
                if (i < buttons.Count)
                {
                    flowLayoutPanel1.Controls.Add(buttons[i]);
                }
            }
            flowLayoutPanel1.Visible = true;
            //btnPageUp.Enabled = (Index > 0);
            //btnPageDown.Enabled = ((Index + (PAGE_SIZE + 1)) <= (lables.Count - 1));
        }


    }
}
