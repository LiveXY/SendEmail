//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
    /// <summary>
    /// 拨号连接实体类
    /// 
    /// 修改纪录
    ///     2013-06-03 版本：1.0 系统自动创建此类
    /// 
    /// </summary>
    [Serializable]
    [EntityInfo("拨号连接")]
    public partial class ModelSetting {
        /// <summary>
        /// 拨号连接
        /// </summary>
        public static readonly string _ = "ModelSetting";

        /// <summary>
        /// 拨号连接编号
        /// </summary>
        public static readonly string _ModelID = "ModelID";
        private int? modelID = null;
        /// <summary>
        /// 拨号连接编号
        /// </summary>
        [EntityInfo("拨号连接编号")]
        public new int? ModelID { get { return modelID; } set { modelID = value; } }

        /// <summary>
        /// 拨号连接名称
        /// </summary>
        public static readonly string _ModelName = "ModelName";
        private string modelName = null;
        /// <summary>
        /// 拨号连接名称
        /// </summary>
        [EntityInfo("拨号连接名称")]
        public new string ModelName { get { return modelName; } set { modelName = value; } }

        /// <summary>
        /// 登录账号
        /// </summary>
        public static readonly string _UserName = "UserName";
        private string userName = null;
        /// <summary>
        /// 登录账号
        /// </summary>
        [EntityInfo("登录账号")]
        public new string UserName { get { return userName; } set { userName = value; } }

        /// <summary>
        /// 登录密码
        /// </summary>
        public static readonly string _MPassword = "MPassword";
        private string mPassword = null;
        /// <summary>
        /// 登录密码
        /// </summary>
        [EntityInfo("登录密码")]
        public new string MPassword { get { return mPassword; } set { mPassword = value; } }
    }
}



