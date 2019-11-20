using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_Farm : Form
    {
        public Form_Farm()
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
                    string farmCode = gv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    var frm = new Form_FarmAddEdit
                    {
                        farmCode = farmCode
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
            var frm = new Form_FarmAddEdit
            {
                farmCode = ""
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Populate();
            }
        }

        private void Populate()
        {

            var coll = FarmController.GetAllFarms(TxtFilter.Text.Trim());
            gv.DataSource = coll;

            gv.Columns[1].HeaderText = "รหัสฟาร์ม";
            gv.Columns[2].HeaderText = "ชื่อฟาร์ม";
            gv.Columns[3].HeaderText = "ที่อยู่";
            gv.Columns[4].HeaderText = "ใช้งาน";
            gv.Columns[5].HeaderText = "วันเวลาสร้าง";
            gv.Columns[6].HeaderText = "ผู้สร้าง";
            gv.Columns[7].HeaderText = "วันเวลาแก้ไข";
            gv.Columns[8].HeaderText = "ผู้แก้ไข";

            gv.Columns[ConstColumns.CreateAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            gv.Columns[ConstColumns.ModifiedAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }
    }
}
