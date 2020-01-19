namespace SlaughterHouseClient
{
    partial class Form_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Settings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboComport = new System.Windows.Forms.ComboBox();
            this.cboBaudrate = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboStableTarget = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMsgDisplayTime = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDivision = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCaptureTime = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 44);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 44);
            this.label1.TabIndex = 15;
            this.label1.Text = "Settings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnClose.Location = new System.Drawing.Point(537, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 44);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kanit", 18F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(182, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 35);
            this.label2.TabIndex = 16;
            this.label2.Text = "COMPORT:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kanit", 18F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(172, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 35);
            this.label3.TabIndex = 17;
            this.label3.Text = "BAUDRATE:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboComport
            // 
            this.cboComport.Font = new System.Drawing.Font("Kanit", 18F);
            this.cboComport.FormattingEnabled = true;
            this.cboComport.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.cboComport.Location = new System.Drawing.Point(312, 88);
            this.cboComport.Name = "cboComport";
            this.cboComport.Size = new System.Drawing.Size(258, 43);
            this.cboComport.TabIndex = 18;
            // 
            // cboBaudrate
            // 
            this.cboBaudrate.Font = new System.Drawing.Font("Kanit", 18F);
            this.cboBaudrate.FormattingEnabled = true;
            this.cboBaudrate.Items.AddRange(new object[] {
            "9600",
            "11500"});
            this.cboBaudrate.Location = new System.Drawing.Point(312, 137);
            this.cboBaudrate.Name = "cboBaudrate";
            this.cboBaudrate.Size = new System.Drawing.Size(258, 43);
            this.cboBaudrate.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(312, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(258, 51);
            this.btnSave.TabIndex = 75;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // cboStableTarget
            // 
            this.cboStableTarget.Font = new System.Drawing.Font("Kanit", 18F);
            this.cboStableTarget.FormattingEnabled = true;
            this.cboStableTarget.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20"});
            this.cboStableTarget.Location = new System.Drawing.Point(312, 186);
            this.cboStableTarget.Name = "cboStableTarget";
            this.cboStableTarget.Size = new System.Drawing.Size(258, 43);
            this.cboStableTarget.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Kanit", 18F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(112, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 35);
            this.label4.TabIndex = 76;
            this.label4.Text = "STABLE TARGET:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMsgDisplayTime
            // 
            this.cboMsgDisplayTime.Font = new System.Drawing.Font("Kanit", 18F);
            this.cboMsgDisplayTime.FormattingEnabled = true;
            this.cboMsgDisplayTime.Items.AddRange(new object[] {
            "3",
            "4",
            "5"});
            this.cboMsgDisplayTime.Location = new System.Drawing.Point(312, 333);
            this.cboMsgDisplayTime.Name = "cboMsgDisplayTime";
            this.cboMsgDisplayTime.Size = new System.Drawing.Size(258, 43);
            this.cboMsgDisplayTime.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kanit", 18F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(80, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 35);
            this.label5.TabIndex = 78;
            this.label5.Text = "MSG DISPLAY TIME:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDivision
            // 
            this.cboDivision.Font = new System.Drawing.Font("Kanit", 18F);
            this.cboDivision.FormattingEnabled = true;
            this.cboDivision.Items.AddRange(new object[] {
            "100",
            "1000"});
            this.cboDivision.Location = new System.Drawing.Point(312, 284);
            this.cboDivision.Name = "cboDivision";
            this.cboDivision.Size = new System.Drawing.Size(258, 43);
            this.cboDivision.TabIndex = 81;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Kanit", 18F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(190, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 35);
            this.label6.TabIndex = 80;
            this.label6.Text = "DIVISION:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCaptureTime
            // 
            this.cboCaptureTime.Font = new System.Drawing.Font("Kanit", 18F);
            this.cboCaptureTime.FormattingEnabled = true;
            this.cboCaptureTime.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.cboCaptureTime.Location = new System.Drawing.Point(312, 235);
            this.cboCaptureTime.Name = "cboCaptureTime";
            this.cboCaptureTime.Size = new System.Drawing.Size(258, 43);
            this.cboCaptureTime.TabIndex = 83;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Kanit", 18F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(49, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(257, 35);
            this.label7.TabIndex = 82;
            this.label7.Text = "CAPTURE TIME (SEC.) :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_Settings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(633, 463);
            this.Controls.Add(this.cboCaptureTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboDivision);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboMsgDisplayTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboStableTarget);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboBaudrate);
            this.Controls.Add(this.cboComport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Kanit", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboComport;
        private System.Windows.Forms.ComboBox cboBaudrate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboStableTarget;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMsgDisplayTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDivision;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCaptureTime;
        private System.Windows.Forms.Label label7;
    }
}