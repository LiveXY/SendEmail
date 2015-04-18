//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Common;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Text;
#if NET20
using Pub.Class.Linq;
#else
using System.Linq;
#endif
using TH.Mailer.Entity;
using Pub.Class;

namespace TH.Mailer.Helper {
    /// <summary>
    /// 路由操作类
    /// 
    /// 修改纪录
    ///     2013-06-03 版本：1.0 系统自动创建此类
    /// 
    /// </summary>
    public partial class RouteSettingHelper {
        /// <summary>
        /// 路由缓存多少秒 x 5
        /// </summary>
        public static int cacheSeconds = 1440;
        /// <summary>
        /// 路由添加记录
        /// </summary>
        /// <param name="routeSetting">路由实体类</param>
        /// <param name="delCache">添加成功后清理的CACHE key，支持正则</param>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
        /// <returns>添加是否成功</returns>
        public static bool Insert(RouteSetting routeSetting, string dbkey = "", string[] delCache = null) {
            int obj = new SQL().Database(dbkey).Insert(RouteSetting._)
                .ValueP(RouteSetting._RouteID, routeSetting.RouteID)
                .ValueP(RouteSetting._RouteIP, routeSetting.RouteIP)
                .ValueP(RouteSetting._UserName, routeSetting.UserName)
                .ValueP(RouteSetting._RPassword, routeSetting.RPassword)
                .ValueP(RouteSetting._RouteConnect, routeSetting.RouteConnect)
                .ValueP(RouteSetting._RouteDisConnect, routeSetting.RouteDisConnect)
                .ValueP(RouteSetting._RouteMethod, routeSetting.RouteMethod)
                .ToExec();
            if (delCache.IsNull()) return obj == 1;
            Cache2.Remove("TH.Mailer.RouteSettingCache_", delCache);
            return obj == 1;
        }
        /// <summary>
        /// 路由添加记录
        /// </summary>
        /// <param name="routeSetting">路由实体类</param>
        /// <returns>添加是否成功</returns>
        public static bool Insert(RouteSetting routeSetting, string dbkey) {
            return Insert(routeSetting, dbkey, null);
        }
        /// <summary>
        /// 路由修改记录
        /// </summary>
        /// <param name="routeSetting">路由实体类</param>
        /// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
        /// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
        /// <returns>修改是否成功</returns>
        public static bool Update(RouteSetting routeSetting, string dbkey = "", Where where = null, string[] delCache = null) {
            if (routeSetting.RouteID.IsNull()) return false;
            int value = new SQL().Database(dbkey).Update(RouteSetting._)
                .SetP(RouteSetting._RouteIP, routeSetting.RouteIP)
                .SetP(RouteSetting._UserName, routeSetting.UserName)
                .SetP(RouteSetting._RPassword, routeSetting.RPassword)
                .SetP(RouteSetting._RouteConnect, routeSetting.RouteConnect)
                .SetP(RouteSetting._RouteDisConnect, routeSetting.RouteDisConnect)
                .SetP(RouteSetting._RouteMethod, routeSetting.RouteMethod)
                .Where(new Where()
                    .AndP(RouteSetting._RouteID, routeSetting.RouteID, Operator.Equal, true)
                ).Where(where).ToExec();
            if (value <= 0) return false;
            if (delCache.IsNull()) return true;
            Cache2.Remove("TH.Mailer.RouteSettingCache_", delCache);
            return true;
        }
        /// <summary>
        /// 路由修改记录
        /// </summary>
        /// <param name="routeSetting">路由实体类</param>
        /// <returns>修改是否成功</returns>
        public static bool Update(RouteSetting routeSetting, string dbkey) {
            return Update(routeSetting, dbkey, null, null);
        }
        /// <summary>
        /// 路由修改多条记录
        /// </summary>
        /// <param name="routeIDList">路由编号列表，用“,”号分隔</param>
        /// <param name="routeSetting">路由实体类</param>
        /// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
        /// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
        /// <returns>修改是否成功</returns>
        public static bool UpdateByIDList(IEnumerable<int> routeIDList,  RouteSetting routeSetting, string dbkey = "", Where where = null, string[] delCache = null) {
            int value = new SQL().Database(dbkey).Update(RouteSetting._)
                .SetP(RouteSetting._RouteIP, routeSetting.RouteIP)
                .SetP(RouteSetting._UserName, routeSetting.UserName)
                .SetP(RouteSetting._RPassword, routeSetting.RPassword)
                .SetP(RouteSetting._RouteConnect, routeSetting.RouteConnect)
                .SetP(RouteSetting._RouteDisConnect, routeSetting.RouteDisConnect)
                .SetP(RouteSetting._RouteMethod, routeSetting.RouteMethod)
                .Where(new Where()
                    .And(RouteSetting._RouteID, "(" + routeIDList .Join(",") + ")", Operator.In)
                ).Where(where).ToExec();
            if (value <= 0) return false;
            if (delCache.IsNull()) return true;
            Cache2.Remove("TH.Mailer.RouteSettingCache_", delCache);
            return true;
        }
        /// <summary>
        /// 路由修改多条记录
        /// </summary>
        /// <param name="routeIDList">路由编号列表，用“,”号分隔</param>
        /// <param name="routeSetting">路由实体类</param>
        /// <returns>修改是否成功</returns>
        public static bool UpdateByIDList(IEnumerable<int> routeIDList,  RouteSetting routeSetting, string dbkey) {
            return UpdateByIDList(routeIDList,  routeSetting, dbkey, null, null);
        }
        /// <summary>
        /// 路由按主键查询，返回数据的实体类
        /// </summary>
        /// <param name="routeID">路由编号</param>
        /// <param name="where">附加条件，统一的前面要加链接符（and、or等等）</param>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
        /// <returns>返回单条记录的实体类</returns>
        public static RouteSetting SelectByID(int routeID,  string dbkey = "", Where where = null) {
            string cacheNameKey = "TH.Mailer.RouteSettingCache_SelectByID_{0}".FormatWith(routeID + "_" +  "_" + where);
            return Cache2.Get<RouteSetting>(cacheNameKey, cacheSeconds, () => {
                RouteSetting obj = new SQL().Database(dbkey).From(RouteSetting._)
                    .Select(RouteSetting._RouteID)
                    .Select(RouteSetting._RouteIP)
                    .Select(RouteSetting._UserName)
                    .Select(RouteSetting._RPassword)
                    .Select(RouteSetting._RouteConnect)
                    .Select(RouteSetting._RouteDisConnect)
                    .Select(RouteSetting._RouteMethod)
                    .Where(new Where()
                        .AndP(RouteSetting._RouteID, routeID, Operator.Equal)
                    ).Where(where).ToEntity<RouteSetting>();
                return obj;
            });
        }
        /// <summary>
        /// 路由按主键查询，返回数据的实体类
        /// </summary>
        /// <param name="routeID">路由编号</param>
        /// <returns>返回单条记录的实体类</returns>
        public static RouteSetting SelectByID(int routeID, string dbkey) {
            return SelectByID(routeID,  dbkey, null);
        }
        /// <summary>
        /// 清除路由按主键查询的缓存
        /// </summary>
        public static void ClearCacheSelectByID(int routeID,  Where where = null) {
            string cacheName = "TH.Mailer.RouteSettingCache_SelectByID_{0}";
            string cacheNameKey = string.Format(cacheName, routeID + "_" +  "_" + where);
            Cache2.Remove(cacheNameKey);
        }
        /// <summary>
        /// 路由删除所有记录
        /// </summary>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
        /// <returns>返回实体记录集</returns>
        public static bool RemoveAll(string dbkey = "") {
            return (new SQL().Database(dbkey).Delete(RouteSetting._).ToExec()) > 0;
        }
        /// <summary>
        /// 清除路由查询所有记录的缓存
        /// </summary>
        public static void ClearCacheSelectListByAll() {
            //Cache2.Remove("TH.Mailer.RouteSettingCache_SelectListByAll___");
            Cache2.RemoveByPattern("TH.Mailer.RouteSettingCache_SelectListByAll_(.+?)");
        }
        /// <summary>
        /// 清除路由所有缓存
        /// </summary>
        public static void ClearCacheAll() {
            Cache2.RemoveByPattern("TH.Mailer.RouteSettingCache_(.+?)");
        }
    }
}

