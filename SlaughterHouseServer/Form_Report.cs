using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_Report : Form
    {
        public Form_Report()
        {
            InitializeComponent();
            UserSettingsComponent();
        }

        private void UserSettingsComponent()
        {
            btnReportDailySales.Click += BtnReportDailySales_Click;
            btnReportStockMovement.Click += BtnReportStockMovement_Click;
            btnReportSoWithInv.Click += BtnReportSoWithInv_Click;
            btnStockBalance.Click += BtnStockBalance_Click;
        }

        private void BtnStockBalance_Click(object sender, EventArgs e)
        {
            var frm = new Form_Report_Stock_Balance
            {

            };
            frm.ShowDialog();
        }

        private void BtnReportSoWithInv_Click(object sender, EventArgs e)
        {
            var frm = new Form_Report_So_Map_Inv 
            {

            };
            frm.ShowDialog();
        }

        private void BtnReportStockMovement_Click(object sender, EventArgs e)
        {
            var frm = new Form_Report_Stock_Movement
            {

            };
            frm.ShowDialog();
        }

        private void BtnReportDailySales_Click(object sender, EventArgs e)
        {
            var frm = new Form_Report_Daily_Sales 
            { 

            };
            frm.ShowDialog();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            DataSet ds = ReportController.GetDataReceiveStickerBarcode(12349);
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report"));
            ds.WriteXml(path + @"\xml\receivebarcode.xml", XmlWriteMode.WriteSchema);
        }
    } 
}