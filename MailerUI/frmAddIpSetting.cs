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
    public partial class frmAddIpSetting : DockContent {
        private int id = 0;

        public frmAddIpSetting(int id = 0) {
            this.id = id;
            InitializeComponent();
        }
        private void frmAddSetting_Load(object sender, EventArgs e) {
            //载入修改数据
            if (this.id != 0) LoadEditData(this.id);
        }

        private void LoadEditData(int ID) {
            IpSetting info = IpSettingHelper.SelectListByAll().Where(p => p.IPCID == ID).FirstOrDefault();
            if (info.IsNull() || info.IPCID.IsNull()) return;
            this.txtWebName.Text = info.WebName.ToString();
            this.txtIPUrl.Text = info.IPUrl.ToString();
            this.txtIPRegex.Text = info.IPRegex.ToString();
            this.txtDataEncode.Text = info.DataEncode.ToString();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(this.txtWebName.Text)) {
                MessageBox.Show("网址名称不能为空", "系统提示");
                return;
            }
            if (string.IsNullOrEmpty(this.txtIPUrl.Text)) {
                MessageBox.Show("网址地址不能为空", "系统提示");
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;

            IpSetting info = new IpSetting();

            info.WebName = this.txtWebName.Text;
            info.IPUrl = this.txtIPUrl.Text;
            info.IPRegex = this.txtIPRegex.Text;
            info.DataEncode = this.txtDataEncode.Text;

            if (this.id != 0) {
                info.IPCID = this.id;
                IpSettingHelper.Update(info);
                IpSettingHelper.ClearCacheAll();
            } else {
                long id = IpSettingHelper.Insert(info);
                IpSettingHelper.ClearCacheAll();
            }

            MessageBox.Show("保存数据成功！", " 系统提示");
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
