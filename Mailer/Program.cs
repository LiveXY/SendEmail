using System;
using System.Collections.Generic;
using System.Text;
using TH.Mailer;
using Pub.Class;
using Pub.Class.Linq;
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
			{ "template", SendSetting._TemplateID },
		};
		[STAThread]
		public static void Main(string[] args) {
			Data.UsePool("ConnString");
			if (args.Length == 0) Help(); else Parse(args.Join(" "), true);
		}
		public static void Input(bool exit = false) {
			if (exit) return;
			Console.Write("> ");
			Parse(Console.ReadLine());
		}
		private static void WriteLog(string msg) { Console.WriteLine(msg); }
		private static void WriteLog(string format, params object[] args) { Console.WriteLine(format, args); }
		public static void Parse(string cmd, bool exit = false) {
			string[] args = cmd.Split(' ');
			cmd = args[0].Trim().ToLower();
			switch (cmd) {
				case "h":
				case "help": Help(exit); break;
				case "s":
				case "send": Send(exit); break;
				case "rs":
				case "resend": Resend(exit); break;
				case "ss":
				case "smtps": Smtps(exit); break;
				case "es":
				case "emails": Emails(exit); break;
				case "ts":
				case "templates": Templates(exit); break;
				case "c":
				case "config": Config(exit); break;
				case "sc": SetConfig(args, exit); break;
				case "set":
					if (args.Length == 1) { Input(exit); break; }
					if (args[1].Trim().ToLower() == "config") { SetConfig(args, exit); break; }
					Input(exit); break;
				case "in":
				case "import":
					if (args.Length == 1) { Input(exit); break; }
					Import(args, exit); break;
				case "d":
				case "delete":
					if (args.Length == 1) { Input(exit); break; }
					Delete(args, exit); break;
				case "cls":
				case "clear": Console.Clear(); Input(exit); break;
				case "q":
				case "quit": break;
				default: Input(exit); break;
			}
		}
		public static void Delete(string[] args, bool exit = false){
			if (args.Length == 2) args = (string.Join(" ", args) + " *").Split(" ");
			if (args[1].Trim().ToLower() == "smtp") WriteLog("delete(d) smtp * 删除SMTP数据");
			if (args[1].Trim().ToLower() == "email") WriteLog("delete(d) email * 删除邮箱数据");
			WriteLog("===============================================================================");
			if (args[1].Trim().ToLower() == "smtp") {
				args = string.Join(" ", args, 2, args.Length - 2).Split(' ');
				int len = 0;
				if (args.Length == 1 && args [0] == "*")
					len = new SQL().Delete(SmtpList._).ToExec();
				else
					foreach (string s in args) {
						string[] ss = s.Split(',');
						if (ss.Length != 3) continue;
						len += SmtpListHelper.DeleteByID(ss[0], ss[1].ToInt(25), ss[2]) ? 1 : 0;
					}
				WriteLog("删除影响行数：{0}", len);
				SmtpListHelper.ClearCacheAll();
			} else if (args[1].Trim().ToLower() == "email") {
				args = string.Join(" ", args, 2, args.Length - 2).Split(' ');
				int len = 0;
				if (args.Length == 1 && args [0] == "*")
					len = new SQL().Delete(EmailList._).ToExec();
				else
					foreach (string s in args) len += EmailListHelper.DeleteByID(s) ? 1 : 0;
				WriteLog("删除影响行数：{0}", len);
				EmailListHelper.ClearCacheAll();
			}
			WriteLog("END");
			Input(exit);
		}
		public static void Import(string[] args, bool exit = false){
			if (args.Length != 3) Input(exit);
			if (args[1].Trim().ToLower() == "smtp") WriteLog("import(in) smtp path 批量导入SMTP");
			if (args[1].Trim().ToLower() == "email") WriteLog("import(in) email path 批量导入邮箱");
			WriteLog("===============================================================================");
			if (args[1].Trim().ToLower() == "smtp") importSmtpList(args[2]);
			if (args[1].Trim().ToLower() == "email") importEmailList(args[2]);
			WriteLog("END");
			Input(exit);
		}
		private static void importSmtpList(string fileName) {
			int totals = 0; int success = 0;
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
		public static void SetConfig(string[] args, bool exit = false) {
			if (args.Length != 3) Input(exit);
			string cmd = args[1].Trim().ToLower();
			int value = args[2].ToInt();
			if (setDic.ContainsKey(cmd)) {
				WriteLog("sc {0} {1} 修改发送配置".FormatWith(cmd, value));
				WriteLog("===============================================================================");
				int result = new SQL().Update(SendSetting._).Set(setDic[cmd], value).ToExec();
				WriteLog(result > 0 ? "操作成功！" : "操作失败！");
				if (result > 0) SendSettingHelper.ClearCacheSelectByID(1);
			}
			WriteLog("END");
			Input(exit);
		}
		public static void Config(bool exit = false) {
			WriteLog("config(c) 显示发送配置");
			WriteLog("===============================================================================");
			SendSetting sendSetting = SendSettingHelper.SelectByID(1);
			IList<HtmlTemplate> templateList = HtmlTemplateHelper.SelectListByAll();
			WriteLog("邮件模版：{0}", templateList.Where(p => p.TemplateID == sendSetting.TemplateID).FirstOrDefault().IfNull(new HtmlTemplate()).Subject ?? "无");
			WriteLog("网络连接类型：{0}", NetHelper.GetNetName(sendSetting.ConnectType.Value));
			WriteLog("发送邮件时间间隔(毫秒)：{0}", sendSetting.SendInterval);
			WriteLog("发送多少封邮件后更换IP：{0}", sendSetting.IPInterval == 0 ? "0不更换IP" : sendSetting.IPInterval.ToString());
			WriteLog("发送多少封邮件后更换SMTP：{0}", sendSetting.SmtpInterval == 0 ? "0不更换SMTP" : sendSetting.SmtpInterval.ToString());
			WriteLog("清理多少分钟之前的历史IP：{0}", sendSetting.DeleteInterval);
			WriteLog("检测网络连接重试次数：{0}", sendSetting.MaxRetryCount);
			WriteLog("发送邮件失败重试次数：{0}", sendSetting.SendRetryCount);
			WriteLog("发送状态：{0}", sendSetting.Status == 0 ? "等待发送" : sendSetting.Status == 1 ? "正在发送" : "已发送完成");
			WriteLog("-------------------------------------------------------------------------------");
			WriteLog("可用邮箱数量：{0}".FormatWith(new SQL().From(EmailList._).Count(EmailList._EmailAddress).ToScalar().ToString()));
			WriteLog("可用SMTP数量：{0}".FormatWith(new SQL().From(SmtpList._).Count(SmtpList._SmtpServer).ToScalar().ToString()));
			WriteLog("END");
			Input(exit);
		}
		public static void Resend(bool exit = false) {
			WriteLog("resend(rs) 重新发送邮件");
			WriteLog("===============================================================================");
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
				WriteLog(msg);
			}, () => { WriteLog("END");if (exit) System.Environment.Exit(0); Console.Write("> "); });
			Parse(Console.ReadLine());
		}
		public static void Templates(bool exit = false) {
			WriteLog("templates(ts) 显示模板列表");
			WriteLog("===============================================================================");
			IList<HtmlTemplate> templateList = HtmlTemplateHelper.SelectListByAll();
			foreach(var t in templateList) WriteLog("{0}-{1}", t.TemplateID, t.Subject);
			WriteLog("count:{0}", templateList.Count);
			WriteLog("END");
			Input(exit);
		}
		public static void Smtps(bool exit = false) {
			WriteLog("smtps(ss) 显示SMTP列表");
			WriteLog("===============================================================================");
			IList<SmtpList> smtpList = SmtpListHelper.SelectListByAll();
			foreach(var smtp in smtpList) WriteLog("{0},{1},{2}", smtp.SmtpServer, smtp.SmtpPort, smtp.UserName);
			WriteLog("count:{0}", smtpList.Count);
			WriteLog("END");
			Input(exit);
		}
		public static void Emails(bool exit = false) {
			WriteLog("emails(es) 显示邮箱列表");
			WriteLog("===============================================================================");
			int count = new SQL().From(EmailList._).Count(EmailList._EmailAddress).ToScalar().ToString().ToInt();
			if (count > 100) {
				WriteLog("数据太多不显示！");
				WriteLog("count:{0}", count);
			} else {
				IList<EmailList> emailList = EmailListHelper.SelectListByAll();
				foreach (var email in emailList) WriteLog(email.EmailAddress);
				WriteLog("count:{0}", emailList.Count);
			}
			WriteLog("END");
			Input(exit);
		}
		public static void Send(bool exit = false) {
			WriteLog("send(s) 发送邮件");
			WriteLog("===============================================================================");
			MailerCenter.Start((msg) => {
				msg = "[{0}]-{1}".FormatWith(DateTime.Now.ToDateTimeFFF(), msg);
				WriteLog(msg);
			}, () => { WriteLog("END"); if (exit) System.Environment.Exit(0); Console.Write("> "); });
			Parse(Console.ReadLine());
		}
		public static void Help(bool exit = false) {
			int len = 25;
			Console.Clear();
			WriteLog("邮件群发操作指令：");
			Console.Write("help(h)".PadRight(len, ' '));
			WriteLog("帮助");
			Console.Write("send(s)".PadRight(len, ' '));
			WriteLog("发送邮件");
			Console.Write("resend(rs)".PadRight(len, ' '));
			WriteLog("重新发送邮件");
			Console.Write("smtps(ss)".PadRight(len, ' '));
			WriteLog("显示SMTP列表");
			Console.Write("emails(es)".PadRight(len, ' '));
			WriteLog("显示邮箱列表");
			Console.Write("templates(ts)".PadRight(len, ' '));
			WriteLog("显示模板列表");
			Console.Write("config(c)".PadRight(len, ' '));
			WriteLog("显示发送配置");
			Console.Write("set config(sc)".PadRight(len, ' '));
			WriteLog("修改发送配置");
			Console.Write("  sc template n".PadRight(len, ' '));
			WriteLog("设置邮件模版");
			Console.Write("  sc connect_type n".PadRight(len, ' '));
			WriteLog("设置网络连接类型(0路由连接/1拨号连接/2天翼无线宽带)");
			Console.Write("  sc send_interval n".PadRight(len, ' '));
			WriteLog("设置发送邮件时间间隔(毫秒)");
			Console.Write("  sc change_ip n".PadRight(len, ' '));
			WriteLog("设置发送多少封邮件后更换IP");
			Console.Write("  sc change_smtp n".PadRight(len, ' '));
			WriteLog("设置发送多少封邮件后更换SMTP");
			Console.Write("  sc clear_ip n".PadRight(len, ' '));
			WriteLog("设置清理多少分钟之前的历史IP");
			Console.Write("  sc net_retry n".PadRight(len, ' '));
			WriteLog("设置检测网络连接重试次数");
			Console.Write("  sc send_retry n".PadRight(len, ' '));
			WriteLog("设置发送邮件失败重试次数");
			Console.Write("  sc status n".PadRight(len, ' '));
			WriteLog("设置发送状态(0等待发送/1正在发送/2已发送完成)");
			Console.Write("import(in)".PadRight(len, ' '));
			WriteLog("导入数据");
			Console.Write("  in smtp path".PadRight(len, ' '));
			WriteLog("批量导入SMTP");
			Console.Write("  in email path".PadRight(len, ' '));
			WriteLog("批量导入邮箱");
			Console.Write("delete(d)".PadRight(len, ' '));
			WriteLog("删除数据");
			Console.Write("  d smtp *".PadRight(len, ' '));
			WriteLog("批量删除SMTP");
			Console.Write("  d email *".PadRight(len, ' '));
			WriteLog("批量删除邮箱");
			Console.Write("quit(q)".PadRight(len, ' '));
			WriteLog("退出");
			WriteLog("");
			Input(exit);
		}
	}
}
