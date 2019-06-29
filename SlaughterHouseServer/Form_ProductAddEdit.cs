using SlaughterHouseLib.Models;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_ProductAddEdit : Form
    {
        public string productCode;

        public Form_ProductAddEdit()
        {
            InitializeComponent();

            txtProductCode.KeyDown += TxtProductCode_KeyDown;
            txtProductName.KeyDown += TxtProductName_KeyDown;

            comboxProductGroup.KeyDown += ComboxProductGroup_KeyDown;
            comboxUnitQty.KeyDown += ComboxUnitQty_KeyDown;
            comboxUnitWgh.KeyDown += ComboxUnitWgh_KeyDown;
             
            this.Load += Form_ProductAddEdit_Load;
            this.Shown += Form_ProductAddEdit_Shown;
        }

        private void Form_ProductAddEdit_Shown(object sender, System.EventArgs e)
        {
            txtProductCode.Focus();
            if (!string.IsNullOrEmpty(this.productCode))
            {
                BtnSaveAndNew.Visible = false;
            }
        }

        private void Form_ProductAddEdit_Load(object sender, System.EventArgs e)
        {
            FillProductGroup();
            FillUnitQtyWgh();
            if (!string.IsNullOrEmpty(this.productCode))
            {

                var product = ProductController.GetProduct(this.productCode);
                if (product != null)
                {
                    txtProductCode.Text = product.ProductCode;
                    txtProductCode.Enabled = false;
                    txtProductName.Text = product.ProductName;
                    comboxProductGroup.SelectedValue = product.ProductGroup.ProductGroupCode;
                    comboxUnitQty.SelectedValue = product.UnitOfQty.UnitCode ;
                    comboxUnitWgh.SelectedValue = product.UnitOfWgh.UnitCode ;
                    chkActive.Checked = product.Active;
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

        private void TxtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboxProductGroup.Focus();
            }
        }

        private void TxtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProductName.Focus();
            }
        }

        private void ComboxProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboxUnitQty.Focus();
            }
        }
        private void ComboxUnitQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboxUnitWgh.Focus();
            }
        }
        private void ComboxUnitWgh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSaveAndNew.Focus();
            }
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.productCode))
                {
                    var product = new Product
                    {
                        ProductCode = txtProductCode.Text.Trim(),
                        ProductName = txtProductName.Text.Trim(),
                        ProductGroup = new ProductGroup
                        {
                            ProductGroupCode = (int)comboxProductGroup.SelectedValue,
                            ProductGroupName = comboxProductGroup.Text,
                        },
                        UnitOfQty = new Unit
                        {
                            UnitCode = (int)comboxUnitQty.SelectedValue,
                            UnitName = comboxUnitQty.Text,
                        },
                        UnitOfWgh = new Unit
                        {
                            UnitCode = (int)comboxUnitWgh.SelectedValue,
                            UnitName = comboxUnitWgh.Text,
                        },
                        Active = chkActive.Checked,
                        CreateBy = "system",
                    };
                    ProductController.Insert(product);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    var product = new Product
                    {
                        ProductCode = txtProductCode.Text.Trim(),
                        ProductName = txtProductName.Text.Trim(),
                        ProductGroup = new ProductGroup
                        {
                            ProductGroupCode = (int)comboxProductGroup.SelectedValue,
                            ProductGroupName = comboxProductGroup.Text,
                        },
                        UnitOfQty = new Unit
                        {
                            UnitCode = (int)comboxUnitQty.SelectedValue,
                            UnitName = comboxUnitQty.Text,
                        },
                        UnitOfWgh = new Unit
                        {
                            UnitCode = (int)comboxUnitWgh.SelectedValue,
                            UnitName = comboxUnitWgh.Text,
                        },
                        Active = chkActive.Checked,
                        ModifiedBy = "system",
                    };
                    ProductController.Update(product);
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
                //UnitOfQty = new Unit;
                //UnitOfWgh = new Unit;
                var product = new Product
                {
                    ProductCode = txtProductCode.Text.Trim(),
                    ProductName = txtProductName.Text.Trim(),
                    ProductGroup = new ProductGroup
                    {
                        ProductGroupCode = (int)comboxProductGroup.SelectedValue,
                        ProductGroupName = comboxProductGroup.Text,
                    },
                    UnitOfQty = new Unit
                    {
                        UnitCode = (int)comboxUnitQty.SelectedValue,
                        UnitName = comboxUnitQty.Text,  
                    },
                    UnitOfWgh = new Unit
                    {
                        UnitCode = (int)comboxUnitWgh.SelectedValue,
                        UnitName = comboxUnitWgh.Text,
                    },
                    Active = chkActive.Checked,
                    CreateBy = "system",
                };
                ProductController.Insert(product);
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtProductCode.Text = "";
                txtProductCode.Focus();
                txtProductName.Text = "";
                comboxProductGroup.SelectedIndex = 0;
                comboxUnitQty.SelectedIndex = 0;
                comboxUnitWgh.SelectedIndex = 0;
                chkActive.Checked = true;

            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void  FillProductGroup()
        {
            comboxProductGroup.DataSource = ProductGroupController.GetAllProudctGroups();
            comboxProductGroup.ValueMember = "ProductGroupCode";
            comboxProductGroup.DisplayMember = "ProductGroupName";
        }
        private void FillUnitQtyWgh()
        {
            comboxUnitQty.DataSource = UnitController.GetAllUnits();
            comboxUnitQty.ValueMember = "UnitCode";
            comboxUnitQty.DisplayMember = "UnitName";

            comboxUnitWgh.DataSource = UnitController.GetAllUnits();
            comboxUnitWgh.ValueMember = "UnitCode";
            comboxUnitWgh.DisplayMember = "UnitName";
        }

    }
}
