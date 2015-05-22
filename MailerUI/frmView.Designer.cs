namespace MailerUI {
    partial class frmView {
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listView1 = new MailerUI.ListViewEx();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.mnuPrev = new System.Windows.Forms.ToolStripButton();
            this.mnuNext = new System.Windows.Forms.ToolStripButton();
            this.mnuAdd = new System.Windows.Forms.ToolStripButton();
            this.mnuEdit = new System.Windows.Forms.ToolStripButton();
            this.mnuSelectAll = new System.Windows.Forms.ToolStripButton();
            this.mnuDelete = new System.Windows.Forms.ToolStripButton();
            this.mnuDeleteAll = new System.Windows.Forms.ToolStripButton();
            this.mnuEnable = new System.Windows.Forms.ToolStripButton();
            this.mnuDisable = new System.Windows.Forms.ToolStripButton();
            this.mnuExport = new System.Windows.Forms.ToolStripButton();
            this.mnuRefresh = new System.Windows.Forms.ToolStripButton();
            this.mnuSearch = new System.Windows.Forms.ToolStripButton();
            this.mnuExit = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(7, 34);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1302, 699);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listView1);
            this.panel3.Controls.Add(this.toolStrip2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1302, 699);
            this.panel3.TabIndex = 4;
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.AllowFileDragDrop = false;
            this.listView1.AutoFillColumnIndex = -1;
            this.listView1.AutoFillColumnMinWidth = -1;
            this.listView1.CheckBoxes = true;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.DoubleClickActivation = false;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1302, 672);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.mnuPrev,
            this.mnuNext});
            this.toolStrip2.Location = new System.Drawing.Point(0, 672);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1302, 27);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(122, 24);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuEdit,
            this.toolStripSeparator3,
            this.mnuSelectAll,
            this.mnuDelete,
            this.mnuDeleteAll,
            this.mnuEnable,
            this.mnuDisable,
            this.toolStripSeparator6,
            this.mnuExport,
            this.toolStripSeparator7,
            this.mnuRefresh,
            this.toolStripSeparator8,
            this.mnu,
            this.toolStripLabel2,
            this.toolStripComboBox1,
            this.mnuSearch,
            this.toolStripSeparator9,
            this.mnuExit});
            this.toolStrip1.Location = new System.Drawing.Point(7, 6);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1302, 28);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 28);
            // 
            // mnu
            // 
            this.mnu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(0, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(39, 25);
            this.toolStripLabel2.Text = "状态";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "全部",
            "等待发送",
            "发送成功",
            "发送失败"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 28);
            // 
            // mnuPrev
            // 
            this.mnuPrev.Image = global::MailerUI.Properties.Resources.pre1;
            this.mnuPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPrev.Name = "mnuPrev";
            this.mnuPrev.Size = new System.Drawing.Size(74, 24);
            this.mnuPrev.Text = "上一页";
            this.mnuPrev.Click += new System.EventHandler(this.mnuPrev_Click);
            // 
            // mnuNext
            // 
            this.mnuNext.Image = global::MailerUI.Properties.Resources.next;
            this.mnuNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuNext.Name = "mnuNext";
            this.mnuNext.Size = new System.Drawing.Size(74, 24);
            this.mnuNext.Text = "下一页";
            this.mnuNext.Click += new System.EventHandler(this.mnuNext_Click);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Image = global::MailerUI.Properties.Resources.add16;
            this.mnuAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(89, 25);
            this.mnuAdd.Text = "添加数据";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::MailerUI.Properties.Resources.edit16;
            this.mnuEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(89, 25);
            this.mnuEdit.Text = "修改数据";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Image = global::MailerUI.Properties.Resources.accept16;
            this.mnuSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSelectAll.Name = "mnuSelectAll";
            this.mnuSelectAll.Size = new System.Drawing.Size(59, 25);
            this.mnuSelectAll.Text = "全选";
            this.mnuSelectAll.Click += new System.EventHandler(this.mnuSelectAll_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::MailerUI.Properties.Resources.delete16;
            this.mnuDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(89, 25);
            this.mnuDelete.Text = "删除选中";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuDeleteAll
            // 
            this.mnuDeleteAll.Image = global::MailerUI.Properties.Resources.cancel16;
            this.mnuDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDeleteAll.Name = "mnuDeleteAll";
            this.mnuDeleteAll.Size = new System.Drawing.Size(89, 25);
            this.mnuDeleteAll.Text = "删除全部";
            this.mnuDeleteAll.Click += new System.EventHandler(this.mnuDeleteAll_Click);
            // 
            // mnuEnable
            // 
            this.mnuEnable.Image = global::MailerUI.Properties.Resources.enable;
            this.mnuEnable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuEnable.Name = "mnuEnable";
            this.mnuEnable.Size = new System.Drawing.Size(89, 25);
            this.mnuEnable.Text = "批量可用";
            this.mnuEnable.Click += new System.EventHandler(this.mnuEnable_Click);
            // 
            // mnuDisable
            // 
            this.mnuDisable.Image = global::MailerUI.Properties.Resources.disable;
            this.mnuDisable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDisable.Name = "mnuDisable";
            this.mnuDisable.Size = new System.Drawing.Size(104, 25);
            this.mnuDisable.Text = "批量不可用";
            this.mnuDisable.Click += new System.EventHandler(this.mnuDisable_Click);
            // 
            // mnuExport
            // 
            this.mnuExport.Image = global::MailerUI.Properties.Resources.app2;
            this.mnuExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Size = new System.Drawing.Size(119, 25);
            this.mnuExport.Text = "导出邮件列表";
            this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Image = global::MailerUI.Properties.Resources.refresh16;
            this.mnuRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(59, 25);
            this.mnuRefresh.Text = "刷新";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // mnuSearch
            // 
            this.mnuSearch.Image = global::MailerUI.Properties.Resources.view16_16;
            this.mnuSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSearch.Name = "mnuSearch";
            this.mnuSearch.Size = new System.Drawing.Size(59, 25);
            this.mnuSearch.Text = "查询";
            this.mnuSearch.Click += new System.EventHandler(this.mnuSearch_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = global::MailerUI.Properties.Resources.exit;
            this.mnuExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(89, 25);
            this.mnuExit.Text = "关闭窗口";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 739);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmView";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TabText = "frmView";
            this.Text = "frmView";
            this.Load += new System.EventHandler(this.frmView_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuExit;
        private System.Windows.Forms.ToolStripLabel mnu;
        private System.Windows.Forms.ToolStripButton mnuEdit;
        private System.Windows.Forms.ToolStripButton mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton mnuAdd;
        private ListViewEx listView1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton mnuSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton mnuRefresh;
        private System.Windows.Forms.ToolStripButton mnuDeleteAll;
        private System.Windows.Forms.ToolStripButton mnuExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton mnuSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton mnuEnable;
        private System.Windows.Forms.ToolStripButton mnuDisable;
        private System.Windows.Forms.ToolStripButton mnuPrev;
        private System.Windows.Forms.ToolStripButton mnuNext;
    }
}