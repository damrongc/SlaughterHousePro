namespace SlaughterHouseClient.Issued
{
    partial class Form_StockIssued
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_StockIssued));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblCurrentDatetime = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.dragControl1 = new DragControl();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBarcodeNo = new System.Windows.Forms.TextBox();
            this.gv = new System.Windows.Forms.DataGridView();
            this.btnBarcode = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.lblStable = new System.Windows.Forms.Label();
            this.plSimulator = new System.Windows.Forms.GroupBox();
            this.btnSetWgh = new System.Windows.Forms.Button();
            this.txtSimWeight = new System.Windows.Forms.TextBox();
            this.btnZero = new System.Windows.Forms.Button();
            this.lblMaxWeight = new System.Windows.Forms.Label();
            this.lblMinWeight = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBarcodeWeight = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timerMinWeight = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
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
            this.lblCaption.Size = new System.Drawing.Size(352, 54);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "จ่ายจากคลังสินค้า";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelHeader;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Kanit", 16F);
            this.label6.Location = new System.Drawing.Point(20, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 33);
            this.label6.TabIndex = 61;
            this.label6.Text = "บาร์โค็ด";
            // 
            // txtBarcodeNo
            // 
            this.txtBarcodeNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.txtBarcodeNo.Font = new System.Drawing.Font("Kanit", 18F);
            this.txtBarcodeNo.ForeColor = System.Drawing.Color.White;
            this.txtBarcodeNo.Location = new System.Drawing.Point(20, 90);
            this.txtBarcodeNo.Name = "txtBarcodeNo";
            this.txtBarcodeNo.Size = new System.Drawing.Size(326, 43);
            this.txtBarcodeNo.TabIndex = 62;
            this.txtBarcodeNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gv
            // 
            this.gv.AllowUserToAddRows = false;
            this.gv.AllowUserToDeleteRows = false;
            this.gv.AllowUserToResizeColumns = false;
            this.gv.AllowUserToResizeRows = false;
            this.gv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gv.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnBarcode});
            this.gv.Location = new System.Drawing.Point(19, 291);
            this.gv.MultiSelect = false;
            this.gv.Name = "gv";
            this.gv.RowHeadersWidth = 10;
            this.gv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv.Size = new System.Drawing.Size(840, 424);
            this.gv.TabIndex = 86;
            // 
            // btnBarcode
            // 
            this.btnBarcode.DataPropertyName = "barcode_no";
            this.btnBarcode.HeaderText = "รหัส";
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Width = 44;
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.btnKeyboard.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyboard.Font = new System.Drawing.Font("Kanit", 16F);
            this.btnKeyboard.ForeColor = System.Drawing.Color.White;
            this.btnKeyboard.Image = ((System.Drawing.Image)(resources.GetObject("btnKeyboard.Image")));
            this.btnKeyboard.Location = new System.Drawing.Point(352, 90);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(99, 42);
            this.btnKeyboard.TabIndex = 87;
            this.btnKeyboard.UseVisualStyleBackColor = false;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // lblStable
            // 
            this.lblStable.AutoSize = true;
            this.lblStable.Location = new System.Drawing.Point(988, 263);
            this.lblStable.Name = "lblStable";
            this.lblStable.Size = new System.Drawing.Size(20, 24);
            this.lblStable.TabIndex = 93;
            this.lblStable.Text = "0";
            // 
            // plSimulator
            // 
            this.plSimulator.BackColor = System.Drawing.Color.White;
            this.plSimulator.Controls.Add(this.btnSetWgh);
            this.plSimulator.Controls.Add(this.txtSimWeight);
            this.plSimulator.Controls.Add(this.btnZero);
            this.plSimulator.Font = new System.Drawing.Font("Kanit", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.plSimulator.Location = new System.Drawing.Point(770, 93);
            this.plSimulator.Name = "plSimulator";
            this.plSimulator.Size = new System.Drawing.Size(238, 66);
            this.plSimulator.TabIndex = 92;
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
            // lblMaxWeight
            // 
            this.lblMaxWeight.BackColor = System.Drawing.Color.Red;
            this.lblMaxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMaxWeight.Font = new System.Drawing.Font("Kanit", 16F);
            this.lblMaxWeight.ForeColor = System.Drawing.Color.White;
            this.lblMaxWeight.Location = new System.Drawing.Point(457, 90);
            this.lblMaxWeight.Name = "lblMaxWeight";
            this.lblMaxWeight.Size = new System.Drawing.Size(99, 43);
            this.lblMaxWeight.TabIndex = 91;
            this.lblMaxWeight.Text = "0.00";
            this.lblMaxWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMinWeight
            // 
            this.lblMinWeight.BackColor = System.Drawing.Color.Yellow;
            this.lblMinWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMinWeight.Font = new System.Drawing.Font("Kanit", 16F);
            this.lblMinWeight.Location = new System.Drawing.Point(457, 245);
            this.lblMinWeight.Name = "lblMinWeight";
            this.lblMinWeight.Size = new System.Drawing.Size(99, 43);
            this.lblMinWeight.TabIndex = 90;
            this.lblMinWeight.Text = "0.00";
            this.lblMinWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Kanit", 16F);
            this.label4.Location = new System.Drawing.Point(843, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 33);
            this.label4.TabIndex = 89;
            this.label4.Text = "น้ำหนัก (กิโลกรัม)";
            // 
            // lblWeight
            // 
            this.lblWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWeight.Font = new System.Drawing.Font("Kanit", 120F);
            this.lblWeight.Location = new System.Drawing.Point(457, 90);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(553, 198);
            this.lblWeight.TabIndex = 88;
            this.lblWeight.Text = "0.00";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProduct
            // 
            this.lblProduct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProduct.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblProduct.ForeColor = System.Drawing.Color.Black;
            this.lblProduct.Location = new System.Drawing.Point(20, 169);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(431, 43);
            this.lblProduct.TabIndex = 95;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kanit", 16F);
            this.label8.Location = new System.Drawing.Point(20, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 33);
            this.label8.TabIndex = 94;
            this.label8.Text = "สินค้า";
            // 
            // lblLotNo
            // 
            this.lblLotNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLotNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLotNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLotNo.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLotNo.ForeColor = System.Drawing.Color.Black;
            this.lblLotNo.Location = new System.Drawing.Point(20, 245);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(224, 43);
            this.lblLotNo.TabIndex = 97;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kanit", 16F);
            this.label2.Location = new System.Drawing.Point(20, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 33);
            this.label2.TabIndex = 96;
            this.label2.Text = "Lot No.";
            // 
            // lblBarcodeWeight
            // 
            this.lblBarcodeWeight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblBarcodeWeight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBarcodeWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBarcodeWeight.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBarcodeWeight.ForeColor = System.Drawing.Color.Black;
            this.lblBarcodeWeight.Location = new System.Drawing.Point(250, 245);
            this.lblBarcodeWeight.Name = "lblBarcodeWeight";
            this.lblBarcodeWeight.Size = new System.Drawing.Size(201, 43);
            this.lblBarcodeWeight.TabIndex = 99;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kanit", 16F);
            this.label5.Location = new System.Drawing.Point(250, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 33);
            this.label5.TabIndex = 98;
            this.label5.Text = "น้ำหนัก (QR)";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(863, 369);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(147, 72);
            this.btnStop.TabIndex = 101;
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
            this.btnStart.Location = new System.Drawing.Point(865, 291);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(145, 72);
            this.btnStart.TabIndex = 100;
            this.btnStart.Text = "เริ่มชั่ง";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timerMinWeight
            // 
            this.timerMinWeight.Interval = 1000;
            this.timerMinWeight.Tick += new System.EventHandler(this.timerMinWeight_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form_StockIssued
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 701);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblBarcodeWeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLotNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblStable);
            this.Controls.Add(this.plSimulator);
            this.Controls.Add(this.lblMaxWeight);
            this.Controls.Add(this.lblMinWeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.btnKeyboard);
            this.Controls.Add(this.gv);
            this.Controls.Add(this.txtBarcodeNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_StockIssued";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รับหมูเป็น";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
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
        private System.Windows.Forms.Label lblCurrentDatetime;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBarcodeNo;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.DataGridViewButtonColumn btnBarcode;
        private System.Windows.Forms.Button btnKeyboard;
        private System.Windows.Forms.Label lblStable;
        private System.Windows.Forms.GroupBox plSimulator;
        private System.Windows.Forms.Button btnSetWgh;
        private System.Windows.Forms.TextBox txtSimWeight;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Label lblMaxWeight;
        private System.Windows.Forms.Label lblMinWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBarcodeWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timerMinWeight;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
