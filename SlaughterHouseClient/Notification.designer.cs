namespace ToastNotifications
{
    partial class Notification
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notification));
            this.lifeTimer = new System.Windows.Forms.Timer(this.components);
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lifeTimer
            // 
            this.lifeTimer.Tick += new System.EventHandler(this.lifeTimer_Tick);
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Kanit", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(698, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "title goes here";
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // labelBody
            // 
            this.labelBody.BackColor = System.Drawing.Color.Transparent;
            this.labelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBody.Font = new System.Drawing.Font("Kanit", 30.25F);
            this.labelBody.ForeColor = System.Drawing.Color.White;
            this.labelBody.Location = new System.Drawing.Point(0, 37);
            this.labelBody.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(698, 281);
            this.labelBody.TabIndex = 1;
            this.labelBody.Text = "Body goes here and here and here and here and here lkjdflkdsjfsdf   lksdjlksdfjsd" +
    ";lfsdf";
            this.labelBody.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(698, 318);
            this.ControlBox = false;
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.labelTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Kanit", 20F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.Name = "Notification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "EDGE Shop Flag Notification";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Notification_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Notification_FormClosed);
            this.Load += new System.EventHandler(this.Notification_Load);
            this.Shown += new System.EventHandler(this.Notification_Shown);
            this.Click += new System.EventHandler(this.Notification_Click);
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Timer lifeTimer;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelBody;
    }
}