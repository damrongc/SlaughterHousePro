using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_ProductionOrder : Form
    {
        public Form_ProductionOrder()
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
              
            LoadOrder();
        }

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
              
        }

        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    string poNo = gv.Rows[e.RowIndex].Cells[2].Value.ToString();

                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {

                        case "Edit":
                            var frm = new Form_ProductionOrderAddEdit
                            {
                                poNo = poNo
                            };
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                LoadOrder();
                            }
                            break;
                        case "Print":
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, System.EventArgs e)
        {
            LoadOrder();
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_ProductionOrderAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadOrder();
            }
        }
         

        private void LoadOrder()
        {
            //var farmCtrl = new FarmController();
            var coll = ProductionOrderController.GetAllProductionOrders(dtpPoDate.Value );
            gv.DataSource = coll;

            gv.Columns[2].HeaderText = "เลขที่ใบเบิก";
            gv.Columns[3].HeaderText = "วันที่เบิก"; 
            gv.Columns[4].HeaderText = "ใช้งาน";
            gv.Columns[5].HeaderText = "วันเวลาสร้าง";
            gv.Columns[6].HeaderText = "ผู้สร้าง";
        }
         
    }
}  