namespace SlaughterHouseServer
{
    partial class Form_Invoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Invoice));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gvDt = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gv = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Print = new System.Windows.Forms.DataGridViewImageColumn();
            this.INVOICE_NO = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnRefSo = new System.Windows.Forms.Button();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDt)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ข้อมูลใบแจ้งหนี้";
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
            this.panel1.Size = new System.Drawing.Size(1264, 681);
            this.panel1.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.gvDt);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(6, 360);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1252, 315);
            this.panel5.TabIndex = 12;
            // 
            // gvDt
            // 
            this.gvDt.AllowUserToAddRows = false;
            this.gvDt.AllowUserToDeleteRows = false;
            this.gvDt.AllowUserToResizeColumns = false;
            this.gvDt.AllowUserToResizeRows = false;
            this.gvDt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvDt.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvDt.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gvDt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvDt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDt.Location = new System.Drawing.Point(0, 0);
            this.gvDt.Name = "gvDt";
            this.gvDt.RowHeadersWidth = 10;
            this.gvDt.Size = new System.Drawing.Size(1252, 315);
            this.gvDt.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gv);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(6, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1252, 292);
            this.panel4.TabIndex = 11;
            // 
            // gv
            // 
            this.gv.AllowUserToAddRows = false;
            this.gv.AllowUserToDeleteRows = false;
            this.gv.AllowUserToResizeColumns = false;
            this.gv.AllowUserToResizeRows = false;
            this.gv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gv.BackgroundColor = System.Drawing.Color.Gray;
            this.gv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Print,
            this.INVOICE_NO});
            this.gv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv.Location = new System.Drawing.Point(0, 0);
            this.gv.Name = "gv";
            this.gv.RowHeadersWidth = 10;
            this.gv.Size = new System.Drawing.Size(1252, 292);
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
            // INVOICE_NO
            // 
            this.INVOICE_NO.DataPropertyName = "INVOICE_NO";
            this.INVOICE_NO.HeaderText = "ใบแจ้งหนี้";
            this.INVOICE_NO.Name = "INVOICE_NO";
            this.INVOICE_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.INVOICE_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.INVOICE_NO.Width = 110;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(6, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1252, 1);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.BtnRefSo);
            this.panel2.Controls.Add(this.cboCustomer);
            this.panel2.Controls.Add(this.dtpInvoiceDate);
            this.panel2.Controls.Add(this.BtnSearch);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1252, 61);
            this.panel2.TabIndex = 5;
            // 
            // BtnRefSo
            // 
            this.BtnRefSo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnRefSo.FlatAppearance.BorderSize = 0;
            this.BtnRefSo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefSo.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefSo.ForeColor = System.Drawing.Color.White;
            this.BtnRefSo.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefSo.Image")));
            this.BtnRefSo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefSo.Location = new System.Drawing.Point(1221, 15);
            this.BtnRefSo.Name = "BtnRefSo";
            this.BtnRefSo.Size = new System.Drawing.Size(129, 36);
            this.BtnRefSo.TabIndex = 8;
            this.BtnRefSo.Text = "ใบสั่งขาย";
            this.BtnRefSo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRefSo.UseVisualStyleBackColor = false;
            this.BtnRefSo.Visible = false;
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(398, 11);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(382, 37);
            this.cboCustomer.TabIndex = 7;
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy";
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(152, 11);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(177, 36);
            this.dtpInvoiceDate.TabIndex = 6;
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
            this.BtnSearch.Location = new System.Drawing.Point(786, 11);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(142, 36);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "แสดงข้อมูล";
            this.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearch.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(343, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "ลูกค้า:";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(934, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(142, 36);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Form_Invoice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1284, 701);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Kanit", 15.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Invoice";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form_Farm";
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDt)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Button BtnRefSo;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.DataGridView gvDt;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Print;
        private System.Windows.Forms.DataGridViewLinkColumn INVOICE_NO;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnExport;
    }
}