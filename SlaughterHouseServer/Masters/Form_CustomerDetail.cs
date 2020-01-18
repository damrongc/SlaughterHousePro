using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_CustomerDetail : Form
    {
        public int classId { get; set; }
        public string customerCode { get; set; }
        public string customerName { get; set; }
        public DateTime startDate { get; set; }
        public bool flagDelete { get; set; }

        public Form_CustomerDetail()
        {
            InitializeComponent();
            UserSettingsComponent();
        }
        private void UserSettingsComponent()
        {
            LoadMasterClass();

            txtDay.KeyDown += TxtDay_KeyDown;
            dtpStartDate.KeyDown += DtpStartDate_KeyDown;
            cboMasterClass.KeyDown += CboMasterClass_KeyDown;

            txtDay.TextChanged += TxtDay_TextChanged;

            txtDay.KeyPress += TxtDay_KeyPress;

            dtpStartDate.ValueChanged += DtpStartDate_ValueChanged;
            BtnSave.Click += BtnSave_Click;
            BtnDelete.Click += BtnDelete_Click;

            this.Load += Form_CustomerDetail_Load;
            this.Shown += Form_CustomerDetail_Shown;
        }
        private void TxtDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboMasterClass.Focus();
            }
        }
        private void DtpStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDay.Focus();
            }
        }
        private void CboMasterClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSave.Focus();
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
        private void TxtDay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //txtDay.Text = (Convert.ToInt32(txtDay.Text) == 0) ? "1" : txtDay.Text;

                if (int.TryParse(txtDay.Text, out int n))
                {
                    n = (n == 0) ? 1 : n;
                    dtpEndDate.Value = dtpStartDate.Value.AddDays(n - 1);
                }
                else
                {
                    txtDay.Text = "0";
                }
            }
            catch
            {

            }
        }
        private void DtpStartDate_ValueChanged(Object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtDay.Text, out int n))
                {
                    n = (n == 0) ? 1 : n;
                    dtpEndDate.Value = dtpStartDate.Value.AddDays(n - 1);
                }
                else
                {
                    txtDay.Text = "0";
                }
            }
            catch
            {

            }
        }

        private void LoadMasterClass()
        {
            cboMasterClass.DataSource = MasterClassController.GetAllMasterClassCombobox("N");
            cboMasterClass.ValueMember = "ClassId";
            cboMasterClass.DisplayMember = "ClassName";
        }
        private void Form_CustomerDetail_Shown(object sender, System.EventArgs e)
        {
            dtpStartDate.Focus();
        }
        private void Form_CustomerDetail_Load(object sender, System.EventArgs e)
        {
            try
            {
                txtCustomerCode.Text = this.customerCode;
                txtCustomerName.Text = this.customerName;
                if (this.classId != 0)
                {
                    var customerClass = CustomerClassController.GetClassByCustomer(this.classId, this.customerCode, this.startDate);
                    if (customerClass != null)
                    {
                        //### Form Load
                        cboMasterClass.SelectedValue = customerClass.MasterClass.ClassId;
                        txtDay.Text = customerClass.Day.ToString();
                        dtpStartDate.Value = customerClass.StartDate;
                        dtpEndDate.Value = customerClass.EndDate;

                        dtpStartDate.Enabled = false;
                        if (this.flagDelete == true)
                        {
                            BtnDelete.Visible = true;
                            BtnSave.Visible = false;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CheckBeforeSave()
        {
            try
            {
                txtDay.Text = (string.IsNullOrEmpty(txtDay.Text)) ? "0" : txtDay.Text;
                if (Convert.ToInt16(txtDay.Text) == 0)
                {
                    throw new Exception(ConstErrorMsg.DayIsZero);
                }
            }
            catch
            {
                throw;
            }
        }

        private void BtnDelete_Click(object sender, System.EventArgs e)
        {
            try
            {
                var customerClass = new CustomerClass
                {
                    Customer = new Customer
                    {
                        CustomerCode = this.customerCode
                    },
                    MasterClass = new MasterClass
                    {
                        ClassId = Convert.ToInt32(cboMasterClass.SelectedValue)
                    },
                    StartDate = dtpStartDate.Value,
                    ModifiedBy = "system",
                };
                CustomerClassController.Delete(customerClass);
                MessageBox.Show("ลบข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                CheckBeforeSave();
                if (this.classId == 0)
                {
                    var customerClass = new CustomerClass
                    {
                        Customer = new Customer
                        {
                            CustomerCode = this.customerCode
                        },
                        MasterClass = new MasterClass
                        {
                            ClassId = Convert.ToInt32(cboMasterClass.SelectedValue)
                        },
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpStartDate.Value.AddDays(Convert.ToInt16(txtDay.Text) - 1),
                        Day = Convert.ToInt16(txtDay.Text),
                        CreateBy = "system",
                    };
                    CustomerClassController.Insert(customerClass);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var customerClass = new CustomerClass
                    {
                        Customer = new Customer
                        {
                            CustomerCode = this.customerCode
                        },
                        MasterClass = new MasterClass
                        {
                            ClassId = Convert.ToInt32(cboMasterClass.SelectedValue)
                        },
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpStartDate.Value.AddDays(Convert.ToInt16(txtDay.Text) - 1),
                        Day = Convert.ToInt16(txtDay.Text),
                        ModifiedBy = "system",
                    };
                    CustomerClassController.Update(customerClass);
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
    }
}
