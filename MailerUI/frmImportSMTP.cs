using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TH.Mailer;
using Pub.Class;
using Pub.Class.Linq;
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;
using TH.Mailer.Entity;
using TH.Mailer.Helper;

namespace MailerUI {
	public partial class frmImportSMTP : DockContent {
		private Thread thread;
		private string fileName;

		public frmImportSMTP() {
			InitializeComponent();
			frmMain.Instance.ControlsHint(this);
		}

		private void btnStart_Click(object sender, EventArgs e) {
			btnStart.Enabled = false;
			openFileDialog1.InitialDirectory = ".\\";
			openFileDialog1.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;
			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				fileName = openFileDialog1.FileName;
				if (!thread.IsNull()) { thread.Abort(); }
				thread = new Thread(inportSmtpList);
				thread.IsBackground = true;
				thread.Start();
			}
		}

		private void inportSmtpList(object o) {
			int totals = 0; int success = 0;
			WriteLog("");
			WriteLog("正在读取数据.....");
			IList<string> data = FileDirectory.FileRead(fileName, FileDirectory.FileEncoding(fileName));
			totals = data.Count;
			WriteLog("读取到：" + totals + " 行记录！");

			WriteLog("正在导入数据.....");
			int index = 1;
			int port = 25;
			foreach (string str in data) {
				string[] list = str.Split(',');
				if (list.Length != 3) {
					WriteLog("第" + index.ToString() + "行数据格式不正确：" + str);
				} else {
					string smtp = list[0].Trim();
					string userName = list[1].Trim();

					if (!IsSmtp(smtp)) {
						WriteLog("第" + index.ToString() + "行Smtp服务器地址格式不正确：" + str);
					} else {
						if (SmtpListHelper.IsExistByID(smtp, port, userName)) {
							WriteLog("第" + index.ToString() + "行数据已存在：" + str);
						} else {
							//bool isTrue = NetHelper.CheckSMTP(list[1], list[2], list[0]);
							//if (isTrue) {
							SmtpList info = new SmtpList();
							info.SmtpServer = list[0];
							info.UserName = list[1];
							info.SPassword = list[2];
							info.SmtpPort = 25;
							info.CreateTime = DateTime.Now.ToDateTime().ToDateTime();
							SmtpListHelper.Insert(info);
							success++;
							//} else {
							//    WriteLog("第" + index.ToString() + "行SMTP无法连接到服务器，请检查用户名和密码是否正确和账号是否被封：" + str);
							//}
						}
					}
				}
				index++;
			}
			SmtpListHelper.ClearCacheAll();
			WriteLog("导入Smtp服务器列表完成：共 {0} 条记录，成功 {1} 条记录，失败 {2} 条记录！".FormatWith(totals, success, totals - success));
		}

		private void WriteLog(string msg) {
			listBox1.BeginInvoke(new Pub.Class.Action(() => {
				if (listBox1.Items.Count > 10000) listBox1.Items.Clear();
				listBox1.Items.Add(msg);
				listBox1.SelectedIndex = listBox1.Items.Count - 1;
				if (msg.IndexOf("导入Smtp服务器列表完成") != -1) btnStart.Enabled = true;
			}));
		}

		private Boolean IsSmtp(string smtp) {
			string[] list = smtp.Split('.');
			if (list.Count() >= 3) {
				return true;
			}
			return false;
		}

		private void mnuExit_Click(object sender, EventArgs e) {
			Close();
		}

		private void frmImportSMTP_FormClosed(object sender, FormClosedEventArgs e) {
			if (!thread.IsNull()) thread.Abort();
		}
	}
}
