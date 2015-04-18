namespace MailerUI {
    partial class frmAddIpSetting {
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
            this.txtWebName = new System.Windows.Forms.TextBox();
            this.txtIPUrl = new System.Windows.Forms.TextBox();
            this.txtIPRegex = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtDataEncode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "网址名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "获取IP的网址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "获取IP的正则：";
            // 
            // txtWebName
            // 
            this.txtWebName.Location = new System.Drawing.Point(153, 41);
            this.txtWebName.Margin = new System.Windows.Forms.Padding(4);
            this.txtWebName.Name = "txtWebName";
            this.txtWebName.Size = new System.Drawing.Size(475, 25);
            this.txtWebName.TabIndex = 0;
            // 
            // txtIPUrl
            // 
            this.txtIPUrl.Location = new System.Drawing.Point(153, 102);
            this.txtIPUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPUrl.Name = "txtIPUrl";
            this.txtIPUrl.Size = new System.Drawing.Size(475, 25);
            this.txtIPUrl.TabIndex = 1;
            // 
            // txtIPRegex
            // 
            this.txtIPRegex.Location = new System.Drawing.Point(153, 165);
            this.txtIPRegex.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPRegex.Name = "txtIPRegex";
            this.txtIPRegex.Size = new System.Drawing.Size(475, 25);
            this.txtIPRegex.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 292);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(529, 292);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtDataEncode
            // 
            this.txtDataEncode.Location = new System.Drawing.Point(153, 230);
            this.txtDataEncode.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataEncode.Name = "txtDataEncode";
            this.txtDataEncode.Size = new System.Drawing.Size(475, 25);
            this.txtDataEncode.TabIndex = 3;
            this.txtDataEncode.Text = "utf-8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 236);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "使用编码：";
            // 
            // frmAddIpSetting
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 358);
            this.Controls.Add(this.txtDataEncode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtIPRegex);
            this.Controls.Add(this.txtIPUrl);
            this.Controls.Add(this.txtWebName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmAddIpSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "获取公网ip网址管理";
            this.Text = "获取公网ip网址管理";
            this.Load += new System.EventHandler(this.frmAddSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWebName;
        private System.Windows.Forms.TextBox txtIPUrl;
        private System.Windows.Forms.TextBox txtIPRegex;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtDataEncode;
        private System.Windows.Forms.Label label1;
    }
}