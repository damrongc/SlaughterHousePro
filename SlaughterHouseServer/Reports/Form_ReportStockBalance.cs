using CrystalDecisions.CrystalReports.Engine;
using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Data;
using System.Windows.Forms;
namespace SlaughterHouseServer.Reports
{
    public partial class Form_ReportStockBalance : Form
    {
        public string invoiceNo { get; set; }

        public Form_ReportStockBalance()
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

        private void Form_Shown(object sender, System.EventArgs e)
        {

        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            FillProductGroup();
        }
        private void FillProductGroup()
        {
            var coll = ProductGroupController.GetAllProudctGroups();
            coll.Insert(0, new ProductGroup
            {
                ProductGroupCode = 0,
                ProductGroupName = "--ทั้งหมด--"
            });
            comboxProductGroup.ValueMember = "ProductGroupCode";
            comboxProductGroup.DisplayMember = "ProductGroupName";
            comboxProductGroup.DataSource = coll;
        }

        private void LoadReport()
        {
            ReportDocument doc = new ReportDocument();
            DataSet ds = ReportController.GetDataReportStockBalance(dtpInvoiceDate.Value);
            //string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Report"));

            //ds.WriteXml(path + @"\xml\stockbalance.xml", XmlWriteMode.WriteSchema);
            var reportPath = Application.StartupPath;
            doc.Load(reportPath + @"\Report\stockbalance.rpt");
            doc.SetDataSource(ds);

            rptViewer.ReportSource = doc;
            rptViewer.Zoom(100);
            rptViewer.RefreshReport();
        }

        private void comboxProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadProduct();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LoadProduct()
        {
            if (comboxProductGroup.SelectedIndex > 0)
            {

                var dtProduct = ProductController.GetProductActive(comboxProductGroup.SelectedValue.ToString(), "", "");

                cboProduct.ValueMember = "product_code";
                cboProduct.DisplayMember = "product_name";
                cboProduct.DataSource = dtProduct;
            }
            else
            {
                cboProduct.DataSource = null;
            }


        }
    }
}
