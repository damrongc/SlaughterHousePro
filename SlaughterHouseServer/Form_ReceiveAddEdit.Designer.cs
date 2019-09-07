namespace SlaughterHouseServer
{
    partial class Form_ReceiveAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ReceiveAddEdit));
            this.BtnSaveAndClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTransportNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTruckNo = new System.Windows.Forms.TextBox();
            this.txtFarmWgh = new System.Windows.Forms.TextBox();
            this.txtCoopNo = new System.Windows.Forms.TextBox();
            this.txtFarmQty = new System.Windows.Forms.TextBox();
            this.cboFarm = new System.Windows.Forms.ComboBox();
            this.BtnSaveAndNew = new System.Windows.Forms.Button();
            this.cboBreeder = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReciveNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // BtnSaveAndClose
            // 
            this.BtnSaveAndClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnSaveAndClose.FlatAppearance.BorderSize = 0;
            this.BtnSaveAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveAndClose.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveAndClose.ForeColor = System.Drawing.Color.White;
            this.BtnSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("BtnSaveAndClose.Image")));
            this.BtnSaveAndClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveAndClose.Location = new System.Drawing.Point(634, 434);
            this.BtnSaveAndClose.Name = "BtnSaveAndClose";
            this.BtnSaveAndClose.Size = new System.Drawing.Size(145, 36);
            this.BtnSaveAndClose.TabIndex = 15;
            this.BtnSaveAndClose.Text = "บันทึกแล้วปิด";
            this.BtnSaveAndClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSaveAndClose.UseVisualStyleBackColor = false;
            this.BtnSaveAndClose.Click += new System.EventHandler(this.BtnSaveAndClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "ทะเบียนรถ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "ฟาร์ม:";
            // 
            // txtTransportNo
            // 
            this.txtTransportNo.Location = new System.Drawing.Point(187, 95);
            this.txtTransportNo.MaxLength = 10;
            this.txtTransportNo.Name = "txtTransportNo";
            this.txtTransportNo.Size = new System.Drawing.Size(215, 36);
            this.txtTransportNo.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "เลขที่ใบส่ง:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 29);
            this.label4.TabIndex = 16;
            this.label4.Text = "เล้า:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 29);
            this.label5.TabIndex = 17;
            this.label5.Text = "จำนวนฟาร์ม:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 29);
            this.label6.TabIndex = 18;
            this.label6.Text = "น้ำหนักฟาร์ม:";
            // 
            // txtTruckNo
            // 
            this.txtTruckNo.Location = new System.Drawing.Point(187, 223);
            this.txtTruckNo.MaxLength = 10;
            this.txtTruckNo.Name = "txtTruckNo";
            this.txtTruckNo.Size = new System.Drawing.Size(215, 36);
            this.txtTruckNo.TabIndex = 19;
            // 
            // txtFarmWgh
            // 
            this.txtFarmWgh.Location = new System.Drawing.Point(187, 349);
            this.txtFarmWgh.MaxLength = 10;
            this.txtFarmWgh.Name = "txtFarmWgh";
            this.txtFarmWgh.Size = new System.Drawing.Size(215, 36);
            this.txtFarmWgh.TabIndex = 20;
            this.txtFarmWgh.Text = "0";
            this.txtFarmWgh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCoopNo
            // 
            this.txtCoopNo.Location = new System.Drawing.Point(187, 265);
            this.txtCoopNo.MaxLength = 5;
            this.txtCoopNo.Name = "txtCoopNo";
            this.txtCoopNo.Size = new System.Drawing.Size(215, 36);
            this.txtCoopNo.TabIndex = 21;
            // 
            // txtFarmQty
            // 
            this.txtFarmQty.Location = new System.Drawing.Point(187, 307);
            this.txtFarmQty.MaxLength = 5;
            this.txtFarmQty.Name = "txtFarmQty";
            this.txtFarmQty.Size = new System.Drawing.Size(215, 36);
            this.txtFarmQty.TabIndex = 22;
            this.txtFarmQty.Text = "0";
            this.txtFarmQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboFarm
            // 
            this.cboFarm.FormattingEnabled = true;
            this.cboFarm.Location = new System.Drawing.Point(187, 137);
            this.cboFarm.Name = "cboFarm";
            this.cboFarm.Size = new System.Drawing.Size(592, 37);
            this.cboFarm.TabIndex = 23;
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
            this.BtnSaveAndNew.Location = new System.Drawing.Point(426, 434);
            this.BtnSaveAndNew.Name = "BtnSaveAndNew";
            this.BtnSaveAndNew.Size = new System.Drawing.Size(202, 36);
            this.BtnSaveAndNew.TabIndex = 24;
            this.BtnSaveAndNew.Text = "บันทึกแล้วสร้างใหม่";
            this.BtnSaveAndNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSaveAndNew.UseVisualStyleBackColor = false;
            this.BtnSaveAndNew.Click += new System.EventHandler(this.BtnSaveAndNew_Click);
            // 
            // cboBreeder
            // 
            this.cboBreeder.FormattingEnabled = true;
            this.cboBreeder.Location = new System.Drawing.Point(187, 180);
            this.cboBreeder.Name = "cboBreeder";
            this.cboBreeder.Size = new System.Drawing.Size(215, 37);
            this.cboBreeder.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(108, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 29);
            this.label7.TabIndex = 25;
            this.label7.Text = "ประเภท:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(408, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 29);
            this.label8.TabIndex = 27;
            this.label8.Text = "ตัว";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(408, 352);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 29);
            this.label9.TabIndex = 28;
            this.label9.Text = "กิโลกรัม";
            // 
            // txtReciveNo
            // 
            this.txtReciveNo.Location = new System.Drawing.Point(187, 12);
            this.txtReciveNo.Name = "txtReciveNo";
            this.txtReciveNo.Size = new System.Drawing.Size(215, 36);
            this.txtReciveNo.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(85, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 29);
            this.label10.TabIndex = 29;
            this.label10.Text = "เลขที่ใบรับ:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(108, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 29);
            this.label11.TabIndex = 31;
            this.label11.Text = "วันที่รับ:";
            // 
            // dtpReceiveDate
            // 
            this.dtpReceiveDate.Checked = false;
            this.dtpReceiveDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReceiveDate.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.dtpReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceiveDate.Location = new System.Drawing.Point(187, 56);
            this.dtpReceiveDate.Name = "dtpReceiveDate";
            this.dtpReceiveDate.Size = new System.Drawing.Size(215, 36);
            this.dtpReceiveDate.TabIndex = 32;
            // 
            // Form_ReceiveAddEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(807, 482);
            this.Controls.Add(this.dtpReceiveDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtReciveNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboBreeder);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnSaveAndNew);
            this.Controls.Add(this.cboFarm);
            this.Controls.Add(this.txtFarmQty);
            this.Controls.Add(this.txtCoopNo);
            this.Controls.Add(this.txtFarmWgh);
            this.Controls.Add(this.txtTruckNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnSaveAndClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTransportNo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ReceiveAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_ReceiveAddEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSaveAndClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTransportNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTruckNo;
        private System.Windows.Forms.TextBox txtFarmWgh;
        private System.Windows.Forms.TextBox txtCoopNo;
        private System.Windows.Forms.TextBox txtFarmQty;
        private System.Windows.Forms.ComboBox cboFarm;
        private System.Windows.Forms.Button BtnSaveAndNew;
        private System.Windows.Forms.ComboBox cboBreeder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtReciveNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpReceiveDate;
    }
}