using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseClient.Receiving
{
    public partial class Form_Receive : Form
    {
        int ReceiveFlag { get; set; }
        public string receiveNo { get; set; }
        public Form_Receive(int _receiveFlag)
        {
            InitializeComponent();
            Load += Form_Receive_Load;

            ReceiveFlag = _receiveFlag;

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

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    this.receiveNo = gv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();


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
                var qry = db.receives.Where(p => p.receive_flag == ReceiveFlag).ToList();
                var coll = qry.AsEnumerable().Select(p => new
                {
                    p.receive_no,
                    p.receive_date,
                    p.transport_doc_no,
                    p.truck_no,
                    p.farm.farm_name,
                    p.coop_no,
                    p.queue_no,
                    p.breeder.breeder_name,
                    farm_qty = p.farm_qty.ToComma(),
                    farm_wgh = p.farm_wgh.ToFormat2Decimal()
                }).ToList();
                //var coll = ReceiveController.GetAllReceives(ReceiveFlag);

                gv.DataSource = coll;

                gv.Columns[1].HeaderText = "เลขที่ใบรับ";
                gv.Columns[2].HeaderText = "วันที่รับ";
                gv.Columns[3].HeaderText = "เลขที่ใบส่ง";
                gv.Columns[4].HeaderText = "ทะเบียนรถ";
                gv.Columns[5].HeaderText = "ฟาร์ม";
                gv.Columns[6].HeaderText = "เล้า";

                gv.Columns[7].HeaderText = "คิวที่";
                gv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                gv.Columns[8].HeaderText = "ประเภท";

                gv.Columns[9].HeaderText = "จำนวน";
                gv.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gv.Columns[10].HeaderText = "น้ำหนัก";
                gv.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
