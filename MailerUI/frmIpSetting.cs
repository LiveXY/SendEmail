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
    public partial class frmIpSetting : DockContent {

        public frmIpSetting() {
            InitializeComponent();
        }

         public void loadData() {
            this.listView1.Items.Clear();
            this.listView1.BeginUpdate();
            IpSettingHelper.SelectListByAll().OrderBy(p => p.IPCID).Do((p, i) => {
                ListViewItem item = new ListViewItem((i+1).ToString());
                item.Tag = p.IPCID.Value;
                item.ToolTipText = p.IPCID.ToString();
 
                item.SubItems.Add(p.WebName.ToString());
                item.SubItems.Add(p.IPUrl.ToString());
                item.SubItems.Add(p.IPRegex.ToString());
                item.SubItems.Add(p.DataEncode.ToString());
                this.listView1.Items.Add(item);
            });
            this.listView1.EndUpdate();
       }

        private void frmSetting_Load(object sender, EventArgs e) {
            loadData();
        }

        private void btnModify_Click(object sender, EventArgs e) {
            edit();

        }

        private void btnDel_Click(object sender, EventArgs e) {
            if (this.listView1.SelectedItems.Count > 0 && this.listView1.SelectedItems[0].Tag != null) {
                if (MessageBox.Show("确认要删除选中的记录吗？", " 系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                    int id = this.listView1.SelectedItems[0].Tag.ToString().ToInt(0);
                    if (id < 1) return;
                    IpSettingHelper.DeleteByID(id);
                    IpSettingHelper.ClearCacheAll();
                    loadData();
                }
            } else
                MessageBox.Show("请选择你要删除的记录！", " 系统提示");
        }

        private void edit() {
            if (this.listView1.SelectedItems.Count > 0 && this.listView1.SelectedItems[0].Tag != null) {
                int id = this.listView1.SelectedItems[0].Tag.ToString().ToInt(0);
                if (id < 1) return;
                frmAddIpSetting frm = new frmAddIpSetting(id);
                if (frm.ShowDialog() == DialogResult.OK)
                    loadData();
            } else
                MessageBox.Show("请选择你要修改的记录！", " 系统提示");
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e) {
            edit();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            frmAddIpSetting frm = new frmAddIpSetting();
            if (frm.ShowDialog() == DialogResult.OK)
                loadData();
     
        }

        private void mnuExit_Click(object sender, EventArgs e) {
            Close();
        }


    }
}
