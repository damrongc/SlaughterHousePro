using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_Plant : Form
    {

        public Form_Plant()
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
            LoadPlant();
        }

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gv.Columns[ConstColumns.PlantId].Visible = false;
            gv.Columns[ConstColumns.LogoImage].Visible = false;
            gv.Columns[ConstColumns.ProductionDate].Visible = false;
            gv.Columns[ConstColumns.PlantName].HeaderText = "ชื่อโรงงาน";
            gv.Columns[ConstColumns.Address].HeaderText = "ที่อยู่";
        }


        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                Int32 plantId = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[ConstColumns.PlantId].Value);

                if ((senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn || senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) && e.RowIndex >= 0)
                {
                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {
                        case "Edit":
                            var frm = new Form_PlantAddEdit
                            {
                                plantId = plantId
                            };
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                LoadPlant();
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
            LoadPlant();
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_TruckAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
            LoadPlant();
        }

        private void LoadPlant()
        {
            //var farmCtrl = new FarmController();
            var coll = PlantController.GetAllPlants();
            gv.DataSource = coll;
            //LoadItem("");
        }
    }
}