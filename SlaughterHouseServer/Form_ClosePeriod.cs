using SlaughterHouseLib;
using SlaughterHouseServer.Reports;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_ClosePeriod : Form
    {
        public Form_ClosePeriod()
        {
            InitializeComponent();
            UserSettingsComponent();
        }

        private void UserSettingsComponent()
        {
            //gv.CellContentClick += Gv_CellContentClick;
             gv.DataBindingComplete += Gv_DataBindingComplete;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;

            btnClosePeriod.Click += BtnClosePeriod_Click;
            btnClosedDownPeriod.Click += BtnClosedDownPeriod_Click;
            //dtpPeriodDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpPeriodDate.Enabled = false;
            LoadProductionDate();
        }

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gv.Columns[ConstColumns.QTY].HeaderText = "ปริมาณ";
            gv.Columns[ConstColumns.WGH ].HeaderText = "น้ำหนัก";
            gv.Columns[ConstColumns.STOCK_NO].HeaderText = "เลขที่สต็อก";
            gv.Columns[ConstColumns.STOCK_ITEM].HeaderText = "ลำดับ";
            gv.Columns[ConstColumns.LOCATION_NAME].HeaderText = "คลังสินค้า";
            gv.Columns[ConstColumns.PRODUCT_CODE].HeaderText = "สินค้า";
            gv.Columns[ConstColumns.PRODUCT_NAME].HeaderText = "สินค้า";
            gv.Columns[ConstColumns.LOT_NO].HeaderText = "Lot No.";

            gv.Columns[ConstColumns.STOCK_DATE].Visible = false ;
            gv.Columns[ConstColumns.PRODUCT_CODE].Visible = false;

            gv.Columns[ConstColumns.QTY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[ConstColumns.WGH].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[ConstColumns.QTY].DefaultCellStyle.Format = "N0";
            gv.Columns[ConstColumns.WGH].DefaultCellStyle.Format = "N2";
        }

        private void LoadProductionDate()
        {
            try
            {
                DateTime res = (DateTime)StockController.GetProductionDate();
                dtpPeriodDate.Value = res;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error LoadProductionDate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                DataTable dt = StockController.GetStockBfOfDay(dtpPeriodDate.Value);
                gv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error LoadData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClosePeriod_Click(object sender, System.EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("ต้องการปิดวันใช่ไหม ?", "ยืนยัน ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int res = StockController.GenStockBfDay(dtpPeriodDate.Value);
                    LoadProductionDate();
                    MessageBox.Show($"สร้างสต็อกยกมาวัน {Convert.ToDateTime(dtpPeriodDate.Value).ToString(("dd/MM/yyyy"))} ทั้งหมด {res} รายการ",
                        "Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    btnClosePeriod.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnClosedDownPeriod_Click(object sender, System.EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("ต้องการถอยปิดวันใช่ไหม ?", "ยืนยัน ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int res = StockController.CancelStockBfDay(dtpPeriodDate.Value);
                    LoadProductionDate();
                    MessageBox.Show($"ถอยปิดวันเรียบร้อย",
                        "Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}