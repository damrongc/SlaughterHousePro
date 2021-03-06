﻿using SlaughterHouseLib;
using SlaughterHouseLib.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace SlaughterHouseServer
{
    public partial class Form_ProductPrice : Form
    {
        public Form_ProductPrice()
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

            LoadProduct();
            LoadOrder();
        }

        private void Gv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

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
                                LoadOrder();
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
            LoadOrder();
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            var frm = new Form_ProductPriceAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadOrder();
            }
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
        }

        private void LoadOrder()
        {
            //var farmCtrl = new FarmController();
            var coll = ProductPriceController.GetAllProductPrices(dtpStartDate.Value, cboProduct.SelectedValue.ToString());
            gv.DataSource = coll;

            gv.Columns[1].HeaderText = "รหัสสินค้า";
            gv.Columns[2].HeaderText = "ชื่อสินค้า";
            gv.Columns[3].HeaderText = "วันที่เริ่มต้น";
            gv.Columns[4].HeaderText = "วินที่สิ้นสุด";
            gv.Columns[5].HeaderText = "ราคาต่อหน่วย";
            gv.Columns[6].HeaderText = "จำนวนวัน";
            gv.Columns[7].HeaderText = "วันเวลาสร้าง";
            gv.Columns[8].HeaderText = "ผู้สร้าง";
            gv.Columns[7].Visible = false;

            gv.Columns[ConstColumns.CreateAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            gv.Columns[ConstColumns.ModifiedAt].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }


    }
}