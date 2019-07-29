namespace SlaughterHouseServer
{
    partial class Form_OrderDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_OrderDetail));
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddOrderItem = new System.Windows.Forms.Button();
            this.txtQtyWgh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUnitName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(122, 24);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(460, 37);
            this.cboProduct.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 29);
            this.label4.TabIndex = 35;
            this.label4.Text = "สินค้า:";
            // 
            // btnAddOrderItem
            // 
            this.btnAddOrderItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(93)))));
            this.btnAddOrderItem.FlatAppearance.BorderSize = 0;
            this.btnAddOrderItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrderItem.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrderItem.ForeColor = System.Drawing.Color.White;
            this.btnAddOrderItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOrderItem.Image")));
            this.btnAddOrderItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddOrderItem.Location = new System.Drawing.Point(122, 126);
            this.btnAddOrderItem.Name = "btnAddOrderItem";
            this.btnAddOrderItem.Size = new System.Drawing.Size(91, 36);
            this.btnAddOrderItem.TabIndex = 39;
            this.btnAddOrderItem.Text = "ตกลง";
            this.btnAddOrderItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddOrderItem.UseVisualStyleBackColor = false;
            this.btnAddOrderItem.Click += new System.EventHandler(this.btnAddOrderItem_Click);
            // 
            // txtQtyWgh
            // 
            this.txtQtyWgh.Location = new System.Drawing.Point(122, 67);
            this.txtQtyWgh.MaxLength = 10;
            this.txtQtyWgh.Name = "txtQtyWgh";
            this.txtQtyWgh.Size = new System.Drawing.Size(215, 36);
            this.txtQtyWgh.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 29);
            this.label2.TabIndex = 41;
            this.label2.Text = "จำนวน:";
            // 
            // lbUnitName
            // 
            this.lbUnitName.AutoSize = true;
            this.lbUnitName.Location = new System.Drawing.Point(359, 71);
            this.lbUnitName.Name = "lbUnitName";
            this.lbUnitName.Size = new System.Drawing.Size(40, 29);
            this.lbUnitName.TabIndex = 43;
            this.lbUnitName.Text = "---";
            // 
            // Form_OrderDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(606, 184);
            this.Controls.Add(this.lbUnitName);
            this.Controls.Add(this.txtQtyWgh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddOrderItem);
            this.Controls.Add(this.cboProduct);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_OrderDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_OrderDetail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddOrderItem;
        private System.Windows.Forms.TextBox txtQtyWgh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbUnitName;
    }
}