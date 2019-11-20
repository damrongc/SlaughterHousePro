using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_Truck : Form
    {

        public Form_Truck()
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


            LoadTruck();
        }

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            gv.Columns[ConstColumns.TRUCK_ID].Visible = false;
            gv.Columns[ConstColumns.TRUCK_NO].HeaderText = "ทะเบียนรถ";
            gv.Columns[ConstColumns.DRIVER].HeaderText = "ชื่อคนขับรถ";

            gv.Columns[ConstColumns.ACTIVE].HeaderText = "ใช้งาน";
            gv.Columns[ConstColumns.CREATE_AT].HeaderText = "วันเวลาสร้าง";
            gv.Columns[ConstColumns.CREATE_BY].HeaderText = "ผู้สร้าง";

            gv.Columns[ConstColumns.MODIFIED_AT].HeaderText = "วันเวลาแก้ไข";
            gv.Columns[ConstColumns.MODIFIED_BY].HeaderText = "ผู้แก้ไข";
            gv.Columns[ConstColumns.TRUCK_TYPE_ID].Visible = false;
            gv.Columns[ConstColumns.TRUCK_TYPE_DESC].Visible = false;

            gv.Columns[ConstColumns.CREATE_AT].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            gv.Columns[ConstColumns.MODIFIED_AT].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

        }


        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                Int32 truckId = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[ConstColumns.TRUCK_ID].Value );


                if ((senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn || senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) && e.RowIndex >= 0)
                {
                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {
                        case "Edit":
                            var frm = new Form_TruckAddEdit
                            {
                                truckId = truckId
                            };
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                LoadTruck();
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
            LoadTruck();
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_TruckAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
            LoadTruck();
        }



        private void LoadTruck()
        {
            //var farmCtrl = new FarmController();
            var coll = TruckController.GetAllTrucks(TxtFilter.Text);
            gv.DataSource = coll;
            //LoadItem("");
        }



    }
}