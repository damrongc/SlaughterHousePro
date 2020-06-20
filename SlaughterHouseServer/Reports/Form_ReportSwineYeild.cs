using CrystalDecisions.CrystalReports.Engine;
using SlaughterHouseLib;
using System;
using System.Data;
using System.Windows.Forms;
namespace SlaughterHouseServer.Reports
{
    public partial class Form_ReportSwineYeild : Form
    {
        public Form_ReportSwineYeild()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            BtnShowReport.Click += BtnShowReport_Click;
            rptViewer.ShowCloseButton = false;
            rptViewer.ShowCopyButton = false;
            rptViewer.ShowGroupTreeButton = false;
            rptViewer.ShowParameterPanelButton = false;
            rptViewer.ShowTextSearchButton = false;
            rptViewer.ShowLogo = false;
        }

        private void BtnShowReport_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReport()
        {
            ReportDocument doc = new ReportDocument();
            DataSet ds = ReportController.GetDataReportSwineYield(dtpReceiveDate.Value);
            //string xmlPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report\xml"));
            //ds.WriteXml(xmlPath + @"\swineyield.xml", XmlWriteMode.WriteSchema);

            var reportPath = Application.StartupPath;
            doc.Load(reportPath + @"\Report\swineyield.rpt");
            doc.SetDataSource(ds);

            rptViewer.ReportSource = doc;
            rptViewer.Zoom(100);
            rptViewer.RefreshReport();
        }
    }
}
