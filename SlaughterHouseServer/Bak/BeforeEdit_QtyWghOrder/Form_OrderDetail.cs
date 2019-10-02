using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_OrderDetail : Form
    {
        public string orderNo { get; set; }
        public string productCode { get; set; }
        public string productName { get; set; }
        public decimal qtyWgh { get; set; }
        public int unitCode { get; set; }
        public string unitName { get; set; }
        public string issueUnitMethod { get; set; }
        public DateTime orderDate { get; set; }

        public Form_OrderDetail()
        {
            InitializeComponent();

            this.Load += Form_Load;
            this.Shown += Form_Shown;
            //KeyDown 
            txtQtyWgh.KeyDown += TxtQtyWgh_KeyDown;
            cboProduct.KeyDown += CboProduct_KeyDown;
            //KeyPress
            txtQtyWgh.KeyPress += TxtQtyWgh_KeyPress;
            cboProduct.SelectedIndexChanged += CboProduct_SelectedIndexChanged;
        }

        private void CboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cboProduct.SelectedValue.ToString()) == false)
            {
                //LockControlBySaleUnitMethod(cboProduct.SelectedValue.ToString());
                txtQtyWgh.Text = "0";
                SetUnitMethod(cboProduct.SelectedValue.ToString());
                SetUnitName(cboProduct.SelectedValue.ToString());
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
                //LockControlBySaleUnitMethod(this.productCode);
            }
            txtQtyWgh.Text = this.qtyWgh.ToString();
            lbUnitName.Text = this.unitName.ToString();
        }
        private void CboProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQtyWgh.Focus();
            }
        }
        private void TxtQtyWgh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddOrderItem.Focus();
            }
        }

        private void TxtQtyWgh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnAddOrderItem_Click(object sender, System.EventArgs e)
        {
            decimal unitPrice;
            try
            {
                if (String.IsNullOrEmpty(txtQtyWgh.Text) || Convert.ToDecimal(txtQtyWgh.Text) <= 0)
                {
                    MessageBox.Show("จำนวนต้องมากกว่า 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                unitPrice = Globals.GetPriceList("", cboProduct.SelectedValue.ToString(), this.orderDate);
                if (unitPrice == 0)
                {
                    MessageBox.Show("สินค้านี้ไม่มีราคาประกาศตามวันที่ต้องการสินค้า", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                this.productCode = cboProduct.SelectedValue.ToString();
                this.productName = cboProduct.Text;
                this.qtyWgh = Convert.ToDecimal(txtQtyWgh.Text);
                this.unitName = lbUnitName.Text;
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

        private void SetUnitName(string productCode)
        {
            Unit unit = UnitController.GetUnitNameOfIssue(productCode);
            this.unitCode = unit.UnitCode;
            this.unitName = unit.UnitName;
            lbUnitName.Text = unit.UnitName;
        }

        private void SetUnitMethod(string productCode)
        {
            Product product = ProductController.GetProduct(productCode);
            this.issueUnitMethod = product.IssueUnitMethod;
        }
    }
}
