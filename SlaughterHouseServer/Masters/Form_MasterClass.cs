using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_MasterClass : Form
    {
        public Form_MasterClass()
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
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;


            gvCustomer.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gvCustomer.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gvCustomer.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gvCustomer.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gvCustomer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCustomer.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gvCustomer.EnableHeadersVisualStyles = false;

            Populate();
        }

        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[1].Value);
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {

                    var frm = new Form_MasterClassAddEdit
                    {
                        customerClassId = id
                    };
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Populate();
                    }
                }
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex >= 0)
                {
                    var customers = MasterClassController.GetCustomersByClass(id, "2020-01-24");
                    var coll = customers.Select(p => new
                    {
                        p.CustomerCode,
                        p.CustomerName
                    }).ToList();
                    gvCustomer.DataSource = coll;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, System.EventArgs e)
        {
            try
            {
                Populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new Form_MasterClassAddEdit
                {
                    customerClassId = 0
                };
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Populate()
        {
            try
            {
                var coll = MasterClassController.GetAllMasterClass(TxtFilter.Text.Trim());
                gv.DataSource = coll;

                //gv.Columns[ConstColumns.ClassId].HeaderText = "รหัสระดับลุกค้า";
                //gv.Columns[ConstColumns.ClassName].HeaderText = "ชื่อระดับลุกค้า";
                //gv.Columns[ConstColumns.Active].HeaderText = "ใช้งาน";
                //gv.Columns[ConstColumns.CreateAt].HeaderText = "วันเวลาสร้าง";
                //gv.Columns[ConstColumns.CreateBy].HeaderText = "ผู้สร้าง";
                //gv.Columns[ConstColumns.ModifiedAt].HeaderText = "วันเวลาแก้ไข";
                //gv.Columns[ConstColumns.ModifiedBy].HeaderText = "ผู้แก้ไข";


                gv.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                gv.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                //gv.Columns[7].Visible = false;

                gvCustomer.DataSource = null;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
