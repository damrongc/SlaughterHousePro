﻿using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_Bom : Form
    {

        public Form_Bom()
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
             
            LoadBom();
        }

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //gv.Columns[GlobalsColumn.ORDER_NO].HeaderText = "เลขที่ใบสั่งขาย";
            //gv.Columns[GlobalsColumn.REQUEST_DATE].HeaderText = "วันที่ต้องการสินค้า";
            //gv.Columns[GlobalsColumn.CUSTOMER_NAME].HeaderText = "ลูกค้า";
            //gv.Columns[GlobalsColumn.COMMENTS].HeaderText = "หมายเหตุ";
            //gv.Columns[GlobalsColumn.ORDER_FLAG].HeaderText = "สถานะ";
            //gv.Columns[GlobalsColumn.INVOICE_FLAG].HeaderText = "สถานะออกใบแจ้งหนี้";
            //gv.Columns[GlobalsColumn.ACTIVE].HeaderText = "ใช้งาน";
            //gv.Columns[GlobalsColumn.CREATE_AT].HeaderText = "วันเวลาสร้าง";
            //gv.Columns[GlobalsColumn.CREATE_BY].HeaderText = "ผู้สร้าง";

            //gv.Columns[GlobalsColumn.ORDER_FLAG].Visible = false;
            //gv.Columns[GlobalsColumn.INVOICE_FLAG].Visible = false;
            //gv.Columns[GlobalsColumn.ACTIVE].Visible = false;
            //gv.Columns[GlobalsColumn.CREATE_BY].Visible = false;

            
        }


        private void GvDt_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //gvDt.Columns[GlobalsColumn.SEQ].HeaderText = "ลำดับ";
            //gvDt.Columns[GlobalsColumn.PRODUCT_CODE].HeaderText = "รหัสสินค้า";
 

            //gvDt.Columns[GlobalsColumn.SEQ].Visible = false;
            //gvDt.Columns[GlobalsColumn.PRODUCT_CODE].Visible = false;
            //gvDt.Columns[GlobalsColumn.UNIT_CODE].Visible = false;
            //gvDt.Columns[GlobalsColumn.ISSUE_UNIT_METHOD].Visible = false;


            //gvDt.Columns[GlobalsColumn.QTY_WGH].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvDt.Columns[GlobalsColumn.UNLOAD_QTY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvDt.Columns[GlobalsColumn.UNLOAD_WGH].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //gvDt.Columns[GlobalsColumn.QTY_WGH].DefaultCellStyle.Format = "N2";
            //gvDt.Columns[GlobalsColumn.UNLOAD_QTY].DefaultCellStyle.Format = "N0";
            //gvDt.Columns[GlobalsColumn.UNLOAD_WGH].DefaultCellStyle.Format = "N2";
        }

        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                string bomCode = gv.Rows[e.RowIndex].Cells["bomcode"].Value.ToString();


                if ((senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn || senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) && e.RowIndex >= 0)
                {
                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {
                        case "Edit":
                            var frm = new Form_BomAddEdit
                            {
                                bomCode = bomCode
                            };
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                LoadBom();
                            }
                            break;
                        case "Print":
                            break;
                    }
                }
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
                {
                    LoadItem(bomCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, System.EventArgs e)
        {
            LoadBom();
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_BomAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
            LoadBom();
        }

      

        private void LoadBom()
        {
            //var farmCtrl = new FarmController();
            var coll = BomController.GetAllBoms(TxtFilter.Text);
            gv.DataSource = coll;
            //LoadItem("");
        }
        private void LoadItem(string bomCode)
        {
            DataTable dtBomItem = new DataTable("BOM_ITEM");
            dtBomItem = BomItemController.GetBomItem(bomCode);
            gvDt.DataSource = dtBomItem;
        }

      
    }
}