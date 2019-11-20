using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_Customer : Form
    {
        public Form_Customer()
        {
            InitializeComponent();
            UserSettingsComponent();
        }

        private void UserSettingsComponent()
        {
            BtnAdd.Click += BtnAdd_Click;
            BtnSearch.Click += BtnSearch_Click;
            gv.CellContentClick += Gv_CellContentClick;

            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;
            Populate();
        }

        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    string customerCode = gv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    var frm = new Form_CustomerAddEdit
                    {
                        customerCode = customerCode
                    };
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Populate();
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
            Populate();
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_CustomerAddEdit
            {
                customerCode = ""
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Populate();
            }
        }

        private void Populate()
        {
            var coll = CustomerController.GetAllCustomers(TxtFilter.Text.Trim());
            gv.DataSource = coll;

            gv.Columns[ConstColumns.CustomerCode].HeaderText = "รหัสลูกค้า";
            gv.Columns[ConstColumns.CustomerName].HeaderText = "ชื่อลูกค้า";
            gv.Columns[ConstColumns.ClassName].HeaderText = "กลุ่มลูกค้า";
            gv.Columns[ConstColumns.Address].HeaderText = "ที่อยู่";
            gv.Columns[ConstColumns.ShipTo].HeaderText = "สถานที่ส่งสินค้า";
            gv.Columns[ConstColumns.TaxId].HeaderText = "เลขที่ผู้เสียภาษี";
            gv.Columns[ConstColumns.ContactNo].HeaderText = "เบอร์ติดต่อ";
            gv.Columns[ConstColumns.Active].HeaderText = "ใช้งาน";
            gv.Columns[ConstColumns.CreateAt].HeaderText = "วันเวลาสร้าง";
            gv.Columns[ConstColumns.CreateBy].HeaderText = "ผู้สร้าง";
            gv.Columns[ConstColumns.ModifiedAt].HeaderText = "วันเวลาแก้ไข";
            gv.Columns[ConstColumns.ModifiedBy].HeaderText = "ผู้แก้ไข";

            gv.Columns[ConstColumns.ClassId].Visible = false;

            gv.Columns[ConstColumns.CreateAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            gv.Columns[ConstColumns.ModifiedAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

        }
    }
}
