using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using SlaughterHouseServer.Reports;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_Receive : Form
    {
        public Form_Receive()
        {
            InitializeComponent();
            UserSettingsComponent();
        }

        private void UserSettingsComponent()
        {
            try
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


                LoadFarm();
                LoadReceive();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < gv.Rows.Count; i++)
            {

                string status = gv.Rows[i].Cells[15].Value.ToString();
                switch (status)
                {
                    //case "New":
                    //    gv.Rows[i].Cells[13].Style.ForeColor = Color.White;
                    //    gv.Rows[i].Cells[13].Style.BackColor = ColorTranslator.FromHtml("#00A8E6");

                    //break;
                    //case 1:
                    //    gv.Rows[i].Cells[15].Style.ForeColor = Color.Black;
                    //    gv.Rows[i].Cells[15].Style.BackColor = Color.Yellow;
                    //    break;
                    case "In Process":
                        gv.Rows[i].Cells[15].Style.ForeColor = Color.Black;
                        gv.Rows[i].Cells[15].Style.BackColor = Color.Yellow;
                        break;
                    case "Close":
                        gv.Rows[i].Cells[15].Style.ForeColor = Color.White;
                        gv.Rows[i].Cells[15].Style.BackColor = ColorTranslator.FromHtml("#219653");
                        break;

                }


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

                        case "Edit":
                            var frm = new Form_ReceiveAddEdit
                            {
                                receiveNo = receiveNo
                            };
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                LoadReceive();
                            }
                            break;
                        case "Print":
                            var frmReport = new Form_ReportSwineReceiveByQueue
                            {
                                ReceiveNo = receiveNo
                            };
                            frmReport.ShowDialog();

                            break;
                        case "CloseFlag":
                            ReceiveController.CloseFlagSwineReceive(receiveNo, "system");
                            //StockController.InsertStockSwineReceive(receiveNo);
                            MessageBox.Show("ปิดคิว เรียบร้อยแล้ว", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadReceive();
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

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_ReceiveAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadReceive();
            }
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
            var coll = ReceiveController.GetAllReceives(dtpReceiveDate.Value, cboFarm.SelectedValue.ToString());
            gv.DataSource = coll;

            gv.Columns[3].HeaderText = "เลขที่ใบรับ";
            gv.Columns[4].HeaderText = "วันที่รับ";
            gv.Columns[5].HeaderText = "เลขที่ใบส่ง";
            gv.Columns[6].HeaderText = "ทะเบียนรถ";
            gv.Columns[7].HeaderText = "ฟาร์ม";
            gv.Columns[8].HeaderText = "เล้า";
            gv.Columns[9].HeaderText = "คิวที่";
            gv.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gv.Columns[10].HeaderText = "ประเภท";

            gv.Columns[11].HeaderText = "จำนวนฟาร์ม";
            gv.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[12].HeaderText = "น้ำหนักฟาร์ม";
            gv.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gv.Columns[13].HeaderText = "จำนวนรับ";
            gv.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[14].HeaderText = "น้ำหนักรับ";
            gv.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            gv.Columns[15].HeaderText = "สถานะ";
            gv.Columns[16].HeaderText = "วันเวลาสร้าง";
        }
    }
}
