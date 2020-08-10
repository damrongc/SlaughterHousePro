using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            //BtnAdd.Click += BtnAdd_Click;
            //BtnSearch.Click += BtnSearch_Click;

            //gv.CellContentClick += Gv_CellContentClick;
            //gv.DataBindingComplete += Gv_DataBindingComplete;
            //gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            //gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            //gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            //gv.EnableHeadersVisualStyles = false;

            BtnAddCustomerClass.Click += BtnAddCustomerClass_Click;
            BtnSearchCustomerClass.Click += BtnSearchCustomerClass_Click;
            gvCustomerClass.CellContentClick += GvCustomerClass_CellContentClick;
            gvCustomerClass.DataBindingComplete += GvCustomerClass_DataBindingComplete;
            gvCustomerClass.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gvCustomerClass.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gvCustomerClass.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gvCustomerClass.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gvCustomerClass.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCustomerClass.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gvCustomerClass.EnableHeadersVisualStyles = false;

            BtnAddCv.Click += BtnAddCv_Click;
            BtnSearchCv.Click += BtnSearchCv_Click;
            gvCv.CellContentClick += GvCv_CellContentClick;
            gvCv.DataBindingComplete += GvCv_DataBindingComplete;
            gvCv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gvCv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gvCv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gvCv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gvCv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gvCv.EnableHeadersVisualStyles = false;


            //BtnAddClassDis.Click += BtnAddClassDis_Click;
            //BtnSearchClassDis.Click += BtnSearchClassDis_Click;
            //gvClassDis.CellContentClick += GvClassDis_CellContentClick;
            //gvClassDis.DataBindingComplete += GvClassDis_DataBindingComplete;
            //gvClassDis.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //gvClassDis.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            //gvClassDis.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            //gvClassDis.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //gvClassDis.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gvClassDis.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            //gvClassDis.EnableHeadersVisualStyles = false;

            LoadProduct();
            //LoadProductPrice();
            LoadCustomerClassPrice();
            LoadCustomerPrice();

            //LoadClassDiscount();


            tabControlPrice.TabPages.Remove(tabPageProduct);
            tabControlPrice.TabPages.Remove(tabPageCustomerClassDis);

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

            //cboProductCustomerClass.DisplayMember = "ProductName";
            //cboProductCustomerClass.ValueMember = "ProductCode";
            //cboProductCustomerClass.DataSource = coll;

            cboProductCv.DisplayMember = "ProductName";
            cboProductCv.ValueMember = "ProductCode";
            cboProductCv.DataSource = coll;
        }
        #region ### Product
        //private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    gv.Columns[ConstColumns.ProductCode].HeaderText = "รหัสสินค้า";
        //    gv.Columns[ConstColumns.ProductName].HeaderText = "ชื่อสินค้า";
        //    gv.Columns[ConstColumns.StartDate].HeaderText = "วันที่เริ่มต้น";
        //    gv.Columns[ConstColumns.EndDate].HeaderText = "วินที่สิ้นสุด";
        //    gv.Columns[ConstColumns.UnitPrice].HeaderText = "ราคาต่อหน่วย";
        //    gv.Columns[ConstColumns.Day].HeaderText = "จำนวนวัน";
        //    gv.Columns[ConstColumns.CreateAt].HeaderText = "วันเวลาสร้าง";
        //    gv.Columns[ConstColumns.CreateBy].HeaderText = "ผู้สร้าง";
        //    gv.Columns[ConstColumns.ModifiedAt].HeaderText = "วันเวลาแก้ไข";
        //    gv.Columns[ConstColumns.ModifiedBy].HeaderText = "ผู้แก้ไข";

        //    gv.Columns[ConstColumns.UnitPrice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        //    gv.Columns[ConstColumns.UnitPrice].DefaultCellStyle.Format = "N2";
        //    gv.Columns[ConstColumns.Day].DefaultCellStyle.Format = "N0";

        //    gv.Columns[ConstColumns.StartDate].DefaultCellStyle.Format = "dd/MM/yyyy";
        //    gv.Columns[ConstColumns.EndDate].DefaultCellStyle.Format = "dd/MM/yyyy";
        //    gv.Columns[ConstColumns.CreateAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        //    gv.Columns[ConstColumns.ModifiedAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        //}
        //private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        DataGridView senderGrid = (DataGridView)sender;

        //        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
        //        {
        //            string productCode = gv.Rows[e.RowIndex].Cells[1].Value.ToString();
        //            DateTime startDate = (DateTime)gv.Rows[e.RowIndex].Cells[3].Value;

        //            switch (senderGrid.Columns[e.ColumnIndex].Name)
        //            {

        //                case "Edit":
        //                    var frm = new Form_ProductPriceAddEdit
        //                    {
        //                        productCode = productCode,
        //                        startDate = startDate
        //                    };
        //                    if (frm.ShowDialog() == DialogResult.OK)
        //                    {
        //                        LoadProductPrice();
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
        //private void BtnSearch_Click(object sender, System.EventArgs e)
        //{
        //    LoadProductPrice();
        //}
        //private void BtnAdd_Click(object sender, System.EventArgs e)
        //{
        //    var frm = new Form_ProductPriceAddEdit();
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        LoadProductPrice();
        //    }
        //}
        //private void LoadProductPrice()
        //{
        //    var coll = ProductPriceController.GetAllProductPrices(dtpStartDate.Value, cboProduct.SelectedValue.ToString());
        //    gv.DataSource = coll;
        //}
        #endregion !!!NotUse

        #region ### CustomerClass
        private void BtnAddCustomerClass_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_CustomerClassPriceAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomerClassPrice();
            }
        }
        private void GvCustomerClass_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
        private void GvCustomerClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    int classId = Convert.ToInt32(gvCustomerClass.Rows[e.RowIndex].Cells[ConstColumns.ClassId].Value);
                    string productCode = gvCustomerClass.Rows[e.RowIndex].Cells[ConstColumns.ProductCode].Value.ToString();
                    DateTime startDate = (DateTime)gvCustomerClass.Rows[e.RowIndex].Cells[ConstColumns.StartDate].Value;

                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {

                        case "EditCustomerClass":
                            var frm = new Form_CustomerClassPriceAddEdit
                            {
                                classId = classId,
                                productCode = productCode,
                                startDate = startDate
                            };
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                LoadCustomerClassPrice();
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
        private void BtnSearchCustomerClass_Click(object sender, System.EventArgs e)
        {
            LoadCustomerClassPrice();
        }
        private void LoadCustomerClassPrice()
        {
            var coll = CustomerClassPriceController.GetAllCustomerClassPrices(dtpStartDateCustomerClass.Value, txtProductFilter.Text);
            gvCustomerClass.DataSource = coll;
            gvCustomerClass.Columns[ConstColumns.ClassId].HeaderText = "รหัสระดับลูกค้า";
            gvCustomerClass.Columns[ConstColumns.ClassName].HeaderText = "กลุ่มลูกค้า";
            gvCustomerClass.Columns[ConstColumns.ProductCode].HeaderText = "รหัสสินค้า";
            gvCustomerClass.Columns[ConstColumns.ProductName].HeaderText = "ชื่อสินค้า";
            gvCustomerClass.Columns[ConstColumns.StartDate].HeaderText = "วันที่เริ่มต้น";
            gvCustomerClass.Columns[ConstColumns.EndDate].HeaderText = "วินที่สิ้นสุด";
            gvCustomerClass.Columns[ConstColumns.UnitPrice].HeaderText = "ราคาต่อหน่วย";
            gvCustomerClass.Columns[ConstColumns.Day].HeaderText = "จำนวนวัน";
            gvCustomerClass.Columns[ConstColumns.CreateAt].HeaderText = "วันเวลาสร้าง";
            gvCustomerClass.Columns[ConstColumns.CreateBy].HeaderText = "ผู้สร้าง";
            gvCustomerClass.Columns[ConstColumns.ModifiedAt].HeaderText = "วันเวลาแก้ไข";
            gvCustomerClass.Columns[ConstColumns.ModifiedBy].HeaderText = "ผู้แก้ไข";


            gvCustomerClass.Columns[ConstColumns.ClassId].Visible = false;

            gvCustomerClass.Columns[ConstColumns.UnitPrice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvCustomerClass.Columns[ConstColumns.Day].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gvCustomerClass.Columns[ConstColumns.UnitPrice].DefaultCellStyle.Format = "N2";
            gvCustomerClass.Columns[ConstColumns.Day].DefaultCellStyle.Format = "N0";


            gvCustomerClass.Columns[ConstColumns.StartDate].DefaultCellStyle.Format = "dd/MM/yyyy";
            gvCustomerClass.Columns[ConstColumns.EndDate].DefaultCellStyle.Format = "dd/MM/yyyy";
            gvCustomerClass.Columns[ConstColumns.CreateAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            gvCustomerClass.Columns[ConstColumns.ModifiedAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";


        }
        #endregion

        #region ### Customer
        private void BtnAddCv_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_CustomerPriceAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomerPrice();
            }
        }
        private void GvCv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
        private void GvCv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    string customerCode = gvCv.Rows[e.RowIndex].Cells[ConstColumns.CustomerCode].Value.ToString();
                    string productCode = gvCv.Rows[e.RowIndex].Cells[ConstColumns.ProductCode].Value.ToString();
                    DateTime startDate = (DateTime)gvCv.Rows[e.RowIndex].Cells[ConstColumns.StartDate].Value;

                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {

                        case "EditCv":
                            var frm = new Form_CustomerPriceAddEdit
                            {
                                customerCode = customerCode,
                                productCode = productCode,
                                startDate = startDate
                            };
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                LoadCustomerPrice();
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
        private void BtnSearchCv_Click(object sender, System.EventArgs e)
        {
            LoadCustomerPrice();
        }
        private void LoadCustomerPrice()
        {
            var coll = CustomerPriceController.GetAllCustomerPrices(dtpStartDateCv.Value, cboProductCv.SelectedValue.ToString());
            gvCv.DataSource = coll;
            gvCv.Columns[ConstColumns.CustomerCode].HeaderText = "รหัสลูกค้า";
            gvCv.Columns[ConstColumns.CustomerName].HeaderText = "ชื่อลูกค้า";
            gvCv.Columns[ConstColumns.ProductCode].HeaderText = "รหัสสินค้า";
            gvCv.Columns[ConstColumns.ProductName].HeaderText = "ชื่อสินค้า";
            gvCv.Columns[ConstColumns.StartDate].HeaderText = "วันที่เริ่มต้น";
            gvCv.Columns[ConstColumns.EndDate].HeaderText = "วินที่สิ้นสุด";
            gvCv.Columns[ConstColumns.UnitPrice].HeaderText = "ราคาต่อหน่วย";
            gvCv.Columns[ConstColumns.Day].HeaderText = "จำนวนวัน";
            gvCv.Columns[ConstColumns.CreateAt].HeaderText = "วันเวลาสร้าง";
            gvCv.Columns[ConstColumns.CreateBy].HeaderText = "ผู้สร้าง";
            gvCv.Columns[ConstColumns.ModifiedAt].HeaderText = "วันเวลาแก้ไข";
            gvCv.Columns[ConstColumns.ModifiedBy].HeaderText = "ผู้แก้ไข";


            gvCv.Columns[ConstColumns.UnitPrice].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvCv.Columns[ConstColumns.Day].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gvCv.Columns[ConstColumns.UnitPrice].DefaultCellStyle.Format = "N2";
            gvCv.Columns[ConstColumns.Day].DefaultCellStyle.Format = "N0";


            gvCv.Columns[ConstColumns.StartDate].DefaultCellStyle.Format = "dd/MM/yyyy";
            gvCv.Columns[ConstColumns.EndDate].DefaultCellStyle.Format = "dd/MM/yyyy";
            gvCv.Columns[ConstColumns.CreateAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            gvCv.Columns[ConstColumns.ModifiedAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";


        }



        #endregion

        #region ### CustomerClassDiscount !!!NotUse
        //private void LoadCustomerClass()
        //{
        //    var coll = CustomerClassController.GetAllCustomerClass();
        //    coll.Insert(0, new CustomerClass
        //    {
        //        ClassId = 0,
        //        ClassName = "--ทั้งหมด--"
        //    });
        //    cboClassId.DisplayMember = "ClassName";
        //    cboClassId.ValueMember = "ClassId";
        //    cboClassId.DataSource = coll;

        //}
        //private void GvClassDis_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    gvClassDis.Columns[ConstColumns.ClassId].HeaderText = "รหัสกลุ่มลูกค้า";
        //    gvClassDis.Columns[ConstColumns.ClassName].HeaderText = "ชื่อกลุ่มลูกค้า";
        //    gvClassDis.Columns[ConstColumns.StartDate].HeaderText = "วันที่เริ่มต้น";
        //    gvClassDis.Columns[ConstColumns.EndDate].HeaderText = "วินที่สิ้นสุด";
        //    gvClassDis.Columns[ConstColumns.DiscountPer].HeaderText = "ส่วนลด %";
        //    gvClassDis.Columns[ConstColumns.Day].HeaderText = "จำนวนวัน";
        //    gvClassDis.Columns[ConstColumns.CreateAt].HeaderText = "วันเวลาสร้าง";
        //    gvClassDis.Columns[ConstColumns.CreateBy].HeaderText = "ผู้สร้าง";
        //    gvClassDis.Columns[ConstColumns.ModifiedAt].HeaderText = "วันเวลาแก้ไข";
        //    gvClassDis.Columns[ConstColumns.ModifiedBy].HeaderText = "ผู้แก้ไข";

        //    gvClassDis.Columns[ConstColumns.DiscountPer].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        //    gvClassDis.Columns[ConstColumns.DiscountPer].DefaultCellStyle.Format = "N2";
        //    gvClassDis.Columns[ConstColumns.Day].DefaultCellStyle.Format = "N0";

        //    gvClassDis.Columns[ConstColumns.StartDate].DefaultCellStyle.Format = "dd/MM/yyyy";
        //    gvClassDis.Columns[ConstColumns.EndDate].DefaultCellStyle.Format = "dd/MM/yyyy";
        //    gvClassDis.Columns[ConstColumns.CreateAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        //    gvClassDis.Columns[ConstColumns.ModifiedAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

        //    gvClassDis.Columns[ConstColumns.ClassId].Visible = false;
        //}
        //private void GvClassDis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        DataGridView senderGrid = (DataGridView)sender;
        //        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
        //        {
        //            Int32 classId = Convert.ToInt32(gvClassDis.Rows[e.RowIndex].Cells[ConstColumns.ClassId].Value);
        //            DateTime startDate = (DateTime)gvClassDis.Rows[e.RowIndex].Cells[ConstColumns.StartDate].Value;

        //            switch (senderGrid.Columns[e.ColumnIndex].Name)
        //            {
        //                case "EditClassDis":
        //                    var frm = new Form_CustomerClassDiscountAddEdit
        //                    {
        //                        classId = classId,
        //                        startDate = startDate
        //                    };
        //                    if (frm.ShowDialog() == DialogResult.OK)
        //                    {
        //                        LoadClassDiscount();
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
        //private void BtnSearchClassDis_Click(object sender, System.EventArgs e)
        //{
        //    LoadClassDiscount();
        //}
        //private void BtnAddClassDis_Click(object sender, System.EventArgs e)
        //{
        //    var frm = new Form_CustomerClassDiscountAddEdit();

        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        LoadClassDiscount();
        //    }
        //}
        //private void LoadClassDiscount()
        //{
        //    var coll = CustomerClassDiscountController.GetAllCustomerClassDiscount(dtpStartDateClassDis.Value, Convert.ToInt32(cboClassId.SelectedValue));
        //    gvClassDis.DataSource = coll;
        //}
        #endregion

        private void btnImportCustomerPrice_Click(object sender, EventArgs e)
        {
            try
            {
                ReadExcel();
                MessageBox.Show("Import Customer Price is success.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomerClassPrice();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void ReadExcel()
        {
            try
            {
                OpenFileDialog openDlg = new OpenFileDialog
                {
                    Filter = "Excel file (* .xlsx) | * .xlsx"
                };
                if (openDlg.ShowDialog() == DialogResult.OK)
                {
                    var filename = openDlg.FileName;
                    XSSFWorkbook hssfwb;
                    using (FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read))
                    {
                        hssfwb = new XSSFWorkbook(file);
                    }

                    ISheet sheet = hssfwb.GetSheet("product_class_price");

                    var classPrices = new List<CustomCustomerClassPrice>();
                    var productCode = new List<string>();
                    var productName = new List<string>();
                    var price1 = new List<double>();
                    var price2 = new List<double>();
                    var price3 = new List<double>();
                    var startDate = new List<string>();
                    var durations = new List<double>();
                    for (int row = 1; row <= sheet.LastRowNum; row++)
                    {
                        if (sheet.GetRow(row) != null) //null is when the row only contains empty cells
                        {
                            productCode.Add(sheet.GetRow(row).GetCell(0).StringCellValue);
                            productName.Add(sheet.GetRow(row).GetCell(1).StringCellValue);
                            price1.Add(sheet.GetRow(row).GetCell(2).NumericCellValue);
                            price2.Add(sheet.GetRow(row).GetCell(3).NumericCellValue);
                            price3.Add(sheet.GetRow(row).GetCell(4).NumericCellValue);
                            startDate.Add(sheet.GetRow(row).GetCell(5).StringCellValue);
                            durations.Add(sheet.GetRow(row).GetCell(6).NumericCellValue);
                            //MessageBox.Show(string.Format("Row {0} = {1}", row, sheet.GetRow(row).GetCell(0).StringCellValue));
                        }
                    }

                    for (int i = 0; i < productCode.Count; i++)
                    {
                        var class1 = new CustomCustomerClassPrice
                        {
                            ClassId = 1,
                            ProductCode = productCode[i],
                            Price = price1[i],
                            StartDate = DateTime.Parse(startDate[i]),
                            EndDate = DateTime.Parse(startDate[i]).AddDays(durations[i])
                        };
                        classPrices.Add(class1);
                        var class2 = new CustomCustomerClassPrice
                        {
                            ClassId = 2,
                            ProductCode = productCode[i],
                            Price = price2[i],
                            StartDate = DateTime.Parse(startDate[i]),
                            EndDate = DateTime.Parse(startDate[i]).AddDays(durations[i])
                        };
                        classPrices.Add(class2);
                        var class3 = new CustomCustomerClassPrice
                        {
                            ClassId = 3,
                            ProductCode = productCode[i],
                            Price = price3[i],
                            StartDate = DateTime.Parse(startDate[i]),
                            EndDate = DateTime.Parse(startDate[i]).AddDays(durations[i])
                        };
                        classPrices.Add(class3);
                    }
                    InvoiceController.ImportCustomerClassPrice(classPrices);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}