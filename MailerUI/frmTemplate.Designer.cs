namespace MailerUI {
    partial class frmTemplate {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShowName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripButton();
            this.checkBoxStatus = new System.Windows.Forms.CheckBox();
            this.checkBoxIsHTML = new System.Windows.Forms.CheckBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 683);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView.RowHeadersWidth = 33;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(217, 681);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.VirtualMode = true;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtShowName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Controls.Add(this.checkBoxStatus);
            this.panel2.Controls.Add(this.checkBoxIsHTML);
            this.panel2.Controls.Add(this.txtSubject);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(227, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(777, 136);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "发件人名称：";
            // 
            // txtShowName
            // 
            this.txtShowName.Location = new System.Drawing.Point(88, 102);
            this.txtShowName.Name = "txtShowName";
            this.txtShowName.Size = new System.Drawing.Size(395, 21);
            this.txtShowName.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(490, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(617, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "注意：邮件主题和正文可包含如下标记{email},{name},{ex0},{ex1},{ex2},{ex3},{ex4},{ex5},{ex6},{ex7},{" +
                "ex8}";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.toolStripSeparator1,
            this.mnuAdd,
            this.toolStripSeparator2,
            this.mnuDelete,
            this.toolStripSeparator3,
            this.mnuExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(777, 25);
            this.toolStrip1.TabIndex = 41;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::MailerUI.Properties.Resources.edit16;
            this.mnuEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(73, 22);
            this.mnuEdit.Text = "保存数据";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Image = global::MailerUI.Properties.Resources.add16;
            this.mnuAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(73, 22);
            this.mnuAdd.Text = "添加数据";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::MailerUI.Properties.Resources.delete16;
            this.mnuDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(73, 22);
            this.mnuDelete.Text = "删除数据";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = global::MailerUI.Properties.Resources.exit;
            this.mnuExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(73, 22);
            this.mnuExit.Text = "关闭窗口";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.AutoSize = true;
            this.checkBoxStatus.Checked = true;
            this.checkBoxStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStatus.Location = new System.Drawing.Point(211, 72);
            this.checkBoxStatus.Name = "checkBoxStatus";
            this.checkBoxStatus.Size = new System.Drawing.Size(72, 16);
            this.checkBoxStatus.TabIndex = 2;
            this.checkBoxStatus.Text = "是否可用";
            this.checkBoxStatus.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsHTML
            // 
            this.checkBoxIsHTML.AutoSize = true;
            this.checkBoxIsHTML.Checked = true;
            this.checkBoxIsHTML.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsHTML.Location = new System.Drawing.Point(88, 72);
            this.checkBoxIsHTML.Name = "checkBoxIsHTML";
            this.checkBoxIsHTML.Size = new System.Drawing.Size(96, 16);
            this.checkBoxIsHTML.TabIndex = 1;
            this.checkBoxIsHTML.Text = "使用HTML格式";
            this.checkBoxIsHTML.UseVisualStyleBackColor = true;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(88, 38);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(395, 21);
            this.txtSubject.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "邮件主题：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(227, 141);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(777, 547);
            this.tabControl1.TabIndex = 44;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtBody);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(769, 522);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "邮件正文";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtBody
            // 
            this.txtBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBody.Location = new System.Drawing.Point(2, 2);
            this.txtBody.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(765, 518);
            this.txtBody.TabIndex = 3;
            this.txtBody.DoubleClick += new System.EventHandler(this.txtBody_DoubleClick);
            this.txtBody.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBody_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(769, 548);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "预览效果";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(2, 2);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(15, 16);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(766, 546);
            this.webBrowser1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(224, 5);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 683);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(489, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 44;
            this.label3.Text = "如：公司名称";
            // 
            // frmTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 693);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "frmTemplate";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.TabText = "模版管理";
            this.Text = "模版管理";
            this.Load += new System.EventHandler(this.frmTemplate_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.CheckBox checkBoxIsHTML;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxStatus;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton mnuExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShowName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}