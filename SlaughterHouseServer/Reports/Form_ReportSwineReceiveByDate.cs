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
    public partial class Form_ReportSwineReceiveByDate : Form
    {
        public Form_ReportSwineReceiveByDate()
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
            LoadReport();
        }

        private void LoadReport()
        {
            ReportDocument doc = new ReportDocument();
            DataSet ds = ReportController.GetDataReportSwineReceive(dtpReceiveDate.Value);
            string xmlPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report\xml"));


            ds.WriteXml(xmlPath + @"\swinereceive_by_date.xml", XmlWriteMode.WriteSchema);

            var reportPath = Application.StartupPath;
            //doc.Load(reportPath + @"\Report\swineyield.rpt");
            //doc.SetDataSource(ds);

            //rptViewer.ReportSource = doc;
            //rptViewer.Zoom(100);
            //rptViewer.RefreshReport();
        }
    }
}
