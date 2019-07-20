using SlaughterHouseLib;
using SlaughterHouseLib.Models;
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
              
        }

        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                string invoiceNo = gv.Rows[e.RowIndex].Cells[2].Value.ToString();
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
                                invoiceNo = invoiceNo
                            };
                            if (frmPrint.ShowDialog() == DialogResult.OK)
                            {
                                LoadInvoice();
                            }
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
        
        //private void BtnAdd_Click(object sender, System.EventArgs e)
        //{
        //    var frm = new Form_InvoiceAddEdit();
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        LoadInvoice();
        //    }
        //} 
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
                CustomerName = "--เลือก--"
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

            gv.Columns[2].HeaderText = "เลขที่ใบแจ้งหนี้";
            gv.Columns[3].HeaderText = "วันที่แจ้งหนี้";
            gv.Columns[4].HeaderText = "เลขที่ใบสั่งขาย";
            gv.Columns[5].HeaderText = "ลูกค้า";
            gv.Columns[6].HeaderText = "ราคา";
            gv.Columns[7].HeaderText = "ส่วนลด";
            gv.Columns[8].HeaderText = "ภาษี";
            gv.Columns[9].HeaderText = "ราคาสุทธิ";
            gv.Columns[10].HeaderText = "ใช้งาน";
            gv.Columns[11].HeaderText = "วันเวลาสร้าง";
            gv.Columns[12].HeaderText = "ผู้สร้าง";

            gv.Columns[10].Visible = false;
            LoadItem("");
        }
        private void LoadItem(string invoiceNo)
        {
            DataTable dtInvoiceItem = new DataTable("INVOICE_ITEM");
            dtInvoiceItem = InvoiceItemController.GetInvoiceItems(invoiceNo);

            gvDt.DataSource = dtInvoiceItem;
            gvDt.Columns[0].HeaderText = "ลำดับ";
            gvDt.Columns[1].HeaderText = "รหัสสินค้า";
            gvDt.Columns[2].HeaderText = "สินค้า";
            gvDt.Columns[3].HeaderText = "หน่วยคำนวณ";
            gvDt.Columns[4].HeaderText = "ปริมาณ";
            gvDt.Columns[5].HeaderText = "น้ำหนัก";
            gvDt.Columns[6].HeaderText = "ราคาต่อหน่วย"; 
            gvDt.Columns[7].HeaderText = "จำนวนเงิน";

            gvDt.Columns[1].Visible = false;
 
            gvDt.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
}