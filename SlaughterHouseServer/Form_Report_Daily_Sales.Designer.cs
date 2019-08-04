namespace SlaughterHouseServer
{
    partial class Form_Report_Daily_Sales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Report_Daily_Sales));
            this.groupBoxReportName = new System.Windows.Forms.GroupBox();
            this.BtnShowReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpInvoiceDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpInvoiceDateStr = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBoxReportName.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxReportName
            // 
            this.groupBoxReportName.Controls.Add(this.BtnShowReport);
            this.groupBoxReportName.Controls.Add(this.label1);
            this.groupBoxReportName.Controls.Add(this.dtpInvoiceDateEnd);
            this.groupBoxReportName.Controls.Add(this.dtpInvoiceDateStr);
            this.groupBoxReportName.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxReportName.Location = new System.Drawing.Point(0, 0);
            this.groupBoxReportName.Name = "groupBoxReportName";
            this.groupBoxReportName.Size = new System.Drawing.Size(1184, 89);
            this.groupBoxReportName.TabIndex = 0;
            this.groupBoxReportName.TabStop = false;
            this.groupBoxReportName.Text = "รายวันขาย";
            // 
            // BtnShowReport
            // 
            this.BtnShowReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnShowReport.FlatAppearance.BorderSize = 0;
            this.BtnShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShowReport.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowReport.ForeColor = System.Drawing.Color.White;
            this.BtnShowReport.Image = ((System.Drawing.Image)(resources.GetObject("BtnShowReport.Image")));
            this.BtnShowReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnShowReport.Location = new System.Drawing.Point(428, 35);
            this.BtnShowReport.Name = "BtnShowReport";
            this.BtnShowReport.Size = new System.Drawing.Size(157, 36);
            this.BtnShowReport.TabIndex = 14;
            this.BtnShowReport.Text = "แสดงรายงาน";
            this.BtnShowReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnShowReport.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = " - ";
            // 
            // dtpInvoiceDateEnd
            // 
            this.dtpInvoiceDateEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpInvoiceDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDateEnd.Location = new System.Drawing.Point(232, 35);
            this.dtpInvoiceDateEnd.Name = "dtpInvoiceDateEnd";
            this.dtpInvoiceDateEnd.Size = new System.Drawing.Size(177, 36);
            this.dtpInvoiceDateEnd.TabIndex = 12;
            // 
            // dtpInvoiceDateStr
            // 
            this.dtpInvoiceDateStr.CustomFormat = "dd/MM/yyyy";
            this.dtpInvoiceDateStr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDateStr.Location = new System.Drawing.Point(12, 35);
            this.dtpInvoiceDateStr.Name = "dtpInvoiceDateStr";
            this.dtpInvoiceDateStr.Size = new System.Drawing.Size(177, 36);
            this.dtpInvoiceDateStr.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rptViewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 572);
            this.panel1.TabIndex = 1;
            // 
            // rptViewer
            // 
            this.rptViewer.ActiveViewIndex = -1;
            this.rptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(0, 0);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ShowLogo = false;
            this.rptViewer.Size = new System.Drawing.Size(1184, 572);
            this.rptViewer.TabIndex = 1;
            this.rptViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Form_Report_Daily_Sales
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxReportName);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "Form_Report_Daily_Sales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Report_Daily_Sales";
            this.groupBoxReportName.ResumeLayout(false);
            this.groupBoxReportName.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxReportName;
        private System.Windows.Forms.Button BtnShowReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDateEnd;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDateStr;
        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewer;
    }
}