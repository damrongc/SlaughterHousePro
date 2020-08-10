namespace SlaughterHouseServer.Reports
{
    partial class Form_ReportStockBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ReportStockBalance));
            this.groupBoxReportName = new System.Windows.Forms.GroupBox();
            this.BtnShowReport = new System.Windows.Forms.Button();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.labelProductGroup = new System.Windows.Forms.Label();
            this.comboxProductGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.groupBoxReportName.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxReportName
            // 
            this.groupBoxReportName.Controls.Add(this.label1);
            this.groupBoxReportName.Controls.Add(this.cboProduct);
            this.groupBoxReportName.Controls.Add(this.labelProductGroup);
            this.groupBoxReportName.Controls.Add(this.comboxProductGroup);
            this.groupBoxReportName.Controls.Add(this.BtnShowReport);
            this.groupBoxReportName.Controls.Add(this.dtpInvoiceDate);
            this.groupBoxReportName.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxReportName.Location = new System.Drawing.Point(0, 0);
            this.groupBoxReportName.Name = "groupBoxReportName";
            this.groupBoxReportName.Size = new System.Drawing.Size(1184, 91);
            this.groupBoxReportName.TabIndex = 0;
            this.groupBoxReportName.TabStop = false;
            this.groupBoxReportName.Text = "รายงานสต็อกคงเหลือรายวัน";
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
            this.BtnShowReport.Location = new System.Drawing.Point(804, 38);
            this.BtnShowReport.Name = "BtnShowReport";
            this.BtnShowReport.Size = new System.Drawing.Size(157, 36);
            this.BtnShowReport.TabIndex = 14;
            this.BtnShowReport.Text = "แสดงรายงาน";
            this.BtnShowReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnShowReport.UseVisualStyleBackColor = false;
            this.BtnShowReport.Click += new System.EventHandler(this.BtnShowReport_Click);
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy";
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(12, 35);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(177, 36);
            this.dtpInvoiceDate.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rptViewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 570);
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
            this.rptViewer.Size = new System.Drawing.Size(1184, 570);
            this.rptViewer.TabIndex = 3;
            this.rptViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // labelProductGroup
            // 
            this.labelProductGroup.AutoSize = true;
            this.labelProductGroup.Location = new System.Drawing.Point(195, 41);
            this.labelProductGroup.Name = "labelProductGroup";
            this.labelProductGroup.Size = new System.Drawing.Size(90, 29);
            this.labelProductGroup.TabIndex = 29;
            this.labelProductGroup.Text = "กลุ่มสินค้า";
            // 
            // comboxProductGroup
            // 
            this.comboxProductGroup.FormattingEnabled = true;
            this.comboxProductGroup.Location = new System.Drawing.Point(300, 37);
            this.comboxProductGroup.Name = "comboxProductGroup";
            this.comboxProductGroup.Size = new System.Drawing.Size(215, 37);
            this.comboxProductGroup.TabIndex = 28;
            this.comboxProductGroup.SelectedIndexChanged += new System.EventHandler(this.comboxProductGroup_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(521, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 29);
            this.label1.TabIndex = 31;
            this.label1.Text = "สินค้า";
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(583, 38);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(215, 37);
            this.cboProduct.TabIndex = 30;
            // 
            // Form_ReportStockBalance
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxReportName);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "Form_ReportStockBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Report_Stock_Balance";
            this.groupBoxReportName.ResumeLayout(false);
            this.groupBoxReportName.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxReportName;
        private System.Windows.Forms.Button BtnShowReport;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewer;
        private System.Windows.Forms.Label labelProductGroup;
        private System.Windows.Forms.ComboBox comboxProductGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProduct;
    }
}