using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using Pub.Class;

namespace MailerService {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main() {
            Data.UsePool("ConnString");

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] { new MailerService() };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
