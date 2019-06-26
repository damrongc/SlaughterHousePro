using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_ProductGroupAddEdit : Form
    {
        public string productGroupCode;

        public Form_ProductGroupAddEdit()
        {
            InitializeComponent();

            txtProductGroupCode.KeyDown += TxtProductGroupCode_KeyDown;
            txtProductGroupName.KeyDown += TxtProductGroupName_KeyDown;
            this.Load += Form_ProductGroupAddEdit_Load;
            this.Shown += Form_ProductGroupAddEdit_Shown;
        }

        private void Form_ProductGroupAddEdit_Shown(object sender, System.EventArgs e)
        {
            txtProductGroupCode.Focus();
            if (!string.IsNullOrEmpty(this.productGroupCode))
            {
                BtnSaveAndNew.Visible = false;
            }
        }

        private void Form_ProductGroupAddEdit_Load(object sender, System.EventArgs e)
        {

            if (!string.IsNullOrEmpty(this.productGroupCode))
            {

                var productgroup = ProductGroupController.GetProductGroup(this.productGroupCode);
                if (productgroup != null)
                {
                    txtProductGroupCode.Text = productgroup.ProductGroupCode.ToString();
                    txtProductGroupCode.Enabled = false;
                    txtProductGroupName.Text = productgroup.ProductGroupName; 
                    chkActive.Checked = productgroup.Active;
                }
            }
        }

        private void TxtProductGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSaveAndNew.Focus();
            }
        }

        private void TxtProductGroupCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProductGroupName.Focus();
            }
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.productGroupCode))
                {
                    var productgroup = new ProductGroup
                    {
                        //UnitCode = Convert.ToInt32(txtUnitCode.Text),
                        ProductGroupName = txtProductGroupName.Text.Trim(),
                        Active = chkActive.Checked,
                        CreateBy = "system",
                    };
                    ProductGroupController.Insert(productgroup);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var productgroup = new ProductGroup
                    {
                        ProductGroupCode = Convert.ToInt32(txtProductGroupCode.Text),
                        ProductGroupName = txtProductGroupName.Text.Trim(),
                        Active = chkActive.Checked,
                        ModifiedBy = "system",
                    };
                    ProductGroupController.Update(productgroup);
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
                var productgroup = new ProductGroup
                {
                    //UnitCode = Convert.ToInt32(txtUnitCode.Text),
                    ProductGroupName = txtProductGroupName.Text.Trim(),
                    Active = chkActive.Checked,
                    CreateBy = "system",
                };
                ProductGroupController.Insert(productgroup);
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtProductGroupCode.Text = "";
                txtProductGroupCode.Focus();
                txtProductGroupName.Text = "";
                chkActive.Checked = true;

            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
    }
}
