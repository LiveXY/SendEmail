namespace MailerUI {
    partial class frmIpSetting {
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnModify = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.序号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.网址名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.获取IP的网址 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.获取IP的正则 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.使用编码 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnModify,
            this.btnDel,
            this.toolStripSeparator1,
            this.mnuExit});
            this.toolStrip1.Location = new System.Drawing.Point(7, 6);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1546, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::MailerUI.Properties.Resources.add16;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(103, 24);
            this.btnAdd.Text = "增加Ip配置";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.Image = global::MailerUI.Properties.Resources.edit16;
            this.btnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(103, 24);
            this.btnModify.Text = "修改Ip配置";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = global::MailerUI.Properties.Resources.delete16;
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(103, 24);
            this.btnDel.Text = "删除Ip配置";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = global::MailerUI.Properties.Resources.exit;
            this.mnuExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(89, 24);
            this.mnuExit.Text = "关闭窗口";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.序号,
            this.网址名称,
            this.获取IP的网址,
            this.获取IP的正则,
            this.使用编码});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(7, 33);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1546, 626);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // 序号
            // 
            this.序号.Text = "序号";
            // 
            // 网址名称
            // 
            this.网址名称.Text = "网址名称";
            this.网址名称.Width = 434;
            // 
            // 获取IP的网址
            // 
            this.获取IP的网址.Text = "获取IP的网址";
            this.获取IP的网址.Width = 277;
            // 
            // 获取IP的正则
            // 
            this.获取IP的正则.Text = "获取IP的正则";
            this.获取IP的正则.Width = 431;
            // 
            // 使用编码
            // 
            this.使用编码.Text = "使用编码";
            this.使用编码.Width = 296;
            // 
            // frmIpSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1560, 665);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmIpSetting";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TabText = "获取公网ip网址管理";
            this.Text = "获取公网ip网址管理";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnModify;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 网址名称;
        private System.Windows.Forms.ColumnHeader 获取IP的网址;
        private System.Windows.Forms.ColumnHeader 获取IP的正则;
        private System.Windows.Forms.ToolStripButton mnuExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ColumnHeader 序号;
        private System.Windows.Forms.ColumnHeader 使用编码;


    }
}