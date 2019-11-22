using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_TruckTypeAddEdit : Form
    {
        public Int32 truckTypeId { get; set; }
        string productCode { get; set; }


        public Form_TruckTypeAddEdit()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            this.Load += Form_Load;
            this.Shown += Form_Shown;
        }
        private void Form_Shown(object sender, System.EventArgs e)
        {

        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }

        #region Event Focus, KeyDown


        #endregion


        #region Event Click
        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                SaveTruckType();
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
                SaveTruckType();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTruckTypeName.Text = "";
                txtTruckTypeName.Focus();
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
                if (this.truckTypeId > 0)
                {
                    TruckType truckType = TruckTypeController.GetTruckType(this.truckTypeId);
                    txtTruckTypeId.Text = this.truckTypeId.ToString(); ;
                    txtTruckTypeName.Text = truckType.TruckTypeDesc;
                    chkActive.Checked = truckType.Active;
                    BtnSaveAndNew.Visible = false;
                    //txtTruckNo.Enabled = false;
                }
            }
            catch (Exception)
            {

            }
        }

        private void SaveTruckType()
        {
            try
            {


                if (this.truckTypeId == null || this.truckTypeId == 0)
                {
                    var truckType = new TruckType
                    {
                        TruckTypeId = this.truckTypeId,
                        TruckTypeDesc = txtTruckTypeName.Text.Trim(),
                        Active = chkActive.Checked,
                        CreateBy = "system",
                    };
                    TruckTypeController.Insert(truckType);
                }
                else
                {
                    var truckType = new TruckType
                    {
                        TruckTypeId = this.truckTypeId,
                        TruckTypeDesc = txtTruckTypeName.Text.Trim(),
                        Active = chkActive.Checked,
                        ModifiedBy = "system",
                    };
                    truckType.TruckTypeId = Convert.ToInt32(txtTruckTypeId.Text);
                    TruckTypeController.Update(truckType);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}
