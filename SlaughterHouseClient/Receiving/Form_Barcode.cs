using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseClient.Receiving
{
    public partial class Form_Barcode : Form
    {
        //int ReceiveFlag { get; set; }

        public string ProductCode { get; set; }
        ReportDocument doc = new ReportDocument();
        public Form_Barcode()
        {
            InitializeComponent();
            Load += Form_Load;

            //ReceiveFlag = _receiveFlag;

            UserSettingsComponent();

        }

        private void UserSettingsComponent()
        {
            gv.CellContentClick += Gv_CellContentClick;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;



        }

        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {

                    string barcode_no = gv.Rows[e.RowIndex].Cells[0].Value.ToString();


                    var reportPath = Application.StartupPath;
                    doc.Load(reportPath + "\\Report\\Rpt\\barcode.rpt");
                    DataTable dt = Helper.GetBarcode(barcode_no.ToLong());
                    doc.SetDataSource(dt);
                    doc.PrintToPrinter(1, true, 0, 0);



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            using (var db = new SlaughterhouseEntities())
            {
                var barcodes = db.barcodes.Where(p => p.active == true
                    && p.product_code == ProductCode).Select(p => new
                    {
                        p.barcode_no,
                        p.product.product_code,
                        p.product.product_name,
                        p.production_date,
                        p.lot_no,
                        p.qty,
                        p.wgh
                    }).OrderByDescending(p => p.barcode_no).ToList();
                //var qry = db.receives.Where(p => (p.farm_qty - p.factory_qty) > 0).ToList();
                var coll = barcodes.AsEnumerable().Select(p => new
                {
                    p.barcode_no,
                    p.product_code,
                    p.product_name,
                    production_date = p.production_date.ToString("dd-MM-yyyy"),
                    p.lot_no,
                    qty = p.qty.ToComma(),
                    wgh = p.wgh.ToFormat2Decimal()
                }).ToList();

                gv.DataSource = coll;

                gv.Columns[0].HeaderText = "รหัส";
                gv.Columns[1].HeaderText = "รหัสสินค้า";
                gv.Columns[2].HeaderText = "ชื่อสินค้า";
                gv.Columns[3].HeaderText = "วันที่ผลิต";
                gv.Columns[4].HeaderText = "Lot No.";

                gv.Columns[5].HeaderText = "จำนวน";
                gv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                gv.Columns[6].HeaderText = "น้ำหนัก";
                gv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
