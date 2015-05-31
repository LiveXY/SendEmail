using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml.Serialization;
using System.Xml;
using System.Collections;
using System.Net;
using Pub.Class;

namespace TH.Mailer {
	public class MailerCenter {
		private static Mailer mailer = new Mailer();

		/// <summary>
		/// 开始群发邮件
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="done"></param>
		public static void Start(Action<string> msg = null, Pub.Class.Action done = null) {
			ServicePointManager.DefaultConnectionLimit = 10000;
			mailer.Start(msg, done);
		}

		/// <summary>
		/// 停止发送
		/// </summary>
		public static void Stop() {
			mailer.Stop();
		}

		/// <summary>
		/// 停止
		/// </summary>
		public static void Abort() {
			mailer.Abort();
		}
	}

}