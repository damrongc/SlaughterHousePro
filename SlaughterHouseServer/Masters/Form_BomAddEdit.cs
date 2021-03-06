﻿using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_BomAddEdit : Form
    {
        public string bomCode { get; set; }
        string productCode { get; set; }
        DataTable dtBomItem;

        public Form_BomAddEdit()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            gv.CellContentClick += Gv_CellContentClick;
            gv.DataBindingComplete += Gv_DataBindingComplete;
            //gv.ReadOnly = true;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;

            this.Load += Form_Load;
            this.Shown += Form_Shown;

            btnAddOrderItem.Click += BtnAddOrderItem_Click;
            btnLovProduct.Click += BtnLovProduct_Click;
            //KeyDown
        }
        private void Form_Shown(object sender, System.EventArgs e)
        {

        }
        private void Form_Load(object sender, System.EventArgs e)
        {
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

        #endregion

        #region Event Focus, KeyDown
        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gv.Columns[ConstColumns.BOM_CODE].HeaderText = "รหัส Bom";
            gv.Columns[ConstColumns.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
            gv.Columns[ConstColumns.PRODUCT_NAME].HeaderText = "ชื่อสินค้า";
            gv.Columns[ConstColumns.MUTIPLY_QTY].Visible = false;
            gv.Columns[ConstColumns.MUTIPLY_WGH].Visible = false;
            gv.Columns[ConstColumns.BOM_CODE].Visible = false;
            gv.Columns[ConstColumns.PRODUCT_NAME].ReadOnly = true;

            foreach (DataGridViewColumn column in gv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        #endregion

        #region Event Click
        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                SaveBom();
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
                SaveBom();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bomCode = "";
                txtBomCode.Text = "";
                txtBomCode.Focus();
                chkActive.Checked = true;
                LoadDetail();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLovProduct_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new Form_LovProduct();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtProductName.Text = frm.productName;
                    this.productCode = frm.productCode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnAddOrderItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new Form_LovProductMuti();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataRow dr;
                    foreach (DataRow row in frm.dtResultProduct.Rows)
                    {
                        DataRow[] results = dtBomItem.Select($"product_code = '{row[ConstColumns.PRODUCT_CODE]}' ");

                        if (results.Length == 0)
                        {
                            dr = dtBomItem.NewRow();
                            dr[ConstColumns.PRODUCT_CODE] = row[ConstColumns.PRODUCT_CODE];
                            dr[ConstColumns.PRODUCT_NAME] = row[ConstColumns.PRODUCT_NAME];
                            dr[ConstColumns.MUTIPLY_QTY] = 1;
                            dr[ConstColumns.MUTIPLY_WGH] = 1;
                            dtBomItem.Rows.Add(dr);
                            dtBomItem.AcceptChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        case "Del":
                            dtBomItem.Rows[e.RowIndex].Delete();
                            dtBomItem.AcceptChanges();
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
            txtBomCode.Enabled = false;

            if (bomCode != null)
            {
                Bom bom = BomController.GetBomByCode(this.bomCode);
                txtBomCode.Text = bom.BomCode.ToString();
                txtProductName.Text = bom.Product.ProductName;
                productCode = bom.Product.ProductCode;
                BtnSaveAndNew.Visible = false;
                txtProductName.Enabled = false;
                btnLovProduct.Enabled = false;
            }
            else
            {

            }
            LoadDetail();
        }
        private void LoadDetail()
        {
            dtBomItem = new DataTable("ORDERS_ITEM");
            dtBomItem = BomItemController.GetBomItem(bomCode);
            gv.DataSource = dtBomItem;
        }

        private void SaveBom()
        {
            try
            {
                if (dtBomItem.Rows.Count == 0)
                {
                    throw new Exception("กรุณาเลือกสินค้าย่อย");
                }

                var bomItems = new List<BomItem>();
                int seq = 0;
                foreach (DataRow row in dtBomItem.Rows)
                {

                    seq++;
                    bomItems.Add(new BomItem
                    {
                        BomCode = String.IsNullOrEmpty(txtBomCode.Text) == true ? 0 : Convert.ToInt32(txtBomCode.Text),
                        Product = new Product
                        {
                            ProductCode = row[ConstColumns.PRODUCT_CODE].ToString(),
                            ProductName = row[ConstColumns.PRODUCT_NAME].ToString(),
                        },
                        MutiplyQty = 1,
                        MutiplyWgh = 1,
                        //MutiplyQty = row[ConstColumns.ISSUE_UNIT_METHOD].ToString() == "Q" ? Convert.ToInt16(row[ConstColumns.QTY_WGH]) : 0,
                        //MutiplyWgh = row[ConstColumns.ISSUE_UNIT_METHOD].ToString() == "W" ? Convert.ToDecimal(row[ConstColumns.QTY_WGH]) : 0,
                    });
                }

                var bom = new Bom
                {
                    BomCode = string.IsNullOrEmpty(txtBomCode.Text) == true ? 0 : Convert.ToInt32(txtBomCode.Text),
                    Product = new Product
                    {
                        ProductCode = this.productCode,
                        ProductName = txtProductName.Text,
                    },
                    Active = chkActive.Checked,
                    CreateBy = "system",
                    ModifiedBy = "system",
                    BomItems = bomItems
                };

                if (string.IsNullOrEmpty(txtBomCode.Text))
                {
                    BomController.Insert(bom);
                }
                else
                {
                    BomController.Update(bom);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}
