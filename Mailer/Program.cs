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
				case "sc": SetConfig(args); break;
				case "set":
					if (args.Length == 1) { Input(); break; }
					if (args[1].Trim().ToLower() == "config") { SetConfig(args); break; }
					Input(); break;
				case "import(in)":
					if (args.Length == 1) { Input(); break; }
					Import(args); break;
				case "cls":
				case "clear": Console.Clear(); Input(); break;
				case "q":
				case "quit": break;
				default: Input(); break;
			}
		}
		public static void Import(string[] args){
            if (args[1].Trim().ToLower() == "smtp") Console.WriteLine("批量导入SMTP");
            if (args[1].Trim().ToLower() == "email") Console.WriteLine("批量导入SMTP");
            Console.WriteLine("===============================================================================");
            Console.WriteLine("END");
            Input();

		}
		public static void SetConfig(string[] args) {
            Console.WriteLine("修改发送配置");
            Console.WriteLine("===============================================================================");
            Console.WriteLine("END");
            Input();
		}
		public static void Config() {
            Console.WriteLine("显示发送配置");
            Console.WriteLine("===============================================================================");
			SendSetting sendSetting = SendSettingHelper.SelectByID(1);
			Console.WriteLine("网络连接类型：{0}", NetHelper.GetNetName(sendSetting.ConnectType.Value));
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
            Console.WriteLine("重新发送邮件");
            Console.WriteLine("===============================================================================");
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
            Console.WriteLine("显示模板列表");
            Console.WriteLine("===============================================================================");
			IList<HtmlTemplate> templateList = HtmlTemplateHelper.SelectListByAll();
			foreach(var t in templateList) Console.WriteLine("{0}-{1}", t.TemplateID, t.Subject);
			Console.WriteLine("count:{0}", templateList.Count);
			Console.WriteLine("END");
			Input();
		}
		public static void Smtps() {
            Console.WriteLine("显示SMTP列表");
            Console.WriteLine("===============================================================================");
			IList<SmtpList> smtpList = SmtpListHelper.SelectListByAll();
			foreach(var smtp in smtpList) Console.WriteLine("{0},{1},{2}", smtp.SmtpServer, smtp.SmtpPort, smtp.UserName);
			Console.WriteLine("count:{0}", smtpList.Count);
			Console.WriteLine("END");
			Input();
		}
		public static void Emails() {
            Console.WriteLine("显示邮箱列表");
            Console.WriteLine("===============================================================================");
			IList<EmailList> emailList = EmailListHelper.SelectListByAll();
			foreach(var email in emailList) Console.WriteLine(email.EmailAddress);
			Console.WriteLine("count:{0}", emailList.Count);
			Console.WriteLine("END");
			Input();
		}
		public static void Send() {
            Console.WriteLine("发送邮件");
            Console.WriteLine("===============================================================================");
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
			Input();
		}
	}
}
