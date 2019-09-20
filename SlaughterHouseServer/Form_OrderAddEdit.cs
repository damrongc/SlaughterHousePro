using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_OrderAddEdit : Form
    {
        public string orderNo { get; set; }
        DataTable dtOrderItem;

        public Form_OrderAddEdit()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            btnAddOrderItem.Click += BtnAddOrderItem_Click;
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

            //KeyDown  
            dtpRequestDate.KeyDown += DtpRequestDate_KeyDown;
            cboCustomer.KeyDown += CboCustomer_KeyDown;
        }
        private void Form_Shown(object sender, System.EventArgs e)
        {
            dtpRequestDate.Focus();
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
        #endregion

        #region Event Focus, KeyDown 
        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gv.Columns["seq"].HeaderText = "ลำดับ";
            gv.Columns[GlobalsColumn.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gv.Columns[GlobalsColumn.PRODUCT_NAME].HeaderText = "ชื่อสินค้า";
            gv.Columns[GlobalsColumn.QTY_WGH].HeaderText = "จำนวน";
            gv.Columns[GlobalsColumn.ISSUE_UNIT_METHOD].HeaderText = "หน่วยคำนวณ";
            gv.Columns[GlobalsColumn.UNIT_CODE].HeaderText = "รหัสหน่วยสินค้า";
            gv.Columns[GlobalsColumn.UNIT_NAME].HeaderText = "หน่วยสินค้า";

            gv.Columns["seq"].Visible = false;
            gv.Columns[GlobalsColumn.ISSUE_UNIT_METHOD].Visible = false;
            gv.Columns[GlobalsColumn.UNIT_CODE].Visible = false;
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
                txtOrderNo.Text = "";
                txtOrderNo.Focus();
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
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CancelOrder();
                MessageBox.Show("ยกเลิกเอกสาร เรียบร้อยแล้ว", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnAddOrderItem_Click(object sender, System.EventArgs e)
        {

            var frm = new Form_OrderDetail();
            frm.qtyWgh = 0;
            frm.orderDate = dtpRequestDate.Value;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow dr;
                dr = dtOrderItem.NewRow();

                dr[GlobalsColumn.SEQ] = 0;
                dr[GlobalsColumn.PRODUCT_CODE] = frm.productCode;
                dr[GlobalsColumn.PRODUCT_NAME] = frm.productName;
                dr[GlobalsColumn.QTY_WGH] = frm.qtyWgh;
                dr[GlobalsColumn.ISSUE_UNIT_METHOD] = frm.issueUnitMethod;
                dr[GlobalsColumn.UNIT_CODE] = frm.unitCode;
                dr[GlobalsColumn.UNIT_NAME] = frm.unitName;
                dtOrderItem.Rows.Add(dr);
                dtOrderItem.AcceptChanges();
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
                            var frm = new Form_OrderDetail();
                            frm.orderNo = txtOrderNo.Text;
                            frm.orderDate = dtpRequestDate.Value;

                            frm.productCode = dtOrderItem.Rows[e.RowIndex][GlobalsColumn.PRODUCT_CODE].ToString();
                            frm.qtyWgh = Convert.ToDecimal(dtOrderItem.Rows[e.RowIndex][GlobalsColumn.QTY_WGH]);
                            frm.issueUnitMethod = dtOrderItem.Rows[e.RowIndex][GlobalsColumn.ISSUE_UNIT_METHOD].ToString();
                            frm.unitCode = Convert.ToInt16(dtOrderItem.Rows[e.RowIndex][GlobalsColumn.UNIT_CODE]);
                            frm.unitName = dtOrderItem.Rows[e.RowIndex][GlobalsColumn.UNIT_NAME].ToString();
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                dtOrderItem.Rows[e.RowIndex][GlobalsColumn.PRODUCT_CODE] = frm.productCode;
                                dtOrderItem.Rows[e.RowIndex][GlobalsColumn.PRODUCT_NAME] = frm.productName;
                                dtOrderItem.Rows[e.RowIndex][GlobalsColumn.QTY_WGH] = frm.qtyWgh;
                                dtOrderItem.Rows[e.RowIndex][GlobalsColumn.ISSUE_UNIT_METHOD] = frm.issueUnitMethod;
                                dtOrderItem.Rows[e.RowIndex][GlobalsColumn.UNIT_CODE] = frm.unitCode;
                                dtOrderItem.Rows[e.RowIndex][GlobalsColumn.UNIT_NAME] = frm.unitName;
                                dtOrderItem.AcceptChanges();
                                gv.Refresh();
                            }
                            break;
                        case "Del":
                            dtOrderItem.Rows[e.RowIndex].Delete();
                            dtOrderItem.AcceptChanges();
                            gv.Refresh();
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
            txtOrderNo.Enabled = false;
            Order order = OrderController.GetOrder(this.orderNo);
            if (order != null)
            {
                txtOrderNo.Text = order.OrderNo;
                dtpRequestDate.Value = order.RequestDate;
                cboCustomer.SelectedValue = order.Customer.CustomerCode;
                txtComment.Text = order.Comments;
                chkActive.Checked = order.Active;
                dtpRequestDate.Enabled = false;
                BtnSaveAndNew.Visible = false;
            }
            else
            {
                BtnCancel.Visible = false;
            }
            LoadDetail();
        }
        private void LoadDetail()
        {
            dtOrderItem = new DataTable("ORDERS_ITEM");
            dtOrderItem = OrderItemController.GetOrderItems(orderNo, "Y");

            gv.DataSource = dtOrderItem;
            gv.Columns["seq"].Visible = false;
            gv.Columns["issue_unit_method"].Visible = false;
            gv.Columns["unit_code"].Visible = false;
            gv.Columns["unload_qty"].Visible = false;
            gv.Columns["unload_wgh"].Visible = false;
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
                foreach (DataRow row in dtOrderItem.Rows)
                {
                    DataTable dtBom = BomController.GetBom(row[GlobalsColumn.PRODUCT_CODE].ToString());

                    //if (bomItm.Count > 0)
                    //{
                    //}
                    orderItems.Add(new OrderItem
                    {
                        OrderNo = txtOrderNo.Text,
                        Seq = seq,
                        Product = new Product
                        {
                            ProductCode = row["product_code"].ToString(),
                            ProductName = row["product_name"].ToString(),
                        },
                        OrderQty = row["issue_unit_method"].ToString() == "Q" ? Convert.ToInt16(row["qty_wgh"]) : 0,
                        OrderWgh = row["issue_unit_method"].ToString() == "W" ? Convert.ToDecimal(row["qty_wgh"]) : 0,
                    });

                    if (dtBom.Rows.Count > 0)
                    {
                        foreach (DataRow dtRow in dtBom.Rows)
                        {
                            seq++;
                            orderItems.Add(new OrderItem
                            {
                                OrderNo = txtOrderNo.Text,
                                Seq = seq,
                                Product = new Product
                                {
                                    ProductCode = dtRow[GlobalsColumn.PRODUCT_CODE].ToString(),
                                    ProductName = "",
                                },
                                BomCode = (int)dtRow["bom_code"],
                                OrderSetQty = row[GlobalsColumn.ISSUE_UNIT_METHOD].ToString() == "Q" ? Convert.ToInt16(row[GlobalsColumn.QTY_WGH]) : 0,
                                OrderSetWgh = row[GlobalsColumn.ISSUE_UNIT_METHOD].ToString() == "W" ? Convert.ToDecimal(row[GlobalsColumn.QTY_WGH]) : 0,
                                OrderQty = row[GlobalsColumn.ISSUE_UNIT_METHOD].ToString() == "Q" ? Convert.ToInt16(row[GlobalsColumn.QTY_WGH]) * Convert.ToInt16(dtRow["Mutiply_Qty"]) : 0,
                                OrderWgh = row[GlobalsColumn.ISSUE_UNIT_METHOD].ToString() == "W" ? Convert.ToDecimal(row[GlobalsColumn.QTY_WGH]) * Convert.ToDecimal(dtRow["Mutiply_Wgh"]) : 0,
                            });
                        }
                    }
                    else
                    {
                        seq++;
                        orderItems.Add(new OrderItem
                        {
                            OrderNo = txtOrderNo.Text,
                            Seq = seq,
                            Product = new Product
                            {
                                ProductCode = row[GlobalsColumn.PRODUCT_CODE].ToString(),
                                ProductName = row[GlobalsColumn.PRODUCT_NAME].ToString(),
                            },
                            BomCode = 0,
                            OrderSetQty = 0,
                            OrderSetWgh = 0,
                            OrderQty = row[GlobalsColumn.ISSUE_UNIT_METHOD].ToString() == "Q" ? Convert.ToInt16(row[GlobalsColumn.QTY_WGH]) : 0,
                            OrderWgh = row[GlobalsColumn.ISSUE_UNIT_METHOD].ToString() == "W" ? Convert.ToDecimal(row[GlobalsColumn.QTY_WGH]) : 0,
                        });
                    }
                }

                var order = new Order
                {
                    OrderNo = txtOrderNo.Text,
                    RequestDate = dtpRequestDate.Value,
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

                if (string.IsNullOrEmpty(txtOrderNo.Text))
                {
                    OrderController.Insert(order);
                }
                else
                {
                    OrderController.Update(order);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CancelOrder()
        {
            try
            {
                var order = new Order
                {
                    OrderNo = txtOrderNo.Text,
                    RequestDate = dtpRequestDate.Value,
                    Customer = new Customer
                    {
                        CustomerCode = cboCustomer.SelectedValue.ToString()
                    },
                    Comments = txtComment.Text,
                    OrderFlag = 0,
                    Active = false,
                    CreateBy = "system",
                    ModifiedBy = "system"
                };
                OrderController.Cancel(order);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
