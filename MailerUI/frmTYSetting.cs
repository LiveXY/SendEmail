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
	public partial class frmTYSetting : DockContent {
		private TianYiSetting setting;

		public frmTYSetting() {
			InitializeComponent();
			frmMain.Instance.ControlsHint(this);
		}

		private void mnuEdit_Click(object sender, EventArgs e) {
			if (!FileDirectory.FileExists(txtPath.Text)) {
				MessageBox.Show("文件不存在！", " 系统提示");
				return;
			}

			TianYiSetting info = new TianYiSetting();
			info.TianYiExePath = txtPath.Text;
			if (setting.IsNull() || setting.TianYiID.IsNull()) {
				info.TianYiID = 1;
				TianYiSettingHelper.Insert(info);
			} else {
				info.TianYiID = setting.TianYiID;
				TianYiSettingHelper.Update(info);
			}
			TianYiSettingHelper.ClearCacheAll();

			string inifile = info.TianYiExePath.GetParentPath('\\');
			inifile = inifile + "NavigateSetting.ini";
			if (FileDirectory.FileExists(inifile)) {
				IniFile ini = new IniFile(inifile);
				if (ini.ReadValue("DIAL", "AutoDial") == "0") ini.WriteValue("DIAL", "AutoDial", "1");
			}

			MessageBox.Show("保存数据成功！", " 系统提示");
			this.Close();
		}

		private void mnuExit_Click(object sender, EventArgs e) {
			Close();
		}

		private void frmRoute_Activated(object sender, EventArgs e) {
			frmMain.Instance.ShowStatusText("正在数据....");
			setting = TianYiSettingHelper.SelectByID(1);
			if (setting.IsNull() || setting.TianYiID.IsNull()) return;
			txtPath.Text = setting.TianYiExePath;
			frmMain.Instance.ShowStatusText("数据加载完成！");
		}
	}
}
