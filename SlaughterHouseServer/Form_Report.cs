﻿using SlaughterHouseLib;
using SlaughterHouseServer.Reports;
using System;
using System.Data;
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
            btnSwineReceive.Click += BtnSwineReceive_Click; ;
            btnSwineYield.Click += BtnSwineYield_Click;
            btnReportDailySales.Click += BtnReportDailySales_Click;
            btnReportStockMovement.Click += BtnReportStockMovement_Click;
            btnReportSoWithInv.Click += BtnReportSoWithInv_Click;
            btnStockBalance.Click += BtnStockBalance_Click;
        }

        private void BtnSwineYield_Click(object sender, EventArgs e)
        {

            var frm = new Form_ReportSwineYeild();
            frm.ShowDialog();
        }

        private void BtnSwineReceive_Click(object sender, EventArgs e)
        {
            var frm = new Form_ReportSwineReceiveByDate();
            frm.ShowDialog();
        }

        //private void BtnSwineYield_Click(object sender, EventArgs e)
        //{
        //    var frm = new Form_ReportSwineYeild();
        //    frm.ShowDialog();
        //}

        private void BtnStockBalance_Click(object sender, EventArgs e)
        {
            var frm = new Form_ReportStockBalance();

            frm.ShowDialog();
        }

        private void BtnReportSoWithInv_Click(object sender, EventArgs e)
        {
            var frm = new Form_ReportSoMapInv();

            frm.ShowDialog();
        }

        private void BtnReportStockMovement_Click(object sender, EventArgs e)
        {
            var frm = new Form_ReportStockMovement();

            frm.ShowDialog();
        }

        private void BtnReportDailySales_Click(object sender, EventArgs e)
        {
            var frm = new Form_ReportDailySales();

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