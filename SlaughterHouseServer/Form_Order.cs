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
            gv.Columns[ConstColumns.ORDER_NO].HeaderText = "เลขที่ใบสั่งขาย";
            gv.Columns[ConstColumns.REQUEST_DATE].HeaderText = "วันที่ต้องการสินค้า";
            gv.Columns[ConstColumns.CUSTOMER_NAME].HeaderText = "ลูกค้า";
            gv.Columns[ConstColumns.COMMENTS].HeaderText = "หมายเหตุ";
            gv.Columns[ConstColumns.ORDER_FLAG].HeaderText = "สถานะ";
            gv.Columns[ConstColumns.INVOICE_FLAG].HeaderText = "สถานะออกใบแจ้งหนี้";
            gv.Columns[ConstColumns.ACTIVE].HeaderText = "ใช้งาน";
            gv.Columns[ConstColumns.CREATE_AT].HeaderText = "วันเวลาสร้าง";
            gv.Columns[ConstColumns.CREATE_BY].HeaderText = "ผู้สร้าง";

            gv.Columns[ConstColumns.ORDER_FLAG].Visible = false;
            gv.Columns[ConstColumns.INVOICE_FLAG].Visible = false;
            gv.Columns[ConstColumns.ACTIVE].Visible = false;
            gv.Columns[ConstColumns.CREATE_BY].Visible = false;

            DataGridViewButtonColumn invoiceBtnColumn = new DataGridViewButtonColumn();
            invoiceBtnColumn.Name = ConstColumns.BTN_INVOICE;
            invoiceBtnColumn.Text = "สร้างใบแจ้งหนี้";
            invoiceBtnColumn.UseColumnTextForButtonValue = true; //dont forget this line
            invoiceBtnColumn.FlatStyle = FlatStyle.Flat;
            if (gv.Columns[ConstColumns.BTN_INVOICE] == null)
            {
                gv.Columns.Insert(gv.ColumnCount, invoiceBtnColumn);
                gv.Columns[ConstColumns.BTN_INVOICE].HeaderText = "";
            }
            foreach (DataGridViewRow row in gv.Rows)
            {
                string invocieFlag = gv.Rows[row.Index].Cells[ConstColumns.INVOICE_FLAG].Value.ToString();
                if (invocieFlag == "1")
                {
                    gv.Rows[row.Index].Cells[ConstColumns.BTN_INVOICE].Style.BackColor = Color.Gray;
                }
                else
                {
                    gv.Rows[row.Index].Cells[ConstColumns.BTN_INVOICE].Style.BackColor = Color.MediumSpringGreen;
                }
            }

            DataGridViewButtonColumn printProductSlipBtnColumn = new DataGridViewButtonColumn();
            printProductSlipBtnColumn.Name = ConstColumns.BTN_PRODUCT_SLIP;
            printProductSlipBtnColumn.Text = "สร้างใบจัดสินค้า";
            printProductSlipBtnColumn.UseColumnTextForButtonValue = true; //dont forget this line
            printProductSlipBtnColumn.FlatStyle = FlatStyle.Flat;
            if (gv.Columns[ConstColumns.BTN_PRODUCT_SLIP] == null)
            {
                gv.Columns.Insert(gv.ColumnCount, printProductSlipBtnColumn);
                gv.Columns[ConstColumns.BTN_PRODUCT_SLIP].HeaderText = "";
            }
        }


        private void GvDt_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gvDt.Columns[ConstColumns.SEQ].HeaderText = "ลำดับ";
            gvDt.Columns[ConstColumns.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gvDt.Columns[ConstColumns.PRODUCT_NAME].HeaderText = "สินค้า";
            gvDt.Columns[ConstColumns.QTY].HeaderText = "ปริมาณ";
            gvDt.Columns[ConstColumns.WGH].HeaderText = "น้ำหนัก";
            gvDt.Columns[ConstColumns.ISSUE_UNIT_METHOD].HeaderText = "หน่วยคำนวณ";
            gvDt.Columns[ConstColumns.UNIT_CODE_QTY].HeaderText = "รหัสหน่วยปริมาณ";
            gvDt.Columns[ConstColumns.UNIT_NAME_QTY].HeaderText = "หน่วยปริมาณ";
            gvDt.Columns[ConstColumns.UNIT_CODE_WGH].HeaderText = "รหัสหน่วยน้ำหนัก";
            gvDt.Columns[ConstColumns.UNIT_NAME_WGH].HeaderText = "หน่วยน้ำหนัก";
            gvDt.Columns[ConstColumns.UNLOAD_QTY].HeaderText = "ปริมาณจ่าย";
            gvDt.Columns[ConstColumns.UNLOAD_WGH].HeaderText = "น้ำหนักจ่าย";

            gvDt.Columns[ConstColumns.SEQ].Visible = false;
            gvDt.Columns[ConstColumns.PRODUCT_CODE].Visible = false;
            gvDt.Columns[ConstColumns.UNIT_CODE_QTY].Visible = false;
            gvDt.Columns[ConstColumns.UNIT_CODE_WGH].Visible = false;
            gvDt.Columns[ConstColumns.ISSUE_UNIT_METHOD].Visible = false;
            gvDt.Columns[ConstColumns.PACKING_SIZE].Visible = false;

            gvDt.Columns[ConstColumns.QTY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[ConstColumns.WGH].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[ConstColumns.UNLOAD_QTY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[ConstColumns.UNLOAD_WGH].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gvDt.Columns[ConstColumns.QTY].DefaultCellStyle.Format = "N0";
            gvDt.Columns[ConstColumns.WGH].DefaultCellStyle.Format = "N2";
            gvDt.Columns[ConstColumns.UNLOAD_QTY].DefaultCellStyle.Format = "N0";
            gvDt.Columns[ConstColumns.UNLOAD_WGH].DefaultCellStyle.Format = "N2";
        }

        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                string orderNo = gv.Rows[e.RowIndex].Cells[ConstColumns.ORDER_NO].Value.ToString();


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
                        case ConstColumns.BTN_INVOICE:
                            string invocieFlag = gv.Rows[e.RowIndex].Cells[ConstColumns.INVOICE_FLAG].Value.ToString();
                            if (invocieFlag == "1")
                            {
                                return;
                            }
                            bool pickingCompleteFlag = OrderItemController.CheckPickingComplete(orderNo);
                            if (pickingCompleteFlag == false)
                            {
                                LoadItem(orderNo);
                                DialogResult result = MessageBox.Show("จำนวนสินยังไม่ครบตามใบสั่งขาย\rท่านยังต้องขายใช่ไหม? Yes/No", "Warning ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
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
                        case ConstColumns.BTN_PRODUCT_SLIP:
                            var frmSlip = new Form_ProductSlip
                            {
                                orderNo = orderNo,
                            };
                            if (frmSlip.ShowDialog() == DialogResult.OK)
                            {
                                LoadOrder();
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

            }
            LoadOrder();
        }

        private void LoadCustomer()
        {
            var coll = CustomerController.GetAllCustomers();
            coll.Insert(0, new Customer
            {
                CustomerCode = "",
                CustomerName = "--ทั้งหมด--"
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