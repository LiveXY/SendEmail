using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WeifenLuo.WinFormsUI.Docking;
using TH.Mailer.Helper;
using TH.Mailer.Entity;
using Pub.Class;
using Pub.Class.Linq;

namespace MailerUI {
    public partial class frmView : DockContent {
        private int type;
        private int pageSize = 50;
        private int page = 1;
        private int pages = 0;

        public frmView(int type) {
            this.type = type;
            InitializeComponent();
        }

        private void frmView_Load(object sender, EventArgs e) {
            switch (type) {
                case 1:
                    mnuAdd.Visible = true;
                    mnuAdd.Visible = true;
                    mnuDelete.Visible = true;
                    mnuEdit.Visible = true;
                    mnuSelectAll.Visible = true;
                    mnuDeleteAll.Visible = true;
                    mnuExport.Visible = true;
                    mnuRefresh.Visible = true;
                    this.toolStripLabel2.Visible = true;
                    toolStripComboBox1.Visible = true;
                    mnuSearch.Visible = true;
                    toolStripSeparator3.Visible = true;
                    toolStripSeparator6.Visible = true;
                    toolStripSeparator7.Visible = true;
                    toolStripSeparator8.Visible = true;
                    this.mnuEnable.Visible = false;
                    this.mnuDisable.Visible = false;
                    break;
                case 2:
                    mnuAdd.Visible = true;
                    mnuAdd.Visible = true;
                    mnuDelete.Visible = true;
                    mnuEdit.Visible = true;
                    mnuSelectAll.Visible = true;
                    mnuDeleteAll.Visible = true;
                    mnuExport.Visible = false;
                    mnuRefresh.Visible = true;
                    this.toolStripLabel2.Visible = false;
                    toolStripComboBox1.Visible = false;
                    mnuSearch.Visible = false;

                    toolStripSeparator3.Visible = true;
                    toolStripSeparator6.Visible = false;
                    toolStripSeparator7.Visible = true;
                    toolStripSeparator8.Visible = false;
                    toolStripSeparator9.Visible = true;
                   this.mnuEnable.Visible = true;
                    this.mnuDisable.Visible = true;
                    break;
                case 3:
                    mnuAdd.Visible = false;
                    mnuDelete.Visible = false;
                    mnuEdit.Visible = false;
                    mnuSelectAll.Visible = false;
                    mnuDeleteAll.Visible = true;
                    mnuExport.Visible = false;
                    mnuRefresh.Visible = true;
                    toolStripComboBox1.Visible = false;
                    mnuSearch.Visible = false;
                    toolStripSeparator3.Visible = false;
                    toolStripSeparator6.Visible = false;
                    toolStripSeparator7.Visible = true;
                    toolStripSeparator8.Visible = false;
                    toolStripSeparator9.Visible = true;
                    this.toolStripLabel2.Visible = false;
                    this.mnuEnable.Visible = false;
                    this.mnuDisable.Visible = false;
                    break;
            }

            loadData();
            this.toolStripComboBox1.SelectedIndex = 0;
        }

        private void loadData() {
            mnuNext.Enabled = false;
            mnuPrev.Enabled = false;

            int totals = 0;

            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.BeginUpdate();

            switch (type) {
                case 1:
                    Where where = null;
                    switch (toolStripComboBox1.Text) {
                        case "等待发送":
                            where = new Where().And("LastSendStatus", 0, Operator.Equal);
                            break;
                        case "发送成功":
                            where = new Where().And("LastSendStatus", 1, Operator.Equal);
                            break;
                        case "发送失败":
                            where = new Where().And("LastSendStatus", 2, Operator.Equal);
                            break;
                        default:
                            where = null;
                            break;
                    }

    

                    IList<EmailList> emailList = EmailListHelper.SelectPageList(page, pageSize, out totals, "", where);
                    pages = totals / pageSize + (totals % pageSize == 0 ? 0 : 1);


                    listView1.Columns.Add("序号", 60, HorizontalAlignment.Left);
                    listView1.Columns.Add("邮件地址", 150, HorizontalAlignment.Left);
                    listView1.Columns.Add("昵称", 80, HorizontalAlignment.Left);
                    listView1.Columns.Add("状态", 80, HorizontalAlignment.Left);
                    listView1.Columns.Add("最后一次出错日志", 150, HorizontalAlignment.Left);
                    listView1.Columns.Add("最后一次使用SMTP", 150, HorizontalAlignment.Left);
                    listView1.Columns.Add("最后一次发送时间", 130, HorizontalAlignment.Left);

                    listView1.Columns.Add("ex0", 80, HorizontalAlignment.Left);
                    listView1.Columns.Add("ex1", 80, HorizontalAlignment.Left);
                    listView1.Columns.Add("ex2", 80, HorizontalAlignment.Left);
                    listView1.Columns.Add("ex3", 80, HorizontalAlignment.Left);
                    listView1.Columns.Add("ex4", 80, HorizontalAlignment.Left);
                    listView1.Columns.Add("ex5", 80, HorizontalAlignment.Left);
                    listView1.Columns.Add("ex6", 80, HorizontalAlignment.Left);
                    listView1.Columns.Add("ex7", 80, HorizontalAlignment.Left);
                    listView1.Columns.Add("ex8", 80, HorizontalAlignment.Left);

                    this.listView1.BeginInvoke(new Action(() => {
                        string tempStatus = string.Empty;
                        emailList.Do((p, i) => {
                            switch (p.LastSendStatus) {
                                case 0:
                                    tempStatus = "等待发送";
                                    break;
                                case 1:
                                    tempStatus = "发送成功";
                                    break;
                                case 2:
                                    tempStatus = "发送失败";
                                    break;
                            }
                            ListViewItem item = new ListViewItem((i + 1).ToString());
                            item.Tag = p.EmailAddress.ToString();
                            item.ToolTipText = p.EmailAddress.ToString();
                            item.SubItems.Add(p.EmailAddress.ToString());
                            //item.SubItems.Add(p.a.ToString() == "0" ? "可用" : "不可用");
                            item.SubItems.Add(p.NickName.ToString());
                            item.SubItems.Add(tempStatus);
                            item.SubItems.Add(p.LastSendError.ToString());
                            item.SubItems.Add(p.LastSendSmtp.ToString());
                            item.SubItems.Add(p.LastSendTime.ToString());
                            item.SubItems.Add(p.ex0.ToString());
                            item.SubItems.Add(p.ex1.ToString());
                            item.SubItems.Add(p.ex2.ToString());
                            item.SubItems.Add(p.ex3.ToString());
                            item.SubItems.Add(p.ex4.ToString());
                            item.SubItems.Add(p.ex5.ToString());
                            item.SubItems.Add(p.ex6.ToString());
                            item.SubItems.Add(p.ex7.ToString());
                            item.SubItems.Add(p.ex8.ToString());

                            this.listView1.Items.Add(item);
                        });

                    }));
                    break;
                case 2:
 

                    IList<SmtpList> smtpList = SmtpListHelper.SelectPageList(page, pageSize, out totals);
                    pages = totals / pageSize + (totals % pageSize == 0 ? 0 : 1);

                    listView1.Columns.Add("序号", 100, HorizontalAlignment.Left);
                    listView1.Columns.Add("SMTP服务器", 200, HorizontalAlignment.Left);
                    listView1.Columns.Add("SMTP端口", 100, HorizontalAlignment.Left);
                    listView1.Columns.Add("登录用户名", 100, HorizontalAlignment.Left);
                    listView1.Columns.Add("登录密码", 100, HorizontalAlignment.Left);
                    listView1.Columns.Add("是否支持SSL", 100, HorizontalAlignment.Left);
                    listView1.Columns.Add("状态", 100, HorizontalAlignment.Left);
                    listView1.Columns.Add("发送次数", 100, HorizontalAlignment.Left);
                    listView1.Columns.Add("发送失败次数", 100, HorizontalAlignment.Left);

                    listView1.BeginInvoke(new Action(() => {
                        smtpList.Do((p, i) => {
                            ListViewItem item = new ListViewItem((i + 1).ToString());
                            item.Tag = p.SmtpServer.ToString() + ',' + p.SmtpPort.ToString() + ',' + p.UserName.ToString() + ',' + p.SPassword.ToString();
                            item.ToolTipText = p.SmtpServer.ToString();

                            item.SubItems.Add(p.SmtpServer.ToString());
                            item.SubItems.Add(p.SmtpPort.ToString());
                            item.SubItems.Add(p.UserName.ToString());
                            //item.SubItems.Add(p.SPassword.ToString());
                            item.SubItems.Add("*".PadRight(p.SPassword.Length, '*'));
                            item.SubItems.Add(p.SSL == true ? "支持" : "不支持");
                            item.SubItems.Add(p.Status.ToString() == "0" ? "可用" : "不可用");
                            item.SubItems.Add(p.Sends.ToString());
                            item.SubItems.Add(p.SendFails.ToString());

                            this.listView1.Items.Add(item);
                        });
                    }));
                    break;
                case 3:
                    IList<IpHistory> ipList = IpHistoryHelper.SelectPageList(page, pageSize, out totals);
                    pages = totals / pageSize + (totals % pageSize == 0 ? 0 : 1);

                    listView1.CheckBoxes = false;
                    listView1.Columns.Add("序号", 60, HorizontalAlignment.Left);
                    listView1.Columns.Add("IP地址", 200, HorizontalAlignment.Left);
                    listView1.Columns.Add("使用时间", 200, HorizontalAlignment.Left);

                    listView1.BeginInvoke(new Action(() => {
                        ipList.Do((p, i) => {
                            ListViewItem item = new ListViewItem((i + 1).ToString());
                            item.Tag = p.IP.ToString();
                            item.ToolTipText = p.IP.ToString();

                            item.SubItems.Add(p.IP.ToString());
                            item.SubItems.Add(p.CreateTime.ToString());

                            this.listView1.Items.Add(item);
                        });
                    }));
                    break;
            }

            if (page <= 1) {
                mnuNext.Enabled = true;
                mnuPrev.Enabled = false;
            }

            if (page == pages) {
                mnuNext.Enabled = false;
                mnuPrev.Enabled = true;
            }

            if (page <= 1 && page >= pages) {
                mnuNext.Enabled = false;
                mnuPrev.Enabled = false;
            }

            toolStripLabel1.Text = "总记录数：{0}，总页数：{1}，当前页：{2}".FormatWith(totals, pages, page);

            this.listView1.EndUpdate();
        }

        private void mnuPrev_Click(object sender, EventArgs e) {
            --page;
            loadData();
        }

        private void mnuNext_Click(object sender, EventArgs e) {
            ++page;
            loadData();
        }

        private void mnuExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void mnuAdd_Click(object sender, EventArgs e) {
            switch (type) {
                case 1:
                    frmAddEmailList frm2 = new frmAddEmailList();
                    if (frm2.ShowDialog() == DialogResult.OK) loadData();
                    break;

                case 2:
                    frmAddSMTPList frm1 = new frmAddSMTPList();
                    if (frm1.ShowDialog() == DialogResult.OK) loadData();
                    break;
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e) {
            edit();
        }

        private void mnuDelete_Click(object sender, EventArgs e) {
            switch (type) {
                case 1:
                    if (listView1.CheckedItems.Count == 0) {
                        MessageBox.Show("请选择你要删除的记录！", " 系统提示");
                        return;
                    }
                    if (MessageBox.Show("确认要删除选中的记录吗？", " 系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                        IList<string> data = new List<string>();
                        foreach (ListViewItem item in listView1.Items) {
                            if (item.Checked) {
                                data.Add(item.Tag.ToString());
                            }
                        }
                        int rows = new SQL().Database("ConnString").Delete(EmailList._)
                            .Where(new Where()
                                .And(EmailList._EmailAddress, "('" + data.Select(p => p.SafeSql()).Join("','") + "')", Operator.In)
                            ).ToExec();

                        EmailListHelper.ClearCacheAll();
                        loadData();

                    }
                    break;
                case 2:
                    if (listView1.CheckedItems.Count == 0) {
                        MessageBox.Show("请选择你要删除的记录！", " 系统提示");
                        return;
                    }

                    if (MessageBox.Show("确认要删除选中的记录吗？", " 系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {

                        foreach (ListViewItem item in listView1.Items) {
                            if (item.Checked) {
                                string[] list = item.Tag.ToString().Split(',');

                                string id = list[0].ToString();
                                int port = list[1].ToString().ToInt(25);
                                string username = list[2].ToString();
                                string password = list[3].ToString();
                                SmtpListHelper.DeleteByID(id, port, username, password);

                            }
                        }
                        SmtpListHelper.ClearCacheAll();
                        loadData();
                    }
                    break;
            }
        }

        private void edit() {
            switch (type) {
                case 1:
                    if (this.listView1.SelectedItems.Count > 0 && this.listView1.SelectedItems[0].Tag != null) {
                        string id = this.listView1.SelectedItems[0].Tag.ToString();

                        frmAddEmailList frm = new frmAddEmailList(id);
                        if (frm.ShowDialog() == DialogResult.OK) loadData();
                    } else
                        MessageBox.Show("请选择你要修改的记录！", " 系统提示");
                    break;
                case 2:
                    if (this.listView1.SelectedItems.Count > 0 && this.listView1.SelectedItems[0].Tag != null) {
                        string[] list = this.listView1.SelectedItems[0].Tag.ToString().Split(',');

                        string id = list[0].ToString();
                        int port = list[1].ToString().ToInt(25);
                        string username = list[2].ToString();
                        string password = list[3].ToString();

                        frmAddSMTPList frm = new frmAddSMTPList(id, port, username);

                        if (frm.ShowDialog() == DialogResult.OK) loadData();
                    } else
                        MessageBox.Show("请选择你要修改的记录！", " 系统提示");
                    break;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e) {
            edit();
        }

        private void mnuRefresh_Click(object sender, EventArgs e) {
            switch (type) {
                case 1:
                    EmailListHelper.ClearCacheAll();
                    break;
                case 2:
                    SmtpListHelper.ClearCacheAll();
                    break;
                case 3:
                    IpHistoryHelper.ClearCacheAll();
                    break;
            }
            loadData();
        }

        private void mnuSelectAll_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in listView1.Items) {
                //if (item.Checked) {
                //    item.Checked = false;
                //} else {
                //    item.Checked = true;

                //}
                item.Checked = true;
            }
        }

        private void mnuDeleteAll_Click(object sender, EventArgs e) {
            switch (type) {
                case 1:
                    if (MessageBox.Show("确认要删除全部记录吗？", " 系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                        int rows = new SQL().Database("ConnString").Delete(EmailList._).ToExec();
                        EmailListHelper.ClearCacheAll();
                        loadData();
                    }
                    break;
                case 2:
                    if (MessageBox.Show("确认要删除全部记录吗？", " 系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                        int rows = new SQL().Database("ConnString").Delete(SmtpList._).ToExec();
                        SmtpListHelper.ClearCacheAll();
                        loadData();
                    }
                    break;
                case 3:
                    if (MessageBox.Show("确认要删除全部记录吗？", " 系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                        int rows = new SQL().Database("ConnString").Delete(IpHistory._).ToExec();
                        IpHistoryHelper.ClearCacheAll();
                        loadData();
                    }
                    break;
            }
        }

        private void mnuExport_Click(object sender, EventArgs e) {
            saveFileDialog1.InitialDirectory = ".\\";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                ThreadPool.QueueUserWorkItem(new WaitCallback(exportEmailList), saveFileDialog1.FileName);
            }
        }

        private void exportEmailList(object o) {
            string fileName = (string)o;
            var emailList = EmailListHelper.SelectListByAll();

            StringBuilder sb = new StringBuilder();
            if (FileDirectory.FileExists(fileName)) FileDirectory.FileDelete(fileName);
            emailList.Do(p => {
                if (p.LastSendError.IndexOf("Mailbox not found") == -1) sb.AppendLine(p.EmailAddress);
            });
            FileDirectory.FileWrite(fileName, sb.ToString(), Encoding.UTF8);
        }

        private void mnuSearch_Click(object sender, EventArgs e) {
            switch (type) {
                case 1:
                    EmailListHelper.ClearCacheAll();
                    break;
                case 2:
                    SmtpListHelper.ClearCacheAll();
                    break;
                case 3:
                    IpHistoryHelper.ClearCacheAll();
                    break;
            }
            loadData();
        }


        private void mnuEnable_Click(object sender, EventArgs e) {


            switch (type) {
                case 1:
                    EmailListHelper.ClearCacheAll();
                    break;
                case 2:
                    SmtpListHelper.ClearCacheAll();
                    foreach (ListViewItem item in listView1.Items) {
                        if (item.Checked) {
                            string[] list = item.Tag.ToString().Split(',');

                            SmtpList info = new SmtpList();
                            info.SmtpServer = list[0].ToString();
                            info.SmtpPort = list[1].ToString().ToInt(25);
                            info.UserName = list[2].ToString();
                            info.SPassword = list[3].ToString();
                            info.Status = 0;
                            SmtpListHelper.Update(info);
                            //if (!info.SmtpServer.IsNullEmpty() || SmtpListHelper.IsExistByID(info.SmtpServer, info.SmtpPort.Value, info.UserName)) {
                            //    SmtpListHelper.Update(info);
                            //}

                        }
                    }
                    break;
                case 3:
                    IpHistoryHelper.ClearCacheAll();
                    break;
            }
            loadData();



        }

        private void mnuDisable_Click(object sender, EventArgs e) {

            switch (type) {
                case 1:
                    EmailListHelper.ClearCacheAll();
                    break;
                case 2:
                    SmtpListHelper.ClearCacheAll();
                    foreach (ListViewItem item in listView1.Items) {
                        if (item.Checked) {
                            string[] list = item.Tag.ToString().Split(',');

                            SmtpList info = new SmtpList();
                            info.SmtpServer = list[0].ToString();
                            info.SmtpPort = list[1].ToString().ToInt(25);
                            info.UserName = list[2].ToString();
                            info.SPassword = list[3].ToString();
                            info.Status = 1;
                            SmtpListHelper.Update(info);
                            //if (!info.SmtpServer.IsNullEmpty() || SmtpListHelper.IsExistByID(info.SmtpServer, info.SmtpPort.Value, info.UserName)) {
                            //    SmtpListHelper.Update(info);
                            //}

                        }
                    }
                    break;
                case 3:
                    IpHistoryHelper.ClearCacheAll();
                    break;
            }
            loadData();
        }


    }
}