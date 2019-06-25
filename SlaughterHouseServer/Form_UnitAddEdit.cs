using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_UnitAddEdit : Form
    {
        public string unitCode;

        public Form_UnitAddEdit()
        {
            InitializeComponent();

            txtUnitCode.KeyDown += TxtUnitCode_KeyDown; 
            //txtAddress.KeyDown += TxtAddress_KeyDown;
            this.Load += Form_UnitAddEdit_Load;
            this.Shown += Form_UnitAddEdit_Shown;
        }

        private void Form_UnitAddEdit_Shown(object sender, System.EventArgs e)
        {
            txtUnitCode.Focus();
            if (!string.IsNullOrEmpty(this.unitCode))
            {
                BtnSaveAndNew.Visible = false;
            }
        }

        private void Form_UnitAddEdit_Load(object sender, System.EventArgs e)
        {

            if (!string.IsNullOrEmpty(this.unitCode))
            {

                var unit = UnitController.GetUnit(this.unitCode);
                if (unit != null)
                {
                    txtUnitCode.Text = unit.UnitCode.ToString();
                    txtUnitCode.Enabled = false;
                    txtUnitName.Text = unit.UnitName; 
                    chkActive.Checked = unit.Active;
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

        private void TxtUnitCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUnitName.Focus();
            }
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.unitCode))
                {
                    var unit = new Unit
                    {
                        UnitCode = Convert.ToInt32(txtUnitCode.Text),
                        UnitName = txtUnitName.Text.Trim(),
                        Active = chkActive.Checked,
                        CreateBy = "system",
                    };
                    UnitController.Insert(unit);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    var unit = new Unit
                    {
                        UnitCode = Convert.ToInt32(txtUnitCode.Text),
                        UnitName = txtUnitName.Text.Trim(),
                        Active = chkActive.Checked,
                        ModifiedBy = "system",
                    };
                    UnitController.Update(unit);
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

                var unit = new Unit
                {
                    UnitCode = Convert.ToInt32(txtUnitCode.Text),
                    UnitName = txtUnitName.Text.Trim(),
                    Active = chkActive.Checked,
                    CreateBy = "system",
                };
                UnitController.Insert(unit);
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUnitCode.Text = "";
                txtUnitCode.Focus();
                txtUnitName.Text = "";
                chkActive.Checked = true;

            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
    }
}
