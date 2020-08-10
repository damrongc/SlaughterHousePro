using SlaughterHouseEF;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SlaughterHouseClient
{
    public partial class Form_Lot : Form
    {
        public string LotNoSelected { get; set; }
        public Form_Lot(string productCode)
        {
            InitializeComponent();
            //UserSettingsComponent();
            LoadData(productCode);
        }
        //private void UserSettingsComponent()
        //{
        //    gv.CellContentClick += Gv_CellContentClick;
        //    gv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        //    //gv.ColumnHeadersDefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE);
        //    gv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00A8E6");
        //    gv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //gv.DefaultCellStyle.Font = new Font(Globals.FONT_FAMILY, Globals.FONT_SIZE - 2);
        //    gv.EnableHeadersVisualStyles = false;
        //}
        //private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        DataGridView senderGrid = (DataGridView)sender;
        //        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
        //        {
        //            LotNoSelected = gv.Rows[e.RowIndex].Cells[1].Value.ToString();
        //            DialogResult = DialogResult.OK;
        //            Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void LoadData(string productCode)
        {
            using (var db = new SlaughterhouseEntities())
            {
                var lots = (from p in db.receive_item
                            where p.product_code == productCode && ((p.receive_qty - p.chill_qty) > 0)
                            select p.lot_no).Distinct().ToList();
                foreach (string lot_no in lots)
                {
                    var btn = new Button
                    {
                        Text = lot_no,
                        Width = 150,
                        Height = 50,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Kanit", 16),
                        BackColor = Color.WhiteSmoke,
                    };
                    btn.Click += Btn_Click;
                    flowLayoutPanel1.Controls.Add(btn);
                }
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            LotNoSelected = btn.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
