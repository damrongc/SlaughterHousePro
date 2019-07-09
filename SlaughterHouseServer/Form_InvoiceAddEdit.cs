using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_InvoiceAddEdit : Form
    {
        public string orderNo { get; set; }
        public string invoiceNo { get; set; }
        DataTable dtInvoiceItem;

        public Form_InvoiceAddEdit()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            //btnAddOrderItem.Click += BtnAddOrderItem_Click;
            gv.CellContentClick += Gv_CellContentClick;
            gv.DataBindingComplete += Gv_DataBindingComplete;
            gv.ReadOnly = true;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;

            this.Load += Form_Load;
            this.Shown += Form_Shown;

            chkVatFlag.CheckedChanged += ChkVatFlag_CheckedChanged;

            //KeyDown  
            dtpInvoiceDate.KeyDown += DtpRequestDate_KeyDown;
            cboCustomer.KeyDown += CboCustomer_KeyDown;

            cboCustomer.Enabled = false;
            dtpInvoiceDate.Enabled = false;
            txtOrderNo.Enabled = false;
            txtInvoiceNo.Enabled = false;
            BtnSaveAndNew.Visible = false;
            txtGrossAmt.Enabled = false;
            txtBeforeVat.Enabled = false;
            txtVatAmt.Enabled = false;
            txtNetAmt.Enabled = false;

            txtVatAmt.Text = 0.ToString();
            txtVatRate.Text = 0.ToString();
            txtGrossAmt.Text = 0.ToString();
            txtBeforeVat.Text = 0.ToString();
            txtDiscount.Text = 0.ToString();
            txtNetAmt.Text = 0.ToString();
        }
        private void ChkVatFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVatFlag.Checked == true )
            {
                txtVatRate.Text = 7.ToString();
            }
            else
            {
                txtVatRate.Text = 0.ToString();
            }
        }
        private void Form_Shown(object sender, System.EventArgs e)
        {
            dtpInvoiceDate.Focus();
        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadCustomer(); 
            LoadData();
        }
        private void DtpRequestDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboCustomer.Focus();
            }
        }
        private void CboCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtComment.Focus();
            }
        } 
        #region Event Focus, KeyDown 
        private void TxtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSaveAndNew.Focus();
            }
        }
        private void TxtFarmName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtComment.Focus();
            }
        }
        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
        #endregion

#region Event Click
        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                SaveOrder();
                MessageBox.Show("บันทึกข้อมูล เรียบร้อยแล้ว", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BtnSaveAndNew_Click(object sender, System.EventArgs e)
        {
            try
            {
                SaveOrder();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                orderNo = "";
                txtInvoiceNo.Text = "";
                txtInvoiceNo.Focus();
                cboCustomer.SelectedIndex = 0;
                txtComment.Text = "";
                chkActive.Checked = true;
                LoadDetail();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void BtnAddOrderItem_Click(object sender, System.EventArgs e)
        //{
        //    var frm = new Form_OrderDetail();
            
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        DataRow dr;
        //        dr = dtOrderItem.NewRow();

        //        dr["seq"] = 0;
        //        dr["product_code"] = frm.productCode;
        //        dr["product_name"] = frm.productName;
        //        dr["order_qty"] = frm.qty;
        //        dr["order_wgh"] = frm.wgh;
        //        dtOrderItem.Rows.Add(dr);
        //        dtOrderItem.AcceptChanges();
        //    }
        //}
        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {

                        //case "Edit":
                        //    var frm = new Form_OrderDetail();
                        //    frm.orderNo = txtInvoiceNo.Text;
                        //    frm.productCode = dtOrderItem.Rows[e.RowIndex]["product_code"].ToString();
                        //    frm.qty = (int)dtOrderItem.Rows[e.RowIndex]["order_qty"];
                        //    frm.wgh = (decimal)dtOrderItem.Rows[e.RowIndex]["order_wgh"];
                        //    if (frm.ShowDialog() == DialogResult.OK)
                        //    {
                        //        dtOrderItem.Rows[e.RowIndex]["product_code"] = frm.productCode;
                        //        dtOrderItem.Rows[e.RowIndex]["product_name"] = frm.productName;
                        //        dtOrderItem.Rows[e.RowIndex]["order_qty"] = frm.qty;
                        //        dtOrderItem.Rows[e.RowIndex]["order_wgh"] = frm.wgh;
                        //        dtOrderItem.AcceptChanges();
                        //        gv.Refresh();
                        //    }
                        //    break;
                        //case "Del":
                        //    dtOrderItem.Rows[e.RowIndex].Delete();
                        //    dtOrderItem.AcceptChanges();
                        //    gv.Refresh(); 
                        //    break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
#endregion

        private void LoadData()
        {
            txtOrderNo .Text  = this.orderNo;
            if (String.IsNullOrEmpty(this.invoiceNo))
            {
                Order order = OrderController.GetOrder(this.orderNo);
                if (order != null)
                {
                    txtInvoiceNo.Text = "";
                    dtpInvoiceDate.Value = order.RequestDate;
                    cboCustomer.SelectedValue = order.Customer.CustomerCode;
                    txtComment.Text = "";
                    chkActive.Checked = order.Active; 
                }
            }
            else
            {
                Invoice invoice = InvoiceController.GetInvoice(this.orderNo);
                if (invoice != null)
                {
                    txtInvoiceNo.Text = invoice.InvoiceNo ;
                    dtpInvoiceDate.Value = invoice.InvoiceDate;
                    cboCustomer.SelectedValue = invoice.Customer.CustomerCode;
                    txtComment.Text = invoice.Comments;
                    chkActive.Checked = invoice.Active; 
                }
            }
            LoadDetail();
        }
        private void LoadDetail()
        {
            if (String.IsNullOrEmpty(this.invoiceNo))
            {
                dtInvoiceItem = new DataTable("INVOICE_ITEM");
                dtInvoiceItem = OrderItemController.GetOrderItemReadyToSell(this.orderNo);

                if (dtInvoiceItem.Rows.Count > 0)
                {
                    ProductPrice productPrice;
                    for (int i = 0; i < dtInvoiceItem.Rows.Count; i++)
                    {
                        productPrice = ProductPriceController.GetPriceList(dtInvoiceItem.Rows[i]["product_code"].ToString(), dtpInvoiceDate.Value);
                        dtInvoiceItem.Rows[i]["unit_price"] = productPrice.UnitPrice;
                        dtInvoiceItem.Rows[i]["sale_unit_method"] = productPrice.SaleUnitMethod;
                    }
                }
            }
            else
            {

            }
            gv.DataSource = dtInvoiceItem;
            gv.Columns[0].HeaderText = "ลำดับ";
            gv.Columns[1].HeaderText = "รหัสสินค้า";
            gv.Columns[2].HeaderText = "ชื่อสินค้า";
            gv.Columns[3].HeaderText = "หน่วยคำนวณ";
            gv.Columns[4].HeaderText = "ปริมาณ";
            gv.Columns[5].HeaderText = "น้้ำหนัก";
            gv.Columns[6].HeaderText = "ราคาต่อหน่วย";
            gv.Columns[7].HeaderText = "ราคา";

            gv.Columns[0].Visible = false;           
            gv.Columns[1].Visible = false;
        }
        private void LoadPriceList()
        {

        }

        private void LoadCustomer()
        {
            var coll = CustomerController.GetAllCustomers();
            cboCustomer.DisplayMember = "CustomerName";
            cboCustomer.ValueMember = "CustomerCode";
            cboCustomer.DataSource = coll;
        }
        private void SaveOrder()
        {
            try
            {
                var orderItems = new List<OrderItem>();
                int seq = 0; 

                var order = new Order
                {
                    OrderNo = txtInvoiceNo.Text,
                    RequestDate = dtpInvoiceDate.Value,
                    Customer = new Customer
                    {
                        CustomerCode = cboCustomer.SelectedValue.ToString()
                    },
                    Comments = txtComment.Text,
                    OrderFlag = 0,
                    Active = chkActive.Checked,
                    CreateBy = "system",
                    ModifiedBy = "system",
                    OrderItems = orderItems
                };

                if (string.IsNullOrEmpty(txtInvoiceNo.Text)) 
                {
                    OrderController.Insert(order);
                }
                else{
                    OrderController.Update (order);
                } 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
