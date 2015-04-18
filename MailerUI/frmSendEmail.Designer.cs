namespace MailerUI {
    partial class frmSendEmail {
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(5, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(626, 553);
            this.listBox1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStart,
            this.toolStripSeparator2,
            this.btnStop,
            this.toolStripSeparator3,
            this.mnuExit});
            this.toolStrip1.Location = new System.Drawing.Point(5, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(626, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnStart
            // 
            this.btnStart.Image = global::MailerUI.Properties.Resources.add16;
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 22);
            this.btnStart.Text = "开始发送";
            this.btnStart.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnStop
            // 
            this.btnStop.Image = global::MailerUI.Properties.Resources.delete16;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(73, 22);
            this.btnStop.Text = "停止发送";
            this.btnStop.Click += new System.EventHandler(this.mnuDelete_Click);
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
            // frmSendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 588);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSendEmail";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.TabText = "测试群发邮件";
            this.Text = "测试群发邮件";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSendEmail_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton mnuExit;
    }
}