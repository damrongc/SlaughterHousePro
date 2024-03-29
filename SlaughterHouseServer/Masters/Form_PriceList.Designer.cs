﻿namespace SlaughterHouseServer
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
            this.tabControlPrice = new System.Windows.Forms.TabControl();
            this.tabPageProduct = new System.Windows.Forms.TabPage();
            this.tabPageCustomerClass = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.gvCustomerClass = new System.Windows.Forms.DataGridView();
            this.EditCustomerClass = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel12 = new System.Windows.Forms.Panel();
            this.dtpStartDateCustomerClass = new System.Windows.Forms.DateTimePicker();
            this.BtnSearchCustomerClass = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnAddCustomerClass = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
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
            this.tabPageCustomerClassDis = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cboClassId = new System.Windows.Forms.ComboBox();
            this.dtpStartDateClassDis = new System.Windows.Forms.DateTimePicker();
            this.BtnSearchClassDis = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnAddClassDis = new System.Windows.Forms.Button();
            this.gvClassDis = new System.Windows.Forms.DataGridView();
            this.EditClassDis = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtProductFilter = new System.Windows.Forms.TextBox();
            this.btnImportCustomerPrice = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControlPrice.SuspendLayout();
            this.tabPageProduct.SuspendLayout();
            this.tabPageCustomerClass.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomerClass)).BeginInit();
            this.panel12.SuspendLayout();
            this.tabPageCustomer.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCv)).BeginInit();
            this.panel6.SuspendLayout();
            this.tabPageCustomerClassDis.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvClassDis)).BeginInit();
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
            this.BtnAdd.Location = new System.Drawing.Point(189, 14);
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
            this.panel1.Size = new System.Drawing.Size(1384, 698);
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
            this.gv.Size = new System.Drawing.Size(1372, 624);
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
            this.cboProduct.Location = new System.Drawing.Point(555, 14);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(214, 37);
            this.cboProduct.TabIndex = 7;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(324, 14);
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
            this.BtnSearch.Location = new System.Drawing.Point(775, 14);
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
            this.label2.Location = new System.Drawing.Point(490, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "สินค้า:";
            // 
            // tabControlPrice
            // 
            this.tabControlPrice.Controls.Add(this.tabPageProduct);
            this.tabControlPrice.Controls.Add(this.tabPageCustomerClass);
            this.tabControlPrice.Controls.Add(this.tabPageCustomer);
            this.tabControlPrice.Controls.Add(this.tabPageCustomerClassDis);
            this.tabControlPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPrice.Location = new System.Drawing.Point(0, 0);
            this.tabControlPrice.Name = "tabControlPrice";
            this.tabControlPrice.SelectedIndex = 0;
            this.tabControlPrice.Size = new System.Drawing.Size(1400, 750);
            this.tabControlPrice.TabIndex = 4;
            // 
            // tabPageProduct
            // 
            this.tabPageProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageProduct.Controls.Add(this.panel1);
            this.tabPageProduct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPageProduct.Location = new System.Drawing.Point(4, 40);
            this.tabPageProduct.Name = "tabPageProduct";
            this.tabPageProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProduct.Size = new System.Drawing.Size(1392, 706);
            this.tabPageProduct.TabIndex = 1;
            this.tabPageProduct.Text = " ราคาระดับสินค้า ";
            this.tabPageProduct.UseVisualStyleBackColor = true;
            // 
            // tabPageCustomerClass
            // 
            this.tabPageCustomerClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageCustomerClass.Controls.Add(this.panel10);
            this.tabPageCustomerClass.Location = new System.Drawing.Point(4, 40);
            this.tabPageCustomerClass.Name = "tabPageCustomerClass";
            this.tabPageCustomerClass.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomerClass.Size = new System.Drawing.Size(1392, 706);
            this.tabPageCustomerClass.TabIndex = 3;
            this.tabPageCustomerClass.Text = " ราคาระดับกลุ่มลูกค้า";
            this.tabPageCustomerClass.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.gvCustomerClass);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(6);
            this.panel10.Size = new System.Drawing.Size(1384, 698);
            this.panel10.TabIndex = 6;
            // 
            // gvCustomerClass
            // 
            this.gvCustomerClass.AllowUserToAddRows = false;
            this.gvCustomerClass.AllowUserToDeleteRows = false;
            this.gvCustomerClass.AllowUserToResizeColumns = false;
            this.gvCustomerClass.AllowUserToResizeRows = false;
            this.gvCustomerClass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gvCustomerClass.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvCustomerClass.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gvCustomerClass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvCustomerClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCustomerClass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditCustomerClass});
            this.gvCustomerClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCustomerClass.Location = new System.Drawing.Point(6, 68);
            this.gvCustomerClass.Name = "gvCustomerClass";
            this.gvCustomerClass.RowHeadersWidth = 10;
            this.gvCustomerClass.Size = new System.Drawing.Size(1372, 624);
            this.gvCustomerClass.TabIndex = 9;
            // 
            // EditCustomerClass
            // 
            this.EditCustomerClass.HeaderText = "แก้ไข";
            this.EditCustomerClass.Image = ((System.Drawing.Image)(resources.GetObject("EditCustomerClass.Image")));
            this.EditCustomerClass.Name = "EditCustomerClass";
            this.EditCustomerClass.Width = 58;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnImportCustomerPrice);
            this.panel12.Controls.Add(this.txtProductFilter);
            this.panel12.Controls.Add(this.dtpStartDateCustomerClass);
            this.panel12.Controls.Add(this.BtnSearchCustomerClass);
            this.panel12.Controls.Add(this.label7);
            this.panel12.Controls.Add(this.label8);
            this.panel12.Controls.Add(this.BtnAddCustomerClass);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(6, 7);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1372, 61);
            this.panel12.TabIndex = 7;
            // 
            // dtpStartDateCustomerClass
            // 
            this.dtpStartDateCustomerClass.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDateCustomerClass.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDateCustomerClass.Location = new System.Drawing.Point(364, 14);
            this.dtpStartDateCustomerClass.Name = "dtpStartDateCustomerClass";
            this.dtpStartDateCustomerClass.Size = new System.Drawing.Size(160, 36);
            this.dtpStartDateCustomerClass.TabIndex = 6;
            // 
            // BtnSearchCustomerClass
            // 
            this.BtnSearchCustomerClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnSearchCustomerClass.FlatAppearance.BorderSize = 0;
            this.BtnSearchCustomerClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchCustomerClass.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchCustomerClass.ForeColor = System.Drawing.Color.White;
            this.BtnSearchCustomerClass.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearchCustomerClass.Image")));
            this.BtnSearchCustomerClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearchCustomerClass.Location = new System.Drawing.Point(903, 16);
            this.BtnSearchCustomerClass.Name = "BtnSearchCustomerClass";
            this.BtnSearchCustomerClass.Size = new System.Drawing.Size(142, 36);
            this.BtnSearchCustomerClass.TabIndex = 4;
            this.BtnSearchCustomerClass.Text = "แสดงข้อมูล";
            this.BtnSearchCustomerClass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearchCustomerClass.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(530, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 29);
            this.label7.TabIndex = 5;
            this.label7.Text = "รหัสหรือชื่อสินค้า:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(212, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "ข้อมูลราคาระดับกลุ่มลูกค้า";
            // 
            // BtnAddCustomerClass
            // 
            this.BtnAddCustomerClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnAddCustomerClass.FlatAppearance.BorderSize = 0;
            this.BtnAddCustomerClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddCustomerClass.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddCustomerClass.ForeColor = System.Drawing.Color.White;
            this.BtnAddCustomerClass.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddCustomerClass.Image")));
            this.BtnAddCustomerClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAddCustomerClass.Location = new System.Drawing.Point(229, 14);
            this.BtnAddCustomerClass.Name = "BtnAddCustomerClass";
            this.BtnAddCustomerClass.Size = new System.Drawing.Size(129, 36);
            this.BtnAddCustomerClass.TabIndex = 2;
            this.BtnAddCustomerClass.Text = "เพิ่มข้อมูล";
            this.BtnAddCustomerClass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAddCustomerClass.UseVisualStyleBackColor = false;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.LightGray;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(6, 6);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1372, 1);
            this.panel11.TabIndex = 6;
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
            // tabPageCustomerClassDis
            // 
            this.tabPageCustomerClassDis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageCustomerClassDis.Controls.Add(this.panel7);
            this.tabPageCustomerClassDis.Location = new System.Drawing.Point(4, 40);
            this.tabPageCustomerClassDis.Name = "tabPageCustomerClassDis";
            this.tabPageCustomerClassDis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomerClassDis.Size = new System.Drawing.Size(1392, 706);
            this.tabPageCustomerClassDis.TabIndex = 2;
            this.tabPageCustomerClassDis.Text = "ส่วนลดกลุ่มลูกค้า";
            this.tabPageCustomerClassDis.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.gvClassDis);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(6);
            this.panel7.Size = new System.Drawing.Size(1384, 698);
            this.panel7.TabIndex = 5;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.LightGray;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(6, 67);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1372, 1);
            this.panel8.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.cboClassId);
            this.panel9.Controls.Add(this.dtpStartDateClassDis);
            this.panel9.Controls.Add(this.BtnSearchClassDis);
            this.panel9.Controls.Add(this.label5);
            this.panel9.Controls.Add(this.label6);
            this.panel9.Controls.Add(this.BtnAddClassDis);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(6, 6);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1372, 61);
            this.panel9.TabIndex = 5;
            // 
            // cboClassId
            // 
            this.cboClassId.FormattingEnabled = true;
            this.cboClassId.Location = new System.Drawing.Point(601, 14);
            this.cboClassId.Name = "cboClassId";
            this.cboClassId.Size = new System.Drawing.Size(214, 37);
            this.cboClassId.TabIndex = 7;
            // 
            // dtpStartDateClassDis
            // 
            this.dtpStartDateClassDis.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDateClassDis.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDateClassDis.Location = new System.Drawing.Point(327, 14);
            this.dtpStartDateClassDis.Name = "dtpStartDateClassDis";
            this.dtpStartDateClassDis.Size = new System.Drawing.Size(160, 36);
            this.dtpStartDateClassDis.TabIndex = 6;
            // 
            // BtnSearchClassDis
            // 
            this.BtnSearchClassDis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnSearchClassDis.FlatAppearance.BorderSize = 0;
            this.BtnSearchClassDis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchClassDis.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchClassDis.ForeColor = System.Drawing.Color.White;
            this.BtnSearchClassDis.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearchClassDis.Image")));
            this.BtnSearchClassDis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearchClassDis.Location = new System.Drawing.Point(821, 14);
            this.BtnSearchClassDis.Name = "BtnSearchClassDis";
            this.BtnSearchClassDis.Size = new System.Drawing.Size(142, 36);
            this.BtnSearchClassDis.TabIndex = 4;
            this.BtnSearchClassDis.Text = "แสดงข้อมูล";
            this.BtnSearchClassDis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearchClassDis.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(499, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 29);
            this.label5.TabIndex = 5;
            this.label5.Text = "ระดับลูกค้้า:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 29);
            this.label6.TabIndex = 0;
            this.label6.Text = "ข้อมูลราคาระดับลูกค้า";
            // 
            // BtnAddClassDis
            // 
            this.BtnAddClassDis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnAddClassDis.FlatAppearance.BorderSize = 0;
            this.BtnAddClassDis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddClassDis.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddClassDis.ForeColor = System.Drawing.Color.White;
            this.BtnAddClassDis.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddClassDis.Image")));
            this.BtnAddClassDis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAddClassDis.Location = new System.Drawing.Point(192, 14);
            this.BtnAddClassDis.Name = "BtnAddClassDis";
            this.BtnAddClassDis.Size = new System.Drawing.Size(129, 36);
            this.BtnAddClassDis.TabIndex = 2;
            this.BtnAddClassDis.Text = "เพิ่มข้อมูล";
            this.BtnAddClassDis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAddClassDis.UseVisualStyleBackColor = false;
            // 
            // gvClassDis
            // 
            this.gvClassDis.AllowUserToAddRows = false;
            this.gvClassDis.AllowUserToDeleteRows = false;
            this.gvClassDis.AllowUserToResizeColumns = false;
            this.gvClassDis.AllowUserToResizeRows = false;
            this.gvClassDis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gvClassDis.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvClassDis.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gvClassDis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvClassDis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvClassDis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditClassDis});
            this.gvClassDis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvClassDis.Location = new System.Drawing.Point(6, 6);
            this.gvClassDis.Name = "gvClassDis";
            this.gvClassDis.RowHeadersWidth = 10;
            this.gvClassDis.Size = new System.Drawing.Size(1372, 686);
            this.gvClassDis.TabIndex = 8;
            // 
            // EditClassDis
            // 
            this.EditClassDis.HeaderText = "แก้ไข";
            this.EditClassDis.Image = ((System.Drawing.Image)(resources.GetObject("EditClassDis.Image")));
            this.EditClassDis.Name = "EditClassDis";
            this.EditClassDis.Width = 58;
            // 
            // txtProductFilter
            // 
            this.txtProductFilter.Location = new System.Drawing.Point(682, 15);
            this.txtProductFilter.MaxLength = 10;
            this.txtProductFilter.Name = "txtProductFilter";
            this.txtProductFilter.Size = new System.Drawing.Size(215, 36);
            this.txtProductFilter.TabIndex = 10;
            // 
            // btnImportCustomerPrice
            // 
            this.btnImportCustomerPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.btnImportCustomerPrice.FlatAppearance.BorderSize = 0;
            this.btnImportCustomerPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCustomerPrice.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCustomerPrice.ForeColor = System.Drawing.Color.White;
            this.btnImportCustomerPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportCustomerPrice.Location = new System.Drawing.Point(1051, 15);
            this.btnImportCustomerPrice.Name = "btnImportCustomerPrice";
            this.btnImportCustomerPrice.Size = new System.Drawing.Size(142, 36);
            this.btnImportCustomerPrice.TabIndex = 11;
            this.btnImportCustomerPrice.Text = "Import Excel";
            this.btnImportCustomerPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportCustomerPrice.UseVisualStyleBackColor = false;
            this.btnImportCustomerPrice.Click += new System.EventHandler(this.btnImportCustomerPrice_Click);
            // 
            // Form_PriceList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.tabControlPrice);
            this.Font = new System.Drawing.Font("Kanit", 15.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_PriceList";
            this.Text = "Form_Farm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControlPrice.ResumeLayout(false);
            this.tabPageProduct.ResumeLayout(false);
            this.tabPageCustomerClass.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomerClass)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.tabPageCustomer.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCv)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabPageCustomerClassDis.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvClassDis)).EndInit();
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
        private System.Windows.Forms.TabControl tabControlPrice;
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
        private System.Windows.Forms.TabPage tabPageCustomerClassDis;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView gvClassDis;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ComboBox cboClassId;
        private System.Windows.Forms.DateTimePicker dtpStartDateClassDis;
        private System.Windows.Forms.Button BtnSearchClassDis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnAddClassDis;
        private System.Windows.Forms.DataGridViewImageColumn EditClassDis;
        private System.Windows.Forms.TabPage tabPageCustomerClass;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.DataGridView gvCustomerClass;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.DateTimePicker dtpStartDateCustomerClass;
        private System.Windows.Forms.Button BtnSearchCustomerClass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnAddCustomerClass;
        private System.Windows.Forms.DataGridViewImageColumn EditCustomerClass;
        private System.Windows.Forms.TextBox txtProductFilter;
        private System.Windows.Forms.Button btnImportCustomerPrice;
    }
}