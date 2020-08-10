namespace SlaughterHouseClient.Issued
{
    partial class Form_CarcassForSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CarcassForSales));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblCurrentDatetime = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOrderNo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOrderQty = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblOrderWgh = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblUnloadedQty = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblUnloadedWgh = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.plSimulator = new System.Windows.Forms.GroupBox();
            this.btnSetWgh = new System.Windows.Forms.Button();
            this.txtSimWeight = new System.Windows.Forms.TextBox();
            this.btnZero = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnAcceptWeight = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timerMinWeight = new System.Windows.Forms.Timer(this.components);
            this.lblMaxWeight = new System.Windows.Forms.Label();
            this.lblMinWeight = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTruckNo = new System.Windows.Forms.ComboBox();
            this.dragControl1 = new DragControl();
            this.btnClear = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.plSimulator.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
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
            this.label1.Text = "ขายหมูซีก";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWeight
            // 
            this.lblWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWeight.Font = new System.Drawing.Font("Kanit", 120F);
            this.lblWeight.Location = new System.Drawing.Point(507, 90);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(511, 219);
            this.lblWeight.TabIndex = 5;
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
            // btnOrderNo
            // 
            this.btnOrderNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btnOrderNo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOrderNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderNo.Font = new System.Drawing.Font("Kanit", 16F);
            this.btnOrderNo.ForeColor = System.Drawing.Color.White;
            this.btnOrderNo.Location = new System.Drawing.Point(355, 90);
            this.btnOrderNo.Name = "btnOrderNo";
            this.btnOrderNo.Size = new System.Drawing.Size(146, 43);
            this.btnOrderNo.TabIndex = 7;
            this.btnOrderNo.Text = "เลือกข้อมูล";
            this.btnOrderNo.UseVisualStyleBackColor = false;
            this.btnOrderNo.Click += new System.EventHandler(this.BtnOrderNo_Click);
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
            this.lblProduct.Location = new System.Drawing.Point(18, 265);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(279, 43);
            this.lblProduct.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kanit", 16F);
            this.label8.Location = new System.Drawing.Point(18, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 33);
            this.label8.TabIndex = 10;
            this.label8.Text = "สินค้า";
            // 
            // lblOrderQty
            // 
            this.lblOrderQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOrderQty.Font = new System.Drawing.Font("Kanit", 40F);
            this.lblOrderQty.ForeColor = System.Drawing.Color.Black;
            this.lblOrderQty.Location = new System.Drawing.Point(18, 354);
            this.lblOrderQty.Name = "lblOrderQty";
            this.lblOrderQty.Size = new System.Drawing.Size(175, 87);
            this.lblOrderQty.TabIndex = 20;
            this.lblOrderQty.Text = "0";
            this.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Kanit", 16F);
            this.label16.Location = new System.Drawing.Point(12, 325);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 33);
            this.label16.TabIndex = 19;
            this.label16.Text = "จำนวนสั่ง";
            // 
            // lblOrderWgh
            // 
            this.lblOrderWgh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblOrderWgh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderWgh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOrderWgh.Font = new System.Drawing.Font("Kanit", 40F);
            this.lblOrderWgh.ForeColor = System.Drawing.Color.Black;
            this.lblOrderWgh.Location = new System.Drawing.Point(207, 354);
            this.lblOrderWgh.Name = "lblOrderWgh";
            this.lblOrderWgh.Size = new System.Drawing.Size(294, 87);
            this.lblOrderWgh.TabIndex = 22;
            this.lblOrderWgh.Text = "0.00";
            this.lblOrderWgh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Kanit", 16F);
            this.label18.Location = new System.Drawing.Point(201, 325);
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
            this.lblUnloadedQty.Location = new System.Drawing.Point(18, 527);
            this.lblUnloadedQty.Name = "lblUnloadedQty";
            this.lblUnloadedQty.Size = new System.Drawing.Size(175, 87);
            this.lblUnloadedQty.TabIndex = 24;
            this.lblUnloadedQty.Text = "0";
            this.lblUnloadedQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Kanit", 16F);
            this.label20.Location = new System.Drawing.Point(12, 498);
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
            this.lblUnloadedWgh.Location = new System.Drawing.Point(207, 527);
            this.lblUnloadedWgh.Name = "lblUnloadedWgh";
            this.lblUnloadedWgh.Size = new System.Drawing.Size(294, 87);
            this.lblUnloadedWgh.TabIndex = 26;
            this.lblUnloadedWgh.Text = "0.00";
            this.lblUnloadedWgh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Kanit", 16F);
            this.label22.Location = new System.Drawing.Point(199, 498);
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
            this.lblMessage.Location = new System.Drawing.Point(0, 651);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1024, 50);
            this.lblMessage.TabIndex = 28;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomer
            // 
            this.lblCustomer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCustomer.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(18, 174);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(483, 43);
            this.lblCustomer.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Kanit", 16F);
            this.label6.Location = new System.Drawing.Point(18, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 33);
            this.label6.TabIndex = 33;
            this.label6.Text = "ลูกค้า";
            // 
            // plSimulator
            // 
            this.plSimulator.BackColor = System.Drawing.Color.White;
            this.plSimulator.Controls.Add(this.btnSetWgh);
            this.plSimulator.Controls.Add(this.txtSimWeight);
            this.plSimulator.Controls.Add(this.btnZero);
            this.plSimulator.Font = new System.Drawing.Font("Kanit", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.plSimulator.Location = new System.Drawing.Point(717, 93);
            this.plSimulator.Name = "plSimulator";
            this.plSimulator.Size = new System.Drawing.Size(292, 59);
            this.plSimulator.TabIndex = 58;
            this.plSimulator.TabStop = false;
            this.plSimulator.Text = "Simulator";
            // 
            // btnSetWgh
            // 
            this.btnSetWgh.Location = new System.Drawing.Point(96, 22);
            this.btnSetWgh.Name = "btnSetWgh";
            this.btnSetWgh.Size = new System.Drawing.Size(70, 31);
            this.btnSetWgh.TabIndex = 43;
            this.btnSetWgh.Text = "Set Wgh";
            this.btnSetWgh.UseVisualStyleBackColor = true;
            this.btnSetWgh.Click += new System.EventHandler(this.btnSetWgh_Click);
            // 
            // txtSimWeight
            // 
            this.txtSimWeight.Location = new System.Drawing.Point(10, 26);
            this.txtSimWeight.Name = "txtSimWeight";
            this.txtSimWeight.Size = new System.Drawing.Size(78, 24);
            this.txtSimWeight.TabIndex = 42;
            this.txtSimWeight.Text = "0";
            this.txtSimWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(172, 22);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(80, 31);
            this.btnZero.TabIndex = 41;
            this.btnZero.Text = "Set Zero";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // btnAcceptWeight
            // 
            this.btnAcceptWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnAcceptWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptWeight.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnAcceptWeight.ForeColor = System.Drawing.Color.White;
            this.btnAcceptWeight.Location = new System.Drawing.Point(816, 524);
            this.btnAcceptWeight.Name = "btnAcceptWeight";
            this.btnAcceptWeight.Size = new System.Drawing.Size(203, 90);
            this.btnAcceptWeight.TabIndex = 77;
            this.btnAcceptWeight.Text = "ตกลง";
            this.btnAcceptWeight.UseVisualStyleBackColor = false;
            this.btnAcceptWeight.Click += new System.EventHandler(this.BtnAcceptWeight_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // timerMinWeight
            // 
            this.timerMinWeight.Interval = 1000;
            this.timerMinWeight.Tick += new System.EventHandler(this.TimerMinWeight_Tick);
            // 
            // lblMaxWeight
            // 
            this.lblMaxWeight.BackColor = System.Drawing.Color.Red;
            this.lblMaxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMaxWeight.Font = new System.Drawing.Font("Kanit", 16F);
            this.lblMaxWeight.ForeColor = System.Drawing.Color.White;
            this.lblMaxWeight.Location = new System.Drawing.Point(507, 90);
            this.lblMaxWeight.Name = "lblMaxWeight";
            this.lblMaxWeight.Size = new System.Drawing.Size(99, 43);
            this.lblMaxWeight.TabIndex = 80;
            this.lblMaxWeight.Text = "0.00";
            this.lblMaxWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMinWeight
            // 
            this.lblMinWeight.BackColor = System.Drawing.Color.Yellow;
            this.lblMinWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMinWeight.Font = new System.Drawing.Font("Kanit", 16F);
            this.lblMinWeight.Location = new System.Drawing.Point(507, 266);
            this.lblMinWeight.Name = "lblMinWeight";
            this.lblMinWeight.Size = new System.Drawing.Size(99, 43);
            this.lblMinWeight.TabIndex = 79;
            this.lblMinWeight.Text = "0.00";
            this.lblMinWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kanit", 16F);
            this.label2.Location = new System.Drawing.Point(303, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 33);
            this.label2.TabIndex = 81;
            this.label2.Text = "ทะเบียนรถ";
            // 
            // cboTruckNo
            // 
            this.cboTruckNo.Font = new System.Drawing.Font("Kanit", 18F);
            this.cboTruckNo.FormattingEnabled = true;
            this.cboTruckNo.Location = new System.Drawing.Point(303, 265);
            this.cboTruckNo.Name = "cboTruckNo";
            this.cboTruckNo.Size = new System.Drawing.Size(198, 43);
            this.cboTruckNo.TabIndex = 84;
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelHeader;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Black;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Kanit", 30F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(919, 418);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 90);
            this.btnClear.TabIndex = 107;
            this.btnClear.Text = "c";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn0.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn0.ForeColor = System.Drawing.Color.White;
            this.btn0.Location = new System.Drawing.Point(610, 524);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(100, 90);
            this.btn0.TabIndex = 106;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn3.ForeColor = System.Drawing.Color.White;
            this.btn3.Location = new System.Drawing.Point(713, 312);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(100, 90);
            this.btn3.TabIndex = 105;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn2.ForeColor = System.Drawing.Color.White;
            this.btn2.Location = new System.Drawing.Point(610, 312);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(100, 90);
            this.btn2.TabIndex = 104;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn1.ForeColor = System.Drawing.Color.White;
            this.btn1.Location = new System.Drawing.Point(507, 312);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(100, 90);
            this.btn1.TabIndex = 103;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn6.ForeColor = System.Drawing.Color.White;
            this.btn6.Location = new System.Drawing.Point(610, 418);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(100, 90);
            this.btn6.TabIndex = 102;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn5.ForeColor = System.Drawing.Color.White;
            this.btn5.Location = new System.Drawing.Point(507, 418);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(100, 90);
            this.btn5.TabIndex = 101;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn4.ForeColor = System.Drawing.Color.White;
            this.btn4.Location = new System.Drawing.Point(816, 312);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(100, 90);
            this.btn4.TabIndex = 100;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn9.ForeColor = System.Drawing.Color.White;
            this.btn9.Location = new System.Drawing.Point(507, 524);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(100, 90);
            this.btn9.TabIndex = 99;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn8.ForeColor = System.Drawing.Color.White;
            this.btn8.Location = new System.Drawing.Point(816, 418);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(100, 90);
            this.btn8.TabIndex = 98;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.Font = new System.Drawing.Font("Kanit", 30F);
            this.btn7.ForeColor = System.Drawing.Color.White;
            this.btn7.Location = new System.Drawing.Point(713, 418);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(100, 90);
            this.btn7.TabIndex = 97;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            // 
            // btnDot
            // 
            this.btnDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btnDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDot.Font = new System.Drawing.Font("Kanit", 30F);
            this.btnDot.ForeColor = System.Drawing.Color.White;
            this.btnDot.Location = new System.Drawing.Point(713, 524);
            this.btnDot.Name = "btnDot";
            this.btnDot.Size = new System.Drawing.Size(100, 90);
            this.btnDot.TabIndex = 108;
            this.btnDot.Text = ".";
            this.btnDot.UseVisualStyleBackColor = false;
            this.btnDot.Click += new System.EventHandler(this.btnDot_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkGray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(919, 312);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 90);
            this.btnBack.TabIndex = 109;
            this.btnBack.Text = "back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Form_CarcassForSales
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1024, 701);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDot);
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
            this.Controls.Add(this.cboTruckNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.plSimulator);
            this.Controls.Add(this.lblMaxWeight);
            this.Controls.Add(this.lblMinWeight);
            this.Controls.Add(this.btnAcceptWeight);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblUnloadedWgh);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblUnloadedQty);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblOrderWgh);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblOrderQty);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnOrderNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_CarcassForSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelHeader.ResumeLayout(false);
            this.plSimulator.ResumeLayout(false);
            this.plSimulator.PerformLayout();
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
        private System.Windows.Forms.Button btnOrderNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox plSimulator;
        private System.Windows.Forms.Button btnSetWgh;
        private System.Windows.Forms.TextBox txtSimWeight;
        private System.Windows.Forms.Button btnZero;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnAcceptWeight;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timerMinWeight;
        private System.Windows.Forms.Label lblMaxWeight;
        private System.Windows.Forms.Label lblMinWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTruckNo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btnDot;
        private System.Windows.Forms.Button btnBack;
    }
}
