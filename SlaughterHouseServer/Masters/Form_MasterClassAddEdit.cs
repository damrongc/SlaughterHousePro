using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_MasterClassAddEdit : Form
    {
        public int customerClassId;

        public Form_MasterClassAddEdit()
        {
            InitializeComponent();

            txtCustomerClassCode.KeyDown += TxtCustomerClassCode_KeyDown;
            txtCustomerClassName.KeyDown += TxtCustomerClassName_KeyDown;
            this.Load += Form_CustomerClassAddEdit_Load;
            this.Shown += Form_CustomerClassAddEdit_Shown;
        }

        private void Form_CustomerClassAddEdit_Shown(object sender, System.EventArgs e)
        {
            txtCustomerClassCode.Focus();
            if (customerClassId > 0)
            {
                BtnSaveAndNew.Visible = false;
            }
        }

        private void Form_CustomerClassAddEdit_Load(object sender, System.EventArgs e)
        {

            if (customerClassId > 0)
            {

                var customerClass = MasterClassController.GetMasterClass(this.customerClassId);
                if (customerClass != null)
                {
                    txtCustomerClassCode.Text = customerClass.ClassId.ToString();
                    txtCustomerClassCode.Enabled = false;
                    txtCustomerClassName.Text = customerClass.ClassName;
                    chkActive.Checked = customerClass.Active;
                }
            }
        }

        private void TxtCustomerClassName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSaveAndNew.Focus();
            }
        }

        private void TxtCustomerClassCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerClassName.Focus();
            }
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (customerClassId == 0)
                {
                    var customerClass = new MasterClass
                    {
                        //UnitCode = Convert.ToInt32(txtUnitCode.Text),
                        ClassName = txtCustomerClassName.Text.Trim(),
                        Active = chkActive.Checked,
                        CreateBy = "system",
                    };
                    MasterClassController.Insert(customerClass);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var customerClass = new MasterClass
                    {
                        ClassId = Convert.ToInt32(txtCustomerClassCode.Text),
                        ClassName = txtCustomerClassName.Text.Trim(),
                        Active = chkActive.Checked,
                        ModifiedBy = "system",
                    };
                    MasterClassController.Update(customerClass);
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
                var customerClass = new MasterClass
                {
                    //UnitCode = Convert.ToInt32(txtUnitCode.Text),
                    ClassName = txtCustomerClassName.Text.Trim(),
                    Active = chkActive.Checked,
                    CreateBy = "system",
                };
                MasterClassController.Insert(customerClass);
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCustomerClassCode.Text = "";
                txtCustomerClassCode.Focus();
                txtCustomerClassName.Text = "";
                chkActive.Checked = true;

            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
