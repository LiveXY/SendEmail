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
using Pub.Class;
using Pub.Class.Linq;
using System.Threading;

namespace TH.Mailer {
    public class IPHelper {
        private static IList<IpHistory> ipHistory = IpHistoryHelper.SelectListByAll();
        private static ThreadEx ex;

        /// <summary>
        /// 获取外网IP地址 多线程 有一个线程取到数据后其它线程都停止
        /// </summary>
        /// <returns></returns>
        public static string GetIpFast() {
            string ip = string.Empty;
            ThreadEx ex = new ThreadEx();
            IList<IpSetting> list = IpSettingHelper.SelectListByAll();
            list.Do((p, i) => {
                ex.QueueWorkItem(new System.Threading.WaitCallback(o => {
                    IpSetting setting = (IpSetting)o;
                    try {
                        string data = string.Empty;
                        string name = setting.DataEncode.IfNullOrEmpty("utf-8");
                        Encoding coding = Encoding.GetEncoding(name);
                        data = GetRemoteHtmlCode(setting.IPUrl, coding);
                        if (!data.Trim().IsNullEmpty()) {
                            if (setting.IPRegex.IsNullEmpty()) { //允许正则为空
                                if (!data.IsNullEmpty()) {
                                    ip = data;
                                    ex.SetAll();
                                }
                            } else {
                                string begin = setting.IPRegex.Substring(0, setting.IPRegex.IndexOf("(")).Replace("\\", "");
                                string end = setting.IPRegex.Substring(setting.IPRegex.IndexOf(")") + 1).Replace("\\", "");

                                if (!begin.IsNullEmpty() && !end.IsNullEmpty()) {
                                    string _ip = data.GetMatchingValues(setting.IPRegex, begin, end).Join(",");
                                    if (!_ip.IsNullEmpty()) {
                                        ip = _ip;
                                        ex.SetAll();
                                    }
                                }
                            }
                        }
                    } catch { }
                }), p);
            });
            ex.WaitAllComplete();
            return ip;
        }

        private static string GetRemoteHtmlCode(string url, System.Text.Encoding encoding, int timeout = 3000) {
            string content = string.Empty;
            HttpWebResponse response = null; StreamReader stream = null;
            try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = timeout;
                response = (HttpWebResponse)request.GetResponse();
                stream = new StreamReader(response.GetResponseStream(), encoding);
                content = stream.ReadToEnd();
            } catch { } finally {
                if (stream.IsNotNull()) stream.Close();
                if (response.IsNotNull()) response.Close();
            }
            return content;
        }

        public static void TestIPStart(Action<string> msg, Pub.Class.Action done) {
            IList<IpSetting> list = IpSettingHelper.SelectListByAll();
            if (list.Count == 0) { msg("请设置需要获取IP的网址！"); return; }
            msg("共有{0}个获取IP的网址！".FormatWith(list.Count));
            if (!ex.IsNull()) ex.SetAll();

            ex = new ThreadEx();
            list.Do((p, i) => {
                ex.QueueWorkItem(new System.Threading.WaitCallback(o => {
                    IpSetting setting = (IpSetting)o;
                    string ip = string.Empty;
                    try {
                        string data = string.Empty;
                        string name = setting.DataEncode.IfNullOrEmpty("utf-8");
                        Encoding coding = Encoding.GetEncoding(name);
                        data = GetRemoteHtmlCode(setting.IPUrl, coding);
                        if (data.Trim().IsNullEmpty()) {
                            msg("{0}，error - 请检查网址{1}是否正确！".FormatWith(i + 1, setting.IPUrl));
                        } else {
                            if (setting.IPRegex.IsNullEmpty()) { //允许正则为空
                                if (data.IsNullEmpty()) {
                                    msg("{0}，error - 网址{1}无法匹配IP：{2}".FormatWith(i + 1, setting.IPUrl, data));
                                } else {
                                    msg("{0}，ok - 网址{1}获取的IP是：{2}".FormatWith(i + 1, setting.IPUrl, data));
                                }
                            } else {
                                string begin = setting.IPRegex.Substring(0, setting.IPRegex.IndexOf("(")).Replace("\\", "");
                                string end = setting.IPRegex.Substring(setting.IPRegex.IndexOf(")") + 1).Replace("\\", "");

                                if (begin.IsNullEmpty() || end.IsNullEmpty()) {
                                    msg("{0}，error - 请检查网址{1}的正则是否正确：{2}".FormatWith(i + 1, setting.IPUrl, setting.IPRegex));
                                } else {
                                    ip = data.GetMatchingValues(setting.IPRegex, begin, end).Join(",");
                                    if (ip.IsNullEmpty()) {
                                        msg("{0}，error - 网址{1}无法匹配IP：{2}".FormatWith(i + 1, setting.IPUrl, data));
                                    } else {
                                        msg("{0}，ok - 网址{1}获取的IP是：{2}".FormatWith(i + 1, setting.IPUrl, ip));
                                    }
                                }
                            }
                        }
                    } catch (Exception e) {
                        msg("{0}，error - 获取网址{1}数据出错：{2}".FormatWith(i + 1, setting.IPUrl, e.Message));
                        return;
                    }
                }), p);
            });
            ex.WaitAllComplete();
            done();
        }

        public static void TestIPStop() {
            if (ex.IsNotNull()) {
                ex.SetAll();
                ex = null;
            }
        }
    }
}