using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using SlaughterHouseServer.Report;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_Invoice : Form
    {
        public Form_Invoice()
        {
            InitializeComponent();
            UserSettingsComponent();
        }

        private void UserSettingsComponent()
        {
            //BtnAdd.Click += BtnAdd_Click;
            BtnRefSo.Click += BtnRefSo_Click;
            BtnSearch.Click += BtnSearch_Click;
            gv.CellContentClick += Gv_CellContentClick;
            gv.DataBindingComplete += Gv_DataBindingComplete;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;

            gvDt.DataBindingComplete += GvDt_DataBindingComplete;
            gvDt.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gvDt.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gvDt.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gvDt.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gvDt.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvDt.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gvDt.EnableHeadersVisualStyles = false;

            LoadCustomer();
            LoadInvoice();
        }

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gv.Columns[ConstColumns.INVOICE_NO].HeaderText = "เลขที่ใบแจ้งหนี้";
            gv.Columns[ConstColumns.INVOICE_DATE].HeaderText = "วันที่แจ้งหนี้";
            gv.Columns[ConstColumns.REF_DOCUMENT_NO].HeaderText = "เลขที่ใบสั่งขาย";
            gv.Columns[ConstColumns.CUSTOMER_NAME].HeaderText = "ลูกค้า";
            gv.Columns[ConstColumns.TRUCK_NO].HeaderText = "ทะเบียนรถ";
            gv.Columns[ConstColumns.GROSS_AMT].HeaderText = "ราคา";
            gv.Columns[ConstColumns.DISC_AMT_BILL].HeaderText = "ส่วนลด";
            gv.Columns[ConstColumns.VAT_AMT].HeaderText = "ภาษี";
            gv.Columns[ConstColumns.NET_AMT].HeaderText = "ราคาสุทธิ";
            gv.Columns[ConstColumns.ACTIVE].HeaderText = "ใช้งาน";
            gv.Columns[ConstColumns.CREATE_AT].HeaderText = "วันเวลาสร้าง";

            gv.Columns[ConstColumns.GROSS_AMT].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[ConstColumns.DISC_AMT_BILL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[ConstColumns.VAT_AMT].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[ConstColumns.NET_AMT].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gv.Columns[ConstColumns.DISC_AMT].Visible = false; 



            gv.Columns[ConstColumns.GROSS_AMT].DefaultCellStyle.Format = "N2";
            gv.Columns[ConstColumns.DISC_AMT_BILL].DefaultCellStyle.Format = "N2";
            gv.Columns[ConstColumns.VAT_AMT].DefaultCellStyle.Format = "N2";
            gv.Columns[ConstColumns.NET_AMT].DefaultCellStyle.Format = "N2";
        }

        private void GvDt_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gvDt.Columns[ConstColumns.INVOICE_NO].HeaderText = "เลขที่ใบแจ้งหนี้";
            gvDt.Columns[ConstColumns.SEQ].HeaderText = "ลำดับ";
            gvDt.Columns[ConstColumns.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gvDt.Columns[ConstColumns.PRODUCT_NAME].HeaderText = "สินค้า";
            gvDt.Columns[ConstColumns.SALE_UNIT_METHOD].HeaderText = "หน่วยคำนวณ";
            gvDt.Columns[ConstColumns.QTY].HeaderText = "ปริมาณ";
            gvDt.Columns[ConstColumns.WGH].HeaderText = "น้ำหนัก";
            gvDt.Columns[ConstColumns.UNIT_PRICE].HeaderText = "ราคาต่อหน่วย";
            gvDt.Columns[ConstColumns.GROSS_AMT].HeaderText = "จำนวนเงิน";

            gvDt.Columns[ConstColumns.SEQ].Visible = false;

            gvDt.Columns[ConstColumns.QTY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[ConstColumns.WGH].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[ConstColumns.UNIT_PRICE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[ConstColumns.GROSS_AMT].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gvDt.Columns[ConstColumns.QTY].DefaultCellStyle.Format = "N0";
            gvDt.Columns[ConstColumns.WGH].DefaultCellStyle.Format = "N2";
            gvDt.Columns[ConstColumns.UNIT_PRICE].DefaultCellStyle.Format = "N2";
            gvDt.Columns[ConstColumns.GROSS_AMT].DefaultCellStyle.Format = "N2";
        }

        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                string invoiceNo = gv.Rows[e.RowIndex].Cells[ConstColumns.INVOICE_NO].Value.ToString();
                string orderNo = gv.Rows[e.RowIndex].Cells[ConstColumns.REF_DOCUMENT_NO ].Value.ToString();
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {
                        case "Edit":
                            var frm = new Form_InvoiceAddEdit
                            {
                                invoiceNo = invoiceNo
                            };
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                LoadInvoice();
                            }
                            break;
                        case "Print":
                            var frmPrint = new Form_InvoiceReport
                            {
                                invoiceNo = invoiceNo,
                                orderNo = orderNo
                            };
                            frmPrint.ShowDialog();
                            //if (frmPrint.ShowDialog() == DialogResult.OK)
                            //{
                            //    LoadInvoice();
                            //}
                            break;
                    }
                }
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
                {
                    LoadItem(invoiceNo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, System.EventArgs e)
        {
            LoadInvoice();
        }
         
        private void BtnRefSo_Click(object sender, System.EventArgs e)
        {
            var frmNew = new Form_InvoiceNew();
            frmNew.requestDate = dtpInvoiceDate.Value;
            if (frmNew.ShowDialog() == DialogResult.OK)
            {
                var frm = new Form_InvoiceAddEdit
                {
                    orderNo = frmNew.orderNo
                };
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadInvoice();
                }
            }
        }

        private void LoadCustomer()
        {
            var coll = CustomerController.GetAllCustomers();
            coll.Insert(0, new Customer
            {
                CustomerCode = "",
                CustomerName = "--ทั้งหมด--"
            });
            cboCustomer.DisplayMember = "CustomerName";
            cboCustomer.ValueMember = "CustomerCode";
            cboCustomer.DataSource = coll;
        }

        private void LoadInvoice()
        {
            //var farmCtrl = new FarmController();
            var coll = InvoiceController.GetAllInvoices(dtpInvoiceDate.Value, cboCustomer.SelectedValue.ToString());
            gv.DataSource = coll;

            LoadItem("");
        }
        private void LoadItem(string invoiceNo)
        {
            DataTable dtInvoiceItem = new DataTable("INVOICE_ITEM");
            dtInvoiceItem = InvoiceItemController.GetInvoiceItems(invoiceNo);

            gvDt.DataSource = dtInvoiceItem;
            gvDt.Visible = true;

        }

    }
}