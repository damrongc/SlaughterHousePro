using CrystalDecisions.CrystalReports.Engine;
using SlaughterHouseLib;
using System.Data;
using System.Windows.Forms;
namespace SlaughterHouseServer.Report
{
    public partial class Form_ProductSlipReport : Form
    {
        public string productSlipNo { get; set; }

        public Form_ProductSlipReport()
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
            LoadReport();
        }

        private void LoadReport()
        {

            ReportDocument doc = new ReportDocument();
            DataSet ds = ProductSlipController.GetDataPrintProductSlip(productSlipNo);
            //string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report"));
            //ds.WriteXml(path + @"\xml\productSlip.xml", XmlWriteMode.WriteSchema);

            var reportPath = Application.StartupPath;
            doc.Load(reportPath + @"\Report\productSlip.rpt");
            doc.SetDataSource(ds);

            rptViewer.ReportSource = doc;
            rptViewer.Zoom(100);
            rptViewer.RefreshReport();
        }
    }
}
;