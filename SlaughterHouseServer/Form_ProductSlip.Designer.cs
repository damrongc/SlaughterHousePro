namespace SlaughterHouseServer
{
    partial class Form_ProductSlip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ProductSlip));
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductSlip = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.dtpProductSlipDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "เลขที่ใบจัดสินค้า:";
            // 
            // txtProductSlip
            // 
            this.txtProductSlip.Enabled = false;
            this.txtProductSlip.Location = new System.Drawing.Point(182, 22);
            this.txtProductSlip.MaxLength = 10;
            this.txtProductSlip.Name = "txtProductSlip";
            this.txtProductSlip.Size = new System.Drawing.Size(215, 36);
            this.txtProductSlip.TabIndex = 1;
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSave.Location = new System.Drawing.Point(730, 398);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(215, 36);
            this.BtnSave.TabIndex = 7;
            this.BtnSave.Text = "บันทึกแล้วปริ้น";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // dtpProductSlipDate
            // 
            this.dtpProductSlipDate.CustomFormat = "dd/MM/yyyy";
            this.dtpProductSlipDate.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpProductSlipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpProductSlipDate.Location = new System.Drawing.Point(182, 64);
            this.dtpProductSlipDate.Name = "dtpProductSlipDate";
            this.dtpProductSlipDate.Size = new System.Drawing.Size(215, 36);
            this.dtpProductSlipDate.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(49, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 29);
            this.label11.TabIndex = 33;
            this.label11.Text = "วันที่ใบจัดสินค้า:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gv);
            this.panel2.Location = new System.Drawing.Point(12, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(933, 220);
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
            this.gv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv.Location = new System.Drawing.Point(0, 0);
            this.gv.Name = "gv";
            this.gv.RowHeadersWidth = 10;
            this.gv.Size = new System.Drawing.Size(933, 220);
            this.gv.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 29);
            this.label2.TabIndex = 44;
            this.label2.Text = "ใบจัดสินค้า";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 36);
            this.panel1.TabIndex = 45;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Enabled = false;
            this.chkActive.Location = new System.Drawing.Point(848, 24);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(79, 33);
            this.chkActive.TabIndex = 46;
            this.chkActive.Text = "ใช้งาน";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Tomato;
            this.BtnCancel.FlatAppearance.BorderSize = 0;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancel.Image")));
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancel.Location = new System.Drawing.Point(522, 398);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(202, 36);
            this.BtnCancel.TabIndex = 47;
            this.BtnCancel.Text = "ยกเลิกเอกสาร";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Enabled = false;
            this.txtOrderNo.Location = new System.Drawing.Point(604, 22);
            this.txtOrderNo.MaxLength = 10;
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(215, 36);
            this.txtOrderNo.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(472, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 29);
            this.label4.TabIndex = 48;
            this.label4.Text = "เลขที่ใบสั่งขาย:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboCustomer
            // 
            this.cboCustomer.Enabled = false;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(604, 64);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(310, 37);
            this.cboCustomer.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(543, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 29);
            this.label5.TabIndex = 50;
            this.label5.Text = "ลูกค้า:";
            // 
            // Form_ProductSlip
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(957, 457);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtpProductSlipDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.txtProductSlip);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ProductSlip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_ProductSlip";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductSlip;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.DateTimePicker dtpProductSlipDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label5;
    }
}