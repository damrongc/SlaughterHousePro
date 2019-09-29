namespace SlaughterHouseServer
{
    partial class Form_ProductAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ProductAddEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnSaveAndNew = new System.Windows.Forms.Button();
            this.comboxProductGroup = new System.Windows.Forms.ComboBox();
            this.labelProductGroup = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboxUnitQty = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboxUnitWgh = new System.Windows.Forms.ComboBox();
            this.txtMinWgh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaxWgh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStdYield = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbWghSale = new System.Windows.Forms.RadioButton();
            this.rdbQtySale = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbWghIssue = new System.Windows.Forms.RadioButton();
            this.rdbQtyIssue = new System.Windows.Forms.RadioButton();
            this.txtPackingSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสสินค้า";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(198, 22);
            this.txtProductCode.MaxLength = 10;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(215, 36);
            this.txtProductCode.TabIndex = 1;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(198, 64);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(529, 36);
            this.txtProductName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "ชื่อสินค้า";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(198, 413);
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
            this.BtnSave.Location = new System.Drawing.Point(512, 469);
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
            this.BtnSaveAndNew.Location = new System.Drawing.Point(198, 469);
            this.BtnSaveAndNew.Name = "BtnSaveAndNew";
            this.BtnSaveAndNew.Size = new System.Drawing.Size(202, 36);
            this.BtnSaveAndNew.TabIndex = 25;
            this.BtnSaveAndNew.Text = "บันทึกแล้วสร้างใหม่";
            this.BtnSaveAndNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSaveAndNew.UseVisualStyleBackColor = false;
            this.BtnSaveAndNew.Click += new System.EventHandler(this.BtnSaveAndNew_Click);
            // 
            // comboxProductGroup
            // 
            this.comboxProductGroup.FormattingEnabled = true;
            this.comboxProductGroup.Location = new System.Drawing.Point(198, 105);
            this.comboxProductGroup.Name = "comboxProductGroup";
            this.comboxProductGroup.Size = new System.Drawing.Size(215, 37);
            this.comboxProductGroup.TabIndex = 26;
            // 
            // labelProductGroup
            // 
            this.labelProductGroup.AutoSize = true;
            this.labelProductGroup.Location = new System.Drawing.Point(93, 109);
            this.labelProductGroup.Name = "labelProductGroup";
            this.labelProductGroup.Size = new System.Drawing.Size(90, 29);
            this.labelProductGroup.TabIndex = 27;
            this.labelProductGroup.Text = "กลุ่มสินค้า";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 29);
            this.label3.TabIndex = 29;
            this.label3.Text = "หน่วยนับปริมาณ";
            // 
            // comboxUnitQty
            // 
            this.comboxUnitQty.FormattingEnabled = true;
            this.comboxUnitQty.Location = new System.Drawing.Point(198, 148);
            this.comboxUnitQty.Name = "comboxUnitQty";
            this.comboxUnitQty.Size = new System.Drawing.Size(215, 37);
            this.comboxUnitQty.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 29);
            this.label4.TabIndex = 31;
            this.label4.Text = "หน่วยนับน้ำหนัก";
            // 
            // comboxUnitWgh
            // 
            this.comboxUnitWgh.FormattingEnabled = true;
            this.comboxUnitWgh.Location = new System.Drawing.Point(198, 192);
            this.comboxUnitWgh.Name = "comboxUnitWgh";
            this.comboxUnitWgh.Size = new System.Drawing.Size(215, 37);
            this.comboxUnitWgh.TabIndex = 30;
            // 
            // txtMinWgh
            // 
            this.txtMinWgh.Location = new System.Drawing.Point(198, 235);
            this.txtMinWgh.MaxLength = 10;
            this.txtMinWgh.Name = "txtMinWgh";
            this.txtMinWgh.Size = new System.Drawing.Size(215, 36);
            this.txtMinWgh.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 29);
            this.label5.TabIndex = 32;
            this.label5.Text = "น้ำหนักต่าสุด";
            // 
            // txtMaxWgh
            // 
            this.txtMaxWgh.Location = new System.Drawing.Point(198, 277);
            this.txtMaxWgh.MaxLength = 10;
            this.txtMaxWgh.Name = "txtMaxWgh";
            this.txtMaxWgh.Size = new System.Drawing.Size(215, 36);
            this.txtMaxWgh.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 29);
            this.label6.TabIndex = 34;
            this.label6.Text = "น้ำหนักสูงสุด";
            // 
            // txtStdYield
            // 
            this.txtStdYield.Location = new System.Drawing.Point(198, 319);
            this.txtStdYield.MaxLength = 10;
            this.txtStdYield.Name = "txtStdYield";
            this.txtStdYield.Size = new System.Drawing.Size(215, 36);
            this.txtStdYield.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(96, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 29);
            this.label7.TabIndex = 36;
            this.label7.Text = "std yield";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbWghSale);
            this.groupBox1.Controls.Add(this.rdbQtySale);
            this.groupBox1.Location = new System.Drawing.Point(512, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 78);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "หน่วยคำนวณขาย";
            // 
            // rdbWghSale
            // 
            this.rdbWghSale.AutoSize = true;
            this.rdbWghSale.Location = new System.Drawing.Point(112, 35);
            this.rdbWghSale.Name = "rdbWghSale";
            this.rdbWghSale.Size = new System.Drawing.Size(84, 33);
            this.rdbWghSale.TabIndex = 1;
            this.rdbWghSale.TabStop = true;
            this.rdbWghSale.Text = "น้ำหนัก";
            this.rdbWghSale.UseVisualStyleBackColor = true;
            // 
            // rdbQtySale
            // 
            this.rdbQtySale.AutoSize = true;
            this.rdbQtySale.Location = new System.Drawing.Point(12, 35);
            this.rdbQtySale.Name = "rdbQtySale";
            this.rdbQtySale.Size = new System.Drawing.Size(90, 33);
            this.rdbQtySale.TabIndex = 0;
            this.rdbQtySale.TabStop = true;
            this.rdbQtySale.Text = "ปริมาณ";
            this.rdbQtySale.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbWghIssue);
            this.groupBox2.Controls.Add(this.rdbQtyIssue);
            this.groupBox2.Location = new System.Drawing.Point(512, 275);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 78);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "หน่วยคำนวณเบิก";
            // 
            // rdbWghIssue
            // 
            this.rdbWghIssue.AutoSize = true;
            this.rdbWghIssue.Location = new System.Drawing.Point(112, 35);
            this.rdbWghIssue.Name = "rdbWghIssue";
            this.rdbWghIssue.Size = new System.Drawing.Size(84, 33);
            this.rdbWghIssue.TabIndex = 1;
            this.rdbWghIssue.TabStop = true;
            this.rdbWghIssue.Text = "น้ำหนัก";
            this.rdbWghIssue.UseVisualStyleBackColor = true;
            // 
            // rdbQtyIssue
            // 
            this.rdbQtyIssue.AutoSize = true;
            this.rdbQtyIssue.Location = new System.Drawing.Point(12, 35);
            this.rdbQtyIssue.Name = "rdbQtyIssue";
            this.rdbQtyIssue.Size = new System.Drawing.Size(90, 33);
            this.rdbQtyIssue.TabIndex = 0;
            this.rdbQtyIssue.TabStop = true;
            this.rdbQtyIssue.Text = "ปริมาณ";
            this.rdbQtyIssue.UseVisualStyleBackColor = true;
            // 
            // txtPackingSize
            // 
            this.txtPackingSize.Location = new System.Drawing.Point(198, 361);
            this.txtPackingSize.MaxLength = 10;
            this.txtPackingSize.Name = "txtPackingSize";
            this.txtPackingSize.Size = new System.Drawing.Size(215, 36);
            this.txtPackingSize.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 29);
            this.label8.TabIndex = 40;
            this.label8.Text = "packing size";
            // 
            // Form_ProductAddEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(802, 525);
            this.Controls.Add(this.txtPackingSize);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtStdYield);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMaxWgh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMinWgh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboxUnitWgh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboxUnitQty);
            this.Controls.Add(this.labelProductGroup);
            this.Controls.Add(this.comboxProductGroup);
            this.Controls.Add(this.BtnSaveAndNew);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ProductAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_ProductAddEdit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnSaveAndNew;
        private System.Windows.Forms.ComboBox comboxProductGroup;
        private System.Windows.Forms.Label labelProductGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboxUnitQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboxUnitWgh;
        private System.Windows.Forms.TextBox txtMinWgh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaxWgh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStdYield;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbWghSale;
        private System.Windows.Forms.RadioButton rdbQtySale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbWghIssue;
        private System.Windows.Forms.RadioButton rdbQtyIssue;
        private System.Windows.Forms.TextBox txtPackingSize;
        private System.Windows.Forms.Label label8;
    }
}