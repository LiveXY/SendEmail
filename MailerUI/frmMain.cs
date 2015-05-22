using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Pub.Class;
using TH.Mailer.Helper;
using TH.Mailer;
using TH.Mailer.Entity;
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;
using Pub.Class.Linq;

namespace MailerUI {
    public partial class frmMain : Form {
        private string serviceName = "MailerService";
        private string servicePath = AppDomain.CurrentDomain.BaseDirectory.Trim('\\') + "\\MailerService.exe";
        private string week;

        public static frmMain Instance;

        public frmMain() {
            InitializeComponent();
            testToolStripMenuItem.Visible = false;
            test2ToolStripMenuItem.Visible = false;
            ControlsHint(this);
        }

        public void ShowStatusText(string msg) {
            if (!this.IsHandleCreated) return;
			this.BeginInvoke(new Pub.Class.Action(() => {
                statusMsg.Text = msg;
            }));
        }
        private void MenuHintShowInStatusBar(MenuStrip menu) { foreach (ToolStripMenuItem item in menu.Items) { MenuItemHint(item); } }
        private void MenuHint_Enter(object sender, EventArgs e) { statusMsg.Text = (sender as ToolStripMenuItem).ToolTipText; }
        private void Hint_Leave(object sender, EventArgs e) {
            if (statusMsg.Text.IndexOf("...") != -1) return;
            if (statusMsg.Text.IndexOf("！") != -1) return;
            statusMsg.Text = "";
        }
        private void MenuItemHint(ToolStripMenuItem element) {
            for (int i = 0; i < element.DropDownItems.Count; i++) {
                if (!(element.DropDownItems[i] is ToolStripSeparator)) {
                    ToolStripMenuItem item = element.DropDownItems[i] as ToolStripMenuItem;
                    if (item.ToolTipText != "") {
                        item.MouseEnter += MenuHint_Enter;
                        item.MouseLeave += Hint_Leave;
                    }
                    MenuItemHint(item);
                }
            }
        }
        private void ToolHintShowInStatusBar(ToolStrip tool) { foreach (ToolStripItem item in tool.Items) { ToolItemHint(item); } }
        private void ToolHint_Enter(object sender, EventArgs e) { statusMsg.Text = (sender as ToolStripItem).ToolTipText; }
        private void ToolItemHint(ToolStripItem element) {
            if (!(element is ToolStripSeparator)) {
                ToolStripItem item = element as ToolStripItem;
                if (item.ToolTipText != "") {
                    item.MouseEnter += ToolHint_Enter;
                    item.MouseLeave += Hint_Leave;
                }
            }
        }
        public void ControlsHint(Form from) {
            foreach (Control c in from.Controls) {
                if (c is MenuStrip) MenuHintShowInStatusBar(c as MenuStrip);
                if (c is ToolStrip) ToolHintShowInStatusBar(c as ToolStrip);
                if (c is Panel) {
                    foreach (Control c2 in c.Controls) {
                        if (c2 is MenuStrip) MenuHintShowInStatusBar(c2 as MenuStrip);
                        if (c2 is ToolStrip) ToolHintShowInStatusBar(c2 as ToolStrip);
                    }
                }
            }
        }

        private bool FormExist(string formName) {
            foreach (Form item in this.MdiChildren) {
                if (item.Name == formName) {
                    item.Focus();
                    return true;
                }
            }
            return false;
        }

        private void mnuStart_Click(object sender, EventArgs e) {
            if (!ServiceHelper.ServiceIsInstalled(serviceName)) {
                if (ServiceHelper.ServiceInstall(servicePath)) {
                    if (ServiceHelper.ServiceIsStarted(serviceName)) {
                        MessageBox.Show(serviceName + "服务已启动！", " 系统提示");
                    } else {
                        if (ServiceHelper.ServiceStart(serviceName)) {
                            MessageBox.Show(serviceName + "服务启动成功！", " 系统提示");
                        } else {
                            MessageBox.Show(serviceName + "服务启动失败！", " 系统提示");
                        }
                    }
                } else {
                    MessageBox.Show("安装服务失败：" + serviceName);
                }
            }
        }

        private void mnuStop_Click(object sender, EventArgs e) {
            if (MessageBox.Show("是否停止并卸载服务？", " 系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK) {
                if (ServiceHelper.ServiceStop(serviceName)) {
                    if (ServiceHelper.ServiceInstall("/u", servicePath)) {
                        MessageBox.Show("卸载服务成功：" + serviceName, " 系统提示");
                    } else {
                        MessageBox.Show("卸载服务失败：" + serviceName, " 系统提示");
                    }
                } else {
                    MessageBox.Show("无法停止服务：" + serviceName, " 系统提示");
                }
            }
        }

        private void mnuExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void mnuSetting_Click(object sender, EventArgs e) {
            if (!FormExist("frmSendSetting")) {
                frmSendSetting setting = new frmSendSetting();
                setting.Show(dockPanel);
            }
        }

        private void mnuTemplate_Click(object sender, EventArgs e) {
            if (!FormExist("frmTemplate")) {
                frmTemplate temp = new frmTemplate();
                temp.Show(dockPanel);
            }
        }

        private void mnuRoute_Click(object sender, EventArgs e) {
            if (!FormExist("frmRouteSetting")) {
                frmRouteSetting route = new frmRouteSetting();
                route.Show(dockPanel);
            }
        }

        private void mnuModel_Click(object sender, EventArgs e) {
            if (!FormExist("frmModelSetting")) {
                frmModelSetting model = new frmModelSetting();
                model.Show(dockPanel);
            }
        }

        private void mnuViewEmail_Click(object sender, EventArgs e) {
            if (!FormExist("ViewEmailList")) {
                frmView view = new frmView(1);
                view.TabText = "查看Email列表";
                view.Name = "ViewEmailList";
                view.Show(dockPanel);
            }
        }

        private void mnuViewSMTP_Click(object sender, EventArgs e) {
            if (!FormExist("ViewSmtpList")) {
                frmView view = new frmView(2);
                view.TabText = "查看Smtp列表";
                view.Name = "ViewSmtpList";
                view.Show(dockPanel);
            }
        }

        private void mnuTestIP_Click(object sender, EventArgs e) {
            if (!FormExist("frmTestRoute")) {
                frmTestRoute test = new frmTestRoute();
                test.Show(dockPanel);
            }
        }

        private void mnuTestSend_Click(object sender, EventArgs e) {
            if (!FormExist("frmSendEmail")) {
                frmSendEmail test = new frmSendEmail();
                test.Show(dockPanel);
            }
        }

        private void mnuInportSMTP_Click(object sender, EventArgs e) {
            if (!FormExist("frmImportSMTP")) {
                frmImportSMTP test = new frmImportSMTP();
                test.Show(dockPanel);
            }
        }

        private void mnuInportEmail_Click(object sender, EventArgs e) {
            if (!FormExist("frmImportEmail")) {
                frmImportEmail test = new frmImportEmail();
                test.Show(dockPanel);
            }
        }

        private void frmMain_Load(object sender, EventArgs e) {
            this.Text = this.Text + " - " + Data.Pool("ConnString").DBType;
            Instance = this;
            switch (DateTime.Now.DayOfWeek) {
                case DayOfWeek.Monday: week = " 星期一"; break;
                case DayOfWeek.Tuesday: week = " 星期二"; break;
                case DayOfWeek.Wednesday: week = " 星期三"; break;
                case DayOfWeek.Thursday: week = " 星期四"; break;
                case DayOfWeek.Friday: week = " 星期五"; break;
                case DayOfWeek.Saturday: week = " 星期六"; break;
                case DayOfWeek.Sunday: week = " 星期天"; break;
            }
            if (!ServiceHelper.ServiceIsInstalled(serviceName)) ShowStatusText("发送邮件服务未安装！");
            else {
                if (ServiceHelper.ServiceIsStarted(serviceName)) ShowStatusText("发送邮件服务已安装并启动！"); else ShowStatusText("发送邮件服务已安装未启动！");
            }
            //MessageBox.Show(Mailer.Jammer(HtmlTemplateHelper.SelectListByAll().FirstOrDefault().Body));
        }

        private void mnuTestModel_Click(object sender, EventArgs e) {
            if (!FormExist("frmTestModel")) {
                frmTestModel test = new frmTestModel();
                test.Show(dockPanel);
            }
        }

        public void RouteSetting() {
            mnuRoute_Click(null, null);
        }
        public void ModelSetting() {
            mnuModel_Click(null, null);
        }
        public void IPSetting() {
            mnuGetIP_Click(null, null);
        }
        public void TYSetting() {
            mnuTY_Click(null, null);
        }

        private void numViewIP_Click(object sender, EventArgs e) {
            if (!FormExist("ViewIpHistory")) {
                frmView view = new frmView(3);
                view.TabText = "查看最近使用的IP列表";
                view.Name = "ViewIpHistory";
                view.Show(dockPanel);
            }
        }

        private void mnuGetIP_Click(object sender, EventArgs e) {
            if (!FormExist("frmIpSetting")) {
                frmIpSetting test = new frmIpSetting();
                test.Show(dockPanel);
            }
        }

        private void numTestGetIP_Click(object sender, EventArgs e) {
            if (!FormExist("frmTestIP")) {
                frmTestIP test = new frmTestIP();
                test.Show(dockPanel);
            }
        }

        private void mnuTY_Click(object sender, EventArgs e) {
            if (!FormExist("frmTYSetting")) {
                frmTYSetting test = new frmTYSetting();
                test.Show(dockPanel);
            }
        }

        private void mnuTestTY_Click(object sender, EventArgs e) {
            if (!FormExist("frmTestTY")) {
                frmTestTY test = new frmTestTY();
                test.Show(dockPanel);
            }
        }

        private void mnuReset_Click(object sender, EventArgs e) {
            if (MessageBox.Show("是否重启群发邮件服务？", " 系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK) {
                if (ServiceHelper.ServiceStop(serviceName)) {
                    if (ServiceHelper.ServiceIsStarted(serviceName)) {
                        MessageBox.Show(serviceName + "服务已启动！", " 系统提示");
                    } else {
                        if (ServiceHelper.ServiceStart(serviceName)) {
                            MessageBox.Show(serviceName + "服务启动成功！", " 系统提示");
                        } else {
                            MessageBox.Show(serviceName + "服务启动失败！", " 系统提示");
                        }
                    }
                } else {
                    MessageBox.Show("无法停止服务：" + serviceName, " 系统提示");
                }
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!FormExist("frm1")) {
                frm1 test = new frm1();
                test.Show(dockPanel);
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            statusTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + week;
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!FormExist("frm2")) {
                frm2 test = new frm2();
                test.Show(dockPanel);
            }
        }
    }
}
