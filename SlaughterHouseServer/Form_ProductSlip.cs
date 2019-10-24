using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using SlaughterHouseServer.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_ProductSlip : Form
    {
        public string orderNo { get; set; }
        //public string productSlipNo { get; set; }
        DataTable dtProductSlipItem;

        public Form_ProductSlip()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
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


            gvSo.DataBindingComplete += GvSo_DataBindingComplete;
            gvSo.ReadOnly = true;
            gvSo.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gvSo.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gvSo.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gvSo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gvSo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvSo.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gvSo.EnableHeadersVisualStyles = false;

            this.Load += Form_Load;
            this.Shown += Form_Shown;

            //KeyDown
            dtpProductSlipDate.KeyDown += DtpRequestDate_KeyDown;


        }
        private void Form_Shown(object sender, System.EventArgs e)
        {
            dtpProductSlipDate.Focus();
        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadCustomer();
            LoadData();
        }


        #region Event Focus, KeyDown, BindingComplete
        private void DtpRequestDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSave.Focus();
            }
        }
        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //gv.Columns[ConstColumns.SEQ ].HeaderText = "ลำดับ";
            gv.Columns[ConstColumns.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gv.Columns[ConstColumns.PRODUCT_NAME].HeaderText = "ชื่อสินค้า";
            gv.Columns[ConstColumns.QTY_WGH].HeaderText = "จำนวน";
            gv.Columns[ConstColumns.QTY_WGH_LOCATION].HeaderText = "จำนวน";
            gv.Columns[ConstColumns.LOT_NO].HeaderText = "Lot No.";
            //gv.Columns[ConstColumns.ISSUE_UNIT_METHOD].HeaderText = "หน่วยคำนวณ";
            //gv.Columns[ConstColumns.UNIT_CODE ].HeaderText = "รหัสหน่วยสินค้า";
            gv.Columns[ConstColumns.UNIT_NAME].HeaderText = "หน่วยสินค้า";
            gv.Columns[ConstColumns.LOCATION_CODE].HeaderText = "รหัสคลังสินค้า";
            gv.Columns[ConstColumns.LOCATION_NAME].HeaderText = "คลังสินค้า";

            //gv.Columns[ConstColumns.SEQ].Visible = false;
            gv.Columns[ConstColumns.PRODUCT_CODE].Visible = false;
            gv.Columns[ConstColumns.QTY_WGH].Visible = false;
            gv.Columns[ConstColumns.ISSUE_UNIT_METHOD].Visible = false;
            gv.Columns[ConstColumns.LOCATION_CODE].Visible = false;
        }
        private void GvSo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gvSo.Columns[ConstColumns.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gvSo.Columns[ConstColumns.PRODUCT_NAME].HeaderText = "ชื่อสินค้า";
            gvSo.Columns[ConstColumns.QTY].HeaderText = "ปริมาณ";
            gvSo.Columns[ConstColumns.WGH].HeaderText = "น้ำหนัก";
            gvSo.Columns[ConstColumns.UNIT_NAME_QTY].HeaderText = "หน่วยปริมาณ";
            gvSo.Columns[ConstColumns.UNIT_NAME_WGH].HeaderText = "หน่วยน้ำหนัก";
            gvSo.Columns[ConstColumns.PACKING_SIZE].HeaderText = "ขนาดบรรจุ";

            gvSo.Columns[ConstColumns.SEQ].Visible = false;
            gvSo.Columns[ConstColumns.ISSUE_UNIT_METHOD].Visible = false;
            gvSo.Columns[ConstColumns.PRODUCT_CODE].Visible = false;
            gvSo.Columns[ConstColumns.UNLOAD_QTY].Visible = false;
            gvSo.Columns[ConstColumns.UNLOAD_WGH].Visible = false;
            gvSo.Columns[ConstColumns.UNIT_CODE_QTY].Visible = false;
            gvSo.Columns[ConstColumns.UNIT_CODE_WGH].Visible = false;
            gvSo.Columns[ConstColumns.PACKING_SIZE].Visible = false;

        }
        #endregion

        #region Event Click
        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtProductSlipNo.Text))
                {
                    SaveProductSlip();
                }
                PrintReport();
                //MessageBox.Show("บันทึกข้อมูล เรียบร้อยแล้ว", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.DialogResult = DialogResult.OK;
                //this.Close();
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
                //SaveOrder();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                orderNo = "";
                txtProductSlipNo.Text = "";
                txtProductSlipNo.Focus();
                cboCustomer.SelectedIndex = 0;
                chkActive.Checked = true;
                LoadDetail();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CancelProductSlip();
                MessageBox.Show("ยกเลิกเอกสาร เรียบร้อยแล้ว", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
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

                        case "Edit":
                            //var frm = new Form_OrderDetail();
                            //frm.orderNo = txtProductSlip.Text;
                            //frm.orderDate = dtpProductSlipDate.Value;

                            //frm.productCode = dtOrderItem.Rows[e.RowIndex][ConstColumns.PRODUCT_CODE].ToString();
                            //frm.qtyWgh = Convert.ToDecimal(dtOrderItem.Rows[e.RowIndex][ConstColumns.QTY_WGH]);
                            //frm.issueUnitMethod = dtOrderItem.Rows[e.RowIndex][ConstColumns.ISSUE_UNIT_METHOD].ToString();
                            //frm.unitCode = Convert.ToInt16(dtOrderItem.Rows[e.RowIndex]["unit_code"]);
                            //frm.unitName = dtOrderItem.Rows[e.RowIndex]["unit_name"].ToString();
                            //if (frm.ShowDialog() == DialogResult.OK)
                            //{
                            //    dtOrderItem.Rows[e.RowIndex][ConstColumns.PRODUCT_CODE] = frm.productCode;
                            //    dtOrderItem.Rows[e.RowIndex]["product_name"] = frm.productName;
                            //    dtOrderItem.Rows[e.RowIndex][ConstColumns.QTY_WGH] = frm.qtyWgh;
                            //    dtOrderItem.Rows[e.RowIndex][ConstColumns.ISSUE_UNIT_METHOD] = frm.issueUnitMethod;
                            //    dtOrderItem.Rows[e.RowIndex]["unit_code"] = frm.unitCode;
                            //    dtOrderItem.Rows[e.RowIndex]["unit_name"] = frm.unitName;
                            //    dtOrderItem.AcceptChanges();
                            //    gv.Refresh();
                            //}
                            break;
                        case "Del":
                            //dtOrderItem.Rows[e.RowIndex].Delete();
                            //dtOrderItem.AcceptChanges();
                            //gv.Refresh();
                            break;
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
            txtProductSlipNo.Enabled = false;
            Order order = OrderController.GetOrder(this.orderNo);
            if (order != null)
            {
                txtProductSlipNo.Text = "";
                txtOrderNo.Text = order.OrderNo;
                dtpProductSlipDate.Value = order.RequestDate;
                cboCustomer.SelectedValue = order.Customer.CustomerCode;
                chkActive.Checked = order.Active;
                dtpProductSlipDate.Enabled = false;
            }
            else
            {
                BtnCancel.Visible = false;
            }

            ProductSlip productSlip = ProductSlipController.GetProductSlipByOrderNo(orderNo);
            if (productSlip != null)
            {
                txtProductSlipNo.Text = productSlip.ProductSlipNo;
            }
            else
            {
                BtnCancel.Visible = false;
            }

            LoadDetail();
        }
        private void LoadDetail()
        {
            DataTable dtOrdersIteemItem = new DataTable("ORDERS_ITEM");
            dtOrdersIteemItem = OrderItemController.GetOrderItems(orderNo, "N");
            gvSo.DataSource = dtOrdersIteemItem;
            gvSo.Columns[0].Visible = false;

            if (String.IsNullOrEmpty(txtProductSlipNo.Text))
            {
                dtProductSlipItem = new DataTable("PRODUCT_SLIP_ITEM");
                dtProductSlipItem = ProductSlipItemController.GetProductSlipItemByOrderNo(orderNo);
                gv.DataSource = dtProductSlipItem;
            }
            else
            {
                dtProductSlipItem = new DataTable("PRODUCT_SLIP_ITEM");
                dtProductSlipItem = ProductSlipItemController.GetProductSlipItem(txtProductSlipNo.Text);
                gv.DataSource = dtProductSlipItem;
            }


        }
        private void LoadCustomer()
        {
            var coll = CustomerController.GetAllCustomers();
            cboCustomer.DisplayMember = "CustomerName";
            cboCustomer.ValueMember = "CustomerCode";
            cboCustomer.DataSource = coll;
        }
        private void SaveProductSlip()
        {
            try
            {
                var productSlipItems = new List<ProductSlipItem>();
                int seq = 0;
                foreach (DataRow row in dtProductSlipItem.Rows)
                {
                    seq++;
                    var xx = new ProductSlipItem();


                    xx.ProductSlipNo = txtProductSlipNo.Text;
                    xx.Seq = seq;
                    xx.Product = new Product
                    {
                        ProductCode = row[ConstColumns.PRODUCT_CODE].ToString(),
                        ProductName = row[ConstColumns.PRODUCT_NAME].ToString(),
                    };
                    xx.Location = new Location
                    {
                        LocationCode = int.Parse(row[ConstColumns.LOCATION_CODE].ToString()),
                        LocationName = row[ConstColumns.LOCATION_NAME].ToString(),
                    };
                    xx.LotNo = row[ConstColumns.LOT_NO].ToString();
                    xx.Qty = row[ConstColumns.ISSUE_UNIT_METHOD].ToString() == "Q" ? Convert.ToInt16(row[ConstColumns.QTY_WGH_LOCATION]) : 0;
                    xx.Wgh = row[ConstColumns.ISSUE_UNIT_METHOD].ToString() == "W" ? Convert.ToDecimal(row[ConstColumns.QTY_WGH_LOCATION]) : 0;
                    productSlipItems.Add(xx);
                }
                var productSlip = new ProductSlip
                {
                    ProductSlipNo = txtProductSlipNo.Text,
                    ProductSlipDate = dtpProductSlipDate.Value,
                    RefDocumentNo = txtOrderNo.Text,
                    ProductSlipFlag = 0,
                    Active = chkActive.Checked,
                    CreateBy = "system",
                    ModifiedBy = "system",
                    ProductSlipItem = productSlipItems
                };

                if (string.IsNullOrEmpty(txtProductSlipNo.Text))
                {
                    txtProductSlipNo.Text = ProductSlipController.Insert(productSlip);
                }
                else
                {
                    ProductSlipController.Update(productSlip);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CancelProductSlip()
        {
            try
            {
                var productSlip = new ProductSlip
                {
                    ProductSlipNo = txtProductSlipNo.Text,
                    ProductSlipDate = dtpProductSlipDate.Value,
                    ProductSlipFlag = 0,
                    Active = false,
                    CreateBy = "system",
                    ModifiedBy = "system"
                };
                ProductSlipController.Cancel(productSlip);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void PrintReport()
        {
            try
            {
                var frmPrint = new Form_ProductSlipReport();
                frmPrint.productSlipNo = txtProductSlipNo.Text;

                frmPrint.ShowDialog();
                this.DialogResult = DialogResult.OK;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                this.Close();
            }
        }
    }
}
