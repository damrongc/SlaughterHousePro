﻿using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;

namespace SlaughterHouseClient
{
    public partial class Form_CarcassReceive : Form
    {
        private string productCode = "P002";
        private bool isStart = false;
        private Receive receive;

        const string CHOOSE_QUEUE = "กรุณาเลือกคิว";
        const string START_WAITING = "กรุณาเริ่มชั่ง";
        const string WEIGHT_WAITING = "กรุณาชั่งน้ำหนัก";
        public Form_CarcassReceive()
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
            var frm = new Form_Receive(1);

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


        private void LoadData(string receiveNo)
        {
            receive = ReceiveController.GetReceive(receiveNo, this.productCode);
            lblReceiveNo.Text = receive.ReceiveNo;
            lblFarm.Text = receive.Farm.FarmName;
            lblBreeder.Text = receive.Breeder.BreederName;
            lblTruckNo.Text = receive.TruckNo;
            lblQueueNo.Text = receive.QueueNo.ToString();
            lblSwineQty.Text = receive.FarmQty.ToString();
            lblStockQty.Text = receive.FactoryQty.ToString();
            lblStockWgh.Text = receive.FactoryWgh.ToFormat2Decimal();
            lblRemainQty.Text = (receive.FarmQty - receive.FactoryQty).ToString();
            lblMessage.Text = START_WAITING;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {

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
                    SexFlag = "",
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
