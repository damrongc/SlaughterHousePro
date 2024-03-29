﻿namespace SlaughterHouseServer
{
    partial class Form_BomAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BomAddEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBomCode = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.btnAddOrderItem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gv = new System.Windows.Forms.DataGridView();
            this.Del = new System.Windows.Forms.DataGridViewImageColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.BtnSaveAndNew = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLovProduct = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bom Code";
            // 
            // txtBomCode
            // 
            this.txtBomCode.Location = new System.Drawing.Point(182, 22);
            this.txtBomCode.MaxLength = 10;
            this.txtBomCode.Name = "txtBomCode";
            this.txtBomCode.Size = new System.Drawing.Size(215, 36);
            this.txtBomCode.TabIndex = 1;
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSave.Location = new System.Drawing.Point(730, 590);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(215, 36);
            this.BtnSave.TabIndex = 7;
            this.BtnSave.Text = "บันทึกแล้วปิด";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
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
            this.btnAddOrderItem.Location = new System.Drawing.Point(846, 0);
            this.btnAddOrderItem.Name = "btnAddOrderItem";
            this.btnAddOrderItem.Size = new System.Drawing.Size(87, 36);
            this.btnAddOrderItem.TabIndex = 39;
            this.btnAddOrderItem.Text = "เพิ่ม";
            this.btnAddOrderItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddOrderItem.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gv);
            this.panel2.Location = new System.Drawing.Point(12, 179);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(933, 383);
            this.panel2.TabIndex = 43;
            // 
            // gv
            // 
            this.gv.AllowUserToAddRows = false;
            this.gv.AllowUserToDeleteRows = false;
            this.gv.AllowUserToResizeColumns = false;
            this.gv.AllowUserToResizeRows = false;
            this.gv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gv.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Del});
            this.gv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv.Location = new System.Drawing.Point(0, 0);
            this.gv.Name = "gv";
            this.gv.RowHeadersWidth = 10;
            this.gv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gv.Size = new System.Drawing.Size(933, 383);
            this.gv.TabIndex = 43;
            // 
            // Del
            // 
            this.Del.HeaderText = "ลบ";
            this.Del.Image = ((System.Drawing.Image)(resources.GetObject("Del.Image")));
            this.Del.Name = "Del";
            this.Del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Del.Width = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 29);
            this.label2.TabIndex = 44;
            this.label2.Text = "สินค้า";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAddOrderItem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 36);
            this.panel1.TabIndex = 45;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(182, 106);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(79, 33);
            this.chkActive.TabIndex = 46;
            this.chkActive.Text = "ใช้งาน";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // BtnSaveAndNew
            // 
            this.BtnSaveAndNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(93)))));
            this.BtnSaveAndNew.FlatAppearance.BorderSize = 0;
            this.BtnSaveAndNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveAndNew.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveAndNew.ForeColor = System.Drawing.Color.White;
            this.BtnSaveAndNew.Image = ((System.Drawing.Image)(resources.GetObject("BtnSaveAndNew.Image")));
            this.BtnSaveAndNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveAndNew.Location = new System.Drawing.Point(521, 590);
            this.BtnSaveAndNew.Name = "BtnSaveAndNew";
            this.BtnSaveAndNew.Size = new System.Drawing.Size(202, 36);
            this.BtnSaveAndNew.TabIndex = 25;
            this.BtnSaveAndNew.Text = "บันทึกแล้วสร้างใหม่";
            this.BtnSaveAndNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSaveAndNew.UseVisualStyleBackColor = false;
            this.BtnSaveAndNew.Click += new System.EventHandler(this.BtnSaveAndNew_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(182, 67);
            this.txtProductName.MaxLength = 10;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(447, 36);
            this.txtProductName.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 29);
            this.label3.TabIndex = 48;
            this.label3.Text = "สินค้า";
            // 
            // btnLovProduct
            // 
            this.btnLovProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.btnLovProduct.FlatAppearance.BorderSize = 0;
            this.btnLovProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLovProduct.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLovProduct.ForeColor = System.Drawing.Color.White;
            this.btnLovProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnLovProduct.Image")));
            this.btnLovProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLovProduct.Location = new System.Drawing.Point(629, 67);
            this.btnLovProduct.Name = "btnLovProduct";
            this.btnLovProduct.Size = new System.Drawing.Size(39, 36);
            this.btnLovProduct.TabIndex = 50;
            this.btnLovProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLovProduct.UseVisualStyleBackColor = false;
            // 
            // Form_BomAddEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(957, 648);
            this.Controls.Add(this.btnLovProduct);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BtnSaveAndNew);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.txtBomCode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_BomAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_BomAddEdit";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBomCode;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button btnAddOrderItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button BtnSaveAndNew;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewImageColumn Del;
        private System.Windows.Forms.Button btnLovProduct;
    }
}