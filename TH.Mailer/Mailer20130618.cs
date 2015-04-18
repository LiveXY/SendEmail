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
        private Action uiDone; //完成时执行
        private bool exit = false; //是否停止执行
        private Thread thread; //发送邮件线程

        /// <summary>
        /// 开始群发邮件
        /// </summary>
        /// <param name="msg">通知消息</param>
        /// <param name="done">完成执行</param>
        public void Start(Action<string> msg = null, Action done = null) {
            exit = false;
            uiMsg = msg; uiDone = done;
            thread = new Thread(() => {
                smtpList = SmtpListHelper.SelectListByAll();
                emailList = EmailListHelper.SelectListByAll();
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
            //开始发送
            SendSetting setting = new SendSetting();
            setting.SettingID = sendSetting.SettingID;
            setting.Status = 1;
            SendSettingHelper.Update(setting);

            new SQL()
                .Update(SmtpList._)
                .Set("Sends", 0)
                .Set("SendFails", 0)
                .ToExec();

            int ips = 0;
            int smtps = 0; int smtps2 = 0; int smtpIndex = 0;
            smtpList = SmtpListHelper.SelectListByAll().Where(p => p.Status == 0).OrderBy(p => p.Sends).ToList();
            if (smtpList.Count == 0) { WriteLog("SMTP列表为空！"); if (uiDone != null) uiDone(); return; }

            SmtpList smtpInfo = smtpList[smtpIndex];

            HtmlTemplate template = templateList.Where(t => t.TemplateID == sendSetting.TemplateID).FirstOrDefault();
            if (template.IsNull() || template.TemplateID.IsNull()) { WriteLog("找不到模版ID：" + sendSetting.TemplateID); if (uiDone != null) uiDone(); return; }

            WriteLog("");
            WriteLog(template.Subject + "|" + (sendSetting.ConnectType == 0 ? "路由连接" : "拨号连接") + "|" + smtpInfo.SmtpServer + "|" + smtpInfo.UserName + " 开始发送！");

            Email email = new Email(smtpInfo.SmtpServer, smtpInfo.SmtpPort.Value)
                .Ssl(smtpInfo.SSL.Value)
                .Credentials(smtpInfo.UserName, smtpInfo.SPassword)
                .IsBodyHtml(template.IsHTML.Value);

            int state = 0; //0正常结束 1更换IP失败结束
            int sendIndex = 0;
            IList<EmailList> emailList = EmailListHelper.SelectListByAll().Where(e => e.LastSendStatus == 0).ToList();
            //循环发送所有email
            foreach (EmailList e in emailList) {
                sendIndex++;
                if (exit) { clear(); WriteLog("已停止发送邮件！"); thread.Abort(); return; }

                string name = smtpInfo.UserName;
                if (name.IndexOf("@") != -1) name = name.Split('@')[0];

                int index = smtpInfo.SmtpServer.IndexOf(".");
                string smtpDomail = smtpInfo.SmtpServer.Substring(index + 1);
                string emailAddress = name + "@" + smtpDomail;

                if (!template.ShowName.IsNullEmpty()) name = template.ShowName;

                bool success = false; string msg = string.Empty;
                email = email.ClearTo()
                    .From(name, emailAddress)
                    .Subject(processText(template.Subject, e))
                    .Body(processText(template.Body, e))
                    .To(t => t.Add(e.NickName.IfNullOrEmpty(e.EmailAddress.Split('@')[0]), e.EmailAddress));

                for (int i = 0; i < sendSetting.SendRetryCount; i++) {
                    success = email.Send();
                    msg = processError(email.ErrorMessage);
                    if (sendSetting.SendInterval > 0) Thread.Sleep(sendSetting.SendInterval.Value); //暂停时间
                    if (success || msg.IndexOf("Mailbox not found") != -1) break;
                }

                WriteLog("<" + e.NickName + ">" + e.EmailAddress + (success ? " 发送成功！" : " 发送出错：" + msg));

                //更新email发送次数
                EmailList emailInfo = new EmailList();
                emailInfo.EmailAddress = e.EmailAddress;
                emailInfo.LastSendStatus = success ? 1 : 2;
                emailInfo.LastSendTime = DateTime.Now;
                emailInfo.LastSendSmtp = smtpInfo.SmtpServer + "|" + smtpInfo.UserName;
                emailInfo.LastSendError = msg;
                EmailListHelper.Update(emailInfo);

                ips++;
                if (sendSetting.IPInterval > 0 && ips >= sendSetting.IPInterval && sendIndex != emailList.Count) {
                    ips = 0;
                    //换IP
                    WriteLog("正在更换IP.....");
                    string ip = NetHelper.ChangeIP(sendSetting.ConnectType.Value, uiMsg, uiDone);
                    if (ip.IsNullEmpty()) { state = 1; WriteLog(sendSetting.MaxRetryCount + "次更换IP失败！"); break; }
                    WriteLog("更换IP：" + ip);
                }

                smtps++;
                if (!success) smtps2++;
                if (sendSetting.SmtpInterval > 0 && smtps >= sendSetting.SmtpInterval && sendIndex != emailList.Count) {
                    //更新smtp发送次数
                    smtpList[smtpIndex].Sends += sendSetting.SmtpInterval;
                    smtpList[smtpIndex].SendFails += smtps2;
                    smtpInfo.Sends = smtpList[smtpIndex].Sends;
                    smtpInfo.SendFails = smtpList[smtpIndex].SendFails;
                    smtpInfo.CreateTime = null;
                    SmtpListHelper.Update(smtpInfo);

                    smtps = 0;
                    smtps2 = 0;
                    smtpIndex++;
                    if (smtpIndex + 1 > smtpList.Count) smtpIndex = 0; //如果所有smtp发送完，将重新循环
                    smtpInfo = smtpList[smtpIndex]; //更换下一个smtp
                    WriteLog("更换SMTP：" + smtpInfo.SmtpServer + "|" + smtpInfo.UserName);
                    email.Host(smtpInfo.SmtpServer)
                        .Ssl(smtpInfo.SSL.Value)
                        .Port(smtpInfo.SmtpPort.Value)
                        .Credentials(smtpInfo.UserName, smtpInfo.SPassword);
                }
            };

            if (smtps > 0) {
                //更新smtp发送次数
                smtpList[smtpIndex].Sends += smtps;
                smtpList[smtpIndex].SendFails += smtps2;
                smtpInfo.Sends = smtpList[smtpIndex].Sends;
                smtpInfo.SendFails = smtpList[smtpIndex].SendFails;
                smtpInfo.CreateTime = null;
                SmtpListHelper.Update(smtpInfo);
            }

            if (state == 0) { //正常发送完成
                //所有email地址全部发送完成
                setting.SettingID = sendSetting.SettingID;
                setting.Status = 2;
                SendSettingHelper.Update(setting);
            }

            EmailListHelper.ClearCacheAll();
            SmtpListHelper.ClearCacheAll();

            if (state == 0)
                WriteLog(template.Subject + " 已发送完成！");
            else
                WriteLog(template.Subject + " 已停止发送！");

            //此处可邮件通知
            if (uiDone != null) uiDone();
            clear();
        }

        //输出消息
        private void WriteLog(string msg) {
            if (uiMsg != null) uiMsg(msg);
        }

        /// <summary>
        /// 处理邮件标题和内容
        /// </summary>
        /// <param name="text"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private string processText(string text, EmailList e) {
            return text.Replace("{EmailAddress}", e.EmailAddress).Replace("{Email}", e.EmailAddress).Replace("{email}", e.EmailAddress)
                .Replace("{NickName}", e.NickName).Replace("{Name}", e.NickName).Replace("{name}", e.NickName)
                .Replace("{ex0}", e.ex0).Replace("{ex1}", e.ex1).Replace("{ex2}", e.ex2).Replace("{ex3}", e.ex3).Replace("{ex4}", e.ex4)
                .Replace("{ex5}", e.ex5).Replace("{ex6}", e.ex6).Replace("{ex7}", e.ex7).Replace("{ex8}", e.ex8);
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

        /// <summary>
        /// 清理缓存
        /// </summary>
        private void clear() {
            SmtpListHelper.ClearCacheAll(); smtpList = null;
            EmailListHelper.ClearCacheAll(); emailList = null;
            SendSettingHelper.ClearCacheAll(); sendSetting = null;
            HtmlTemplateHelper.ClearCacheAll(); templateList = null;
        }
    }

}