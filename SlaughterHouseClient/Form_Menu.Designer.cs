namespace SlaughterHouseClient
{
    partial class Form_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Menu));
            this.btnExit = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblCurrentDatetime = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReceiveSwine = new System.Windows.Forms.Button();
            this.btnReceiveCarcass = new System.Windows.Forms.Button();
            this.btnReceiveHead = new System.Windows.Forms.Button();
            this.btnReceiveByProductWhite = new System.Windows.Forms.Button();
            this.btnReceiveByProductRed = new System.Windows.Forms.Button();
            this.btnReceivePart = new System.Windows.Forms.Button();
            this.btnConfirmStock = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnReceiveSpecial = new System.Windows.Forms.Button();
            this.btnIssueCarcass = new System.Windows.Forms.Button();
            this.btnIssueByProduct = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSalesCarcass = new System.Windows.Forms.Button();
            this.btnStockIssued = new System.Windows.Forms.Button();
            this.btnIssueProductForSales = new System.Windows.Forms.Button();
            this.btnIssueSpacialForSales = new System.Windows.Forms.Button();
            this.dragControl1 = new DragControl();
            this.panelHeader.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
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
            this.btnExit.Location = new System.Drawing.Point(944, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 54);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(107)))), ((int)(((byte)(188)))));
            this.panelHeader.Controls.Add(this.lblCurrentDatetime);
            this.panelHeader.Controls.Add(this.btnSettings);
            this.panelHeader.Controls.Add(this.btnExit);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1024, 54);
            this.panelHeader.TabIndex = 1;
            // 
            // lblCurrentDatetime
            // 
            this.lblCurrentDatetime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCurrentDatetime.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCurrentDatetime.ForeColor = System.Drawing.Color.White;
            this.lblCurrentDatetime.Location = new System.Drawing.Point(738, 0);
            this.lblCurrentDatetime.Name = "lblCurrentDatetime";
            this.lblCurrentDatetime.Size = new System.Drawing.Size(150, 54);
            this.lblCurrentDatetime.TabIndex = 16;
            this.lblCurrentDatetime.Text = "-";
            this.lblCurrentDatetime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Gray;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.Location = new System.Drawing.Point(888, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(56, 54);
            this.btnSettings.TabIndex = 15;
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(634, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "ระบบบริการจัดการโรงเชือด v.20.0722.01";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnReceiveSwine);
            this.flowLayoutPanel1.Controls.Add(this.btnReceiveCarcass);
            this.flowLayoutPanel1.Controls.Add(this.btnReceiveHead);
            this.flowLayoutPanel1.Controls.Add(this.btnReceiveByProductWhite);
            this.flowLayoutPanel1.Controls.Add(this.btnReceiveByProductRed);
            this.flowLayoutPanel1.Controls.Add(this.btnReceivePart);
            this.flowLayoutPanel1.Controls.Add(this.btnConfirmStock);
            this.flowLayoutPanel1.Controls.Add(this.btnReturn);
            this.flowLayoutPanel1.Controls.Add(this.btnReceiveSpecial);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 54);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(30);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1024, 352);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.Click += new System.EventHandler(this.btnIssuePart_Click);
            // 
            // btnReceiveSwine
            // 
            this.btnReceiveSwine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReceiveSwine.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveSwine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveSwine.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReceiveSwine.ForeColor = System.Drawing.Color.White;
            this.btnReceiveSwine.Location = new System.Drawing.Point(33, 33);
            this.btnReceiveSwine.Name = "btnReceiveSwine";
            this.btnReceiveSwine.Size = new System.Drawing.Size(285, 89);
            this.btnReceiveSwine.TabIndex = 8;
            this.btnReceiveSwine.Text = "รับหมูเป็น";
            this.btnReceiveSwine.UseVisualStyleBackColor = false;
            this.btnReceiveSwine.Click += new System.EventHandler(this.btnReceiveSwine_Click);
            // 
            // btnReceiveCarcass
            // 
            this.btnReceiveCarcass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReceiveCarcass.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveCarcass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveCarcass.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReceiveCarcass.ForeColor = System.Drawing.Color.White;
            this.btnReceiveCarcass.Location = new System.Drawing.Point(324, 33);
            this.btnReceiveCarcass.Name = "btnReceiveCarcass";
            this.btnReceiveCarcass.Size = new System.Drawing.Size(285, 89);
            this.btnReceiveCarcass.TabIndex = 9;
            this.btnReceiveCarcass.Text = "รับหมูซีก";
            this.btnReceiveCarcass.UseVisualStyleBackColor = false;
            this.btnReceiveCarcass.Click += new System.EventHandler(this.btnReceiveCarcass_Click);
            // 
            // btnReceiveHead
            // 
            this.btnReceiveHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReceiveHead.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveHead.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReceiveHead.ForeColor = System.Drawing.Color.White;
            this.btnReceiveHead.Location = new System.Drawing.Point(615, 33);
            this.btnReceiveHead.Name = "btnReceiveHead";
            this.btnReceiveHead.Size = new System.Drawing.Size(285, 89);
            this.btnReceiveHead.TabIndex = 18;
            this.btnReceiveHead.Text = "รับหัว";
            this.btnReceiveHead.UseVisualStyleBackColor = false;
            this.btnReceiveHead.Click += new System.EventHandler(this.btnReceiveHead_Click);
            // 
            // btnReceiveByProductWhite
            // 
            this.btnReceiveByProductWhite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReceiveByProductWhite.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveByProductWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveByProductWhite.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReceiveByProductWhite.ForeColor = System.Drawing.Color.White;
            this.btnReceiveByProductWhite.Location = new System.Drawing.Point(33, 128);
            this.btnReceiveByProductWhite.Name = "btnReceiveByProductWhite";
            this.btnReceiveByProductWhite.Size = new System.Drawing.Size(285, 89);
            this.btnReceiveByProductWhite.TabIndex = 10;
            this.btnReceiveByProductWhite.Text = "รับเครื่องในขาว";
            this.btnReceiveByProductWhite.UseVisualStyleBackColor = false;
            this.btnReceiveByProductWhite.Click += new System.EventHandler(this.btnReceiveByProductWhite_Click);
            // 
            // btnReceiveByProductRed
            // 
            this.btnReceiveByProductRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReceiveByProductRed.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveByProductRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveByProductRed.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReceiveByProductRed.ForeColor = System.Drawing.Color.White;
            this.btnReceiveByProductRed.Location = new System.Drawing.Point(324, 128);
            this.btnReceiveByProductRed.Name = "btnReceiveByProductRed";
            this.btnReceiveByProductRed.Size = new System.Drawing.Size(285, 89);
            this.btnReceiveByProductRed.TabIndex = 11;
            this.btnReceiveByProductRed.Text = "รับเครื่องในแดง";
            this.btnReceiveByProductRed.UseVisualStyleBackColor = false;
            this.btnReceiveByProductRed.Click += new System.EventHandler(this.btnReceiveByProductRed_Click);
            // 
            // btnReceivePart
            // 
            this.btnReceivePart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReceivePart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceivePart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceivePart.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReceivePart.ForeColor = System.Drawing.Color.White;
            this.btnReceivePart.Location = new System.Drawing.Point(615, 128);
            this.btnReceivePart.Name = "btnReceivePart";
            this.btnReceivePart.Size = new System.Drawing.Size(285, 89);
            this.btnReceivePart.TabIndex = 14;
            this.btnReceivePart.Text = "รับผลได้ชิ้นส่วน";
            this.btnReceivePart.UseVisualStyleBackColor = false;
            this.btnReceivePart.Click += new System.EventHandler(this.btnReceivePart_Click);
            // 
            // btnConfirmStock
            // 
            this.btnConfirmStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnConfirmStock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnConfirmStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmStock.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnConfirmStock.ForeColor = System.Drawing.Color.White;
            this.btnConfirmStock.Location = new System.Drawing.Point(33, 223);
            this.btnConfirmStock.Name = "btnConfirmStock";
            this.btnConfirmStock.Size = new System.Drawing.Size(285, 89);
            this.btnConfirmStock.TabIndex = 19;
            this.btnConfirmStock.Text = "ยืนยันเข้าคลัง";
            this.btnConfirmStock.UseVisualStyleBackColor = false;
            this.btnConfirmStock.Click += new System.EventHandler(this.BtnConfirmStock_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReturn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(324, 223);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(285, 89);
            this.btnReturn.TabIndex = 20;
            this.btnReturn.Text = "ส่งคืนชิ้นส่วน";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnReceiveSpecial
            // 
            this.btnReceiveSpecial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReceiveSpecial.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveSpecial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveSpecial.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReceiveSpecial.ForeColor = System.Drawing.Color.White;
            this.btnReceiveSpecial.Location = new System.Drawing.Point(615, 223);
            this.btnReceiveSpecial.Name = "btnReceiveSpecial";
            this.btnReceiveSpecial.Size = new System.Drawing.Size(285, 89);
            this.btnReceiveSpecial.TabIndex = 21;
            this.btnReceiveSpecial.Text = "รับผลได้สินค้าพิเศษ";
            this.btnReceiveSpecial.UseVisualStyleBackColor = false;
            this.btnReceiveSpecial.Click += new System.EventHandler(this.btnReceiveSpecial_Click);
            // 
            // btnIssueCarcass
            // 
            this.btnIssueCarcass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(66)))), ((int)(((byte)(54)))));
            this.btnIssueCarcass.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIssueCarcass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueCarcass.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnIssueCarcass.ForeColor = System.Drawing.Color.White;
            this.btnIssueCarcass.Location = new System.Drawing.Point(33, 33);
            this.btnIssueCarcass.Name = "btnIssueCarcass";
            this.btnIssueCarcass.Size = new System.Drawing.Size(285, 89);
            this.btnIssueCarcass.TabIndex = 12;
            this.btnIssueCarcass.Text = "เบิกหมูซีก/ชั่งขาย";
            this.btnIssueCarcass.UseVisualStyleBackColor = false;
            this.btnIssueCarcass.Click += new System.EventHandler(this.btnIssueCarcass_Click);
            // 
            // btnIssueByProduct
            // 
            this.btnIssueByProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(66)))), ((int)(((byte)(54)))));
            this.btnIssueByProduct.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIssueByProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueByProduct.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnIssueByProduct.ForeColor = System.Drawing.Color.White;
            this.btnIssueByProduct.Location = new System.Drawing.Point(615, 33);
            this.btnIssueByProduct.Name = "btnIssueByProduct";
            this.btnIssueByProduct.Size = new System.Drawing.Size(285, 89);
            this.btnIssueByProduct.TabIndex = 15;
            this.btnIssueByProduct.Text = "จ่ายหัว-เครื่องใน";
            this.btnIssueByProduct.UseVisualStyleBackColor = false;
            this.btnIssueByProduct.Click += new System.EventHandler(this.btnIssueByProduct_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnIssueCarcass);
            this.flowLayoutPanel2.Controls.Add(this.btnSalesCarcass);
            this.flowLayoutPanel2.Controls.Add(this.btnIssueByProduct);
            this.flowLayoutPanel2.Controls.Add(this.btnStockIssued);
            this.flowLayoutPanel2.Controls.Add(this.btnIssueProductForSales);
            this.flowLayoutPanel2.Controls.Add(this.btnIssueSpacialForSales);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 406);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(30);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1024, 295);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btnSalesCarcass
            // 
            this.btnSalesCarcass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(66)))), ((int)(((byte)(54)))));
            this.btnSalesCarcass.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalesCarcass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesCarcass.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnSalesCarcass.ForeColor = System.Drawing.Color.White;
            this.btnSalesCarcass.Location = new System.Drawing.Point(324, 33);
            this.btnSalesCarcass.Name = "btnSalesCarcass";
            this.btnSalesCarcass.Size = new System.Drawing.Size(285, 89);
            this.btnSalesCarcass.TabIndex = 21;
            this.btnSalesCarcass.Text = "ขายหมูซีก 1 ซีก";
            this.btnSalesCarcass.UseVisualStyleBackColor = false;
            this.btnSalesCarcass.Click += new System.EventHandler(this.btnSalesCarcass_Click);
            // 
            // btnStockIssued
            // 
            this.btnStockIssued.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(66)))), ((int)(((byte)(54)))));
            this.btnStockIssued.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStockIssued.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockIssued.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnStockIssued.ForeColor = System.Drawing.Color.White;
            this.btnStockIssued.Location = new System.Drawing.Point(33, 128);
            this.btnStockIssued.Name = "btnStockIssued";
            this.btnStockIssued.Size = new System.Drawing.Size(285, 89);
            this.btnStockIssued.TabIndex = 20;
            this.btnStockIssued.Text = "เบิกตัดแต่ง";
            this.btnStockIssued.UseVisualStyleBackColor = false;
            this.btnStockIssued.Click += new System.EventHandler(this.btnStockIssued_Click);
            // 
            // btnIssueProductForSales
            // 
            this.btnIssueProductForSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(66)))), ((int)(((byte)(54)))));
            this.btnIssueProductForSales.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIssueProductForSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueProductForSales.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnIssueProductForSales.ForeColor = System.Drawing.Color.White;
            this.btnIssueProductForSales.Location = new System.Drawing.Point(324, 128);
            this.btnIssueProductForSales.Name = "btnIssueProductForSales";
            this.btnIssueProductForSales.Size = new System.Drawing.Size(285, 89);
            this.btnIssueProductForSales.TabIndex = 18;
            this.btnIssueProductForSales.Text = "เบิกขายชิ้นส่วน";
            this.btnIssueProductForSales.UseVisualStyleBackColor = false;
            this.btnIssueProductForSales.Click += new System.EventHandler(this.BtnIssueProductForSales_Click);
            // 
            // btnIssueSpacialForSales
            // 
            this.btnIssueSpacialForSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(66)))), ((int)(((byte)(54)))));
            this.btnIssueSpacialForSales.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIssueSpacialForSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueSpacialForSales.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnIssueSpacialForSales.ForeColor = System.Drawing.Color.White;
            this.btnIssueSpacialForSales.Location = new System.Drawing.Point(615, 128);
            this.btnIssueSpacialForSales.Name = "btnIssueSpacialForSales";
            this.btnIssueSpacialForSales.Size = new System.Drawing.Size(285, 89);
            this.btnIssueSpacialForSales.TabIndex = 22;
            this.btnIssueSpacialForSales.Text = "ขายสินค้าพิเศษ";
            this.btnIssueSpacialForSales.UseVisualStyleBackColor = false;
            this.btnIssueSpacialForSales.Click += new System.EventHandler(this.btnIssueSpacialForSales_Click);
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelHeader;
            // 
            // Form_Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1024, 701);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Kanit", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Form_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Menu";
            this.panelHeader.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnReceiveSwine;
        private System.Windows.Forms.Button btnReceiveCarcass;
        private System.Windows.Forms.Button btnReceiveByProductWhite;
        private System.Windows.Forms.Button btnReceiveByProductRed;
        private System.Windows.Forms.Button btnIssueCarcass;
        private System.Windows.Forms.Button btnReceivePart;
        private System.Windows.Forms.Button btnIssueByProduct;
        private DragControl dragControl1;
        private System.Windows.Forms.Button btnReceiveHead;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnConfirmStock;
        private System.Windows.Forms.Button btnIssueProductForSales;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblCurrentDatetime;
        private System.Windows.Forms.Button btnStockIssued;
        private System.Windows.Forms.Button btnSalesCarcass;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnIssueSpacialForSales;
        private System.Windows.Forms.Button btnReceiveSpecial;
    }
}