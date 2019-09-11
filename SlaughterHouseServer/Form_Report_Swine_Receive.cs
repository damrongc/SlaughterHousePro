using CrystalDecisions.CrystalReports.Engine;
using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_Report_Swine_Receive : Form
    {
        public string ReceiveNo { get; set; }

        public Form_Report_Swine_Receive()
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
            DataSet ds = ReportController.GetDataReportSwineReceiveHeader(ReceiveNo);
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report"));

            ds.WriteXml(path + @"\xml\swinereceive.xml", XmlWriteMode.WriteSchema);
            doc.Load(path + @"\swinereceive.rpt");
            doc.SetDataSource(ds);

            rptViewer.ReportSource = doc;
            rptViewer.Zoom(100);
            rptViewer.RefreshReport();
        }
    }
}
