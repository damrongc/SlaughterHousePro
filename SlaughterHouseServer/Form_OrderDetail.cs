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
        public enum ProgramMode { Add, Edit }
        public ProgramMode pgMode { get; set; }

        public Form_OrderDetail()
        {
            InitializeComponent();

            //txtFarmCode.KeyDown += TxtFarmCode_KeyDown;
            //txtFarmName.KeyDown += TxtFarmName_KeyDown;
            //txtAddress.KeyDown += TxtAddress_KeyDown;
            this.Load += Form_Load;
            this.Shown += Form_Shown;
            pgMode = ProgramMode.Add;
        }

        private void Form_Shown(object sender, System.EventArgs e)
        {
            //txtFarmCode.Focus();
            //if (!string.IsNullOrEmpty(this.orderNo))
            //{
            //    BtnSaveAndNew.Visible = false;
        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            LoadProduct();
            if (!string.IsNullOrEmpty(this.productCode))
            { 
                cboProduct.SelectedValue = this.productCode;
                txtQty.Text = this.qty.ToString();
                txtWgh.Text = this.wgh.ToString(); 
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
    }
}

   

    //private void TxtAddress_KeyDown(object sender, KeyEventArgs e)
    //{
    //    if (e.KeyCode == Keys.Enter)
    //    {
    //        BtnSaveAndNew.Focus();
    //    }
    //}

    //private void TxtFarmName_KeyDown(object sender, KeyEventArgs e)
    //{
    //    if (e.KeyCode == Keys.Enter)
    //    {
    //        txtAddress.Focus();
    //    }
    //}

    //private void TxtFarmCode_KeyDown(object sender, KeyEventArgs e)
    //{
    //    if (e.KeyCode == Keys.Enter)
    //    {
    //        txtFarmName.Focus();
    //    }
    //}

    //private void BtnSave_Click(object sender, System.EventArgs e)
    //{
    //    try
    //    {
    //        if (string.IsNullOrEmpty(this.farmCode))
    //        {
    //            var farm = new Farm
    //            {
    //                FarmCode = txtFarmCode.Text.Trim(),
    //                FarmName = txtFarmName.Text.Trim(),
    //                Address = txtAddress.Text.Trim(),
    //                Active = chkActive.Checked,
    //                CreateBy = "system",
    //            };
    //            FarmController.Insert(farm);
    //            MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

    //        }
    //        else
    //        {
    //            var farm = new Farm
    //            {
    //                FarmCode = txtFarmCode.Text.Trim(),
    //                FarmName = txtFarmName.Text.Trim(),
    //                Address = txtAddress.Text.Trim(),
    //                Active = chkActive.Checked,
    //                ModifiedBy = "system",
    //            };
    //            FarmController.Update(farm);
    //            MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //        }

    //        this.DialogResult = DialogResult.OK;
    //        this.Close();
    //    }
    //    catch (System.Exception ex)
    //    {

    //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }

    //}

    //private void BtnSaveAndNew_Click(object sender, System.EventArgs e)
    //{
    //    try
    //    {

    //        var farm = new Farm
    //        {
    //            FarmCode = txtFarmCode.Text.Trim(),
    //            FarmName = txtFarmName.Text.Trim(),
    //            Address = txtAddress.Text.Trim(),
    //            Active = chkActive.Checked,
    //            CreateBy = "system",
    //        };
    //        FarmController.Insert(farm);
    //        MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

    //        txtFarmCode.Text = "";
    //        txtFarmCode.Focus();
    //        txtFarmName.Text = "";
    //        txtAddress.Text = "";
    //        chkActive.Checked = true;

    //    }
    //    catch (System.Exception ex)
    //    {

    //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //}
      