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
    /// 邮件模版操作类
    /// 
    /// 修改纪录
    ///     2013-06-03 版本：1.0 系统自动创建此类
    /// 
    /// </summary>
    public partial class HtmlTemplateHelper {
        /// <summary>
        /// 邮件模版缓存多少秒 x 5
        /// </summary>
        public static int cacheSeconds = 1440;
        /// <summary>
        /// 邮件模版添加记录
        /// </summary>
        /// <param name="htmlTemplate">邮件模版实体类</param>
        /// <param name="delCache">添加成功后清理的CACHE key，支持正则</param>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
        /// <returns>返回添加成功后的ID</returns>
        public static Int64 Insert(HtmlTemplate htmlTemplate, string dbkey = "", string[] delCache = null) {
            object obj = new SQL().Database(dbkey).Insert(HtmlTemplate._)
                .ValueP(HtmlTemplate._TemplateID, htmlTemplate.TemplateID)
                .ValueP(HtmlTemplate._Subject, htmlTemplate.Subject)
                .ValueP(HtmlTemplate._Body, htmlTemplate.Body)
                .ValueP(HtmlTemplate._ShowName, htmlTemplate.ShowName)
                .ValueP(HtmlTemplate._IsHTML, htmlTemplate.IsHTML)
                .ValueP(HtmlTemplate._Status, htmlTemplate.Status)
                .ValueP(HtmlTemplate._CreateTime, htmlTemplate.CreateTime)
                .ToExec();
            if (obj.ToInt() != 1) return 0;
            obj = new SQL().Database(dbkey).From(HtmlTemplate._).Max("TemplateID").ToScalar();
            if (obj.IsAllNull()) return 0;
            Int64 value = obj.ToString().ToBigInt();
            if (delCache.IsNull()) return value;
            Cache2.Remove("TH.Mailer.HtmlTemplateCache_", delCache);
            return value;
        }
        /// <summary>
        /// 邮件模版添加记录
        /// </summary>
        /// <param name="htmlTemplate">邮件模版实体类</param>
        /// <returns>返回添加成功后的ID</returns>
        public static Int64 Insert(HtmlTemplate htmlTemplate, string dbkey) {
            return Insert(htmlTemplate, dbkey, null);
        }
        /// <summary>
        /// 邮件模版修改记录
        /// </summary>
        /// <param name="htmlTemplate">邮件模版实体类</param>
        /// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
        /// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
        /// <returns>修改是否成功</returns>
        public static bool Update(HtmlTemplate htmlTemplate, string dbkey = "", Where where = null, string[] delCache = null) {
            if (htmlTemplate.TemplateID.IsNull()) return false;
            int value = new SQL().Database(dbkey).Update(HtmlTemplate._)
                .SetP(HtmlTemplate._Subject, htmlTemplate.Subject)
                .SetP(HtmlTemplate._Body, htmlTemplate.Body)
                .SetP(HtmlTemplate._ShowName, htmlTemplate.ShowName)
                .SetP(HtmlTemplate._IsHTML, htmlTemplate.IsHTML)
                .SetP(HtmlTemplate._Status, htmlTemplate.Status)
                .SetP(HtmlTemplate._CreateTime, htmlTemplate.CreateTime)
                .Where(new Where()
                    .AndP(HtmlTemplate._TemplateID, htmlTemplate.TemplateID, Operator.Equal, true)
                ).Where(where).ToExec();
            if (value <= 0) return false;
            if (delCache.IsNull()) return true;
            Cache2.Remove("TH.Mailer.HtmlTemplateCache_", delCache);
            return true;
        }
        /// <summary>
        /// 邮件模版修改记录
        /// </summary>
        /// <param name="htmlTemplate">邮件模版实体类</param>
        /// <returns>修改是否成功</returns>
        public static bool Update(HtmlTemplate htmlTemplate, string dbkey) {
            return Update(htmlTemplate, dbkey, null, null);
        }
        /// <summary>
        /// 邮件模版修改多条记录
        /// </summary>
        /// <param name="templateIDList">邮件模版编号列表，用“,”号分隔</param>
        /// <param name="htmlTemplate">邮件模版实体类</param>
        /// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
        /// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
        /// <returns>修改是否成功</returns>
        public static bool UpdateByIDList(IEnumerable<Int64> templateIDList,  HtmlTemplate htmlTemplate, string dbkey = "", Where where = null, string[] delCache = null) {
            int value = new SQL().Database(dbkey).Update(HtmlTemplate._)
                .SetP(HtmlTemplate._Subject, htmlTemplate.Subject)
                .SetP(HtmlTemplate._Body, htmlTemplate.Body)
                .SetP(HtmlTemplate._ShowName, htmlTemplate.ShowName)
                .SetP(HtmlTemplate._IsHTML, htmlTemplate.IsHTML)
                .SetP(HtmlTemplate._Status, htmlTemplate.Status)
                .SetP(HtmlTemplate._CreateTime, htmlTemplate.CreateTime)
                .Where(new Where()
                    .And(HtmlTemplate._TemplateID, "(" + templateIDList .Join(",") + ")", Operator.In)
                ).Where(where).ToExec();
            if (value <= 0) return false;
            if (delCache.IsNull()) return true;
            Cache2.Remove("TH.Mailer.HtmlTemplateCache_", delCache);
            return true;
        }
        /// <summary>
        /// 邮件模版修改多条记录
        /// </summary>
        /// <param name="templateIDList">邮件模版编号列表，用“,”号分隔</param>
        /// <param name="htmlTemplate">邮件模版实体类</param>
        /// <returns>修改是否成功</returns>
        public static bool UpdateByIDList(IEnumerable<Int64> templateIDList,  HtmlTemplate htmlTemplate, string dbkey) {
            return UpdateByIDList(templateIDList,  htmlTemplate, dbkey, null, null);
        }
         /// <summary>
        /// 邮件模版删除记录
        /// </summary>
        /// <param name="templateID">邮件模版编号</param>
        /// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
        /// <param name="delCache">删除成功后清理的CACHE key，支持正则</param>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
        /// <returns>删除是否成功</returns>
        public static bool DeleteByID(Int64? templateID,  string dbkey = "", Where where = null, string[] delCache = null) {
            if (templateID.IsNull()) return false;
            int value = new SQL().Database(dbkey).Delete(HtmlTemplate._)
                .Where(new Where()
                    .AndP(HtmlTemplate._TemplateID, templateID, Operator.Equal, true)
                ).Where(where).ToExec();
            if (value != 1) return false;
            if (delCache.IsNull()) return true;
            Cache2.Remove("TH.Mailer.HtmlTemplateCache_", delCache);
            return true;
        }
        /// <summary>
        /// 邮件模版删除记录
        /// </summary>
        /// <param name="templateID">邮件模版编号</param>
        /// <returns>删除是否成功</returns>
        public static bool DeleteByID(Int64? templateID, string dbkey) {
            return DeleteByID(templateID,  dbkey, null, null);
        }
        /// <summary>
        /// 邮件模版删除记录
        /// </summary>
        /// <param name="templateID">邮件模版编号</param>
        /// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
        /// <param name="delCache">删除成功后清理的CACHE key，支持正则</param>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
        /// <returns>删除是否成功</returns>
        public static bool DeleteByID(Int64 templateID,  string dbkey = "", Where where = null, string[] delCache = null) {
            return DeleteByID((Int64?)templateID,  dbkey, where, delCache);
        }
        /// <summary>
        /// 邮件模版删除记录
        /// </summary>
        /// <param name="templateID">邮件模版编号</param>
        /// <returns>删除是否成功</returns>
        public static bool DeleteByID(Int64 templateID, string dbkey) {
            return DeleteByID((Int64?)templateID,  dbkey, null, null);
        }
        /// <summary>
        /// 邮件模版删除多条记录
        /// </summary>
        /// <param name="templateIDList">邮件模版编号列表，用“,”号分隔</param>
        /// <param name="where">删除时附加条件，统一的前面要加链接符（and、or等等）</param>
        /// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
        /// <returns>删除是否成功</returns>
        public static bool DeleteByIDList(IEnumerable<Int64> templateIDList,  string dbkey = "", Where where = null, string[] delCache = null) {
            int value = new SQL().Database(dbkey).Delete(HtmlTemplate._)
                .Where(new Where()
                    .And(HtmlTemplate._TemplateID, "(" + templateIDList .Join(",") + ")", Operator.In)
                ).Where(where).ToExec();
            if (value <= 0) return false;
            if (delCache.IsNull()) return true;
            Cache2.Remove("TH.Mailer.HtmlTemplateCache_", delCache);
            return true;
        }
        /// <summary>
        /// 邮件模版删除多条记录
        /// </summary>
        /// <param name="templateIDList">邮件模版编号列表，用“,”号分隔</param>
        /// <param name="where">删除时附加条件，统一的前面要加链接符（and、or等等）</param>
        /// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
        /// <returns>删除是否成功</returns>
        public static bool DeleteByIDList(IEnumerable<Int64> templateIDList, string dbkey) {
            return DeleteByIDList(templateIDList,  dbkey, null, null);
        }
        /// <summary>
        /// 邮件模版查询所有记录
        /// </summary>
        /// <param name="where">附加条件，统一的前面要加链接符（and、or等等）</param>
        /// <param name="order">排序字段，不加“order by”</param>
        /// <param name="fieldList">设置需要返回的字段</param>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
        /// <returns>返回实体记录集</returns>
        public static IList<HtmlTemplate> SelectListByAll(string dbkey = "", Where where = null, string order = "", string fieldList = "") {
            string cacheNameKey = "TH.Mailer.HtmlTemplateCache_SelectListByAll_{0}_{1}_{2}".FormatWith(where, order, fieldList);
            return Cache2.Get<IList<HtmlTemplate>>(cacheNameKey, cacheSeconds, () => {
                IList<HtmlTemplate> list = new List<HtmlTemplate>();
                if (fieldList.IsNullEmpty()) {
                    list = new SQL().Database(dbkey).From(HtmlTemplate._)
                        .Select(HtmlTemplate._TemplateID)
                        .Select(HtmlTemplate._Subject)
                        .Select(HtmlTemplate._Body)
                        .Select(HtmlTemplate._ShowName)
                        .Select(HtmlTemplate._IsHTML)
                        .Select(HtmlTemplate._Status)
                        .Select(HtmlTemplate._CreateTime)
                        .Where(where).Order(order).ToList<HtmlTemplate>();
                } else {
                    list = new SQL().Database(dbkey).From(HtmlTemplate._).Select(fieldList).Where(where).Order(order).ToList<HtmlTemplate>();
                }
                return list;
            });
        }
        /// <summary>
        /// 邮件模版查询所有记录
        /// </summary>
        /// <returns>返回实体记录集</returns>
        public static IList<HtmlTemplate> SelectListByAll(string dbkey) {
            return SelectListByAll(dbkey, null, "", "");
        }
        /// <summary>
        /// 邮件模版删除所有记录
        /// </summary>
        /// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
        /// <returns>返回实体记录集</returns>
        public static bool RemoveAll(string dbkey = "") {
            return (new SQL().Database(dbkey).Delete(HtmlTemplate._).ToExec()) > 0;
        }
        /// <summary>
        /// 清除邮件模版查询所有记录的缓存
        /// </summary>
        public static void ClearCacheSelectListByAll() {
            //Cache2.Remove("TH.Mailer.HtmlTemplateCache_SelectListByAll___");
            Cache2.RemoveByPattern("TH.Mailer.HtmlTemplateCache_SelectListByAll_(.+?)");
        }
        /// <summary>
        /// 清除邮件模版所有缓存
        /// </summary>
        public static void ClearCacheAll() {
            Cache2.RemoveByPattern("TH.Mailer.HtmlTemplateCache_(.+?)");
        }
    }
}

