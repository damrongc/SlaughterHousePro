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
        //DataTable dtTruckItem;

        public Form_TruckAddEdit()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            LoadTruckType();
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
            LoadType();
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

<<<<<<< HEAD
=======

>>>>>>> 8e7570345231c099c0226de5161f05ab481aac21
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
<<<<<<< HEAD
            if (this.truckNo != null)
            {
                Truck Truck = TruckController.GetTruck(this.truckNo);
                txtTruckNo.Text = Truck.TruckNo.ToString();
                cboTruckType.SelectedValue = Truck.TruckTypeId;
                txtDriver.Text = Truck.Driver.ToString();
                BtnSaveAndNew.Visible = false;
                txtTruckNo.Enabled = false;
            }

=======
            try
            {
                if (this.truckId > 0)
                {
                    Truck Truck = TruckController.GetTruck(this.truckId);
                    txtTruckId.Text = this.truckId.ToString(); ;
                    txtTruckNo.Text = Truck.TruckNo.ToString();
                    txtDriver.Text = Truck.Driver.ToString();
                    comboxTruckType.SelectedValue = Truck.TruckType.TruckTypeId;
                    BtnSaveAndNew.Visible = false;
                    //txtTruckNo.Enabled = false;
                }
            }
            catch (Exception)
            {

            }
        }

        private void LoadTruckType()
        {
            comboxTruckType.DataSource = TruckTypeController.GetAllTruckType();
            comboxTruckType.ValueMember = "TruckTypeId";
            comboxTruckType.DisplayMember = "TruckTypeDesc";
        }
>>>>>>> 8e7570345231c099c0226de5161f05ab481aac21

        }
        private void LoadType()
        {
            var coll = TruckTypeController.GetAllTruckTypes();
            cboTruckType.DisplayMember = "TruckTypeDesc";
            cboTruckType.ValueMember = "TruckTypeId";
            cboTruckType.DataSource = coll;
        }
        private void SaveTruck()
        {
            try
            {
                var truck = new Truck
                {
                    TruckNo = txtTruckNo.Text.Trim(),
<<<<<<< HEAD
                    TruckTypeId = cboTruckType.SelectedValue.ToString().ToInt16(),
                    Driver = txtDriver.Text.Trim(),
=======
                    Driver = txtDriver.Text.Trim(),
                    TruckType = new TruckType
                    {
                        TruckTypeId = (int)comboxTruckType.SelectedValue,
                        TruckTypeDesc = comboxTruckType.Text,
                    },
>>>>>>> 8e7570345231c099c0226de5161f05ab481aac21
                    Active = chkActive.Checked,
                    CreateBy = "system",
                };

<<<<<<< HEAD
                if (string.IsNullOrEmpty(this.truckNo))
=======
                if (this.truckId == null || this.truckId == 0)
>>>>>>> 8e7570345231c099c0226de5161f05ab481aac21
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
