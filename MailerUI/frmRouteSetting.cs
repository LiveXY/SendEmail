using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Pub.Class;
using TH.Mailer.Helper;
using Pub.Class.Linq;
using TH.Mailer.Entity;
using System.Threading;
using WeifenLuo.WinFormsUI.Docking;

namespace MailerUI {
	public partial class frmRouteSetting : DockContent {
		private RouteSetting routeSetting;

		public frmRouteSetting() {
			InitializeComponent();
			frmMain.Instance.ControlsHint(this);
		}

		private void mnuEdit_Click(object sender, EventArgs e) {
			RouteSetting info = new RouteSetting();
			info.UserName = txtUserName.Text;
			info.RPassword = txtPassword.Text;
			info.RouteIP = txtRouteIP.Text;
			info.RouteConnect = txtRouteConnect.Text;
			info.RouteDisConnect = txtRouteDisConnect.Text;
			info.RouteMethod = rdoGET.Checked ? "GET" : "POST";
			if (routeSetting.IsNull() || routeSetting.RouteID.IsNull()) {
				info.RouteID = 1;
				RouteSettingHelper.Insert(info);
			} else {
				info.RouteID = routeSetting.RouteID;
				RouteSettingHelper.Update(info);
			}
			RouteSettingHelper.ClearCacheAll();

			MessageBox.Show("保存数据成功！", " 系统提示");
			this.Close();
		}

		private void mnuExit_Click(object sender, EventArgs e) {
			Close();
		}

		private void frmRoute_Activated(object sender, EventArgs e) {
			frmMain.Instance.ShowStatusText("正在数据....");
			routeSetting = RouteSettingHelper.SelectByID(1);
			if (routeSetting.IsNull() || routeSetting.RouteID.IsNull()) return;
			txtPassword.Text = routeSetting.RPassword;
			txtRouteIP.Text = routeSetting.RouteIP;
			txtUserName.Text = routeSetting.UserName;
			txtRouteConnect.Text = routeSetting.RouteConnect;
			txtRouteDisConnect.Text = routeSetting.RouteDisConnect;
			if (routeSetting.RouteMethod == "GET") rdoGET.Checked = true;
			if (routeSetting.RouteMethod == "POST") rdoPOST.Checked = true;
			frmMain.Instance.ShowStatusText("数据加载完成！");
		}

		private void label8_DoubleClick(object sender, EventArgs e) {
			txtRouteIP.Text = "http://192.168.0.1/userRpm/SysRebootRpm.htm";
		}

		private void label9_DoubleClick(object sender, EventArgs e) {
			txtRouteConnect.Text = "Reboot=%D6%D8%C6%F4%C2%B7%D3%C9%C6%F7";
		}
	}
}
