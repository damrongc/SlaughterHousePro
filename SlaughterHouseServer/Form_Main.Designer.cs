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
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.plMenu = new System.Windows.Forms.Panel();
            this.BtnClosePeriod = new System.Windows.Forms.Button();
            this.BtnReport = new System.Windows.Forms.Button();
            this.BtnInvoice = new System.Windows.Forms.Button();
            this.BtnProductionOrder = new System.Windows.Forms.Button();
            this.BtnOrder = new System.Windows.Forms.Button();
            this.BtnReceive = new System.Windows.Forms.Button();
            this.BtnMaster = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.plContainer = new System.Windows.Forms.Panel();
            this.dragControl1 = new DragControl();
            this.plHeader.SuspendLayout();
            this.plMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // plHeader
            // 
            this.plHeader.BackColor = System.Drawing.SystemColors.HotTrack;
            this.plHeader.Controls.Add(this.btnMinimize);
            this.plHeader.Controls.Add(this.btnExit);
            this.plHeader.Controls.Add(this.label1);
            this.plHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.plHeader.Location = new System.Drawing.Point(0, 0);
            this.plHeader.Name = "plHeader";
            this.plHeader.Size = new System.Drawing.Size(1400, 54);
            this.plHeader.TabIndex = 8;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(1276, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(48, 54);
            this.btnMinimize.TabIndex = 14;
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
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
            this.label1.Size = new System.Drawing.Size(576, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "ระบบบริหารจัดการโรงชำแหละสุกร v.20.06.22.001";
            // 
            // plMenu
            // 
            this.plMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.plMenu.Controls.Add(this.BtnClosePeriod);
            this.plMenu.Controls.Add(this.BtnReport);
            this.plMenu.Controls.Add(this.BtnInvoice);
            this.plMenu.Controls.Add(this.BtnProductionOrder);
            this.plMenu.Controls.Add(this.BtnOrder);
            this.plMenu.Controls.Add(this.BtnReceive);
            this.plMenu.Controls.Add(this.BtnMaster);
            this.plMenu.Controls.Add(this.button2);
            this.plMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.plMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plMenu.Location = new System.Drawing.Point(0, 54);
            this.plMenu.Name = "plMenu";
            this.plMenu.Size = new System.Drawing.Size(147, 846);
            this.plMenu.TabIndex = 9;
            // 
            // BtnClosePeriod
            // 
            this.BtnClosePeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnClosePeriod.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnClosePeriod.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnClosePeriod.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnClosePeriod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnClosePeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClosePeriod.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.BtnClosePeriod.ForeColor = System.Drawing.Color.White;
            this.BtnClosePeriod.Image = ((System.Drawing.Image)(resources.GetObject("BtnClosePeriod.Image")));
            this.BtnClosePeriod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClosePeriod.Location = new System.Drawing.Point(0, 300);
            this.BtnClosePeriod.Name = "BtnClosePeriod";
            this.BtnClosePeriod.Size = new System.Drawing.Size(147, 50);
            this.BtnClosePeriod.TabIndex = 34;
            this.BtnClosePeriod.Text = "ปิดวัน";
            this.BtnClosePeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClosePeriod.UseVisualStyleBackColor = false;
            // 
            // BtnReport
            // 
            this.BtnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnReport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReport.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.BtnReport.ForeColor = System.Drawing.Color.White;
            this.BtnReport.Image = ((System.Drawing.Image)(resources.GetObject("BtnReport.Image")));
            this.BtnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReport.Location = new System.Drawing.Point(0, 250);
            this.BtnReport.Name = "BtnReport";
            this.BtnReport.Size = new System.Drawing.Size(147, 50);
            this.BtnReport.TabIndex = 33;
            this.BtnReport.Text = "รายงาน";
            this.BtnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReport.UseVisualStyleBackColor = false;
            // 
            // BtnInvoice
            // 
            this.BtnInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnInvoice.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInvoice.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.BtnInvoice.ForeColor = System.Drawing.Color.White;
            this.BtnInvoice.Image = ((System.Drawing.Image)(resources.GetObject("BtnInvoice.Image")));
            this.BtnInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnInvoice.Location = new System.Drawing.Point(0, 200);
            this.BtnInvoice.Name = "BtnInvoice";
            this.BtnInvoice.Size = new System.Drawing.Size(147, 50);
            this.BtnInvoice.TabIndex = 32;
            this.BtnInvoice.Text = "ใบแจ้งหนี้";
            this.BtnInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnInvoice.UseVisualStyleBackColor = false;
            // 
            // BtnProductionOrder
            // 
            this.BtnProductionOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnProductionOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnProductionOrder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnProductionOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnProductionOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnProductionOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProductionOrder.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.BtnProductionOrder.ForeColor = System.Drawing.Color.White;
            this.BtnProductionOrder.Image = ((System.Drawing.Image)(resources.GetObject("BtnProductionOrder.Image")));
            this.BtnProductionOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProductionOrder.Location = new System.Drawing.Point(0, 150);
            this.BtnProductionOrder.Name = "BtnProductionOrder";
            this.BtnProductionOrder.Size = new System.Drawing.Size(147, 50);
            this.BtnProductionOrder.TabIndex = 31;
            this.BtnProductionOrder.Text = "ใบสั่งผลิต";
            this.BtnProductionOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProductionOrder.UseVisualStyleBackColor = false;
            this.BtnProductionOrder.Visible = false;
            // 
            // BtnOrder
            // 
            this.BtnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnOrder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOrder.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.BtnOrder.ForeColor = System.Drawing.Color.White;
            this.BtnOrder.Image = ((System.Drawing.Image)(resources.GetObject("BtnOrder.Image")));
            this.BtnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOrder.Location = new System.Drawing.Point(0, 100);
            this.BtnOrder.Name = "BtnOrder";
            this.BtnOrder.Size = new System.Drawing.Size(147, 50);
            this.BtnOrder.TabIndex = 30;
            this.BtnOrder.Text = "ใบสั่งขาย";
            this.BtnOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOrder.UseVisualStyleBackColor = false;
            // 
            // BtnReceive
            // 
            this.BtnReceive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnReceive.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnReceive.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnReceive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnReceive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReceive.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.BtnReceive.ForeColor = System.Drawing.Color.White;
            this.BtnReceive.Image = ((System.Drawing.Image)(resources.GetObject("BtnReceive.Image")));
            this.BtnReceive.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReceive.Location = new System.Drawing.Point(0, 50);
            this.BtnReceive.Name = "BtnReceive";
            this.BtnReceive.Size = new System.Drawing.Size(147, 50);
            this.BtnReceive.TabIndex = 28;
            this.BtnReceive.Text = "รับหมูเป็น";
            this.BtnReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReceive.UseVisualStyleBackColor = false;
            // 
            // BtnMaster
            // 
            this.BtnMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(42)))));
            this.BtnMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnMaster.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnMaster.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnMaster.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMaster.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.BtnMaster.ForeColor = System.Drawing.Color.White;
            this.BtnMaster.Image = ((System.Drawing.Image)(resources.GetObject("BtnMaster.Image")));
            this.BtnMaster.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMaster.Location = new System.Drawing.Point(0, 0);
            this.BtnMaster.Name = "BtnMaster";
            this.BtnMaster.Size = new System.Drawing.Size(147, 50);
            this.BtnMaster.TabIndex = 27;
            this.BtnMaster.Text = "ข้อมูลหลัก";
            this.BtnMaster.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMaster.UseVisualStyleBackColor = false;
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
            this.button2.Location = new System.Drawing.Point(0, 813);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 33);
            this.button2.TabIndex = 13;
            this.button2.Text = "©2019 NAV Project";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // plContainer
            // 
            this.plContainer.AutoScroll = true;
            this.plContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContainer.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.plContainer.Location = new System.Drawing.Point(147, 54);
            this.plContainer.Name = "plContainer";
            this.plContainer.Size = new System.Drawing.Size(1253, 846);
            this.plContainer.TabIndex = 10;
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.plHeader;
            // 
            // Form_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1400, 900);
            this.Controls.Add(this.plContainer);
            this.Controls.Add(this.plMenu);
            this.Controls.Add(this.plHeader);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel plContainer;
        private System.Windows.Forms.Button BtnMaster;
        private System.Windows.Forms.Button BtnReport;
        private System.Windows.Forms.Button BtnInvoice;
        private System.Windows.Forms.Button BtnProductionOrder;
        private System.Windows.Forms.Button BtnOrder;
        private System.Windows.Forms.Button BtnReceive;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button BtnClosePeriod;
    }
}