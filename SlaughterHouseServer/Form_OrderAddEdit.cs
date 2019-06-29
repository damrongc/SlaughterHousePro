﻿using SlaughterHouseLib;
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
            
        }

        private void Form_Shown(object sender, System.EventArgs e)
        {
            dtpOrderDate.Focus();
        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadCustomer(); 
            LoadData();
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

                txtOrderNo.Text = "";
                txtOrderNo.Focus();
                //txtFarmName.Text = "";
                //txtComment.Text = "";
                //chkActive.Checked = true;

            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnAddOrderItem_Click(object sender, System.EventArgs e)
        {
            
        var frm = new Form_OrderDetail();
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow dr;
                dr = dtOrderItem.NewRow();

                dr["seq"] = 0;
                dr["product_code"] = frm.productCode;
                dr["product_name"] = frm.productName;
                dr["order_qty"] = frm.qty;
                dr["order_wgh"] = frm.wgh;
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
                            frm.productCode = dtOrderItem.Rows[e.RowIndex]["product_code"].ToString();
                            frm.qty = (int)dtOrderItem.Rows[e.RowIndex]["order_qty"];
                            frm.wgh = (decimal)dtOrderItem.Rows[e.RowIndex]["order_wgh"];
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                dtOrderItem.Rows[e.RowIndex]["product_code"] = frm.productCode;
                                dtOrderItem.Rows[e.RowIndex]["product_name"] = frm.productName;
                                dtOrderItem.Rows[e.RowIndex]["order_qty"] = frm.qty;
                                dtOrderItem.Rows[e.RowIndex]["order_wgh"] = frm.wgh;
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
                dtpOrderDate.Value = order.OrderDate;
                cboCustomer.SelectedValue = order.Customer.CustomerCode;
                txtComment.Text = order.Comments;

                dtpOrderDate.Enabled = false;
                BtnSaveAndNew.Visible = false;
                LoadDetail();
            }

        }

        private void LoadDetail()
        {
            //var orderItem = OrderItemController.GetOrderItems(orderNo);
            dtOrderItem = new DataTable("ORDER_ITEM");
            dtOrderItem = OrderItemController.GetOrderItems(orderNo);
            if (dtOrderItem != null && dtOrderItem.Rows.Count > 0)
            {
                gv.DataSource = dtOrderItem;
                gv.Columns[2].HeaderText = "ลำดับ";
                gv.Columns[3].HeaderText = "รหัสสินค้า";
                gv.Columns[4].HeaderText = "ชื่อสินค้า";
                gv.Columns[5].HeaderText = "ปริมาณ";
                gv.Columns[6].HeaderText = "น้้ำหนัก";

                gv.Columns[2].Visible = false;
            }
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
                var order = new Order
                {
                    OrderNo = txtOrderNo.Text,
                    OrderDate  = dtpOrderDate.Value, 
                    Customer = new Customer
                    {
                        CustomerCode = cboCustomer.SelectedValue.ToString()
                    },  
                    Comments = txtComment.Text,
                    CreateBy = "system"

                };
                 
                var orderItems = new List<OrderItem>(); 
                foreach (DataRow row in dtOrderItem.Rows)
                {
                    orderItems.Add(new OrderItem
                    {
                        OrderNo = txtOrderNo.Text,
                        Seq = (int)row["seq"], 
                        Product = new Product
                        {
                            ProductCode = row["product_code"].ToString() ,
                            ProductName = row["product_name"].ToString(),
                        },
                        OrderQty = (int)row["order_qty"],
                        OrderWgh = (decimal)row["order_wgh"],
                    });
                }
                //OrderController.InsertOrUpdate(order);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}