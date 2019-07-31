using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;

namespace SlaughterHouseClient.Report
{
    public partial class Form_Barcode : Form
    {
        public Form_Barcode()
        {
            InitializeComponent();

            Load += Form_Load;
        }
        ReportDocument doc = new ReportDocument();


        private void Form_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("dtBarcode");
            dt.Columns.Add("BarcodeId");

            DataRow dr = dt.NewRow();
            dr["BarcodeId"] = Guid.NewGuid();

            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            //ds.WriteXml(string.Format(path, "barcode.xml"), XmlWriteMode.WriteSchema);
            doc.Load(@"D:\MyWork\โรงงานปราจีนบุรี PKP6\source\SlaughterHouseClient\Report\Rpt\barcode.rpt");
            doc.SetDataSource(ds);

            crystalReportViewer1.ReportSource = doc;
            crystalReportViewer1.Zoom(100);
            crystalReportViewer1.RefreshReport();
        }
    }
}
