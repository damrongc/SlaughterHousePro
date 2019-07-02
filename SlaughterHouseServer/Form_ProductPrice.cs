using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_ProductPrice : Form
    {
        public Form_ProductPrice()
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
             
            LoadCustomer();
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
                    string orderNo = gv.Rows[e.RowIndex].Cells[2].Value.ToString();

                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {

                        case "Edit":
                            var frm = new Form_OrderAddEdit
                            {
                                orderNo = orderNo
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
            var frm = new Form_OrderAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadOrder();
            }
        }

        private void LoadCustomer()
        {

            var coll = ProductController.GetAllProducts();
            coll.Insert(0, new Product
            {
                ProductCode  = "",
                ProductName  = "--เลือก--"
            });
            cboProduct.DisplayMember = "ProductCode";
            cboProduct.ValueMember = "ProductName";
            cboProduct.DataSource = coll;
        }

        private void LoadOrder()
        {
            //var farmCtrl = new FarmController();
            var coll = ProductPriceController.GetAllProductPrices(dtpStartDate.Value, cboProduct.SelectedValue.ToString());
            gv.DataSource = coll;

            gv.Columns[1].HeaderText = "รหัสสินค้า";
            gv.Columns[2].HeaderText = "ชื่อสินค้า";
            gv.Columns[3].HeaderText = "วันที่เริ่มต้น";
            gv.Columns[4].HeaderText = "วินที่สิ้นสุด";
            gv.Columns[5].HeaderText = "ราคาต่อหน่วย"; 
            gv.Columns[6].HeaderText = "หน่วยคำนวณขาย";
            gv.Columns[7].HeaderText = "จำนวนวัน";

            gv.Columns[7].Visible = false;
        }
    }
}  