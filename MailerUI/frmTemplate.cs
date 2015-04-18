using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TH.Mailer.Entity;
using System.Threading;
using Pub.Class;
using TH.Mailer.Helper;
using Pub.Class.Linq;
using WeifenLuo.WinFormsUI.Docking;

namespace MailerUI {
    public partial class frmTemplate : DockContent {

        private long lastID = 0;
        private int currentIndex = -1;

        public frmTemplate() {
            InitializeComponent();
        }

        private void frmTemplate_Load(object sender, EventArgs e) {
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) => {
                dataGridView.BeginInvoke(new Action(() => {
                    dataGridView.DataSource = HtmlTemplateHelper.SelectListByAll().OrderByDescending(p => p.TemplateID).Select(p => new {
                        编号 = p.TemplateID,
                        邮件主题 = p.Subject
                    }).ToDataTable();
                    getRowData();
                }));
            }), null);
        }

        private void getRowData() {
            if (dataGridView.Rows.Count > 0) {
                int count = dataGridView.Rows.Count;
                currentIndex = currentIndex == -1 ? 0 : (currentIndex == count ? currentIndex - 1 : currentIndex);
                lastID = dataGridView.Rows[currentIndex].Cells[0].Value.ToBigInt(0);
                if (lastID < 1) return;
                HtmlTemplate info = HtmlTemplateHelper.SelectListByAll().Where(p => p.TemplateID == lastID).FirstOrDefault();
                if (info.IsNull() || info.TemplateID.IsNull()) return;

                txtSubject.Text = info.Subject;
                txtBody.Text = info.Body;
                txtShowName.Text = info.ShowName;
                checkBoxIsHTML.Checked = info.IsHTML == true ? true : false;
                checkBoxStatus.Checked = info.Status == 0 ? true : false;
                info.CreateTime = System.DateTime.Now;
                mnuEdit.Enabled = true;
                mnuDelete.Enabled = true;
            } else {
                this.txtSubject.Text = "";
                this.checkBoxIsHTML.Checked = false;
                this.checkBoxStatus.Checked = true;
                this.txtBody.Text = "";
                mnuEdit.Enabled = false;
                mnuDelete.Enabled = false;
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
            currentIndex = e.RowIndex;
            if (currentIndex < 0) return;
            lastID = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToBigInt(0);
            if (lastID < 1) return;
            HtmlTemplate info = HtmlTemplateHelper.SelectListByAll().Where(p => p.TemplateID == lastID).FirstOrDefault();
            if (info.IsNull() || info.TemplateID.IsNull()) return;

            this.txtSubject.Text = info.Subject;
            txtSubject.Text = info.Subject;
            txtBody.Text = info.Body;
            txtShowName.Text = info.ShowName;
            checkBoxIsHTML.Checked = info.IsHTML == true ? true : false;
            checkBoxStatus.Checked = info.Status == 0 ? true : false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl1.SelectedIndex == 1) {
                this.webBrowser1.DocumentText = this.txtBody.Text;
            }
        }

        private void txtBody_DoubleClick(object sender, EventArgs e) {
            this.txtBody.SelectAll();
        }

        private void txtBody_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 1) {
                this.txtBody.SelectAll();
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e) {

           // SendSetting info = SendSettingHelper(lastID);

            //int rows = new SQL().Database("ConnString").Select(IpHistory._).Where().ToExec();

            SendSetting setting = SendSettingHelper.SelectByID(1);
            if (setting.IsNull() || setting.TemplateID.IsNull()) return;


            if (setting.TemplateID == lastID && !this.checkBoxStatus.Checked) {

                MessageBox.Show("发送邮件设置使用了此模板，该模板不能不可用", "系统提示");
                return;
            }

            tabControl1.SelectedTab = tabControl1.TabPages[0];
            if (currentIndex < 0 || lastID < 1) return;
            HtmlTemplate info = new HtmlTemplate();
            info.Subject = this.txtSubject.Text;
            info.Body = this.txtBody.Text;
            info.IsHTML = this.checkBoxIsHTML.Checked ? true : false;
            info.Status = this.checkBoxStatus.Checked ? 0 : 1;
            info.ShowName = this.txtShowName.Text;
            info.TemplateID = lastID;
            HtmlTemplateHelper.Update(info);
            dataGridView.Rows[currentIndex].Cells[1].Value = info.Subject;
            HtmlTemplateHelper.ClearCacheAll();
            MessageBox.Show("保存成功", "系统提示");
        }

        private void mnuAdd_Click(object sender, EventArgs e) {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
            HtmlTemplate info = new HtmlTemplate();
            info.Status = this.checkBoxStatus.Checked ? 0 : 1;
            info.Subject = this.txtSubject.Text;
            info.Body = this.txtBody.Text;
            info.IsHTML = this.checkBoxIsHTML.Checked ? true : false;
            info.ShowName = this.txtShowName.Text;
            info.CreateTime = DateTime.Now;
            long id = HtmlTemplateHelper.Insert(info);
            HtmlTemplateHelper.ClearCacheAll();
            frmTemplate_Load(sender, e);
        }

        private void mnuDelete_Click(object sender, EventArgs e) {
            if (dataGridView.Rows.Count == 0 || lastID < 1) return;

            SendSetting setting = SendSettingHelper.SelectByID(1);
            if (setting.IsNull() || setting.TemplateID.IsNull()) return;


            if (setting.TemplateID == lastID && !this.checkBoxStatus.Checked) {

                MessageBox.Show("发送邮件设置使用了此模板，该模板不能删除", "系统提示");
                return;
            }

            if (MessageBox.Show("是否删除此邮件模板？", " 系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK) {
                
                HtmlTemplateHelper.DeleteByID(lastID);
                HtmlTemplateHelper.ClearCacheAll();
                dataGridView.Rows.RemoveAt(currentIndex);
                getRowData();
            }
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void mnuExit_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
