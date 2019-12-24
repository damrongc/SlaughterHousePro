﻿namespace SlaughterHouseServer
{
    partial class Form_CustomerAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CustomerAddEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnSaveAndNew = new System.Windows.Forms.Button();
            this.txtShipTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTaxId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboxMasterClass = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสลูกค้า";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(200, 22);
            this.txtCustomerCode.MaxLength = 10;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(215, 36);
            this.txtCustomerCode.TabIndex = 1;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(200, 64);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(529, 36);
            this.txtCustomerName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "ชื่อลูกค้า";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(200, 106);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(529, 116);
            this.txtAddress.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "ที่อยู่";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(200, 569);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(79, 33);
            this.chkActive.TabIndex = 6;
            this.chkActive.Text = "ใช้งาน";
            this.chkActive.UseVisualStyleBackColor = true;
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
            this.BtnSave.Location = new System.Drawing.Point(514, 622);
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
            this.BtnSaveAndNew.Location = new System.Drawing.Point(200, 622);
            this.BtnSaveAndNew.Name = "BtnSaveAndNew";
            this.BtnSaveAndNew.Size = new System.Drawing.Size(202, 36);
            this.BtnSaveAndNew.TabIndex = 25;
            this.BtnSaveAndNew.Text = "บันทึกแล้วสร้างใหม่";
            this.BtnSaveAndNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSaveAndNew.UseVisualStyleBackColor = false;
            this.BtnSaveAndNew.Click += new System.EventHandler(this.BtnSaveAndNew_Click);
            // 
            // txtShipTo
            // 
            this.txtShipTo.Location = new System.Drawing.Point(200, 228);
            this.txtShipTo.MaxLength = 80;
            this.txtShipTo.Multiline = true;
            this.txtShipTo.Name = "txtShipTo";
            this.txtShipTo.Size = new System.Drawing.Size(529, 116);
            this.txtShipTo.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 29);
            this.label4.TabIndex = 26;
            this.label4.Text = "สถานที่ส่งสินค้า";
            // 
            // txtTaxId
            // 
            this.txtTaxId.Location = new System.Drawing.Point(200, 351);
            this.txtTaxId.MaxLength = 13;
            this.txtTaxId.Name = "txtTaxId";
            this.txtTaxId.Size = new System.Drawing.Size(215, 36);
            this.txtTaxId.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 29);
            this.label5.TabIndex = 28;
            this.label5.Text = "เลขประจำตัวผู้เสียภาษี";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(200, 395);
            this.txtContactNo.MaxLength = 10;
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(215, 36);
            this.txtContactNo.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 398);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 29);
            this.label6.TabIndex = 30;
            this.label6.Text = "เบอร์ติดต่อ";
            // 
            // comboxMasterClass
            // 
            this.comboxMasterClass.FormattingEnabled = true;
            this.comboxMasterClass.Location = new System.Drawing.Point(115, 29);
            this.comboxMasterClass.Name = "comboxMasterClass";
            this.comboxMasterClass.Size = new System.Drawing.Size(215, 37);
            this.comboxMasterClass.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 29);
            this.label7.TabIndex = 53;
            this.label7.Text = "กลุ่มมลูกค้า";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDay);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboxMasterClass);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(200, 437);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 129);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "กลุ่มลูกค้า";
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(398, 73);
            this.txtDay.MaxLength = 10;
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(110, 36);
            this.txtDay.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(306, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 29);
            this.label8.TabIndex = 57;
            this.label8.Text = "จำนวนวัน:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(115, 73);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(161, 36);
            this.dtpStartDate.TabIndex = 56;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 29);
            this.label11.TabIndex = 55;
            this.label11.Text = "วันที่เริ่มต้น:";
            // 
            // Form_CustomerAddEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(762, 688);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTaxId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtShipTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnSaveAndNew);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomerCode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_CustomerAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_CustomerAddEdit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnSaveAndNew;
        private System.Windows.Forms.TextBox txtShipTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTaxId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboxMasterClass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label label8;
    }
}