﻿using CrystalDecisions.CrystalReports.Engine;
using SlaughterHouseLib;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_Report_Daily_Sales : Form
    {
        public string invoiceNo { get; set; }

        public Form_Report_Daily_Sales()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            //BtnRefresh.Click += BtnRefresh_Click;
            this.Load += Form_Load;
            this.Shown += Form_Shown;

            this.BtnShowReport.Click += BtnShowReport_Click;
        }

        private void BtnShowReport_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void Form_Shown(object sender, System.EventArgs e)
        {

        }
        private void Form_Load(object sender, System.EventArgs e)
        {

        }

        private void LoadReport()
        {
            ReportDocument doc = new ReportDocument();
            DataSet ds = ReportController.GetDataReportDailySales(dtpInvoiceDateStr.Value, dtpInvoiceDateEnd.Value);
            string pathRpt = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report\rpt\dailysales"));
            string pathXml = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report\xml\dailysales"));
            ds.DataSetName = "NewDataSet";
            ds.Tables[0].TableName = "Table";
            ds.WriteXml(pathXml + ".xml", XmlWriteMode.WriteSchema);
            doc.Load(pathRpt + ".rpt");
            doc.SetDataSource(ds);

            rptViewer.ReportSource = doc;
            rptViewer.Zoom(100);
            rptViewer.RefreshReport();
        }
    }
}
