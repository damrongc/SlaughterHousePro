using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_TruckAddEdit : Form
    {
        public Int32 truckId { get; set; }
        string productCode { get; set; }
        DataTable dtTruckItem;

        public Form_TruckAddEdit()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            LoadCustomerClass();
            this.Load += Form_Load;
            this.Shown += Form_Shown;
            txtDriver.KeyDown += TxtDriver_KeyDown;
            txtTruckNo.KeyDown += TxtTruckNo_KeyDown;
        }
        private void Form_Shown(object sender, System.EventArgs e)
        {

        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }

        #region Event Focus, KeyDown
        private void TxtTruckNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDriver.Focus();
            }
        }
        private void TxtDriver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSave.Focus();
            }
        }
        #endregion


        #region Event Click
        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                SaveTruck();
                MessageBox.Show("บันทึกข้อมูล เรียบร้อยแล้ว", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BtnSaveAndNew_Click(object sender, System.EventArgs e)
        {
            try
            {
                SaveTruck();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txtDriver.Text = "";
                txtTruckNo.Text = "";
                txtTruckNo.Focus();
                chkActive.Checked = true;
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        private void LoadData()
        {
            try
            {
                if (this.truckId > 0)
                {
                    Truck truck = TruckController.GetTruck(this.truckId);
                    txtTruckId.Text = this.truckId.ToString(); ;
                    txtTruckNo.Text = truck.TruckNo.ToString();
                    txtDriver.Text = truck.Driver.ToString();
                    chkActive.Checked = truck.Active;
                    comboxTruckType.SelectedValue = truck.TruckType.TruckTypeId;
                    BtnSaveAndNew.Visible = false;
                    //txtTruckNo.Enabled = false;
                }
            }
            catch (Exception)
            {

            }
        }

        private void LoadCustomerClass()
        {
            comboxTruckType.DataSource = TruckTypeController.GetAllTruckType();
            comboxTruckType.ValueMember = "TruckTypeId";
            comboxTruckType.DisplayMember = "TruckTypeDesc";
        }

        private void SaveTruck()
        {
            try
            {
                var truck = new Truck
                {
                    TruckNo = txtTruckNo.Text.Trim(),
                    Driver = txtDriver.Text.Trim(),
                    TruckType = new TruckType
                    {
                        TruckTypeId = (int)comboxTruckType.SelectedValue,
                        TruckTypeDesc = comboxTruckType.Text,
                    },
                    Active = chkActive.Checked,
                    CreateBy = "system",
                };

                if (this.truckId == null || this.truckId == 0)
                {
                    TruckController.Insert(truck);
                }
                else
                {
                    truck.TruckId = Convert.ToInt32(txtTruckId.Text);
                    TruckController.Update(truck);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}
