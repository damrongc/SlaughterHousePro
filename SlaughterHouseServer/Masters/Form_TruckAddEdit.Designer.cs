namespace SlaughterHouseServer
{
    partial class Form_TruckAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TruckAddEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTruckNo = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.BtnSaveAndNew = new System.Windows.Forms.Button();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
<<<<<<< HEAD
            this.label2 = new System.Windows.Forms.Label();
            this.cboTruckType = new System.Windows.Forms.ComboBox();
=======
            this.txtTruckId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboxTruckType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
>>>>>>> 8e7570345231c099c0226de5161f05ab481aac21
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
<<<<<<< HEAD
            this.label1.Location = new System.Drawing.Point(84, 25);
=======
            this.label1.Location = new System.Drawing.Point(83, 66);
>>>>>>> 8e7570345231c099c0226de5161f05ab481aac21
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ทะเบียนรถ";
            // 
            // txtTruckNo
            // 
            this.txtTruckNo.Location = new System.Drawing.Point(182, 63);
            this.txtTruckNo.MaxLength = 10;
            this.txtTruckNo.Name = "txtTruckNo";
            this.txtTruckNo.Size = new System.Drawing.Size(215, 36);
            this.txtTruckNo.TabIndex = 1;
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
<<<<<<< HEAD
            this.BtnSave.Location = new System.Drawing.Point(364, 211);
=======
            this.BtnSave.Location = new System.Drawing.Point(314, 252);
>>>>>>> 8e7570345231c099c0226de5161f05ab481aac21
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(215, 36);
            this.BtnSave.TabIndex = 7;
            this.BtnSave.Text = "บันทึกแล้วปิด";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
<<<<<<< HEAD
            this.chkActive.Location = new System.Drawing.Point(182, 155);
=======
            this.chkActive.Location = new System.Drawing.Point(182, 197);
>>>>>>> 8e7570345231c099c0226de5161f05ab481aac21
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(79, 33);
            this.chkActive.TabIndex = 46;
            this.chkActive.Text = "ใช้งาน";
            this.chkActive.UseVisualStyleBackColor = true;
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
<<<<<<< HEAD
            this.BtnSaveAndNew.Location = new System.Drawing.Point(155, 211);
=======
            this.BtnSaveAndNew.Location = new System.Drawing.Point(105, 252);
>>>>>>> 8e7570345231c099c0226de5161f05ab481aac21
            this.BtnSaveAndNew.Name = "BtnSaveAndNew";
            this.BtnSaveAndNew.Size = new System.Drawing.Size(202, 36);
            this.BtnSaveAndNew.TabIndex = 25;
            this.BtnSaveAndNew.Text = "บันทึกแล้วสร้างใหม่";
            this.BtnSaveAndNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSaveAndNew.UseVisualStyleBackColor = false;
            this.BtnSaveAndNew.Click += new System.EventHandler(this.BtnSaveAndNew_Click);
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(182, 105);
            this.txtDriver.MaxLength = 75;
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(347, 36);
            this.txtDriver.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
<<<<<<< HEAD
            this.label3.Location = new System.Drawing.Point(73, 70);
=======
            this.label3.Location = new System.Drawing.Point(72, 105);
>>>>>>> 8e7570345231c099c0226de5161f05ab481aac21
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 29);
            this.label3.TabIndex = 48;
            this.label3.Text = "ชื่อคนขับรถ";
            // 
<<<<<<< HEAD
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 29);
            this.label2.TabIndex = 50;
            this.label2.Text = "ประเภทรถ";
            // 
            // cboTruckType
            // 
            this.cboTruckType.FormattingEnabled = true;
            this.cboTruckType.Location = new System.Drawing.Point(182, 112);
            this.cboTruckType.Name = "cboTruckType";
            this.cboTruckType.Size = new System.Drawing.Size(347, 37);
            this.cboTruckType.TabIndex = 52;
=======
            // txtTruckId
            // 
            this.txtTruckId.Enabled = false;
            this.txtTruckId.Location = new System.Drawing.Point(182, 21);
            this.txtTruckId.MaxLength = 10;
            this.txtTruckId.Name = "txtTruckId";
            this.txtTruckId.Size = new System.Drawing.Size(215, 36);
            this.txtTruckId.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 29);
            this.label2.TabIndex = 50;
            this.label2.Text = "รหัสรถ";
            // 
            // comboxTruckType
            // 
            this.comboxTruckType.FormattingEnabled = true;
            this.comboxTruckType.Location = new System.Drawing.Point(182, 147);
            this.comboxTruckType.Name = "comboxTruckType";
            this.comboxTruckType.Size = new System.Drawing.Size(215, 37);
            this.comboxTruckType.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 29);
            this.label4.TabIndex = 53;
            this.label4.Text = "ประเภทรถ";
>>>>>>> 8e7570345231c099c0226de5161f05ab481aac21
            // 
            // Form_TruckAddEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(591, 261);
            this.Controls.Add(this.cboTruckType);
=======
            this.ClientSize = new System.Drawing.Size(591, 336);
            this.Controls.Add(this.comboxTruckType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTruckId);
>>>>>>> 8e7570345231c099c0226de5161f05ab481aac21
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDriver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.BtnSaveAndNew);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.txtTruckNo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_TruckAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_TruckAddEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTruckNo;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button BtnSaveAndNew;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.Label label3;
<<<<<<< HEAD
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTruckType;
=======
        private System.Windows.Forms.TextBox txtTruckId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboxTruckType;
        private System.Windows.Forms.Label label4;
>>>>>>> 8e7570345231c099c0226de5161f05ab481aac21
    }
}