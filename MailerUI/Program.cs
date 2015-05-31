using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using Pub.Class;
using System.Threading;


namespace MailerUI {
	static class Program {
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() {
			Data.UsePool("ConnString");
			//MessageBox.Show ("1");
			//bool isRunning;
			//try {
			//Mutex m = new Mutex(true, "MailerUI", out isRunning);
			//	if (!isRunning) { 
			//		Application.Exit();
			//		return;
			//	}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain());
			//	m.ReleaseMutex();
			//}
			//catch (Exception ex) {
			//     string s = ex.Message;
			//}


		}
	}
}
