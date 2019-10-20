using SlaughterHouseLib.Models;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_FarmAddEdit : Form
    {
        public string farmCode;

        public Form_FarmAddEdit()
        {
            InitializeComponent();

            txtFarmCode.KeyDown += TxtFarmCode_KeyDown;
            txtFarmName.KeyDown += TxtFarmName_KeyDown;
            //txtAddress.KeyDown += TxtAddress_KeyDown;
            this.Load += Form_FarmAddEdit_Load;
            this.Shown += Form_FarmAddEdit_Shown;
        }

        private void Form_FarmAddEdit_Shown(object sender, System.EventArgs e)
        {
            txtFarmCode.Focus();
            if (!string.IsNullOrEmpty(this.farmCode))
            {
                BtnSaveAndNew.Visible = false;
            }
        }

        private void Form_FarmAddEdit_Load(object sender, System.EventArgs e)
        {

            if (!string.IsNullOrEmpty(this.farmCode))
            {

                var farm = FarmController.GetFarm(this.farmCode);
                if (farm != null)
                {
                    txtFarmCode.Text = farm.FarmCode;
                    txtFarmCode.Enabled = false;
                    txtFarmName.Text = farm.FarmName;
                    txtAddress.Text = farm.Address;
                    chkActive.Checked = farm.Active;
                }
            }
        }

        private void TxtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSaveAndNew.Focus();
            }
        }

        private void TxtFarmName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
            }
        }

        private void TxtFarmCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFarmName.Focus();
            }
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.farmCode))
                {
                    var farm = new Farm
                    {
                        FarmCode = txtFarmCode.Text.Trim(),
                        FarmName = txtFarmName.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        Active = chkActive.Checked,
                        CreateBy = "system",
                    };
                    FarmController.Insert(farm);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    var farm = new Farm
                    {
                        FarmCode = txtFarmCode.Text.Trim(),
                        FarmName = txtFarmName.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        Active = chkActive.Checked,
                        ModifiedBy = "system",
                    };
                    FarmController.Update(farm);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
                var farm = new Farm
                {
                    FarmCode = txtFarmCode.Text.Trim(),
                    FarmName = txtFarmName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Active = chkActive.Checked,
                    CreateBy = "system",
                };
                FarmController.Insert(farm);
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtFarmCode.Text = "";
                txtFarmCode.Focus();
                txtFarmName.Text = "";
                txtAddress.Text = "";
                chkActive.Checked = true;

            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
