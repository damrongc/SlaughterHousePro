﻿namespace SlaughterHouseServer
{
    partial class Form_Report
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.btnReportDailySales = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnReportSoWithInv = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btnReportStockMovement = new System.Windows.Forms.Button();
            this.btnStockBalance = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.btnReportDailySales);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.btnReportSoWithInv);
            this.groupBox1.Controls.Add(this.btn1);
            this.groupBox1.Controls.Add(this.btnReportStockMovement);
            this.groupBox1.Controls.Add(this.btnStockBalance);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1256, 673);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายงาน";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button7.Location = new System.Drawing.Point(318, 589);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(666, 59);
            this.button7.TabIndex = 6;
            this.button7.Text = "report xxx";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // btnReportDailySales
            // 
            this.btnReportDailySales.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnReportDailySales.Location = new System.Drawing.Point(318, 62);
            this.btnReportDailySales.Name = "btnReportDailySales";
            this.btnReportDailySales.Size = new System.Drawing.Size(666, 59);
            this.btnReportDailySales.TabIndex = 0;
            this.btnReportDailySales.Text = "รายงานรายวันขาย";
            this.btnReportDailySales.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button5.Location = new System.Drawing.Point(318, 501);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(666, 59);
            this.button5.TabIndex = 5;
            this.button5.Text = "report xxx";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // btnReportSoWithInv
            // 
            this.btnReportSoWithInv.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnReportSoWithInv.Location = new System.Drawing.Point(318, 150);
            this.btnReportSoWithInv.Name = "btnReportSoWithInv";
            this.btnReportSoWithInv.Size = new System.Drawing.Size(666, 59);
            this.btnReportSoWithInv.TabIndex = 2;
            this.btnReportSoWithInv.Text = "รายงานเปรียบเทียบใบสั่งขายกับใบแจ้งหนี้";
            this.btnReportSoWithInv.UseVisualStyleBackColor = false;
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn1.Location = new System.Drawing.Point(318, 414);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(666, 59);
            this.btn1.TabIndex = 3;
            this.btn1.Text = "report xxx";
            this.btn1.UseVisualStyleBackColor = false;
            // 
            // btnReportStockMovement
            // 
            this.btnReportStockMovement.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnReportStockMovement.Location = new System.Drawing.Point(318, 237);
            this.btnReportStockMovement.Name = "btnReportStockMovement";
            this.btnReportStockMovement.Size = new System.Drawing.Size(666, 59);
            this.btnReportStockMovement.TabIndex = 4;
            this.btnReportStockMovement.Text = "รายงานเคลื่อนไหวสต็อก";
            this.btnReportStockMovement.UseVisualStyleBackColor = false;
            // 
            // btnStockBalance
            // 
            this.btnStockBalance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStockBalance.Location = new System.Drawing.Point(318, 326);
            this.btnStockBalance.Name = "btnStockBalance";
            this.btnStockBalance.Size = new System.Drawing.Size(666, 59);
            this.btnStockBalance.TabIndex = 1;
            this.btnStockBalance.Text = "รายงานสต็อกคงเหลือ";
            this.btnStockBalance.UseVisualStyleBackColor = false;
            // 
            // Form_Report
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1276, 693);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Kanit", 15.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Report";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form_Farm";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnReportDailySales;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnReportSoWithInv;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btnReportStockMovement;
        private System.Windows.Forms.Button btnStockBalance;
    }
}