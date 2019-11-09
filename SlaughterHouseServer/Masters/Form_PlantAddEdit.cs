using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_PlantAddEdit : Form
    {
        public Int32 plantId { get; set; }
        string productCode { get; set; }
        DataTable dtTruckItem;

        public Form_PlantAddEdit()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            this.Load += Form_Load;
            this.Shown += Form_Shown;

            openFileDialog1.FileOk += openFileDialog1_FileOk;
        }
        private void Form_Shown(object sender, System.EventArgs e)
        {

        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }

        #region Event Focus, KeyDown

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
                SavePlant();
                MessageBox.Show("บันทึกข้อมูล เรียบร้อยแล้ว", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //private void BtnSaveAndNew_Click(object sender, System.EventArgs e)
        //{
        //    try
        //    {
        //        SavePlant();
        //        MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        txtPlantName.Text = "";
        //        txtPlantName.Focus();
        //        chkActive.Checked = true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        #endregion

        private void LoadData()
        {
            try
            {
                if (this.plantId > 0)
                {
                    Plant plant = PlantController.GetPlant();
                    txtPlantId.Text = this.plantId.ToString(); ;
                    txtPlantName.Text = plant.PlantName.ToString();
                    txtAddress.Text = plant.Address.ToString();
                    txtEstNo.Text = plant.EstNo.ToString();
                    if (plant.LogoImage != null)
                    {
                        if (plant.LogoImage.Length != 0)
                        {
                            imgLogo.Image = ByteToImage(plant.LogoImage);
                        }
                    }

                    //BtnSaveAndNew.Visible = false;
                    //txtTruckNo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }


        private void SavePlant()
        {
            try
            {
                var plant = new Plant();
                plant.PlantId = Convert.ToInt32(txtPlantId.Text);
                plant.PlantName = txtPlantName.Text;
                plant.Address = txtAddress.Text;
                plant.EstNo = txtEstNo.Text;
                if (openFileDialog1.FileName != "openFileDialog1")
                {
                    plant.LogoImage = File.ReadAllBytes(openFileDialog1.FileName);
                }
                plant.Active = chkActive.Checked;
                plant.CreateBy = "system";

                PlantController.Update(plant);

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            {
                openFileDialog1.Filter = "Images Only. |*.jpg; .jpeg; .png; .gif; .PNG;";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    var size = new FileInfo(openFileDialog1.FileName).Length;
                    txtLogoImage.Text = openFileDialog1.FileName;
                    imgLogo.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            FileInfo info = new FileInfo(openFileDialog1.FileName);
            if (info.Length > 300000)
            {
                MessageBox.Show("ไฟล์ต้องมีขนาดดไม่เกิน 300 kb");
                e.Cancel = true;
            }
        }
    }
}
