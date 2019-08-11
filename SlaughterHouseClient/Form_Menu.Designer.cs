namespace SlaughterHouseClient
{
    partial class Form_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Menu));
            this.btnExit = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblCurrentDatetime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReceiveSwine = new System.Windows.Forms.Button();
            this.btnReceiveCarcass = new System.Windows.Forms.Button();
            this.btnReceiveByProductWhite = new System.Windows.Forms.Button();
            this.btnReceiveByProductRed = new System.Windows.Forms.Button();
            this.btnIssueCarcass = new System.Windows.Forms.Button();
            this.btnIssueCarcassForSales = new System.Windows.Forms.Button();
            this.btnReceivePart = new System.Windows.Forms.Button();
            this.btnIssueHead = new System.Windows.Forms.Button();
            this.btnIssueByProduct = new System.Windows.Forms.Button();
            this.btnIssuePart = new System.Windows.Forms.Button();
            this.dragControl1 = new DragControl();
            this.btnReceiveHead = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelHeader.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
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
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.panelHeader.Controls.Add(this.lblCurrentDatetime);
            this.panelHeader.Controls.Add(this.btnExit);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1024, 54);
            this.panelHeader.TabIndex = 1;
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
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Kanit", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(437, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "ระบบบริการจัดการโรงเชือด";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnReceiveSwine);
            this.flowLayoutPanel1.Controls.Add(this.btnReceiveCarcass);
            this.flowLayoutPanel1.Controls.Add(this.btnReceiveHead);
            this.flowLayoutPanel1.Controls.Add(this.btnReceiveByProductWhite);
            this.flowLayoutPanel1.Controls.Add(this.btnReceiveByProductRed);
            this.flowLayoutPanel1.Controls.Add(this.btnReceivePart);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 54);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(30);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1024, 352);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.Click += new System.EventHandler(this.btnIssuePart_Click);
            // 
            // btnReceiveSwine
            // 
            this.btnReceiveSwine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReceiveSwine.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveSwine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveSwine.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReceiveSwine.ForeColor = System.Drawing.Color.White;
            this.btnReceiveSwine.Location = new System.Drawing.Point(33, 33);
            this.btnReceiveSwine.Name = "btnReceiveSwine";
            this.btnReceiveSwine.Size = new System.Drawing.Size(285, 89);
            this.btnReceiveSwine.TabIndex = 8;
            this.btnReceiveSwine.Text = "รับหมูเป็น";
            this.btnReceiveSwine.UseVisualStyleBackColor = false;
            this.btnReceiveSwine.Click += new System.EventHandler(this.btnReceiveSwine_Click);
            // 
            // btnReceiveCarcass
            // 
            this.btnReceiveCarcass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReceiveCarcass.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveCarcass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveCarcass.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReceiveCarcass.ForeColor = System.Drawing.Color.White;
            this.btnReceiveCarcass.Location = new System.Drawing.Point(324, 33);
            this.btnReceiveCarcass.Name = "btnReceiveCarcass";
            this.btnReceiveCarcass.Size = new System.Drawing.Size(285, 89);
            this.btnReceiveCarcass.TabIndex = 9;
            this.btnReceiveCarcass.Text = "รับหมูซีก";
            this.btnReceiveCarcass.UseVisualStyleBackColor = false;
            this.btnReceiveCarcass.Click += new System.EventHandler(this.btnReceiveCarcass_Click);
            // 
            // btnReceiveByProductWhite
            // 
            this.btnReceiveByProductWhite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReceiveByProductWhite.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveByProductWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveByProductWhite.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReceiveByProductWhite.ForeColor = System.Drawing.Color.White;
            this.btnReceiveByProductWhite.Location = new System.Drawing.Point(33, 128);
            this.btnReceiveByProductWhite.Name = "btnReceiveByProductWhite";
            this.btnReceiveByProductWhite.Size = new System.Drawing.Size(285, 89);
            this.btnReceiveByProductWhite.TabIndex = 10;
            this.btnReceiveByProductWhite.Text = "รับเครื่องในขาว(ชุด)";
            this.btnReceiveByProductWhite.UseVisualStyleBackColor = false;
            this.btnReceiveByProductWhite.Click += new System.EventHandler(this.btnReceiveByProductWhite_Click);
            // 
            // btnReceiveByProductRed
            // 
            this.btnReceiveByProductRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReceiveByProductRed.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveByProductRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveByProductRed.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReceiveByProductRed.ForeColor = System.Drawing.Color.White;
            this.btnReceiveByProductRed.Location = new System.Drawing.Point(324, 128);
            this.btnReceiveByProductRed.Name = "btnReceiveByProductRed";
            this.btnReceiveByProductRed.Size = new System.Drawing.Size(285, 89);
            this.btnReceiveByProductRed.TabIndex = 11;
            this.btnReceiveByProductRed.Text = "รับเครื่องในแดง(ชุด)";
            this.btnReceiveByProductRed.UseVisualStyleBackColor = false;
            this.btnReceiveByProductRed.Click += new System.EventHandler(this.btnReceiveByProductRed_Click);
            // 
            // btnIssueCarcass
            // 
            this.btnIssueCarcass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(66)))), ((int)(((byte)(54)))));
            this.btnIssueCarcass.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIssueCarcass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueCarcass.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnIssueCarcass.ForeColor = System.Drawing.Color.White;
            this.btnIssueCarcass.Location = new System.Drawing.Point(324, 33);
            this.btnIssueCarcass.Name = "btnIssueCarcass";
            this.btnIssueCarcass.Size = new System.Drawing.Size(285, 89);
            this.btnIssueCarcass.TabIndex = 12;
            this.btnIssueCarcass.Text = "จ่ายหมูซีก-ตัดแต่ง";
            this.btnIssueCarcass.UseVisualStyleBackColor = false;
            this.btnIssueCarcass.Click += new System.EventHandler(this.btnIssueCarcass_Click);
            // 
            // btnIssueCarcassForSales
            // 
            this.btnIssueCarcassForSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(66)))), ((int)(((byte)(54)))));
            this.btnIssueCarcassForSales.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIssueCarcassForSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueCarcassForSales.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnIssueCarcassForSales.ForeColor = System.Drawing.Color.White;
            this.btnIssueCarcassForSales.Location = new System.Drawing.Point(324, 128);
            this.btnIssueCarcassForSales.Name = "btnIssueCarcassForSales";
            this.btnIssueCarcassForSales.Size = new System.Drawing.Size(285, 89);
            this.btnIssueCarcassForSales.TabIndex = 13;
            this.btnIssueCarcassForSales.Text = "จ่ายหมูซีก-ขาย";
            this.btnIssueCarcassForSales.UseVisualStyleBackColor = false;
            this.btnIssueCarcassForSales.Click += new System.EventHandler(this.btnIssueCarcassForSales_Click);
            // 
            // btnReceivePart
            // 
            this.btnReceivePart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReceivePart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceivePart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceivePart.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReceivePart.ForeColor = System.Drawing.Color.White;
            this.btnReceivePart.Location = new System.Drawing.Point(615, 128);
            this.btnReceivePart.Name = "btnReceivePart";
            this.btnReceivePart.Size = new System.Drawing.Size(285, 89);
            this.btnReceivePart.TabIndex = 14;
            this.btnReceivePart.Text = "รับชิ้นส่วน";
            this.btnReceivePart.UseVisualStyleBackColor = false;
            this.btnReceivePart.Click += new System.EventHandler(this.btnReceivePart_Click);
            // 
            // btnIssueHead
            // 
            this.btnIssueHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(66)))), ((int)(((byte)(54)))));
            this.btnIssueHead.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIssueHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueHead.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnIssueHead.ForeColor = System.Drawing.Color.White;
            this.btnIssueHead.Location = new System.Drawing.Point(33, 33);
            this.btnIssueHead.Name = "btnIssueHead";
            this.btnIssueHead.Size = new System.Drawing.Size(285, 89);
            this.btnIssueHead.TabIndex = 15;
            this.btnIssueHead.Text = "จ่ายหัว";
            this.btnIssueHead.UseVisualStyleBackColor = false;
            this.btnIssueHead.Click += new System.EventHandler(this.btnIssueHead_Click);
            // 
            // btnIssueByProduct
            // 
            this.btnIssueByProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(66)))), ((int)(((byte)(54)))));
            this.btnIssueByProduct.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIssueByProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueByProduct.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnIssueByProduct.ForeColor = System.Drawing.Color.White;
            this.btnIssueByProduct.Location = new System.Drawing.Point(615, 33);
            this.btnIssueByProduct.Name = "btnIssueByProduct";
            this.btnIssueByProduct.Size = new System.Drawing.Size(285, 89);
            this.btnIssueByProduct.TabIndex = 16;
            this.btnIssueByProduct.Text = "จ่ายเครื่องใน";
            this.btnIssueByProduct.UseVisualStyleBackColor = false;
            this.btnIssueByProduct.Click += new System.EventHandler(this.btnIssueByProduct_Click);
            // 
            // btnIssuePart
            // 
            this.btnIssuePart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(66)))), ((int)(((byte)(54)))));
            this.btnIssuePart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIssuePart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssuePart.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnIssuePart.ForeColor = System.Drawing.Color.White;
            this.btnIssuePart.Location = new System.Drawing.Point(33, 128);
            this.btnIssuePart.Name = "btnIssuePart";
            this.btnIssuePart.Size = new System.Drawing.Size(285, 89);
            this.btnIssuePart.TabIndex = 17;
            this.btnIssuePart.Text = "จ่ายชิ้นส่วน";
            this.btnIssuePart.UseVisualStyleBackColor = false;
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelHeader;
            // 
            // btnReceiveHead
            // 
            this.btnReceiveHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btnReceiveHead.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceiveHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveHead.Font = new System.Drawing.Font("Kanit", 20F);
            this.btnReceiveHead.ForeColor = System.Drawing.Color.White;
            this.btnReceiveHead.Location = new System.Drawing.Point(615, 33);
            this.btnReceiveHead.Name = "btnReceiveHead";
            this.btnReceiveHead.Size = new System.Drawing.Size(285, 89);
            this.btnReceiveHead.TabIndex = 18;
            this.btnReceiveHead.Text = "รับหัว";
            this.btnReceiveHead.UseVisualStyleBackColor = false;
            this.btnReceiveHead.Click += new System.EventHandler(this.btnReceiveHead_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnIssueHead);
            this.flowLayoutPanel2.Controls.Add(this.btnIssueCarcass);
            this.flowLayoutPanel2.Controls.Add(this.btnIssueByProduct);
            this.flowLayoutPanel2.Controls.Add(this.btnIssuePart);
            this.flowLayoutPanel2.Controls.Add(this.btnIssueCarcassForSales);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 406);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(30);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1024, 362);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // Form_Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Kanit", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Form_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Menu";
            this.panelHeader.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblCurrentDatetime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnReceiveSwine;
        private System.Windows.Forms.Button btnReceiveCarcass;
        private System.Windows.Forms.Button btnReceiveByProductWhite;
        private System.Windows.Forms.Button btnReceiveByProductRed;
        private System.Windows.Forms.Button btnIssueCarcass;
        private System.Windows.Forms.Button btnIssueCarcassForSales;
        private System.Windows.Forms.Button btnReceivePart;
        private System.Windows.Forms.Button btnIssueHead;
        private System.Windows.Forms.Button btnIssueByProduct;
        private System.Windows.Forms.Button btnIssuePart;
        private DragControl dragControl1;
        private System.Windows.Forms.Button btnReceiveHead;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}