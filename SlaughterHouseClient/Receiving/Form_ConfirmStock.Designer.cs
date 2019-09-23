namespace SlaughterHouseClient.Receiving
{
    partial class Form_ConfirmStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ConfirmStock));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblCurrentDatetime = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dragControl1 = new DragControl();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBarcodeNo = new System.Windows.Forms.TextBox();
            this.lblStockWeightCaption = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblStockWgh = new System.Windows.Forms.Label();
            this.lblStockQty = new System.Windows.Forms.Label();
            this.lblLastProduct = new System.Windows.Forms.Label();
            this.lblLastLotNo = new System.Windows.Forms.Label();
            this.lblLastBarcode = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
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
            this.lblCaption.Text = "รับเข้าคลัง";
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
            this.lblWeight.Size = new System.Drawing.Size(553, 194);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kanit", 16F);
            this.label5.Location = new System.Drawing.Point(12, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 33);
            this.label5.TabIndex = 8;
            this.label5.Text = "Lot No";
            // 
            // lblLotNo
            // 
            this.lblLotNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLotNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLotNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLotNo.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLotNo.ForeColor = System.Drawing.Color.Black;
            this.lblLotNo.Location = new System.Drawing.Point(18, 166);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(283, 43);
            this.lblLotNo.TabIndex = 9;
            // 
            // lblProduct
            // 
            this.lblProduct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProduct.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblProduct.ForeColor = System.Drawing.Color.Black;
            this.lblProduct.Location = new System.Drawing.Point(19, 90);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(435, 43);
            this.lblProduct.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kanit", 16F);
            this.label8.Location = new System.Drawing.Point(13, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 33);
            this.label8.TabIndex = 10;
            this.label8.Text = "สินค้า";
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(19, 323);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(878, 310);
            this.flowLayoutPanel1.TabIndex = 51;
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnDown.ForeColor = System.Drawing.Color.White;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(903, 563);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(109, 70);
            this.btnDown.TabIndex = 54;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Font = new System.Drawing.Font("Kanit", 18F);
            this.btnUp.ForeColor = System.Drawing.Color.White;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(903, 323);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(109, 70);
            this.btnUp.TabIndex = 55;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kanit", 16F);
            this.label2.Location = new System.Drawing.Point(12, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 33);
            this.label2.TabIndex = 52;
            this.label2.Text = "คลัง";
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelHeader;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Kanit", 16F);
            this.label6.Location = new System.Drawing.Point(13, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 33);
            this.label6.TabIndex = 61;
            this.label6.Text = "บาร์โค็ด";
            // 
            // txtBarcodeNo
            // 
            this.txtBarcodeNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.txtBarcodeNo.Font = new System.Drawing.Font("Kanit", 16F);
            this.txtBarcodeNo.ForeColor = System.Drawing.Color.White;
            this.txtBarcodeNo.Location = new System.Drawing.Point(18, 245);
            this.txtBarcodeNo.Name = "txtBarcodeNo";
            this.txtBarcodeNo.Size = new System.Drawing.Size(435, 39);
            this.txtBarcodeNo.TabIndex = 62;
            // 
            // lblStockWeightCaption
            // 
            this.lblStockWeightCaption.AutoSize = true;
            this.lblStockWeightCaption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStockWeightCaption.Font = new System.Drawing.Font("Kanit", 12F);
            this.lblStockWeightCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblStockWeightCaption.Location = new System.Drawing.Point(639, 636);
            this.lblStockWeightCaption.Name = "lblStockWeightCaption";
            this.lblStockWeightCaption.Size = new System.Drawing.Size(83, 24);
            this.lblStockWeightCaption.TabIndex = 65;
            this.lblStockWeightCaption.Text = "น้ำหนักรวม";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("Kanit", 12F);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label20.Location = new System.Drawing.Point(487, 636);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 24);
            this.label20.TabIndex = 63;
            this.label20.Text = "จำนวนรวม";
            // 
            // lblStockWgh
            // 
            this.lblStockWgh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStockWgh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStockWgh.Font = new System.Drawing.Font("Kanit", 40F);
            this.lblStockWgh.ForeColor = System.Drawing.Color.Black;
            this.lblStockWgh.Location = new System.Drawing.Point(643, 636);
            this.lblStockWgh.Name = "lblStockWgh";
            this.lblStockWgh.Size = new System.Drawing.Size(254, 75);
            this.lblStockWgh.TabIndex = 66;
            this.lblStockWgh.Text = "0.00";
            this.lblStockWgh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStockQty
            // 
            this.lblStockQty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStockQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStockQty.Font = new System.Drawing.Font("Kanit", 40F);
            this.lblStockQty.ForeColor = System.Drawing.Color.Black;
            this.lblStockQty.Location = new System.Drawing.Point(489, 636);
            this.lblStockQty.Name = "lblStockQty";
            this.lblStockQty.Size = new System.Drawing.Size(148, 75);
            this.lblStockQty.TabIndex = 64;
            this.lblStockQty.Text = "0";
            this.lblStockQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastProduct
            // 
            this.lblLastProduct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLastProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLastProduct.Font = new System.Drawing.Font("Kanit", 14F);
            this.lblLastProduct.ForeColor = System.Drawing.Color.Black;
            this.lblLastProduct.Location = new System.Drawing.Point(19, 636);
            this.lblLastProduct.Name = "lblLastProduct";
            this.lblLastProduct.Size = new System.Drawing.Size(462, 34);
            this.lblLastProduct.TabIndex = 67;
            this.lblLastProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastLotNo
            // 
            this.lblLastLotNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLastLotNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLastLotNo.Font = new System.Drawing.Font("Kanit", 14F);
            this.lblLastLotNo.ForeColor = System.Drawing.Color.Black;
            this.lblLastLotNo.Location = new System.Drawing.Point(21, 679);
            this.lblLastLotNo.Name = "lblLastLotNo";
            this.lblLastLotNo.Size = new System.Drawing.Size(185, 34);
            this.lblLastLotNo.TabIndex = 68;
            this.lblLastLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastBarcode
            // 
            this.lblLastBarcode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLastBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLastBarcode.Font = new System.Drawing.Font("Kanit", 14F);
            this.lblLastBarcode.ForeColor = System.Drawing.Color.Black;
            this.lblLastBarcode.Location = new System.Drawing.Point(212, 679);
            this.lblLastBarcode.Name = "lblLastBarcode";
            this.lblLastBarcode.Size = new System.Drawing.Size(271, 34);
            this.lblLastBarcode.TabIndex = 69;
            this.lblLastBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Kanit", 12F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label9.Location = new System.Drawing.Point(20, 636);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 24);
            this.label9.TabIndex = 70;
            this.label9.Text = "สินค้า";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Kanit", 12F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label10.Location = new System.Drawing.Point(20, 674);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 24);
            this.label10.TabIndex = 71;
            this.label10.Text = "Lot No";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Kanit", 12F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label11.Location = new System.Drawing.Point(213, 679);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 24);
            this.label11.TabIndex = 72;
            this.label11.Text = "บาร์โค็ด";
            // 
            // Form_ConfirmStock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblLastBarcode);
            this.Controls.Add(this.lblLastLotNo);
            this.Controls.Add(this.lblLastProduct);
            this.Controls.Add(this.lblStockWeightCaption);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblStockWgh);
            this.Controls.Add(this.lblStockQty);
            this.Controls.Add(this.txtBarcodeNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblLotNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Kanit", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ConfirmStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รับหมูเป็น";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panelHeader.ResumeLayout(false);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCurrentDatetime;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBarcodeNo;
        private System.Windows.Forms.Label lblStockWeightCaption;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblStockWgh;
        private System.Windows.Forms.Label lblStockQty;
        private System.Windows.Forms.Label lblLastProduct;
        private System.Windows.Forms.Label lblLastLotNo;
        private System.Windows.Forms.Label lblLastBarcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

