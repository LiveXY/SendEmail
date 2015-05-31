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
using TH.Mailer.Helper;
using System.Threading;
using Pub.Class;

namespace TH.Mailer {
	public class RouteController : IController {

		private RouteSetting routeInfo;

		public RouteController() {
			routeInfo = RouteSettingHelper.SelectByID(1);
		}

		/// <summary>
		/// 重启路由
		/// </summary>
		private string reset(string url, string userName, string password, string method, string data) {
			CookieContainer container = new CookieContainer();
			string requestUriString = url;
			if (method == "GET") requestUriString += "?" + data;
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
			request.Method = method;
			if (method == "POST") {
				byte[] POSTData = new UTF8Encoding().GetBytes(data);
				request.ContentLength = POSTData.Length;
				request.GetRequestStream().Write(POSTData, 0, POSTData.Length);
			}
			request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0;CIBA)";
			request.CookieContainer = container;
			request.KeepAlive = true;
			request.Accept = "*/*";
			request.Timeout = 3000;
			request.PreAuthenticate = true;
			CredentialCache cache = new CredentialCache();
			cache.Add(new Uri(requestUriString), "Basic", new NetworkCredential(routeInfo.UserName, routeInfo.RPassword));
			request.Credentials = cache;
			try {
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				response.Cookies = container.GetCookies(request.RequestUri);
				new StreamReader(response.GetResponseStream(), Encoding.Default).Close();
				response.Close();
				return string.Empty;
			} catch (Exception ex) {
				return ex.Message;
			}
		}

		/// <summary>
		/// 重启路由
		/// </summary>
		/// <returns></returns>
		public string Reset() {
			string message = string.Empty;
			if (!routeInfo.RouteDisConnect.IsNullEmpty()) message += reset(routeInfo.RouteIP, routeInfo.UserName, routeInfo.RPassword, routeInfo.RouteMethod, routeInfo.RouteDisConnect);
			Thread.Sleep(1000); //断开连接后停止1秒
			if (!routeInfo.RouteConnect.IsNullEmpty()) message += reset(routeInfo.RouteIP, routeInfo.UserName, routeInfo.RPassword, routeInfo.RouteMethod, routeInfo.RouteConnect);
			Thread.Sleep(3000); //连接后停止3秒 等待本地断网
			return message;
		}
	}

}