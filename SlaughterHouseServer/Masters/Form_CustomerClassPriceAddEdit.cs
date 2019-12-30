using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_CustomerClassPriceAddEdit : Form
    {
        public int classId { get; set; }
        public string productCode { get; set; }
        public DateTime startDate { get; set; }

        public Form_CustomerClassPriceAddEdit()
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
            txtDay.KeyPress += TxtDay_KeyPress;
            txtUnitPrice.KeyPress += TxtDay_KeyPress;
            //Click
            btnLovProduct.Click += BtnLovProduct_Click;
        }
        private void Form_Shown(object sender, System.EventArgs e)
        {
            dtpStartDate.Focus();
        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadCustomerClass();
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
        private void TxtDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUnitPrice.Focus();
            }
        }

        private void TxtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 49 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }
        private void TxtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 49 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
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

                cboCustomerClass.SelectedIndex = 0;
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


        private void LoadData()
        {
            if (String.IsNullOrEmpty(this.productCode) == false)
            {
                btnLovProduct.Enabled = false;
                txtProductName.Enabled = false;
                cboCustomerClass.Enabled = false;
            }

            CustomerClassPrice customerPrice = CustomerClassPriceController.GetCustomerClassPrice(this.classId, this.productCode, this.startDate);
            if (customerPrice != null)
            {
                cboCustomerClass.SelectedValue = customerPrice.MasterClass.ClassId;

                this.productCode = customerPrice.Product.ProductCode;
                txtProductName.Text = customerPrice.Product.ProductName;
                txtUnitPrice.Text = customerPrice.UnitPrice.ToString();
                txtDay.Text = customerPrice.Day.ToString();

                dtpStartDate.Value = customerPrice.StartDate;
                dtpStartDate.Enabled = false;
                BtnSaveAndNew.Visible = false;
            }
        }

        private void LoadCustomerClass()
        {
            cboCustomerClass.DataSource = MasterClassController.GetAllMasterClass();
            cboCustomerClass.ValueMember = "ClassId";
            cboCustomerClass.DisplayMember = "ClassName";
        }

        private void SaveProductPrice()
        {
            try
            {
                var customerClassPrice = new CustomerClassPrice
                {
                    MasterClass = new MasterClass
                    {
                        ClassId = Convert.ToInt32(cboCustomerClass.SelectedValue)
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

                if (btnLovProduct.Enabled == true && cboCustomerClass.Enabled == true)
                {
                    CustomerClassPriceController.Insert(customerClassPrice);
                }
                else
                {
                    CustomerClassPriceController.Update(customerClassPrice);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
