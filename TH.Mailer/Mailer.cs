using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml.Serialization;
using System.Xml;
using System.Collections;
using System.Net;
using TH.Mailer.Entity;
using System.Threading;
using TH.Mailer.Helper;
using Pub.Class;
using Pub.Class.Linq;

namespace TH.Mailer {
    public class Mailer {
        private IList<SmtpList> smtpList; //smtp列表
        private IList<EmailList> emailList; //email列表
        private SendSetting sendSetting; //发送设置
        private IList<HtmlTemplate> templateList; //模版列表
        private Action<string> uiMsg; //通知消息
		private Pub.Class.Action uiDone; //完成时执行
        private bool exit = false; //是否停止执行
        private Thread thread; //发送邮件线程

        SmtpList smtpInfo;
        HtmlTemplate template;
        Email email;

        /// <summary>
        /// 开始群发邮件
        /// </summary>
        /// <param name="msg">通知消息</param>
        /// <param name="done">完成执行</param>
		public void Start(Action<string> msg = null, Pub.Class.Action done = null) {
            exit = false;
            uiMsg = msg; uiDone = done;
            thread = new Thread(() => {
                smtpList = SmtpListHelper.SelectListByAll();
                sendSetting = SendSettingHelper.SelectByID(1);
                templateList = HtmlTemplateHelper.SelectListByAll().Where(p => p.Status == 0).ToList();

                sendStart();
            });
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 开始群发邮件
        /// </summary>
        private void sendStart() {
            UpdateSendSettingStatus(1); //开始发送并初始化数据

            smtpList = SmtpListHelper.SelectListByAll().Where(p => p.Status == 0).ToList();
            if (smtpList.Count == 0) { WriteLog("SMTP列表为空！"); if (uiDone != null) uiDone(); return; }
            smtpInfo = smtpList[0]; //默认使用第一个SMTP发送

            template = templateList.Where(t => t.TemplateID == sendSetting.TemplateID).FirstOrDefault();
            if (template.IsNull() || template.TemplateID.IsNull()) { WriteLog("找不到模版ID：" + sendSetting.TemplateID); if (uiDone != null) uiDone(); return; }

            WriteLog("");
            WriteLog(template.Subject + "|" + NetHelper.GetNetName(sendSetting.ConnectType.Value) + "|" + smtpInfo.SmtpServer + "|" + smtpInfo.UserName + " 开始发送！");

            email = new Email(smtpInfo.SmtpServer, smtpInfo.SmtpPort.Value)
                .Ssl(smtpInfo.SSL.Value)
                .Credentials(smtpInfo.UserName, smtpInfo.SPassword)
                .IsBodyHtml(template.IsHTML.Value)
                .Timeout(3000);

            int state = SendEmails();
            if (state == -1) return; //停止发送邮件
            if (state == 0) UpdateSendSettingStatus(2); //正常发送完成时 标记全部发送完成
            WriteLog(template.Subject + (state == 0 ? " 已发送完成！" : " 已停止发送！"));

            //此处可邮件通知

            if (uiDone != null) uiDone();

            clear(); //清理数据
        }

        private int SendEmails(int sends = 0) {
            int sendIndex = 0; //当前发送的邮件索引
            int ips = 0; //记录发送多少邮件后更换IP
            int smtps = 0; int smtps2 = 0; int smtpIndex = 0; //记录发送多少邮件后更换SMTP、smtp发送失败次数、当前使用的smtp索引

            EmailListHelper.ClearCacheAll();
            Where where = new Where().And("LastSendStatus", 0, Operator.Equal);
            emailList = EmailListHelper.SelectListByAll(null, where).Where(e => e.LastSendError.IndexOf("Mailbox not found") == -1).ToList();
            if (emailList.Count == 0) return 0; //0正常发送结束

            //循环发送所有email
            foreach (EmailList e in emailList) {
                sendIndex++;
                if (exit) { clear(); WriteLog("已停止发送邮件！"); thread.Abort(); return -1; } //-1停止发送邮件

                string name = smtpInfo.UserName;
                if (name.IndexOf("@") != -1) name = name.Split('@')[0]; //显示发件人

                int index = smtpInfo.SmtpServer.IndexOf(".");
                string smtpDomail = smtpInfo.SmtpServer.Substring(index + 1);
                string emailAddress = name + "@" + smtpDomail; //显示发件人EMAIL

                if (!template.ShowName.IsNullEmpty()) name = template.ShowName;  //显示模版里设置的发件人

                bool success = false; string msg = string.Empty;
                if (emailAddress.Trim().ToLower() == e.EmailAddress.Trim().ToLower()) success = true; //不允许自己发给自己

                if (!success) {
                    success = email.ClearTo()
                        .From(name, emailAddress)
                        .Subject(processText(template.Subject, e))
                        .Body(processText(template.Body, e))
                        .To(t => t.Add(e.NickName.IfNullOrEmpty(e.EmailAddress.Split('@')[0]), e.EmailAddress))
                        .Send();
                    msg = processError(email.ErrorMessage);
                    if (sendSetting.SendInterval > 0) Thread.Sleep(sendSetting.SendInterval.Value); //暂停时间
                }

                WriteLog("<" + e.NickName + ">" + e.EmailAddress + (success ? " 发送成功！" : " 发送出错：" + msg));

                //最后一次发送情况
                EmailList emailInfo = new EmailList();
                emailInfo.EmailAddress = e.EmailAddress;
                emailInfo.LastSendStatus = success ? 1 : (sendSetting.SendRetryCount == e.SendCount + 1 ? 2 : 0);
                emailInfo.LastSendTime = DateTime.Now;
                emailInfo.LastSendSmtp = smtpInfo.SmtpServer + "|" + smtpInfo.UserName;
                emailInfo.LastSendError = msg;
                emailInfo.SendCount = e.SendCount + 1;
                EmailListHelper.Update(emailInfo);

                ips++;
                if (sendSetting.IPInterval > 0 && ips >= sendSetting.IPInterval) { //换IP
                    ips = 0;
                    WriteLog("正在更换IP.....");
                    string ip = NetHelper.ChangeIP(sendSetting.ConnectType.Value, uiMsg, uiDone);
                    if (ip.IsNullEmpty()) { WriteLog(sendSetting.MaxRetryCount + "次更换IP失败！"); return 1; } //1更换IP失败结束
                    WriteLog("更换IP：" + ip);
                }

                smtps++;
                if (!success) smtps2++;
                if (sendSetting.SmtpInterval > 0 && smtps >= sendSetting.SmtpInterval && smtpList.Count > 1) { //换SMTP
                    UpdateSmtpListSendCount(smtpIndex, sendSetting.SmtpInterval.Value, smtps2); //更新smtp发送次数

                    smtps = 0; smtps2 = 0;
                    smtpIndex++;
                    if (smtpIndex + 1 > smtpList.Count) smtpIndex = 0; //如果所有smtp发送完，将重新循环更换
                    smtpInfo = smtpList[smtpIndex]; //更换下一个smtp
                    WriteLog("更换SMTP：" + smtpInfo.SmtpServer + "|" + smtpInfo.UserName);
                    email.Host(smtpInfo.SmtpServer)
                        .Ssl(smtpInfo.SSL.Value)
                        .Port(smtpInfo.SmtpPort.Value)
                        .Credentials(smtpInfo.UserName, smtpInfo.SPassword);
                }
            };

            if (smtps > 0) UpdateSmtpListSendCount(smtpIndex, smtps, smtps2); //更新smtp发送次数
            WriteLog("第" + (sends + 1) + "轮发送完成！");
            return SendEmails(sends + 1);
        }

        //输出消息
        private void WriteLog(string msg) {
            if (uiMsg != null) uiMsg(msg);
        }

        private void UpdateSendSettingStatus(int status) {
            SendSetting setting = new SendSetting();
            setting.SettingID = sendSetting.SettingID;
            setting.Status = status;
            SendSettingHelper.Update(setting);
        }

        private void UpdateSmtpListSendCount(int smtpIndex, int smtps, int smtps2) {
            smtpList[smtpIndex].Sends += smtps;
            smtpList[smtpIndex].SendFails += smtps2;
            smtpInfo.Sends = smtpList[smtpIndex].Sends;
            smtpInfo.SendFails = smtpList[smtpIndex].SendFails;
            smtpInfo.CreateTime = null;
            SmtpListHelper.Update(smtpInfo);
        }

        /// <summary>
        /// 处理邮件标题和内容
        /// </summary>
        /// <param name="text"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private string processText(string text, EmailList e) {
            return Jammer(text.Replace("{EmailAddress}", e.EmailAddress).Replace("{Email}", e.EmailAddress).Replace("{email}", e.EmailAddress)
                .Replace("{NickName}", e.NickName).Replace("{Name}", e.NickName).Replace("{name}", e.NickName)
                .Replace("{ex0}", e.ex0).Replace("{ex1}", e.ex1).Replace("{ex2}", e.ex2).Replace("{ex3}", e.ex3).Replace("{ex4}", e.ex4)
                .Replace("{ex5}", e.ex5).Replace("{ex6}", e.ex6).Replace("{ex7}", e.ex7).Replace("{ex8}", e.ex8));
        }
        public class JammerData {
            public int Index { get; set; }
            public string RandText { get; set; }
        }
        public static string Jammer(string emailHTML, int count = 1) {
            string emailText = emailHTML.RemoveAllHTML();
            if (emailText.Length < 20) return emailHTML;

            IList<JammerData> list = new List<JammerData>();
            for (int i = 0; i < count; i++) {
                int index = 0;
                while (true) {
                    index = Rand.RndInt(0, emailHTML.Length);
                    string leftHTML = emailHTML.Substring(0, index);
                    int left = leftHTML.LastIndexOf("<");
                    int right = leftHTML.LastIndexOf(">");
                    if (left != -1 && right != -1) {
                        if (right > left) break;
                    } else if (left == -1 && right != -1) break;
                    else if (left == -1 && right == -1) break;
                }
                int randLen = Rand.RndInt(5, emailText.Length - 10);
                list.Add(new JammerData() {
                    RandText = "<b style='display:none'>" + emailText.Substring(Rand.RndInt(0, emailText.Length - randLen), randLen).ReplaceRN() + "</b>",
                    Index = index
                });
            }
            int len = 0;
            foreach (JammerData d in list) {
                emailHTML = emailHTML.Insert(d.Index + len, d.RandText);
                len += d.RandText.Length;
            }
            return emailHTML;
        }

        /// <summary>
        /// 处理错误消息
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        private string processError(string error) {
            string e = string.Empty;
            return error.GetMatchingValue("Message:(.+?)" + Environment.NewLine, 8, 0).Trim();
        }

        /// <summary>
        /// 停止发送邮件
        /// </summary>
        public void Stop() {
            exit = true;
        }

        public void Abort() {
            if (!thread.IsNull()) thread.Abort();
        }

        /// <summary>
        /// 清理缓存
        /// </summary>
        private void clear() {
            SmtpListHelper.ClearCacheAll(); smtpList = null;
            EmailListHelper.ClearCacheAll(); emailList = null;
            SendSettingHelper.ClearCacheAll(); sendSetting = null;
            HtmlTemplateHelper.ClearCacheAll(); templateList = null;
            IpHistoryHelper.ClearCacheAll();
        }
    }

}