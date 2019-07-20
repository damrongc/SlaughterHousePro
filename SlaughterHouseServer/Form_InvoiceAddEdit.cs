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
            txtDiscount.TextChanged += TxtDiscount_TextChanged;
            txtVatRate.TextChanged += TxtVatRate_TextChanged;

            //KeyPress
            txtDiscount.KeyPress += TxtDiscount_KeyPress;
            txtVatRate.KeyPress += TxtVatRate_KeyPress;

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
            txtVatRate.Text = "";
            txtVatRate.Enabled = false;
            txtGrossAmt.Text = 0.ToString();
            txtBeforeVat.Text = 0.ToString();
            txtDiscount.Text = 0.ToString();
            txtNetAmt.Text = 0.ToString();
        }

        private void TxtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                if (e.KeyChar != 46)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void TxtVatRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (chkVatFlag.Checked == false)
            { 
                e.Handled = true;
                return; 
            }
        } 

        private void TxtVatRate_TextChanged(object sender, EventArgs e)
        { 
            try
            {
                Calculate_Total();
            }
            catch
            {

            }
        }

        private void TxtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calculate_Total();
            }
            catch
            {

            } 
        } 
        private void ChkVatFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVatFlag.Checked == true )
            {
                txtVatRate.Text = 7.ToString();
                txtVatRate.Enabled = true;
            }
            else
            {
                txtVatRate.Text = "";
                txtVatRate.Enabled = false;
            }
            Calculate_Total();
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
                SaveInvoice();
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
                SaveInvoice();
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
            txtOrderNo.Text  = this.orderNo;
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
                Invoice invoice = InvoiceController.GetInvoice(this.invoiceNo );
                if (invoice != null)
                {
                    txtInvoiceNo.Text = invoice.InvoiceNo ;
                    dtpInvoiceDate.Value = invoice.InvoiceDate;
                    txtOrderNo.Text = invoice.RefDocumentNo;
                    cboCustomer.SelectedValue = invoice.Customer.CustomerCode;
                    txtComment.Text = invoice.Comments;
                    chkActive.Checked = invoice.Active;
                    txtGrossAmt.Text = invoice.GrossAmt.ToString(); 
                    txtDiscount.Text = invoice.Discount.ToString();
                    txtBeforeVat.Text = (invoice.GrossAmt - invoice.Discount).ToString (); 
                    txtVatAmt.Text = invoice.VatAmt.ToString();
                    txtNetAmt.Text = invoice.NetAmt.ToString();
                    if (invoice.VatRate > 0)
                    {
                        chkVatFlag.Checked = true;
                        txtVatRate.Text = invoice.VatRate.ToString();
                    }
                    else
                    {
                        chkVatFlag.Checked = false;
                        txtVatRate.Text = "";
                    }
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
                    Product product;
                    for (int i = 0; i < dtInvoiceItem.Rows.Count; i++)
                    {
                        string productCode = dtInvoiceItem.Rows[i]["product_code"].ToString();
                        productPrice = ProductPriceController.GetPriceList(productCode, dtpInvoiceDate.Value);
                        product = ProductController.GetProduct(productCode);

                        dtInvoiceItem.Rows[i]["unit_price"] = productPrice.UnitPrice;
                        dtInvoiceItem.Rows[i]["sale_unit_method"] = product.SaleUnitMethod;
                        if (dtInvoiceItem.Rows[i]["sale_unit_method"].ToString() == "Q")
                        {
                            dtInvoiceItem.Rows[i]["gross_amt"] = Convert.ToDecimal(dtInvoiceItem.Rows[i]["unit_price"]) * Convert.ToDecimal(dtInvoiceItem.Rows[i]["qty"]);
                        }
                        else
                        {
                            dtInvoiceItem.Rows[i]["gross_amt"] = Convert.ToDecimal(dtInvoiceItem.Rows[i]["unit_price"]) * Convert.ToDecimal(dtInvoiceItem.Rows[i]["wgh"]);
                        }
                    }
                    dtInvoiceItem.AcceptChanges();
                    gv.Refresh();
                }
                Calculate_Total();
            }
            else
            {
                dtInvoiceItem = new DataTable("INVOICE_ITEM");
                dtInvoiceItem = InvoiceItemController.GetInvoiceItems(this.invoiceNo);
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
        private void Calculate_Total()
        {
            if (dtInvoiceItem != null && dtInvoiceItem.Rows.Count > 0)
            {
                decimal grossAmt = Convert.ToDecimal(dtInvoiceItem.Compute("Sum(gross_amt)", string.Empty));
                decimal discount = Convert.ToDecimal(txtDiscount.Text);
                decimal beforeVat = grossAmt - discount;

                decimal vatRate = 0;
                    if (chkVatFlag.Checked == true )
                {
                    vatRate = Convert.ToDecimal(txtVatRate.Text);

                }
                decimal vatAmt = (vatRate > 0) ? beforeVat * vatRate / 100 : 0;
                decimal netAmt = grossAmt - discount + vatAmt;

                txtGrossAmt.Text = grossAmt.ToString();
                txtDiscount.Text = discount.ToString();
                txtBeforeVat.Text = beforeVat.ToString();
                txtVatAmt.Text = vatAmt.ToString();
                txtNetAmt.Text = netAmt.ToString();
            }
            //for (int i = 0; i < dtInvoiceItem.Rows.Count; i++)
            //{
            //    grossAmt += Convert.ToDecimal(dtInvoiceItem.Rows[i]["gross_amt"]);
            //}
        }
        private void LoadCustomer()
        {
            var coll = CustomerController.GetAllCustomers();
            cboCustomer.DisplayMember = "CustomerName";
            cboCustomer.ValueMember = "CustomerCode";
            cboCustomer.DataSource = coll;
        }
        private void SaveInvoice()
        {
           
            try
            {
                if (Convert.ToDecimal(txtNetAmt.Text) <= 0)
                {
                    throw new Exception($"ราคาสุทธิต้องมีค่ามากกวว่า 0");
                }

                var invoiceItems = new List<InvoiceItem>();
                int seq = 0;
                foreach (DataRow row in dtInvoiceItem.Rows)
                { 
                    seq++;
                    invoiceItems.Add(new InvoiceItem
                    {
                        InvoiceNo = txtInvoiceNo.Text,
                        Seq = seq,
                        Product = new Product
                        {
                            ProductCode = row["product_code"].ToString(),
                            ProductName = row["product_name"].ToString(),
                        },
                        Qty = Convert.ToInt16(row["qty"]),
                        Wgh = Convert.ToDecimal(row["wgh"]),
                        UnitPrice  = Convert.ToDecimal(row["unit_price"]),
                        GrossAmt = Convert.ToDecimal(row["gross_amt"]),
                        SaleUnitMethod = row["sale_unit_method"].ToString(),
                    });

                    if (Convert.ToDecimal(row["unit_price"]) == 0)
                    {
                        throw new Exception($"สินค้า {row["product_name"].ToString()} ไม่มีการตั้งราคา");
                    }
                }

                var invoice = new Invoice
                {
                    InvoiceNo = txtInvoiceNo.Text,
                    InvoiceDate = dtpInvoiceDate.Value,
                    RefDocumentNo = txtOrderNo.Text,
                    Customer = new Customer
                    {
                        CustomerCode = cboCustomer.SelectedValue.ToString()
                    },
                    GrossAmt = Convert.ToDecimal(txtGrossAmt.Text),
                    Discount = Convert.ToDecimal(txtDiscount.Text), 
                    VatRate = (chkVatFlag.Checked == true) ? Convert.ToDecimal(txtVatRate.Text) : 0, 
                    VatAmt = Convert.ToDecimal(txtVatAmt.Text),
                    NetAmt = Convert.ToDecimal(txtNetAmt.Text),
                    Comments = txtComment.Text,
                    InvoiceFlag = 0,
                    Active = chkActive.Checked,
                    CreateBy = "system",
                    ModifiedBy = "system",
                    InvoiceItems = invoiceItems
                };

                if (string.IsNullOrEmpty(txtInvoiceNo.Text))
                {
                    InvoiceController.Insert(invoice);
                }
                else
                {
                    InvoiceController.Update(invoice);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
