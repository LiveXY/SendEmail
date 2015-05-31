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
	/// 天翼连接设置操作类
	///
	/// 修改纪录
	///	 2013-06-03 版本：1.0 系统自动创建此类
	///
	/// </summary>
	public partial class TianYiSettingHelper {
		/// <summary>
		/// 天翼连接设置缓存多少秒 x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// 天翼连接设置添加记录
		/// </summary>
		/// <param name="tianYiSetting">天翼连接设置实体类</param>
		/// <param name="delCache">添加成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>添加是否成功</returns>
		public static bool Insert(TianYiSetting tianYiSetting, string dbkey = "", string[] delCache = null) {
			int obj = new SQL().Database(dbkey).Insert(TianYiSetting._)
				.ValueP(TianYiSetting._TianYiID, tianYiSetting.TianYiID)
				.ValueP(TianYiSetting._TianYiExePath, tianYiSetting.TianYiExePath)
				.ToExec();
			if (delCache.IsNull()) return obj == 1;
			Cache2.Remove("TH.Mailer.TianYiSettingCache_", delCache);
			return obj == 1;
		}
		/// <summary>
		/// 天翼连接设置添加记录
		/// </summary>
		/// <param name="tianYiSetting">天翼连接设置实体类</param>
		/// <returns>添加是否成功</returns>
		public static bool Insert(TianYiSetting tianYiSetting, string dbkey) {
			return Insert(tianYiSetting, dbkey, null);
		}
		/// <summary>
		/// 天翼连接设置修改记录
		/// </summary>
		/// <param name="tianYiSetting">天翼连接设置实体类</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(TianYiSetting tianYiSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			if (tianYiSetting.TianYiID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Update(TianYiSetting._)
				.SetP(TianYiSetting._TianYiExePath, tianYiSetting.TianYiExePath)
				.Where(new Where()
					.AndP(TianYiSetting._TianYiID, tianYiSetting.TianYiID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.TianYiSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// 天翼连接设置修改记录
		/// </summary>
		/// <param name="tianYiSetting">天翼连接设置实体类</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(TianYiSetting tianYiSetting, string dbkey) {
			return Update(tianYiSetting, dbkey, null, null);
		}
		/// <summary>
		/// 天翼连接设置修改多条记录
		/// </summary>
		/// <param name="tianYiIDList">天翼连接设置编号列表，用“,”号分隔</param>
		/// <param name="tianYiSetting">天翼连接设置实体类</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>修改是否成功</returns>
		public static bool UpdateByIDList(IEnumerable<int> tianYiIDList,  TianYiSetting tianYiSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(TianYiSetting._)
				.SetP(TianYiSetting._TianYiExePath, tianYiSetting.TianYiExePath)
				.Where(new Where()
					.And(TianYiSetting._TianYiID, "(" + tianYiIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.TianYiSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// 天翼连接设置修改多条记录
		/// </summary>
		/// <param name="tianYiIDList">天翼连接设置编号列表，用“,”号分隔</param>
		/// <param name="tianYiSetting">天翼连接设置实体类</param>
		/// <returns>修改是否成功</returns>
		public static bool UpdateByIDList(IEnumerable<int> tianYiIDList,  TianYiSetting tianYiSetting, string dbkey) {
			return UpdateByIDList(tianYiIDList,  tianYiSetting, dbkey, null, null);
		}
 		/// <summary>
		/// 天翼连接设置删除记录
		/// </summary>
		/// <param name="tianYiID">天翼连接设置编号</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">删除成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(int? tianYiID,  string dbkey = "", Where where = null, string[] delCache = null) {
			if (tianYiID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Delete(TianYiSetting._)
				.Where(new Where()
					.AndP(TianYiSetting._TianYiID, tianYiID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value != 1) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.TianYiSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// 天翼连接设置删除记录
		/// </summary>
		/// <param name="tianYiID">天翼连接设置编号</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(int? tianYiID, string dbkey) {
			return DeleteByID(tianYiID,  dbkey, null, null);
		}
		/// <summary>
		/// 天翼连接设置删除记录
		/// </summary>
		/// <param name="tianYiID">天翼连接设置编号</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">删除成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(int tianYiID,  string dbkey = "", Where where = null, string[] delCache = null) {
			return DeleteByID((int?)tianYiID,  dbkey, where, delCache);
		}
		/// <summary>
		/// 天翼连接设置删除记录
		/// </summary>
		/// <param name="tianYiID">天翼连接设置编号</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(int tianYiID, string dbkey) {
			return DeleteByID((int?)tianYiID,  dbkey, null, null);
		}
		/// <summary>
		/// 天翼连接设置删除多条记录
		/// </summary>
		/// <param name="tianYiIDList">天翼连接设置编号列表，用“,”号分隔</param>
		/// <param name="where">删除时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByIDList(IEnumerable<int> tianYiIDList,  string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Delete(TianYiSetting._)
				.Where(new Where()
					.And(TianYiSetting._TianYiID, "(" + tianYiIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.TianYiSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// 天翼连接设置删除多条记录
		/// </summary>
		/// <param name="tianYiIDList">天翼连接设置编号列表，用“,”号分隔</param>
		/// <param name="where">删除时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByIDList(IEnumerable<int> tianYiIDList, string dbkey) {
			return DeleteByIDList(tianYiIDList,  dbkey, null, null);
		}
		/// <summary>
		/// 天翼连接设置按主键查询，返回数据的实体类
		/// </summary>
		/// <param name="tianYiID">天翼连接设置编号</param>
		/// <param name="where">附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回单条记录的实体类</returns>
		public static TianYiSetting SelectByID(int tianYiID,  string dbkey = "", Where where = null) {
			string cacheNameKey = "TH.Mailer.TianYiSettingCache_SelectByID_{0}".FormatWith(tianYiID + "_" +  "_" + where);
			return Cache2.Get<TianYiSetting>(cacheNameKey, cacheSeconds, () => {
				TianYiSetting obj = new SQL().Database(dbkey).From(TianYiSetting._)
					.Select(TianYiSetting._TianYiID)
					.Select(TianYiSetting._TianYiExePath)
					.Where(new Where()
						.AndP(TianYiSetting._TianYiID, tianYiID, Operator.Equal)
					).Where(where).ToEntity<TianYiSetting>();
				return obj;
			});
		}
		/// <summary>
		/// 天翼连接设置按主键查询，返回数据的实体类
		/// </summary>
		/// <param name="tianYiID">天翼连接设置编号</param>
		/// <returns>返回单条记录的实体类</returns>
		public static TianYiSetting SelectByID(int tianYiID, string dbkey) {
			return SelectByID(tianYiID,  dbkey, null);
		}
		/// <summary>
		/// 清除天翼连接设置按主键查询的缓存
		/// </summary>
		public static void ClearCacheSelectByID(int tianYiID,  Where where = null) {
			string cacheName = "TH.Mailer.TianYiSettingCache_SelectByID_{0}";
			string cacheNameKey = string.Format(cacheName, tianYiID + "_" +  "_" + where);
			Cache2.Remove(cacheNameKey);
		}
		/// <summary>
		/// 天翼连接设置查询数据，带分页
		/// </summary>
		/// <param name="pageIndex">当前第几页，从1开始</param>
		/// <param name="pageSize">每页记录数</param>
		/// <param name="totalRecords">返回总记录数</param>
		/// <param name="where">附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="order">排序字段，不加“order by”</param>
		/// <param name="fieldList">设置需要返回的字段</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <param name="pageEnum">使用哪种分页方式（not_in、max_top、top_top、row_number、mysql、oracle、sqlite）</param>
		/// <returns>返回实体记录集</returns>
		public static IList<TianYiSetting> SelectPageList(int pageIndex, int pageSize, out long totalRecords, string dbkey = "", Where where = null, string order = "", string fieldList = "", PagerSQLEnum pageEnum = PagerSQLEnum.sqlite) {
			string cacheNameKey = "TH.Mailer.TianYiSettingCache_SelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			string cacheRecordsKey = "TH.Mailer.TianYiSettingCache_RecordsSelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			IList<TianYiSetting> list = (IList<TianYiSetting>)Cache2.Get(cacheNameKey);
			if (!list.IsNull()) { totalRecords = (int)Cache2.Get(cacheRecordsKey); return list; }

			using (PagerSQLHelper s = new PagerSQLHelper(pageEnum)) {
				list = s.GetSQL(pageIndex, pageSize, TianYiSetting._, TianYiSetting._TianYiID, fieldList.IfNullOrEmpty("[TianYiID],[TianYiExePath],"), where, "", order).ToList<TianYiSetting>(out totalRecords, dbkey);
			}
			Cache2.Insert(cacheNameKey, list, cacheSeconds);
			Cache2.Insert(cacheRecordsKey, totalRecords, cacheSeconds);
			return list;
		}
		/// <summary>
		/// 天翼连接设置查询记录，带分页
		/// </summary>
		/// <param name="pageIndex">当前第几页，从1开始</param>
		/// <param name="pageSize">每页记录数</param>
		/// <param name="totalRecords">返回总记录数</param>
		/// <returns>返回实体记录集</returns>
		public static IList<TianYiSetting> SelectPageList(int pageIndex, int pageSize, out long totalRecords, string dbkey) {
			return SelectPageList(pageIndex, pageSize, out totalRecords, dbkey, null, "", "", PagerSQLEnum.sqlite);
		}
		/// <summary>
		/// 清除天翼连接设置查询记录，带分页的缓存
		/// </summary>
		public static void ClearCacheSelectPageList() {
			string cacheNameKey = "TH.Mailer.TianYiSettingCache_SelectPageList_(.+?)";
			string cacheRecordsKey = "TH.Mailer.TianYiSettingCache_RecordsSelectPageList_(.+?)";
			Cache2.RemoveByPattern(cacheNameKey);
			Cache2.RemoveByPattern(cacheRecordsKey);
		}
		/// <summary>
		/// 天翼连接设置删除所有记录
		/// </summary>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回实体记录集</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(TianYiSetting._).ToExec()) > 0;
		}
		/// <summary>
		/// 清除天翼连接设置查询所有记录的缓存
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.TianYiSettingCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.TianYiSettingCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// 清除天翼连接设置所有缓存
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.TianYiSettingCache_(.+?)");
		}
	}
}

