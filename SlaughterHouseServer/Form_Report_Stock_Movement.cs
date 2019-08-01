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
    public partial class Form_Report_Stock_Movement : Form
    {
        public string invoiceNo { get; set; } 
         
        public Form_Report_Stock_Movement()
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
            DataSet ds = ReportController.GetDataReportStockMovement(dtpInvoiceDateStr.Value, dtpInvoiceDateEnd.Value);
            string path =  Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report"));

            ds.WriteXml(path + @"\xml\stockmovement.xml", XmlWriteMode.WriteSchema);
            doc.Load(path + @"\stockmovement.rpt");
            doc.SetDataSource(ds);

            rptViewer.ReportSource = doc;
            rptViewer.Zoom(100);
            rptViewer.RefreshReport();
        } 
    }
}
 