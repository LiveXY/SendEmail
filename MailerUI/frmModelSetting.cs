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
	public partial class frmModelSetting : DockContent {
		private ModelSetting modelSetting;

		public frmModelSetting() {
			InitializeComponent();
			frmMain.Instance.ControlsHint(this);
		}

		private void mnuEdit_Click(object sender, EventArgs e) {
			ModelSetting info = new ModelSetting();
			info.ModelName = txtModelName.Text;
			info.UserName = txtUserName.Text;
			info.MPassword = txtPassword.Text;
			if (modelSetting.IsNull() || modelSetting.ModelID.IsNull()) {
				info.ModelID = 1;
				ModelSettingHelper.Insert(info);
			} else {
				info.ModelID = modelSetting.ModelID;
				ModelSettingHelper.Update(info);
			}
			ModelSettingHelper.ClearCacheAll();

			MessageBox.Show("保存数据成功！", " 系统提示");
			this.Close();
		}

		private void mnuExit_Click(object sender, EventArgs e) {
			Close();
		}

		private void frmRoute_Activated(object sender, EventArgs e) {
			frmMain.Instance.ShowStatusText("正在数据....");
			modelSetting = ModelSettingHelper.SelectByID(1);
			if (modelSetting.IsNull() || modelSetting.ModelID.IsNull()) return;
			txtModelName.Text = modelSetting.ModelName;
			txtPassword.Text = modelSetting.MPassword;
			txtUserName.Text = modelSetting.UserName;
			frmMain.Instance.ShowStatusText("数据加载完成！");
		}
	}
}
