namespace SlaughterHouseServer
{
    partial class Form_Receive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Receive));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gv = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboFarm = new System.Windows.Forms.ComboBox();
            this.dtpReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Print = new System.Windows.Forms.DataGridViewImageColumn();
            this.CloseFlag = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReceiveFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiveNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransportDocNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTruckNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFarmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoopNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQueueNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreederName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFarmQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFarmWgh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFactoryQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFactoryWgh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ข้อมูลการรับหมูเป็น";
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdd.Image")));
            this.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAdd.Location = new System.Drawing.Point(177, 11);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(129, 36);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = "เพิ่มข้อมูล";
            this.BtnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdd.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.gv);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(1380, 730);
            this.panel1.TabIndex = 3;
            // 
            // gv
            // 
            this.gv.AllowUserToAddRows = false;
            this.gv.AllowUserToDeleteRows = false;
            this.gv.AllowUserToResizeColumns = false;
            this.gv.AllowUserToResizeRows = false;
            this.gv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gv.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Print,
            this.CloseFlag,
            this.colReceiveFlag,
            this.colReceiveNo,
            this.colReceiveDate,
            this.colTransportDocNo,
            this.colTruckNo,
            this.colFarmName,
            this.colCoopNo,
            this.colQueueNo,
            this.colBreederName,
            this.colFarmQty,
            this.colFarmWgh,
            this.colFactoryQty,
            this.colFactoryWgh,
            this.colCreateAt});
            this.gv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv.Location = new System.Drawing.Point(6, 68);
            this.gv.Name = "gv";
            this.gv.RowHeadersWidth = 10;
            this.gv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gv.Size = new System.Drawing.Size(1368, 656);
            this.gv.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(6, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1368, 1);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboFarm);
            this.panel2.Controls.Add(this.dtpReceiveDate);
            this.panel2.Controls.Add(this.BtnSearch);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BtnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1368, 61);
            this.panel2.TabIndex = 5;
            // 
            // cboFarm
            // 
            this.cboFarm.FormattingEnabled = true;
            this.cboFarm.Location = new System.Drawing.Point(560, 11);
            this.cboFarm.Name = "cboFarm";
            this.cboFarm.Size = new System.Drawing.Size(376, 37);
            this.cboFarm.TabIndex = 7;
            // 
            // dtpReceiveDate
            // 
            this.dtpReceiveDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceiveDate.Location = new System.Drawing.Point(312, 11);
            this.dtpReceiveDate.Name = "dtpReceiveDate";
            this.dtpReceiveDate.Size = new System.Drawing.Size(177, 36);
            this.dtpReceiveDate.TabIndex = 6;
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(223)))));
            this.BtnSearch.FlatAppearance.BorderSize = 0;
            this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.ForeColor = System.Drawing.Color.White;
            this.BtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearch.Image")));
            this.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearch.Location = new System.Drawing.Point(942, 11);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(142, 36);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "แสดงข้อมูล";
            this.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearch.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kanit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(495, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "ฟาร์ม:";
            // 
            // Edit
            // 
            this.Edit.HeaderText = "แก้ไข";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.Width = 58;
            // 
            // Print
            // 
            this.Print.HeaderText = "พิมพ์";
            this.Print.Image = ((System.Drawing.Image)(resources.GetObject("Print.Image")));
            this.Print.Name = "Print";
            this.Print.Width = 58;
            // 
            // CloseFlag
            // 
            this.CloseFlag.HeaderText = "จบคิว";
            this.CloseFlag.Image = ((System.Drawing.Image)(resources.GetObject("CloseFlag.Image")));
            this.CloseFlag.Name = "CloseFlag";
            this.CloseFlag.Width = 63;
            // 
            // colReceiveFlag
            // 
            this.colReceiveFlag.DataPropertyName = "ReceiveFlag";
            this.colReceiveFlag.HeaderText = "สถานะ";
            this.colReceiveFlag.Name = "colReceiveFlag";
            this.colReceiveFlag.Width = 87;
            // 
            // colReceiveNo
            // 
            this.colReceiveNo.DataPropertyName = "ReceiveNo";
            this.colReceiveNo.HeaderText = "เลขที่ใบรับ";
            this.colReceiveNo.Name = "colReceiveNo";
            this.colReceiveNo.Width = 117;
            // 
            // colReceiveDate
            // 
            this.colReceiveDate.DataPropertyName = "ReceiveDate";
            this.colReceiveDate.HeaderText = "วันที่รับ";
            this.colReceiveDate.Name = "colReceiveDate";
            this.colReceiveDate.Width = 91;
            // 
            // colTransportDocNo
            // 
            this.colTransportDocNo.DataPropertyName = "TransportDocNo";
            this.colTransportDocNo.HeaderText = "เลขที่ใบส่ง";
            this.colTransportDocNo.Name = "colTransportDocNo";
            this.colTransportDocNo.Width = 118;
            // 
            // colTruckNo
            // 
            this.colTruckNo.DataPropertyName = "TruckNo";
            this.colTruckNo.HeaderText = "ทะเบียนรถ";
            this.colTruckNo.Name = "colTruckNo";
            this.colTruckNo.Width = 117;
            // 
            // colFarmName
            // 
            this.colFarmName.DataPropertyName = "FarmName";
            this.colFarmName.HeaderText = "ฟาร์ม";
            this.colFarmName.Name = "colFarmName";
            this.colFarmName.Width = 81;
            // 
            // colCoopNo
            // 
            this.colCoopNo.DataPropertyName = "CoopNo";
            this.colCoopNo.HeaderText = "เล้า";
            this.colCoopNo.Name = "colCoopNo";
            this.colCoopNo.Width = 63;
            // 
            // colQueueNo
            // 
            this.colQueueNo.DataPropertyName = "QueueNo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQueueNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.colQueueNo.HeaderText = "คิวที่";
            this.colQueueNo.Name = "colQueueNo";
            this.colQueueNo.Width = 70;
            // 
            // colBreederName
            // 
            this.colBreederName.DataPropertyName = "BreederName";
            this.colBreederName.HeaderText = "ประเภท";
            this.colBreederName.Name = "colBreederName";
            this.colBreederName.Width = 95;
            // 
            // colFarmQty
            // 
            this.colFarmQty.DataPropertyName = "FarmQty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colFarmQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFarmQty.HeaderText = "จำนวนฟาร์ม";
            this.colFarmQty.Name = "colFarmQty";
            this.colFarmQty.Width = 131;
            // 
            // colFarmWgh
            // 
            this.colFarmWgh.DataPropertyName = "FarmWgh";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colFarmWgh.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFarmWgh.HeaderText = "น้ำหนักฟาร์ม";
            this.colFarmWgh.Name = "colFarmWgh";
            this.colFarmWgh.Width = 134;
            // 
            // colFactoryQty
            // 
            this.colFactoryQty.DataPropertyName = "FactoryQty";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colFactoryQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.colFactoryQty.HeaderText = "จำนวนรับ";
            this.colFactoryQty.Name = "colFactoryQty";
            this.colFactoryQty.Width = 110;
            // 
            // colFactoryWgh
            // 
            this.colFactoryWgh.DataPropertyName = "FactoryWgh";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colFactoryWgh.DefaultCellStyle = dataGridViewCellStyle5;
            this.colFactoryWgh.HeaderText = "น้ำหนักรับ";
            this.colFactoryWgh.Name = "colFactoryWgh";
            this.colFactoryWgh.Width = 113;
            // 
            // colCreateAt
            // 
            this.colCreateAt.DataPropertyName = "CreateAt";
            this.colCreateAt.HeaderText = "วันเวลาสร้าง";
            this.colCreateAt.Name = "colCreateAt";
            this.colCreateAt.Width = 133;
            // 
            // Form_Receive
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Kanit", 15.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Receive";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "เอกสารการรับ";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpReceiveDate;
        private System.Windows.Forms.ComboBox cboFarm;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Print;
        private System.Windows.Forms.DataGridViewImageColumn CloseFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiveFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiveNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiveDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransportDocNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTruckNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFarmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoopNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQueueNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreederName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFarmQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFarmWgh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactoryQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactoryWgh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateAt;
    }
}