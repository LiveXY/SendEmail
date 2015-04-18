namespace MailerUI {
    partial class frmSendSetting {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTemplate = new System.Windows.Forms.ComboBox();
            this.txtSendInterval = new System.Windows.Forms.TextBox();
            this.txtIPInterval = new System.Windows.Forms.TextBox();
            this.txtSmtpInterval = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripButton();
            this.rdoRoute = new System.Windows.Forms.RadioButton();
            this.rdoModel = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDeleteInterval = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaxRetryCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.rdoTY = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSendRetryCount = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择连接：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "请选择发送主题：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "发送邮件时间间隔(毫秒)：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "发送多少封邮件后更换IP：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "发送多少封邮件后更换SMTP：";
            // 
            // cboTemplate
            // 
            this.cboTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemplate.FormattingEnabled = true;
            this.cboTemplate.Location = new System.Drawing.Point(196, 83);
            this.cboTemplate.Name = "cboTemplate";
            this.cboTemplate.Size = new System.Drawing.Size(357, 20);
            this.cboTemplate.TabIndex = 0;
            // 
            // txtSendInterval
            // 
            this.txtSendInterval.Location = new System.Drawing.Point(196, 178);
            this.txtSendInterval.Name = "txtSendInterval";
            this.txtSendInterval.Size = new System.Drawing.Size(357, 21);
            this.txtSendInterval.TabIndex = 3;
            this.txtSendInterval.Text = "1000";
            // 
            // txtIPInterval
            // 
            this.txtIPInterval.Location = new System.Drawing.Point(196, 227);
            this.txtIPInterval.Name = "txtIPInterval";
            this.txtIPInterval.Size = new System.Drawing.Size(357, 21);
            this.txtIPInterval.TabIndex = 4;
            this.txtIPInterval.Text = "100";
            // 
            // txtSmtpInterval
            // 
            this.txtSmtpInterval.Location = new System.Drawing.Point(196, 277);
            this.txtSmtpInterval.Name = "txtSmtpInterval";
            this.txtSmtpInterval.Size = new System.Drawing.Size(357, 21);
            this.txtSmtpInterval.TabIndex = 5;
            this.txtSmtpInterval.Text = "10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 487);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "状态：";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(196, 482);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(357, 20);
            this.cboStatus.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.toolStripSeparator1,
            this.mnuExit});
            this.toolStrip1.Location = new System.Drawing.Point(5, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(616, 25);
            this.toolStrip1.TabIndex = 4;
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
            // mnuExit
            // 
            this.mnuExit.Image = global::MailerUI.Properties.Resources.exit;
            this.mnuExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(73, 22);
            this.mnuExit.Text = "关闭窗口";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // rdoRoute
            // 
            this.rdoRoute.AutoSize = true;
            this.rdoRoute.Checked = true;
            this.rdoRoute.Location = new System.Drawing.Point(196, 133);
            this.rdoRoute.Name = "rdoRoute";
            this.rdoRoute.Size = new System.Drawing.Size(95, 16);
            this.rdoRoute.TabIndex = 1;
            this.rdoRoute.TabStop = true;
            this.rdoRoute.Text = "使用路由连接";
            this.rdoRoute.UseVisualStyleBackColor = true;
            // 
            // rdoModel
            // 
            this.rdoModel.AutoSize = true;
            this.rdoModel.Location = new System.Drawing.Point(324, 133);
            this.rdoModel.Name = "rdoModel";
            this.rdoModel.Size = new System.Drawing.Size(95, 16);
            this.rdoModel.TabIndex = 2;
            this.rdoModel.Text = "使用拨号连接";
            this.rdoModel.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "清理多少分钟之前的历史IP：";
            // 
            // txtDeleteInterval
            // 
            this.txtDeleteInterval.Location = new System.Drawing.Point(196, 327);
            this.txtDeleteInterval.Name = "txtDeleteInterval";
            this.txtDeleteInterval.Size = new System.Drawing.Size(357, 21);
            this.txtDeleteInterval.TabIndex = 5;
            this.txtDeleteInterval.Text = "60";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 384);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "检测网络连接重试次数：";
            // 
            // txtMaxRetryCount
            // 
            this.txtMaxRetryCount.Location = new System.Drawing.Point(196, 379);
            this.txtMaxRetryCount.Name = "txtMaxRetryCount";
            this.txtMaxRetryCount.Size = new System.Drawing.Size(357, 21);
            this.txtMaxRetryCount.TabIndex = 5;
            this.txtMaxRetryCount.Text = "10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(559, 384);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "次";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(559, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "分钟";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(559, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "封";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(559, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "封";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(559, 184);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "毫秒";
            // 
            // rdoTY
            // 
            this.rdoTY.AutoSize = true;
            this.rdoTY.Location = new System.Drawing.Point(441, 133);
            this.rdoTY.Name = "rdoTY";
            this.rdoTY.Size = new System.Drawing.Size(119, 16);
            this.rdoTY.TabIndex = 2;
            this.rdoTY.Text = "天翼无线宽带连接";
            this.rdoTY.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(559, 433);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "次";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(52, 433);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(137, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "发送邮件失败重试次数：";
            // 
            // txtSendRetryCount
            // 
            this.txtSendRetryCount.Location = new System.Drawing.Point(196, 428);
            this.txtSendRetryCount.Name = "txtSendRetryCount";
            this.txtSendRetryCount.Size = new System.Drawing.Size(357, 21);
            this.txtSendRetryCount.TabIndex = 5;
            this.txtSendRetryCount.Text = "10";
            // 
            // frmSendSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 554);
            this.Controls.Add(this.rdoTY);
            this.Controls.Add(this.rdoModel);
            this.Controls.Add(this.rdoRoute);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtSendRetryCount);
            this.Controls.Add(this.txtMaxRetryCount);
            this.Controls.Add(this.txtDeleteInterval);
            this.Controls.Add(this.txtSmtpInterval);
            this.Controls.Add(this.txtIPInterval);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtSendInterval);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboTemplate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSendSetting";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "发送邮件设置";
            this.Text = "发送邮件设置";
            this.Activated += new System.EventHandler(this.frmSendSetting_Activated);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTemplate;
        private System.Windows.Forms.TextBox txtSendInterval;
        private System.Windows.Forms.TextBox txtIPInterval;
        private System.Windows.Forms.TextBox txtSmtpInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuExit;
        private System.Windows.Forms.RadioButton rdoRoute;
        private System.Windows.Forms.RadioButton rdoModel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDeleteInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaxRetryCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rdoTY;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSendRetryCount;
    }
}