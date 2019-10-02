using CrystalDecisions.CrystalReports.Engine;
using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
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
        }

        private void BtnShowReport_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            ReportDocument doc = new ReportDocument();
            DataSet ds = ReportController.GetDataReportSwineYield(dtpReceiveDate.Value);
            //string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report"));

            var reportPath = Application.StartupPath;
            //ds.WriteXml(reportPath + @"\Report\xml\swineyield.xml", XmlWriteMode.WriteSchema);


            doc.Load(reportPath + @"\Report\swineyield.rpt");


            doc.SetDataSource(ds);

            rptViewer.ReportSource = doc;
            rptViewer.Zoom(100);
            rptViewer.RefreshReport();
        }
    }
}
