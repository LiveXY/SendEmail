using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using TH.Mailer.Helper;
using Pub.Class;
using Pub.Class.Linq;
using TH.Mailer.Entity;
using TH.Mailer;
namespace MailerUI {
    public partial class frmAddSMTPList : DockContent {
        private string smtp = "";
        private int port = 0;
        private string user = "";

        public frmAddSMTPList(string smtp = "", int port = 0, string user = "") {
            this.smtp = smtp;
            this.port = port;
            this.user = user;
            InitializeComponent();
        }

        private void frmAddSMTPList_Load(object sender, EventArgs e) {
            if (!smtp.IsNullEmpty()) LoadEditData();
        }

        private void LoadEditData() {
            SmtpList info = SmtpListHelper.SelectByID(smtp, port, user);
            if (info.IsNull() || info.SmtpServer.IsNull()) return;
            txtSmtpServer.Text = info.SmtpServer.ToString();
            txtSmtpPort.Text = info.SmtpPort.ToString();
            txtUserName.Text = info.UserName.ToString();
            txtSPassword.Text = info.SPassword.ToString();
            checkBoxSSL.Checked = info.SSL == true ? true : false;
            checkBoxStatus.Checked = info.Status == 0 ? true : false;

            txtSmtpServer.Enabled = false;
            txtSmtpPort.Enabled = false;
            txtUserName.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e) {

            if (string.IsNullOrEmpty(this.txtSmtpServer.Text)) {
                MessageBox.Show("SMTP服务器不能为空", "系统提示");
                return;
            }
            if (string.IsNullOrEmpty(this.txtSmtpPort.Text)) {
                MessageBox.Show("SMTP服务器端口不能为空", "系统提示");
                return;
            }
            if (string.IsNullOrEmpty(this.txtUserName.Text)) {
                MessageBox.Show("登录用户名不能为空", "系统提示");
                return;
            } 

            SmtpList info = new SmtpList();
            info.SmtpServer = this.txtSmtpServer.Text;
            info.SmtpPort = this.txtSmtpPort.Text.ToInt(25);
            info.UserName = this.txtUserName.Text;
            info.SPassword = this.txtSPassword.Text;
            info.SSL = this.checkBoxSSL.Checked;
            info.Status = this.checkBoxStatus.Checked == true ? 0 : 1;

            //bool isTrue = NetHelper.CheckSMTP(info.UserName, info.SPassword, info.SmtpServer);
            //if (!isTrue) {
            //    MessageBox.Show("无法连接SMTP服务器，请检查用户名和密码是否正确和账号是否被封。", " 系统提示");
            //    return;
            //}

            //DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;

            if (!smtp.IsNullEmpty() || SmtpListHelper.IsExistByID(info.SmtpServer, info.SmtpPort.Value, info.UserName)) {
                SmtpListHelper.Update(info);
            } else {
                info.CreateTime = DateTime.Now;
                SmtpListHelper.Insert(info);
            }
            SmtpListHelper.ClearCacheAll();

            MessageBox.Show("保存数据成功!", " 系统提示");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
