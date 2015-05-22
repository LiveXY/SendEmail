namespace MailerUI {
    partial class frmAddSMTPList {
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSmtpServer = new System.Windows.Forms.TextBox();
            this.txtSmtpPort = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxStatus = new System.Windows.Forms.CheckBox();
            this.checkBoxSSL = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "SMTP服务器：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 109);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "SMTP端口：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 169);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "登录用户名：";
            // 
            // txtSmtpServer
            // 
            this.txtSmtpServer.Location = new System.Drawing.Point(153, 38);
            this.txtSmtpServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSmtpServer.Name = "txtSmtpServer";
            this.txtSmtpServer.Size = new System.Drawing.Size(475, 25);
            this.txtSmtpServer.TabIndex = 0;
            // 
            // txtSmtpPort
            // 
            this.txtSmtpPort.Location = new System.Drawing.Point(153, 99);
            this.txtSmtpPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSmtpPort.Name = "txtSmtpPort";
            this.txtSmtpPort.Size = new System.Drawing.Size(475, 25);
            this.txtSmtpPort.TabIndex = 1;
            this.txtSmtpPort.Text = "25";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(153, 161);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(475, 25);
            this.txtUserName.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 334);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(529, 334);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSPassword
            // 
            this.txtSPassword.Location = new System.Drawing.Point(153, 214);
            this.txtSPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSPassword.Name = "txtSPassword";
            this.txtSPassword.PasswordChar = '*';
            this.txtSPassword.Size = new System.Drawing.Size(475, 25);
            this.txtSPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 221);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "登录密码：";
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.AutoSize = true;
            this.checkBoxStatus.Checked = true;
            this.checkBoxStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStatus.Location = new System.Drawing.Point(345, 276);
            this.checkBoxStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxStatus.Name = "checkBoxStatus";
            this.checkBoxStatus.Size = new System.Drawing.Size(89, 19);
            this.checkBoxStatus.TabIndex = 5;
            this.checkBoxStatus.Text = "是否可用";
            this.checkBoxStatus.UseVisualStyleBackColor = true;
            // 
            // checkBoxSSL
            // 
            this.checkBoxSSL.AutoSize = true;
            this.checkBoxSSL.Location = new System.Drawing.Point(153, 276);
            this.checkBoxSSL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxSSL.Name = "checkBoxSSL";
            this.checkBoxSSL.Size = new System.Drawing.Size(113, 19);
            this.checkBoxSSL.TabIndex = 4;
            this.checkBoxSSL.Text = "是否支持SSL";
            this.checkBoxSSL.UseVisualStyleBackColor = true;
            // 
            // frmAddSMTPList
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 389);
            this.Controls.Add(this.checkBoxSSL);
            this.Controls.Add(this.checkBoxStatus);
            this.Controls.Add(this.txtSPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtSmtpPort);
            this.Controls.Add(this.txtSmtpServer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmAddSMTPList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "SMTP服务器";
            this.Text = "SMTP服务器";
            this.Load += new System.EventHandler(this.frmAddSMTPList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSmtpServer;
        private System.Windows.Forms.TextBox txtSmtpPort;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxStatus;
        private System.Windows.Forms.CheckBox checkBoxSSL;
    }
}