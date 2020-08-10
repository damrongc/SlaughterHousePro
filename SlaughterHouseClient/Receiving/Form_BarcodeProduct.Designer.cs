namespace SlaughterHouseClient.Receiving
{
    partial class Form_BarcodeProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BarcodeProduct));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ddlProduct = new System.Windows.Forms.ComboBox();
            this.gv = new System.Windows.Forms.DataGridView();
            this.btnBarcode = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_product_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_wgh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 44);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kanit", 16F);
            this.label5.Location = new System.Drawing.Point(72, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 33);
            this.label5.TabIndex = 92;
            this.label5.Text = "สินค้า";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(928, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 44);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ddlProduct
            // 
            this.ddlProduct.Font = new System.Drawing.Font("Kanit", 14F);
            this.ddlProduct.FormattingEnabled = true;
            this.ddlProduct.Location = new System.Drawing.Point(143, 49);
            this.ddlProduct.Name = "ddlProduct";
            this.ddlProduct.Size = new System.Drawing.Size(300, 37);
            this.ddlProduct.TabIndex = 91;
            this.ddlProduct.SelectedIndexChanged += new System.EventHandler(this.ddlProduct_SelectedIndexChanged);
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
            this.btnBarcode,
            this.col_product_code,
            this.col_product_name,
            this.col_lot_no,
            this.col_qty,
            this.col_wgh,
            this.btnDelete});
            this.gv.Location = new System.Drawing.Point(0, 92);
            this.gv.MultiSelect = false;
            this.gv.Name = "gv";
            this.gv.RowHeadersWidth = 10;
            this.gv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv.Size = new System.Drawing.Size(1024, 676);
            this.gv.TabIndex = 9;
            // 
            // btnBarcode
            // 
            this.btnBarcode.DataPropertyName = "barcode_no";
            this.btnBarcode.Frozen = true;
            this.btnBarcode.HeaderText = "รหัส";
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Width = 44;
            // 
            // col_product_code
            // 
            this.col_product_code.DataPropertyName = "product_code";
            this.col_product_code.Frozen = true;
            this.col_product_code.HeaderText = "รหัสสินค้า";
            this.col_product_code.Name = "col_product_code";
            // 
            // col_product_name
            // 
            this.col_product_name.DataPropertyName = "product_name";
            this.col_product_name.Frozen = true;
            this.col_product_name.HeaderText = "ชื่อสินค้า";
            this.col_product_name.Name = "col_product_name";
            this.col_product_name.Width = 90;
            // 
            // col_lot_no
            // 
            this.col_lot_no.DataPropertyName = "lot_no";
            this.col_lot_no.Frozen = true;
            this.col_lot_no.HeaderText = "เลขที่ล็อต";
            this.col_lot_no.Name = "col_lot_no";
            this.col_lot_no.Width = 98;
            // 
            // col_qty
            // 
            this.col_qty.DataPropertyName = "quantity";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_qty.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_qty.Frozen = true;
            this.col_qty.HeaderText = "จำนวน";
            this.col_qty.Name = "col_qty";
            this.col_qty.Width = 79;
            // 
            // col_wgh
            // 
            this.col_wgh.DataPropertyName = "weight";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_wgh.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_wgh.Frozen = true;
            this.col_wgh.HeaderText = "น้ำหนัก";
            this.col_wgh.Name = "col_wgh";
            this.col_wgh.Width = 82;
            // 
            // btnDelete
            // 
            this.btnDelete.DataPropertyName = "barcode_no";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.DefaultCellStyle = dataGridViewCellStyle9;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Frozen = true;
            this.btnDelete.HeaderText = "";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Text = "ลบบาร์โค็ด";
            this.btnDelete.UseColumnTextForButtonValue = true;
            this.btnDelete.Width = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Kanit", 20.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(928, 44);
            this.label1.TabIndex = 17;
            this.label1.Text = "ข้อมูลบาร์โค้ด";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_BarcodeProduct
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gv);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ddlProduct);
            this.Font = new System.Drawing.Font("Kanit", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_BarcodeProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Receive";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox ddlProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewButtonColumn btnBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_product_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_wgh;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
        private System.Windows.Forms.Label label1;
    }
}