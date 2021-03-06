﻿using SlaughterHouseEF;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseClient.Receiving
{
    public partial class Form_Receive : Form
    {
        //int ReceiveFlag { get; set; }
        public string ReceiveNo { get; set; }
        public Form_Receive()
        {
            InitializeComponent();
            Load += Form_Receive_Load;
            //ReceiveFlag = _receiveFlag;
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            gv.CellContentClick += Gv_CellContentClick;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;
        }
        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                if (e.RowIndex >= 0)
                {
                    ReceiveNo = gv.Rows[e.RowIndex].Cells[0].Value.ToString();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form_Receive_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (var db = new SlaughterhouseEntities())
            {
                var qry = db.receives.Where(p => (p.farm_qty - p.factory_qty) > 0 &&
                p.receive_flag != 2).ToList();
                var coll = qry.AsEnumerable().Select(p => new
                {
                    p.receive_no,
                    receive_date = p.receive_date.ToString("dd-MM-yyyy"),
                    p.transport_doc_no,
                    p.truck.truck_no,
                    p.farm.farm_name,
                    p.coop_no,
                    p.queue_no,
                    p.breeder.breeder_name,
                    farm_qty = p.farm_qty.ToComma(),
                    farm_wgh = p.farm_wgh.ToFormat2Decimal()
                }).OrderBy(p => p.receive_no).ToList();
                gv.DataSource = coll;
                gv.Columns[0].HeaderText = "เลขที่ใบรับ";
                gv.Columns[1].HeaderText = "วันที่รับ";
                gv.Columns[2].HeaderText = "เลขที่ใบส่ง";
                gv.Columns[3].HeaderText = "ทะเบียนรถ";
                gv.Columns[4].HeaderText = "ฟาร์ม";
                gv.Columns[5].HeaderText = "เล้า";
                gv.Columns[6].HeaderText = "คิวที่";
                gv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gv.Columns[7].HeaderText = "ประเภท";
                gv.Columns[8].HeaderText = "จำนวน";
                gv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gv.Columns[9].HeaderText = "น้ำหนัก";
                gv.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
