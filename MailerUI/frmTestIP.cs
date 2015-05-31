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
	public partial class frmTestIP : DockContent {
		private Thread thread;

		public frmTestIP() {
			InitializeComponent();
			frmMain.Instance.ControlsHint(this);
		}

		private void mnuExit_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnTest_Click(object sender, EventArgs e) {
			listBox1.Items.Clear();
			btnTest.Enabled = false;

			if (!thread.IsNull()) { thread.Abort(); }
			thread = new Thread(threadRun);
			thread.IsBackground = true;
			thread.Start();
		}

		private void threadRun() {
			IPHelper.TestIPStart(msg => {
				if (!listBox1.IsHandleCreated) return;
				listBox1.BeginInvoke(new Pub.Class.Action(() => {
					if (listBox1.Items.Count > 10000) listBox1.Items.Clear();
					listBox1.Items.Add(msg);
					listBox1.SelectedIndex = listBox1.Items.Count - 1;
				}));
			}, () => {
				this.BeginInvoke(new Pub.Class.Action(() => {
					btnTest.Enabled = true;
				}));
			});
		}

		private void btnEdit_Click(object sender, EventArgs e) {
			frmMain.Instance.IPSetting();
		}

		private void frmTestIP_FormClosed(object sender, FormClosedEventArgs e) {
			IPHelper.TestIPStop();
			thread.Abort();
		}

	}
}
