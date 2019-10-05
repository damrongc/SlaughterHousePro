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
            dtpPeriodDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpPeriodDate.Enabled = false;
        }

        private void BtnClosePeriod_Click(object sender, System.EventArgs e)
        {
            try
            {
                int res = StockController.GenStockBf(dtpPeriodDate.Value);
                MessageBox.Show($"สร้างสต็อกยกมาเดือน {Convert.ToDateTime(dtpPeriodDate.Value).AddMonths(1).ToString(("MM/yyyy"))} ทั้งหมด {res} รายการ" , "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

            }

        }
    }
}