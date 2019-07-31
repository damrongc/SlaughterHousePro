namespace SlaughterHouseClient
{
    partial class Form_CarcassIssued
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CarcassIssued));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblCurrentDatetime = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dragControl1 = new DragControl();
            this.lblWeight = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReceiveNo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProductionOrderNo = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblProductionOrderQty = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblRemainQty = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblUnloadedQty = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblUnloadedWgh = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.btnLotNo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.panelHeader.Controls.Add(this.lblCurrentDatetime);
            this.panelHeader.Controls.Add(this.btnExit);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(934, 54);
            this.panelHeader.TabIndex = 0;
            // 
            // lblCurrentDatetime
            // 
            this.lblCurrentDatetime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCurrentDatetime.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCurrentDatetime.ForeColor = System.Drawing.Color.White;
            this.lblCurrentDatetime.Location = new System.Drawing.Point(708, 0);
            this.lblCurrentDatetime.Name = "lblCurrentDatetime";
            this.lblCurrentDatetime.Size = new System.Drawing.Size(150, 54);
            this.lblCurrentDatetime.TabIndex = 14;
            this.lblCurrentDatetime.Text = "-";
            this.lblCurrentDatetime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(858, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(76, 54);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "จ่ายหมูซีก (ตัดแต่ง)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelHeader;
            // 
            // lblWeight
            // 
            this.lblWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWeight.Font = new System.Drawing.Font("Kanit", 120F);
            this.lblWeight.Location = new System.Drawing.Point(415, 90);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(505, 230);
            this.lblWeight.TabIndex = 5;
            this.lblWeight.Text = "0.00";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Kanit", 16F);
            this.label4.Location = new System.Drawing.Point(753, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 33);
            this.label4.TabIndex = 6;
            this.label4.Text = "น้ำหนัก (กิโลกรัม)";
            // 
            // btnReceiveNo
            // 
            this.btnReceiveNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.btnReceiveNo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveNo.Font = new System.Drawing.Font("Kanit", 16F);
            this.btnReceiveNo.ForeColor = System.Drawing.Color.White;
            this.btnReceiveNo.Location = new System.Drawing.Point(263, 90);
            this.btnReceiveNo.Name = "btnReceiveNo";
            this.btnReceiveNo.Size = new System.Drawing.Size(146, 43);
            this.btnReceiveNo.TabIndex = 7;
            this.btnReceiveNo.Text = "เลือกข้อมูล";
            this.btnReceiveNo.UseVisualStyleBackColor = false;
            this.btnReceiveNo.Click += new System.EventHandler(this.btnReceiveNo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kanit", 16F);
            this.label5.Location = new System.Drawing.Point(18, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 33);
            this.label5.TabIndex = 8;
            this.label5.Text = "เลขที่ใบเบิก";
            // 
            // lblProductionOrderNo
            // 
            this.lblProductionOrderNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblProductionOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProductionOrderNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProductionOrderNo.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblProductionOrderNo.ForeColor = System.Drawing.Color.Black;
            this.lblProductionOrderNo.Location = new System.Drawing.Point(18, 90);
            this.lblProductionOrderNo.Name = "lblProductionOrderNo";
            this.lblProductionOrderNo.Size = new System.Drawing.Size(239, 43);
            this.lblProductionOrderNo.TabIndex = 9;
            // 
            // lblProduct
            // 
            this.lblProduct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProduct.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblProduct.ForeColor = System.Drawing.Color.Black;
            this.lblProduct.Location = new System.Drawing.Point(18, 177);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(390, 43);
            this.lblProduct.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kanit", 16F);
            this.label8.Location = new System.Drawing.Point(18, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 33);
            this.label8.TabIndex = 10;
            this.label8.Text = "สินค้า";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Kanit", 16F);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(415, 378);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(146, 43);
            this.btnStart.TabIndex = 18;
            this.btnStart.Text = "เริ่มชั่ง";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblProductionOrderQty
            // 
            this.lblProductionOrderQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblProductionOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProductionOrderQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProductionOrderQty.Font = new System.Drawing.Font("Kanit", 50F);
            this.lblProductionOrderQty.ForeColor = System.Drawing.Color.Black;
            this.lblProductionOrderQty.Location = new System.Drawing.Point(19, 521);
            this.lblProductionOrderQty.Name = "lblProductionOrderQty";
            this.lblProductionOrderQty.Size = new System.Drawing.Size(175, 97);
            this.lblProductionOrderQty.TabIndex = 20;
            this.lblProductionOrderQty.Text = "0";
            this.lblProductionOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Kanit", 16F);
            this.label16.Location = new System.Drawing.Point(13, 488);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(177, 33);
            this.label16.TabIndex = 19;
            this.label16.Text = "จำนวน (เป้าหมาย)";
            // 
            // lblRemainQty
            // 
            this.lblRemainQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRemainQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRemainQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRemainQty.Font = new System.Drawing.Font("Kanit", 50F);
            this.lblRemainQty.ForeColor = System.Drawing.Color.Black;
            this.lblRemainQty.Location = new System.Drawing.Point(200, 521);
            this.lblRemainQty.Name = "lblRemainQty";
            this.lblRemainQty.Size = new System.Drawing.Size(175, 97);
            this.lblRemainQty.TabIndex = 22;
            this.lblRemainQty.Text = "0";
            this.lblRemainQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Kanit", 16F);
            this.label18.Location = new System.Drawing.Point(194, 488);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(146, 33);
            this.label18.TabIndex = 21;
            this.label18.Text = "จำนวน (รอชั่ง)";
            // 
            // lblUnloadedQty
            // 
            this.lblUnloadedQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblUnloadedQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUnloadedQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUnloadedQty.Font = new System.Drawing.Font("Kanit", 50F);
            this.lblUnloadedQty.ForeColor = System.Drawing.Color.Black;
            this.lblUnloadedQty.Location = new System.Drawing.Point(407, 521);
            this.lblUnloadedQty.Name = "lblUnloadedQty";
            this.lblUnloadedQty.Size = new System.Drawing.Size(175, 97);
            this.lblUnloadedQty.TabIndex = 24;
            this.lblUnloadedQty.Text = "0";
            this.lblUnloadedQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Kanit", 16F);
            this.label20.Location = new System.Drawing.Point(399, 488);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(158, 33);
            this.label20.TabIndex = 23;
            this.label20.Text = "จำนวน (ชั่งแล้ว)";
            // 
            // lblUnloadedWgh
            // 
            this.lblUnloadedWgh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblUnloadedWgh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUnloadedWgh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUnloadedWgh.Font = new System.Drawing.Font("Kanit", 50F);
            this.lblUnloadedWgh.ForeColor = System.Drawing.Color.Black;
            this.lblUnloadedWgh.Location = new System.Drawing.Point(588, 521);
            this.lblUnloadedWgh.Name = "lblUnloadedWgh";
            this.lblUnloadedWgh.Size = new System.Drawing.Size(332, 97);
            this.lblUnloadedWgh.TabIndex = 26;
            this.lblUnloadedWgh.Text = "0.00";
            this.lblUnloadedWgh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Kanit", 16F);
            this.label22.Location = new System.Drawing.Point(808, 488);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(112, 33);
            this.label22.TabIndex = 25;
            this.label22.Text = "น้ำหนักรวม";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Kanit", 16F);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(774, 378);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(146, 43);
            this.btnStop.TabIndex = 27;
            this.btnStop.Text = "ปิดงาน";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMessage.Font = new System.Drawing.Font("Kanit", 16F);
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(0, 648);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(934, 33);
            this.lblMessage.TabIndex = 28;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLotNo
            // 
            this.lblLotNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLotNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLotNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLotNo.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLotNo.ForeColor = System.Drawing.Color.Black;
            this.lblLotNo.Location = new System.Drawing.Point(18, 262);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(239, 43);
            this.lblLotNo.TabIndex = 30;
            // 
            // btnLotNo
            // 
            this.btnLotNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.btnLotNo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLotNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLotNo.Font = new System.Drawing.Font("Kanit", 16F);
            this.btnLotNo.ForeColor = System.Drawing.Color.White;
            this.btnLotNo.Location = new System.Drawing.Point(263, 262);
            this.btnLotNo.Name = "btnLotNo";
            this.btnLotNo.Size = new System.Drawing.Size(146, 43);
            this.btnLotNo.TabIndex = 29;
            this.btnLotNo.Text = "เลือกข้อมูล";
            this.btnLotNo.UseVisualStyleBackColor = false;
            this.btnLotNo.Click += new System.EventHandler(this.btnLotNo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kanit", 16F);
            this.label3.Location = new System.Drawing.Point(18, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 33);
            this.label3.TabIndex = 31;
            this.label3.Text = "Lot No";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnAccept.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Kanit", 16F);
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(588, 378);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(146, 43);
            this.btnAccept.TabIndex = 32;
            this.btnAccept.Text = "ตกลง";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // Form_CarcassIssued
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 681);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLotNo);
            this.Controls.Add(this.btnLotNo);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblUnloadedWgh);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblUnloadedQty);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblRemainQty);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblProductionOrderQty);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblProductionOrderNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReceiveNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_CarcassIssued";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รับหมูเป็น";
            this.Load += new System.EventHandler(this.Form_SwineReceive_Load);
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private DragControl dragControl1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReceiveNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProductionOrderNo;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblProductionOrderQty;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblRemainQty;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblUnloadedQty;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblUnloadedWgh;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblCurrentDatetime;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.Button btnLotNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAccept;
    }
}

