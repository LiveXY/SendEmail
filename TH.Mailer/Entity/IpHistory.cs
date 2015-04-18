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
    public partial class IpHistory {
        /// <summary>
        /// 
        /// </summary>
        public static readonly string _ = "IpHistory";

        /// <summary>
        /// IP地址
        /// </summary>
        public static readonly string _IP = "IP";
        private string iP = null;
        /// <summary>
        /// IP地址
        /// </summary>
        [EntityInfo("IP地址")]
        public new string IP { get { return iP; } set { iP = value; } }

        /// <summary>
        /// 使用时间
        /// </summary>
        public static readonly string _CreateTime = "CreateTime";
        private DateTime? createTime = null;
        /// <summary>
        /// 使用时间
        /// </summary>
        [EntityInfo("使用时间")]
        public new DateTime? CreateTime { get { return createTime; } set { createTime = value; } }
    }
}



