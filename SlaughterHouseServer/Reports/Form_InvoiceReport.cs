using CrystalDecisions.CrystalReports.Engine;
using SlaughterHouseLib;
using System.Data;
using System.Windows.Forms;
namespace SlaughterHouseServer.Report
{
    public partial class Form_InvoiceReport : Form
    {
        public string invoiceNo { get; set; }
        public string orderNo { get; set; }

        public Form_InvoiceReport()
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

            rptViewerTransport.ShowCloseButton = false;
            rptViewerTransport.ShowCopyButton = false;
            rptViewerTransport.ShowGroupTreeButton = false;
            rptViewerTransport.ShowParameterPanelButton = false;
            rptViewerTransport.ShowTextSearchButton = false;
            rptViewerTransport.ShowLogo = false;

            crystalReportViewer1.ShowCloseButton = false;
            crystalReportViewer1.ShowCopyButton = false;
            crystalReportViewer1.ShowGroupTreeButton = false;
            crystalReportViewer1.ShowParameterPanelButton = false;
            crystalReportViewer1.ShowTextSearchButton = false;
            crystalReportViewer1.ShowLogo = false;

            tabControl1.TabPages.Remove(tabPage2);
        }

        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            ReportDocument doc = new ReportDocument();
            DataSet ds = InvoiceController.GetDataPrintInvoice(invoiceNo);
            //string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report"));
            //string reportName = "invoice";
            //doc.Load(path + @"\invoice.rpt");
            var reportPath = Application.StartupPath;
            //ds.WriteXml(reportPath + @"\invoice.xml", XmlWriteMode.WriteSchema);

            doc.Load(reportPath + @"\Report\invoice.rpt");
            doc.SetDataSource(ds);
            rptViewer.ReportSource = doc;
            rptViewer.Zoom(100);
            rptViewer.RefreshReport();



            ReportDocument docReceipt = new ReportDocument();
            docReceipt.Load(reportPath + @"\Report\receipt.rpt");
            docReceipt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = docReceipt;
            crystalReportViewer1.Zoom(100);
            crystalReportViewer1.RefreshReport();



            //ReportDocument docTrabsport = new ReportDocument();
            //DataSet dsTrabsport = InvoiceController.GetDataPrintTransport(orderNo);

            ////dsTrabsport.WriteXml(reportPath + @"\transport.xml", XmlWriteMode.WriteSchema);
            //docTrabsport.Load(reportPath + @"\Report\transport.rpt");
            //docTrabsport.SetDataSource(dsTrabsport);
            //rptViewerTransport.ReportSource = docTrabsport;
            //rptViewerTransport.Zoom(100);
            //rptViewerTransport.RefreshReport();
        }
    }
}
;