namespace SlaughterHouseServer
{
    partial class Form_PriceList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PriceList));
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gv = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartDateCustomer = new System.Windows.Forms.TabControl();
            this.tabPageCustomer = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gvCv = new System.Windows.Forms.DataGridView();
            this.EditCv = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cboProductCv = new System.Windows.Forms.ComboBox();
            this.dtpStartDateCv = new System.Windows.Forms.DateTimePicker();
            this.BtnSearchCv = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnAddCv = new System.Windows.Forms.Button();
            this.tabPageProduct = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.panel2.SuspendLayout();
            this.dtpStartDateCustomer.SuspendLayout();
            this.tabPageCustomer.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCv)).BeginInit();
            this.panel6.SuspendLayout();
            this.tabPageProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ข้อมูลราคาระดับสินค้า";
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
            this.BtnAdd.Location = new System.Drawing.Point(192, 14);
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
            this.panel1.Controls.Add(this.gv);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(1384, 716);
            this.panel1.TabIndex = 3;
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
            this.Edit});
            this.gv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv.Location = new System.Drawing.Point(6, 68);
            this.gv.Name = "gv";
            this.gv.RowHeadersWidth = 10;
            this.gv.Size = new System.Drawing.Size(1372, 642);
            this.gv.TabIndex = 8;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "แก้ไข";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.Width = 58;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(6, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1372, 1);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboProduct);
            this.panel2.Controls.Add(this.dtpStartDate);
            this.panel2.Controls.Add(this.BtnSearch);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BtnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1372, 61);
            this.panel2.TabIndex = 5;
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(558, 14);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(214, 37);
            this.cboProduct.TabIndex = 7;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(327, 14);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(160, 36);
            this.dtpStartDate.TabIndex = 6;
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
            this.BtnSearch.Location = new System.Drawing.Point(778, 14);
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
            this.label2.Location = new System.Drawing.Point(493, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "สินค้า:";
            // 
            // dtpStartDateCustomer
            // 
            this.dtpStartDateCustomer.Controls.Add(this.tabPageCustomer);
            this.dtpStartDateCustomer.Controls.Add(this.tabPageProduct);
            this.dtpStartDateCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStartDateCustomer.Location = new System.Drawing.Point(0, 0);
            this.dtpStartDateCustomer.Name = "dtpStartDateCustomer";
            this.dtpStartDateCustomer.SelectedIndex = 0;
            this.dtpStartDateCustomer.Size = new System.Drawing.Size(1400, 750);
            this.dtpStartDateCustomer.TabIndex = 4;
            // 
            // tabPageCustomer
            // 
            this.tabPageCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageCustomer.Controls.Add(this.panel4);
            this.tabPageCustomer.Location = new System.Drawing.Point(4, 40);
            this.tabPageCustomer.Name = "tabPageCustomer";
            this.tabPageCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomer.Size = new System.Drawing.Size(1392, 706);
            this.tabPageCustomer.TabIndex = 0;
            this.tabPageCustomer.Text = " ราคาระดับลูกค้า ";
            this.tabPageCustomer.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.gvCv);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(6);
            this.panel4.Size = new System.Drawing.Size(1384, 698);
            this.panel4.TabIndex = 4;
            // 
            // gvCv
            // 
            this.gvCv.AllowUserToAddRows = false;
            this.gvCv.AllowUserToDeleteRows = false;
            this.gvCv.AllowUserToResizeColumns = false;
            this.gvCv.AllowUserToResizeRows = false;
            this.gvCv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gvCv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvCv.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gvCv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvCv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditCv});
            this.gvCv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCv.Location = new System.Drawing.Point(6, 68);
            this.gvCv.Name = "gvCv";
            this.gvCv.RowHeadersWidth = 10;
            this.gvCv.Size = new System.Drawing.Size(1372, 624);
            this.gvCv.TabIndex = 8;
            // 
            // EditCv
            // 
            this.EditCv.HeaderText = "แก้ไข";
            this.EditCv.Image = ((System.Drawing.Image)(resources.GetObject("EditCv.Image")));
            this.EditCv.Name = "EditCv";
            this.EditCv.Width = 58;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(6, 67);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1372, 1);
            this.panel5.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cboProductCv);
            this.panel6.Controls.Add(this.dtpStartDateCv);
            this.panel6.Controls.Add(this.BtnSearchCv);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.BtnAddCv);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(6, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1372, 61);
            this.panel6.TabIndex = 5;
            // 
            // cboProductCv
            // 
            this.cboProductCv.FormattingEnabled = true;
            this.cboProductCv.Location = new System.Drawing.Point(558, 14);
            this.cboProductCv.Name = "cboProductCv";
            this.cboProductCv.Size = new System.Drawing.Size(214, 37);
            this.cboProductCv.TabIndex = 7;
            // 
            // dtpStartDateCv
            // 
            this.dtpStartDateCv.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDateCv.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDateCv.Location = new System.Drawing.Point(327, 14);
            this.dtpStartDateCv.Name = "dtpStartDateCv";
            this.dtpStartDateCv.Size = new System.Drawing.Size(160, 36);
            this.dtpStartDateCv.TabIndex = 6;
            // 
            // BtnSearchCv
            // 
            this.BtnSearchCv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnSearchCv.FlatAppearance.BorderSize = 0;
            this.BtnSearchCv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchCv.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchCv.ForeColor = System.Drawing.Color.White;
            this.BtnSearchCv.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearchCv.Image")));
            this.BtnSearchCv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearchCv.Location = new System.Drawing.Point(778, 14);
            this.BtnSearchCv.Name = "BtnSearchCv";
            this.BtnSearchCv.Size = new System.Drawing.Size(142, 36);
            this.BtnSearchCv.TabIndex = 4;
            this.BtnSearchCv.Text = "แสดงข้อมูล";
            this.BtnSearchCv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearchCv.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(493, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "สินค้า:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "ข้อมูลราคาระดับลูกค้า";
            // 
            // BtnAddCv
            // 
            this.BtnAddCv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnAddCv.FlatAppearance.BorderSize = 0;
            this.BtnAddCv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddCv.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddCv.ForeColor = System.Drawing.Color.White;
            this.BtnAddCv.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddCv.Image")));
            this.BtnAddCv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAddCv.Location = new System.Drawing.Point(192, 14);
            this.BtnAddCv.Name = "BtnAddCv";
            this.BtnAddCv.Size = new System.Drawing.Size(129, 36);
            this.BtnAddCv.TabIndex = 2;
            this.BtnAddCv.Text = "เพิ่มข้อมูล";
            this.BtnAddCv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAddCv.UseVisualStyleBackColor = false;
            // 
            // tabPageProduct
            // 
            this.tabPageProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageProduct.Controls.Add(this.panel1);
            this.tabPageProduct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPageProduct.Location = new System.Drawing.Point(4, 22);
            this.tabPageProduct.Name = "tabPageProduct";
            this.tabPageProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProduct.Size = new System.Drawing.Size(1392, 724);
            this.tabPageProduct.TabIndex = 1;
            this.tabPageProduct.Text = " ราคาระดับสินค้า ";
            this.tabPageProduct.UseVisualStyleBackColor = true;
            // 
            // Form_PriceList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.dtpStartDateCustomer);
            this.Font = new System.Drawing.Font("Kanit", 15.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_PriceList";
            this.Text = "Form_Farm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.dtpStartDateCustomer.ResumeLayout(false);
            this.tabPageCustomer.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCv)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabPageProduct.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl dtpStartDateCustomer;
        private System.Windows.Forms.TabPage tabPageCustomer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView gvCv;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cboProductCv;
        private System.Windows.Forms.DateTimePicker dtpStartDateCv;
        private System.Windows.Forms.Button BtnSearchCv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnAddCv;
        private System.Windows.Forms.TabPage tabPageProduct;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.DataGridViewImageColumn EditCv;
    }
}