namespace MailerUI {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.操作OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTestSend = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTestIP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTestModel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTestTY = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.numTestGetIP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInportSMTP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInportEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.设置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRoute = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTY = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGetIP = new System.Windows.Forms.ToolStripMenuItem();
            this.查看VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewSMTP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.numViewIP = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusMsg = new System.Windows.Forms.StatusBarPanel();
            this.statusTime = new System.Windows.Forms.StatusBarPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusTime)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作OToolStripMenuItem,
            this.设置SToolStripMenuItem,
            this.查看VToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1284, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "操作(&O)";
            // 
            // 操作OToolStripMenuItem
            // 
            this.操作OToolStripMenuItem.AutoToolTip = true;
            this.操作OToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTestSend,
            this.mnuTestIP,
            this.mnuTestModel,
            this.mnuTestTY,
            this.toolStripSeparator5,
            this.numTestGetIP,
            this.toolStripSeparator2,
            this.mnuInportSMTP,
            this.mnuInportEmail,
            this.toolStripSeparator1,
            this.mnuStart,
            this.mnuStop,
            this.mnuReset,
            this.toolStripSeparator3,
            this.mnuExit});
            this.操作OToolStripMenuItem.Name = "操作OToolStripMenuItem";
            this.操作OToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.操作OToolStripMenuItem.Text = "操作(&O)";
            this.操作OToolStripMenuItem.ToolTipText = "操作";
            // 
            // mnuTestSend
            // 
            this.mnuTestSend.Name = "mnuTestSend";
            this.mnuTestSend.Size = new System.Drawing.Size(228, 24);
            this.mnuTestSend.Text = "测试群发邮件";
            this.mnuTestSend.ToolTipText = "测试群发邮件";
            this.mnuTestSend.Click += new System.EventHandler(this.mnuTestSend_Click);
            // 
            // mnuTestIP
            // 
            this.mnuTestIP.Name = "mnuTestIP";
            this.mnuTestIP.Size = new System.Drawing.Size(228, 24);
            this.mnuTestIP.Text = "测试路由连接";
            this.mnuTestIP.ToolTipText = "测试路由连接";
            this.mnuTestIP.Click += new System.EventHandler(this.mnuTestIP_Click);
            // 
            // mnuTestModel
            // 
            this.mnuTestModel.Name = "mnuTestModel";
            this.mnuTestModel.Size = new System.Drawing.Size(228, 24);
            this.mnuTestModel.Text = "测试拨号连接";
            this.mnuTestModel.ToolTipText = "测试拨号连接";
            this.mnuTestModel.Click += new System.EventHandler(this.mnuTestModel_Click);
            // 
            // mnuTestTY
            // 
            this.mnuTestTY.Name = "mnuTestTY";
            this.mnuTestTY.Size = new System.Drawing.Size(228, 24);
            this.mnuTestTY.Text = "测试天翼无线宽带连接";
            this.mnuTestTY.ToolTipText = "测试天翼无线宽带连接";
            this.mnuTestTY.Click += new System.EventHandler(this.mnuTestTY_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(225, 6);
            // 
            // numTestGetIP
            // 
            this.numTestGetIP.Name = "numTestGetIP";
            this.numTestGetIP.Size = new System.Drawing.Size(228, 24);
            this.numTestGetIP.Text = "测试获取IP地址";
            this.numTestGetIP.ToolTipText = "测试获取IP地址";
            this.numTestGetIP.Click += new System.EventHandler(this.numTestGetIP_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(225, 6);
            // 
            // mnuInportSMTP
            // 
            this.mnuInportSMTP.Name = "mnuInportSMTP";
            this.mnuInportSMTP.Size = new System.Drawing.Size(228, 24);
            this.mnuInportSMTP.Text = "导入SMTP列表";
            this.mnuInportSMTP.ToolTipText = "导入SMTP列表";
            this.mnuInportSMTP.Click += new System.EventHandler(this.mnuInportSMTP_Click);
            // 
            // mnuInportEmail
            // 
            this.mnuInportEmail.Name = "mnuInportEmail";
            this.mnuInportEmail.Size = new System.Drawing.Size(228, 24);
            this.mnuInportEmail.Text = "导入Email地址";
            this.mnuInportEmail.ToolTipText = "导入Email地址";
            this.mnuInportEmail.Click += new System.EventHandler(this.mnuInportEmail_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(225, 6);
            // 
            // mnuStart
            // 
            this.mnuStart.Name = "mnuStart";
            this.mnuStart.Size = new System.Drawing.Size(228, 24);
            this.mnuStart.Text = "安装群发邮件服务";
            this.mnuStart.ToolTipText = "安装群发邮件服务";
            this.mnuStart.Click += new System.EventHandler(this.mnuStart_Click);
            // 
            // mnuStop
            // 
            this.mnuStop.Name = "mnuStop";
            this.mnuStop.Size = new System.Drawing.Size(228, 24);
            this.mnuStop.Text = "卸载群发邮件服务";
            this.mnuStop.ToolTipText = "卸载群发邮件服务";
            this.mnuStop.Click += new System.EventHandler(this.mnuStop_Click);
            // 
            // mnuReset
            // 
            this.mnuReset.Name = "mnuReset";
            this.mnuReset.Size = new System.Drawing.Size(228, 24);
            this.mnuReset.Text = "重启群发邮件服务";
            this.mnuReset.ToolTipText = "重启群发邮件服务";
            this.mnuReset.Click += new System.EventHandler(this.mnuReset_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(225, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(228, 24);
            this.mnuExit.Text = "退出";
            this.mnuExit.ToolTipText = "退出";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // 设置SToolStripMenuItem
            // 
            this.设置SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetting,
            this.mnuRoute,
            this.mnuModel,
            this.mnuTY,
            this.toolStripSeparator4,
            this.mnuTemplate,
            this.mnuGetIP});
            this.设置SToolStripMenuItem.Name = "设置SToolStripMenuItem";
            this.设置SToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.设置SToolStripMenuItem.Text = "设置(&S)";
            this.设置SToolStripMenuItem.ToolTipText = "设置";
            // 
            // mnuSetting
            // 
            this.mnuSetting.Name = "mnuSetting";
            this.mnuSetting.Size = new System.Drawing.Size(212, 24);
            this.mnuSetting.Text = "发送邮件设置";
            this.mnuSetting.ToolTipText = "发送邮件设置";
            this.mnuSetting.Click += new System.EventHandler(this.mnuSetting_Click);
            // 
            // mnuRoute
            // 
            this.mnuRoute.Name = "mnuRoute";
            this.mnuRoute.Size = new System.Drawing.Size(212, 24);
            this.mnuRoute.Text = "路由设置";
            this.mnuRoute.ToolTipText = "路由设置";
            this.mnuRoute.Click += new System.EventHandler(this.mnuRoute_Click);
            // 
            // mnuModel
            // 
            this.mnuModel.Name = "mnuModel";
            this.mnuModel.Size = new System.Drawing.Size(212, 24);
            this.mnuModel.Text = "拨号设置";
            this.mnuModel.ToolTipText = "拨号设置";
            this.mnuModel.Click += new System.EventHandler(this.mnuModel_Click);
            // 
            // mnuTY
            // 
            this.mnuTY.Name = "mnuTY";
            this.mnuTY.Size = new System.Drawing.Size(212, 24);
            this.mnuTY.Text = "天翼无线宽带设置";
            this.mnuTY.ToolTipText = "天翼无线宽带设置";
            this.mnuTY.Click += new System.EventHandler(this.mnuTY_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(209, 6);
            // 
            // mnuTemplate
            // 
            this.mnuTemplate.Name = "mnuTemplate";
            this.mnuTemplate.Size = new System.Drawing.Size(212, 24);
            this.mnuTemplate.Text = "模版管理";
            this.mnuTemplate.ToolTipText = "模版管理";
            this.mnuTemplate.Click += new System.EventHandler(this.mnuTemplate_Click);
            // 
            // mnuGetIP
            // 
            this.mnuGetIP.Name = "mnuGetIP";
            this.mnuGetIP.Size = new System.Drawing.Size(212, 24);
            this.mnuGetIP.Text = "获取公网ip网址管理";
            this.mnuGetIP.ToolTipText = "获取公网ip网址管理";
            this.mnuGetIP.Click += new System.EventHandler(this.mnuGetIP_Click);
            // 
            // 查看VToolStripMenuItem
            // 
            this.查看VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewSMTP,
            this.mnuViewEmail,
            this.numViewIP,
            this.testToolStripMenuItem,
            this.test2ToolStripMenuItem});
            this.查看VToolStripMenuItem.Name = "查看VToolStripMenuItem";
            this.查看VToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.查看VToolStripMenuItem.Text = "查看(V)";
            this.查看VToolStripMenuItem.ToolTipText = "查看";
            // 
            // mnuViewSMTP
            // 
            this.mnuViewSMTP.Name = "mnuViewSMTP";
            this.mnuViewSMTP.Size = new System.Drawing.Size(226, 24);
            this.mnuViewSMTP.Text = "查看SMTP列表";
            this.mnuViewSMTP.ToolTipText = "查看SMTP列表";
            this.mnuViewSMTP.Click += new System.EventHandler(this.mnuViewSMTP_Click);
            // 
            // mnuViewEmail
            // 
            this.mnuViewEmail.Name = "mnuViewEmail";
            this.mnuViewEmail.Size = new System.Drawing.Size(226, 24);
            this.mnuViewEmail.Text = "查看Email列表";
            this.mnuViewEmail.ToolTipText = "查看Email列表";
            this.mnuViewEmail.Click += new System.EventHandler(this.mnuViewEmail_Click);
            // 
            // numViewIP
            // 
            this.numViewIP.Name = "numViewIP";
            this.numViewIP.Size = new System.Drawing.Size(226, 24);
            this.numViewIP.Text = "查看最近使用的IP列表";
            this.numViewIP.ToolTipText = "查看最近使用的IP列表";
            this.numViewIP.Click += new System.EventHandler(this.numViewIP_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(226, 24);
            this.testToolStripMenuItem.Text = "test1";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // test2ToolStripMenuItem
            // 
            this.test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            this.test2ToolStripMenuItem.Size = new System.Drawing.Size(226, 24);
            this.test2ToolStripMenuItem.Text = "test2";
            this.test2ToolStripMenuItem.Click += new System.EventHandler(this.test2ToolStripMenuItem_Click);
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.AllowEndUserDocking = false;
            this.dockPanel.AllowEndUserNestedDocking = false;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockLeftPortion = 0.15D;
            this.dockPanel.Location = new System.Drawing.Point(0, 28);
            this.dockPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(1284, 767);
            this.dockPanel.TabIndex = 14;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 795);
            this.statusBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusMsg,
            this.statusTime});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(1284, 30);
            this.statusBar.TabIndex = 20;
            // 
            // statusMsg
            // 
            this.statusMsg.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusMsg.Name = "statusMsg";
            this.statusMsg.ToolTipText = "显示消息";
            this.statusMsg.Width = 1013;
            // 
            // statusTime
            // 
            this.statusTime.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusTime.Name = "statusTime";
            this.statusTime.ToolTipText = "显示时间";
            this.statusTime.Width = 250;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 825);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "邮件群发";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 操作OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTestSend;
        private System.Windows.Forms.ToolStripMenuItem mnuTestIP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuInportSMTP;
        private System.Windows.Forms.ToolStripMenuItem mnuInportEmail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuStart;
        private System.Windows.Forms.ToolStripMenuItem mnuStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem 设置SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSetting;
        private System.Windows.Forms.ToolStripMenuItem mnuRoute;
        private System.Windows.Forms.ToolStripMenuItem mnuTemplate;
        private System.Windows.Forms.ToolStripMenuItem 查看VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuViewSMTP;
        private System.Windows.Forms.ToolStripMenuItem mnuViewEmail;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStripMenuItem mnuTestModel;
        private System.Windows.Forms.ToolStripMenuItem mnuModel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuGetIP;
        private System.Windows.Forms.ToolStripMenuItem numViewIP;
        private System.Windows.Forms.ToolStripMenuItem numTestGetIP;
        private System.Windows.Forms.ToolStripMenuItem mnuTY;
        private System.Windows.Forms.ToolStripMenuItem mnuTestTY;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuReset;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem test2ToolStripMenuItem;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.StatusBarPanel statusMsg;
        private System.Windows.Forms.StatusBarPanel statusTime;
    }
}