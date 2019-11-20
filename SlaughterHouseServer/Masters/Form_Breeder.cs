using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_Breeder : Form
    {
        public Form_Breeder()
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
                    string breederCode = gv.Rows[e.RowIndex].Cells[ConstColumns.BREEDER_CODE].Value.ToString();
                    var frm = new Form_BreederAddEdit
                    {
                        breederCode = breederCode
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
            var frm = new Form_BreederAddEdit
            {
                breederCode = ""
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Populate();
            }
        }

        private void Populate()
        {

            DataTable coll = BreederController.GetAllBreeders(TxtFilter.Text.Trim());
            gv.DataSource = coll;

            gv.Columns[ConstColumns.BREEDER_CODE].HeaderText = "รหัสสายพันธุ์";
            gv.Columns[ConstColumns.BREEDER_NAME].HeaderText = "ชื่อสายพันธุ์";
            gv.Columns[ConstColumns.ACTIVE].HeaderText = "ใช้งาน";
            gv.Columns[ConstColumns.CREATE_AT].HeaderText = "วันเวลาสร้าง";
            gv.Columns[ConstColumns.CREATE_BY].HeaderText = "ผู้สร้าง";
            gv.Columns[ConstColumns.MODIFIED_AT].HeaderText = "วันเวลาแก้ไข";
            gv.Columns[ConstColumns.MODIFIED_BY].HeaderText = "ผู้แก้ไข";

            gv.Columns[ConstColumns.BREEDER_CODE].Visible = false;

            gv.Columns[ConstColumns.CREATE_AT].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            gv.Columns[ConstColumns.MODIFIED_AT].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }
    }
}
