using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;

namespace SlaughterHouseClient
{
    public partial class Form_SwineReceive : Form
    {
        private string productCode = "P001";
        private string sexFlag = "F";
        private bool isStart = false;
        private Receive receive;

        const string CHOOSE_QUEUE = "กรุณาเลือกคิว";
        const string START_WAITING = "กรุณาเริ่มชั่ง";
        const string WEIGHT_WAITING = "กรุณาชั่งน้ำหนัก";
        public Form_SwineReceive()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_SwineReceive_Load(object sender, EventArgs e)
        {
            lblCurrentDatetime.Text = DateTime.Today.ToString("dd.MM.yyyy");
            lblMessage.Text = CHOOSE_QUEUE;
        }

        private void btnReceiveNo_Click(object sender, EventArgs e)
        {
            var frm = new Form_Receive(0);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(frm.receiveNo);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isStart = true;
            lblMessage.Text = WEIGHT_WAITING;
        }

        private void btnFemale_Click(object sender, EventArgs e)
        {
            if (isStart)
                return;
            sexFlag = "F";
            btnFemale.BackColor = System.Drawing.ColorTranslator.FromHtml("#459CDB");
            btnMale.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            btnUndified.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
        }

        private void btnMale_Click(object sender, EventArgs e)
        {
            if (isStart)
                return;
            sexFlag = "M";
            btnFemale.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            btnMale.BackColor = System.Drawing.ColorTranslator.FromHtml("#459CDB");
            btnUndified.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");

        }

        private void btnUndified_Click(object sender, EventArgs e)
        {
            if (isStart)
                return;
            sexFlag = "NA";
            btnFemale.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            btnMale.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            btnUndified.BackColor = System.Drawing.ColorTranslator.FromHtml("#459CDB");

        }

        private void LoadData(string receiveNo)
        {
            receive = ReceiveController.GetReceive(receiveNo);
            lblReceiveNo.Text = receive.ReceiveNo;
            lblFarm.Text = receive.Farm.FarmName;
            lblBreeder.Text = receive.Breeder.BreederName;
            lblTruckNo.Text = receive.TruckNo;
            lblQueueNo.Text = receive.QueueNo.ToString();
            lblFarmQty.Text = receive.FarmQty.ToString();
            lblFactoryQty.Text = receive.FactoryQty.ToString();
            lblFactoryWgh.Text = receive.FactoryWgh.ToFormat2Decimal();
            lblRemainQty.Text = (receive.FarmQty - receive.FactoryQty).ToString();
            lblMessage.Text = START_WAITING;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                //StockController.InsertStockSwineReceive(receive.ReceiveNo);
                var ret = SaveData();
                if (ret)
                {
                    LoadData(lblReceiveNo.Text);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool SaveData()
        {
            try
            {
                ReceiveItem receiveItem = new ReceiveItem
                {
                    ReceiveNo = receive.ReceiveNo,
                    ProductCode = this.productCode,
                    SexFlag = sexFlag,
                    ReceiveQty = 1,
                    ReceiveWgh = lblWeight.Text.ToDecimal(),
                    CreateBy = "Auto"
                };
                return ReceiveController.InsertItem(receiveItem);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
