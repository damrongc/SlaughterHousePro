using nucs.JsonSettings;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseClient
{
    public partial class Form_Settings : Form
    {
        readonly SettingsBag MySettings = JsonSettings.Load<SettingsBag>("config.json");

        public Form_Settings()
        {
            InitializeComponent();
            Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSetting();
            }
            catch (Exception)
            {

                throw;
            }
        }

        void LoadSetting()
        {

            if (MySettings.Data.Count > 0)
            {

                cboComport.Text = MySettings["Comport"].ToString();
                cboBaudrate.Text = MySettings["Baudrate"].ToString();
                if (MySettings["StableTarget"] != null)
                    cboStableTarget.Text = MySettings["StableTarget"].ToString();
                if (MySettings["DisplayTime"] != null)
                    cboMsgDisplayTime.Text = MySettings["DisplayTime"].ToString();
                if (MySettings["Division"] != null)
                    cboDivision.Text = MySettings["Division"].ToString();
                if (MySettings["CaptureTime"] != null)
                    cboCaptureTime.Text = MySettings["CaptureTime"].ToString();
            }
        }

        void SaveSetting()
        {
            MySettings["Comport"] = cboComport.Text;
            MySettings["Baudrate"] = cboBaudrate.Text;
            MySettings["StableTarget"] = cboStableTarget.Text;
            MySettings["DisplayTime"] = cboMsgDisplayTime.Text;
            MySettings["Division"] = cboDivision.Text;
            MySettings["CaptureTime"] = cboCaptureTime.Text;
            MySettings.Save();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSetting();
                MessageBox.Show("Success", "บันทึกข้อมูล เรียบร้อยแล้ว", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
