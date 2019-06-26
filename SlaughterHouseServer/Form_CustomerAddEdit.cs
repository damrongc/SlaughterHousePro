using SlaughterHouseLib.Models;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_CustomerAddEdit : Form
    {
        public string customerCode;

        public Form_CustomerAddEdit()
        {
            InitializeComponent();

            txtCustomerCode.KeyDown += TxtCustomerCode_KeyDown;
            txtCustomerName.KeyDown += TxtCustomerName_KeyDown;
            //txtAddress.KeyDown += TxtAddress_KeyDown;
            txtShipTo.KeyDown += TxtShipTo_KeyDown;
            txtTaxId.KeyDown += TxtTaxId_KeyDown;
            txtContactNo.KeyDown += TxtContactNo_KeyDown;

            this.Load += Form_CustomerAddEdit_Load;
            this.Shown += Form_CustomerAddEdit_Shown;
        }

        private void Form_CustomerAddEdit_Shown(object sender, System.EventArgs e)
        {
            txtCustomerCode.Focus();
            if (!string.IsNullOrEmpty(this.customerCode))
            {
                BtnSaveAndNew.Visible = false;
            }
        }

        private void Form_CustomerAddEdit_Load(object sender, System.EventArgs e)
        {

            if (!string.IsNullOrEmpty(this.customerCode))
            {

                var customer = CustomerController.GetCustomer(this.customerCode);
                if (customer != null)
                {
                    txtCustomerCode.Text = customer.CustomerCode;
                    txtCustomerCode.Enabled = false;
                    txtCustomerName.Text = customer.CustomerName;
                    txtAddress.Text = customer.Address;
                    txtShipTo.Text = customer.ShipTo;
                    txtTaxId.Text = customer.TaxId;
                    txtContactNo.Text = customer.ContactNo;
                    chkActive.Checked = customer.Active;
                }
            }
        }
        private void TxtContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSaveAndNew.Focus();
            }
        }
        private void TxtTaxId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContactNo.Focus();
            }
        }
        private void TxtShipTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTaxId.Focus();
            }
        }

        private void TxtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtShipTo.Focus();
            }
        }

        private void TxtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
            }
        }

        private void TxtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerName.Focus();
            }
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.customerCode))
                {
                    var customer = new Customer
                    {
                        CustomerCode = txtCustomerCode.Text.Trim(),
                        CustomerName = txtCustomerName.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        ShipTo = txtShipTo.Text.Trim(),
                        TaxId = txtTaxId.Text.Trim(),
                        ContactNo = txtContactNo.Text.Trim(),
                        Active = chkActive.Checked,
                        CreateBy = "system",
                    };
                    CustomerController.Insert(customer);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    var customer = new Customer 
                    {
                        CustomerCode = txtCustomerCode.Text.Trim(),
                        CustomerName = txtCustomerName.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        ShipTo = txtShipTo.Text.Trim(),
                        TaxId = txtTaxId.Text.Trim(),
                        ContactNo = txtContactNo.Text.Trim(),
                        Active = chkActive.Checked,
                        ModifiedBy = "system",
                    };
                    CustomerController.Update(customer);
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

                var customer = new Customer
                {
                    CustomerCode = txtCustomerCode.Text.Trim(),
                    CustomerName = txtCustomerName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    ShipTo = txtShipTo.Text.Trim(),
                    TaxId = txtTaxId.Text.Trim(),
                    ContactNo = txtContactNo.Text.Trim(),
                    Active = chkActive.Checked,
                    CreateBy = "system",
                };
                CustomerController.Insert(customer);
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCustomerCode.Text = "";
                txtCustomerCode.Focus();
                txtCustomerName.Text = "";
                txtAddress.Text = "";
                txtShipTo.Text = "";
                txtTaxId.Text = "";
                txtContactNo.Text = "";
                chkActive.Checked = true;

            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, System.EventArgs e)
        {

        }

        private void label3_Click(object sender, System.EventArgs e)
        {

        }

        private void label4_Click(object sender, System.EventArgs e)
        {

        }

        private void chkActive_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void txtContactNo_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
