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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ทะเบียนรถ";
            // 
            // txtTruckNo
            // 
            this.txtTruckNo.Location = new System.Drawing.Point(182, 22);
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
            this.BtnSave.Location = new System.Drawing.Point(314, 161);
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
            this.chkActive.Location = new System.Drawing.Point(182, 106);
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
            this.BtnSaveAndNew.Location = new System.Drawing.Point(105, 161);
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
            this.txtDriver.Location = new System.Drawing.Point(182, 67);
            this.txtDriver.MaxLength = 75;
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(347, 36);
            this.txtDriver.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 29);
            this.label3.TabIndex = 48;
            this.label3.Text = "ชื่อคนขับรถ";
            // 
            // Form_TruckAddEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(591, 231);
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
    }
}