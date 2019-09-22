namespace SlaughterHouseClient.Receiving
{
    partial class Form_ByProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ByProduct));
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
            this.lblSwineQty = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblRemainQty = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblStockQty = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblStockWgh = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.lblQueueNo = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblBreeder = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTruckNo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMinWeight = new System.Windows.Forms.Label();
            this.lblMaxWeight = new System.Windows.Forms.Label();
            this.plSimulator = new System.Windows.Forms.GroupBox();
            this.btnSetWgh = new System.Windows.Forms.Button();
            this.txtSimWeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dragControl1 = new DragControl();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panelHeader.SuspendLayout();
            this.plSimulator.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
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
            this.lblCaption.Text = "รับเครื่องในแดง";
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
            // btnReceiveNo
            // 
            this.btnReceiveNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.btnReceiveNo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveNo.Font = new System.Drawing.Font("Kanit", 16F);
            this.btnReceiveNo.ForeColor = System.Drawing.Color.White;
            this.btnReceiveNo.Location = new System.Drawing.Point(307, 90);
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
            this.label5.Location = new System.Drawing.Point(12, 57);
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
            this.lblReceiveNo.Location = new System.Drawing.Point(18, 90);
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
            this.lblFarm.Location = new System.Drawing.Point(18, 186);
            this.lblFarm.Name = "lblFarm";
            this.lblFarm.Size = new System.Drawing.Size(435, 43);
            this.lblFarm.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kanit", 16F);
            this.label8.Location = new System.Drawing.Point(12, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 33);
            this.label8.TabIndex = 10;
            this.label8.Text = "ฟาร์ม";
            // 
            // lblSwineQty
            // 
            this.lblSwineQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSwineQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSwineQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSwineQty.Font = new System.Drawing.Font("Kanit", 50F);
            this.lblSwineQty.ForeColor = System.Drawing.Color.Black;
            this.lblSwineQty.Location = new System.Drawing.Point(19, 610);
            this.lblSwineQty.Name = "lblSwineQty";
            this.lblSwineQty.Size = new System.Drawing.Size(175, 97);
            this.lblSwineQty.TabIndex = 20;
            this.lblSwineQty.Text = "0";
            this.lblSwineQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Kanit", 16F);
            this.label16.Location = new System.Drawing.Point(13, 577);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(147, 33);
            this.label16.TabIndex = 19;
            this.label16.Text = "จำนวน (ฟาร์ม)";
            // 
            // lblRemainQty
            // 
            this.lblRemainQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRemainQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRemainQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRemainQty.Font = new System.Drawing.Font("Kanit", 50F);
            this.lblRemainQty.ForeColor = System.Drawing.Color.Black;
            this.lblRemainQty.Location = new System.Drawing.Point(239, 610);
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
            this.label18.Location = new System.Drawing.Point(233, 577);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(146, 33);
            this.label18.TabIndex = 21;
            this.label18.Text = "จำนวน (รอชั่ง)";
            // 
            // lblStockQty
            // 
            this.lblStockQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStockQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStockQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStockQty.Font = new System.Drawing.Font("Kanit", 50F);
            this.lblStockQty.ForeColor = System.Drawing.Color.Black;
            this.lblStockQty.Location = new System.Drawing.Point(459, 610);
            this.lblStockQty.Name = "lblStockQty";
            this.lblStockQty.Size = new System.Drawing.Size(175, 97);
            this.lblStockQty.TabIndex = 24;
            this.lblStockQty.Text = "0";
            this.lblStockQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Kanit", 16F);
            this.label20.Location = new System.Drawing.Point(453, 577);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(158, 33);
            this.label20.TabIndex = 23;
            this.label20.Text = "จำนวน (ชั่งแล้ว)";
            // 
            // lblStockWgh
            // 
            this.lblStockWgh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStockWgh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStockWgh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStockWgh.Font = new System.Drawing.Font("Kanit", 50F);
            this.lblStockWgh.ForeColor = System.Drawing.Color.Black;
            this.lblStockWgh.Location = new System.Drawing.Point(680, 610);
            this.lblStockWgh.Name = "lblStockWgh";
            this.lblStockWgh.Size = new System.Drawing.Size(332, 97);
            this.lblStockWgh.TabIndex = 26;
            this.lblStockWgh.Text = "0.00";
            this.lblStockWgh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Kanit", 16F);
            this.label22.Location = new System.Drawing.Point(902, 577);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(112, 33);
            this.label22.TabIndex = 25;
            this.label22.Text = "น้ำหนักรวม";
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
            this.btnStop.Location = new System.Drawing.Point(876, 437);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(136, 70);
            this.btnStop.TabIndex = 38;
            this.btnStop.Text = "ยกเลิก";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(876, 361);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(136, 70);
            this.btnStart.TabIndex = 37;
            this.btnStart.Text = "เริ่มชั่ง";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(112, 74);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(98, 31);
            this.btnZero.TabIndex = 41;
            this.btnZero.Text = "Set Zero";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // lblQueueNo
            // 
            this.lblQueueNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblQueueNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblQueueNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblQueueNo.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblQueueNo.ForeColor = System.Drawing.Color.Black;
            this.lblQueueNo.Location = new System.Drawing.Point(201, 282);
            this.lblQueueNo.Name = "lblQueueNo";
            this.lblQueueNo.Size = new System.Drawing.Size(100, 43);
            this.lblQueueNo.TabIndex = 47;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Kanit", 16F);
            this.label14.Location = new System.Drawing.Point(195, 249);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 33);
            this.label14.TabIndex = 46;
            this.label14.Text = "คิวที่";
            // 
            // lblBreeder
            // 
            this.lblBreeder.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblBreeder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBreeder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBreeder.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBreeder.ForeColor = System.Drawing.Color.Black;
            this.lblBreeder.Location = new System.Drawing.Point(307, 282);
            this.lblBreeder.Name = "lblBreeder";
            this.lblBreeder.Size = new System.Drawing.Size(146, 43);
            this.lblBreeder.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Kanit", 16F);
            this.label12.Location = new System.Drawing.Point(301, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 33);
            this.label12.TabIndex = 44;
            this.label12.Text = "ประเภท";
            // 
            // lblTruckNo
            // 
            this.lblTruckNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTruckNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTruckNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTruckNo.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTruckNo.ForeColor = System.Drawing.Color.Black;
            this.lblTruckNo.Location = new System.Drawing.Point(19, 282);
            this.lblTruckNo.Name = "lblTruckNo";
            this.lblTruckNo.Size = new System.Drawing.Size(176, 43);
            this.lblTruckNo.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Kanit", 16F);
            this.label10.Location = new System.Drawing.Point(13, 249);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 33);
            this.label10.TabIndex = 42;
            this.label10.Text = "ทะเบียนรถ";
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
            this.lblMinWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.lblMaxWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plSimulator
            // 
            this.plSimulator.Controls.Add(this.btnSetWgh);
            this.plSimulator.Controls.Add(this.txtSimWeight);
            this.plSimulator.Controls.Add(this.btnZero);
            this.plSimulator.Location = new System.Drawing.Point(155, 150);
            this.plSimulator.Name = "plSimulator";
            this.plSimulator.Size = new System.Drawing.Size(238, 126);
            this.plSimulator.TabIndex = 50;
            this.plSimulator.TabStop = false;
            this.plSimulator.Text = "Simulator";
            // 
            // btnSetWgh
            // 
            this.btnSetWgh.Location = new System.Drawing.Point(112, 37);
            this.btnSetWgh.Name = "btnSetWgh";
            this.btnSetWgh.Size = new System.Drawing.Size(98, 31);
            this.btnSetWgh.TabIndex = 43;
            this.btnSetWgh.Text = "Set Wgh";
            this.btnSetWgh.UseVisualStyleBackColor = true;
            this.btnSetWgh.Click += new System.EventHandler(this.btnSetWgh_Click);
            // 
            // txtSimWeight
            // 
            this.txtSimWeight.Location = new System.Drawing.Point(6, 37);
            this.txtSimWeight.Name = "txtSimWeight";
            this.txtSimWeight.Size = new System.Drawing.Size(100, 31);
            this.txtSimWeight.TabIndex = 42;
            this.txtSimWeight.Text = "0";
            this.txtSimWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kanit", 16F);
            this.label2.Location = new System.Drawing.Point(13, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 33);
            this.label2.TabIndex = 52;
            this.label2.Text = "สินค้า";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(19, 361);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(851, 211);
            this.flowLayoutPanel1.TabIndex = 51;
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelHeader;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM2";
            // 
            // Form_ByProduct
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.plSimulator);
            this.Controls.Add(this.lblMaxWeight);
            this.Controls.Add(this.lblMinWeight);
            this.Controls.Add(this.lblQueueNo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblBreeder);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblTruckNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblStockWgh);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblStockQty);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblRemainQty);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblSwineQty);
            this.Controls.Add(this.label16);
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
            this.Name = "Form_ByProduct";
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
        private System.Windows.Forms.Label lblSwineQty;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblRemainQty;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblStockQty;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblStockWgh;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblCurrentDatetime;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Label lblQueueNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblBreeder;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTruckNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMinWeight;
        private System.Windows.Forms.Label lblMaxWeight;
        private System.Windows.Forms.GroupBox plSimulator;
        private System.Windows.Forms.Button btnSetWgh;
        private System.Windows.Forms.TextBox txtSimWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

