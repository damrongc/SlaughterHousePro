using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_LovProduct : Form
    {
        public string productCode { get; set; }
        public string productName { get; set; }
        //public string productSlipNo { get; set; }

        DataTable dtProduct;
        public DataTable dtResultProduct;


        public Form_LovProduct()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            gv.CellContentClick += Gv_CellContentClick;
            gv.DataBindingComplete += Gv_DataBindingComplete;

            gv.ReadOnly = false;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;

            this.Load += Form_Load;
            this.Shown += Form_Shown;

            this.comboxProductGroup.SelectedIndexChanged += ComboxProductGroup_SelectedIndexChanged;
        }
        private void Form_Shown(object sender, System.EventArgs e)
        {

        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            FillProductGroup();
            LoadData();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        #region Event Focus, KeyDown 
        private void ComboxProductGroup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadData();
        }
        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            gv.Columns[ConstColumns.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gv.Columns[ConstColumns.PRODUCT_NAME].HeaderText = "ชื่อสินค้า";
            //gv.Columns[ConstColumns.UNIT_NAME].HeaderText = "หน่วยสินค้า";
            gv.Columns[ConstColumns.UNIT_NAME_QTY].HeaderText = "หน่วยปริมาณ";
            gv.Columns[ConstColumns.UNIT_NAME_WGH].HeaderText = "หน่วยน้ำหนัก";
            gv.Columns[ConstColumns.PACKING_SIZE].HeaderText = "ขนาดบรรจุ";

            gv.Columns[ConstColumns.UNIT_CODE_QTY].Visible = false;
            gv.Columns[ConstColumns.UNIT_CODE_WGH].Visible = false;
            gv.Columns[ConstColumns.UNIT_NAME_QTY].Visible = false;
            gv.Columns[ConstColumns.UNIT_NAME_WGH].Visible = false;
            gv.Columns[ConstColumns.ISSUE_UNIT_METHOD].Visible = false;

            gv.Columns[ConstColumns.PRODUCT_CODE].ReadOnly = true;
            gv.Columns[ConstColumns.PRODUCT_NAME].ReadOnly = true;
            gv.Columns[ConstColumns.UNIT_NAME_QTY].ReadOnly = true;
            gv.Columns[ConstColumns.UNIT_NAME_WGH].ReadOnly = true;

            gv.Columns[ConstColumns.SELECT_COL].ReadOnly = false;

            foreach (DataGridViewColumn column in gv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        #endregion

        #region Event Click 
        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                //{
                //    switch (senderGrid.Columns[e.ColumnIndex].Name)
                //    {
                //        case "select_col":
                //            try
                //            {
                //                this.productCode = gv.Rows[e.RowIndex].Cells[ConstColumns.PRODUCT_CODE].Value.ToString();
                //                this.productName = gv.Rows[e.RowIndex].Cells[ConstColumns.PRODUCT_NAME].Value.ToString();
                //                this.DialogResult = DialogResult.OK;
                //                this.Close();
                //            }
                //            catch (System.Exception ex)
                //            {
                //                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            }
                //            break;
                //    }
                //}
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
                {
                    try
                    {
                        this.productCode = gv.Rows[e.RowIndex].Cells[ConstColumns.PRODUCT_CODE].Value.ToString();
                        this.productName = gv.Rows[e.RowIndex].Cells[ConstColumns.PRODUCT_NAME].Value.ToString();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dtProduct = new DataTable();
            dtProduct = ProductController.GetProductActive(comboxProductGroup.SelectedValue.ToString(), txtProductCode.Text, txtProductName.Text);
            if (dtProduct != null)
            {
                gv.DataSource = dtProduct;
            }
        }
        private void FillProductGroup()
        {
            //bool showSelectAllflag = true;
            //var coll = ProductGroupController.GetAllProudctGroups(showSelectAllflag);
            //comboxProductGroup.ValueMember = "ProductGroupCode";
            //comboxProductGroup.DisplayMember = "ProductGroupName"; 

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
