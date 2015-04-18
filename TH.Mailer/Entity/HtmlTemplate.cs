//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
    /// <summary>
    /// 邮件模版实体类
    /// 
    /// 修改纪录
    ///     2013-06-03 版本：1.0 系统自动创建此类
    /// 
    /// </summary>
    [Serializable]
    [EntityInfo("邮件模版")]
    public partial class HtmlTemplate {
        /// <summary>
        /// 邮件模版
        /// </summary>
        public static readonly string _ = "HtmlTemplate";

        /// <summary>
        /// 邮件模版编号
        /// </summary>
        public static readonly string _TemplateID = "TemplateID";
        private Int64? templateID = null;
        /// <summary>
        /// 邮件模版编号
        /// </summary>
        [EntityInfo("邮件模版编号")]
        public new Int64? TemplateID { get { return templateID; } set { templateID = value; } }

        /// <summary>
        /// 主题
        /// </summary>
        public static readonly string _Subject = "Subject";
        private string subject = null;
        /// <summary>
        /// 主题
        /// </summary>
        [EntityInfo("主题")]
        public new string Subject { get { return subject; } set { subject = value; } }

        /// <summary>
        /// 内容
        /// </summary>
        public static readonly string _Body = "Body";
        private string body = null;
        /// <summary>
        /// 内容
        /// </summary>
        [EntityInfo("内容")]
        public new string Body { get { return body; } set { body = value; } }

        /// <summary>
        /// 显示发件人名称
        /// </summary>
        public static readonly string _ShowName = "ShowName";
        private string showName = null;
        /// <summary>
        /// 显示发件人名称
        /// </summary>
        [EntityInfo("显示发件人名称")]
        public new string ShowName { get { return showName; } set { showName = value; } }

        /// <summary>
        /// 是否使用HTML发送
        /// </summary>
        public static readonly string _IsHTML = "IsHTML";
        private bool? isHTML = null;
        /// <summary>
        /// 是否使用HTML发送
        /// </summary>
        [EntityInfo("是否使用HTML发送")]
        public new bool? IsHTML { get { return isHTML; } set { isHTML = value; } }

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



