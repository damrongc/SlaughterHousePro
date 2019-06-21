using SlaughterHouseLib;
using SlaughterHouseLib.Models;
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

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                string status = gv.Rows[i].Cells[13].Value.ToString();
                switch (status)
                {
                    //case "New":
                    //    gv.Rows[i].Cells[13].Style.ForeColor = Color.White;
                    //    gv.Rows[i].Cells[13].Style.BackColor = ColorTranslator.FromHtml("#00A8E6");

                    //break;
                    case "In Process":
                        gv.Rows[i].Cells[13].Style.ForeColor = Color.Black;
                        gv.Rows[i].Cells[13].Style.BackColor = Color.Yellow;
                        break;
                    case "Finish":
                        gv.Rows[i].Cells[13].Style.ForeColor = Color.White;
                        gv.Rows[i].Cells[13].Style.BackColor = Color.Lime;
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
                    string receiveNo = gv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    var frm = new Form_ReceiveAddEdit
                    {
                        receiveNo = receiveNo
                    };
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadReceive();
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

            //ReceiveNo = p.Field<string>("receive_no"),
            //ReceiveDate = p.Field<DateTime>("receive_date"),
            //TransportDocNo = p.Field<string>("transport_doc_no"),
            //TruckNo = p.Field<string>("truck_no"),
            //FarmName = p.Field<string>("farm_name"),
            //CoopNo = p.Field<string>("coop_no"),
            //QueueNo = p.Field<int>("queue_no"),
            //BreederName = p.Field<string>("breeder_name"),
            //FarmQty = p.Field<int>("farm_qty"),
            //FarmWgh = p.Field<decimal>("farm_wgh"),
            //ReceiveFlag = p.Field<int>("receive_flag"),
            //CreateAt = p.Field<DateTime>("create_at"),

            gv.Columns[1].HeaderText = "เลขที่ใบรับ";
            gv.Columns[2].HeaderText = "วันที่รับ";
            gv.Columns[3].HeaderText = "เลขที่ใบส่ง";
            gv.Columns[4].HeaderText = "ทะเบียนรถ";
            gv.Columns[5].HeaderText = "ฟาร์ม";
            gv.Columns[6].HeaderText = "เล้า";
            gv.Columns[7].HeaderText = "คิวที่";
            gv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gv.Columns[8].HeaderText = "ประเภท";

            gv.Columns[9].HeaderText = "จำนวนฟาร์ม";
            gv.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[10].HeaderText = "น้ำหนักฟาร์ม";
            gv.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gv.Columns[11].HeaderText = "จำนวนรับ";
            gv.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[12].HeaderText = "น้ำหนักรับ";
            gv.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            gv.Columns[13].HeaderText = "สถานะ";
            gv.Columns[14].HeaderText = "วันเวลาสร้าง";
        }
    }
}
