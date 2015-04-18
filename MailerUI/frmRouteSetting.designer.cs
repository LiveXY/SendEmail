namespace MailerUI {
    partial class frmRouteSetting {
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
            this.rdoPOST = new System.Windows.Forms.RadioButton();
            this.rdoGET = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripButton();
            this.txtRouteDisConnect = new System.Windows.Forms.TextBox();
            this.txtRouteConnect = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRouteIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoPOST);
            this.panel2.Controls.Add(this.rdoGET);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Controls.Add(this.txtRouteDisConnect);
            this.panel2.Controls.Add(this.txtRouteConnect);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtUserName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtRouteIP);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(816, 421);
            this.panel2.TabIndex = 0;
            // 
            // rdoPOST
            // 
            this.rdoPOST.AutoSize = true;
            this.rdoPOST.Location = new System.Drawing.Point(158, 322);
            this.rdoPOST.Name = "rdoPOST";
            this.rdoPOST.Size = new System.Drawing.Size(47, 16);
            this.rdoPOST.TabIndex = 4;
            this.rdoPOST.Text = "POST";
            this.rdoPOST.UseVisualStyleBackColor = true;
            // 
            // rdoGET
            // 
            this.rdoGET.AutoSize = true;
            this.rdoGET.Checked = true;
            this.rdoGET.Location = new System.Drawing.Point(99, 322);
            this.rdoGET.Name = "rdoGET";
            this.rdoGET.Size = new System.Drawing.Size(41, 16);
            this.rdoGET.TabIndex = 4;
            this.rdoGET.TabStop = true;
            this.rdoGET.Text = "GET";
            this.rdoGET.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.toolStripSeparator1,
            this.mnuExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(816, 25);
            this.toolStrip1.TabIndex = 3;
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
            // txtRouteDisConnect
            // 
            this.txtRouteDisConnect.Location = new System.Drawing.Point(98, 267);
            this.txtRouteDisConnect.Name = "txtRouteDisConnect";
            this.txtRouteDisConnect.Size = new System.Drawing.Size(374, 21);
            this.txtRouteDisConnect.TabIndex = 2;
            // 
            // txtRouteConnect
            // 
            this.txtRouteConnect.Location = new System.Drawing.Point(98, 223);
            this.txtRouteConnect.Name = "txtRouteConnect";
            this.txtRouteConnect.Size = new System.Drawing.Size(374, 21);
            this.txtRouteConnect.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(98, 177);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(374, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(478, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(281, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "TP-LINK：Reboot=%D6%D8%C6%F4%C2%B7%D3%C9%C6%F7";
            this.label9.DoubleClick += new System.EventHandler(this.label9_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(478, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(317, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "TP-LINK：http://192.168.0.1/userRpm/SysRebootRpm.htm";
            this.label8.DoubleClick += new System.EventHandler(this.label8_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "请求方式：";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(98, 136);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(374, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "断开参数：";
            // 
            // txtRouteIP
            // 
            this.txtRouteIP.Location = new System.Drawing.Point(98, 94);
            this.txtRouteIP.Name = "txtRouteIP";
            this.txtRouteIP.Size = new System.Drawing.Size(374, 21);
            this.txtRouteIP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "连接参数：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "登录密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "登录账号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "路由控制URL：";
            // 
            // frmRouteSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 431);
            this.Controls.Add(this.panel2);
            this.Name = "frmRouteSetting";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.TabText = "路由设置";
            this.Text = "路由设置";
            this.Activated += new System.EventHandler(this.frmRoute_Activated);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtRouteIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuExit;
        private System.Windows.Forms.TextBox txtRouteDisConnect;
        private System.Windows.Forms.TextBox txtRouteConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rdoPOST;
        private System.Windows.Forms.RadioButton rdoGET;
    }
}