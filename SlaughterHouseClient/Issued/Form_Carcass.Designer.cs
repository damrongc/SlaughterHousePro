namespace SlaughterHouseClient.Issued
{
    partial class Form_Carcass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Carcass));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblCurrentDatetime = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dragControl1 = new DragControl();
            this.lblWeight = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReceiveNo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblOrderQty = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblOrderWgh = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblUnloadedQty = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblUnloadedWgh = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
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
            this.panelHeader.Size = new System.Drawing.Size(1024, 54);
            this.panelHeader.TabIndex = 0;
            // 
            // lblCurrentDatetime
            // 
            this.lblCurrentDatetime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCurrentDatetime.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCurrentDatetime.ForeColor = System.Drawing.Color.White;
            this.lblCurrentDatetime.Location = new System.Drawing.Point(798, 0);
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
            this.btnExit.Location = new System.Drawing.Point(948, 0);
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
            this.label1.Text = "จ่ายหมูซีก";
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
            this.lblWeight.Location = new System.Drawing.Point(507, 90);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(505, 195);
            this.lblWeight.TabIndex = 5;
            this.lblWeight.Text = "0.00";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Kanit", 16F);
            this.label4.Location = new System.Drawing.Point(845, 57);
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
            this.btnReceiveNo.Location = new System.Drawing.Point(355, 90);
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
            this.label5.Size = new System.Drawing.Size(142, 33);
            this.label5.TabIndex = 8;
            this.label5.Text = "เลขที่ใบสั่งขาย";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOrderNo.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblOrderNo.ForeColor = System.Drawing.Color.Black;
            this.lblOrderNo.Location = new System.Drawing.Point(18, 90);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(331, 43);
            this.lblOrderNo.TabIndex = 9;
            // 
            // lblProduct
            // 
            this.lblProduct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProduct.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblProduct.ForeColor = System.Drawing.Color.Black;
            this.lblProduct.Location = new System.Drawing.Point(18, 242);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(483, 43);
            this.lblProduct.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kanit", 16F);
            this.label8.Location = new System.Drawing.Point(18, 209);
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
            this.btnStart.Location = new System.Drawing.Point(507, 293);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(146, 43);
            this.btnStart.TabIndex = 18;
            this.btnStart.Text = "เริ่มชั่ง";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblOrderQty
            // 
            this.lblOrderQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOrderQty.Font = new System.Drawing.Font("Kanit", 40F);
            this.lblOrderQty.ForeColor = System.Drawing.Color.Black;
            this.lblOrderQty.Location = new System.Drawing.Point(18, 625);
            this.lblOrderQty.Name = "lblOrderQty";
            this.lblOrderQty.Size = new System.Drawing.Size(175, 97);
            this.lblOrderQty.TabIndex = 20;
            this.lblOrderQty.Text = "0";
            this.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Kanit", 16F);
            this.label16.Location = new System.Drawing.Point(12, 592);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 33);
            this.label16.TabIndex = 19;
            this.label16.Text = "จำนวน";
            // 
            // lblOrderWgh
            // 
            this.lblOrderWgh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblOrderWgh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderWgh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOrderWgh.Font = new System.Drawing.Font("Kanit", 40F);
            this.lblOrderWgh.ForeColor = System.Drawing.Color.Black;
            this.lblOrderWgh.Location = new System.Drawing.Point(199, 625);
            this.lblOrderWgh.Name = "lblOrderWgh";
            this.lblOrderWgh.Size = new System.Drawing.Size(294, 97);
            this.lblOrderWgh.TabIndex = 22;
            this.lblOrderWgh.Text = "0.00";
            this.lblOrderWgh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Kanit", 16F);
            this.label18.Location = new System.Drawing.Point(193, 592);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 33);
            this.label18.TabIndex = 21;
            this.label18.Text = "น้ำหนัก";
            // 
            // lblUnloadedQty
            // 
            this.lblUnloadedQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblUnloadedQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUnloadedQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUnloadedQty.Font = new System.Drawing.Font("Kanit", 40F);
            this.lblUnloadedQty.ForeColor = System.Drawing.Color.Black;
            this.lblUnloadedQty.Location = new System.Drawing.Point(537, 625);
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
            this.label20.Location = new System.Drawing.Point(531, 592);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(111, 33);
            this.label20.TabIndex = 23;
            this.label20.Text = "จำนวนจ่าย";
            // 
            // lblUnloadedWgh
            // 
            this.lblUnloadedWgh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblUnloadedWgh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUnloadedWgh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUnloadedWgh.Font = new System.Drawing.Font("Kanit", 40F);
            this.lblUnloadedWgh.ForeColor = System.Drawing.Color.Black;
            this.lblUnloadedWgh.Location = new System.Drawing.Point(718, 625);
            this.lblUnloadedWgh.Name = "lblUnloadedWgh";
            this.lblUnloadedWgh.Size = new System.Drawing.Size(294, 97);
            this.lblUnloadedWgh.TabIndex = 26;
            this.lblUnloadedWgh.Text = "0.00";
            this.lblUnloadedWgh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Kanit", 16F);
            this.label22.Location = new System.Drawing.Point(712, 592);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(113, 33);
            this.label22.TabIndex = 25;
            this.label22.Text = "น้ำหนักจ่าย";
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMessage.Font = new System.Drawing.Font("Kanit", 16F);
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(0, 735);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1024, 33);
            this.lblMessage.TabIndex = 28;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kanit", 16F);
            this.label3.Location = new System.Drawing.Point(18, 306);
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
            this.btnAccept.Location = new System.Drawing.Point(659, 293);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(146, 43);
            this.btnAccept.TabIndex = 32;
            this.btnAccept.Text = "ตกลง";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCustomer.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(18, 166);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(483, 43);
            this.lblCustomer.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Kanit", 16F);
            this.label6.Location = new System.Drawing.Point(18, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 33);
            this.label6.TabIndex = 33;
            this.label6.Text = "ลูกค้า";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 342);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(879, 247);
            this.flowLayoutPanel1.TabIndex = 52;
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnUp.ForeColor = System.Drawing.Color.White;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(903, 342);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(109, 70);
            this.btnUp.TabIndex = 57;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnDown.ForeColor = System.Drawing.Color.White;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(903, 418);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(109, 70);
            this.btnDown.TabIndex = 56;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // Form_Carcass
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblUnloadedWgh);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblUnloadedQty);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblOrderWgh);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblOrderQty);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReceiveNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Carcass";
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
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblOrderQty;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblOrderWgh;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblUnloadedQty;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblUnloadedWgh;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblCurrentDatetime;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
    }
}

