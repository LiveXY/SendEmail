using System;
using System.Collections.Generic;
using System.Text;
using TH.Mailer;
using Pub.Class;
using TH.Mailer.Entity;
using TH.Mailer.Helper;

namespace Mailer {
	class Program {
        private static Dictionary<string, string> setDic = new Dictionary<string, string>() { 
            { "connect_type", SendSetting._ConnectType },
            { "send_interval", SendSetting._SendInterval },
            { "change_ip", SendSetting._IPInterval },
            { "change_smtp", SendSetting._SmtpInterval },
            { "clear_ip", SendSetting._DeleteInterval },
            { "net_retry", SendSetting._MaxRetryCount },
            { "send_retry", SendSetting._SendRetryCount },
            { "status", SendSetting._Status },
        };
		[STAThread]
		public static void Main(string[] args) {
			Data.UsePool("ConnString");
			if (args.Length == 0) Help(); else Parse(args.Join(" "), true);
		}
		public static void Input(bool first = false) {
            if (first) {
                Console.Write("按任意键退出！");
                Console.ReadKey();
                return;
            }
			Console.Write("> ");
			Parse(Console.ReadLine());
		}
        public static void WriteLog(string msg) { Console.WriteLine(msg); }
        public static void Parse(string cmd, bool first = false) {
			string[] args = cmd.Split(' ');
			cmd = args[0].Trim().ToLower();
			switch (cmd) {
				case "h":
				case "help": Help(first); break;
				case "s":
				case "send": Send(first); break;
				case "rs":
				case "resend": Resend(first); break;
				case "ss":
				case "smtps": Smtps(first); break;
				case "es":
				case "emails": Emails(first); break;
				case "ts":
				case "templates": Templates(first); break;
				case "c":
				case "config": Config(first); break;
				case "sc": SetConfig(args, first); break;
				case "set":
					if (args.Length == 1) { Input(first); break; }
					if (args[1].Trim().ToLower() == "config") { SetConfig(args, first); break; }
					Input(first); break;
                case "in":
				case "import":
					if (args.Length == 1) { Input(first); break; }
					Import(args, first); break;
				case "cls":
				case "clear": Console.Clear(); Input(first); break;
				case "q":
				case "quit": break;
				default: Input(first); break;
			}
		}
		public static void Import(string[] args, bool first = false){
            if (args.Length != 3) Input(first);
            if (args[1].Trim().ToLower() == "smtp") Console.WriteLine("import(in) smtp path 批量导入SMTP");
            if (args[1].Trim().ToLower() == "email") Console.WriteLine("import(in) email path 批量导入邮箱");
            Console.WriteLine("===============================================================================");
            if (args[1].Trim().ToLower() == "smtp") importSmtpList(args[2]);
            if (args[1].Trim().ToLower() == "email") importEmailList(args[2]);
            Console.WriteLine("END");
            Input(first);
		}
        private static void importSmtpList(string fileName) {
            int totals = 0; int success = 0;
            WriteLog("");
            WriteLog("正在读取数据.....");
            IList<string> data = FileDirectory.FileRead(fileName, FileDirectory.FileEncoding(fileName));
            totals = data.Count;
            WriteLog("读取到：" + totals + " 行记录！");

            WriteLog("正在导入数据.....");
            int index = 1;
            int port = 25;
            foreach (string str in data) {
                string[] list = str.Split(',');
                if (list.Length != 3) {
                    WriteLog("第" + index.ToString() + "行数据格式不正确：" + str);
                } else { 
                    string smtp = list[0].Trim();
                    string userName = list[1].Trim();

                    if (!IsSmtp(smtp)) {
                        WriteLog("第" + index.ToString() + "行Smtp服务器地址格式不正确：" + str);
                    } else {
                        if (SmtpListHelper.IsExistByID(smtp, port, userName)) {
                            WriteLog("第" + index.ToString() + "行数据已存在：" + str);
                        } else {
                            SmtpList info = new SmtpList();
                            info.SmtpServer = list[0];
                            info.UserName = list[1];
                            info.SPassword = list[2];
                            info.SmtpPort = 25;
                            info.CreateTime = DateTime.Now.ToDateTime().ToDateTime();
                            SmtpListHelper.Insert(info);
                            success++;
                        }
                    }
                }
                index++;
            }
            SmtpListHelper.ClearCacheAll();
            WriteLog("导入Smtp服务器列表完成：共 {0} 条记录，成功 {1} 条记录，失败 {2} 条记录！".FormatWith(totals, success, totals - success));
        }
        private static bool IsSmtp(string smtp) {
            string[] list = smtp.Split('.');
            if (list.Length >= 3) {
                return true;
            }
            return false;
        }
        private static void importEmailList(string fileName) {
            int totals = 0; int success = 0;
            WriteLog("");
            WriteLog("正在读取数据.....");
            IList<string> data = FileDirectory.FileRead(fileName, FileDirectory.FileEncoding(fileName));
            totals = data.Count;
            WriteLog("读取到：" + totals + " 行记录！");

            WriteLog("正在导入数据.....");
            int index = 1;
            foreach (string str in data) {
                string[] list = str.Split(',');
                string email = list[0].Trim();
                if (!email.IsEmail()) {
                    WriteLog("第" + index.ToString() + "行Email地址格式不正确：" + str);
                } else {
                    if (EmailListHelper.IsExistByID(email)) {
                        WriteLog("第" + index.ToString() + "行数据已存在：" + str);
                    } else {
                        EmailList info = new EmailList();
                        info.EmailAddress = email;
                        info.NickName = email.Split('@')[0];
                        if (list.Length == 10) {
                            info.ex0 = list[1];
                            info.ex1 = list[2];
                            info.ex2 = list[3];
                            info.ex3 = list[4];
                            info.ex4 = list[5];
                            info.ex5 = list[6];
                            info.ex6 = list[7];
                            info.ex7 = list[8];
                            info.ex8 = list[9];
                        }
                        info.CreateTime = DateTime.Now.ToDateTime().ToDateTime();
                        EmailListHelper.Insert(info);
                        success++;
                    }
                }
                index++;
            }
            EmailListHelper.ClearCacheAll();
            WriteLog("导入Email列表完成：共 {0} 条记录，成功 {1} 条记录，失败 {2} 条记录！".FormatWith(totals, success, totals - success));
        }
        public static void SetConfig(string[] args, bool first = false) {
            if (args.Length != 3) Input(first);
            string cmd = args[1].Trim().ToLower();
            int value = args[2].ToInt();
            if (setDic.ContainsKey(cmd)) {
                Console.WriteLine("sc {0} {1} 修改发送配置".FormatWith(cmd, value));
                Console.WriteLine("===============================================================================");
                int result = new SQL().Update(SendSetting._).Set(setDic[cmd], value).ToExec();
                Console.WriteLine(result > 0 ? "操作成功！" : "操作失败！");
                if (result > 0) SendSettingHelper.ClearCacheSelectByID(1);
            }
            Console.WriteLine("END");
            Input(first);
		}
		public static void Config(bool first = false) {
            Console.WriteLine("config(c) 显示发送配置");
            Console.WriteLine("===============================================================================");
			SendSetting sendSetting = SendSettingHelper.SelectByID(1);
			Console.WriteLine("网络连接类型：{0}", NetHelper.GetNetName(sendSetting.ConnectType.Value));
			Console.WriteLine("发送邮件时间间隔(毫秒)：{0}", sendSetting.SendInterval);
			Console.WriteLine("发送多少封邮件后更换IP：{0}", sendSetting.IPInterval == 0 ? "0不更换IP" : sendSetting.IPInterval.ToString());
			Console.WriteLine("发送多少封邮件后更换SMTP：{0}", sendSetting.SmtpInterval == 0 ? "0不更换SMTP" : sendSetting.SmtpInterval.ToString());
			Console.WriteLine("清理多少分钟之前的历史IP：{0}", sendSetting.DeleteInterval);
			Console.WriteLine("检测网络连接重试次数：{0}", sendSetting.MaxRetryCount);
			Console.WriteLine("发送邮件失败重试次数：{0}", sendSetting.SendRetryCount);
			Console.WriteLine("发送状态：{0}", sendSetting.Status == 0 ? "等待发送" : sendSetting.Status == 1 ? "正在发送" : "已发送完成");
			Console.WriteLine("END");
			Input(first);
		}
		public static void Resend(bool first = false) {
            Console.WriteLine("resend(rs) 重新发送邮件");
            Console.WriteLine("===============================================================================");
			SendSettingHelper.Update(new SendSetting() { SettingID = 1, Status = 0 });
            SendSettingHelper.ClearCacheSelectByID(1);

			new SQL()
				.Update(EmailList._)
				.Set(EmailList._LastSendStatus, 0)
				.Set(EmailList._LastSendError, "")
				.Set(EmailList._LastSendTime, null, true)
				.Set(EmailList._LastSendSmtp, "")
				.Set(EmailList._SendCount, 0)
				.ToExec();

			new SQL().Update(SmtpList._)
				.Set(SmtpList._Sends, 0)
				.Set(SmtpList._SendFails, 0)
				.ToExec();

			MailerCenter.Start((msg) => {
				msg = "[{0}]-{1}".FormatWith(DateTime.Now.ToDateTimeFFF(), msg);
				Console.WriteLine(msg);
			}, () => { Console.WriteLine("END"); Console.Write("> "); });
			Parse(Console.ReadLine());
		}
		public static void Templates(bool first = false) {
            Console.WriteLine("templates(ts) 显示模板列表");
            Console.WriteLine("===============================================================================");
			IList<HtmlTemplate> templateList = HtmlTemplateHelper.SelectListByAll();
			foreach(var t in templateList) Console.WriteLine("{0}-{1}", t.TemplateID, t.Subject);
			Console.WriteLine("count:{0}", templateList.Count);
			Console.WriteLine("END");
			Input(first);
		}
		public static void Smtps(bool first = false) {
            Console.WriteLine("smtps(ss) 显示SMTP列表");
            Console.WriteLine("===============================================================================");
			IList<SmtpList> smtpList = SmtpListHelper.SelectListByAll();
			foreach(var smtp in smtpList) Console.WriteLine("{0},{1},{2}", smtp.SmtpServer, smtp.SmtpPort, smtp.UserName);
			Console.WriteLine("count:{0}", smtpList.Count);
			Console.WriteLine("END");
			Input(first);
		}
		public static void Emails(bool first = false) {
            Console.WriteLine("emails(es) 显示邮箱列表");
            Console.WriteLine("===============================================================================");
            int count = new SQL().From(EmailList._).Count(EmailList._EmailAddress).ToScalar().ToString().ToInt();
            if (count > 100) {
                Console.WriteLine("数据太多不显示！");
                Console.WriteLine("count:{0}", count);
            } else {
                IList<EmailList> emailList = EmailListHelper.SelectListByAll();
                foreach (var email in emailList) Console.WriteLine(email.EmailAddress);
                Console.WriteLine("count:{0}", emailList.Count);
            }
			Console.WriteLine("END");
			Input(first);
		}
		public static void Send(bool first = false) {
            Console.WriteLine("send(s) 发送邮件");
            Console.WriteLine("===============================================================================");
			MailerCenter.Start((msg) => {
				msg = "[{0}]-{1}".FormatWith(DateTime.Now.ToDateTimeFFF(), msg);
				Console.WriteLine(msg);
			}, () => { Console.WriteLine("END"); Console.Write("> "); });
			Parse(Console.ReadLine());
		}
		public static void Help(bool first = false) {
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
			Console.Write("templates(ts)".PadRight(len, ' '));
			Console.WriteLine("显示模板列表");
			Console.Write("config(c)".PadRight(len, ' '));
			Console.WriteLine("显示发送配置");
			Console.Write("set config(sc)".PadRight(len, ' '));
			Console.WriteLine("修改发送配置");
			Console.Write("  sc connect_type n".PadRight(len + 10, ' '));
			Console.WriteLine("设置网络连接类型(0路由连接/1拨号连接/2天翼无线宽带)");
			Console.Write("  sc send_interval n".PadRight(len + 10, ' '));
			Console.WriteLine("设置发送邮件时间间隔(毫秒)");
			Console.Write("  sc change_ip n".PadRight(len + 10, ' '));
			Console.WriteLine("设置发送多少封邮件后更换IP");
			Console.Write("  sc change_smtp n".PadRight(len + 10, ' '));
			Console.WriteLine("设置发送多少封邮件后更换SMTP");
			Console.Write("  sc clear_ip n".PadRight(len + 10, ' '));
			Console.WriteLine("设置清理多少分钟之前的历史IP");
			Console.Write("  sc net_retry n".PadRight(len + 10, ' '));
			Console.WriteLine("设置检测网络连接重试次数");
			Console.Write("  sc send_retry n".PadRight(len + 10, ' '));
			Console.WriteLine("设置发送邮件失败重试次数");
			Console.Write("  sc status n".PadRight(len + 10, ' '));
			Console.WriteLine("设置发送状态(0等待发送/1正在发送/2已发送完成)");
            Console.Write("import(in)".PadRight(len, ' '));
            Console.WriteLine("导入数据");
            Console.Write("  in smtp path".PadRight(len + 10, ' '));
            Console.WriteLine("批量导入SMTP");
            Console.Write("  in email path".PadRight(len + 10, ' '));
            Console.WriteLine("批量导入邮箱");
			Console.Write("quit(q)".PadRight(len, ' '));
			Console.WriteLine("退出");
			Console.WriteLine("");
			Input(first);
		}
	}
}
