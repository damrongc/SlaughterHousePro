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
        //private string customerCode { get; set; }
        DataTable dtInvoiceItem;
        public Form_InvoiceAddEdit()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            //GridView
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
            txtDiscount.KeyDown += TxtDiscount_KeyDown;

            //Leave
            //txtDiscount.Leave  += TxtDiscount_Leave;

            cboCustomer.Enabled = false;
            dtpInvoiceDate.Enabled = false;
            txtOrderNo.Enabled = false;
            txtInvoiceNo.Enabled = false;
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

        #region Event Focus, KeyDown
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
            if (chkVatFlag.Checked == true)
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
        private void TxtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiscount.Text = string.Format("{0:#,##0.00}", double.Parse(txtDiscount.Text));
                BtnSave.Focus();
            }
        }
        //private void TxtDiscount_Leave(object sender, EventArgs e)
        //{
        //    //txtDiscount.Text = string.Format("{0:#,##0.00}", double.Parse(txtDiscount.Text));
        //}
        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gv.Columns[ConstColumns.SEQ].HeaderText = "ลำดับ";
            gv.Columns[ConstColumns.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gv.Columns[ConstColumns.PRODUCT_NAME].HeaderText = "ชื่อสินค้า";
            gv.Columns[ConstColumns.SALE_UNIT_METHOD].HeaderText = "หน่วยคำนวณ";
            gv.Columns[ConstColumns.QTY].HeaderText = "ปริมาณจ่าย";
            gv.Columns[ConstColumns.WGH].HeaderText = "น้ำหนักจ่าย";
            gv.Columns[ConstColumns.UNIT_PRICE].HeaderText = "ราคาต่อหน่วย";
            gv.Columns[ConstColumns.GROSS_AMT].HeaderText = "ราคา";

            gv.Columns[ConstColumns.SEQ].Visible = false;
            gv.Columns[ConstColumns.PRODUCT_CODE].Visible = false;

            gv.Columns[ConstColumns.UNIT_DISC].Visible = false;
            gv.Columns[ConstColumns.UNIT_NET].Visible = false;
            gv.Columns[ConstColumns.DISC_AMT].Visible = false;


            gv.Columns[ConstColumns.QTY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[ConstColumns.WGH].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[ConstColumns.UNIT_PRICE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[ConstColumns.GROSS_AMT].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gv.Columns[ConstColumns.QTY].DefaultCellStyle.Format = "N0";
            gv.Columns[ConstColumns.WGH].DefaultCellStyle.Format = "N2";
            gv.Columns[ConstColumns.UNIT_PRICE].DefaultCellStyle.Format = "N2";
            gv.Columns[ConstColumns.GROSS_AMT].DefaultCellStyle.Format = "N2";
        }
        #endregion

        #region Event Click
        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                SaveInvoice();
                PrintReport();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CancelInvoice();
                PrintReport();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #endregion

        #region Method Connect DB
        private void LoadData()
        {
            txtOrderNo.Text = this.orderNo;
            if (String.IsNullOrEmpty(this.invoiceNo))
            {
                Order order = OrderController.GetOrder(this.orderNo);
                if (order != null)
                {
                    txtInvoiceNo.Text = "";
                    dtpInvoiceDate.Value = order.RequestDate;
                    cboCustomer.SelectedValue = order.Customer.CustomerCode;
                    //customerCode = order.Customer.CustomerCode;
                    txtComment.Text = "";
                    chkActive.Checked = order.Active;
                }
                BtnCancel.Visible = false;
            }
            else
            {

                Invoice invoice = InvoiceController.GetInvoice(this.invoiceNo);
                if (invoice != null)
                {
                    txtInvoiceNo.Text = invoice.InvoiceNo;
                    dtpInvoiceDate.Value = invoice.InvoiceDate;
                    txtOrderNo.Text = invoice.RefDocumentNo;
                    cboCustomer.SelectedValue = invoice.Customer.CustomerCode;
                    txtComment.Text = invoice.Comments;
                    chkActive.Checked = invoice.Active;
                    txtGrossAmt.Text = invoice.GrossAmt.ToString();
                    txtDiscount.Text = invoice.DiscAmtBill.ToString();
                    txtBeforeVat.Text = (invoice.GrossAmt - invoice.DiscAmtBill).ToString();
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

                    chkActive.Enabled = false;
                    BtnSave.Enabled = false;
                    txtDiscount.Enabled = false;
                    chkVatFlag.Enabled = false;
                    txtVatRate.Enabled = false;
                    if (chkActive.Checked == false)
                    {
                        BtnCancel.Visible = false;
                        txtComment.Enabled = false;
                    }
                }
            }
            SetFormatNumberTextbox();
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
                    decimal unitPrice;
                    Product product;
                    for (int i = 0; i < dtInvoiceItem.Rows.Count; i++)
                    {
                        string productCode = dtInvoiceItem.Rows[i][ConstColumns.PRODUCT_CODE].ToString();
                        unitPrice = Globals.GetPriceList(cboCustomer.SelectedValue.ToString(), productCode, dtpInvoiceDate.Value);
                        product = ProductController.GetProduct(productCode);

                        dtInvoiceItem.Rows[i][ConstColumns.UNIT_PRICE] = unitPrice;
                        dtInvoiceItem.Rows[i][ConstColumns.SALE_UNIT_METHOD] = product.SaleUnitMethod;
                        if (dtInvoiceItem.Rows[i][ConstColumns.SALE_UNIT_METHOD].ToString() == "Q")
                        {
                            dtInvoiceItem.Rows[i][ConstColumns.GROSS_AMT] = Convert.ToDecimal(dtInvoiceItem.Rows[i][ConstColumns.UNIT_PRICE]) * Convert.ToDecimal(dtInvoiceItem.Rows[i][ConstColumns.QTY]);
                        }
                        else
                        {
                            dtInvoiceItem.Rows[i][ConstColumns.GROSS_AMT] = Convert.ToDecimal(dtInvoiceItem.Rows[i][ConstColumns.UNIT_PRICE]) * Convert.ToDecimal(dtInvoiceItem.Rows[i][ConstColumns.WGH]);
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
                CheckBeforeSave();

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
                            ProductCode = row[ConstColumns.PRODUCT_CODE].ToString(),
                            ProductName = row[ConstColumns.PRODUCT_NAME].ToString(),
                        },
                        Qty = Convert.ToInt16(row[ConstColumns.QTY]),
                        Wgh = Convert.ToDecimal(row[ConstColumns.WGH]),
                        UnitPrice = Convert.ToDecimal(row[ConstColumns.UNIT_PRICE]),
                        UnitDisc = Convert.ToDecimal(row[ConstColumns.UNIT_DISC]),
                        UnitNet = Convert.ToDecimal(row[ConstColumns.UNIT_NET]),
                        GrossAmt = Convert.ToDecimal(row[ConstColumns.GROSS_AMT]),
                        SaleUnitMethod = row[ConstColumns.SALE_UNIT_METHOD].ToString(),
                    });

                    if (Convert.ToDecimal(row[ConstColumns.UNIT_PRICE]) == 0)
                    {
                        throw new Exception($"สินค้า {row[ConstColumns.PRODUCT_NAME].ToString()} ไม่มีการตั้งราคา");
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
                    DiscAmt = 0,
                    DiscAmtBill = Convert.ToDecimal(txtDiscount.Text),
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
            catch (Exception ex)
            {
                throw;
            }
        }
        private void CancelInvoice()
        {
            try
            {
                if (String.IsNullOrEmpty(txtComment.Text))
                {
                    txtComment.Focus();
                    throw new Exception($"ถ้ายกเลิกเอกสาร กรุณาระบุเหตุผลที่ยกเลิก");
                }
                var invoice = new Invoice
                {
                    InvoiceNo = txtInvoiceNo.Text,
                    InvoiceDate = dtpInvoiceDate.Value,
                    RefDocumentNo = txtOrderNo.Text,
                    Comments = txtComment.Text,
                    Active = false,
                    ModifiedBy = "system"
                };

                InvoiceController.Cancel(invoice);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Method Other
        private void CheckBeforeSave()
        {
            try
            {
                if (String.IsNullOrEmpty(txtInvoiceNo.Text) == false)
                {
                    throw new Exception($"เอกสารใบแจ้งหนี้บันทึกแล้วไม่สามารถบันทึกซ้ำได้");
                }

                //Check UNIT_PRICE
                for (int i = 0; i < dtInvoiceItem.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dtInvoiceItem.Rows[i][ConstColumns.UNIT_PRICE]) == 0)
                    {
                        throw new Exception($"สินค้า {dtInvoiceItem.Rows[i][ConstColumns.PRODUCT_NAME]} ไม่มีราคาประกาศ");
                    }
                }

                //Check txtNetAmt
                if (Convert.ToDecimal(txtNetAmt.Text) <= 0)
                {
                    throw new Exception($"ราคาสุทธิต้องมีค่ามากกวว่า 0");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void Calculate_Total()
        {
            if (dtInvoiceItem != null && dtInvoiceItem.Rows.Count > 0)
            {
                decimal grossAmt = Convert.ToDecimal(dtInvoiceItem.Compute("Sum(gross_amt)", string.Empty));
                decimal discount = Convert.ToDecimal(txtDiscount.Text);
                decimal beforeVat = grossAmt - discount;

                decimal vatRate = 0;
                if (chkVatFlag.Checked == true)
                {
                    vatRate = Convert.ToDecimal(txtVatRate.Text);

                }
                decimal vatAmt = (vatRate > 0) ? beforeVat * vatRate / 100 : 0;
                decimal netAmt = grossAmt - discount + vatAmt;

                txtGrossAmt.Text = string.Format("{0:#,##0.00}", grossAmt);
                txtBeforeVat.Text = string.Format("{0:#,##0.00}", beforeVat);
                txtVatAmt.Text = string.Format("{0:#,##0.00}", vatAmt);
                txtNetAmt.Text = string.Format("{0:#,##0.00}", netAmt);

            }
        }
        private void SetFormatNumberTextbox()
        {
            txtGrossAmt.Text = string.Format("{0:#,##0.00}", double.Parse(txtGrossAmt.Text));
            txtDiscount.Text = string.Format("{0:#,##0.00}", double.Parse(txtDiscount.Text));
            txtBeforeVat.Text = string.Format("{0:#,##0.00}", double.Parse(txtBeforeVat.Text));
            txtVatAmt.Text = string.Format("{0:#,##0.00}", double.Parse(txtVatAmt.Text));
            txtNetAmt.Text = string.Format("{0:#,##0.00}", double.Parse(txtNetAmt.Text));

        }
        private void PrintReport()
        {
            try
            {
                var frmPrint = new Form_InvoiceReport();
                frmPrint.invoiceNo = (String.IsNullOrEmpty(txtInvoiceNo.Text)) ? InvoiceController.GetInvoiceNoByOrderNo(txtOrderNo.Text) : txtInvoiceNo.Text;

                frmPrint.ShowDialog();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                this.Close();
            }
        }

        #endregion


    }
}
