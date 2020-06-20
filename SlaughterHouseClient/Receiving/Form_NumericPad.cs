using System;
using System.Windows.Forms;

namespace SlaughterHouseClient.Receiving
{


    public partial class Form_NumericPad : Form
    {
        public int ReturnValue { get; set; }
        public string DefaultValue { get; set; }

        private bool firstTime = true;
        public Form_NumericPad()
        {
            InitializeComponent();
            Load += Form_Load;
            btn0.Click += Btn_Click;
            btn1.Click += Btn_Click;
            btn2.Click += Btn_Click;
            btn3.Click += Btn_Click;
            btn4.Click += Btn_Click;
            btn5.Click += Btn_Click;
            btn6.Click += Btn_Click;
            btn7.Click += Btn_Click;
            btn8.Click += Btn_Click;
            btn9.Click += Btn_Click;
        }



        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            //if (txtNumeric.Text.Length >= 2)
            //    return;
            if (btn.Text == "0" && string.IsNullOrEmpty(txtNumeric.Text))
                return;
            else
            {
                if (firstTime)
                {
                    txtNumeric.Text = btn.Text;
                    firstTime = false;
                }
                else
                {
                    txtNumeric.Text = txtNumeric.Text + btn.Text;

                }
            }

        }

        private void Form_Load(object sender, EventArgs e)
        {
            txtNumeric.Text = DefaultValue;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNumeric.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumeric.Text))
            {
                var value = int.Parse(txtNumeric.Text);
                if (value > 0)
                {
                    ReturnValue = int.Parse(txtNumeric.Text);
                    DialogResult = DialogResult.OK;
                    Close();
                }

            }
            else
            {
                ReturnValue = 0;
                DialogResult = DialogResult.OK;
                Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ReturnValue = 0;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
