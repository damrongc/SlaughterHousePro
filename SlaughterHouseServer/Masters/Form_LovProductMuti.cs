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
    public partial class Form_LovProductMuti : Form
    {
        public string orderNo { get; set; }
        //public string productSlipNo { get; set; }

        DataTable dtProduct;
        public DataTable dtResultProduct;
        public bool forSaleFlag = false;


        public Form_LovProductMuti()
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
            gv.Columns[ConstColumns.SELECT_COL].HeaderText = "เลือก";

            gv.Columns[ConstColumns.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gv.Columns[ConstColumns.PRODUCT_NAME].HeaderText = "ชื่อสินค้า"; 
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

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {

                        case "Edit":
                            //var frm = new Form_OrderDetail();
                            //frm.orderNo = txtProductSlip.Text;
                            //frm.orderDate = dtpProductSlipDate.Value;

                            //frm.productCode = dtOrderItem.Rows[e.RowIndex][ConstColumns.PRODUCT_CODE].ToString();
                            //frm.qtyWgh = Convert.ToDecimal(dtOrderItem.Rows[e.RowIndex][ConstColumns.QTY_WGH]);
                            //frm.issueUnitMethod = dtOrderItem.Rows[e.RowIndex][ConstColumns.ISSUE_UNIT_METHOD].ToString();
                            //frm.unitCode = Convert.ToInt16(dtOrderItem.Rows[e.RowIndex]["unit_code"]);
                            //frm.unitName = dtOrderItem.Rows[e.RowIndex]["unit_name"].ToString();
                            //if (frm.ShowDialog() == DialogResult.OK)
                            //{
                            //    dtOrderItem.Rows[e.RowIndex][ConstColumns.PRODUCT_CODE] = frm.productCode;
                            //    dtOrderItem.Rows[e.RowIndex]["product_name"] = frm.productName;
                            //    dtOrderItem.Rows[e.RowIndex][ConstColumns.QTY_WGH] = frm.qtyWgh;
                            //    dtOrderItem.Rows[e.RowIndex][ConstColumns.ISSUE_UNIT_METHOD] = frm.issueUnitMethod;
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
            dtProduct = new DataTable();
            if (forSaleFlag == true)
            {
                dtProduct = ProductController.GetProductsForSale(comboxProductGroup.SelectedValue.ToString(), txtProductCode.Text, txtProductName.Text);
            }
            else
            {
                bool mutiSelectFlag = true;
                dtProduct = ProductController.GetProductActive(comboxProductGroup.SelectedValue.ToString(),txtProductCode.Text, txtProductName.Text, mutiSelectFlag);
            }
            
            if (dtProduct != null)
            {
                gv.DataSource = dtProduct;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                dtResultProduct = new DataTable();
                dtResultProduct = dtProduct.Clone();
                foreach (DataRow row in dtProduct.Rows)
                {
                    try
                    {
                        if (int.Parse(row[ConstColumns.SELECT_COL].ToString()) == 1)
                        {
                            DataRow drNew = dtResultProduct.NewRow();
                            drNew[ConstColumns.SELECT_COL] = row[ConstColumns.SELECT_COL];
                            drNew[ConstColumns.PRODUCT_CODE] = row[ConstColumns.PRODUCT_CODE];
                            drNew[ConstColumns.PRODUCT_NAME] = row[ConstColumns.PRODUCT_NAME];
                            drNew[ConstColumns.ISSUE_UNIT_METHOD] = row[ConstColumns.ISSUE_UNIT_METHOD];
                            drNew[ConstColumns.UNIT_CODE_QTY] = row[ConstColumns.UNIT_CODE_QTY];
                            drNew[ConstColumns.UNIT_NAME_QTY] = row[ConstColumns.UNIT_NAME_QTY];
                            drNew[ConstColumns.UNIT_CODE_WGH] = row[ConstColumns.UNIT_CODE_WGH];
                            drNew[ConstColumns.UNIT_NAME_WGH] = row[ConstColumns.UNIT_NAME_WGH];
                            drNew[ConstColumns.PACKING_SIZE] = row[ConstColumns.PACKING_SIZE];
                            dtResultProduct.Rows.Add(drNew);
                        }
                    }
                    catch
                    {

                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {

            }

        }

        private void FillProductGroup()
        {
            //bool showSelectAllflag = true;
            //comboxProductGroup.DataSource = ProductGroupController.GetAllProudctGroups(showSelectAllflag);
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
