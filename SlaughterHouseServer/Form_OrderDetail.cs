using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_OrderDetail : Form
    {
        public string orderNo { get; set; }
        public string productCode { get; set; }
        public string productName{ get; set; }
        public int qty { get; set; }
        public decimal wgh { get; set; }

        private string SaleUnitMethod;

        public Form_OrderDetail()
        {
            InitializeComponent();
             
            this.Load += Form_Load;
            this.Shown += Form_Shown;
            //KeyDown 
            txtQty.KeyDown += TxtQty_KeyDown;
            txtWgh.KeyDown += TxtWgh_KeyDown;
            cboProduct.KeyDown += CboProduct_KeyDown;
            //KeyPress
            txtQty.KeyPress += TxtQty_KeyPress;
            txtWgh.KeyPress += TxtWgh_KeyPress;

            cboProduct.SelectedIndexChanged += CboProduct_SelectedIndexChanged;
        }

        private void CboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cboProduct.SelectedValue.ToString()) == false)
            {
                LockControlBySaleUnitMethod(cboProduct.SelectedValue.ToString());
                txtQty.Text = "0";
                txtWgh.Text = "0";
            }
        }
         

        private void Form_Shown(object sender, System.EventArgs e)
        {
           
        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadProduct();
            if (!string.IsNullOrEmpty(this.productCode))
            { 
                cboProduct.SelectedValue = this.productCode;
                LockControlBySaleUnitMethod(this.productCode);
            }
            txtQty.Text = this.qty.ToString();
            txtWgh.Text = this.wgh.ToString(); 
        }
        private void CboProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.SaleUnitMethod == "Q")
                {
                    txtQty.Focus();
                }
                else if (this.SaleUnitMethod == "W")
                {
                    txtWgh.Focus();
                }
            }
        }
        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddOrderItem.Focus();
            }
        }
        private void TxtWgh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddOrderItem.Focus();
            }
        }
        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }
        private void TxtWgh_KeyPress(object sender, KeyPressEventArgs e)
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
        private void btnAddOrderItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.productCode = cboProduct.SelectedValue.ToString();
                this.productName = cboProduct.Text;
                this.qty = Convert.ToInt32(txtQty.Text);
                this.wgh = Convert.ToDecimal(txtWgh.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadProduct()
        {
            var coll = ProductController.GetAllProducts();
            cboProduct.DisplayMember = "ProductName";
            cboProduct.ValueMember = "ProductCode";
            cboProduct.DataSource = coll;
        }

        private void LockControlBySaleUnitMethod(string productCode)
        {
            Product product = ProductController.GetProduct(productCode);
            this.SaleUnitMethod = product.SaleUnitMethod;
            if (product.SaleUnitMethod == "Q")
            {
                txtQty.Enabled = true;
                txtWgh.Enabled = false;
            }
            else if (product.SaleUnitMethod == "W")
            {
                txtQty.Enabled = false;
                txtWgh.Enabled = true;
            }
        }
    }
}
 