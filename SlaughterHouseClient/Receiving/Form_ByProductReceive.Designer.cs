namespace SlaughterHouseClient.Receiving
{
    partial class Form_ByProductReceive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ByProductReceive));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblCurrentDatetime = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReceiveNo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReceiveNo = new System.Windows.Forms.Label();
            this.lblFarm = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
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
            this.timerMinWeight = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lblFarmQty = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAcceptWeight = new System.Windows.Forms.Button();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblQty = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblSelectedProduct = new System.Windows.Forms.Label();
            this.dragControl1 = new DragControl();
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
            this.lblCaption.Size = new System.Drawing.Size(237, 54);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "รับเครื่องใน";
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
            this.lblWeight.Size = new System.Drawing.Size(553, 204);
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
            // btnReceiveNo
            // 
            this.btnReceiveNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btnReceiveNo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveNo.Font = new System.Drawing.Font("Kanit", 16F);
            this.btnReceiveNo.ForeColor = System.Drawing.Color.White;
            this.btnReceiveNo.Location = new System.Drawing.Point(293, 90);
            this.btnReceiveNo.Name = "btnReceiveNo";
            this.btnReceiveNo.Size = new System.Drawing.Size(160, 43);
            this.btnReceiveNo.TabIndex = 7;
            this.btnReceiveNo.Text = "เลือกข้อมูล";
            this.btnReceiveNo.UseVisualStyleBackColor = false;
            this.btnReceiveNo.Click += new System.EventHandler(this.btnReceiveNo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kanit", 16F);
            this.label5.Location = new System.Drawing.Point(-2, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 33);
            this.label5.TabIndex = 8;
            this.label5.Text = "เลขที่ใบรับ";
            // 
            // lblReceiveNo
            // 
            this.lblReceiveNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblReceiveNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceiveNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblReceiveNo.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblReceiveNo.ForeColor = System.Drawing.Color.Black;
            this.lblReceiveNo.Location = new System.Drawing.Point(4, 90);
            this.lblReceiveNo.Name = "lblReceiveNo";
            this.lblReceiveNo.Size = new System.Drawing.Size(283, 43);
            this.lblReceiveNo.TabIndex = 9;
            // 
            // lblFarm
            // 
            this.lblFarm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFarm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFarm.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblFarm.ForeColor = System.Drawing.Color.Black;
            this.lblFarm.Location = new System.Drawing.Point(4, 169);
            this.lblFarm.Name = "lblFarm";
            this.lblFarm.Size = new System.Drawing.Size(449, 43);
            this.lblFarm.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kanit", 16F);
            this.label8.Location = new System.Drawing.Point(-2, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 33);
            this.label8.TabIndex = 10;
            this.label8.Text = "ฟาร์ม";
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
            this.btnStop.Location = new System.Drawing.Point(902, 480);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(110, 72);
            this.btnStop.TabIndex = 38;
            this.btnStop.Text = "หยุดชั่ง";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(902, 402);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 72);
            this.btnStart.TabIndex = 37;
            this.btnStart.Text = "เริ่มชั่ง";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(142, 33);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(60, 31);
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
            this.lblMinWeight.Location = new System.Drawing.Point(459, 251);
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
            this.plSimulator.Location = new System.Drawing.Point(795, 90);
            this.plSimulator.Name = "plSimulator";
            this.plSimulator.Size = new System.Drawing.Size(214, 72);
            this.plSimulator.TabIndex = 50;
            this.plSimulator.TabStop = false;
            this.plSimulator.Text = "Simulator";
            // 
            // btnSetWgh
            // 
            this.btnSetWgh.Location = new System.Drawing.Point(80, 33);
            this.btnSetWgh.Name = "btnSetWgh";
            this.btnSetWgh.Size = new System.Drawing.Size(56, 31);
            this.btnSetWgh.TabIndex = 43;
            this.btnSetWgh.Text = "Wgh";
            this.btnSetWgh.UseVisualStyleBackColor = true;
            this.btnSetWgh.Click += new System.EventHandler(this.btnSetWgh_Click);
            // 
            // txtSimWeight
            // 
            this.txtSimWeight.Location = new System.Drawing.Point(6, 37);
            this.txtSimWeight.Name = "txtSimWeight";
            this.txtSimWeight.Size = new System.Drawing.Size(68, 24);
            this.txtSimWeight.TabIndex = 42;
            this.txtSimWeight.Text = "0";
            this.txtSimWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblStable
            // 
            this.lblStable.AutoSize = true;
            this.lblStable.Location = new System.Drawing.Point(989, 267);
            this.lblStable.Name = "lblStable";
            this.lblStable.Size = new System.Drawing.Size(20, 24);
            this.lblStable.TabIndex = 53;
            this.lblStable.Text = "0";
            // 
            // timerMinWeight
            // 
            this.timerMinWeight.Interval = 1000;
            this.timerMinWeight.Tick += new System.EventHandler(this.TimerMinWeight_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // lblFarmQty
            // 
            this.lblFarmQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFarmQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFarmQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFarmQty.Font = new System.Drawing.Font("Kanit", 20.25F);
            this.lblFarmQty.ForeColor = System.Drawing.Color.Black;
            this.lblFarmQty.Location = new System.Drawing.Point(277, 249);
            this.lblFarmQty.Name = "lblFarmQty";
            this.lblFarmQty.Size = new System.Drawing.Size(176, 43);
            this.lblFarmQty.TabIndex = 67;
            this.lblFarmQty.Text = "0";
            this.lblFarmQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Kanit", 16F);
            this.label16.Location = new System.Drawing.Point(271, 215);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(147, 33);
            this.label16.TabIndex = 66;
            this.label16.Text = "จำนวน (ฟาร์ม)";
            // 
            // btnAcceptWeight
            // 
            this.btnAcceptWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnAcceptWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptWeight.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnAcceptWeight.ForeColor = System.Drawing.Color.White;
            this.btnAcceptWeight.Location = new System.Drawing.Point(902, 558);
            this.btnAcceptWeight.Name = "btnAcceptWeight";
            this.btnAcceptWeight.Size = new System.Drawing.Size(110, 72);
            this.btnAcceptWeight.TabIndex = 74;
            this.btnAcceptWeight.Text = "ตกลง";
            this.btnAcceptWeight.UseVisualStyleBackColor = false;
            this.btnAcceptWeight.Visible = false;
            this.btnAcceptWeight.Click += new System.EventHandler(this.BtnAcceptWeight_Click);
            // 
            // lblLotNo
            // 
            this.lblLotNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLotNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLotNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLotNo.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLotNo.ForeColor = System.Drawing.Color.Black;
            this.lblLotNo.Location = new System.Drawing.Point(4, 248);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(253, 43);
            this.lblLotNo.TabIndex = 78;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kanit", 16F);
            this.label3.Location = new System.Drawing.Point(-2, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 33);
            this.label3.TabIndex = 77;
            this.label3.Text = "Lot No";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(141)))), ((int)(((byte)(0)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(902, 636);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 72);
            this.btnPrint.TabIndex = 79;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblQty
            // 
            this.lblQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblQty.Font = new System.Drawing.Font("Kanit", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.ForeColor = System.Drawing.Color.Black;
            this.lblQty.Location = new System.Drawing.Point(904, 310);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(108, 72);
            this.lblQty.TabIndex = 84;
            this.lblQty.Text = "0";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQty.Click += new System.EventHandler(this.lblQty_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 310);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(629, 398);
            this.flowLayoutPanel1.TabIndex = 85;
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn9.ForeColor = System.Drawing.Color.White;
            this.btn9.Location = new System.Drawing.Point(818, 558);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(80, 72);
            this.btn9.TabIndex = 88;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn8.ForeColor = System.Drawing.Color.White;
            this.btn8.Location = new System.Drawing.Point(732, 558);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(80, 72);
            this.btn8.TabIndex = 87;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn7.ForeColor = System.Drawing.Color.White;
            this.btn7.Location = new System.Drawing.Point(642, 558);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(80, 72);
            this.btn7.TabIndex = 86;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn6.ForeColor = System.Drawing.Color.White;
            this.btn6.Location = new System.Drawing.Point(818, 480);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(80, 72);
            this.btn6.TabIndex = 91;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn5.ForeColor = System.Drawing.Color.White;
            this.btn5.Location = new System.Drawing.Point(732, 480);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(80, 72);
            this.btn5.TabIndex = 90;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn4.ForeColor = System.Drawing.Color.White;
            this.btn4.Location = new System.Drawing.Point(642, 480);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(80, 72);
            this.btn4.TabIndex = 89;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn3.ForeColor = System.Drawing.Color.White;
            this.btn3.Location = new System.Drawing.Point(818, 402);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(80, 72);
            this.btn3.TabIndex = 94;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn2.ForeColor = System.Drawing.Color.White;
            this.btn2.Location = new System.Drawing.Point(732, 402);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(80, 72);
            this.btn2.TabIndex = 93;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn1.ForeColor = System.Drawing.Color.White;
            this.btn1.Location = new System.Drawing.Point(642, 402);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(80, 72);
            this.btn1.TabIndex = 92;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn0.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn0.ForeColor = System.Drawing.Color.White;
            this.btn0.Location = new System.Drawing.Point(642, 636);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(80, 72);
            this.btn0.TabIndex = 95;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkGray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Kanit", 30F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(732, 636);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(164, 72);
            this.btnClear.TabIndex = 96;
            this.btnClear.Text = "c";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblSelectedProduct
            // 
            this.lblSelectedProduct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSelectedProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSelectedProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSelectedProduct.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSelectedProduct.ForeColor = System.Drawing.Color.Black;
            this.lblSelectedProduct.Location = new System.Drawing.Point(641, 310);
            this.lblSelectedProduct.Name = "lblSelectedProduct";
            this.lblSelectedProduct.Size = new System.Drawing.Size(253, 72);
            this.lblSelectedProduct.TabIndex = 97;
            this.lblSelectedProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelHeader;
            // 
            // Form_ByProductReceive
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.lblSelectedProduct);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblLotNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAcceptWeight);
            this.Controls.Add(this.lblFarmQty);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblStable);
            this.Controls.Add(this.plSimulator);
            this.Controls.Add(this.lblMaxWeight);
            this.Controls.Add(this.lblMinWeight);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblFarm);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblReceiveNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReceiveNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ByProductReceive";
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
        private System.Windows.Forms.Button btnReceiveNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReceiveNo;
        private System.Windows.Forms.Label lblFarm;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.Timer timerMinWeight;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lblFarmQty;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnAcceptWeight;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSelectedProduct;
    }
}
