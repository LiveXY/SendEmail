//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
    /// <summary>
    /// 路由实体类
    /// 
    /// 修改纪录
    ///     2013-06-03 版本：1.0 系统自动创建此类
    /// 
    /// </summary>
    [Serializable]
    [EntityInfo("路由")]
    public partial class RouteSetting {
        /// <summary>
        /// 路由
        /// </summary>
        public static readonly string _ = "RouteSetting";

        /// <summary>
        /// 路由编号
        /// </summary>
        public static readonly string _RouteID = "RouteID";
        private int? routeID = null;
        /// <summary>
        /// 路由编号
        /// </summary>
        [EntityInfo("路由编号")]
        public new int? RouteID { get { return routeID; } set { routeID = value; } }

        /// <summary>
        /// 路由地址
        /// </summary>
        public static readonly string _RouteIP = "RouteIP";
        private string routeIP = null;
        /// <summary>
        /// 路由地址
        /// </summary>
        [EntityInfo("路由地址")]
        public new string RouteIP { get { return routeIP; } set { routeIP = value; } }

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
        public static readonly string _RPassword = "RPassword";
        private string rPassword = null;
        /// <summary>
        /// 登录密码
        /// </summary>
        [EntityInfo("登录密码")]
        public new string RPassword { get { return rPassword; } set { rPassword = value; } }

        /// <summary>
        /// 连接参数
        /// </summary>
        public static readonly string _RouteConnect = "RouteConnect";
        private string routeConnect = null;
        /// <summary>
        /// 连接参数
        /// </summary>
        [EntityInfo("连接参数")]
        public new string RouteConnect { get { return routeConnect; } set { routeConnect = value; } }

        /// <summary>
        /// 断开连接参数
        /// </summary>
        public static readonly string _RouteDisConnect = "RouteDisConnect";
        private string routeDisConnect = null;
        /// <summary>
        /// 断开连接参数
        /// </summary>
        [EntityInfo("断开连接参数")]
        public new string RouteDisConnect { get { return routeDisConnect; } set { routeDisConnect = value; } }

        /// <summary>
        /// 请求方式 POST GET
        /// </summary>
        public static readonly string _RouteMethod = "RouteMethod";
        private string routeMethod = null;
        /// <summary>
        /// 请求方式 POST GET
        /// </summary>
        [EntityInfo("请求方式 POST GET")]
        public new string RouteMethod { get { return routeMethod; } set { routeMethod = value; } }
    }
}



