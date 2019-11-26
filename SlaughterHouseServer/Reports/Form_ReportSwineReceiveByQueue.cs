using CrystalDecisions.CrystalReports.Engine;
using SlaughterHouseLib;
using System;
using System.Data;
using System.Windows.Forms;
namespace SlaughterHouseServer.Reports
{
    public partial class Form_ReportSwineReceiveByQueue : Form
    {
        public string ReceiveNo { get; set; }

        public Form_ReportSwineReceiveByQueue()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            //BtnRefresh.Click += BtnRefresh_Click;
            this.Load += Form_Load;
            rptViewer.ShowCloseButton = false;
            rptViewer.ShowCopyButton = false;
            rptViewer.ShowGroupTreeButton = false;
            rptViewer.ShowParameterPanelButton = false;
            rptViewer.ShowTextSearchButton = false;
            rptViewer.ShowLogo = false;

        }



        private void Form_Load(object sender, System.EventArgs e)
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
            try
            {
                ReportDocument doc = new ReportDocument();
                DataSet ds = ReportController.GetDataReportSwineReceive(ReceiveNo);
                //string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report"));

                //ds.WriteXml(path + @"\xml\swinereceive.xml", XmlWriteMode.WriteSchema);
                //doc.Load(path + @"\swinereceive.rpt");

                var reportPath = Application.StartupPath;
                doc.Load(reportPath + @"\Report\swinereceive.rpt");
                doc.SetDataSource(ds);

                rptViewer.ReportSource = doc;
                rptViewer.Zoom(100);
                rptViewer.RefreshReport();
            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}
