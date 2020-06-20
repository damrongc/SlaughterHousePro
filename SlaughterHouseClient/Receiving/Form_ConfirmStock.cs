using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using ToastNotifications;
using nucs.JsonSettings;
using System.Data.Entity;

namespace SlaughterHouseClient.Receiving
{
    public partial class Form_ConfirmStock : Form
    {
        private readonly SettingsBag MySettings = JsonSettings.Load<SettingsBag>("config.json");
        private readonly int plantID = System.Configuration.ConfigurationManager.AppSettings["plantID"].ToInt16();
        private DateTime productionDate;
        private int displayTime = 3;
        //readonly location locationSelected;
        private readonly List<int> _locations;
        private List<barcode> barcodes = new List<barcode>();
        private Timer timer = new Timer();
        //private int Index;
        //private readonly int PAGE_SIZE = 15;
        //List<Button> buttons;
        readonly FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
        readonly FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;
        private string modifiedBy = string.Empty;
        public Form_ConfirmStock(List<int> locations)
        {
            InitializeComponent();
            UserSettingsComponent();
            LoadSetting();
            Shown += Form_ConfirmStock_Shown;
            txtBarcodeNo.KeyDown += TxtBarcodeNo_KeyDown;
            _locations = locations;


            LoadLocation();

        }

        private void UserSettingsComponent()
        {
            //gv.CellContentClick += Gv_CellContentClick;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;



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
                using (var db = new SlaughterhouseEntities())
                {
                    var plant = db.plants.Find(plantID);
                    productionDate = plant.production_date;
                    lblCurrentDatetime.Text = productionDate.ToString("dd-MM-yyyy");
                }
                lblMessage.Text = Constants.PLEASE_SCAN;
                modifiedBy = Helper.GetLocalIPAddress();
                //timer.Interval = 1000;
                //timer.Enabled = true;
                //timer.Tick += Timer_Tick;


            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            txtBarcodeNo.Focus();
        }

        private void LoadLocation()
        {
            using (var db = new SlaughterhouseEntities())
            {

                var locations = db.locations.Where(p => _locations.Contains(p.location_code)).ToList();



                cboLocation.DisplayMember = "location_name";
                cboLocation.ValueMember = "location_code";
                cboLocation.DataSource = locations;

                //flowLayoutPanel1.Controls.Clear();

                //buttons = new List<Button>();
                //foreach (var item in locations)
                //{
                //    var btn = new Button
                //    {
                //        Text = item.location_name,
                //        Width = 150,
                //        Height = 80,
                //        FlatStyle = FlatStyle.Flat,
                //        Font = new Font("Kanit", 14),
                //        BackColor = Color.WhiteSmoke,
                //        Tag = item.location_code
                //    };

                //    buttons.Add(btn);
                //    btn.Click += Btn_Click;
                //    DisplayPaging();
                //}
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

        private void ProcessData()
        {
            try
            {
                //if (locationSelected == null)
                //{

                //    throw new Exception("กรุณาเลือกคลังสินค้า!");
                //}
                lblMessage.Text = Constants.PROCESSING;
                SaveData();
                DisplayNotification("Success", "บันทึกข้อมูล เรียบร้อย.", Color.Green);

                //lblLastProduct.Text = lblProduct.Text;
                //lblLastLotNo.Text = lblLotNo.Text;
                //lblLastBarcode.Text = txtBarcodeNo.Text;

                //int totalQty = lblStockQty.Text.ToInt16();
                //lblStockQty.Text = (totalQty + 1).ToString();

                //double totalWeight = lblStockWgh.Text.ToDouble();
                //double weight = lblWeight.Text.ToDouble();
                //lblStockWgh.Text = (totalWeight + weight).ToFormat2Double();

            }
            catch (Exception ex)
            {
                DisplayNotification("Error", ex.Message, Color.Red);
            }
            finally
            {
                ClearDisplay();
            }

        }

        private void ClearDisplay()
        {

            txtBarcodeNo.Text = "";
            txtBarcodeNo.Focus();

            lblMessage.Text = Constants.PLEASE_SCAN;
        }

        //private void Btn_Click(object sender, EventArgs e)
        //{


        //    foreach (Control ctrl in flowLayoutPanel1.Controls)
        //    {
        //        var b = (Button)ctrl;
        //        b.BackColor = Color.WhiteSmoke;
        //        b.ForeColor = Color.Black;
        //    }
        //    var btn = (Button)sender;
        //    btn.BackColor = ColorTranslator.FromHtml("#2D9CDB");
        //    btn.ForeColor = Color.White;
        //    var locationCode = btn.Tag.ToString().ToInt16();
        //    using (var db = new SlaughterhouseEntities())
        //    {
        //        locationSelected = db.locations.Where(p => p.location_code == locationCode).SingleOrDefault();




        //        //var receiveItems = db.receive_item.Where(p => p.product_code.Equals(locationSelected.product_code)
        //        //&& p.receive_no.Equals(lblReceiveNo.Text)).ToList();

        //        //int stock_qty = 0;
        //        //decimal stock_wgh = 0;
        //        //foreach (var item in receiveItems)
        //        //{
        //        //    stock_qty += item.receive_qty;
        //        //    stock_wgh += item.receive_wgh;
        //        //}

        //        ////int remain_qty = lblSwineQty.Text.ToInt16() - stock_qty;
        //        //lblStockQty.Text = stock_qty.ToComma();
        //        //lblStockWgh.Text = stock_wgh.ToFormat2Decimal();

        //        lblMessage.Text = Constants.BARCODE_WAITING;
        //        txtBarcodeNo.Focus();

        //    }

        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool SaveData()
        {
            try
            {


                //string stockNo = string.Empty;
                //int stockItem = 0;
                using (var db = new SlaughterhouseEntities())
                {
                    long barcodeNo = txtBarcodeNo.Text.ToLong();
                    var barcode = db.barcodes.Find(barcodeNo);

                    if (barcode == null)
                    {
                        throw new Exception("ไม่พบข้อมูลบาร์โค็ดนี้!");
                    }
                    if (barcode.active == false)
                    {
                        throw new Exception("ข้อมูลบาร์โค็ด จ่ายออกแล้ว!");
                    }

                    foreach (int locationCode in _locations)
                    {
                        if (barcode.location_code == locationCode)
                            throw new Exception("รหัสบาร์โค็ดนี้ รับเข้าคลังแล้ว!");
                    }


                    //lblWeight.Text = barcode.wgh.ToFormat2Decimal();
                    //lblProduct.Text = barcode.product.product_name;
                    //lblLotNo.Text = barcode.lot_no;

                    //Get Location เดิม
                    var stocks = db.stocks.Where(p => p.stock_date == productionDate
                        && p.product_code == barcode.product_code
                        && p.location_code == barcode.location_code
                        && p.barcode_no == barcode.barcode_no).ToList();

                    if (stocks.Count == 1)
                    {
                        //var stock = db.stocks.Where(p => p.stock_date == productionDate
                        //&& p.stock_no == stocks[0].stock_no
                        //&& p.stock_item == stocks[0].stock_item
                        //&& p.product_code == stocks[0].product_code).SingleOrDefault();

                        var stock = db.stocks.Find(productionDate, stocks[0].stock_no, stocks[0].stock_item, stocks[0].product_code);
                        using (DbContextTransaction transaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                //update stock location
                                stock.location_code = cboLocation.SelectedValue.ToString().ToInt16();
                                db.Entry(stock).State = System.Data.Entity.EntityState.Modified;

                                //update barcode location
                                barcode.location_code = cboLocation.SelectedValue.ToString().ToInt16();
                                barcode.modified_at = DateTime.Now;
                                barcode.modified_by = modifiedBy;
                                db.Entry(barcode).State = System.Data.Entity.EntityState.Modified;

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

                    barcodes.Add(barcode);

                    var coll = barcodes.Select(p => new
                    {
                        p.barcode_no,
                        p.product_code,
                        p.product.product_name,
                        p.lot_no,
                        qty = p.qty.ToComma(),
                        wgh = p.wgh.ToFormat2Decimal(),
                        modified_at = p.modified_at == null ? "" : Convert.ToDateTime(p.modified_at).ToString("dd-MM-yyyy HH:mm")
                    }).OrderByDescending(p => p.modified_at).ToList();

                    gv.DataSource = coll;
                    gv.Columns[0].HeaderText = "รหัส";
                    gv.Columns[1].HeaderText = "รหัสสินค้า";
                    gv.Columns[2].HeaderText = "ชื่อสินค้า";
                    gv.Columns[3].HeaderText = "Lot No.";
                    gv.Columns[4].HeaderText = "จำนวน";
                    gv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    gv.Columns[5].HeaderText = "น้ำหนัก";
                    gv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gv.Columns[6].HeaderText = "วันเวลาสแกน";

                    //if (stocks.Count == 0)
                    //{
                    //    var stockGenerate = db.document_generate.Find(Constants.STK);
                    //    stockNo = Constants.STK + stockGenerate.running.ToString().PadLeft(10 - Constants.STK.Length, '0');
                    //    stockItem = 1;

                    //    stockGenerate.running += 1;
                    //    db.Entry(stockGenerate).State = System.Data.Entity.EntityState.Modified;
                    //    db.SaveChanges();
                    //}
                    //else
                    //{
                    //    stockNo = stocks[0].stock_no;
                    //    stockItem = stocks.Count + 1;
                    //}




                    //var listOfStock = new List<stock>();
                    ////add issued
                    //listOfStock.Add(new stock
                    //{
                    //    stock_date = productionDate,
                    //    stock_no = stockNo,
                    //    stock_item = stockItem,
                    //    product_code = barcode.product_code,
                    //    stock_qty = barcode.qty,
                    //    stock_wgh = barcode.wgh,
                    //    //ref_document_no = stock.stock_no,
                    //    //ref_document_type = Constants.STK,
                    //    lot_no = barcode.lot_no,
                    //    location_code = (int)barcode.location_code,
                    //    barcode_no = barcode.barcode_no,
                    //    transaction_type = 2,
                    //    create_by = Helper.GetLocalIPAddress()
                    //});

                    ////add receive
                    //listOfStock.Add(new stock
                    //{
                    //    stock_date = DateTime.Today,
                    //    stock_no = stock_no,
                    //    stock_item = stock_item,
                    //    product_code = stock.product_code,
                    //    stock_qty = stock.stock_qty,
                    //    stock_wgh = stock.stock_wgh,
                    //    ref_document_no = stock.ref_document_no,
                    //    ref_document_type = stock.ref_document_type,
                    //    lot_no = stock.lot_no,
                    //    location_code = locationSelected.location_code,
                    //    barcode_no = stock.barcode_no,
                    //    transaction_type = 1,
                    //    create_by = Helper.GetLocalIPAddress()
                    //});



                    //db.stocks.AddRange(listOfStock);


                    return true;

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBarcodeNo.Focus();
        }

        //private void BtnUp_Click(object sender, EventArgs e)
        //{
        //    if (Index > 0)
        //    {
        //        Index = Index - PAGE_SIZE;
        //        if (Index < 0)
        //        {
        //            Index = 0;
        //        }
        //        DisplayPaging();
        //    }
        //}

        //private void BtnDown_Click(object sender, EventArgs e)
        //{
        //    if (Index < buttons.Count - 1)
        //    {
        //        Index = Index + PAGE_SIZE;
        //        if (Index > buttons.Count - 1)
        //        {
        //            Index = buttons.Count - 1;
        //        }

        //    }
        //    DisplayPaging();
        //}

        //private void DisplayPaging()
        //{
        //    flowLayoutPanel1.Controls.Clear();
        //    for (int i = Index; i <= (Index + PAGE_SIZE); i++)
        //    {
        //        if (i < buttons.Count)
        //        {
        //            flowLayoutPanel1.Controls.Add(buttons[i]);
        //        }
        //    }
        //    flowLayoutPanel1.Visible = true;
        //    //btnPageUp.Enabled = (Index > 0);
        //    //btnPageDown.Enabled = ((Index + (PAGE_SIZE + 1)) <= (lables.Count - 1));
        //}


    }
}
