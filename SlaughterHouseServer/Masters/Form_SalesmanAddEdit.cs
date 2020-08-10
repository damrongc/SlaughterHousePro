using SlaughterHouseLib.Models;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_SalesmanAddEdit : Form
    {
        public int id;

        public Form_SalesmanAddEdit()
        {
            InitializeComponent();

            txtCode.KeyDown += TxtUnitCode_KeyDown;
            txtName.KeyDown += TxtUnitName_KeyDown;
            Load += Form_Load;
            Shown += Form_Shown;
        }

        private void Form_Shown(object sender, System.EventArgs e)
        {
            txtCode.Focus();
            if (id > 0)
            {
                BtnSaveAndNew.Visible = false;
            }
        }

        private void Form_Load(object sender, System.EventArgs e)
        {

            var salesman = SalesmanController.GetSalesman(id);
            if (salesman != null)
            {
                txtCode.Text = salesman.SalesmanCode.ToString();
                txtCode.Enabled = false;
                txtName.Text = salesman.SalesmanName;
                chkActive.Checked = salesman.Active;
            }
        }

        private void TxtUnitName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSaveAndNew.Focus();
            }
        }

        private void TxtUnitCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
            }
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                ValiddateData();
                if (id == 0)
                {
                    AddNew();
                    //var salesman = new Salesman
                    //{
                    //    SalesmanName = txtName.Text.Trim(),
                    //    Active = chkActive.Checked,
                    //    CreateBy = "system",
                    //};
                    //SalesmanController.Insert(salesman);
                    //MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var salesman = new Salesman
                    {
                        SalesmanCode = id,
                        SalesmanName = txtName.Text.Trim(),
                        Active = chkActive.Checked,
                        ModifiedBy = "system",
                    };
                    SalesmanController.Update(salesman);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ValiddateData()
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    throw new System.Exception("กรุณาระบุ ชื่อพนักงานขาย");
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private void AddNew()
        {
            try
            {
                var salesman = new Salesman
                {
                    SalesmanName = txtName.Text.Trim(),
                    Active = chkActive.Checked,
                    CreateBy = "system",
                };
                SalesmanController.Insert(salesman);
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void BtnSaveAndNew_Click(object sender, System.EventArgs e)
        {
            try
            {
                ValiddateData();
                AddNew();
                txtCode.Text = "";
                txtCode.Focus();
                txtName.Text = "";
                chkActive.Checked = true;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
