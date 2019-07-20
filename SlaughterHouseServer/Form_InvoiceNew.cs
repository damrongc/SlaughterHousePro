using SlaughterHouseLib;
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
        public DateTime requestDate { get; set; }
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
             
            //BtnRefresh.Click += BtnRefresh_Click;
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

        //private void BtnRefresh_Click(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        LoadData();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //else
                //{
                //    try
                //    {
                //        if (gv.Rows.Count > 0)
                //        {
                //            LoadDataDetail();
                //        }
                //    }
                //    catch (System.Exception ex)
                //    {

                //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    } 
                //}
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
                { 
                    LoadDataDetail(gv.Rows[gv.CurrentCell.RowIndex].Cells[1].Value.ToString());
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
            var coll = OrderController.GetOrderReadyToSell(this.requestDate, this.customerCode);
            gv.DataSource = coll;

            gv.Columns[1].HeaderText = "เลขที่ใบสั่งขาย";
            gv.Columns[2].HeaderText = "วันที่ต้องการสินค้า";
            gv.Columns[3].HeaderText = "ลูกค้า";
            gv.Columns[4].HeaderText = "วันเวลาสร้าง";
            gv.Columns[5].HeaderText = "ผู้สร้าง";
             
            if (gv.Rows.Count > 0)
            {
                LoadDataDetail("");
            }
        }
        private void LoadDataDetail(string orderNo)
        { 
            DataTable dt = new DataTable();
            dt = OrderItemController.GetOrderItemReadyToSell(orderNo);
            gvDt.DataSource = dt;
            gvDt.Columns[0].HeaderText = "ลำดับ";
            gvDt.Columns[1].HeaderText = "รหัสสินค้า"; 
            gvDt.Columns[2].HeaderText = "ชื่อสินค้า";
            gvDt.Columns[3].HeaderText = "หน่วยคำนวณ";
            gvDt.Columns[4].HeaderText = "ปริมาณ";
            gvDt.Columns[5].HeaderText = "น้ำหนัก";
            gvDt.Columns[6].HeaderText = "ราคาต่อหน่วย";
            gvDt.Columns[7].HeaderText = "ราคา";
            
            gvDt.Columns[1].Visible = false;
            gvDt.Columns[3].Visible = false;
            gvDt.Columns[6].Visible = false;
            gvDt.Columns[7].Visible = false;
        } 
    }
}
 