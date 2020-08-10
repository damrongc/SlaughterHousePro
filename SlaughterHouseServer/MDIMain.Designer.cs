namespace SlaughterHouseServer
{
    partial class MDIMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFarm = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBreeder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuProductGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCustomerGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClassPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSalesman = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuTruckType = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTruck = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBOM = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuReceive = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReportReceived = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReportYieldReceived = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuReportOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReportOrderWithInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuReportStockMovement = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReportStockBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUserGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPermission = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlant = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCloseProductionDate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Kanit", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMaster,
            this.MnuReceive,
            this.MenuReport,
            this.MenuAccount,
            this.MenuAdmin,
            this.MenuSystem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1159, 30);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuMaster
            // 
            this.MenuMaster.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFarm,
            this.MenuBreeder,
            this.toolStripSeparator1,
            this.MenuProductGroup,
            this.MenuProduct,
            this.MenuUnit,
            this.toolStripSeparator2,
            this.MenuCustomer,
            this.MenuCustomerGroup,
            this.MenuClassPrice,
            this.MenuSalesman,
            this.toolStripSeparator3,
            this.MenuTruckType,
            this.MenuTruck,
            this.MenuBOM});
            this.MenuMaster.Name = "MenuMaster";
            this.MenuMaster.Size = new System.Drawing.Size(79, 26);
            this.MenuMaster.Text = "ข้อมูลหลัก";
            // 
            // MenuFarm
            // 
            this.MenuFarm.Name = "MenuFarm";
            this.MenuFarm.Size = new System.Drawing.Size(153, 26);
            this.MenuFarm.Text = "ฟาร์ม";
            this.MenuFarm.Click += new System.EventHandler(this.MenuFarm_Click);
            // 
            // MenuBreeder
            // 
            this.MenuBreeder.Name = "MenuBreeder";
            this.MenuBreeder.Size = new System.Drawing.Size(153, 26);
            this.MenuBreeder.Text = "สายพันธุ์";
            this.MenuBreeder.Click += new System.EventHandler(this.MenuBreeder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // MenuProductGroup
            // 
            this.MenuProductGroup.Name = "MenuProductGroup";
            this.MenuProductGroup.Size = new System.Drawing.Size(153, 26);
            this.MenuProductGroup.Text = "กลุ่มสินค้า";
            this.MenuProductGroup.Click += new System.EventHandler(this.MenuProductGroup_Click);
            // 
            // MenuProduct
            // 
            this.MenuProduct.Name = "MenuProduct";
            this.MenuProduct.Size = new System.Drawing.Size(153, 26);
            this.MenuProduct.Text = "สินค้า";
            this.MenuProduct.Click += new System.EventHandler(this.MenuProduct_Click);
            // 
            // MenuUnit
            // 
            this.MenuUnit.Name = "MenuUnit";
            this.MenuUnit.Size = new System.Drawing.Size(153, 26);
            this.MenuUnit.Text = "หน่วยสินค้า";
            this.MenuUnit.Click += new System.EventHandler(this.MenuUnit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(150, 6);
            // 
            // MenuCustomer
            // 
            this.MenuCustomer.Name = "MenuCustomer";
            this.MenuCustomer.Size = new System.Drawing.Size(153, 26);
            this.MenuCustomer.Text = "ลูกค้า";
            this.MenuCustomer.Click += new System.EventHandler(this.MenuCustomer_Click);
            // 
            // MenuCustomerGroup
            // 
            this.MenuCustomerGroup.Name = "MenuCustomerGroup";
            this.MenuCustomerGroup.Size = new System.Drawing.Size(153, 26);
            this.MenuCustomerGroup.Text = "ระดับลูกค้า";
            this.MenuCustomerGroup.Click += new System.EventHandler(this.MenuCustomerGroup_Click);
            // 
            // MenuClassPrice
            // 
            this.MenuClassPrice.Name = "MenuClassPrice";
            this.MenuClassPrice.Size = new System.Drawing.Size(153, 26);
            this.MenuClassPrice.Text = "ราคาประกาศ";
            this.MenuClassPrice.Click += new System.EventHandler(this.MenuClassPrice_Click);
            // 
            // MenuSalesman
            // 
            this.MenuSalesman.Name = "MenuSalesman";
            this.MenuSalesman.Size = new System.Drawing.Size(153, 26);
            this.MenuSalesman.Text = "พนักงานขาย";
            this.MenuSalesman.Click += new System.EventHandler(this.MenuSalesman_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(150, 6);
            // 
            // MenuTruckType
            // 
            this.MenuTruckType.Name = "MenuTruckType";
            this.MenuTruckType.Size = new System.Drawing.Size(153, 26);
            this.MenuTruckType.Text = "ประเภทรถ";
            this.MenuTruckType.Click += new System.EventHandler(this.MenuTruckType_Click);
            // 
            // MenuTruck
            // 
            this.MenuTruck.Name = "MenuTruck";
            this.MenuTruck.Size = new System.Drawing.Size(153, 26);
            this.MenuTruck.Text = "ทะเบียนรถ";
            this.MenuTruck.Click += new System.EventHandler(this.MenuTruck_Click);
            // 
            // MenuBOM
            // 
            this.MenuBOM.Name = "MenuBOM";
            this.MenuBOM.Size = new System.Drawing.Size(153, 26);
            this.MenuBOM.Text = "BOM";
            this.MenuBOM.Click += new System.EventHandler(this.MenuBOM_Click);
            // 
            // MnuReceive
            // 
            this.MnuReceive.Font = new System.Drawing.Font("Kanit", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnuReceive.Name = "MnuReceive";
            this.MnuReceive.Size = new System.Drawing.Size(110, 26);
            this.MnuReceive.Text = "เอกสารการรับ";
            this.MnuReceive.Click += new System.EventHandler(this.MnuReceive_Click);
            // 
            // MenuReport
            // 
            this.MenuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuReportReceived,
            this.MenuReportYieldReceived,
            this.toolStripSeparator4,
            this.MenuReportOrders,
            this.MenuReportOrderWithInvoice,
            this.toolStripSeparator5,
            this.MenuReportStockMovement,
            this.MenuReportStockBalance});
            this.MenuReport.Name = "MenuReport";
            this.MenuReport.Size = new System.Drawing.Size(65, 26);
            this.MenuReport.Text = "รายงาน";
            // 
            // MenuReportReceived
            // 
            this.MenuReportReceived.Name = "MenuReportReceived";
            this.MenuReportReceived.Size = new System.Drawing.Size(312, 26);
            this.MenuReportReceived.Text = "รายงานหมูเป็นเทียบหมูซีก หัว เครื่องใน";
            this.MenuReportReceived.Click += new System.EventHandler(this.MenuReportReceived_Click);
            // 
            // MenuReportYieldReceived
            // 
            this.MenuReportYieldReceived.Name = "MenuReportYieldReceived";
            this.MenuReportYieldReceived.Size = new System.Drawing.Size(312, 26);
            this.MenuReportYieldReceived.Text = "รายงาน Yield การรับหมูเป็น";
            this.MenuReportYieldReceived.Click += new System.EventHandler(this.MenuReportYieldReceived_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(309, 6);
            // 
            // MenuReportOrders
            // 
            this.MenuReportOrders.Name = "MenuReportOrders";
            this.MenuReportOrders.Size = new System.Drawing.Size(312, 26);
            this.MenuReportOrders.Text = "รายงานรายวันขาย";
            this.MenuReportOrders.Click += new System.EventHandler(this.MenuReportOrders_Click);
            // 
            // MenuReportOrderWithInvoice
            // 
            this.MenuReportOrderWithInvoice.Name = "MenuReportOrderWithInvoice";
            this.MenuReportOrderWithInvoice.Size = new System.Drawing.Size(312, 26);
            this.MenuReportOrderWithInvoice.Text = "รายงานเปรียบเทียบใบสั่งขายกับใบแจ้งหนี้";
            this.MenuReportOrderWithInvoice.Click += new System.EventHandler(this.MenuReportOrderWithInvoice_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(309, 6);
            // 
            // MenuReportStockMovement
            // 
            this.MenuReportStockMovement.Name = "MenuReportStockMovement";
            this.MenuReportStockMovement.Size = new System.Drawing.Size(312, 26);
            this.MenuReportStockMovement.Text = "รายงานเคลื่อนไหวสต็อก";
            this.MenuReportStockMovement.Click += new System.EventHandler(this.MenuReportStockMovement_Click);
            // 
            // MenuReportStockBalance
            // 
            this.MenuReportStockBalance.Name = "MenuReportStockBalance";
            this.MenuReportStockBalance.Size = new System.Drawing.Size(312, 26);
            this.MenuReportStockBalance.Text = "รายงานสต็อกคงเหลือรายวัน";
            this.MenuReportStockBalance.Click += new System.EventHandler(this.MenuReportStockBalance_Click);
            // 
            // MenuAccount
            // 
            this.MenuAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOrders,
            this.toolStripSeparator6,
            this.MenuInvoices});
            this.MenuAccount.Name = "MenuAccount";
            this.MenuAccount.Size = new System.Drawing.Size(96, 26);
            this.MenuAccount.Text = "เอกสารบัญชี";
            // 
            // MenuOrders
            // 
            this.MenuOrders.Name = "MenuOrders";
            this.MenuOrders.Size = new System.Drawing.Size(133, 26);
            this.MenuOrders.Text = "ใบสั่งขาย";
            this.MenuOrders.Click += new System.EventHandler(this.MenuOrders_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(130, 6);
            // 
            // MenuInvoices
            // 
            this.MenuInvoices.Name = "MenuInvoices";
            this.MenuInvoices.Size = new System.Drawing.Size(133, 26);
            this.MenuInvoices.Text = "ใบแจ้งหนี้";
            this.MenuInvoices.Click += new System.EventHandler(this.MenuInvoices_Click);
            // 
            // MenuAdmin
            // 
            this.MenuAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUserGroup,
            this.MenuUser,
            this.MenuPermission});
            this.MenuAdmin.Name = "MenuAdmin";
            this.MenuAdmin.Size = new System.Drawing.Size(86, 26);
            this.MenuAdmin.Text = "ผู้ดูแลระบบ";
            // 
            // MenuUserGroup
            // 
            this.MenuUserGroup.Name = "MenuUserGroup";
            this.MenuUserGroup.Size = new System.Drawing.Size(166, 26);
            this.MenuUserGroup.Text = "กลุ่มผู้ใช้งาน";
            this.MenuUserGroup.Click += new System.EventHandler(this.MenuUserGroup_Click);
            // 
            // MenuUser
            // 
            this.MenuUser.Name = "MenuUser";
            this.MenuUser.Size = new System.Drawing.Size(166, 26);
            this.MenuUser.Text = "ผู้ใช้งาน";
            this.MenuUser.Click += new System.EventHandler(this.MenuUser_Click);
            // 
            // MenuPermission
            // 
            this.MenuPermission.Name = "MenuPermission";
            this.MenuPermission.Size = new System.Drawing.Size(166, 26);
            this.MenuPermission.Text = "การกำหนดสิทธิ์";
            this.MenuPermission.Click += new System.EventHandler(this.MenuPermission_Click);
            // 
            // MenuSystem
            // 
            this.MenuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPlant,
            this.MenuCloseProductionDate});
            this.MenuSystem.Name = "MenuSystem";
            this.MenuSystem.Size = new System.Drawing.Size(84, 26);
            this.MenuSystem.Text = "ข้อมูลระบบ";
            // 
            // MenuPlant
            // 
            this.MenuPlant.Name = "MenuPlant";
            this.MenuPlant.Size = new System.Drawing.Size(153, 26);
            this.MenuPlant.Text = "ข้อมูลโรงงาน";
            this.MenuPlant.Click += new System.EventHandler(this.MenuPlant_Click);
            // 
            // MenuCloseProductionDate
            // 
            this.MenuCloseProductionDate.Name = "MenuCloseProductionDate";
            this.MenuCloseProductionDate.Size = new System.Drawing.Size(153, 26);
            this.MenuCloseProductionDate.Text = "การปิดวัน";
            this.MenuCloseProductionDate.Click += new System.EventHandler(this.MenuCloseProductionDate_Click);
            // 
            // MDIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 701);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Kanit", 14.25F);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "MDIMain";
            this.Text = "ระบบบริหารจัดการโรงชำแหละสุกร v.2020.07.28.01";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MnuReceive;
        private System.Windows.Forms.ToolStripMenuItem MenuMaster;
        private System.Windows.Forms.ToolStripMenuItem MenuFarm;
        private System.Windows.Forms.ToolStripMenuItem MenuProductGroup;
        private System.Windows.Forms.ToolStripMenuItem MenuProduct;
        private System.Windows.Forms.ToolStripMenuItem MenuUnit;
        private System.Windows.Forms.ToolStripMenuItem MenuBreeder;
        private System.Windows.Forms.ToolStripMenuItem MenuCustomer;
        private System.Windows.Forms.ToolStripMenuItem MenuCustomerGroup;
        private System.Windows.Forms.ToolStripMenuItem MenuClassPrice;
        private System.Windows.Forms.ToolStripMenuItem MenuTruckType;
        private System.Windows.Forms.ToolStripMenuItem MenuTruck;
        private System.Windows.Forms.ToolStripMenuItem MenuBOM;
        private System.Windows.Forms.ToolStripMenuItem MenuReport;
        private System.Windows.Forms.ToolStripMenuItem MenuReportReceived;
        private System.Windows.Forms.ToolStripMenuItem MenuAccount;
        private System.Windows.Forms.ToolStripMenuItem MenuAdmin;
        private System.Windows.Forms.ToolStripMenuItem MenuUserGroup;
        private System.Windows.Forms.ToolStripMenuItem MenuUser;
        private System.Windows.Forms.ToolStripMenuItem MenuPermission;
        private System.Windows.Forms.ToolStripMenuItem MenuOrders;
        private System.Windows.Forms.ToolStripMenuItem MenuInvoices;
        private System.Windows.Forms.ToolStripMenuItem MenuReportYieldReceived;
        private System.Windows.Forms.ToolStripMenuItem MenuReportOrders;
        private System.Windows.Forms.ToolStripMenuItem MenuReportStockMovement;
        private System.Windows.Forms.ToolStripMenuItem MenuReportStockBalance;
        private System.Windows.Forms.ToolStripMenuItem MenuSystem;
        private System.Windows.Forms.ToolStripMenuItem MenuPlant;
        private System.Windows.Forms.ToolStripMenuItem MenuCloseProductionDate;
        private System.Windows.Forms.ToolStripMenuItem MenuSalesman;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem MenuReportOrderWithInvoice;
    }
}



