//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
    /// <summary>
    /// 实体类
    /// 
    /// 修改纪录
    ///     2013-06-03 版本：1.0 系统自动创建此类
    /// 
    /// </summary>
    [Serializable]
    [EntityInfo("")]
    public partial class SmtpList {
        /// <summary>
        /// 
        /// </summary>
        public static readonly string _ = "SmtpList";

        /// <summary>
        /// SMTP服务器
        /// </summary>
        public static readonly string _SmtpServer = "SmtpServer";
        private string smtpServer = null;
        /// <summary>
        /// SMTP服务器
        /// </summary>
        [EntityInfo("SMTP服务器")]
        public new string SmtpServer { get { return smtpServer; } set { smtpServer = value; } }

        /// <summary>
        /// SMTP端口
        /// </summary>
        public static readonly string _SmtpPort = "SmtpPort";
        private int? smtpPort = null;
        /// <summary>
        /// SMTP端口
        /// </summary>
        [EntityInfo("SMTP端口")]
        public new int? SmtpPort { get { return smtpPort; } set { smtpPort = value; } }

        /// <summary>
        /// 登录用户名
        /// </summary>
        public static readonly string _UserName = "UserName";
        private string userName = null;
        /// <summary>
        /// 登录用户名
        /// </summary>
        [EntityInfo("登录用户名")]
        public new string UserName { get { return userName; } set { userName = value; } }

        /// <summary>
        /// 登录密码
        /// </summary>
        public static readonly string _SPassword = "SPassword";
        private string sPassword = null;
        /// <summary>
        /// 登录密码
        /// </summary>
        [EntityInfo("登录密码")]
        public new string SPassword { get { return sPassword; } set { sPassword = value; } }

        /// <summary>
        /// 是否支持SSL
        /// </summary>
        public static readonly string _SSL = "SSL";
        private bool? sSL = null;
        /// <summary>
        /// 是否支持SSL
        /// </summary>
        [EntityInfo("是否支持SSL")]
        public new bool? SSL { get { return sSL; } set { sSL = value; } }

        /// <summary>
        /// 状态 0可用 1不可用
        /// </summary>
        public static readonly string _Status = "Status";
        private int? status = null;
        /// <summary>
        /// 状态 0可用 1不可用
        /// </summary>
        [EntityInfo("状态 0可用 1不可用")]
        public new int? Status { get { return status; } set { status = value; } }

        /// <summary>
        /// 发送次数
        /// </summary>
        public static readonly string _Sends = "Sends";
        private int? sends = null;
        /// <summary>
        /// 发送次数
        /// </summary>
        [EntityInfo("发送次数")]
        public new int? Sends { get { return sends; } set { sends = value; } }

        /// <summary>
        /// 发送失败次数
        /// </summary>
        public static readonly string _SendFails = "SendFails";
        private int? sendFails = null;
        /// <summary>
        /// 发送失败次数
        /// </summary>
        [EntityInfo("发送失败次数")]
        public new int? SendFails { get { return sendFails; } set { sendFails = value; } }

        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly string _CreateTime = "CreateTime";
        private DateTime? createTime = null;
        /// <summary>
        /// 创建时间
        /// </summary>
        [EntityInfo("创建时间")]
        public new DateTime? CreateTime { get { return createTime; } set { createTime = value; } }
    }
}



