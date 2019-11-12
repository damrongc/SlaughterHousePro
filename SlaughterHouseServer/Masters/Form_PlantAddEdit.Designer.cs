namespace SlaughterHouseServer
{
    partial class Form_PlantAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PlantAddEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlantName = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtPlantId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.txtLogoImage = new System.Windows.Forms.TextBox();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEstNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อโรงงาน";
            // 
            // txtPlantName
            // 
            this.txtPlantName.Location = new System.Drawing.Point(182, 63);
            this.txtPlantName.MaxLength = 10;
            this.txtPlantName.Name = "txtPlantName";
            this.txtPlantName.Size = new System.Drawing.Size(215, 36);
            this.txtPlantName.TabIndex = 1;
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
            this.BtnSave.Location = new System.Drawing.Point(182, 484);
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
            this.chkActive.Location = new System.Drawing.Point(182, 429);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(79, 33);
            this.chkActive.TabIndex = 46;
            this.chkActive.Text = "ใช้งาน";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtPlantId
            // 
            this.txtPlantId.Enabled = false;
            this.txtPlantId.Location = new System.Drawing.Point(182, 21);
            this.txtPlantId.MaxLength = 10;
            this.txtPlantId.Name = "txtPlantId";
            this.txtPlantId.Size = new System.Drawing.Size(215, 36);
            this.txtPlantId.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 29);
            this.label2.TabIndex = 50;
            this.label2.Text = "รหัสโรงงาน";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imgLogo
            // 
            this.imgLogo.Location = new System.Drawing.Point(182, 286);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(189, 138);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogo.TabIndex = 52;
            this.imgLogo.TabStop = false;
            // 
            // txtLogoImage
            // 
            this.txtLogoImage.Location = new System.Drawing.Point(182, 244);
            this.txtLogoImage.MaxLength = 10;
            this.txtLogoImage.Name = "txtLogoImage";
            this.txtLogoImage.ReadOnly = true;
            this.txtLogoImage.Size = new System.Drawing.Size(319, 36);
            this.txtLogoImage.TabIndex = 53;
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(500, 244);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(105, 36);
            this.BtnBrowse.TabIndex = 54;
            this.BtnBrowse.Text = "Browse";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 55;
            this.label3.Text = "UpLoad Logo";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(182, 105);
            this.txtAddress.MaxLength = 10;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(319, 91);
            this.txtAddress.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 29);
            this.label4.TabIndex = 56;
            this.label4.Text = "ที่อยู่";
            // 
            // txtEstNo
            // 
            this.txtEstNo.Location = new System.Drawing.Point(182, 202);
            this.txtEstNo.MaxLength = 3;
            this.txtEstNo.Name = "txtEstNo";
            this.txtEstNo.Size = new System.Drawing.Size(215, 36);
            this.txtEstNo.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 29);
            this.label5.TabIndex = 58;
            this.label5.Text = "Est No";
            // 
            // Form_PlantAddEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(665, 564);
            this.Controls.Add(this.txtEstNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnBrowse);
            this.Controls.Add(this.txtLogoImage);
            this.Controls.Add(this.imgLogo);
            this.Controls.Add(this.txtPlantId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.txtPlantName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_PlantAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_PlantAddEdit";
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPlantName;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtPlantId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.TextBox txtLogoImage;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEstNo;
        private System.Windows.Forms.Label label5;
    }
}