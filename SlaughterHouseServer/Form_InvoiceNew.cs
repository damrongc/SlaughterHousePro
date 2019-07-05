﻿using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_InvoiceNew : Form
    {
        public string orderNo { get; set; }
        public DateTime orderDate { get; set; }
        public string customerCode { get; set; }
         
        public Form_InvoiceNew()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            gv.CellContentClick += Gv_CellContentClick;
            gv.ReadOnly = true;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;

            gvDt.ReadOnly = true;
            gvDt.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gvDt.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gvDt.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gvDt.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gvDt.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvDt.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gvDt.EnableHeadersVisualStyles = false;
                
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

                        case "Select":
                            try
                            {
                                this.orderNo = gv.Rows[e.RowIndex].Cells[1].Value.ToString();

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
            var coll = OrderController.GetOrderMakeInvoice(this.orderDate, this.customerCode);
            gv.DataSource = coll;

            gv.Columns[2].HeaderText = "เลขที่ใบสั่งขาย";
            gv.Columns[3].HeaderText = "วันที่สั่งขาย";
            gv.Columns[4].HeaderText = "ลูกค้า";
            gv.Columns[5].HeaderText = "ใช้งาน";
            gv.Columns[6].HeaderText = "ผู้สร้าง";

            gv.Columns[5].Visible = false;
            LoadSoStock();
        }
        private void LoadSoStock()
        {

            var coll = OrderItemController.GetOrderItemsMapStock(gv.Rows[gv.CurrentCell.RowIndex].Cells[1].Value.ToString());
            gvDt.DataSource = coll;

            gvDt.Columns[1].HeaderText = "สินค้า";
            gvDt.Columns[2].HeaderText = "ปริมาณ";
            gvDt.Columns[3].HeaderText = "น้ำหนัก"; 
            gvDt.Columns[0].Visible = false;
        }
    }
}
 