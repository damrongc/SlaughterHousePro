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
        
        OrderItem.columnDt colDt;

        public Form_Order()
        {
            InitializeComponent();
            UserSettingsComponent();
        }

        private void UserSettingsComponent()
        {
            colDt.order_no       = "order_no";
            colDt.product_code   = "product_code";
            colDt.product_name = "product_name";
            colDt.bom_code       = "bom_code";
            colDt.seq            = "seq";
            colDt.qty_wgh = "qty_wgh";
            colDt.issue_unit_method = "issue_unit_method";
            colDt.unit_code = "unit_code";
            colDt.unit_name = "unit_name";
            colDt.unload_qty     = "unload_qty";
            colDt.unload_wgh     = "unload_wgh"; 
            colDt.product_set = "product_set";
            colDt.create_at      = "create_at";
            colDt.create_by      = "create_by";
            colDt.modified_at    = "modified_at";
            colDt.modified_by    = "modified_by";
            

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
              
        }

        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                string orderNo =   gv.Rows[e.RowIndex].Cells["OrderNo"].Value.ToString();
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
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

            gv.Columns[1].HeaderText = "เลขที่ใบสั่งขาย";
            gv.Columns[2].HeaderText = "วันที่ต้องการสินค้า";
            gv.Columns[3].HeaderText = "ลูกค้า";

            gv.Columns[4].HeaderText = "หมายเหตุ";
            gv.Columns[5].HeaderText = "สถานะ";
            gv.Columns[6].HeaderText = "สถานะออกใบแจ้งหนี้";

            gv.Columns[7].HeaderText = "ใช้งาน";
            gv.Columns[8].HeaderText = "วันเวลาสร้าง";
            gv.Columns[9].HeaderText = "ผู้สร้าง"; 

            LoadItem("");
        }
        private void LoadItem(string orderNo)
        {
            DataTable dtOrderItem = new DataTable("ORDERS_ITEM");
            dtOrderItem = OrderItemController.GetOrderItems(orderNo,"N"); 
 
            gvDt.DataSource = dtOrderItem;

            gvDt.Columns[colDt.seq ].HeaderText = "ลำดับ"; 
            gvDt.Columns[colDt.product_code ].HeaderText = "รหัสสินค้า";
            gvDt.Columns[colDt.product_name].HeaderText = "สินค้า";
            gvDt.Columns[colDt.qty_wgh ].HeaderText = "จำนวน";
            gvDt.Columns[colDt.issue_unit_method].HeaderText = "หน่วยคำนวณ";
            gvDt.Columns[colDt.unit_code ].HeaderText = "รหัสหน่วยสินค้า";
            gvDt.Columns[colDt.unit_name ].HeaderText = "หน่วยสินค้า";
            gvDt.Columns[colDt.unload_qty ].HeaderText = "จำนวนจ่าย";
            gvDt.Columns[colDt.unload_wgh ].HeaderText = "น้ำหนักจ่าย";
            gvDt.Columns[colDt.product_set].HeaderText = "สินค้าชุด";

            gvDt.Columns[colDt.seq ].Visible  = false ; 
            gvDt.Columns[colDt.product_code  ].Visible  = false ;
            gvDt.Columns[colDt.unit_code   ].Visible  = false;
            gvDt.Columns[colDt.issue_unit_method].Visible  = false;
             

            //gvDt.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvDt.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvDt.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvDt.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvDt.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
    }
}