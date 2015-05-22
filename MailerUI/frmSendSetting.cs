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
    public partial class frmSendSetting : DockContent {
        private SendSetting sendSetting;

        public frmSendSetting() {
            InitializeComponent();
            frmMain.Instance.ControlsHint(this);
        }

        private void mnuEdit_Click(object sender, EventArgs e) {
            if (this.cboTemplate.SelectedIndex < 0) {
                MessageBox.Show("发送主题为空,保存失败", "系统提示");
                 return;
            }
            SendSetting info = new SendSetting();
            info.TemplateID = (long)this.cboTemplate.SelectedValue;
            info.ConnectType = rdoRoute.Checked ? 0 : rdoModel.Checked ? 1 : 2;
            info.IPInterval = txtIPInterval.Text.ToInt(1000);
            info.SendInterval = txtSendInterval.Text.ToInt(10);
            info.SmtpInterval = txtSmtpInterval.Text.ToInt(20);
            info.Status = this.cboStatus.SelectedValue.ToString().ToInt(0);
            info.MaxRetryCount = txtMaxRetryCount.Text.ToInt(10);
            info.SendRetryCount = txtSendRetryCount.Text.ToInt(10);
            info.DeleteInterval = txtDeleteInterval.Text.ToInt(60);

            if (sendSetting.IsNull() || sendSetting.SettingID.IsNull()) {
                info.SettingID = 1;
                SendSettingHelper.Insert(info);
            } else {
                info.SettingID = sendSetting.SettingID;
                SendSettingHelper.Update(info);
            }
            SendSettingHelper.ClearCacheAll();

            if (info.Status == 0 && (int)cboStatus.Tag != info.Status) {
                new SQL()
                    .Update(EmailList._)
                    .Set("LastSendStatus", 0)
                    .Set("LastSendError", "")
                    .Set("LastSendTime", null, true)
                    .Set("LastSendSmtp", "")
                    .Set("SendCount", 0)
                    .ToExec();

                new SQL().Update(SmtpList._)
                    .Set("Sends", 0)
                    .Set("SendFails", 0)
                    .ToExec();

                new SQL().Delete(IpHistory._)
                    .ToExec();
            }

            MessageBox.Show("保存数据成功！", " 系统提示");
            this.Close();
        }

        private void mnuExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void frmSendSetting_Activated(object sender, EventArgs e) {
            frmMain.Instance.ShowStatusText("正在数据....");
            HtmlTemplateHelper.ClearCacheAll();
            cboTemplate.DataSource = null; ;
            cboTemplate.ValueMember = "TemplateID";
            cboTemplate.DisplayMember = "Subject";
            cboTemplate.DataSource = HtmlTemplateHelper.SelectListByAll().Where(p => p.Status == 0).OrderByDescending(p => p.TemplateID).Select(p => new { p.TemplateID, p.Subject }).ToDataTable();

            DataTable dt = new DataTable()
                .AddColumn<int>("id")
                .AddColumn<string>("name")
                .AddRow(0, "等待发送")
                .AddRow(1, "正在发送")
                .AddRow(2, "已发送完成");

            this.cboStatus.DataSource = dt;
            this.cboStatus.DisplayMember = "name";
            this.cboStatus.ValueMember = "id";
            this.cboStatus.SelectedIndex = 0;

            sendSetting = SendSettingHelper.SelectByID(1);
            if (sendSetting.IsNull() || sendSetting.SettingID.IsNull()) return;

            cboTemplate.SelectedValue = sendSetting.TemplateID;
            if (sendSetting.ConnectType == 0) rdoRoute.Checked = true;
            if (sendSetting.ConnectType == 1) rdoModel.Checked = true;
            if (sendSetting.ConnectType == 2) rdoTY.Checked = true;
            txtIPInterval.Text = sendSetting.IPInterval.ToString();
            txtSendInterval.Text = sendSetting.SendInterval.ToString();
            txtSmtpInterval.Text = sendSetting.SmtpInterval.ToString();
            txtMaxRetryCount.Text = sendSetting.MaxRetryCount.ToString();
            txtDeleteInterval.Text = sendSetting.DeleteInterval.ToString();
            txtSendRetryCount.Text = sendSetting.SendRetryCount.ToString();
            cboStatus.SelectedValue = sendSetting.Status;
            cboStatus.Tag = sendSetting.Status.Value;
            frmMain.Instance.ShowStatusText("数据加载完成！");
        }
    }
}
