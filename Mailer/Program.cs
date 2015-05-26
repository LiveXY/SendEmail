using System;
using System.Collections.Generic;
using System.Text;
using TH.Mailer;
using Pub.Class;
using TH.Mailer.Entity;
using TH.Mailer.Helper;

namespace Mailer {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            Data.UsePool("ConnString");
            if (args.Length == 0) Help(); else Parse(args[0]);
        }
        public static void Input() { 
            Console.Write("> ");
            Parse(Console.ReadLine());
        }
        public static void Parse(string cmd) {
            string[] args = cmd.Split(' ');
            cmd = args[0].Trim().ToLower();
            switch (cmd) {
                case "h":
                case "help": Help(); break;
                case "s":
                case "send": Send(); break;
                case "rs":
                case "resend": Resend(); break;
                case "ss":
                case "smtps": Smtps(); break;
                case "es":
                case "emails": Emails(); break;
                case "ts":
                case "templates": Templates(); break;
                case "c":
                case "config": Config(); break;
                case "cls":
                case "clear": Console.Clear(); Input(); break;
                case "q":
                case "quit": break;
                default: Input(); break;
            }
        }
        public static void Config() { 
            SendSetting sendSetting = SendSettingHelper.SelectByID(1);
            Console.WriteLine("连接类型：{0}", NetHelper.GetNetName(sendSetting.ConnectType.Value));
            Console.WriteLine("发送邮件时间间隔(毫秒)：{0}", sendSetting.SendInterval);
            Console.WriteLine("发送多少封邮件后更换IP：{0}", sendSetting.IPInterval == 0 ? "不更换IP" : sendSetting.IPInterval.ToString());
            Console.WriteLine("发送多少封邮件后更换SMTP：{0}", sendSetting.SmtpInterval == 0 ? "不更换SMTP" : sendSetting.SmtpInterval.ToString());
            Console.WriteLine("清理多少分钟之前的历史IP：{0}", sendSetting.DeleteInterval);
            Console.WriteLine("检测网络连接重试次数：{0}", sendSetting.MaxRetryCount);
            Console.WriteLine("发送邮件失败重试次数：{0}", sendSetting.SendRetryCount);
            Console.WriteLine("发送状态：{0}", sendSetting.Status == 0 ? "等待发送" : sendSetting.Status == 1 ? "正在发送" : "已发送完成");
            Console.WriteLine("END");
            Input();
        }
        public static void Resend() {
            SendSettingHelper.Update(new SendSetting() { SettingID = 1, Status = 0 });
            new SQL()
                .Update(EmailList._)
                .Set("LastSendStatus", 0)
                .Set("LastSendError", "")
                .Set("LastSendTime", null, true)
                .Set("LastSendSmtp", "")
                .Set("SendCount", 0)
                .ToExec();

            new SQL().Update(SmtpList._)
                .Set("Sends", 0)
                .Set("SendFails", 0)
                .ToExec();

            Send();
        }
        public static void Templates() { 
            IList<HtmlTemplate> templateList = HtmlTemplateHelper.SelectListByAll();
            foreach(var t in templateList) Console.WriteLine("{0}-{1}", t.TemplateID, t.Subject);
            Console.WriteLine("count:{0}", templateList.Count);
            Console.WriteLine("END");
            Input();
        }
        public static void Smtps() { 
            int totals = 0;
            IList<SmtpList> smtpList = SmtpListHelper.SelectPageList(1, 50, out totals);
            foreach(var smtp in smtpList) Console.WriteLine("{0},{1},{2}", smtp.SmtpServer, smtp.SmtpPort, smtp.UserName);
            Console.WriteLine("count:{0}", totals);
            Console.WriteLine("END");
            Input();
        }
        public static void Emails() {
            int totals = 0;
            IList<EmailList> emailList = EmailListHelper.SelectPageList(1, 50, out totals);
            foreach(var email in emailList) Console.WriteLine(email.EmailAddress);
            Console.WriteLine("count:{0}", totals);
            Console.WriteLine("END");
            Input();
        }
        public static void Send() { 
            MailerCenter.Start((msg) => {
                msg = "[{0}]-{1}".FormatWith(DateTime.Now.ToDateTimeFFF(), msg);
                Console.WriteLine(msg);
            }, () => { Console.WriteLine("END"); Console.Write("> "); });
            Parse(Console.ReadLine());
        }
        public static void Help() {
            int len = 15;
            Console.WriteLine("邮件群发操作指令：");
            Console.Write("help(h)".PadRight(len, ' '));
            Console.WriteLine("帮助");
            Console.Write("send(s)".PadRight(len, ' '));
            Console.WriteLine("发送邮件");
            Console.Write("resend(rs)".PadRight(len, ' '));
            Console.WriteLine("重新发送邮件");
            Console.Write("smtps(ss)".PadRight(len, ' '));
            Console.WriteLine("显示SMTP列表");
            Console.Write("emails(es)".PadRight(len, ' '));
            Console.WriteLine("显示邮箱列表");
            Console.Write("template(ts)".PadRight(len, ' '));
            Console.WriteLine("显示模板列表");
            Console.Write("config(c)".PadRight(len, ' '));
            Console.WriteLine("显示发送配置");
            Console.Write("quit(q)".PadRight(len, ' '));
            Console.WriteLine("退出");
            Console.WriteLine("");
            Input();
        }
    }
}
