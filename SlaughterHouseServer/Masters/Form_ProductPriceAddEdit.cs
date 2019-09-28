﻿using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_ProductPriceAddEdit : Form
    {
        public string productCode { get; set; }
        public DateTime startDate { get; set; }

        public Form_ProductPriceAddEdit()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {

            this.Load += Form_Load;
            this.Shown += Form_Shown;

            //KeyDown  
            dtpStartDate.KeyDown += DtpStartDate_KeyDown;
            cboProduct.KeyDown += CboProduct_KeyDown;
        }
        private void Form_Shown(object sender, System.EventArgs e)
        {
            dtpStartDate.Focus();
        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadProduct();
            LoadData();
        }
        private void DtpStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboProduct.Focus();
            }
        }
        private void CboProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboProduct.Focus();
            }
        }

        #region Event Focus, KeyDown 
        private void TxtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSaveAndNew.Focus();
            }
        }

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
        #endregion

        #region Event Click
        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                SaveProductPrice();
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
                SaveProductPrice();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //orderNo = "";
                //txtOrderNo.Text = "";
                //txtOrderNo.Focus();
                //cboCustomer.SelectedIndex = 0;
                //txtComment.Text = "";
                //chkActive.Checked = true;
                //LoadDetail();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion
        private void LoadProduct()
        {
            var coll = ProductController.GetAllProducts();
            cboProduct.DisplayMember = "ProductName";
            cboProduct.ValueMember = "ProductCode";
            cboProduct.DataSource = coll;
        }

        private void LoadData()
        {
            if (productCode != null)
            {
                cboProduct.Enabled = false;
            }
            ProductPrice productPrice = ProductPriceController.GetProductPrice(this.productCode, this.startDate);
            if (productPrice != null)
            {

                cboProduct.SelectedValue = productPrice.Product.ProductCode;
                txtUnitPrice.Text = productPrice.UnitPrice.ToString();
                txtDay.Text = productPrice.Day.ToString();
                
                dtpStartDate.Value = productPrice.StartDate;
                dtpStartDate.Enabled = false;
                BtnSaveAndNew.Visible = false;
            }
        }

        private void SaveProductPrice()
        {
            try
            {
                
                var productPrice = new ProductPrice
                {
                    Product = new Product
                    {
                        ProductCode = cboProduct.SelectedValue.ToString()
                    },
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpStartDate.Value.AddDays(Convert.ToInt16(txtDay.Text)),
                    Day = Convert.ToInt16(txtDay.Text),

                    UnitPrice = Convert.ToDecimal(txtUnitPrice.Text),
                    CreateBy = "system",
                    ModifiedBy = "system"
                };

                if (cboProduct.Enabled == true)
                {
                    ProductPriceController.Insert(productPrice);
                }
                else
                {
                    ProductPriceController.Update(productPrice);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
