using SlaughterHouseLib;
using SlaughterHouseServer.Reports;
using System;
using System.Data;
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
            btnClosePeriod.Click += BtnClosePeriod_Click;
            //dtpPeriodDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpPeriodDate.Enabled = false;
            LoadProductionDate(); 
        }

        private void LoadProductionDate()
        {
            try
            {
                DateTime res = (DateTime)StockController.GetProductionDate();
                dtpPeriodDate.Value = res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error LoadProductionDate", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}