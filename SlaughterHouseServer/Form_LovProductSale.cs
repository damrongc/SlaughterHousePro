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
    public partial class Form_LovProductSale : Form
    {
        public string orderNo { get; set; }
        //public string productSlipNo { get; set; }

        DataTable dtProduct;
        public DataTable dtResultProduct;


        public Form_LovProductSale()
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


        }
        private void Form_Shown(object sender, System.EventArgs e)
        {

        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void DtpRequestDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnOk.Focus();
            }
        }

        #region Event Focus, KeyDown 
        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            gv.Columns[GlobalsColumn.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gv.Columns[GlobalsColumn.PRODUCT_NAME].HeaderText = "ชื่อสินค้า";
            gv.Columns[GlobalsColumn.ISSUE_UNIT_METHOD].HeaderText = "หน่วยคำนวณ";

            gv.Columns[GlobalsColumn.PRODUCT_CODE].ReadOnly = true;
            gv.Columns[GlobalsColumn.PRODUCT_NAME].ReadOnly = true;
            gv.Columns[GlobalsColumn.UNIT_NAME].ReadOnly = true;
            gv.Columns[GlobalsColumn.SELECT_COL].ReadOnly = false;

            //gv.Columns[GlobalsColumn.UNIT_CODE ].HeaderText = "รหัสหน่วยสินค้า";


            //gv.Columns[GlobalsColumn.ISSUE_UNIT_METHOD].Visible = false;
            //gv.Columns[GlobalsColumn.UNIT_CODE].Visible = false;
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

                            //frm.productCode = dtOrderItem.Rows[e.RowIndex][GlobalsColumn.PRODUCT_CODE].ToString();
                            //frm.qtyWgh = Convert.ToDecimal(dtOrderItem.Rows[e.RowIndex][GlobalsColumn.QTY_WGH]);
                            //frm.issueUnitMethod = dtOrderItem.Rows[e.RowIndex][GlobalsColumn.ISSUE_UNIT_METHOD].ToString();
                            //frm.unitCode = Convert.ToInt16(dtOrderItem.Rows[e.RowIndex]["unit_code"]);
                            //frm.unitName = dtOrderItem.Rows[e.RowIndex]["unit_name"].ToString();
                            //if (frm.ShowDialog() == DialogResult.OK)
                            //{
                            //    dtOrderItem.Rows[e.RowIndex][GlobalsColumn.PRODUCT_CODE] = frm.productCode;
                            //    dtOrderItem.Rows[e.RowIndex]["product_name"] = frm.productName;
                            //    dtOrderItem.Rows[e.RowIndex][GlobalsColumn.QTY_WGH] = frm.qtyWgh;
                            //    dtOrderItem.Rows[e.RowIndex][GlobalsColumn.ISSUE_UNIT_METHOD] = frm.issueUnitMethod;
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
            dtProduct = ProductController.GetProductsForSale(txtProductCode.Text, txtProductName.Text);
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
                        if (int.Parse(row[GlobalsColumn.SELECT_COL].ToString()) == 1)
                        {
                            DataRow drNew = dtResultProduct.NewRow();
                            drNew[GlobalsColumn.SELECT_COL] = row[GlobalsColumn.SELECT_COL];
                            drNew[GlobalsColumn.PRODUCT_CODE] = row[GlobalsColumn.PRODUCT_CODE];
                            drNew[GlobalsColumn.PRODUCT_NAME] = row[GlobalsColumn.PRODUCT_NAME];
                            drNew[GlobalsColumn.ISSUE_UNIT_METHOD] = row[GlobalsColumn.ISSUE_UNIT_METHOD];
                            drNew[GlobalsColumn.UNIT_CODE] = row[GlobalsColumn.UNIT_CODE];
                            drNew[GlobalsColumn.UNIT_NAME] = row[GlobalsColumn.UNIT_NAME];
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





            //drNew["PRODUCT_CODE"] = dt.Rows[idxRow]["PRODUCT_CODE"];
            //drNew["PRODUCT_NAME"] = dt.Rows[idxRow]["PRODUCT_NAME"];
            //drNew["LOT_NO"] = "NA";
            //drNew["LOCATION_CODE"] = 0;
            //drNew["LOCATION_NAME"] = "NA";
            //drNew["QTY_WGH"] = Convert.ToDecimal(dt.Rows[idxRow]["QTY_WGH"]);
            //drNew["UNIT_NAME"] = dt.Rows[idxRow]["UNIT_NAME"];
            //drNew["ISSUE_UNIT_METHOD"] = dt.Rows[idxRow]["ISSUE_UNIT_METHOD"];
            //drNew["QTY_WGH_LOCATION"] = cfQtyWgh;
            //dt.Rows.Add(drNew);

            catch (Exception ex)
            {

            }

        }



        //private void LoadCustomer()
        //{
        //    var coll = CustomerController.GetAllCustomers();
        //    cboCustomer.DisplayMember = "CustomerName";
        //    cboCustomer.ValueMember = "CustomerCode";
        //    cboCustomer.DataSource = coll;
        //}

    }
}
