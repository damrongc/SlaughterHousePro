namespace SlaughterHouseServer
{
    partial class Form_InvoiceNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_InvoiceNew));
            this.panel2 = new System.Windows.Forms.Panel();
            this.gv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvDt = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewImageColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDt)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gv);
            this.panel2.Location = new System.Drawing.Point(4, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1092, 333);
            this.panel2.TabIndex = 43;
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
            this.Select,
            this.OrderNo});
            this.gv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv.Location = new System.Drawing.Point(0, 0);
            this.gv.Name = "gv";
            this.gv.RowHeadersWidth = 10;
            this.gv.Size = new System.Drawing.Size(1092, 333);
            this.gv.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 29);
            this.label2.TabIndex = 44;
            this.label2.Text = "เอกสารใบสั่งขาย";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnRefresh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 35);
            this.panel1.TabIndex = 45;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.BackColor = System.Drawing.Color.White;
            this.BtnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRefresh.FlatAppearance.BorderSize = 0;
            this.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefresh.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefresh.ForeColor = System.Drawing.Color.White;
            this.BtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefresh.Image")));
            this.BtnRefresh.Location = new System.Drawing.Point(1042, -2);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(54, 36);
            this.BtnRefresh.TabIndex = 44;
            this.BtnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRefresh.UseVisualStyleBackColor = false;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvDt);
            this.groupBox1.Location = new System.Drawing.Point(4, 380);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1092, 238);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียดใบสั่งขาย";
            // 
            // gvDt
            // 
            this.gvDt.AllowUserToAddRows = false;
            this.gvDt.AllowUserToDeleteRows = false;
            this.gvDt.AllowUserToResizeColumns = false;
            this.gvDt.AllowUserToResizeRows = false;
            this.gvDt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gvDt.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvDt.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gvDt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvDt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDt.Location = new System.Drawing.Point(3, 32);
            this.gvDt.Name = "gvDt";
            this.gvDt.RowHeadersWidth = 10;
            this.gvDt.Size = new System.Drawing.Size(1086, 203);
            this.gvDt.TabIndex = 44;
            // 
            // Select
            // 
            this.Select.HeaderText = "เลือก";
            this.Select.Image = ((System.Drawing.Image)(resources.GetObject("Select.Image")));
            this.Select.Name = "Select";
            this.Select.Width = 59;
            // 
            // OrderNo
            // 
            this.OrderNo.DataPropertyName = "OrderNo";
            this.OrderNo.HeaderText = "ใบสั่งขาย";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OrderNo.Width = 109;
            // 
            // Form_InvoiceNew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1101, 618);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_InvoiceNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_InvoiceNew";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gvDt;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.DataGridViewImageColumn Select;
        private System.Windows.Forms.DataGridViewLinkColumn OrderNo;
    }
}