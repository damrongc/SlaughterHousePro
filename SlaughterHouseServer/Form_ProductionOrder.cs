using SlaughterHouseLib;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SlaughterHouseServer
{
    public partial class Form_ProductionOrder : Form
    {
        public Form_ProductionOrder()
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

            gvDt.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gvDt.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gvDt.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gvDt.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gvDt.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvDt.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gvDt.EnableHeadersVisualStyles = false;

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

                if (e.RowIndex >= 0)
                {
                    string poNo = gv.Rows[e.RowIndex].Cells[2].Value.ToString();

                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn)
                    {
                        switch (senderGrid.Columns[e.ColumnIndex].Name)
                        {

                            case "Edit":
                                var frm = new Form_ProductionOrderAddEdit
                                {
                                    poNo = poNo
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

                        LoadItem(poNo);
                    }

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
            var frm = new Form_ProductionOrderAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadOrder();
            }
        }


        private void LoadOrder()
        {
            //var farmCtrl = new FarmController();
            var coll = ProductionOrderController.GetAllProductionOrders(dtpPoDate.Value);
            gv.DataSource = coll;

            gv.Columns[2].HeaderText = "เลขที่ใบเบิก";
            gv.Columns[3].HeaderText = "วันที่เบิก";
            gv.Columns[4].HeaderText = "หมายเหตุ";
            gv.Columns[5].HeaderText = "สถานะ";
            gv.Columns[6].HeaderText = "ใช้งาน";
            gv.Columns[7].HeaderText = "วันเวลาสร้าง";
            gv.Columns[8].HeaderText = "ผู้สร้าง";

            LoadItem("");
        }

        private void LoadItem(string poNo)
        {
            //var farmCtrl = new FarmController();
            //var items = ProductionOrderItemController.GetProductionOrderItems(poNo);

            DataTable dtPoItem = new DataTable("PO_ITEM");
            dtPoItem = ProductionOrderItemController.GetProductionOrderItems(poNo);

            gvDt.DataSource = dtPoItem;

            gvDt.Columns[0].HeaderText = "ลำดับ";
            gvDt.Columns[1].HeaderText = "รหัสสินค้า";
            gvDt.Columns[2].HeaderText = "สินค้า";
            gvDt.Columns[3].HeaderText = "จำนวน";
            gvDt.Columns[4].HeaderText = "หน่วยคำนวณ";
            gvDt.Columns[5].HeaderText = "รหัสหน่วยสินค้า";
            gvDt.Columns[6].HeaderText = "หน่วยสินค้า";
            gvDt.Columns[7].HeaderText = "ปริมาณจ่าย";
            gvDt.Columns[8].HeaderText = "น้ำหนักจ่าย";

            gvDt.Columns[1].Visible = false;
            gvDt.Columns[4].Visible = false;
            gvDt.Columns[5].Visible = false;

            gvDt.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvDt.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //###################################################

            //var coll = items.AsEnumerable().Select(p => new
            //{
            //    seq = p.Field<int>("seq"),
            //    product_name = p.Field<string>("product_name"),
            //    po_qty = p.Field<int>("po_qty").ToComma(),
            //    po_wgh = p.Field<decimal>("po_wgh").ToFormat2Decimal(),
            //    unload_qty = p.Field<int>("unload_qty").ToComma(),
            //    unload_wgh = p.Field<decimal>("unload_wgh").ToFormat2Decimal(),

            //}).ToList();
            //gv2.DataSource = coll;

            //gv2.Columns[0].HeaderText = "ลำดับ";
            //gv2.Columns[1].HeaderText = "สินค้า";
            //gv2.Columns[2].HeaderText = "จำนวนเบิก";
            //gv2.Columns[3].HeaderText = "น้ำหนักเบิก";
            //gv2.Columns[4].HeaderText = "จำนวนจ่าย";
            //gv2.Columns[5].HeaderText = "น้ำหนักจ่าย";

        } 
    }
}