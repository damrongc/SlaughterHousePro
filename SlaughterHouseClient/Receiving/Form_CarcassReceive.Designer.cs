namespace SlaughterHouseClient.Receiving
{
    partial class Form_CarcassReceive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CarcassReceive));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblProductionDate = new System.Windows.Forms.Label();
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
            this.lblBreeder = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblMinWeight = new System.Windows.Forms.Label();
            this.lblMaxWeight = new System.Windows.Forms.Label();
            this.plSimulator = new System.Windows.Forms.GroupBox();
            this.btnSetWgh = new System.Windows.Forms.Button();
            this.txtSimWeight = new System.Windows.Forms.TextBox();
            this.lblStable = new System.Windows.Forms.Label();
            this.timerMinWeight = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lblFactoryWgh = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblFactoryQty = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblRemainQty = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblFarmQty = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAcceptWeight = new System.Windows.Forms.Button();
            this.lblLastWgh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMale = new System.Windows.Forms.Button();
            this.btnUndified = new System.Windows.Forms.Button();
            this.btnFemale = new System.Windows.Forms.Button();
            this.dragControl1 = new DragControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.plSimulator.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.panelHeader.Controls.Add(this.lblProductionDate);
            this.panelHeader.Controls.Add(this.btnExit);
            this.panelHeader.Controls.Add(this.lblCaption);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1024, 54);
            this.panelHeader.TabIndex = 0;
            // 
            // lblProductionDate
            // 
            this.lblProductionDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblProductionDate.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblProductionDate.ForeColor = System.Drawing.Color.White;
            this.lblProductionDate.Location = new System.Drawing.Point(798, 0);
            this.lblProductionDate.Name = "lblProductionDate";
            this.lblProductionDate.Size = new System.Drawing.Size(150, 54);
            this.lblProductionDate.TabIndex = 14;
            this.lblProductionDate.Text = "-";
            this.lblProductionDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.lblCaption.Size = new System.Drawing.Size(119, 54);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "รับหมูซีก";
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
            this.btnReceiveNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
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
            this.btnStop.Font = new System.Drawing.Font("Kanit", 32F);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(625, 377);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(172, 125);
            this.btnStop.TabIndex = 38;
            this.btnStop.Text = "หยุดชั่ง";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Kanit", 32F);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(459, 377);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(160, 125);
            this.btnStart.TabIndex = 37;
            this.btnStart.Text = "เริ่มชั่ง";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(159, 19);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(73, 31);
            this.btnZero.TabIndex = 41;
            this.btnZero.Text = "Zero";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // lblBreeder
            // 
            this.lblBreeder.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblBreeder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBreeder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBreeder.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBreeder.ForeColor = System.Drawing.Color.Black;
            this.lblBreeder.Location = new System.Drawing.Point(19, 282);
            this.lblBreeder.Name = "lblBreeder";
            this.lblBreeder.Size = new System.Drawing.Size(208, 43);
            this.lblBreeder.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Kanit", 16F);
            this.label12.Location = new System.Drawing.Point(13, 247);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 33);
            this.label12.TabIndex = 44;
            this.label12.Text = "ประเภท";
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
            this.plSimulator.Location = new System.Drawing.Point(773, 90);
            this.plSimulator.Name = "plSimulator";
            this.plSimulator.Size = new System.Drawing.Size(238, 60);
            this.plSimulator.TabIndex = 50;
            this.plSimulator.TabStop = false;
            this.plSimulator.Text = "Simulator";
            // 
            // btnSetWgh
            // 
            this.btnSetWgh.Location = new System.Drawing.Point(85, 19);
            this.btnSetWgh.Name = "btnSetWgh";
            this.btnSetWgh.Size = new System.Drawing.Size(71, 31);
            this.btnSetWgh.TabIndex = 43;
            this.btnSetWgh.Text = "Set Wgh";
            this.btnSetWgh.UseVisualStyleBackColor = true;
            this.btnSetWgh.Click += new System.EventHandler(this.btnSetWgh_Click);
            // 
            // txtSimWeight
            // 
            this.txtSimWeight.Location = new System.Drawing.Point(6, 23);
            this.txtSimWeight.Name = "txtSimWeight";
            this.txtSimWeight.Size = new System.Drawing.Size(73, 24);
            this.txtSimWeight.TabIndex = 42;
            this.txtSimWeight.Text = "0";
            this.txtSimWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblStable
            // 
            this.lblStable.AutoSize = true;
            this.lblStable.Location = new System.Drawing.Point(990, 298);
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
            // lblFactoryWgh
            // 
            this.lblFactoryWgh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFactoryWgh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFactoryWgh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFactoryWgh.Font = new System.Drawing.Font("Kanit", 48F);
            this.lblFactoryWgh.ForeColor = System.Drawing.Color.Black;
            this.lblFactoryWgh.Location = new System.Drawing.Point(678, 621);
            this.lblFactoryWgh.Name = "lblFactoryWgh";
            this.lblFactoryWgh.Size = new System.Drawing.Size(332, 97);
            this.lblFactoryWgh.TabIndex = 73;
            this.lblFactoryWgh.Text = "0";
            this.lblFactoryWgh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Kanit", 16F);
            this.label22.Location = new System.Drawing.Point(672, 588);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(112, 33);
            this.label22.TabIndex = 72;
            this.label22.Text = "น้ำหนักรวม";
            // 
            // lblFactoryQty
            // 
            this.lblFactoryQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFactoryQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFactoryQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFactoryQty.Font = new System.Drawing.Font("Kanit", 48F);
            this.lblFactoryQty.ForeColor = System.Drawing.Color.Black;
            this.lblFactoryQty.Location = new System.Drawing.Point(458, 621);
            this.lblFactoryQty.Name = "lblFactoryQty";
            this.lblFactoryQty.Size = new System.Drawing.Size(208, 97);
            this.lblFactoryQty.TabIndex = 71;
            this.lblFactoryQty.Text = "0";
            this.lblFactoryQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Kanit", 16F);
            this.label20.Location = new System.Drawing.Point(450, 588);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(158, 33);
            this.label20.TabIndex = 70;
            this.label20.Text = "จำนวน (ชั่งแล้ว)";
            // 
            // lblRemainQty
            // 
            this.lblRemainQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRemainQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRemainQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRemainQty.Font = new System.Drawing.Font("Kanit", 48F);
            this.lblRemainQty.ForeColor = System.Drawing.Color.Black;
            this.lblRemainQty.Location = new System.Drawing.Point(238, 621);
            this.lblRemainQty.Name = "lblRemainQty";
            this.lblRemainQty.Size = new System.Drawing.Size(208, 97);
            this.lblRemainQty.TabIndex = 69;
            this.lblRemainQty.Text = "0";
            this.lblRemainQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Kanit", 16F);
            this.label18.Location = new System.Drawing.Point(232, 588);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(146, 33);
            this.label18.TabIndex = 68;
            this.label18.Text = "จำนวน (รอชั่ง)";
            // 
            // lblFarmQty
            // 
            this.lblFarmQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFarmQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFarmQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFarmQty.Font = new System.Drawing.Font("Kanit", 48F);
            this.lblFarmQty.ForeColor = System.Drawing.Color.Black;
            this.lblFarmQty.Location = new System.Drawing.Point(18, 621);
            this.lblFarmQty.Name = "lblFarmQty";
            this.lblFarmQty.Size = new System.Drawing.Size(208, 97);
            this.lblFarmQty.TabIndex = 67;
            this.lblFarmQty.Text = "0";
            this.lblFarmQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Kanit", 16F);
            this.label16.Location = new System.Drawing.Point(12, 588);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(147, 33);
            this.label16.TabIndex = 66;
            this.label16.Text = "จำนวน (ฟาร์ม)";
            // 
            // btnAcceptWeight
            // 
            this.btnAcceptWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnAcceptWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptWeight.Font = new System.Drawing.Font("Kanit", 32F);
            this.btnAcceptWeight.ForeColor = System.Drawing.Color.White;
            this.btnAcceptWeight.Location = new System.Drawing.Point(803, 377);
            this.btnAcceptWeight.Name = "btnAcceptWeight";
            this.btnAcceptWeight.Size = new System.Drawing.Size(208, 125);
            this.btnAcceptWeight.TabIndex = 74;
            this.btnAcceptWeight.Text = "ตกลง";
            this.btnAcceptWeight.UseVisualStyleBackColor = false;
            this.btnAcceptWeight.Visible = false;
            this.btnAcceptWeight.Click += new System.EventHandler(this.BtnAcceptWeight_Click);
            // 
            // lblLastWgh
            // 
            this.lblLastWgh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLastWgh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLastWgh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLastWgh.Font = new System.Drawing.Font("Kanit", 30F);
            this.lblLastWgh.ForeColor = System.Drawing.Color.Black;
            this.lblLastWgh.Location = new System.Drawing.Point(803, 543);
            this.lblLastWgh.Name = "lblLastWgh";
            this.lblLastWgh.Size = new System.Drawing.Size(209, 65);
            this.lblLastWgh.TabIndex = 76;
            this.lblLastWgh.Text = "0.00";
            this.lblLastWgh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kanit", 16F);
            this.label2.Location = new System.Drawing.Point(797, 510);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 33);
            this.label2.TabIndex = 75;
            this.label2.Text = "น้ำหนักล่าสุด";
            // 
            // lblLotNo
            // 
            this.lblLotNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLotNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLotNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLotNo.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLotNo.ForeColor = System.Drawing.Color.Black;
            this.lblLotNo.Location = new System.Drawing.Point(233, 282);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(220, 43);
            this.lblLotNo.TabIndex = 78;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kanit", 16F);
            this.label3.Location = new System.Drawing.Point(227, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 33);
            this.label3.TabIndex = 77;
            this.label3.Text = "Lot No";
            // 
            // btnMale
            // 
            this.btnMale.BackColor = System.Drawing.Color.Silver;
            this.btnMale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMale.Font = new System.Drawing.Font("Kanit", 30F);
            this.btnMale.ForeColor = System.Drawing.Color.White;
            this.btnMale.Location = new System.Drawing.Point(160, 377);
            this.btnMale.Name = "btnMale";
            this.btnMale.Size = new System.Drawing.Size(136, 125);
            this.btnMale.TabIndex = 82;
            this.btnMale.Text = "ผู้";
            this.btnMale.UseVisualStyleBackColor = false;
            this.btnMale.Click += new System.EventHandler(this.btnMale_Click);
            // 
            // btnUndified
            // 
            this.btnUndified.BackColor = System.Drawing.Color.Silver;
            this.btnUndified.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndified.Font = new System.Drawing.Font("Kanit", 30F);
            this.btnUndified.ForeColor = System.Drawing.Color.White;
            this.btnUndified.Location = new System.Drawing.Point(302, 377);
            this.btnUndified.Name = "btnUndified";
            this.btnUndified.Size = new System.Drawing.Size(136, 125);
            this.btnUndified.TabIndex = 81;
            this.btnUndified.Text = "ไม่ระบุ";
            this.btnUndified.UseVisualStyleBackColor = false;
            this.btnUndified.Click += new System.EventHandler(this.btnUndified_Click);
            // 
            // btnFemale
            // 
            this.btnFemale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btnFemale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFemale.Font = new System.Drawing.Font("Kanit", 30F);
            this.btnFemale.ForeColor = System.Drawing.Color.White;
            this.btnFemale.Location = new System.Drawing.Point(18, 377);
            this.btnFemale.Name = "btnFemale";
            this.btnFemale.Size = new System.Drawing.Size(136, 125);
            this.btnFemale.TabIndex = 79;
            this.btnFemale.Text = "เมีย";
            this.btnFemale.UseVisualStyleBackColor = false;
            this.btnFemale.Click += new System.EventHandler(this.btnFemale_Click);
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelHeader;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kanit", 16F);
            this.label1.Location = new System.Drawing.Point(12, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 33);
            this.label1.TabIndex = 80;
            this.label1.Text = "เพศ";
            // 
            // Form_CarcassReceive
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnMale);
            this.Controls.Add(this.btnUndified);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFemale);
            this.Controls.Add(this.lblLotNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLastWgh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAcceptWeight);
            this.Controls.Add(this.lblFactoryWgh);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblFactoryQty);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblRemainQty);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblFarmQty);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblStable);
            this.Controls.Add(this.plSimulator);
            this.Controls.Add(this.lblMaxWeight);
            this.Controls.Add(this.lblMinWeight);
            this.Controls.Add(this.lblBreeder);
            this.Controls.Add(this.label12);
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
            this.Name = "Form_CarcassReceive";
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
        private System.Windows.Forms.Label lblProductionDate;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Label lblBreeder;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblMinWeight;
        private System.Windows.Forms.Label lblMaxWeight;
        private System.Windows.Forms.GroupBox plSimulator;
        private System.Windows.Forms.Button btnSetWgh;
        private System.Windows.Forms.TextBox txtSimWeight;
        private System.Windows.Forms.Label lblStable;
        private System.Windows.Forms.Timer timerMinWeight;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lblFactoryWgh;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblFactoryQty;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblRemainQty;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblFarmQty;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnAcceptWeight;
        private System.Windows.Forms.Label lblLastWgh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMale;
        private System.Windows.Forms.Button btnUndified;
        private System.Windows.Forms.Button btnFemale;
        private System.Windows.Forms.Label label1;
    }
}
