﻿using SlaughterHouseLib;
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
      

        #region Event Focus, KeyDown 
        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            gv.Columns[GlobalsColumn.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gv.Columns[GlobalsColumn.PRODUCT_NAME].HeaderText = "ชื่อสินค้า";
            gv.Columns[GlobalsColumn.UNIT_NAME].HeaderText = "หน่วยสินค้า";

             gv.Columns[GlobalsColumn.UNIT_CODE].Visible = false;
             gv.Columns[GlobalsColumn.ISSUE_UNIT_METHOD].Visible = false;

            gv.Columns[GlobalsColumn.PRODUCT_CODE].ReadOnly = true;
            gv.Columns[GlobalsColumn.PRODUCT_NAME].ReadOnly = true;
            gv.Columns[GlobalsColumn.UNIT_NAME].ReadOnly = true;
            gv.Columns[GlobalsColumn.SELECT_COL].ReadOnly = false;

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
                        case "select_col":
                            try
                            {
                                this.productCode = gv.Rows[e.RowIndex].Cells[GlobalsColumn.PRODUCT_CODE].Value.ToString();
                                this.productName = gv.Rows[e.RowIndex].Cells[GlobalsColumn.PRODUCT_NAME].Value.ToString();

                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            catch (System.Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
            dtProduct = ProductController.GetProducts(txtProductCode.Text, txtProductName.Text);
            if (dtProduct != null)
            {
                gv.DataSource = dtProduct;
            }

        }
                
    }
}