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
            gv.CellContentClick += Gv_CellContentClick;
            gv.DataBindingComplete += Gv_DataBindingComplete;
            gv.CellEndEdit += Gv_CellEndEdit;
            gv.EditingControlShowing += Gv_EditingControlShowing;
            //gv.ReadOnly = true;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;


            this.Load += Form_Load;
            this.Shown += Form_Shown;

            btnAddOrderItem.Click += BtnAddOrderItem_Click;


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
            gv.Columns[ConstColumns.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gv.Columns[ConstColumns.PRODUCT_NAME].HeaderText = "ชื่อสินค้า";
            gv.Columns[ConstColumns.QTY].HeaderText = "ปริมาณ";
            gv.Columns[ConstColumns.WGH].HeaderText = "น้ำหนัก";
            gv.Columns[ConstColumns.ISSUE_UNIT_METHOD].HeaderText = "หน่วยคำนวณ";
            gv.Columns[ConstColumns.UNIT_CODE_QTY].HeaderText = "รหัสหน่วยปริมาณ";
            gv.Columns[ConstColumns.UNIT_NAME_QTY].HeaderText = "หน่วยปริมาณ";
            gv.Columns[ConstColumns.UNIT_CODE_WGH].HeaderText = "รหัสหน่วยน้ำหนัก";
            gv.Columns[ConstColumns.UNIT_NAME_WGH].HeaderText = "หน่วยน้ำหนัก";

            gv.Columns["seq"].Visible = false;
            gv.Columns[ConstColumns.ISSUE_UNIT_METHOD].Visible = false;
            gv.Columns[ConstColumns.UNIT_CODE_QTY].Visible = false;
            gv.Columns[ConstColumns.UNIT_CODE_WGH].Visible = false;


            gv.Columns[ConstColumns.PRODUCT_CODE].ReadOnly = true;
            gv.Columns[ConstColumns.PRODUCT_NAME].ReadOnly = true;
            gv.Columns[ConstColumns.UNIT_NAME_QTY].ReadOnly = true;
            gv.Columns[ConstColumns.UNIT_NAME_WGH].ReadOnly = true;
            gv.Columns[ConstColumns.PACKING_SIZE].ReadOnly = true;
            gv.Columns[ConstColumns.QTY].ReadOnly = false;
            gv.Columns[ConstColumns.WGH].ReadOnly = false;


            gv.Columns[ConstColumns.QTY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[ConstColumns.WGH].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[ConstColumns.QTY].DefaultCellStyle.Format = "N0";
            gv.Columns[ConstColumns.WGH].DefaultCellStyle.Format = "N2";
            gv.Columns[ConstColumns.PACKING_SIZE].DefaultCellStyle.Format = "N2";
            foreach (DataGridViewColumn column in gv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
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
                dtpRequestDate.Value = DateTime.Now;
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

            //var frm = new Form_OrderDetail();
            //frm.qtyWgh = 0;
            //frm.orderDate = dtpRequestDate.Value;
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    DataRow dr;
            //    dr = dtOrderItem.NewRow();

            //    dr[ConstColumns.SEQ] = 0;
            //    dr[ConstColumns.PRODUCT_CODE] = frm.productCode;
            //    dr[ConstColumns.PRODUCT_NAME] = frm.productName;
            //    dr[ConstColumns.QTY_WGH] = frm.qtyWgh;
            //    dr[ConstColumns.ISSUE_UNIT_METHOD] = frm.issueUnitMethod;
            //    dr[ConstColumns.UNIT_CODE] = frm.unitCode;
            //    dr[ConstColumns.UNIT_NAME] = frm.unitName;
            //    dtOrderItem.Rows.Add(dr);
            //    dtOrderItem.AcceptChanges();
            //}
            try
            {
                var frm = new Form_LovProductMuti();
                frm.forSaleFlag = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataRow dr;
                    foreach (DataRow row in frm.dtResultProduct.Rows)
                    {
                        DataRow[] results = dtOrderItem.Select($"product_code = '{row[ConstColumns.PRODUCT_CODE]}' ");
                        if (results.Length == 0)
                        {
                            dr = dtOrderItem.NewRow();
                            dr[ConstColumns.SEQ] = 0;
                            dr[ConstColumns.PRODUCT_CODE] = row[ConstColumns.PRODUCT_CODE];
                            dr[ConstColumns.PRODUCT_NAME] = row[ConstColumns.PRODUCT_NAME];
                            dr[ConstColumns.QTY] = 0;
                            dr[ConstColumns.UNIT_CODE_QTY] = row[ConstColumns.UNIT_CODE_QTY];
                            dr[ConstColumns.UNIT_NAME_QTY] = row[ConstColumns.UNIT_NAME_QTY];
                            dr[ConstColumns.WGH] = 0;
                            dr[ConstColumns.UNIT_CODE_WGH] = row[ConstColumns.UNIT_CODE_WGH];
                            dr[ConstColumns.UNIT_NAME_WGH] = row[ConstColumns.UNIT_NAME_WGH];
                            dr[ConstColumns.ISSUE_UNIT_METHOD] = row[ConstColumns.ISSUE_UNIT_METHOD];
                            dr[ConstColumns.PACKING_SIZE] = row[ConstColumns.PACKING_SIZE];

                            dtOrderItem.Rows.Add(dr);
                            dtOrderItem.AcceptChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        //    frm.orderNo = txtOrderNo.Text;
                        //    frm.orderDate = dtpRequestDate.Value;

                        //    frm.productCode = dtOrderItem.Rows[e.RowIndex][ConstColumns.PRODUCT_CODE].ToString();
                        //    frm.qtyWgh = Convert.ToDecimal(dtOrderItem.Rows[e.RowIndex][ConstColumns.QTY_WGH]);
                        //    frm.issueUnitMethod = dtOrderItem.Rows[e.RowIndex][ConstColumns.ISSUE_UNIT_METHOD].ToString();
                        //    frm.unitCode = Convert.ToInt16(dtOrderItem.Rows[e.RowIndex][ConstColumns.UNIT_CODE]);
                        //    frm.unitName = dtOrderItem.Rows[e.RowIndex][ConstColumns.UNIT_NAME].ToString();
                        //    if (frm.ShowDialog() == DialogResult.OK)
                        //    {
                        //        dtOrderItem.Rows[e.RowIndex][ConstColumns.PRODUCT_CODE] = frm.productCode;
                        //        dtOrderItem.Rows[e.RowIndex][ConstColumns.PRODUCT_NAME] = frm.productName;
                        //        dtOrderItem.Rows[e.RowIndex][ConstColumns.QTY_WGH] = frm.qtyWgh;
                        //        dtOrderItem.Rows[e.RowIndex][ConstColumns.ISSUE_UNIT_METHOD] = frm.issueUnitMethod;
                        //        dtOrderItem.Rows[e.RowIndex][ConstColumns.UNIT_CODE] = frm.unitCode;
                        //        dtOrderItem.Rows[e.RowIndex][ConstColumns.UNIT_NAME] = frm.unitName;
                        //        dtOrderItem.AcceptChanges();
                        //        gv.Refresh();
                        //    }
                        //    break;
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

        private void Gv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //do your checks to see RowIndex is not -1 and other good stuffs
            //var row = gv.Rows[e.RowIndex];
            int rowIdx = e.RowIndex;
            int colIdx = e.ColumnIndex - 1;
            DataGridView senderGrid = (DataGridView)sender;
            decimal packingSize = 0;
            decimal.TryParse(dtOrderItem.Rows[rowIdx][ConstColumns.PACKING_SIZE].ToString(), out packingSize);
             
            switch (senderGrid.Columns[e.ColumnIndex].Name)
            {
                case "qty":
                    dtOrderItem.Rows[rowIdx][ConstColumns.WGH] = MyExtension.ToInt32(dtOrderItem.Rows[rowIdx][ConstColumns.QTY].ToString()) * packingSize;
                    break;
                case "wgh":
                    if (packingSize ==0)
                    {
                        break;
                    } 
                    dtOrderItem.Rows[rowIdx][ConstColumns.QTY] = Math.Ceiling(MyExtension.ToDecimal(dtOrderItem.Rows[rowIdx][ConstColumns.WGH].ToString()) / packingSize);
                    break;
            }
            dtOrderItem.AcceptChanges();
            gv.Refresh();
            //row.Cells[e.ColumnIndex].OwningColumn.Name  ##getName
        }

        private void Gv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnNumber_KeyPress);
            if (gv.CurrentCell.ColumnIndex == 4 || gv.CurrentCell.ColumnIndex == 6) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnNumber_KeyPress);
                }
            }
        }

        private void ColumnNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

            if (!String.IsNullOrEmpty(txtOrderNo.Text))
            {
                bool res = OrderController.CheckUseOrder(this.orderNo);
                if (res == true)
                {
                    btnAddOrderItem.Enabled = false;
                    BtnSave.Enabled = false;
                    BtnSaveAndNew.Enabled = false;
                    BtnCancel.Enabled = false;
                    cboCustomer.Enabled = false;
                    txtComment.Enabled = false;
                    gv.Enabled = false;
                }
            }
            
        }
        private void LoadDetail()
        {
            dtOrderItem = new DataTable("ORDERS_ITEM");
            dtOrderItem = OrderItemController.GetOrderItems(orderNo, "Y");

            gv.DataSource = dtOrderItem;
            gv.Columns[ConstColumns.SEQ].Visible = false;
            gv.Columns[ConstColumns.ISSUE_UNIT_METHOD].Visible = false;
            gv.Columns[ConstColumns.UNLOAD_QTY].Visible = false;
            gv.Columns[ConstColumns.UNIT_CODE_QTY].Visible = false;
            gv.Columns[ConstColumns.UNLOAD_WGH].Visible = false;
            gv.Columns[ConstColumns.UNIT_CODE_WGH].Visible = false;

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
                CheckBeforeSave();
                var orderItems = new List<OrderItem>();
                int seq = 0;
                foreach (DataRow row in dtOrderItem.Rows)
                {
                    DataTable dtBom = BomController.GetBom(row[ConstColumns.PRODUCT_CODE].ToString());
                    if (dtBom.Rows.Count > 0)
                    {
                        foreach (DataRow dtBomRow in dtBom.Rows)
                        {
                            seq++;
                            //Product productBom = ProductController.GetProduct(dtBomRow[ConstColumns.PRODUCT_CODE].ToString());
                            orderItems.Add(new OrderItem
                            {
                                OrderNo = txtOrderNo.Text,
                                Seq = seq,
                                Product = new Product
                                {
                                    ProductCode = dtBomRow[ConstColumns.PRODUCT_CODE].ToString(),
                                    ProductName = "",
                                },
                                BomCode = (int)dtBomRow["bom_code"],
                                OrderSetQty = Convert.ToInt16(row[ConstColumns.QTY]) ,
                                OrderSetWgh = Convert.ToInt16(row[ConstColumns.WGH]),
                                OrderQty =  Convert.ToInt16(row[ConstColumns.QTY]) * Convert.ToInt16(dtBomRow[ConstColumns.MUTIPLY_QTY]) ,
                                OrderWgh = Convert.ToInt16(row[ConstColumns.QTY]) * Convert.ToDecimal(dtBomRow[ConstColumns.PACKING_SIZE]) * Convert.ToDecimal(dtBomRow[ConstColumns.MUTIPLY_WGH]) ,
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
                                ProductCode = row[ConstColumns.PRODUCT_CODE].ToString(),
                                ProductName = row[ConstColumns.PRODUCT_NAME].ToString(),
                            },
                            BomCode = 0,
                            OrderSetQty = 0,
                            OrderSetWgh = 0,
                            OrderQty =  Convert.ToInt16(row[ConstColumns.QTY]) ,
                            OrderWgh =  Convert.ToDecimal(row[ConstColumns.WGH]),
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                throw;
            }
        }
        private void CheckBeforeSave()
        {
            try
            {
                //Check UNIT_PRICE
                for (int i = 0; i < dtOrderItem.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dtOrderItem.Rows[i][ConstColumns.QTY]) == 0 && Convert.ToDecimal(dtOrderItem.Rows[i][ConstColumns.WGH]) == 0)
                    {
                        throw new Exception($"สินค้า {dtOrderItem.Rows[i][ConstColumns.PRODUCT_NAME]} ไม่ได้ระบุปริมาณหรือน้ำหนัก");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }

}
