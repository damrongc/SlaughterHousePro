using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_CustomerAddEdit : Form
    {
        public string customerCode { get; set; }
        private DataTable dtCusClass;
        public Form_CustomerAddEdit()
        {
            InitializeComponent();

            gv.CellContentClick += Gv_CellContentClick;
            gv.DataBindingComplete += Gv_DataBindingComplete;
            gv.ReadOnly = true;
            gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
            gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
            gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
            gv.EnableHeadersVisualStyles = false;

            txtCustomerCode.KeyDown += TxtCustomerCode_KeyDown;
            txtCustomerName.KeyDown += TxtCustomerName_KeyDown;
            txtShipTo.KeyDown += TxtShipTo_KeyDown;
            txtTaxId.KeyDown += TxtTaxId_KeyDown;
            txtContactNo.KeyDown += TxtContactNo_KeyDown;

            txtTaxId.KeyPress += TxtTaxId_KeyPress;
            txtContactNo.KeyPress += TxtContactNo;

            btnAddOrderItem.Click += BtnAddOrderItem_Click;

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
            try
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

                        Load_CustomerClass();
                    }
                }
                else
                {
                    groupBoxCustomerClass.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Form Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Load_CustomerClass()
        {
            dtCusClass = new DataTable("CUSTOMER_CLASS");
            dtCusClass = CustomerClassController.GetClassAllByCustomer(this.customerCode);
            gv.DataSource = dtCusClass;
        }

        private void TxtTaxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }
        private void TxtContactNo(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
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


                //if (this.classId == 0 || this.customerCode == null)
                //{
                //    var customerClass = new CustomerClass
                //    {
                //        MasterClass = new MasterClass
                //        {
                //            ClassId = Convert.ToInt32(comboxMasterClass.SelectedValue)
                //        },
                //        StartDate = dtpStartDate.Value,
                //        EndDate = dtpStartDate.Value.AddDays(Convert.ToInt16(txtDay.Text)),
                //        Day = Convert.ToInt16(txtDay.Text),
                //        CreateBy = "system",
                //    };
                //    CustomerClassController.Insert(customerClass);
                //    MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    var customerClass = new CustomerClass
                //    {
                //        MasterClass = new MasterClass
                //        {
                //            ClassId = Convert.ToInt32(comboxMasterClass.SelectedValue)
                //        },
                //        StartDate = dtpStartDate.Value,
                //        EndDate = dtpStartDate.Value.AddDays(Convert.ToInt16(txtDay.Text)),
                //        Day = Convert.ToInt16(txtDay.Text),
                //        ModifiedBy = "system",
                //    };
                //    CustomerClassController.Update(customerClass);
                //    MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

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


        #region CustomerClass
        private void BtnAddOrderItem_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_CustomerDetail();

            frm.customerCode = txtCustomerCode.Text;
            frm.customerName = txtCustomerName.Text;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Load_CustomerClass();
                gv.Refresh();

            }
        }

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //gv.Columns["seq"].HeaderText = "ลำดับ";
            gv.Columns[ConstColumns.CLASS_NAME].HeaderText = "ชื่อระดับคลาส";
            gv.Columns[ConstColumns.START_DATE].HeaderText = "วันที่เริ่มต้น";
            gv.Columns[ConstColumns.END_DATE].HeaderText = "วันที่สิ้นสุด";
            gv.Columns[ConstColumns.CREATE_AT].HeaderText = "วันเวลาสร้าง";
            gv.Columns[ConstColumns.CREATE_BY].HeaderText = "ผู้สร้าง";
            gv.Columns[ConstColumns.MODIFIED_AT].HeaderText = "วันเวลาแก้ไข";
            gv.Columns[ConstColumns.MODIFIED_BY].HeaderText = "ผู้แก้ไข";

            gv.Columns[ConstColumns.CLASS_ID].Visible = false;
            gv.Columns[ConstColumns.CUSTOMER_CODE].Visible = false;
            gv.Columns[ConstColumns.CUSTOMER_NAME].Visible = false;

            gv.Columns[ConstColumns.START_DATE].DefaultCellStyle.Format = "dd/MM/yyyy";
            gv.Columns[ConstColumns.END_DATE].DefaultCellStyle.Format = "dd/MM/yyyy";
            gv.Columns[ConstColumns.CREATE_AT].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            gv.Columns[ConstColumns.MODIFIED_AT].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }
        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    switch (senderGrid.Columns[e.ColumnIndex].Name)
                    {
                        case "Edit":
                            var frm = new Form_CustomerDetail();

                            frm.customerCode = txtCustomerCode.Text;
                            frm.customerName = txtCustomerName.Text;
                            frm.classId = Convert.ToInt32(dtCusClass.Rows[e.RowIndex][ConstColumns.CLASS_ID]);
                            frm.startDate = (DateTime)dtCusClass.Rows[e.RowIndex][ConstColumns.START_DATE];

                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                Load_CustomerClass();
                                gv.Refresh();
                            }
                            break;
                        case "Del":
                            //dtCusClass.Rows[e.RowIndex].Delete();
                            //dtCusClass.AcceptChanges();
                            //gv.Refresh();
                            var frmD = new Form_CustomerDetail();

                            frmD.customerCode = txtCustomerCode.Text;
                            frmD.customerName = txtCustomerName.Text;
                            frmD.classId = Convert.ToInt32(dtCusClass.Rows[e.RowIndex][ConstColumns.CLASS_ID]);
                            frmD.startDate = (DateTime)dtCusClass.Rows[e.RowIndex][ConstColumns.START_DATE];
                            frmD.flagDelete = true;
                            if (frmD.ShowDialog() == DialogResult.OK)
                            {
                                Load_CustomerClass();
                                gv.Refresh();
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
