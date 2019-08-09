namespace SlaughterHouseServer
{
    partial class Form_OrderAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_OrderAddEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnSaveAndNew = new System.Windows.Forms.Button();
            this.dtpRequestDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddOrderItem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gv = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Del = new System.Windows.Forms.DataGridViewImageColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "เลขที่ใบสั่งขาย:";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Location = new System.Drawing.Point(182, 22);
            this.txtOrderNo.MaxLength = 10;
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(215, 36);
            this.txtOrderNo.TabIndex = 1;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(182, 150);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(529, 133);
            this.txtComment.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "ความคิดเห็น:";
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
            this.BtnSave.Location = new System.Drawing.Point(730, 611);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(215, 36);
            this.BtnSave.TabIndex = 7;
            this.BtnSave.Text = "บันทึกแล้วปิด";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnSaveAndNew
            // 
            this.BtnSaveAndNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(93)))));
            this.BtnSaveAndNew.FlatAppearance.BorderSize = 0;
            this.BtnSaveAndNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveAndNew.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveAndNew.ForeColor = System.Drawing.Color.White;
            this.BtnSaveAndNew.Image = ((System.Drawing.Image)(resources.GetObject("BtnSaveAndNew.Image")));
            this.BtnSaveAndNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveAndNew.Location = new System.Drawing.Point(521, 611);
            this.BtnSaveAndNew.Name = "BtnSaveAndNew";
            this.BtnSaveAndNew.Size = new System.Drawing.Size(202, 36);
            this.BtnSaveAndNew.TabIndex = 25;
            this.BtnSaveAndNew.Text = "บันทึกแล้วสร้างใหม่";
            this.BtnSaveAndNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSaveAndNew.UseVisualStyleBackColor = false;
            this.BtnSaveAndNew.Click += new System.EventHandler(this.BtnSaveAndNew_Click);
            // 
            // dtpRequestDate
            // 
            this.dtpRequestDate.CustomFormat = "dd/MM/yyyy";
            this.dtpRequestDate.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequestDate.Location = new System.Drawing.Point(182, 64);
            this.dtpRequestDate.Name = "dtpRequestDate";
            this.dtpRequestDate.Size = new System.Drawing.Size(215, 36);
            this.dtpRequestDate.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 29);
            this.label11.TabIndex = 33;
            this.label11.Text = "วันที่ต้องการสินค้า:";
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(182, 106);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(310, 37);
            this.cboCustomer.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 29);
            this.label4.TabIndex = 35;
            this.label4.Text = "ลูกค้า:";
            // 
            // btnAddOrderItem
            // 
            this.btnAddOrderItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(93)))));
            this.btnAddOrderItem.FlatAppearance.BorderSize = 0;
            this.btnAddOrderItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrderItem.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrderItem.ForeColor = System.Drawing.Color.White;
            this.btnAddOrderItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOrderItem.Image")));
            this.btnAddOrderItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddOrderItem.Location = new System.Drawing.Point(846, 0);
            this.btnAddOrderItem.Name = "btnAddOrderItem";
            this.btnAddOrderItem.Size = new System.Drawing.Size(87, 36);
            this.btnAddOrderItem.TabIndex = 39;
            this.btnAddOrderItem.Text = "เพิ่ม";
            this.btnAddOrderItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddOrderItem.UseVisualStyleBackColor = false; 
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gv);
            this.panel2.Location = new System.Drawing.Point(12, 366);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(933, 211);
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
            this.Edit,
            this.Del});
            this.gv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv.Location = new System.Drawing.Point(0, 0);
            this.gv.Name = "gv";
            this.gv.RowHeadersWidth = 10;
            this.gv.Size = new System.Drawing.Size(933, 211);
            this.gv.TabIndex = 43;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "แก้ไข";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.Width = 58;
            // 
            // Del
            // 
            this.Del.HeaderText = "ลบ";
            this.Del.Image = ((System.Drawing.Image)(resources.GetObject("Del.Image")));
            this.Del.Name = "Del";
            this.Del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Del.Width = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 29);
            this.label2.TabIndex = 44;
            this.label2.Text = "รายละเอียดใบสั่งขาย";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAddOrderItem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 329);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 36);
            this.panel1.TabIndex = 45;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(182, 289);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(79, 33);
            this.chkActive.TabIndex = 46;
            this.chkActive.Text = "ใช้งาน";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // Form_OrderAddEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(957, 661);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpRequestDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BtnSaveAndNew);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_OrderAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_OrderAddEdit";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnSaveAndNew;
        private System.Windows.Forms.DateTimePicker dtpRequestDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddOrderItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Del;
        private System.Windows.Forms.CheckBox chkActive;
    }
}