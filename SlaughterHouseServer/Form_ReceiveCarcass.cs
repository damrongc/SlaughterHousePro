using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_ReceiveCarcass : Form
    {
        public Form_ReceiveCarcass()
        {
            InitializeComponent();
            UserSettingsComponent();
        }

        private void UserSettingsComponent()
        {

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


            LoadFarm();
            LoadReceive();
        }

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < gv.Rows.Count; i++)
            {

                //string status = gv.Rows[i].Cells[15].Value.ToString();
                //switch (status)
                //{

                //    case "In Process":
                //        gv.Rows[i].Cells[15].Style.ForeColor = Color.Black;
                //        gv.Rows[i].Cells[15].Style.BackColor = Color.Yellow;
                //        break;
                //    case "Close":
                //        gv.Rows[i].Cells[15].Style.ForeColor = Color.White;
                //        gv.Rows[i].Cells[15].Style.BackColor = ColorTranslator.FromHtml("#219653");
                //        break;

                //}


            }
        }

        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    string receiveNo = gv.Rows[e.RowIndex].Cells[3].Value.ToString();

                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {
                        case "Print":

                            break;
                        case "CloseFlag":
                            StockController.InsertStockSwineReceive(receiveNo);
                            MessageBox.Show("ปิดคิว เรียบร้อยแล้ว", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            LoadReceive();
        }


        private void LoadFarm()
        {

            var coll = FarmController.GetAllFarms();
            coll.Insert(0, new Farm
            {
                FarmCode = "",
                FarmName = "--เลือก--"
            });
            cboFarm.DisplayMember = "FarmName";
            cboFarm.ValueMember = "FarmCode";
            cboFarm.DataSource = coll;
        }

        private void LoadReceive()
        {
            //var farmCtrl = new FarmController();
            var coll = ReceiveController.GetAllReceives(1);
            gv.DataSource = coll;

            gv.Columns[2].HeaderText = "เลขที่ใบรับ";
            gv.Columns[3].HeaderText = "วันที่รับ";
            gv.Columns[4].HeaderText = "เลขที่ใบส่ง";
            gv.Columns[5].HeaderText = "ทะเบียนรถ";
            gv.Columns[6].HeaderText = "ฟาร์ม";
            gv.Columns[7].HeaderText = "เล้า";
            gv.Columns[8].HeaderText = "คิวที่";
            gv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gv.Columns[9].HeaderText = "ประเภท";

            gv.Columns[10].HeaderText = "จำนวนฟาร์ม";
            gv.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[11].HeaderText = "น้ำหนักฟาร์ม";
            gv.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gv.Columns[12].HeaderText = "จำนวนรับ";
            gv.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[13].HeaderText = "น้ำหนักรับ";
            gv.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            gv.Columns[14].HeaderText = "สถานะ";
            gv.Columns[15].HeaderText = "วันเวลาสร้าง";
        }
    }
}
