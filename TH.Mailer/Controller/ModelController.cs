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
using System.Diagnostics;
using TH.Mailer.Helper;
using System.Threading;
using Pub.Class;

namespace TH.Mailer {
    public class ModelController : IController {
        private ModelSetting setting;

        public ModelController() { setting = ModelSettingHelper.SelectByID(1); }
        
        /// <summary>
        /// 连接
        /// </summary>
        /// <returns></returns>
        public bool Connect() {
            Safe.RunWait("cmd.exe", new string[] { "rasdial.exe " + setting.ModelName + " " + setting.UserName + " " + setting.MPassword, "exit" }, null);
            return true;
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <returns></returns>
        public bool Disconnect() {
            Safe.RunWait("cmd.exe", new string[] { "rundll32.exe iedkcs32.dll CloseRASConnections", "exit" }, null);
            return true;
        }

        /// <summary>
        /// 重新连接
        /// </summary>
        /// <returns></returns>
        public string Reset() {
            this.Disconnect();
            Thread.Sleep(2000);
            this.Connect();
            Thread.Sleep(2000);
            return string.Empty;
        }
    }
}