namespace SlaughterHouseServer
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.plHeader = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.plMenu = new System.Windows.Forms.Panel();
            this.BtnInvoice = new System.Windows.Forms.Button();
            this.BtnPriceList = new System.Windows.Forms.Button();
            this.BtnProductionOrder = new System.Windows.Forms.Button();
            this.BtnOrder = new System.Windows.Forms.Button();
            this.BtnCarcass = new System.Windows.Forms.Button();
            this.BtnReceive = new System.Windows.Forms.Button();
            this.BtnUnit = new System.Windows.Forms.Button();
            this.BtnProductGroup = new System.Windows.Forms.Button();
            this.BtnProduct = new System.Windows.Forms.Button();
            this.BtnCustomer = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnFarm = new System.Windows.Forms.Button();
            this.plContainer = new System.Windows.Forms.Panel();
            this.dragControl1 = new DragControl();
            this.BtnReport = new System.Windows.Forms.Button();
            this.plHeader.SuspendLayout();
            this.plMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // plHeader
            // 
            this.plHeader.BackColor = System.Drawing.SystemColors.HotTrack;
            this.plHeader.Controls.Add(this.btnExit);
            this.plHeader.Controls.Add(this.label1);
            this.plHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.plHeader.Location = new System.Drawing.Point(0, 0);
            this.plHeader.Name = "plHeader";
            this.plHeader.Size = new System.Drawing.Size(1400, 54);
            this.plHeader.TabIndex = 8;
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
            this.btnExit.Location = new System.Drawing.Point(1324, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(76, 54);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "ระบบบริหารจัดการโรงชำแหละสุกร";
            // 
            // plMenu
            // 
            this.plMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.plMenu.Controls.Add(this.BtnReport);
            this.plMenu.Controls.Add(this.BtnInvoice);
            this.plMenu.Controls.Add(this.BtnPriceList);
            this.plMenu.Controls.Add(this.BtnProductionOrder);
            this.plMenu.Controls.Add(this.BtnOrder);
            this.plMenu.Controls.Add(this.BtnCarcass);
            this.plMenu.Controls.Add(this.BtnReceive);
            this.plMenu.Controls.Add(this.BtnUnit);
            this.plMenu.Controls.Add(this.BtnProductGroup);
            this.plMenu.Controls.Add(this.BtnProduct);
            this.plMenu.Controls.Add(this.BtnCustomer);
            this.plMenu.Controls.Add(this.button2);
            this.plMenu.Controls.Add(this.BtnFarm);
            this.plMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.plMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plMenu.Location = new System.Drawing.Point(0, 54);
            this.plMenu.Name = "plMenu";
            this.plMenu.Size = new System.Drawing.Size(162, 746);
            this.plMenu.TabIndex = 9;
            // 
            // BtnInvoice
            // 
            this.BtnInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnInvoice.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInvoice.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInvoice.ForeColor = System.Drawing.Color.White;
            this.BtnInvoice.Image = ((System.Drawing.Image)(resources.GetObject("BtnInvoice.Image")));
            this.BtnInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnInvoice.Location = new System.Drawing.Point(0, 600);
            this.BtnInvoice.Name = "BtnInvoice";
            this.BtnInvoice.Size = new System.Drawing.Size(162, 60);
            this.BtnInvoice.TabIndex = 25;
            this.BtnInvoice.Text = "ใบแจ้งหนี้";
            this.BtnInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnInvoice.UseVisualStyleBackColor = false;
            // 
            // BtnPriceList
            // 
            this.BtnPriceList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnPriceList.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnPriceList.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnPriceList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnPriceList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnPriceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPriceList.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPriceList.ForeColor = System.Drawing.Color.White;
            this.BtnPriceList.Image = ((System.Drawing.Image)(resources.GetObject("BtnPriceList.Image")));
            this.BtnPriceList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPriceList.Location = new System.Drawing.Point(0, 540);
            this.BtnPriceList.Name = "BtnPriceList";
            this.BtnPriceList.Size = new System.Drawing.Size(162, 60);
            this.BtnPriceList.TabIndex = 24;
            this.BtnPriceList.Text = "ราคาประกาศ";
            this.BtnPriceList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPriceList.UseVisualStyleBackColor = false;
            // 
            // BtnProductionOrder
            // 
            this.BtnProductionOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnProductionOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnProductionOrder.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnProductionOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnProductionOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnProductionOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProductionOrder.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProductionOrder.ForeColor = System.Drawing.Color.White;
            this.BtnProductionOrder.Image = ((System.Drawing.Image)(resources.GetObject("BtnProductionOrder.Image")));
            this.BtnProductionOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProductionOrder.Location = new System.Drawing.Point(0, 480);
            this.BtnProductionOrder.Name = "BtnProductionOrder";
            this.BtnProductionOrder.Size = new System.Drawing.Size(162, 60);
            this.BtnProductionOrder.TabIndex = 23;
            this.BtnProductionOrder.Text = "ใบสั่งผลิต";
            this.BtnProductionOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProductionOrder.UseVisualStyleBackColor = false;
            // 
            // BtnOrder
            // 
            this.BtnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnOrder.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOrder.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOrder.ForeColor = System.Drawing.Color.White;
            this.BtnOrder.Image = ((System.Drawing.Image)(resources.GetObject("BtnOrder.Image")));
            this.BtnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOrder.Location = new System.Drawing.Point(0, 420);
            this.BtnOrder.Name = "BtnOrder";
            this.BtnOrder.Size = new System.Drawing.Size(162, 60);
            this.BtnOrder.TabIndex = 22;
            this.BtnOrder.Text = "ใบสั่งขาย";
            this.BtnOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOrder.UseVisualStyleBackColor = false;
            // 
            // BtnCarcass
            // 
            this.BtnCarcass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnCarcass.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCarcass.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnCarcass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnCarcass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnCarcass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCarcass.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCarcass.ForeColor = System.Drawing.Color.White;
            this.BtnCarcass.Image = ((System.Drawing.Image)(resources.GetObject("BtnCarcass.Image")));
            this.BtnCarcass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCarcass.Location = new System.Drawing.Point(0, 360);
            this.BtnCarcass.Name = "BtnCarcass";
            this.BtnCarcass.Size = new System.Drawing.Size(162, 60);
            this.BtnCarcass.TabIndex = 21;
            this.BtnCarcass.Text = "รับหมูซีก";
            this.BtnCarcass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCarcass.UseVisualStyleBackColor = false;
            // 
            // BtnReceive
            // 
            this.BtnReceive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnReceive.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnReceive.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnReceive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnReceive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReceive.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReceive.ForeColor = System.Drawing.Color.White;
            this.BtnReceive.Image = ((System.Drawing.Image)(resources.GetObject("BtnReceive.Image")));
            this.BtnReceive.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReceive.Location = new System.Drawing.Point(0, 300);
            this.BtnReceive.Name = "BtnReceive";
            this.BtnReceive.Size = new System.Drawing.Size(162, 60);
            this.BtnReceive.TabIndex = 18;
            this.BtnReceive.Text = "รับหมูเป็น";
            this.BtnReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReceive.UseVisualStyleBackColor = false;
            // 
            // BtnUnit
            // 
            this.BtnUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnUnit.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnUnit.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnUnit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnUnit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUnit.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUnit.ForeColor = System.Drawing.Color.White;
            this.BtnUnit.Image = ((System.Drawing.Image)(resources.GetObject("BtnUnit.Image")));
            this.BtnUnit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUnit.Location = new System.Drawing.Point(0, 240);
            this.BtnUnit.Name = "BtnUnit";
            this.BtnUnit.Size = new System.Drawing.Size(162, 60);
            this.BtnUnit.TabIndex = 17;
            this.BtnUnit.Text = "หน่วยสินค้า";
            this.BtnUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUnit.UseVisualStyleBackColor = false;
            // 
            // BtnProductGroup
            // 
            this.BtnProductGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnProductGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnProductGroup.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnProductGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnProductGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnProductGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProductGroup.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProductGroup.ForeColor = System.Drawing.Color.White;
            this.BtnProductGroup.Image = ((System.Drawing.Image)(resources.GetObject("BtnProductGroup.Image")));
            this.BtnProductGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProductGroup.Location = new System.Drawing.Point(0, 180);
            this.BtnProductGroup.Name = "BtnProductGroup";
            this.BtnProductGroup.Size = new System.Drawing.Size(162, 60);
            this.BtnProductGroup.TabIndex = 16;
            this.BtnProductGroup.Text = "กลุ่มสินค้า";
            this.BtnProductGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProductGroup.UseVisualStyleBackColor = false;
            // 
            // BtnProduct
            // 
            this.BtnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnProduct.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProduct.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProduct.ForeColor = System.Drawing.Color.White;
            this.BtnProduct.Image = ((System.Drawing.Image)(resources.GetObject("BtnProduct.Image")));
            this.BtnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProduct.Location = new System.Drawing.Point(0, 120);
            this.BtnProduct.Name = "BtnProduct";
            this.BtnProduct.Size = new System.Drawing.Size(162, 60);
            this.BtnProduct.TabIndex = 15;
            this.BtnProduct.Text = "สินค้า";
            this.BtnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProduct.UseVisualStyleBackColor = false;
            // 
            // BtnCustomer
            // 
            this.BtnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCustomer.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCustomer.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCustomer.ForeColor = System.Drawing.Color.White;
            this.BtnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("BtnCustomer.Image")));
            this.BtnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCustomer.Location = new System.Drawing.Point(0, 60);
            this.BtnCustomer.Name = "BtnCustomer";
            this.BtnCustomer.Size = new System.Drawing.Size(162, 60);
            this.BtnCustomer.TabIndex = 14;
            this.BtnCustomer.Text = "ลูกค้า";
            this.BtnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCustomer.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 713);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 33);
            this.button2.TabIndex = 13;
            this.button2.Text = "©2019 NAV Project";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // BtnFarm
            // 
            this.BtnFarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnFarm.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnFarm.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnFarm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnFarm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnFarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFarm.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFarm.ForeColor = System.Drawing.Color.White;
            this.BtnFarm.Image = ((System.Drawing.Image)(resources.GetObject("BtnFarm.Image")));
            this.BtnFarm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFarm.Location = new System.Drawing.Point(0, 0);
            this.BtnFarm.Name = "BtnFarm";
            this.BtnFarm.Size = new System.Drawing.Size(162, 60);
            this.BtnFarm.TabIndex = 11;
            this.BtnFarm.Text = "ฟาร์ม";
            this.BtnFarm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnFarm.UseVisualStyleBackColor = false;
            // 
            // plContainer
            // 
            this.plContainer.AutoScroll = true;
            this.plContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContainer.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.plContainer.Location = new System.Drawing.Point(162, 54);
            this.plContainer.Name = "plContainer";
            this.plContainer.Size = new System.Drawing.Size(1238, 746);
            this.plContainer.TabIndex = 10;
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.plHeader;
            // 
            // BtnReport
            // 
            this.BtnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReport.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReport.ForeColor = System.Drawing.Color.White;
            this.BtnReport.Image = ((System.Drawing.Image)(resources.GetObject("BtnReport.Image")));
            this.BtnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReport.Location = new System.Drawing.Point(0, 660);
            this.BtnReport.Name = "BtnReport";
            this.BtnReport.Size = new System.Drawing.Size(162, 60);
            this.BtnReport.TabIndex = 26;
            this.BtnReport.Text = "รายงาน";
            this.BtnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReport.UseVisualStyleBackColor = false;
            // 
            // Form_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.plContainer);
            this.Controls.Add(this.plMenu);
            this.Controls.Add(this.plHeader);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.plHeader.ResumeLayout(false);
            this.plHeader.PerformLayout();
            this.plMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DragControl dragControl1;
        private System.Windows.Forms.Panel plHeader;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plMenu;
        private System.Windows.Forms.Button BtnReceive;
        private System.Windows.Forms.Button BtnUnit;
        private System.Windows.Forms.Button BtnProductGroup;
        private System.Windows.Forms.Button BtnProduct;
        private System.Windows.Forms.Button BtnCustomer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnFarm;
        private System.Windows.Forms.Panel plContainer;
        private System.Windows.Forms.Button BtnProductionOrder;
        private System.Windows.Forms.Button BtnOrder;
        private System.Windows.Forms.Button BtnCarcass;
        private System.Windows.Forms.Button BtnPriceList;
        private System.Windows.Forms.Button BtnInvoice;
        private System.Windows.Forms.Button BtnReport;
    }
}