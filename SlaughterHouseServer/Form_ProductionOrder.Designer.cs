namespace SlaughterHouseServer
{
    partial class Form_ProductionOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ProductionOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gv2 = new System.Windows.Forms.DataGridView();
            this.seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po_wgh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unload_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unload_wgh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gv = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Print = new System.Windows.Forms.DataGridViewImageColumn();
            this.colPoNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpPoDate = new System.Windows.Forms.DateTimePicker();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ข้อมูลใบสั่งผลิต";
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdd.Image")));
            this.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAdd.Location = new System.Drawing.Point(146, 11);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(129, 36);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = "เพิ่มข้อมูล";
            this.BtnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdd.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(1380, 730);
            this.panel1.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.gv2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(6, 426);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1368, 298);
            this.panel5.TabIndex = 8;
            // 
            // gv2
            // 
            this.gv2.AllowUserToAddRows = false;
            this.gv2.AllowUserToDeleteRows = false;
            this.gv2.AllowUserToResizeColumns = false;
            this.gv2.AllowUserToResizeRows = false;
            this.gv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gv2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gv2.BackgroundColor = System.Drawing.Color.LightGray;
            this.gv2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seq,
            this.product_name,
            this.po_qty,
            this.po_wgh,
            this.unload_qty,
            this.unload_wgh});
            this.gv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv2.Location = new System.Drawing.Point(0, 0);
            this.gv2.Name = "gv2";
            this.gv2.RowHeadersWidth = 10;
            this.gv2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gv2.Size = new System.Drawing.Size(1368, 298);
            this.gv2.TabIndex = 10;
            // 
            // seq
            // 
            this.seq.DataPropertyName = "seq";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.seq.DefaultCellStyle = dataGridViewCellStyle6;
            this.seq.HeaderText = "ลำดับ";
            this.seq.Name = "seq";
            this.seq.Width = 81;
            // 
            // product_name
            // 
            this.product_name.DataPropertyName = "product_name";
            this.product_name.HeaderText = "สินค้า";
            this.product_name.Name = "product_name";
            this.product_name.Width = 81;
            // 
            // po_qty
            // 
            this.po_qty.DataPropertyName = "po_qty";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.po_qty.DefaultCellStyle = dataGridViewCellStyle7;
            this.po_qty.HeaderText = "จำนวนเบิก";
            this.po_qty.Name = "po_qty";
            this.po_qty.Width = 118;
            // 
            // po_wgh
            // 
            this.po_wgh.DataPropertyName = "po_wgh";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.po_wgh.DefaultCellStyle = dataGridViewCellStyle8;
            this.po_wgh.HeaderText = "น้ำหนักเบิก";
            this.po_wgh.Name = "po_wgh";
            this.po_wgh.Width = 121;
            // 
            // unload_qty
            // 
            this.unload_qty.DataPropertyName = "unload_qty";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.unload_qty.DefaultCellStyle = dataGridViewCellStyle9;
            this.unload_qty.HeaderText = "จำนวนจ่าย";
            this.unload_qty.Name = "unload_qty";
            this.unload_qty.Width = 118;
            // 
            // unload_wgh
            // 
            this.unload_wgh.DataPropertyName = "unload_wgh";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.unload_wgh.DefaultCellStyle = dataGridViewCellStyle10;
            this.unload_wgh.HeaderText = "น้ำหนักจ่าย (กก.)";
            this.unload_wgh.Name = "unload_wgh";
            this.unload_wgh.Width = 167;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gv);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(6, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1368, 358);
            this.panel4.TabIndex = 7;
            // 
            // gv
            // 
            this.gv.AllowUserToAddRows = false;
            this.gv.AllowUserToDeleteRows = false;
            this.gv.AllowUserToResizeColumns = false;
            this.gv.AllowUserToResizeRows = false;
            this.gv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gv.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Print,
            this.colPoNo});
            this.gv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv.Location = new System.Drawing.Point(0, 0);
            this.gv.Name = "gv";
            this.gv.RowHeadersWidth = 10;
            this.gv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gv.Size = new System.Drawing.Size(1368, 358);
            this.gv.TabIndex = 9;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "แก้ไข";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.Width = 58;
            // 
            // Print
            // 
            this.Print.HeaderText = "พิมพ์";
            this.Print.Image = ((System.Drawing.Image)(resources.GetObject("Print.Image")));
            this.Print.Name = "Print";
            this.Print.Width = 58;
            // 
            // colPoNo
            // 
            this.colPoNo.DataPropertyName = "PoNo";
            this.colPoNo.HeaderText = "ใบสั่งผลิต";
            this.colPoNo.Name = "colPoNo";
            this.colPoNo.Width = 95;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(6, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1368, 1);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpPoDate);
            this.panel2.Controls.Add(this.BtnSearch);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BtnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1368, 61);
            this.panel2.TabIndex = 5;
            // 
            // dtpPoDate
            // 
            this.dtpPoDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPoDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPoDate.Location = new System.Drawing.Point(281, 11);
            this.dtpPoDate.Name = "dtpPoDate";
            this.dtpPoDate.Size = new System.Drawing.Size(177, 36);
            this.dtpPoDate.TabIndex = 6;
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnSearch.FlatAppearance.BorderSize = 0;
            this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.ForeColor = System.Drawing.Color.White;
            this.BtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearch.Image")));
            this.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearch.Location = new System.Drawing.Point(477, 12);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(142, 36);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "แสดงข้อมูล";
            this.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearch.UseVisualStyleBackColor = false;
            // 
            // Form_ProductionOrder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Kanit", 15.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_ProductionOrder";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form_Farm";
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpPoDate;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Print;
        private System.Windows.Forms.DataGridViewLinkColumn colPoNo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView gv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn po_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn po_wgh;
        private System.Windows.Forms.DataGridViewTextBoxColumn unload_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn unload_wgh;
    }
}