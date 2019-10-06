using SlaughterHouseLib.Models;
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
            dtpStartDate.KeyDown += DtpStartDate_KeyDown;
            txtDay.KeyDown += TxtDay_KeyDown;

            //Click
            btnLovProduct.Click += BtnLovProduct_Click;
        }
        private void Form_Shown(object sender, System.EventArgs e)
        {
            dtpStartDate.Focus();
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
        private void TxtDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUnitPrice.Focus();
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
        private void BtnLovProduct_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new Form_LovProduct();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtProductName.Text = frm.productName;
                    this.productCode = frm.productCode;
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

        private void SaveProductPrice()
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
                    EndDate = dtpStartDate.Value.AddDays(Convert.ToInt16(txtDay.Text)),
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
