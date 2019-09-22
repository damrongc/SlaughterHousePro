namespace SlaughterHouseClient.Receiving
{
    partial class Form_Swine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Swine));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblCurrentDatetime = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFemale = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUndified = new System.Windows.Forms.Button();
            this.btnMale = new System.Windows.Forms.Button();
            this.lblWeight = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReceiveNo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReceiveNo = new System.Windows.Forms.Label();
            this.lblFarm = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTruckNo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblBreeder = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblQueueNo = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblFarmQty = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblRemainQty = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblFactoryQty = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblFactoryWgh = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCloseQueue = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.BgwMinWeight = new System.ComponentModel.BackgroundWorker();
            this.TmMinWeight = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.dragControl1 = new DragControl();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
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
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "รับหมูเป็น";
            // 
            // btnFemale
            // 
            this.btnFemale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.btnFemale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFemale.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnFemale.ForeColor = System.Drawing.Color.White;
            this.btnFemale.Location = new System.Drawing.Point(18, 399);
            this.btnFemale.Name = "btnFemale";
            this.btnFemale.Size = new System.Drawing.Size(136, 70);
            this.btnFemale.TabIndex = 1;
            this.btnFemale.Text = "เมีย";
            this.btnFemale.UseVisualStyleBackColor = false;
            this.btnFemale.Click += new System.EventHandler(this.btnFemale_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kanit", 16F);
            this.label2.Location = new System.Drawing.Point(12, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "เพศ";
            // 
            // btnUndified
            // 
            this.btnUndified.BackColor = System.Drawing.Color.Silver;
            this.btnUndified.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndified.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnUndified.ForeColor = System.Drawing.Color.White;
            this.btnUndified.Location = new System.Drawing.Point(302, 399);
            this.btnUndified.Name = "btnUndified";
            this.btnUndified.Size = new System.Drawing.Size(136, 70);
            this.btnUndified.TabIndex = 3;
            this.btnUndified.Text = "ไม่ระบุ";
            this.btnUndified.UseVisualStyleBackColor = false;
            this.btnUndified.Click += new System.EventHandler(this.btnUndified_Click);
            // 
            // btnMale
            // 
            this.btnMale.BackColor = System.Drawing.Color.Silver;
            this.btnMale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMale.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnMale.ForeColor = System.Drawing.Color.White;
            this.btnMale.Location = new System.Drawing.Point(160, 399);
            this.btnMale.Name = "btnMale";
            this.btnMale.Size = new System.Drawing.Size(136, 70);
            this.btnMale.TabIndex = 4;
            this.btnMale.Text = "ผู้";
            this.btnMale.UseVisualStyleBackColor = false;
            this.btnMale.Click += new System.EventHandler(this.btnMale_Click);
            // 
            // lblWeight
            // 
            this.lblWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWeight.Font = new System.Drawing.Font("Kanit", 120F);
            this.lblWeight.Location = new System.Drawing.Point(507, 90);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(505, 230);
            this.lblWeight.TabIndex = 5;
            this.lblWeight.Text = "0";
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
            this.btnReceiveNo.Location = new System.Drawing.Point(355, 90);
            this.btnReceiveNo.Name = "btnReceiveNo";
            this.btnReceiveNo.Size = new System.Drawing.Size(146, 43);
            this.btnReceiveNo.TabIndex = 7;
            this.btnReceiveNo.Text = "เลือกคิว";
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
            this.lblReceiveNo.Size = new System.Drawing.Size(331, 43);
            this.lblReceiveNo.TabIndex = 9;
            // 
            // lblFarm
            // 
            this.lblFarm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFarm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFarm.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblFarm.ForeColor = System.Drawing.Color.Black;
            this.lblFarm.Location = new System.Drawing.Point(18, 166);
            this.lblFarm.Name = "lblFarm";
            this.lblFarm.Size = new System.Drawing.Size(483, 43);
            this.lblFarm.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kanit", 16F);
            this.label8.Location = new System.Drawing.Point(12, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 33);
            this.label8.TabIndex = 10;
            this.label8.Text = "ฟาร์ม";
            // 
            // lblTruckNo
            // 
            this.lblTruckNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTruckNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTruckNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTruckNo.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTruckNo.ForeColor = System.Drawing.Color.Black;
            this.lblTruckNo.Location = new System.Drawing.Point(18, 242);
            this.lblTruckNo.Name = "lblTruckNo";
            this.lblTruckNo.Size = new System.Drawing.Size(238, 43);
            this.lblTruckNo.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Kanit", 16F);
            this.label10.Location = new System.Drawing.Point(12, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 33);
            this.label10.TabIndex = 12;
            this.label10.Text = "ทะเบียนรถ";
            // 
            // lblBreeder
            // 
            this.lblBreeder.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblBreeder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBreeder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBreeder.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBreeder.ForeColor = System.Drawing.Color.Black;
            this.lblBreeder.Location = new System.Drawing.Point(19, 320);
            this.lblBreeder.Name = "lblBreeder";
            this.lblBreeder.Size = new System.Drawing.Size(238, 43);
            this.lblBreeder.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Kanit", 16F);
            this.label12.Location = new System.Drawing.Point(13, 287);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 33);
            this.label12.TabIndex = 14;
            this.label12.Text = "ประเภท";
            // 
            // lblQueueNo
            // 
            this.lblQueueNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblQueueNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblQueueNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblQueueNo.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblQueueNo.ForeColor = System.Drawing.Color.Black;
            this.lblQueueNo.Location = new System.Drawing.Point(262, 242);
            this.lblQueueNo.Name = "lblQueueNo";
            this.lblQueueNo.Size = new System.Drawing.Size(239, 43);
            this.lblQueueNo.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Kanit", 16F);
            this.label14.Location = new System.Drawing.Point(256, 209);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 33);
            this.label14.TabIndex = 16;
            this.label14.Text = "คิวที่";
            // 
            // lblFarmQty
            // 
            this.lblFarmQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFarmQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFarmQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFarmQty.Font = new System.Drawing.Font("Kanit", 48F);
            this.lblFarmQty.ForeColor = System.Drawing.Color.Black;
            this.lblFarmQty.Location = new System.Drawing.Point(18, 612);
            this.lblFarmQty.Name = "lblFarmQty";
            this.lblFarmQty.Size = new System.Drawing.Size(175, 97);
            this.lblFarmQty.TabIndex = 20;
            this.lblFarmQty.Text = "0";
            this.lblFarmQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Kanit", 16F);
            this.label16.Location = new System.Drawing.Point(12, 579);
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
            this.lblRemainQty.Font = new System.Drawing.Font("Kanit", 48F);
            this.lblRemainQty.ForeColor = System.Drawing.Color.Black;
            this.lblRemainQty.Location = new System.Drawing.Point(238, 612);
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
            this.label18.Location = new System.Drawing.Point(232, 579);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(146, 33);
            this.label18.TabIndex = 21;
            this.label18.Text = "จำนวน (รอชั่ง)";
            // 
            // lblFactoryQty
            // 
            this.lblFactoryQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFactoryQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFactoryQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFactoryQty.Font = new System.Drawing.Font("Kanit", 48F);
            this.lblFactoryQty.ForeColor = System.Drawing.Color.Black;
            this.lblFactoryQty.Location = new System.Drawing.Point(458, 612);
            this.lblFactoryQty.Name = "lblFactoryQty";
            this.lblFactoryQty.Size = new System.Drawing.Size(175, 97);
            this.lblFactoryQty.TabIndex = 24;
            this.lblFactoryQty.Text = "0";
            this.lblFactoryQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Kanit", 16F);
            this.label20.Location = new System.Drawing.Point(450, 579);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(158, 33);
            this.label20.TabIndex = 23;
            this.label20.Text = "จำนวน (ชั่งแล้ว)";
            // 
            // lblFactoryWgh
            // 
            this.lblFactoryWgh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFactoryWgh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFactoryWgh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFactoryWgh.Font = new System.Drawing.Font("Kanit", 48F);
            this.lblFactoryWgh.ForeColor = System.Drawing.Color.Black;
            this.lblFactoryWgh.Location = new System.Drawing.Point(678, 612);
            this.lblFactoryWgh.Name = "lblFactoryWgh";
            this.lblFactoryWgh.Size = new System.Drawing.Size(332, 97);
            this.lblFactoryWgh.TabIndex = 26;
            this.lblFactoryWgh.Text = "0";
            this.lblFactoryWgh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Kanit", 16F);
            this.label22.Location = new System.Drawing.Point(899, 579);
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
            // BtnOK
            // 
            this.BtnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.BtnOK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOK.Font = new System.Drawing.Font("Kanit", 20F);
            this.BtnOK.ForeColor = System.Drawing.Color.White;
            this.BtnOK.Location = new System.Drawing.Point(874, 399);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(136, 70);
            this.BtnOK.TabIndex = 29;
            this.BtnOK.Text = "ตกลง";
            this.BtnOK.UseVisualStyleBackColor = false;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCloseQueue
            // 
            this.BtnCloseQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BtnCloseQueue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnCloseQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCloseQueue.Font = new System.Drawing.Font("Kanit", 20F);
            this.BtnCloseQueue.ForeColor = System.Drawing.Color.White;
            this.BtnCloseQueue.Location = new System.Drawing.Point(875, 475);
            this.BtnCloseQueue.Name = "BtnCloseQueue";
            this.BtnCloseQueue.Size = new System.Drawing.Size(136, 70);
            this.BtnCloseQueue.TabIndex = 30;
            this.BtnCloseQueue.Text = "ปิดคิว";
            this.BtnCloseQueue.UseVisualStyleBackColor = false;
            this.BtnCloseQueue.Visible = false;
            this.BtnCloseQueue.Click += new System.EventHandler(this.BtnCloseQueue_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnStart.Location = new System.Drawing.Point(507, 399);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(136, 70);
            this.btnStart.TabIndex = 31;
            this.btnStart.Text = "เริ่มชั่ง";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // BgwMinWeight
            // 
            this.BgwMinWeight.WorkerReportsProgress = true;
            this.BgwMinWeight.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwMinWeight_DoWork);
            this.BgwMinWeight.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgwMinWeight_ProgressChanged);
            this.BgwMinWeight.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwMinWeight_RunWorkerCompleted);
            // 
            // TmMinWeight
            // 
            this.TmMinWeight.Interval = 1000;
            this.TmMinWeight.Tick += new System.EventHandler(this.TmMinWeight_Tick);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnStop.Location = new System.Drawing.Point(655, 399);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(136, 70);
            this.btnStop.TabIndex = 32;
            this.btnStop.Text = "ยกเลิก";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(507, 325);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(98, 40);
            this.btnZero.TabIndex = 33;
            this.btnZero.Text = "Set Zero";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelHeader;
            // 
            // Form_Swine
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.BtnCloseQueue);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblFactoryWgh);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblFactoryQty);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblRemainQty);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblFarmQty);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblQueueNo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblBreeder);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblTruckNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblFarm);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblReceiveNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReceiveNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.btnMale);
            this.Controls.Add(this.btnUndified);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFemale);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Swine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รับหมูเป็น";
            this.Load += new System.EventHandler(this.Form_SwineReceive_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFemale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUndified;
        private System.Windows.Forms.Button btnMale;
        private DragControl dragControl1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReceiveNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReceiveNo;
        private System.Windows.Forms.Label lblFarm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTruckNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblBreeder;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblQueueNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblFarmQty;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblRemainQty;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblFactoryQty;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblFactoryWgh;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblCurrentDatetime;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCloseQueue;
        private System.Windows.Forms.Button btnStart;
        private System.ComponentModel.BackgroundWorker BgwMinWeight;
        private System.Windows.Forms.Timer TmMinWeight;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnZero;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

