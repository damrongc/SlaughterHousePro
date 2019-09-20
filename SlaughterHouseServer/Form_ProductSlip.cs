using SlaughterHouseLib;
using SlaughterHouseLib.Models;
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
        private void DtpRequestDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSave.Focus();
            }
        }
       
        #region Event Focus, KeyDown 
        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //gv.Columns[GlobalsColumn.SEQ ].HeaderText = "ลำดับ";
            gv.Columns[GlobalsColumn.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gv.Columns[GlobalsColumn.PRODUCT_NAME ].HeaderText = "ชื่อสินค้า";
            gv.Columns[GlobalsColumn.QTY_WGH].HeaderText = "จำนวน";
            gv.Columns[GlobalsColumn.QTY_WGH_LOCATION].HeaderText = "จำนวน";
            //gv.Columns[GlobalsColumn.ISSUE_UNIT_METHOD].HeaderText = "หน่วยคำนวณ";
            //gv.Columns[GlobalsColumn.UNIT_CODE ].HeaderText = "รหัสหน่วยสินค้า";
            gv.Columns[GlobalsColumn.UNIT_NAME ].HeaderText = "หน่วยสินค้า";
            gv.Columns[GlobalsColumn.LOCATION_CODE  ].HeaderText = "รหัสคลังสินค้า";
            gv.Columns[GlobalsColumn.LOCATION_NAME ].HeaderText = "คลังสินค้า";

            gv.Columns[GlobalsColumn.PRODUCT_CODE].Visible = false;
            gv.Columns[GlobalsColumn.QTY_WGH].Visible = false;
            gv.Columns[GlobalsColumn.ISSUE_UNIT_METHOD].Visible = false;
            gv.Columns[GlobalsColumn.LOCATION_CODE].Visible = false;
        }
        private void GvSo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gvSo.Columns[GlobalsColumn.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gvSo.Columns[GlobalsColumn.PRODUCT_NAME].HeaderText = "ชื่อสินค้า";
            gvSo.Columns[GlobalsColumn.QTY_WGH].HeaderText = "จำนวน";
            gvSo.Columns[GlobalsColumn.UNIT_NAME].HeaderText = "หน่วยสินค้า";

            gvSo.Columns[GlobalsColumn.SEQ].Visible = false;
            gvSo.Columns[GlobalsColumn.ISSUE_UNIT_METHOD].Visible = false;
            gvSo.Columns[GlobalsColumn.PRODUCT_CODE].Visible = false; 
            gvSo.Columns[GlobalsColumn.UNLOAD_QTY].Visible = false;
            gvSo.Columns[GlobalsColumn.UNLOAD_WGH].Visible = false;
            gvSo.Columns[GlobalsColumn.UNIT_CODE].Visible = false;
        }
            #endregion

            #region Event Click
            private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                //SaveOrder();
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
                //SaveOrder();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                orderNo = "";
                txtProductSlip.Text = "";
                txtProductSlip.Focus();
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
                //CancelOrder();
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

                            //frm.productCode = dtOrderItem.Rows[e.RowIndex][GlobalsColumn.PRODUCT_CODE].ToString();
                            //frm.qtyWgh = Convert.ToDecimal(dtOrderItem.Rows[e.RowIndex][GlobalsColumn.QTY_WGH]);
                            //frm.issueUnitMethod = dtOrderItem.Rows[e.RowIndex][GlobalsColumn.ISSUE_UNIT_METHOD].ToString();
                            //frm.unitCode = Convert.ToInt16(dtOrderItem.Rows[e.RowIndex]["unit_code"]);
                            //frm.unitName = dtOrderItem.Rows[e.RowIndex]["unit_name"].ToString();
                            //if (frm.ShowDialog() == DialogResult.OK)
                            //{
                            //    dtOrderItem.Rows[e.RowIndex][GlobalsColumn.PRODUCT_CODE] = frm.productCode;
                            //    dtOrderItem.Rows[e.RowIndex]["product_name"] = frm.productName;
                            //    dtOrderItem.Rows[e.RowIndex][GlobalsColumn.QTY_WGH] = frm.qtyWgh;
                            //    dtOrderItem.Rows[e.RowIndex][GlobalsColumn.ISSUE_UNIT_METHOD] = frm.issueUnitMethod;
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
            txtProductSlip.Enabled = false;
            Order order = OrderController.GetOrder(this.orderNo);
            if (order != null)
            {
                txtProductSlip.Text = "";
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
            LoadDetail();
        }
        private void LoadDetail()
        {
            dtProductSlipItem = new DataTable("PRODUCT_SLIP_ITEM");
            dtProductSlipItem = ProductSlipItemController.GetProductSlipItem(orderNo);
            gv.DataSource = dtProductSlipItem;


            DataTable dtOrdersIteemItem = new DataTable("ORDERS_ITEM");
            dtOrdersIteemItem = OrderItemController.GetOrderItems(orderNo, "N");
            gvSo.DataSource = dtOrdersIteemItem;

        }
        private void LoadCustomer()
        {
            var coll = CustomerController.GetAllCustomers();
            cboCustomer.DisplayMember = "CustomerName";
            cboCustomer.ValueMember = "CustomerCode";
            cboCustomer.DataSource = coll;
        }
        //private void SaveOrder()
        //{
        //    try
        //    {
        //        var orderItems = new List<OrderItem>();
        //        int seq = 0;
        //        foreach (DataRow row in dtOrderItem.Rows)
        //        {
        //            DataTable dtBom = BomController.GetBom(row[GlobalsColumn.PRODUCT_CODE].ToString());

        //            if (dtBom.Rows.Count > 0)
        //            {
        //                foreach (DataRow dtRow in dtBom.Rows)
        //                {
        //                    seq++;
        //                    orderItems.Add(new OrderItem
        //                    {
        //                        OrderNo = txtProductSlip.Text,
        //                        Seq = seq,
        //                        Product = new Product
        //                        {
        //                            ProductCode = dtRow[GlobalsColumn.PRODUCT_CODE].ToString(),
        //                            ProductName = "",
        //                        },
        //                        BomCode = (int)dtRow[GlobalsColumn.BOM_CODE ],
        //                        OrderSetQty = row[GlobalsColumn.ISSUE_UNIT_METHOD].ToString() == "Q" ? Convert.ToInt16(row[GlobalsColumn.QTY_WGH]) : 0,
        //                        OrderSetWgh = row[GlobalsColumn.ISSUE_UNIT_METHOD].ToString() == "W" ? Convert.ToDecimal(row[GlobalsColumn.QTY_WGH]) : 0,
        //                        OrderQty = row[GlobalsColumn.ISSUE_UNIT_METHOD].ToString() == "Q" ? Convert.ToInt16(row[GlobalsColumn.QTY_WGH]) * Convert.ToInt16(dtRow[GlobalsColumn.MUTIPLY_QTY]) : 0,
        //                        OrderWgh = row[GlobalsColumn.ISSUE_UNIT_METHOD].ToString() == "W" ? Convert.ToDecimal(row[GlobalsColumn.QTY_WGH]) * Convert.ToDecimal(dtRow[GlobalsColumn.MUTIPLY_WGH]) : 0,
        //                    });
        //                }
        //            }
        //            else
        //            {
        //                seq++;
        //                orderItems.Add(new OrderItem
        //                {
        //                    OrderNo = txtProductSlip.Text,
        //                    Seq = seq,
        //                    Product = new Product
        //                    {
        //                        ProductCode = row[GlobalsColumn.PRODUCT_CODE].ToString(),
        //                        ProductName = row[GlobalsColumn.PRODUCT_NAME].ToString(),
        //                    },
        //                    BomCode = 0,
        //                    OrderSetQty = 0,
        //                    OrderSetWgh = 0,
        //                    OrderQty = row[GlobalsColumn.ISSUE_UNIT_METHOD].ToString() == "Q" ? Convert.ToInt16(row[GlobalsColumn.QTY_WGH]) : 0,
        //                    OrderWgh = row[GlobalsColumn.ISSUE_UNIT_METHOD].ToString() == "W" ? Convert.ToDecimal(row[GlobalsColumn.QTY_WGH]) : 0,
        //                });
        //            }
        //        }

        //        var order = new Order
        //        {
        //            OrderNo = txtProductSlip.Text,
        //            RequestDate = dtpProductSlipDate.Value,
        //            Customer = new Customer
        //            {
        //                CustomerCode = cboCustomer.SelectedValue.ToString()
        //            },
        //            OrderFlag = 0,
        //            Active = chkActive.Checked,
        //            CreateBy = "system",
        //            ModifiedBy = "system",
        //            OrderItems = orderItems
        //        };

        //        if (string.IsNullOrEmpty(txtProductSlip.Text))
        //        {
        //            OrderController.Insert(order);
        //        }
        //        else
        //        {
        //            OrderController.Update(order);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //private void CancelProductSlip()
        //{
        //    try
        //    {
        //        var order = new Order
        //        {
        //            OrderNo = txtProductSlip.Text,
        //            RequestDate = dtpProductSlipDate.Value,
        //            Customer = new Customer
        //            {
        //                CustomerCode = cboCustomer.SelectedValue.ToString()
        //            },
        //            OrderFlag = 0,
        //            Active = false,
        //            CreateBy = "system",
        //            ModifiedBy = "system" 
        //        };
        //        OrderController.Cancel(order);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

       
    }
}
