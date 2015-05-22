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

namespace MailerUI {
    public partial class frmSendEmail : DockContent {
        public frmSendEmail() {
            InitializeComponent();
            frmMain.Instance.ControlsHint(this);
        }

        private void mnuAdd_Click(object sender, EventArgs e) {
            listBox1.Items.Add("");
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            MailerCenter.Start((msg) => {
                if (!listBox1.IsHandleCreated) return;
				listBox1.BeginInvoke(new Pub.Class.Action(() => {
                    msg = "[{0}]-{1}".FormatWith(DateTime.Now.ToDateTimeFFF(), msg);
                    Log.WriteLog(msg);
                    if (listBox1.Items.Count > 10000) listBox1.Items.Clear();
                    listBox1.Items.Add(msg);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }));
            }, () => {
				this.BeginInvoke(new Pub.Class.Action(() => {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                }));
            });
        }

        private void mnuDelete_Click(object sender, EventArgs e) {
            listBox1.Items.Add("正在停止发送.....");
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            MailerCenter.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void mnuExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void frmSendEmail_FormClosed(object sender, FormClosedEventArgs e) {
            MailerCenter.Abort();
        }
    }
}
