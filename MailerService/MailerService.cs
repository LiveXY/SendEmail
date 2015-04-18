using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using TH.Mailer;
using Pub.Class;

namespace MailerService {
    partial class MailerService : ServiceBase {
        public MailerService() {
            InitializeComponent();
        }

        protected override void OnStart(string[] args) {
            MailerCenter.Start((msg) => {
                msg = "[{0}]-{1}".FormatWith(DateTime.Now.ToDateTimeFFF(), msg);
                Log.WriteLog(msg);
            });
        }

        protected override void OnStop() {
            MailerCenter.Stop();
        }
    }
}
