﻿using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_CustomerPriceAddEdit : Form
    {
        public string customerCode { get; set; }
        public string productCode { get; set; }
        public DateTime startDate { get; set; }

        public Form_CustomerPriceAddEdit()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {

            this.Load += Form_Load;
            this.Shown += Form_Shown;

            //KeyDown
            cboCustomer.KeyDown += CboCustomer_KeyDown;
            dtpStartDate.KeyDown += DtpStartDate_KeyDown;
            txtDay.KeyDown += TxtDay_KeyDown;
            txtUnitPrice.KeyDown += TxtUnitPrice_KeyDown;



            txtDay.KeyPress += TxtDay_KeyPress;
            txtUnitPrice.KeyPress += TxtUnitPrice_KeyPress;
            //Click
            btnLovProduct.Click += BtnLovProduct_Click;
        }
        private void Form_Shown(object sender, System.EventArgs e)
        {
            cboCustomer.Focus();
        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadCustomer();
            LoadData();
        }
        private void DtpStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDay.Focus();
            }
        }


        #region Event Focus, KeyDown
        private void CboCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLovProduct.Focus();
            }
        }
        private void TxtDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUnitPrice.Focus();
            }
        }

        private void TxtUnitPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSaveAndNew.Focus();
            }
        }

        private void TxtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }
        private void TxtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
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
        private void BtnLovProduct_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new Form_LovProduct();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtProductName.Text = frm.productName;
                    this.productCode = frm.productCode;
                    dtpStartDate.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                CheckBeforeSave();
                Save();
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
                CheckBeforeSave();
                Save();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cboCustomer.SelectedIndex = 0;
                this.productCode = "";
                txtProductName.Text = "";
                txtUnitPrice.Text = "0";
                txtDay.Text = "0";
                dtpStartDate.Value = DateTime.Now;
                LoadData();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        private void LoadCustomer()
        {
            var coll = CustomerController.GetAllCustomers();
            cboCustomer.DisplayMember = "CustomerName";
            cboCustomer.ValueMember = "CustomerCode";
            cboCustomer.DataSource = coll;
        }
        private void LoadData()
        {
            if (String.IsNullOrEmpty(this.productCode) == false)
            {
                btnLovProduct.Enabled = false;
                txtProductName.Enabled = false;
                cboCustomer.Enabled = false;
            }

            CustomerPrice customerPrice = CustomerPriceController.GetCustomerPrice(this.customerCode, this.productCode, this.startDate);
            if (customerPrice != null)
            {
                cboCustomer.SelectedValue = customerPrice.Customer.CustomerCode;

                this.productCode = customerPrice.Product.ProductCode;
                txtProductName.Text = customerPrice.Product.ProductName;
                txtUnitPrice.Text = customerPrice.UnitPrice.ToString();
                txtDay.Text = customerPrice.Day.ToString();

                dtpStartDate.Value = customerPrice.StartDate;
                dtpStartDate.Enabled = false;
                BtnSaveAndNew.Visible = false;
            }
        }

        private void CheckBeforeSave()
        {
            try
            {
                if (string.IsNullOrEmpty(txtProductName.Text))
                {
                    throw new Exception(ConstErrorMsg.ProductNull);
                }
                txtDay.Text = (string.IsNullOrEmpty(txtDay.Text)) ? "0" : txtDay.Text;
                txtUnitPrice.Text = (string.IsNullOrEmpty(txtUnitPrice.Text)) ? "0" : txtUnitPrice.Text;
                if (Convert.ToInt32(txtDay.Text) == 0)
                {
                    throw new Exception(ConstErrorMsg.DayIsZero);
                }
                if (Convert.ToDecimal(txtUnitPrice.Text) == 0)
                {
                    throw new Exception(ConstErrorMsg.UnitPriceIsZero);
                }
            }
            catch
            {
                throw;
            }
        }

        private void Save()
        {
            try
            {
                var customerPrice = new CustomerPrice
                {
                    Customer = new Customer
                    {
                        CustomerCode = cboCustomer.SelectedValue.ToString()
                    },
                    Product = new Product
                    {
                        ProductCode = this.productCode
                    },
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpStartDate.Value.AddDays(Convert.ToInt16(txtDay.Text) - 1),
                    Day = Convert.ToInt16(txtDay.Text),

                    UnitPrice = Convert.ToDecimal(txtUnitPrice.Text),
                    CreateBy = "system",
                    ModifiedBy = "system"
                };

                if (btnLovProduct.Enabled == true && cboCustomer.Enabled == true)
                {
                    CustomerPriceController.Insert(customerPrice);
                }
                else
                {
                    CustomerPriceController.Update(customerPrice);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
