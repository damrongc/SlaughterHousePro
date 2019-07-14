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
            this.c1DataViewSet1 = new C1.C1DataExtender.C1DataViewSet();
            ((System.ComponentModel.ISupportInitialize)(this.c1DataViewSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1DataViewSet1
            // 
            this.c1DataViewSet1.DiagramXML = "";
            // 
            // Form_InvoiceReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1026, 492);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_InvoiceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_InvoiceReport";
            ((System.ComponentModel.ISupportInitialize)(this.c1DataViewSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.C1DataExtender.C1DataViewSet c1DataViewSet1;
    }
}