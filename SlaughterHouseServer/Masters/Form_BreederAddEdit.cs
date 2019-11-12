using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_BreederAddEdit : Form
    {
        public string breederCode;

        public Form_BreederAddEdit()
        {
            InitializeComponent();

            txtBreederCode.KeyDown += TxtUnitCode_KeyDown;
            txtBreederName.KeyDown += TxtUnitName_KeyDown;
            this.Load += Form_Load;
            this.Shown += Form_Shown;
        }

        private void Form_Shown(object sender, System.EventArgs e)
        {
            txtBreederCode.Focus();
            if (!string.IsNullOrEmpty(this.breederCode))
            {
                BtnSaveAndNew.Visible = false;
            }
        }

        private void Form_Load(object sender, System.EventArgs e)
        {

            if (!string.IsNullOrEmpty(this.breederCode))
            {

                var breeder = BreederController.GetBreeder(this.breederCode);
                if (this.breederCode != null)
                {
                    txtBreederCode.Text = breeder.BreederCode.ToString();
                    txtBreederCode.Enabled = false;
                    txtBreederName.Text = breeder.BreederName; 
                    chkActive.Checked = breeder.Active;
                }
            }
        }

        private void TxtUnitName_KeyDown(object sender, KeyEventArgs e)
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
                txtBreederName.Focus();
            }
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.breederCode))
                {
                    var breeder = new Breeder
                    {
                        //UnitCode = Convert.ToInt32(txtUnitCode.Text),
                        BreederName = txtBreederName.Text.Trim(),
                        Active = chkActive.Checked,
                        CreateBy = "system",
                    };
                    BreederController.Insert(breeder);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var breeder = new Breeder
                    {
                        BreederCode = Convert.ToInt32(txtBreederCode.Text),
                        BreederName = txtBreederName.Text.Trim(),
                        Active = chkActive.Checked,
                        ModifiedBy = "system",
                    };
                    BreederController.Update(breeder);
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

                var breeder = new Breeder
                {
                    //UnitCode = Convert.ToInt32(txtUnitCode.Text),
                    BreederName = txtBreederName.Text.Trim(),
                    Active = chkActive.Checked,
                    CreateBy = "system",
                };
                BreederController.Insert(breeder);
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtBreederCode.Text = "";
                txtBreederCode.Focus();
                txtBreederName.Text = "";
                chkActive.Checked = true;

            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
    }
}
