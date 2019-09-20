using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_ProductionOrderAddEdit : Form
    {
        public string poNo { get; set; }
        DataTable dtPoItem;

        public Form_ProductionOrderAddEdit()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            btnAddPoItem.Click += BtnAddPoItem_Click;
            gv.CellContentClick += Gv_CellContentClick;
            gv.DataBindingComplete += Gv_DataBindingComplete;
            gv.ReadOnly = true;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;

            this.Load += Form_Load;
            this.Shown += Form_Shown;

            //KeyDown  
            dtpPoDate.KeyDown += DtpPoDate_KeyDown;
        }
        private void Form_Shown(object sender, System.EventArgs e)
        {
            dtpPoDate.Focus();
        }
        private void Form_Load(object sender, System.EventArgs e)
        { 
            LoadData();
        }
        private void DtpPoDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtComment.Focus();
            }
        }
       
        #region Event Focus, KeyDown 
        private void TxtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSaveAndNew.Focus();
            }
        }
        private void TxtFarmName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtComment.Focus();
            }
        }
        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
        #endregion

        #region Event Click
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CancelOrder();
                MessageBox.Show("ยกเลิกเอกสาร เรียบร้อยแล้ว", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                SavePo();
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
                SavePo();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                poNo = "";
                txtPoNo.Text = "";
                txtPoNo.Focus(); 
                txtComment.Text = "";
                chkActive.Checked = true;
                LoadDetail();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnAddPoItem_Click(object sender, System.EventArgs e)
        {
            
        var frm = new Form_ProductionOrderDetail();
            frm.qtyWgh = 0;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow dr;
                dr = dtPoItem.NewRow();

                dr["seq"] = 0;
                dr["product_code"] = frm.productCode;
                dr["product_name"] = frm.productName; 
                dr["qty_wgh"] = frm.qtyWgh;
                dr["issue_unit_method"] = frm.issueUnitMethod;
                dr["unit_code"] = frm.unitCode;
                dr["unit_name"] = frm.unitName;
                dtPoItem.Rows.Add(dr);
                dtPoItem.AcceptChanges();
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

                        case "Edit":
                            var frm = new Form_ProductionOrderDetail();
                            frm.poNo = txtPoNo.Text;
                            frm.productCode = dtPoItem.Rows[e.RowIndex]["product_code"].ToString();
                            frm.qtyWgh = Convert.ToDecimal(dtPoItem.Rows[e.RowIndex]["qty_wgh"]);
                            frm.issueUnitMethod = dtPoItem.Rows[e.RowIndex]["issue_unit_method"].ToString();
                            frm.unitCode = Convert.ToInt16(dtPoItem.Rows[e.RowIndex]["unit_code"]);
                            frm.unitName = dtPoItem.Rows[e.RowIndex]["unit_name"].ToString();
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                dtPoItem.Rows[e.RowIndex]["product_code"] = frm.productCode;
                                dtPoItem.Rows[e.RowIndex]["product_name"] = frm.productName;
                                dtPoItem.Rows[e.RowIndex]["qty_wgh"] = frm.qtyWgh;
                                dtPoItem.Rows[e.RowIndex]["issue_unit_method"] = frm.issueUnitMethod;
                                dtPoItem.Rows[e.RowIndex]["unit_code"] = frm.unitCode;
                                dtPoItem.Rows[e.RowIndex]["unit_name"] = frm.unitName;
                                dtPoItem.AcceptChanges();
                                gv.Refresh();
                            }
                            break;
                        case "Del":
                            dtPoItem.Rows[e.RowIndex].Delete();
                            dtPoItem.AcceptChanges();
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
            txtPoNo.Enabled = false;
            ProductionOrder po = ProductionOrderController.GetProductionOrder(this.poNo);
            if (po != null)
            {
                txtPoNo.Text = po.PoNo;
                dtpPoDate.Value = po.PoDate ;
                txtComment.Text = po.Comments;
                chkActive.Checked = po.Active;
                dtpPoDate.Enabled = false;
                BtnSaveAndNew.Visible = false; 
            }
            else
            {
                BtnCancel.Visible = false;
            }
            LoadDetail();
        }
        private void LoadDetail()
        {
            //var orderItem = PoItemController.GetPoItems(orderNo);
            dtPoItem = new DataTable("PO_ITEM");
            dtPoItem = ProductionOrderItemController.GetProductionOrderItems(this.poNo);
         
            gv.DataSource = dtPoItem;
            gv.Columns["seq"].HeaderText = "ลำดับ";
            gv.Columns["product_code"].HeaderText = "รหัสสินค้า";
            gv.Columns["product_name"].HeaderText = "ชื่อสินค้า";
            gv.Columns["qty_wgh"].HeaderText = "จำนวน";
            gv.Columns["issue_unit_method"].HeaderText = "หน่วยคำนวณ";
            gv.Columns["unit_code"].HeaderText = "รหัสหน่วยสินค้า";
            gv.Columns["unit_name"].HeaderText = "หน่วยสินค้า";

            gv.Columns["seq"].Visible = false;
            gv.Columns["issue_unit_method"].Visible = false;
            gv.Columns["unit_code"].Visible = false;
            gv.Columns["unload_qty"].Visible = false;
            gv.Columns["unload_wgh"].Visible = false;
        } 
        private void SavePo()
        {
            try
            {
                var poItems = new List<ProductionOrderItem>();
                int seq = 0;
                foreach (DataRow row in dtPoItem.Rows)
                {
                    seq++;
                    poItems.Add(new ProductionOrderItem
                    {
                        PoNo = txtPoNo.Text,
                        Seq = seq,
                        Product = new Product
                        {
                            ProductCode = row["product_code"].ToString(),
                            ProductName = row["product_name"].ToString(),
                        },
                        PoQty = row["issue_unit_method"].ToString() == "Q" ? Convert.ToInt16(row["qty_wgh"]) : 0,
                        PoWgh = row["issue_unit_method"].ToString() == "W" ? Convert.ToDecimal(row["qty_wgh"]) : 0,
                    });
                }

                var po = new ProductionOrder
                {
                    PoNo = txtPoNo.Text,
                    PoDate  = dtpPoDate.Value, 
                    Comments = txtComment.Text,
                    PoFlag  = 0,
                    Active = chkActive.Checked,
                    CreateBy = "system",
                    ModifiedBy = "system",
                    ProductionOrderItem = poItems,
                };

                if (string.IsNullOrEmpty(txtPoNo.Text)) 
                {
                    ProductionOrderController.Insert(po);
                }
                else{
                    ProductionOrderController.Update (po);
                }
                //ProductionOrderController.InsertOrUpdate(order);

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CancelOrder()
        {
            try
            {
                var po = new ProductionOrder
                {
                    PoNo = txtPoNo.Text,
                    PoDate  = dtpPoDate.Value, 
                    Comments = txtComment.Text,
                    PoFlag = 0,
                    Active = false,
                    CreateBy = "system",
                    ModifiedBy = "system"
                };
                ProductionOrderController.Cancel(po);
            }
            catch (Exception)
            {
                throw;
            }
        }

 
    }
}
