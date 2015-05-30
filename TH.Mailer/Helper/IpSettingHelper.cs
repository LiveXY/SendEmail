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
	/// 获取IP配置操作类
	///
	/// 修改纪录
	///	 2013-06-03 版本：1.0 系统自动创建此类
	///
	/// </summary>
	public partial class IpSettingHelper {
		/// <summary>
		/// 获取IP配置缓存多少秒 x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// 获取IP配置添加记录
		/// </summary>
		/// <param name="ipSetting">获取IP配置实体类</param>
		/// <param name="delCache">添加成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>返回添加成功后的ID</returns>
		public static Int64 Insert(IpSetting ipSetting, string dbkey = "", string[] delCache = null) {
			object obj = new SQL().Database(dbkey).Insert(IpSetting._)
				.ValueP(IpSetting._IPCID, ipSetting.IPCID)
				.ValueP(IpSetting._WebName, ipSetting.WebName)
				.ValueP(IpSetting._IPUrl, ipSetting.IPUrl)
				.ValueP(IpSetting._IPRegex, ipSetting.IPRegex)
				.ValueP(IpSetting._DataEncode, ipSetting.DataEncode)
				.ToExec();
			if (obj.ToInt() != 1) return 0;
			obj = new SQL().Database(dbkey).From(IpSetting._).Max("IPCID").ToScalar();
			if (obj.IsAllNull()) return 0;
			Int64 value = obj.ToString().ToBigInt();
			if (delCache.IsNull()) return value;
			Cache2.Remove("TH.Mailer.IpSettingCache_", delCache);
			return value;
		}
		/// <summary>
		/// 获取IP配置添加记录
		/// </summary>
		/// <param name="ipSetting">获取IP配置实体类</param>
		/// <returns>返回添加成功后的ID</returns>
		public static Int64 Insert(IpSetting ipSetting, string dbkey) {
			return Insert(ipSetting, dbkey, null);
		}
		/// <summary>
		/// 获取IP配置修改记录
		/// </summary>
		/// <param name="ipSetting">获取IP配置实体类</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(IpSetting ipSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			if (ipSetting.IPCID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Update(IpSetting._)
				.SetP(IpSetting._WebName, ipSetting.WebName)
				.SetP(IpSetting._IPUrl, ipSetting.IPUrl)
				.SetP(IpSetting._IPRegex, ipSetting.IPRegex)
				.SetP(IpSetting._DataEncode, ipSetting.DataEncode)
				.Where(new Where()
					.AndP(IpSetting._IPCID, ipSetting.IPCID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// 获取IP配置修改记录
		/// </summary>
		/// <param name="ipSetting">获取IP配置实体类</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(IpSetting ipSetting, string dbkey) {
			return Update(ipSetting, dbkey, null, null);
		}
		/// <summary>
		/// 获取IP配置修改多条记录
		/// </summary>
		/// <param name="iPCIDList">获取IP配置编号列表，用“,”号分隔</param>
		/// <param name="ipSetting">获取IP配置实体类</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>修改是否成功</returns>
		public static bool UpdateByIDList(IEnumerable<Int64> iPCIDList,  IpSetting ipSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(IpSetting._)
				.SetP(IpSetting._WebName, ipSetting.WebName)
				.SetP(IpSetting._IPUrl, ipSetting.IPUrl)
				.SetP(IpSetting._IPRegex, ipSetting.IPRegex)
				.SetP(IpSetting._DataEncode, ipSetting.DataEncode)
				.Where(new Where()
					.And(IpSetting._IPCID, "(" + iPCIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// 获取IP配置修改多条记录
		/// </summary>
		/// <param name="iPCIDList">获取IP配置编号列表，用“,”号分隔</param>
		/// <param name="ipSetting">获取IP配置实体类</param>
		/// <returns>修改是否成功</returns>
		public static bool UpdateByIDList(IEnumerable<Int64> iPCIDList,  IpSetting ipSetting, string dbkey) {
			return UpdateByIDList(iPCIDList,  ipSetting, dbkey, null, null);
		}
 		/// <summary>
		/// 获取IP配置删除记录
		/// </summary>
		/// <param name="iPCID">获取IP配置编号</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">删除成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(Int64? iPCID,  string dbkey = "", Where where = null, string[] delCache = null) {
			if (iPCID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Delete(IpSetting._)
				.Where(new Where()
					.AndP(IpSetting._IPCID, iPCID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value != 1) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// 获取IP配置删除记录
		/// </summary>
		/// <param name="iPCID">获取IP配置编号</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(Int64? iPCID, string dbkey) {
			return DeleteByID(iPCID,  dbkey, null, null);
		}
		/// <summary>
		/// 获取IP配置删除记录
		/// </summary>
		/// <param name="iPCID">获取IP配置编号</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">删除成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(Int64 iPCID,  string dbkey = "", Where where = null, string[] delCache = null) {
			return DeleteByID((Int64?)iPCID,  dbkey, where, delCache);
		}
		/// <summary>
		/// 获取IP配置删除记录
		/// </summary>
		/// <param name="iPCID">获取IP配置编号</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(Int64 iPCID, string dbkey) {
			return DeleteByID((Int64?)iPCID,  dbkey, null, null);
		}
		/// <summary>
		/// 获取IP配置删除多条记录
		/// </summary>
		/// <param name="iPCIDList">获取IP配置编号列表，用“,”号分隔</param>
		/// <param name="where">删除时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByIDList(IEnumerable<Int64> iPCIDList,  string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Delete(IpSetting._)
				.Where(new Where()
					.And(IpSetting._IPCID, "(" + iPCIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// 获取IP配置删除多条记录
		/// </summary>
		/// <param name="iPCIDList">获取IP配置编号列表，用“,”号分隔</param>
		/// <param name="where">删除时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByIDList(IEnumerable<Int64> iPCIDList, string dbkey) {
			return DeleteByIDList(iPCIDList,  dbkey, null, null);
		}
		/// <summary>
		/// 获取IP配置查询所有记录
		/// </summary>
		/// <param name="where">附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="order">排序字段，不加“order by”</param>
		/// <param name="fieldList">设置需要返回的字段</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回实体记录集</returns>
		public static IList<IpSetting> SelectListByAll(string dbkey = "", Where where = null, string order = "", string fieldList = "") {
			string cacheNameKey = "TH.Mailer.IpSettingCache_SelectListByAll_{0}_{1}_{2}".FormatWith(where, order, fieldList);
			return Cache2.Get<IList<IpSetting>>(cacheNameKey, cacheSeconds, () => {
				IList<IpSetting> list = new List<IpSetting>();
				if (fieldList.IsNullEmpty()) {
					list = new SQL().Database(dbkey).From(IpSetting._)
						.Select(IpSetting._IPCID)
						.Select(IpSetting._WebName)
						.Select(IpSetting._IPUrl)
						.Select(IpSetting._IPRegex)
						.Select(IpSetting._DataEncode)
						.Where(where).Order(order).ToList<IpSetting>();
				} else {
					list = new SQL().Database(dbkey).From(IpSetting._).Select(fieldList).Where(where).Order(order).ToList<IpSetting>();
				}
				return list;
			});
		}
		/// <summary>
		/// 获取IP配置查询所有记录
		/// </summary>
		/// <returns>返回实体记录集</returns>
		public static IList<IpSetting> SelectListByAll(string dbkey) {
			return SelectListByAll(dbkey, null, "", "");
		}
		/// <summary>
		/// 获取IP配置删除所有记录
		/// </summary>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回实体记录集</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(IpSetting._).ToExec()) > 0;
		}
		/// <summary>
		/// 清除获取IP配置查询所有记录的缓存
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.IpSettingCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.IpSettingCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// 清除获取IP配置所有缓存
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.IpSettingCache_(.+?)");
		}
	}
}

