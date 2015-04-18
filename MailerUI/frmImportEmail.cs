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
    public partial class frmImportEmail : DockContent {
        private Thread thread;
        private string fileName;

        public frmImportEmail() {
            InitializeComponent();
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
                thread = new Thread(inportEmailList);
                thread.IsBackground = true;
                thread.Start();
            }
        }

        private void inportEmailList() {
            int totals = 0; int success = 0;
            WriteLog("");
            WriteLog("正在读取数据.....");
            IList<string> data = FileDirectory.FileRead(fileName, FileDirectory.FileEncoding(fileName));
            totals = data.Count;
            WriteLog("读取到：" + totals + " 行记录！");

            WriteLog("正在导入数据.....");
            int index = 1;
            foreach (string str in data) {
                string[] list = str.Split(',');
                string email = list[0].Trim();
                if (!email.IsEmail()) {
                    WriteLog("第" + index.ToString() + "行Email地址格式不正确：" + str);
                } else {
                    if (EmailListHelper.IsExistByID(email)) {
                        WriteLog("第" + index.ToString() + "行数据已存在：" + str);
                    } else {
                        EmailList info = new EmailList();
                        info.EmailAddress = email;
                        info.NickName = email.Split('@')[0];
                        if (list.Length == 10) {
                            info.ex0 = list[1];
                            info.ex1 = list[2];
                            info.ex2 = list[3];
                            info.ex3 = list[4];
                            info.ex4 = list[5];
                            info.ex5 = list[6];
                            info.ex6 = list[7];
                            info.ex7 = list[8];
                            info.ex8 = list[9];
                        }
                        info.CreateTime = DateTime.Now;
                        EmailListHelper.Insert(info);
                        success++;
                    }
                }
                index++;
            }
            EmailListHelper.ClearCacheAll();
            WriteLog("导入Email列表完成：共 {0} 条记录，成功 {1} 条记录，失败 {2} 条记录！".FormatWith(totals, success, totals - success));
        }

        private void WriteLog(string msg) {
            listBox1.BeginInvoke(new Action(() => {
                if (listBox1.Items.Count > 10000) listBox1.Items.Clear();
                listBox1.Items.Add(msg);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                if (msg.IndexOf("导入Email列表完成") != -1) btnStart.Enabled = true;
            }));
        }

        private void mnuExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void frmImportEmail_FormClosed(object sender, FormClosedEventArgs e) {
            if (!thread.IsNull()) thread.Abort();
        }
    }
}
