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
            //ReportDocument doc = new ReportDocument();
            //DataSet ds = ProductSlipController.GetDataPrintProductSlip(productSlipNo); 
            //string path =  Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report"));
            //ds.WriteXml(path + @"\xml\productSlip.xml", XmlWriteMode.WriteSchema);
            //doc.Load(path + @"\productSlip.rpt");
            //doc.SetDataSource(ds);

            //rptViewer.ReportSource = doc;
            //rptViewer.Zoom(100);
            //rptViewer.RefreshReport();
        }
    }
}
;