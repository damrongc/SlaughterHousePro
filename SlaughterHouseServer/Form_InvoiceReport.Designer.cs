namespace SlaughterHouseServer
{
    partial class Form_InvoiceReport
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
            this.groupBoxReportName = new System.Windows.Forms.GroupBox();
            this.rptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBoxReportName.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxReportName
            // 
            this.groupBoxReportName.Controls.Add(this.rptViewer);
            this.groupBoxReportName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxReportName.Location = new System.Drawing.Point(0, 0);
            this.groupBoxReportName.Name = "groupBoxReportName";
            this.groupBoxReportName.Size = new System.Drawing.Size(1184, 661);
            this.groupBoxReportName.TabIndex = 0;
            this.groupBoxReportName.TabStop = false;
            this.groupBoxReportName.Text = "ใบแจ้งหหนี้";
            // 
            // rptViewer
            // 
            this.rptViewer.ActiveViewIndex = -1;
            this.rptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(3, 32);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ShowParameterPanelButton = false;
            this.rptViewer.Size = new System.Drawing.Size(1178, 626);
            this.rptViewer.TabIndex = 1;
            this.rptViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Form_InvoiceReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.groupBoxReportName);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "Form_InvoiceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_InvoiceReport";
            this.groupBoxReportName.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxReportName;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewer;
    }
}