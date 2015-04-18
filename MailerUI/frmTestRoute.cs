using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using TH.Mailer.Entity;
using WeifenLuo.WinFormsUI.Docking;
using TH.Mailer;
using TH.Mailer.Helper;
using Pub.Class;
using Pub.Class.Linq;
using System.Threading;

namespace MailerUI {
    public partial class frmTestRoute : DockContent {
        private Thread thread;

        public frmTestRoute() {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            btnConnect.Enabled = false;
            if (!thread.IsNull()) { thread.Abort(); }
            thread = new Thread(threadRun);
            thread.IsBackground = true;
            thread.Start();
        }

        private void threadRun() {
            NetHelper.ChangeIP(0, msg => {
                if (!listBox1.IsHandleCreated) return;
                listBox1.BeginInvoke(new Action(() => {
                    if (listBox1.Items.Count > 10000) listBox1.Items.Clear();
                    listBox1.Items.Add(msg);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }));
            }, () => {
                this.BeginInvoke(new Action(() => {
                    btnConnect.Enabled = true;
                }));
            });
        }

        private void mnuExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            frmMain.Instance.RouteSetting();
        }

        private void frmTestRoute_FormClosed(object sender, FormClosedEventArgs e) {
            if (!thread.IsNull()) thread.Abort();
        }

    }
}
