using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml.Serialization;
using System.Xml;
using System.Collections;
using System.Net;
using TH.Mailer.Entity;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using TH.Mailer.Helper;
using System.Threading;
using Pub.Class;

namespace TH.Mailer {
	public class TianYiController : IController {
		private TianYiSetting setting;

		public TianYiController() { setting = TianYiSettingHelper.SelectByID(1); }

		/// <summary>
		/// 连接
		/// </summary>
		/// <returns></returns>
		public bool Connect() {
			if (FileDirectory.FileExists(setting.TianYiExePath)) {
				Safe.RunAsync(setting.TianYiExePath);
				return true;
			}
			return false;
		}

		/// <summary>
		/// 断开连接
		/// </summary>
		/// <returns></returns>
		public bool Disconnect() {
			Safe.RunWait("cmd.exe", new string[] { "rundll32.exe iedkcs32.dll CloseRASConnections", "exit" }, null);
			string name = setting.TianYiExePath.GetFileNameWithoutExtension();
			Safe.KillProcess(name);
			return true;
		}

		/// <summary>
		/// 重新连接
		/// </summary>
		/// <returns></returns>
		public string Reset() {
			this.Disconnect();
			Thread.Sleep(2000);
			this.Connect();
			Thread.Sleep(5000);
			return string.Empty;
		}
	}
}