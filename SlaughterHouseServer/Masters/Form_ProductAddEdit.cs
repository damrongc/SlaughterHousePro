﻿using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_ProductAddEdit : Form
    {
        public string productCode;

        public Form_ProductAddEdit()
        {
            InitializeComponent();
            //KeyDown
            txtProductCode.KeyDown += TxtProductCode_KeyDown;
            txtProductName.KeyDown += TxtProductName_KeyDown;
            comboxProductGroup.KeyDown += ComboxProductGroup_KeyDown;
            comboxUnitQty.KeyDown += ComboxUnitQty_KeyDown;
            comboxUnitWgh.KeyDown += ComboxUnitWgh_KeyDown;
            txtMinWgh.KeyDown += TxtMinWgh_KeyDown;
            txtMaxWgh.KeyDown += TxtMaxWgh_KeyDown;
            txtStdYield.KeyDown += TxtStdYield_KeyDown;
            txtPackingSize.KeyDown += TxtPackingSize_KeyDown;

            //KeyPress
            txtMinWgh.KeyPress += TxtMinWgh_KeyPress;
            txtMaxWgh.KeyPress += TxtMaxWgh_KeyPress;
            txtStdYield.KeyPress += TxtStdYield_KeyPress;
            txtPackingSize.KeyPress += TxtPackingSize_KeyPress;


            this.Load += Form_ProductAddEdit_Load;
            this.Shown += Form_ProductAddEdit_Shown;
        }


        private void TxtPackingSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                if (e.KeyChar != 46)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        private void TxtStdYield_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                if (e.KeyChar != 46)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void TxtMaxWgh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                if (e.KeyChar != 46)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void TxtMinWgh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                if (e.KeyChar != 46)
                {
                    e.Handled = true;
                    return;
                }
            }
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
                    comboxUnitQty.SelectedValue = product.UnitOfQty.UnitCode;
                    comboxUnitWgh.SelectedValue = product.UnitOfWgh.UnitCode;
                    txtMinWgh.Text = product.MinWeight.ToString();
                    txtMaxWgh.Text = product.MaxWeight.ToString();
                    txtStdYield.Text = product.StdYield.ToString();
                    txtPackingSize.Text = product.PackingSize.ToString();
                    if (product.SaleUnitMethod.ToUpper() == "Q")
                    {
                        rdbQtySale.Checked = true;
                    }
                    else if (product.SaleUnitMethod.ToUpper() == "W")
                    {
                        rdbWghSale.Checked = true;
                    }
                    if (product.IssueUnitMethod.ToUpper() == "Q")
                    {
                        rdbQtyIssue.Checked = true;
                    }
                    else if (product.SaleUnitMethod.ToUpper() == "W")
                    {
                        rdbWghIssue.Checked = true;
                    }
                    chkActive.Checked = product.Active;
                }
            }
            else
            {
                txtMinWgh.Text = "0";
                txtMaxWgh.Text = "0";
                txtStdYield.Text = "0";
                txtPackingSize.Text = "0";
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
                txtMinWgh.Focus();
            }
        }
        private void TxtMinWgh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMaxWgh.Focus();
            }
        }

        private void TxtMaxWgh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtStdYield.Focus();
            }
        }

        private void TxtPackingSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrEmpty(productCode))
                {
                    BtnSaveAndNew.Focus();
                }
                else
                {
                    BtnSave.Focus();
                }
            }
        }

        private void TxtStdYield_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPackingSize.Focus();
            }
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                CheckBeforeSave();
                if (string.IsNullOrEmpty(productCode))
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
                        MinWeight = Convert.ToDecimal(txtMinWgh.Text),
                        MaxWeight = Convert.ToDecimal(txtMaxWgh.Text),
                        StdYield = Convert.ToDecimal(txtStdYield.Text),
                        PackingSize = Convert.ToDecimal(txtPackingSize.Text),
                        SaleUnitMethod = (rdbQtySale.Checked == true) ? "Q" : "W",
                        IssueUnitMethod = (rdbQtyIssue.Checked == true) ? "Q" : "W",
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
                        MinWeight = Convert.ToDecimal(txtMinWgh.Text),
                        MaxWeight = Convert.ToDecimal(txtMaxWgh.Text),
                        StdYield = Convert.ToDecimal(txtStdYield.Text),
                        PackingSize = Convert.ToDecimal(txtPackingSize.Text),
                        SaleUnitMethod = (rdbQtySale.Checked == true) ? "Q" : "W",
                        IssueUnitMethod = (rdbQtyIssue.Checked == true) ? "Q" : "W",
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
                CheckBeforeSave();
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
                    MinWeight = Convert.ToDecimal(txtMinWgh.Text),
                    MaxWeight = Convert.ToDecimal(txtMaxWgh.Text),
                    StdYield = Convert.ToDecimal(txtStdYield.Text),
                    PackingSize = Convert.ToDecimal(txtPackingSize.Text),
                    SaleUnitMethod = (rdbQtySale.Checked == true) ? "Q" : "W",
                    IssueUnitMethod = (rdbQtyIssue.Checked == true) ? "Q" : "W",
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
                txtMinWgh.Text = 0.ToString();
                txtMaxWgh.Text = 0.ToString();
                txtStdYield.Text = 0.ToString();
                chkActive.Checked = true;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CheckBeforeSave()
        {
            try
            {
                if (string.IsNullOrEmpty(txtProductCode.Text) || txtProductCode.Text == "")
                {
                    throw new Exception($"โปรดระบุรหัสสินค้า");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FillProductGroup()
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
