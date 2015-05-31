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

namespace MailerUI {
	public partial class frmAddEmailList : DockContent {
		private string email = "";

		public frmAddEmailList(string email = "") {
			this.email = email;
			InitializeComponent();
		}
		private void frmAddEmailList_Load(object sender, EventArgs e) {
			if (!email.IsNullEmpty()) LoadEditData();
		}

		private void LoadEditData() {
			EmailList info = EmailListHelper.SelectByID(email);
			if (info.IsNull() || info.EmailAddress.IsNull()) return;
			txtEmailAddress.Text = info.EmailAddress.ToString();
			txtNickName.Text = info.NickName.ToString();
			txtex0.Text = info.ex0;
			txtex1.Text = info.ex1;
			txtex2.Text = info.ex2;
			txtex3.Text = info.ex3;
			txtex4.Text = info.ex4;
			txtex5.Text = info.ex5;
			txtex6.Text = info.ex6;
			txtex7.Text = info.ex7;
			txtex8.Text = info.ex8;
			txtError.Text = info.LastSendError;
			//checkBoxStatus.Checked = info.LastSendStatus == 0 ? true : false;
			txtEmailAddress.Enabled = false;
		}

		private void button1_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(this.txtEmailAddress.Text)) {
				MessageBox.Show("发送的Email不能为空", "系统提示");
				return;
			}

			DialogResult = System.Windows.Forms.DialogResult.OK;

			EmailList info = new EmailList();

			info.EmailAddress = this.txtEmailAddress.Text;
			info.NickName = this.txtNickName.Text;
			if (info.NickName.IsNullEmpty()) info.NickName = info.EmailAddress.Split('@')[0];
			info.ex0 = this.txtex0.Text;
			info.ex1 = this.txtex1.Text;
			info.ex2 = this.txtex2.Text;
			info.ex3 = this.txtex3.Text;
			info.ex4 = this.txtex4.Text;
			info.ex5 = this.txtex5.Text;
			info.ex6 = this.txtex6.Text;
			info.ex7 = this.txtex7.Text;
			info.ex8 = this.txtex8.Text;
			info.LastSendError = txtError.Text;
			//info.LastSendStatus = this.checkBoxStatus.Checked ? 0 : 1;

			if (!email.IsNullEmpty() || EmailListHelper.IsExistByID(info.EmailAddress)) {
				EmailListHelper.Update(info);
			} else {
				info.CreateTime = DateTime.Now.ToDateTime().ToDateTime();
				EmailListHelper.Insert(info);
			}
			EmailListHelper.ClearCacheAll();

			MessageBox.Show("保存数据成功！", " 系统提示");
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
