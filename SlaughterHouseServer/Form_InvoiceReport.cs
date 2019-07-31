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
    public partial class Form_InvoiceReport : Form
    {
        public string invoiceNo { get; set; } 
         
        public Form_InvoiceReport()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            //BtnRefresh.Click += BtnRefresh_Click;
            this.Load += Form_Load;
            this.Shown += Form_Shown;
        }
        private void Form_Shown(object sender, System.EventArgs e)
        {
             
        }
        private void Form_Load(object sender, System.EventArgs e)
        { 
            LoadReport();
        }
         
        private void LoadReport()
        {
            ReportDocument doc = new ReportDocument();
            DataSet ds = InvoiceController.GetDataPrintInvoice(invoiceNo); 
            string path =  Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report\invoice")); 

            ds.WriteXml(path + ".xml", XmlWriteMode.WriteSchema);
            doc.Load(path + ".rpt");
            doc.SetDataSource(ds);

            rptViewer.ReportSource = doc;
            rptViewer.Zoom(100);
            rptViewer.RefreshReport();
        } 
    }
}
 