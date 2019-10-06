using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_Product : Form
    {
        public Form_Product()
        {
            InitializeComponent();
            UserSettingsComponent();
        }

        private void UserSettingsComponent()
        {

            BtnAdd.Click += BtnAdd_Click;
            BtnSearch.Click += BtnSearch_Click;
            gv.CellContentClick += Gv_CellContentClick;

            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;

            this.comboxProductGroup.SelectedIndexChanged += ComboxProductGroup_SelectedIndexChanged;
            FillProductGroup();
            comboxProductGroup.SelectedIndex = 1;
            Populate();
        }

        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    string productCode = gv.Rows[e.RowIndex].Cells[ConstColumns.PRODUCT_CODE].Value.ToString();
                    var frm = new Form_ProductAddEdit
                    {
                        productCode = productCode
                    };
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Populate();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboxProductGroup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Populate();
        }

        private void BtnSearch_Click(object sender, System.EventArgs e)
        {
            Populate();
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_ProductAddEdit
            {
                productCode = ""
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Populate();
            }
        }

        private void Populate()
        {

            DataTable dt = ProductController.GetAllProducts(comboxProductGroup.SelectedValue.ToString(), TxtFilter.Text.Trim());
            gv.DataSource = dt;

            gv.Columns[ConstColumns.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gv.Columns[ConstColumns.PRODUCT_NAME].HeaderText = "ชื่อสินค้า";
            gv.Columns[ConstColumns.PRODUCT_GROUP_NAME].HeaderText = "ชื่อกลุ่มสินค้า";
            gv.Columns[ConstColumns.UNIT_NAME_QTY].HeaderText = "หน่วยนับปริมาณ";
            gv.Columns[ConstColumns.UNIT_NAME_WGH].HeaderText = "หน่วยนับน้ำหนัก";
            gv.Columns[ConstColumns.MIN_WEIGHT].HeaderText = "น้ำหนักต่าสุด";
            gv.Columns[ConstColumns.MAX_WEIGHT].HeaderText = "น้ำหนักสูงสุด";
            gv.Columns[ConstColumns.STD_YIELD].HeaderText = "std. yield";
            gv.Columns[ConstColumns.SALE_UNIT_METHOD].HeaderText = "หน่วยคำนวณขาย";
            gv.Columns[ConstColumns.ISSUE_UNIT_METHOD].HeaderText = "หน่วยคำนวณเบิก";
            gv.Columns[ConstColumns.PACKING_SIZE].HeaderText = "ขนาดบรรจุ";
            gv.Columns[ConstColumns.ACTIVE].HeaderText = "ใช้งาน";
            gv.Columns[ConstColumns.CREATE_AT].HeaderText = "วันเวลาสร้าง";
            gv.Columns[ConstColumns.CREATE_BY].HeaderText = "ผู้สร้าง";
            gv.Columns[ConstColumns.MODIFIED_AT].HeaderText = "วันเวลาแก้ไข";
            gv.Columns[ConstColumns.MODIFIED_BY].HeaderText = "ผู้แก้ไข";

            gv.Columns[ConstColumns.UNIT_CODE_QTY].Visible = false;
            gv.Columns[ConstColumns.UNIT_CODE_WGH].Visible = false;


        }

        private void FillProductGroup()
        {
            var coll = ProductGroupController.GetAllProudctGroups();
            coll.Insert(0, new ProductGroup
            {
                ProductGroupCode = 0,
                ProductGroupName = "--ทั้งหมด--"
            });
            comboxProductGroup.ValueMember = "ProductGroupCode";
            comboxProductGroup.DisplayMember = "ProductGroupName";
            comboxProductGroup.DataSource = coll;
        }
    }
}
