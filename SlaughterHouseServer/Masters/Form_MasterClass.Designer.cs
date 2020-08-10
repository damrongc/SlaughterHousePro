namespace SlaughterHouseServer
{
    partial class Form_MasterClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MasterClass));
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gv = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtFilter = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gvCustomer = new System.Windows.Forms.DataGridView();
            this.col_customer_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colClassId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClassName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCreateAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifiedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifiedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefaultFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ข้อมูลกลุ่มสินค้า";
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
            this.BtnAdd.Location = new System.Drawing.Point(151, 12);
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
            this.panel1.Controls.Add(this.gvCustomer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.gv);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(1400, 750);
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
            this.Edit,
            this.colClassId,
            this.colClassName,
            this.colActive,
            this.colCreateAt,
            this.colCreateBy,
            this.colModifiedAt,
            this.colModifiedBy,
            this.colDefaultFlag});
            this.gv.Dock = System.Windows.Forms.DockStyle.Top;
            this.gv.Location = new System.Drawing.Point(6, 65);
            this.gv.Name = "gv";
            this.gv.RowHeadersWidth = 10;
            this.gv.Size = new System.Drawing.Size(1388, 386);
            this.gv.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(6, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1388, 1);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TxtFilter);
            this.panel2.Controls.Add(this.BtnSearch);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BtnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1388, 58);
            this.panel2.TabIndex = 5;
            // 
            // TxtFilter
            // 
            this.TxtFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFilter.Location = new System.Drawing.Point(286, 12);
            this.TxtFilter.Name = "TxtFilter";
            this.TxtFilter.Size = new System.Drawing.Size(215, 36);
            this.TxtFilter.TabIndex = 3;
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
            this.BtnSearch.Location = new System.Drawing.Point(507, 12);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(129, 36);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "ค้นข้อมูล";
            this.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearch.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "ข้อมูลลูกค้า";
            // 
            // gvCustomer
            // 
            this.gvCustomer.AllowUserToAddRows = false;
            this.gvCustomer.AllowUserToDeleteRows = false;
            this.gvCustomer.AllowUserToResizeColumns = false;
            this.gvCustomer.AllowUserToResizeRows = false;
            this.gvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gvCustomer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvCustomer.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_customer_code,
            this.col_customer_name});
            this.gvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCustomer.Location = new System.Drawing.Point(6, 480);
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.RowHeadersWidth = 10;
            this.gvCustomer.Size = new System.Drawing.Size(1388, 264);
            this.gvCustomer.TabIndex = 10;
            // 
            // col_customer_code
            // 
            this.col_customer_code.DataPropertyName = "CustomerCode";
            this.col_customer_code.HeaderText = "รหัสลูกค้า";
            this.col_customer_code.Name = "col_customer_code";
            this.col_customer_code.Width = 114;
            // 
            // col_customer_name
            // 
            this.col_customer_name.DataPropertyName = "CustomerName";
            this.col_customer_name.HeaderText = "ชื่อลูกค้า";
            this.col_customer_name.Name = "col_customer_name";
            this.col_customer_name.Width = 103;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "แก้ไข";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.Width = 58;
            // 
            // colClassId
            // 
            this.colClassId.DataPropertyName = "ClassId";
            this.colClassId.HeaderText = "รหัสระดับลุกค้า";
            this.colClassId.Name = "colClassId";
            this.colClassId.Width = 154;
            // 
            // colClassName
            // 
            this.colClassName.DataPropertyName = "ClassName";
            this.colClassName.HeaderText = "ชื่อระดับลุกค้า";
            this.colClassName.Name = "colClassName";
            this.colClassName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colClassName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colClassName.Width = 143;
            // 
            // colActive
            // 
            this.colActive.DataPropertyName = "Active";
            this.colActive.HeaderText = "ใช้งาน";
            this.colActive.Name = "colActive";
            this.colActive.Width = 66;
            // 
            // colCreateAt
            // 
            this.colCreateAt.DataPropertyName = "CreateAt";
            this.colCreateAt.HeaderText = "วันเวลาสร้าง";
            this.colCreateAt.Name = "colCreateAt";
            this.colCreateAt.Width = 133;
            // 
            // colCreateBy
            // 
            this.colCreateBy.DataPropertyName = "CreateBy";
            this.colCreateBy.HeaderText = "ผู้สร้าง";
            this.colCreateBy.Name = "colCreateBy";
            this.colCreateBy.Width = 91;
            // 
            // colModifiedAt
            // 
            this.colModifiedAt.DataPropertyName = "ModifiedAt";
            this.colModifiedAt.HeaderText = "วันเวลาแก้ไข";
            this.colModifiedAt.Name = "colModifiedAt";
            this.colModifiedAt.Width = 131;
            // 
            // colModifiedBy
            // 
            this.colModifiedBy.DataPropertyName = "ModifiedBy";
            this.colModifiedBy.HeaderText = "ผู้แก้ไข";
            this.colModifiedBy.Name = "colModifiedBy";
            this.colModifiedBy.Width = 89;
            // 
            // colDefaultFlag
            // 
            this.colDefaultFlag.DataPropertyName = "DefaultFlag";
            this.colDefaultFlag.HeaderText = "DefaultFlag";
            this.colDefaultFlag.Name = "colDefaultFlag";
            this.colDefaultFlag.Width = 132;
            // 
            // Form_MasterClass
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Kanit", 15.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_MasterClass";
            this.Text = "Form_Farm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtFilter;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gvCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_customer_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_customer_name;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassId;
        private System.Windows.Forms.DataGridViewLinkColumn colClassName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefaultFlag;
    }
}