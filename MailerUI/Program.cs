using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using Pub.Class;

namespace MailerUI {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Data.UsePool("ConnString");

            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            } catch (Exception ex) {
                string s = ex.Message;
            }
        }
    }
}
