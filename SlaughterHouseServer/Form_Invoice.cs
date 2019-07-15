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
            BtnAdd.Click += BtnAdd_Click;
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

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    string invoiceNo = gv.Rows[e.RowIndex].Cells[2].Value.ToString();

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
                            DataSet ds = InvoiceController.GetPrintInvoice(invoiceNo);
                            GetPrintInvoice
                            break;
                    } 
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
        
        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_InvoiceAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadInvoice();
            }
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
            gv.Columns[6].HeaderText = "ราคาสุทธิ";
            gv.Columns[7].HeaderText = "ใช้งาน";
            gv.Columns[8].HeaderText = "วันเวลาสร้าง";
            gv.Columns[9].HeaderText = "ผู้สร้าง";

            gv.Columns[7].Visible = false;
        }
 
    }
}