using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_Order : Form
    {

        public Form_Order()
        {
            InitializeComponent();
            UserSettingsComponent();
        }

        private void UserSettingsComponent()
        {
            BtnAdd.Click += BtnAdd_Click;
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

            gvDt.DataBindingComplete += GvDt_DataBindingComplete; 
            gvDt.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gvDt.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gvDt.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gvDt.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gvDt.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvDt.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gvDt.EnableHeadersVisualStyles = false;

            LoadCustomer();
            LoadOrder();
        }

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gv.Columns[GlobalsColumn.ORDER_NO].HeaderText = "เลขที่ใบสั่งขาย";
            gv.Columns[GlobalsColumn.REQUEST_DATE].HeaderText = "วันที่ต้องการสินค้า";
            gv.Columns[GlobalsColumn.CUSTOMER_NAME].HeaderText = "ลูกค้า";
            gv.Columns[GlobalsColumn.COMMENTS].HeaderText = "หมายเหตุ";
            gv.Columns[GlobalsColumn.ORDER_FLAG].HeaderText = "สถานะ";
            gv.Columns[GlobalsColumn.INVOICE_FLAG].HeaderText = "สถานะออกใบแจ้งหนี้";
            gv.Columns[GlobalsColumn.ACTIVE].HeaderText = "ใช้งาน";
            gv.Columns[GlobalsColumn.CREATE_AT].HeaderText = "วันเวลาสร้าง";
            gv.Columns[GlobalsColumn.CREATE_BY].HeaderText = "ผู้สร้าง";

            gv.Columns[GlobalsColumn.ORDER_FLAG].Visible = false;
            gv.Columns[GlobalsColumn.INVOICE_FLAG].Visible = false;
            gv.Columns[GlobalsColumn.ACTIVE].Visible = false;
            gv.Columns[GlobalsColumn.CREATE_BY].Visible = false;

            DataGridViewButtonColumn invoiceBtnColumn = new DataGridViewButtonColumn();
            invoiceBtnColumn.Name = GlobalsColumn.BTN_INVOICE;
            invoiceBtnColumn.Text = "ออกใบแจ้งหนี้";
            invoiceBtnColumn.UseColumnTextForButtonValue = true; //dont forget this line
            invoiceBtnColumn.FlatStyle = FlatStyle.Flat;
            if (gv.Columns[GlobalsColumn.BTN_INVOICE] == null)
            {
                gv.Columns.Insert(gv.ColumnCount, invoiceBtnColumn);
                gv.Columns[GlobalsColumn.BTN_INVOICE].HeaderText = "ใบแจ้งหนี้";
            }
            foreach (DataGridViewRow row in gv.Rows)
            {
                string invocieFlag = gv.Rows[row.Index].Cells[GlobalsColumn.INVOICE_FLAG].Value.ToString();
                if (invocieFlag == "1")
                {
                    gv.Rows[row.Index].Cells[GlobalsColumn.BTN_INVOICE].Style.BackColor = Color.DarkSlateGray;
                    //gv.Rows[row.Index].Cells[GlobalsColumn.BTN_INVOICE].Value = "ออกใบแจ้งหนี้";
                }
                else
                {
                    gv.Rows[row.Index].Cells[GlobalsColumn.BTN_INVOICE].Style.BackColor = Color.MediumSpringGreen;
                }
            }
        }

        private void GvDt_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gvDt.Columns[GlobalsColumn.SEQ].HeaderText = "ลำดับ";
            gvDt.Columns[GlobalsColumn.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gvDt.Columns[GlobalsColumn.PRODUCT_NAME].HeaderText = "สินค้า";
            gvDt.Columns[GlobalsColumn.QTY_WGH].HeaderText = "จำนวน";
            gvDt.Columns[GlobalsColumn.ISSUE_UNIT_METHOD].HeaderText = "หน่วยคำนวณ";
            gvDt.Columns[GlobalsColumn.UNIT_CODE].HeaderText = "รหัสหน่วยสินค้า";
            gvDt.Columns[GlobalsColumn.UNIT_NAME].HeaderText = "หน่วยสินค้า";
            gvDt.Columns[GlobalsColumn.UNLOAD_QTY].HeaderText = "ปริมาณจ่าย";
            gvDt.Columns[GlobalsColumn.UNLOAD_WGH].HeaderText = "น้ำหนักจ่าย";

            gvDt.Columns[GlobalsColumn.SEQ].Visible = false;
            gvDt.Columns[GlobalsColumn.PRODUCT_CODE].Visible = false;
            gvDt.Columns[GlobalsColumn.UNIT_CODE].Visible = false;
            gvDt.Columns[GlobalsColumn.ISSUE_UNIT_METHOD].Visible = false;


            gvDt.Columns[GlobalsColumn.QTY_WGH].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[GlobalsColumn.UNLOAD_QTY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[GlobalsColumn.UNLOAD_WGH].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gvDt.Columns[GlobalsColumn.QTY_WGH].DefaultCellStyle.Format = "N2";
            gvDt.Columns[GlobalsColumn.UNLOAD_QTY].DefaultCellStyle.Format ="N0";
            gvDt.Columns[GlobalsColumn.UNLOAD_WGH].DefaultCellStyle.Format = "N2";
        }

        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                string orderNo = gv.Rows[e.RowIndex].Cells[GlobalsColumn.ORDER_NO].Value.ToString();


                if ((senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn || senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) && e.RowIndex >= 0)
                {
                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {
                        case "Edit":
                            var frm = new Form_OrderAddEdit
                            {
                                orderNo = orderNo
                            };
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                LoadOrder();
                            }
                            break;
                        case "Print":
                            break;
                        case GlobalsColumn.BTN_INVOICE:
                            string invocieFlag = gv.Rows[e.RowIndex].Cells[GlobalsColumn.INVOICE_FLAG].Value.ToString();
                            if (invocieFlag == "1")
                            { 
                                return;
                            }
                            bool pickingCompleteFlag = OrderItemController.CheckPickingComplete(orderNo);
                            if (pickingCompleteFlag == false )
                            {
                                DialogResult result = MessageBox.Show("จำนวนสินยังไม่ครบตามใบสั่งขาย ท่านยังต้องขายใช่ไหม", "Warning ", MessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes )
                                {
                                    var frmInv = new Form_InvoiceAddEdit
                                    {
                                        orderNo = orderNo
                                    };
                                    if (frmInv.ShowDialog() == DialogResult.OK)
                                    {
                                        LoadOrder();
                                    }
                                } 
                                else
                                {
                                    LoadItem(orderNo);
                                    return;
                                }
                            }
                            else
                            {
                                var frmInv = new Form_InvoiceAddEdit
                                {
                                    orderNo = orderNo
                                };
                                if (frmInv.ShowDialog() == DialogResult.OK)
                                {
                                    LoadOrder();
                                }
                            }
                            break;
                    }
                }
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
                {
                    LoadItem(orderNo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, System.EventArgs e)
        {
            LoadOrder();
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_OrderAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadOrder();
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

        private void LoadOrder()
        {
            //var farmCtrl = new FarmController();
            var coll = OrderController.GetAllOrders(dtpRequestDate.Value, cboCustomer.SelectedValue.ToString());
            gv.DataSource = coll; 
            LoadItem("");
        }
        private void LoadItem(string orderNo)
        {
            DataTable dtOrderItem = new DataTable("ORDERS_ITEM");
            dtOrderItem = OrderItemController.GetOrderItems(orderNo, "N");
            gvDt.DataSource = dtOrderItem;  
        }
    }
}