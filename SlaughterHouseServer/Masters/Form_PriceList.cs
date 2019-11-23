using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_PriceList : Form
    {
        public Form_PriceList()
        {
            InitializeComponent();
            UserSettingsComponent();
        }

        private void UserSettingsComponent()
        {
            BtnAdd.Click += BtnAdd_Click;
            BtnSearch.Click += BtnSearch_Click;

            gv.CellContentClick += Gv_CellContentClick;
            gv.DataBindingComplete += Gv_DataBindingComplete;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;

            //BtnAddCv.Click += BtnAddCv_Click;
            //BtnSearchCv.Click += BtnSearchCv_Click;
            //gvCv.CellContentClick += GvCv_CellContentClick;
            //gvCv.DataBindingComplete += GvCv_DataBindingComplete;
            //gvCv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //gvCv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            //gvCv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            //gvCv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //gvCv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gvCv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            //gvCv.EnableHeadersVisualStyles = false;


            BtnAddClassDis.Click += BtnAddClassDis_Click;
            BtnSearchClassDis.Click += BtnSearchClassDis_Click;

            gvClassDis.CellContentClick += GvClassDis_CellContentClick;
            gvClassDis.DataBindingComplete += GvClassDis_DataBindingComplete;
            gvClassDis.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gvClassDis.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gvClassDis.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gvClassDis.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gvClassDis.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvClassDis.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gvClassDis.EnableHeadersVisualStyles = false;

            LoadProduct();
            LoadProductPrice();

            LoadCustomerClass();
            LoadClassDiscount();

            //LoadCustomerPrice();
            tabControlPrice.TabPages.Remove(tabPageCustomer);

        }

        private void LoadProduct()
        {
            var coll = ProductController.GetAllProducts();
            coll.Insert(0, new Product
            {
                ProductCode = "",
                ProductName = "--ทั้งหมด--"
            });
            cboProduct.DisplayMember = "ProductName";
            cboProduct.ValueMember = "ProductCode";
            cboProduct.DataSource = coll;

            cboProductCv.DisplayMember = "ProductName";
            cboProductCv.ValueMember = "ProductCode";
            cboProductCv.DataSource = coll;
        }

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gv.Columns[ConstColumns.ProductCode].HeaderText = "รหัสสินค้า";
            gv.Columns[ConstColumns.ProductName].HeaderText = "ชื่อสินค้า";
            gv.Columns[ConstColumns.StartDate].HeaderText = "วันที่เริ่มต้น";
            gv.Columns[ConstColumns.EndDate].HeaderText = "วินที่สิ้นสุด";
            gv.Columns[ConstColumns.UnitPrice].HeaderText = "ราคาต่อหน่วย";
            gv.Columns[ConstColumns.Day].HeaderText = "จำนวนวัน";
            gv.Columns[ConstColumns.CreateAt].HeaderText = "วันเวลาสร้าง";
            gv.Columns[ConstColumns.CreateBy].HeaderText = "ผู้สร้าง";
            gv.Columns[ConstColumns.ModifiedAt].HeaderText = "วันเวลาแก้ไข";
            gv.Columns[ConstColumns.ModifiedBy].HeaderText = "ผู้แก้ไข";

            gv.Columns[ConstColumns.StartDate].DefaultCellStyle.Format = "dd/MM/yyyy";
            gv.Columns[ConstColumns.EndDate].DefaultCellStyle.Format = "dd/MM/yyyy";
            gv.Columns[ConstColumns.CreateAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            gv.Columns[ConstColumns.ModifiedAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }
        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    string productCode = gv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    DateTime startDate = (DateTime)gv.Rows[e.RowIndex].Cells[3].Value;

                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {

                        case "Edit":
                            var frm = new Form_ProductPriceAddEdit
                            {
                                productCode = productCode,
                                startDate = startDate
                            };
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                LoadProductPrice();
                            }
                            break;
                        case "Print":
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnSearch_Click(object sender, System.EventArgs e)
        {
            LoadProductPrice();
        }
        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_ProductPriceAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadProductPrice();
            }
        }
        private void LoadProductPrice()
        {
            var coll = ProductPriceController.GetAllProductPrices(dtpStartDate.Value, cboProduct.SelectedValue.ToString());
            gv.DataSource = coll;
        }


        private void LoadCustomerClass()
        {
            var coll = CustomerClassController.GetAllCustomerClass();
            coll.Insert(0, new CustomerClass
            {
                ClassId = 0,
                ClassName = "--ทั้งหมด--"
            });
            cboClassId.DisplayMember = "ClassName";
            cboClassId.ValueMember = "ClassId";
            cboClassId.DataSource = coll;

        }
        private void GvClassDis_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gvClassDis.Columns[ConstColumns.ClassId].HeaderText = "รหัสกลุ่มลูกค้า";
            gvClassDis.Columns[ConstColumns.ClassName].HeaderText = "ชื่อกลุ่มลูกค้า";
            gvClassDis.Columns[ConstColumns.StartDate].HeaderText = "วันที่เริ่มต้น";
            gvClassDis.Columns[ConstColumns.EndDate].HeaderText = "วินที่สิ้นสุด";
            gvClassDis.Columns[ConstColumns.DiscountPer].HeaderText = "ส่วนลด %";
            gvClassDis.Columns[ConstColumns.Day].HeaderText = "จำนวนวัน";
            gvClassDis.Columns[ConstColumns.CreateAt].HeaderText = "วันเวลาสร้าง";
            gvClassDis.Columns[ConstColumns.CreateBy].HeaderText = "ผู้สร้าง";
            gvClassDis.Columns[ConstColumns.ModifiedAt].HeaderText = "วันเวลาแก้ไข";
            gvClassDis.Columns[ConstColumns.ModifiedBy].HeaderText = "ผู้แก้ไข";

            gvClassDis.Columns[ConstColumns.StartDate].DefaultCellStyle.Format = "dd/MM/yyyy";
            gvClassDis.Columns[ConstColumns.EndDate].DefaultCellStyle.Format = "dd/MM/yyyy";
            gvClassDis.Columns[ConstColumns.CreateAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            gvClassDis.Columns[ConstColumns.ModifiedAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            gvClassDis.Columns[ConstColumns.ClassId].Visible = false;
        }
        private void GvClassDis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    Int32 classId = Convert.ToInt32(gvClassDis.Rows[e.RowIndex].Cells[ConstColumns.ClassId].Value);
                    DateTime startDate = (DateTime)gvClassDis.Rows[e.RowIndex].Cells[ConstColumns.StartDate].Value;

                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {
                        case "EditClassDis":
                            var frm = new Form_CustomerClassDiscountAddEdit
                            {
                                classId = classId,
                                startDate = startDate
                            };
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                LoadClassDiscount();
                            }
                            break;
                        case "Print":
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnSearchClassDis_Click(object sender, System.EventArgs e)
        {
            LoadClassDiscount();
        }
        private void BtnAddClassDis_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_CustomerClassDiscountAddEdit();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadClassDiscount();
            }
        }
        private void LoadClassDiscount()
        {
            var coll = CustomerClassDiscountController.GetAllCustomerClassDiscount(dtpStartDateClassDis.Value, Convert.ToInt32(cboClassId.SelectedValue));
            gvClassDis.DataSource = coll;
        }



        //****--*-***-*--* Comment Case  CustomerPrice
        //private void BtnAddCv_Click(object sender, System.EventArgs e)
        //{
        //    var frm = new Form_CustomerPriceAddEdit();
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        LoadCustomerPrice();
        //    }
        //}
        //private void GvCv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{

        //}
        //private void GvCv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        DataGridView senderGrid = (DataGridView)sender;

        //        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
        //        {
        //            string customerCode = gvCv.Rows[e.RowIndex].Cells[ConstColumns.CustomerCode].Value.ToString();
        //            string productCode = gvCv.Rows[e.RowIndex].Cells[ConstColumns.ProductCode].Value.ToString();
        //            DateTime startDate = (DateTime)gvCv.Rows[e.RowIndex].Cells[ConstColumns.StartDate].Value;

        //            switch (senderGrid.Columns[e.ColumnIndex].Name)
        //            {

        //                case "EditCv":
        //                    var frm = new Form_CustomerPriceAddEdit
        //                    {
        //                        customerCode = customerCode,
        //                        productCode = productCode,
        //                        startDate = startDate
        //                    };
        //                    if (frm.ShowDialog() == DialogResult.OK)
        //                    {
        //                        LoadCustomerPrice();
        //                    }
        //                    break;
        //                case "Print":
        //                    break;
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private void BtnSearchCv_Click(object sender, System.EventArgs e)
        //{
        //    LoadCustomerPrice();
        //}
        //private void LoadCustomerPrice()
        //{
        //    var coll = CustomerPriceController.GetAllCustomerPrices(dtpStartDateCv.Value, cboProductCv.SelectedValue.ToString());
        //    gvCv.DataSource = coll;
        //    gvCv.Columns[ConstColumns.CustomerCode].HeaderText = "รหัสลูกค้า";
        //    gvCv.Columns[ConstColumns.CustomerName].HeaderText = "ชื่อลูกค้า";
        //    gvCv.Columns[ConstColumns.ProductCode].HeaderText = "รหัสสินค้า";
        //    gvCv.Columns[ConstColumns.ProductName].HeaderText = "ชื่อสินค้า";
        //    gvCv.Columns[ConstColumns.StartDate].HeaderText = "วันที่เริ่มต้น";
        //    gvCv.Columns[ConstColumns.EndDate].HeaderText = "วินที่สิ้นสุด";
        //    gvCv.Columns[ConstColumns.UnitPrice].HeaderText = "ราคาต่อหน่วย";
        //    gvCv.Columns[ConstColumns.Day].HeaderText = "จำนวนวัน";
        //    gvCv.Columns[ConstColumns.CreateAt].HeaderText = "วันเวลาสร้าง";
        //    gvCv.Columns[ConstColumns.CreateBy].HeaderText = "ผู้สร้าง";

        //    gvCv.Columns[ConstColumns.ModifiedAt].HeaderText = "วันเวลาแก้ไข";
        //    gvCv.Columns[ConstColumns.ModifiedBy].HeaderText = "ผู้แก้ไข";

            //gvCv.Columns[ConstColumns.StartDate].DefaultCellStyle.Format = "dd/MM/yyyy";
            //gvCv.Columns[ConstColumns.EndDate].DefaultCellStyle.Format = "dd/MM/yyyy";
            //gvCv.Columns[ConstColumns.CreateAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            //gvCv.Columns[ConstColumns.ModifiedAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        //}

    }
}