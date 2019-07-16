using CrystalDecisions.CrystalReports.Engine;
using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            DataSet ds = InvoiceController.GetPrintInvoice(invoiceNo);
            ds.WriteXml($"report/{invoiceNo}.xml", XmlWriteMode.WriteSchema); 

            //string path = "";
            //path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            //if (System.Diagnostics.Debugger.IsAttached)
            //{
            //    path = @"D:\MyWork\Backup\Softwares\RealPro Warehouse\realPRO_realWarehouse";
            //}

            //ds.WriteXml(path + @"\xml\barcode_product.xml", XmlWriteMode.WriteSchema);
            doc.Load("./report/invoice.rpt");
            doc.SetDataSource(ds);

            //CrystalReportCustomPaperSize("", "", ref doc);
            rptViewer.ReportSource = doc;
            rptViewer.Zoom(100);
            rptViewer.RefreshReport();
        } 
    }
}
 