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
	/// 操作类
	///
	/// 修改纪录
	///	 2013-06-03 版本：1.0 系统自动创建此类
	///
	/// </summary>
	public partial class IpHistoryHelper {
		/// <summary>
		/// 缓存多少秒 x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="ipHistory">实体类</param>
		/// <param name="delCache">添加成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>添加是否成功</returns>
		public static bool Insert(IpHistory ipHistory, string dbkey = "", string[] delCache = null) {
			int obj = new SQL().Database(dbkey).Insert(IpHistory._)
				.ValueP(IpHistory._IP, ipHistory.IP)
				.ValueP(IpHistory._CreateTime, ipHistory.CreateTime)
				.ToExec();
			if (delCache.IsNull()) return obj == 1;
			Cache2.Remove("TH.Mailer.IpHistoryCache_", delCache);
			return obj == 1;
		}
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="ipHistory">实体类</param>
		/// <returns>添加是否成功</returns>
		public static bool Insert(IpHistory ipHistory, string dbkey) {
			return Insert(ipHistory, dbkey, null);
		}
		/// <summary>
		/// 修改记录
		/// </summary>
		/// <param name="ipHistory">实体类</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(IpHistory ipHistory, string dbkey = "", Where where = null, string[] delCache = null) {
			if (ipHistory.IP.IsNullEmpty()) return false;
			int value = new SQL().Database(dbkey).Update(IpHistory._)
				.SetP(IpHistory._CreateTime, ipHistory.CreateTime)
				.Where(new Where()
					.AndP(IpHistory._IP, ipHistory.IP, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpHistoryCache_", delCache);
			return true;
		}
		/// <summary>
		/// 修改记录
		/// </summary>
		/// <param name="ipHistory">实体类</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(IpHistory ipHistory, string dbkey) {
			return Update(ipHistory, dbkey, null, null);
		}
		/// <summary>
		/// 修改多条记录
		/// </summary>
		/// <param name="iPList">IP地址列表，用“,”号分隔</param>
		/// <param name="ipHistory">实体类</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>修改是否成功</returns>
		public static bool UpdateByIDList(IEnumerable<string> iPList,  IpHistory ipHistory, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(IpHistory._)
				.SetP(IpHistory._CreateTime, ipHistory.CreateTime)
				.Where(new Where()
					.And(IpHistory._IP, "(" + iPList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpHistoryCache_", delCache);
			return true;
		}
		/// <summary>
		/// 修改多条记录
		/// </summary>
		/// <param name="iPList">IP地址列表，用“,”号分隔</param>
		/// <param name="ipHistory">实体类</param>
		/// <returns>修改是否成功</returns>
		public static bool UpdateByIDList(IEnumerable<string> iPList,  IpHistory ipHistory, string dbkey) {
			return UpdateByIDList(iPList,  ipHistory, dbkey, null, null);
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		/// <param name="iP">IP地址</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">删除成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(string iP,  string dbkey = "", Where where = null, string[] delCache = null) {
			if (iP.IsNullEmpty()) return false;
			int value = new SQL().Database(dbkey).Delete(IpHistory._)
				.Where(new Where()
					.AndP(IpHistory._IP, iP, Operator.Equal, true)
				).Where(where).ToExec();
			if (value != 1) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpHistoryCache_", delCache);
			return true;
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		/// <param name="iP">IP地址</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(string iP, string dbkey) {
			return DeleteByID(iP,  dbkey, null, null);
		}
		/// <summary>
		/// 删除多条记录
		/// </summary>
		/// <param name="iPList">IP地址列表，用“,”号分隔</param>
		/// <param name="where">删除时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByIDList(IEnumerable<string> iPList,  string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Delete(IpHistory._)
				.Where(new Where()
					.And(IpHistory._IP, "(" + iPList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpHistoryCache_", delCache);
			return true;
		}
		/// <summary>
		/// 删除多条记录
		/// </summary>
		/// <param name="iPList">IP地址列表，用“,”号分隔</param>
		/// <param name="where">删除时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByIDList(IEnumerable<string> iPList, string dbkey) {
			return DeleteByIDList(iPList,  dbkey, null, null);
		}
		/// <summary>
		/// 记录是否存在
		/// </summary>
		/// <param name="iP">IP地址</param>
		/// <param name="where">附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>记录是否存在</returns>
		public static bool IsExistByID(string iP,  string dbkey = "", Where where = null) {
			long value = new SQL().Database(dbkey).Count(IpHistory._IP).From(IpHistory._)
				.Where(new Where()
					.AndP(IpHistory._IP, iP, Operator.Equal)
				).Where(where).ToScalar().ToString().ToBigInt();
			return value == 1;
		}
		/// <summary>
		/// 记录是否存在
		/// </summary>
		/// <param name="iP">IP地址</param>
		/// <returns>记录是否存在</returns>
		public static bool IsExistByID(string iP, string dbkey) {
			return IsExistByID(iP,  dbkey, null);
		}
		/// <summary>
		/// 查询数据，带分页
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
		public static IList<IpHistory> SelectPageList(int pageIndex, int pageSize, out int totalRecords, string dbkey = "", Where where = null, string order = "", string fieldList = "", PagerSQLEnum pageEnum = PagerSQLEnum.sqlite) {
			totalRecords = 0;
			string cacheNameKey = "TH.Mailer.IpHistoryCache_SelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			string cacheRecordsKey = "TH.Mailer.IpHistoryCache_RecordsSelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			IList<IpHistory> list = (IList<IpHistory>)Cache2.Get(cacheNameKey);
			if (!list.IsNull()) { totalRecords = (int)Cache2.Get(cacheRecordsKey); return list; }

			using (PagerSQLHelper s = new PagerSQLHelper(pageEnum)) {
				PagerSql sql = s.GetSQL(pageIndex, pageSize, IpHistory._, IpHistory._IP, fieldList.IfNullOrEmpty("[IP],[CreateTime],"), where, "", order);
				IDataReader dr = Data.Pool(dbkey).GetDbDataReader(sql.DataSql + ";" + sql.CountSql);
				if (dr.IsNull()) return list;
				list = dr.ToList<IpHistory>(false);
				bool result = dr.NextResult();
				if (result) { dr.Read(); totalRecords = dr[0].ToString().ToInt(); }
				dr.Close (); dr.Dispose(); dr = null;
			}
			Cache2.Insert(cacheNameKey, list, cacheSeconds);
			Cache2.Insert(cacheRecordsKey, totalRecords, cacheSeconds);
			return list;
		}
		/// <summary>
		/// 查询记录，带分页
		/// </summary>
		/// <param name="pageIndex">当前第几页，从1开始</param>
		/// <param name="pageSize">每页记录数</param>
		/// <param name="totalRecords">返回总记录数</param>
		/// <returns>返回实体记录集</returns>
		public static IList<IpHistory> SelectPageList(int pageIndex, int pageSize, out int totalRecords, string dbkey) {
			return SelectPageList(pageIndex, pageSize, out totalRecords, dbkey, null, "", "", PagerSQLEnum.sqlite);
		}
		/// <summary>
		/// 清除查询记录，带分页的缓存
		/// </summary>
		public static void ClearCacheSelectPageList() {
			string cacheNameKey = "TH.Mailer.IpHistoryCache_SelectPageList_(.+?)";
			string cacheRecordsKey = "TH.Mailer.IpHistoryCache_RecordsSelectPageList_(.+?)";
			Cache2.RemoveByPattern(cacheNameKey);
			Cache2.RemoveByPattern(cacheRecordsKey);
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		/// <param name="where">附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="order">排序字段，不加“order by”</param>
		/// <param name="fieldList">设置需要返回的字段</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回实体记录集</returns>
		public static IList<IpHistory> SelectListByAll(string dbkey = "", Where where = null, string order = "", string fieldList = "") {
			string cacheNameKey = "TH.Mailer.IpHistoryCache_SelectListByAll_{0}_{1}_{2}".FormatWith(where, order, fieldList);
			return Cache2.Get<IList<IpHistory>>(cacheNameKey, cacheSeconds, () => {
				IList<IpHistory> list = new List<IpHistory>();
				if (fieldList.IsNullEmpty()) {
					list = new SQL().Database(dbkey).From(IpHistory._)
						.Select(IpHistory._IP)
						.Select(IpHistory._CreateTime)
						.Where(where).Order(order).ToList<IpHistory>();
				} else {
					list = new SQL().Database(dbkey).From(IpHistory._).Select(fieldList).Where(where).Order(order).ToList<IpHistory>();
				}
				return list;
			});
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		/// <returns>返回实体记录集</returns>
		public static IList<IpHistory> SelectListByAll(string dbkey) {
			return SelectListByAll(dbkey, null, "", "");
		}
		/// <summary>
		/// 删除所有记录
		/// </summary>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回实体记录集</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(IpHistory._).ToExec()) > 0;
		}
		/// <summary>
		/// 清除查询所有记录的缓存
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.IpHistoryCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.IpHistoryCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// 清除所有缓存
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.IpHistoryCache_(.+?)");
		}
	}
}

