namespace SlaughterHouseClient.Receiving
{
    partial class Form_ReceiveReturn
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ReceiveReturn));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblCurrentDatetime = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnProduct = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblStockQty = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.lblMinWeight = new System.Windows.Forms.Label();
            this.lblMaxWeight = new System.Windows.Forms.Label();
            this.plSimulator = new System.Windows.Forms.GroupBox();
            this.btnSetWgh = new System.Windows.Forms.Button();
            this.txtSimWeight = new System.Windows.Forms.TextBox();
            this.lblStable = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblLastWeight = new System.Windows.Forms.Label();
            this.timerMinWeight = new System.Windows.Forms.Timer(this.components);
            this.btnZeroWeight = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.dragControl1 = new DragControl();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.plSimulator.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.panelHeader.Controls.Add(this.lblCurrentDatetime);
            this.panelHeader.Controls.Add(this.btnExit);
            this.panelHeader.Controls.Add(this.lblCaption);
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
            // lblCaption
            // 
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCaption.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCaption.ForeColor = System.Drawing.Color.White;
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(266, 54);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "ส่งคืนชิ้นส่วน";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWeight
            // 
            this.lblWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWeight.Font = new System.Drawing.Font("Kanit", 120F);
            this.lblWeight.Location = new System.Drawing.Point(459, 90);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(553, 235);
            this.lblWeight.TabIndex = 5;
            this.lblWeight.Text = "0.00";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btnProduct.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Kanit", 16F);
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Location = new System.Drawing.Point(352, 90);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(101, 43);
            this.btnProduct.TabIndex = 7;
            this.btnProduct.Text = "เลือก";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kanit", 16F);
            this.label5.Location = new System.Drawing.Point(12, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 33);
            this.label5.TabIndex = 8;
            this.label5.Text = "สินค้า";
            // 
            // lblProduct
            // 
            this.lblProduct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProduct.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblProduct.ForeColor = System.Drawing.Color.Black;
            this.lblProduct.Location = new System.Drawing.Point(18, 90);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(328, 130);
            this.lblProduct.TabIndex = 9;
            // 
            // lblStockQty
            // 
            this.lblStockQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStockQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStockQty.Font = new System.Drawing.Font("Kanit", 40F);
            this.lblStockQty.ForeColor = System.Drawing.Color.Black;
            this.lblStockQty.Location = new System.Drawing.Point(254, 632);
            this.lblStockQty.Name = "lblStockQty";
            this.lblStockQty.Size = new System.Drawing.Size(199, 75);
            this.lblStockQty.TabIndex = 24;
            this.lblStockQty.Text = "0";
            this.lblStockQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMessage.Font = new System.Drawing.Font("Kanit", 16F);
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(0, 718);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1024, 50);
            this.lblMessage.TabIndex = 28;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(862, 347);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(150, 110);
            this.btnStop.TabIndex = 38;
            this.btnStop.Text = "หยุดชั่ง";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(459, 347);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 110);
            this.btnStart.TabIndex = 37;
            this.btnStart.Text = "เริ่มชั่ง";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(151, 19);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(69, 31);
            this.btnZero.TabIndex = 41;
            this.btnZero.Text = "Zero";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // lblMinWeight
            // 
            this.lblMinWeight.BackColor = System.Drawing.Color.Yellow;
            this.lblMinWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMinWeight.Font = new System.Drawing.Font("Kanit", 16F);
            this.lblMinWeight.Location = new System.Drawing.Point(459, 282);
            this.lblMinWeight.Name = "lblMinWeight";
            this.lblMinWeight.Size = new System.Drawing.Size(99, 43);
            this.lblMinWeight.TabIndex = 48;
            this.lblMinWeight.Text = "0.00";
            this.lblMinWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaxWeight
            // 
            this.lblMaxWeight.BackColor = System.Drawing.Color.Red;
            this.lblMaxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMaxWeight.Font = new System.Drawing.Font("Kanit", 16F);
            this.lblMaxWeight.ForeColor = System.Drawing.Color.White;
            this.lblMaxWeight.Location = new System.Drawing.Point(459, 90);
            this.lblMaxWeight.Name = "lblMaxWeight";
            this.lblMaxWeight.Size = new System.Drawing.Size(99, 43);
            this.lblMaxWeight.TabIndex = 49;
            this.lblMaxWeight.Text = "0.00";
            this.lblMaxWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // plSimulator
            // 
            this.plSimulator.BackColor = System.Drawing.Color.White;
            this.plSimulator.Controls.Add(this.btnSetWgh);
            this.plSimulator.Controls.Add(this.txtSimWeight);
            this.plSimulator.Controls.Add(this.btnZero);
            this.plSimulator.Font = new System.Drawing.Font("Kanit", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.plSimulator.Location = new System.Drawing.Point(771, 93);
            this.plSimulator.Name = "plSimulator";
            this.plSimulator.Size = new System.Drawing.Size(238, 66);
            this.plSimulator.TabIndex = 50;
            this.plSimulator.TabStop = false;
            // 
            // btnSetWgh
            // 
            this.btnSetWgh.Location = new System.Drawing.Point(74, 19);
            this.btnSetWgh.Name = "btnSetWgh";
            this.btnSetWgh.Size = new System.Drawing.Size(71, 31);
            this.btnSetWgh.TabIndex = 43;
            this.btnSetWgh.Text = "Wgh";
            this.btnSetWgh.UseVisualStyleBackColor = true;
            this.btnSetWgh.Click += new System.EventHandler(this.btnSetWgh_Click);
            // 
            // txtSimWeight
            // 
            this.txtSimWeight.Location = new System.Drawing.Point(6, 23);
            this.txtSimWeight.Name = "txtSimWeight";
            this.txtSimWeight.Size = new System.Drawing.Size(62, 24);
            this.txtSimWeight.TabIndex = 42;
            this.txtSimWeight.Text = "0";
            this.txtSimWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblStable
            // 
            this.lblStable.AutoSize = true;
            this.lblStable.Location = new System.Drawing.Point(989, 298);
            this.lblStable.Name = "lblStable";
            this.lblStable.Size = new System.Drawing.Size(20, 24);
            this.lblStable.TabIndex = 53;
            this.lblStable.Text = "0";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(862, 629);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(150, 78);
            this.btnPrint.TabIndex = 56;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // lblLastWeight
            // 
            this.lblLastWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLastWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLastWeight.Font = new System.Drawing.Font("Kanit", 40F);
            this.lblLastWeight.ForeColor = System.Drawing.Color.Black;
            this.lblLastWeight.Location = new System.Drawing.Point(12, 632);
            this.lblLastWeight.Name = "lblLastWeight";
            this.lblLastWeight.Size = new System.Drawing.Size(236, 75);
            this.lblLastWeight.TabIndex = 60;
            this.lblLastWeight.Text = "0.00";
            this.lblLastWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerMinWeight
            // 
            this.timerMinWeight.Interval = 1000;
            this.timerMinWeight.Tick += new System.EventHandler(this.TimerMinWeight_Tick);
            // 
            // btnZeroWeight
            // 
            this.btnZeroWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(141)))), ((int)(((byte)(0)))));
            this.btnZeroWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZeroWeight.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnZeroWeight.ForeColor = System.Drawing.Color.White;
            this.btnZeroWeight.Location = new System.Drawing.Point(706, 629);
            this.btnZeroWeight.Name = "btnZeroWeight";
            this.btnZeroWeight.Size = new System.Drawing.Size(150, 78);
            this.btnZeroWeight.TabIndex = 61;
            this.btnZeroWeight.Text = "Zero";
            this.btnZeroWeight.UseVisualStyleBackColor = false;
            this.btnZeroWeight.Visible = false;
            this.btnZeroWeight.Click += new System.EventHandler(this.btnZeroWeight_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelHeader;
            // 
            // lblLotNo
            // 
            this.lblLotNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLotNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLotNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLotNo.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLotNo.ForeColor = System.Drawing.Color.Black;
            this.lblLotNo.Location = new System.Drawing.Point(18, 282);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(328, 43);
            this.lblLotNo.TabIndex = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kanit", 16F);
            this.label3.Location = new System.Drawing.Point(12, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 33);
            this.label3.TabIndex = 79;
            this.label3.Text = "Lot No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kanit", 16F);
            this.label2.Location = new System.Drawing.Point(12, 599);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 33);
            this.label2.TabIndex = 81;
            this.label2.Text = "น้ำหนัก";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kanit", 16F);
            this.label1.Location = new System.Drawing.Point(245, 599);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 33);
            this.label1.TabIndex = 82;
            this.label1.Text = "จำนวน";
            // 
            // Form_ReceiveReturn
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLotNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnZeroWeight);
            this.Controls.Add(this.lblLastWeight);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblStable);
            this.Controls.Add(this.plSimulator);
            this.Controls.Add(this.lblMaxWeight);
            this.Controls.Add(this.lblMinWeight);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblStockQty);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ReceiveReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รับหมูเป็น";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panelHeader.ResumeLayout(false);
            this.plSimulator.ResumeLayout(false);
            this.plSimulator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblCaption;
        private DragControl dragControl1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblStockQty;
        private System.Windows.Forms.Label lblCurrentDatetime;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Label lblMinWeight;
        private System.Windows.Forms.Label lblMaxWeight;
        private System.Windows.Forms.GroupBox plSimulator;
        private System.Windows.Forms.Button btnSetWgh;
        private System.Windows.Forms.TextBox txtSimWeight;
        private System.Windows.Forms.Label lblStable;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblLastWeight;
        private System.Windows.Forms.Timer timerMinWeight;
        private System.Windows.Forms.Button btnZeroWeight;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
