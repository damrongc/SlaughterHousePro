using SlaughterHouseLib.Models;
using System;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_CustomerClassDiscountAddEdit : Form
    {
        public Int32 classId { get; set; }
        public DateTime startDate { get; set; }

        public Form_CustomerClassDiscountAddEdit()
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
            txtDiscountPer.KeyPress += TxtDiscountPer_KeyPress;
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
        private void TxtDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiscountPer.Focus();
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

        private void TxtDiscountPer_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtDiscountPer.Text)> 100)
                {
                    MessageBox.Show("ส่วนลดต้องไม่เกิน 100%", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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

                this.classId = 0;
                txtDiscountPer.Text = "0";
                txtDay.Text = "0";
                dtpStartDate.Value = DateTime.Now;
                LoadCustomerClass();
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
            if (this.classId > 0)
            {
                comboxCustomerClass.Enabled = false;
                dtpStartDate.Enabled = false;
            }
            CustomerClassDiscount customerClassDiscount = CustomerClassDiscountController.GetCustomerClassDiscount(this.classId, this.startDate);
            if (customerClassDiscount != null)
            {
                this.classId = customerClassDiscount.CustomerClass.ClassId;
                comboxCustomerClass.SelectedValue = customerClassDiscount.CustomerClass.ClassId;
                txtDiscountPer.Text = customerClassDiscount.DiscountPer.ToString();
                txtDay.Text = customerClassDiscount.Day.ToString();

                dtpStartDate.Value = customerClassDiscount.StartDate;
                dtpStartDate.Enabled = false;
                BtnSaveAndNew.Visible = false;
            }
        }

        private void LoadCustomerClass()
        {
            comboxCustomerClass.DataSource = CustomerClassController.GetAllCustomerClass();
            comboxCustomerClass.ValueMember = "ClassId";
            comboxCustomerClass.DisplayMember = "ClassName";
        }

        private void SaveProductPrice()
        {
            try
            {
                var customerClassDiscount = new CustomerClassDiscount
                {
                    CustomerClass = new CustomerClass
                    {
                        ClassId = Convert.ToInt32(comboxCustomerClass.SelectedValue)
                    },
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpStartDate.Value.AddDays(Convert.ToInt16(txtDay.Text)),
                    Day = Convert.ToInt16(txtDay.Text),

                    DiscountPer  = Convert.ToDecimal(txtDiscountPer.Text),
                    CreateBy = "system",
                    ModifiedBy = "system"
                };
                if (comboxCustomerClass.Enabled == true && dtpStartDate.Enabled == true)
                {
                    CustomerClassDiscountController.Insert(customerClassDiscount);
                }
                else
                {
                    CustomerClassDiscountController.Update(customerClassDiscount);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
