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
using Pub.Class;
using System.Threading;
using TH.Mailer.Helper;
using System.Net.Sockets;

namespace TH.Mailer {
    public class NetHelper {
        private static SendSetting setting;
        /// <summary>
        /// 更换IP 
        /// </summary>
        /// <param name="netType">0表示路由 1表示拨号连接</param>
        /// <param name="msg">通知输出消息</param>
        /// <param name="done">完成时执行</param>
        /// <param name="index">第几次执行</param>
        /// <returns></returns>
        public static string ChangeIP(int netType, Action<string> msg = null, Action done = null, int index = 0) {
            string name = GetNetName(netType);
            setting = SendSettingHelper.SelectByID(1);

            if (setting.IsNull()) {
                if (!msg.IsNull()) msg("请修改发送设置！");
                if (!done.IsNull()) done();
                return "";
            } else {
                if (index == setting.MaxRetryCount) {
                    if (!done.IsNull()) done();
                    return "";
                }
                if (!msg.IsNull()) msg((index + 1).ToString());

                //清空多少分钟前的历史IP
                if (Data.Pool("ConnString").DBType == "SqlServer") {
                    "delete from IpHistory where CreateTime < DateAdd(MINUTE , -{0}, getdate())".FormatWith(setting.DeleteInterval).ToSQL().ToExec();
                } else if (Data.Pool("ConnString").DBType == "SQLite") {
                    "delete from IpHistory where datetime(CreateTime) < datetime('now','localtime', '-{0} minute')".FormatWith(setting.DeleteInterval).ToSQL().ToExec();
                }
                if (!msg.IsNull()) msg("正在重启" + name + "......");
                IController connect;
                switch (netType) {
                    case 1: connect = new ModelController(); break;
                    case 2: connect = new TianYiController(); break;
                    default: connect = new RouteController(); break;
                }
                string error = connect.Reset();
                if (!error.IsNullEmpty()) {
                    if (!msg.IsNull()) msg("重启" + name + "失败：" + error);
                    return ChangeIP(netType, msg, done, index + 1);
                } else {
                    if (!msg.IsNull()) msg("已重启" + name + "，正在检测是否联网......");
                    bool isTrue = NetHelper.CheckNetwork(msg);
                    if (!isTrue) return ChangeIP(netType, msg, done, index + 1);

                    if (!msg.IsNull()) msg("已联接网络，正在获取IP......");
                    string ip = IPHelper.GetIpFast();

                    if (!msg.IsNull()) msg("获取到IP：" + ip);
                    if (IpHistoryHelper.IsExistByID(ip)) {
                        if (!msg.IsNull()) msg("检测到IP：" + ip + "最近已使用！");
                        return ChangeIP(netType, msg, done, index + 1);
                    } else {
                        IpHistoryHelper.Insert(new IpHistory() { IP = ip, CreateTime = DateTime.Now });
                    };
                    return ip;
                }
            }
        }
        public static string GetNetName(int netType) {
            switch (netType) {
                case 0: return "路由";
                case 1: return "拨号连接";
                case 2: return "天翼无线宽带";
            }
            return "";
        }

        /// <summary>
        /// 检查网络是否可用
        /// </summary>
        public static bool CheckNetwork(Action<string> msg = null, int index = 0) {
            if (index == setting.MaxRetryCount) {
                if (!msg.IsNull()) msg("无法连接网络！");
                return false;
            }
            Thread.Sleep(1000);
            try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.baidu.com");
                request.Timeout = 3000;
                request.GetResponse().Close();
                if (!msg.IsNull()) msg("已联网！");
                return true;
            } catch {
                if (!msg.IsNull()) msg((index + 1).ToString() + "次未联网，继续尝试检测是否联网.....");
                return CheckNetwork(msg, index + 1);
            }
        }

        public static bool CheckSMTP(string userName, string password, string smtpServer, int port = 25) {
            try {
                Hashtable rightCodeHT = new Hashtable();
                rightCodeHT.Add("220", "");
                rightCodeHT.Add("250", "");
                rightCodeHT.Add("251", "");
                rightCodeHT.Add("354", "");
                rightCodeHT.Add("221", "");
                rightCodeHT.Add("334", "");
                rightCodeHT.Add("235", "");

                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient(smtpServer, port);
                NetworkStream ns = client.GetStream();
                if (!IsRight(ns, rightCodeHT)) return false;

                string enter = "\r\n";

                IList<string> sendBuffer = new List<string>();
                sendBuffer.Add("EHLO " + smtpServer + enter);
                sendBuffer.Add("AUTH LOGIN" + enter);
                sendBuffer.Add(Base64Encode(userName) + enter);
                sendBuffer.Add(Base64Encode(password) + enter);
                sendBuffer.Add("QUIT" + enter);

                foreach (var cmd in sendBuffer) {
                    if (!SendCommand(cmd, ns)) return false;
                    if (!IsRight(ns, rightCodeHT)) return false;
                }

                client.Close();
                ns.Close();

                return true;
            } catch (Exception ex) {
                string errorMessage = ex.ToExceptionDetail();
                return false;
            }
        }
        private static string Base64Encode(string str) {
            return Convert.ToBase64String(Encoding.Default.GetBytes(str));
        }
        private static bool SendCommand(string str, NetworkStream ns) {
            byte[] writeBuffer = Encoding.Default.GetBytes(str);
            ns.Write(writeBuffer, 0, writeBuffer.Length);
            return true;
        }
        private static bool IsRight(NetworkStream ns, Hashtable rightCodeHT) {
            byte[] readBuffer = new byte[1024];
            string returnValue = "";
            int streamSize = ns.Read(readBuffer, 0, readBuffer.Length);
            if (streamSize != 0) returnValue = Encoding.Default.GetString(readBuffer, 0, streamSize);
            if (rightCodeHT[returnValue.Substring(0, 3)] == null) return false;
            return true;
        }
    }
}