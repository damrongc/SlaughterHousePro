using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;

namespace SlaughterHouseServer
{
    public partial class Form_ReceiveAddEdit : Form
    {

        public string receiveNo { get; set; }
        public Form_ReceiveAddEdit()
        {
            InitializeComponent();
            Load += Form_Load;
            Shown += Form_Shown;

            //KeyPress
            txtFarmQty.KeyPress += TxtFarmQty_KeyPress;
            txtFarmWgh.KeyPress += TxtFarmWgh_KeyPress;

            //KeyDown
            txtTransportNo.KeyDown += TxtTransportNo_KeyDown;

            txtCoopNo.KeyDown += TxtCoopNo_KeyDown;
            txtFarmQty.KeyDown += TxtFarmQty_KeyDown;
            txtFarmWgh.KeyDown += TxtFarmWgh_KeyDown;
        }



        private void Form_Load(object sender, EventArgs e)
        {

            BtnDelete.Visible = false;
            LoadFarm();
            LoadTruck();
            LoadBreeder();
            LoadData();
        }
        private void Form_Shown(object sender, EventArgs e)
        {
            txtTransportNo.Focus();
            txtTransportNo.CharacterCasing = CharacterCasing.Upper;
        }



        private void TxtTransportNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                cboTruckNo.Focus();
            }
        }

        private void TxtFarmWgh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSaveAndClose.Focus();
            }
        }

        private void TxtFarmQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFarmWgh.SelectAll();
                txtFarmWgh.Focus();
            }
        }

        private void TxtCoopNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFarmQty.SelectAll();
                txtFarmQty.Focus();
            }
        }

        private void TxtTruckNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCoopNo.SelectAll();
                txtCoopNo.Focus();
            }
        }

        private void TxtFarmQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }

        private void TxtFarmWgh_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void LoadData()
        {
            txtReciveNo.Enabled = false;
            Receive receive = ReceiveController.GetReceive(this.receiveNo);
            if (receive != null)
            {
                txtReciveNo.Text = receive.ReceiveNo;
                dtpReceiveDate.Value = receive.ReceiveDate;
                txtTransportNo.Text = receive.TransportDocNo;
                cboBreeder.SelectedValue = receive.Breeder.BreederCode;
                cboFarm.SelectedValue = receive.Farm.FarmCode;
                cboTruckNo.SelectedValue = receive.TruckNo;
                txtCoopNo.Text = receive.CoopNo;
                txtFarmQty.Text = receive.FarmQty.ToString();
                txtFarmWgh.Text = receive.FarmWgh.ToString();

                dtpReceiveDate.Enabled = false;
                BtnSaveAndNew.Visible = false;

                if (receive.ReceiveFlag == 0)
                {
                    BtnDelete.Visible = true;

                }

            }
        }
        private void LoadTruck()
        {
            var coll = TruckController.GetAllTrucks(1);
            cboTruckNo.DisplayMember = "TruckNo";
            cboTruckNo.ValueMember = "TruckNo";
            cboTruckNo.DataSource = coll;
        }

        private void LoadFarm()
        {
            var coll = FarmController.GetAllFarms();
            cboFarm.DisplayMember = "FarmName";
            cboFarm.ValueMember = "FarmCode";
            cboFarm.DataSource = coll;
        }

        private void LoadBreeder()
        {
            var coll = BreederController.GetAllBreeders();
            cboBreeder.DisplayMember = "BreederName";
            cboBreeder.ValueMember = "BreederCode";
            cboBreeder.DataSource = coll;
        }

        private void BtnSaveAndClose_Click(object sender, EventArgs e)
        {

            try
            {
                SaveReceive();
                MessageBox.Show("บันทึกข้อมูล เรียบร้อยแล้ว", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnSaveAndNew_Click(object sender, EventArgs e)
        {
            try
            {

                SaveReceive();
                MessageBox.Show("บันทึกข้อมูล เรียบร้อยแล้ว", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Clear Control
                txtTransportNo.Focus();
                txtTransportNo.Text = "";
                cboBreeder.SelectedIndex = 0;
                cboFarm.SelectedIndex = 0;
                cboTruckNo.SelectedIndex = 0;
                txtCoopNo.Text = "";
                txtFarmQty.Text = 0.ToString();
                txtFarmWgh.Text = 0.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SaveReceive()
        {
            try
            {
                var receive = new Receive
                {
                    ReceiveNo = txtReciveNo.Text,
                    ReceiveDate = dtpReceiveDate.Value,
                    TransportDocNo = txtTransportNo.Text.Trim(),
                    TruckNo = cboTruckNo.SelectedValue.ToString(),
                    Breeder = new Breeder
                    {
                        BreederCode = (int)cboBreeder.SelectedValue
                    },
                    Farm = new Farm
                    {
                        FarmCode = cboFarm.SelectedValue.ToString()
                    },
                    CoopNo = txtCoopNo.Text.Trim(),
                    FarmQty = txtFarmQty.Text.ToInt16(),
                    FarmWgh = txtFarmWgh.Text.ToDecimal(),
                    CreateBy = "system"

                };
                ReceiveController.InsertOrUpdate(receive);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ReceiveController.Delete(txtReciveNo.Text);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
