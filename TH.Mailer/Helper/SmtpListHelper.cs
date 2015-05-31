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
	public partial class SmtpListHelper {
		/// <summary>
		/// 缓存多少秒 x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="smtpList">实体类</param>
		/// <param name="delCache">添加成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>添加是否成功</returns>
		public static bool Insert(SmtpList smtpList, string dbkey = "", string[] delCache = null) {
			int obj = new SQL().Database(dbkey).Insert(SmtpList._)
				.ValueP(SmtpList._SmtpServer, smtpList.SmtpServer)
				.ValueP(SmtpList._SmtpPort, smtpList.SmtpPort)
				.ValueP(SmtpList._UserName, smtpList.UserName)
				.ValueP(SmtpList._SPassword, smtpList.SPassword)
				.ValueP(SmtpList._SSL, smtpList.SSL)
				.ValueP(SmtpList._Status, smtpList.Status)
				.ValueP(SmtpList._Sends, smtpList.Sends)
				.ValueP(SmtpList._SendFails, smtpList.SendFails)
				.ValueP(SmtpList._CreateTime, smtpList.CreateTime)
				.ToExec();
			if (delCache.IsNull()) return obj == 1;
			Cache2.Remove("TH.Mailer.SmtpListCache_", delCache);
			return obj == 1;
		}
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="smtpList">实体类</param>
		/// <returns>添加是否成功</returns>
		public static bool Insert(SmtpList smtpList, string dbkey) {
			return Insert(smtpList, dbkey, null);
		}
		/// <summary>
		/// 修改记录
		/// </summary>
		/// <param name="smtpList">实体类</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(SmtpList smtpList, string dbkey = "", Where where = null, string[] delCache = null) {
			if (smtpList.SmtpServer.IsNullEmpty()  && smtpList.SmtpPort.IsNull()  && smtpList.UserName.IsNullEmpty()) return false;
			int value = new SQL().Database(dbkey).Update(SmtpList._)
				.SetP(SmtpList._SPassword, smtpList.SPassword)
				.SetP(SmtpList._SSL, smtpList.SSL)
				.SetP(SmtpList._Status, smtpList.Status)
				.SetP(SmtpList._Sends, smtpList.Sends)
				.SetP(SmtpList._SendFails, smtpList.SendFails)
				.SetP(SmtpList._CreateTime, smtpList.CreateTime)
				.Where(new Where()
					.AndP(SmtpList._SmtpServer, smtpList.SmtpServer, Operator.Equal, true)
					.AndP(SmtpList._SmtpPort, smtpList.SmtpPort, Operator.Equal, true)
					.AndP(SmtpList._UserName, smtpList.UserName, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.SmtpListCache_", delCache);
			return true;
		}
		/// <summary>
		/// 修改记录
		/// </summary>
		/// <param name="smtpList">实体类</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(SmtpList smtpList, string dbkey) {
			return Update(smtpList, dbkey, null, null);
		}
 		/// <summary>
		/// 删除记录
		/// </summary>
		/// <param name="smtpServer">SMTP服务器</param>
		/// <param name="smtpPort">SMTP端口</param>
		/// <param name="userName">登录用户名</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">删除成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(string smtpServer, int? smtpPort, string userName,  string dbkey = "", Where where = null, string[] delCache = null) {
			if (smtpServer.IsNullEmpty()  && smtpPort.IsNull()  && userName.IsNullEmpty()) return false;
			int value = new SQL().Database(dbkey).Delete(SmtpList._)
				.Where(new Where()
					.AndP(SmtpList._SmtpServer, smtpServer, Operator.Equal, true)
					.AndP(SmtpList._SmtpPort, smtpPort, Operator.Equal, true)
					.AndP(SmtpList._UserName, userName, Operator.Equal, true)
				).Where(where).ToExec();
			if (value != 1) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.SmtpListCache_", delCache);
			return true;
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		/// <param name="smtpServer">SMTP服务器</param>
		/// <param name="smtpPort">SMTP端口</param>
		/// <param name="userName">登录用户名</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(string smtpServer, int? smtpPort, string userName, string dbkey) {
			return DeleteByID(smtpServer, smtpPort, userName,  dbkey, null, null);
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		/// <param name="smtpServer">SMTP服务器</param>
		/// <param name="smtpPort">SMTP端口</param>
		/// <param name="userName">登录用户名</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">删除成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(string smtpServer, int smtpPort, string userName,  string dbkey = "", Where where = null, string[] delCache = null) {
			return DeleteByID((string)smtpServer, (int?)smtpPort, (string)userName,  dbkey, where, delCache);
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		/// <param name="smtpServer">SMTP服务器</param>
		/// <param name="smtpPort">SMTP端口</param>
		/// <param name="userName">登录用户名</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(string smtpServer, int smtpPort, string userName, string dbkey) {
			return DeleteByID((string)smtpServer, (int?)smtpPort, (string)userName,  dbkey, null, null);
		}
		/// <summary>
		/// 记录是否存在
		/// </summary>
		/// <param name="smtpServer">SMTP服务器</param>
		/// <param name="smtpPort">SMTP端口</param>
		/// <param name="userName">登录用户名</param>
		/// <param name="where">附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>记录是否存在</returns>
		public static bool IsExistByID(string smtpServer, int smtpPort, string userName,  string dbkey = "", Where where = null) {
			long value = new SQL().Database(dbkey).Count(SmtpList._SmtpServer).From(SmtpList._)
				.Where(new Where()
					.AndP(SmtpList._SmtpServer, smtpServer, Operator.Equal)
					.AndP(SmtpList._SmtpPort, smtpPort, Operator.Equal)
					.AndP(SmtpList._UserName, userName, Operator.Equal)
				).Where(where).ToScalar().ToString().ToBigInt();
			return value == 1;
		}
		/// <summary>
		/// 记录是否存在
		/// </summary>
		/// <param name="smtpServer">SMTP服务器</param>
		/// <param name="smtpPort">SMTP端口</param>
		/// <param name="userName">登录用户名</param>
		/// <returns>记录是否存在</returns>
		public static bool IsExistByID(string smtpServer, int smtpPort, string userName, string dbkey) {
			return IsExistByID(smtpServer, smtpPort, userName,  dbkey, null);
		}
		/// <summary>
		/// 按主键查询，返回数据的实体类
		/// </summary>
		/// <param name="smtpServer">SMTP服务器</param>
		/// <param name="smtpPort">SMTP端口</param>
		/// <param name="userName">登录用户名</param>
		/// <param name="where">附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回单条记录的实体类</returns>
		public static SmtpList SelectByID(string smtpServer, int smtpPort, string userName,  string dbkey = "", Where where = null) {
			string cacheNameKey = "TH.Mailer.SmtpListCache_SelectByID_{0}".FormatWith(smtpServer + "_" + smtpPort + "_" + userName + "_" +  "_" + where);
			return Cache2.Get<SmtpList>(cacheNameKey, cacheSeconds, () => {
				SmtpList obj = new SQL().Database(dbkey).From(SmtpList._)
					.Select(SmtpList._SmtpServer)
					.Select(SmtpList._SmtpPort)
					.Select(SmtpList._UserName)
					.Select(SmtpList._SPassword)
					.Select(SmtpList._SSL)
					.Select(SmtpList._Status)
					.Select(SmtpList._Sends)
					.Select(SmtpList._SendFails)
					.Select(SmtpList._CreateTime)
					.Where(new Where()
						.AndP(SmtpList._SmtpServer, smtpServer, Operator.Equal)
						.AndP(SmtpList._SmtpPort, smtpPort, Operator.Equal)
						.AndP(SmtpList._UserName, userName, Operator.Equal)
					).Where(where).ToEntity<SmtpList>();
				return obj;
			});
		}
		/// <summary>
		/// 按主键查询，返回数据的实体类
		/// </summary>
		/// <param name="smtpServer">SMTP服务器</param>
		/// <param name="smtpPort">SMTP端口</param>
		/// <param name="userName">登录用户名</param>
		/// <returns>返回单条记录的实体类</returns>
		public static SmtpList SelectByID(string smtpServer, int smtpPort, string userName, string dbkey) {
			return SelectByID(smtpServer, smtpPort, userName,  dbkey, null);
		}
		/// <summary>
		/// 清除按主键查询的缓存
		/// </summary>
		public static void ClearCacheSelectByID(string smtpServer, int smtpPort, string userName,  Where where = null) {
			string cacheName = "TH.Mailer.SmtpListCache_SelectByID_{0}";
			string cacheNameKey = string.Format(cacheName, smtpServer + "_" + smtpPort + "_" + userName + "_" +  "_" + where);
			Cache2.Remove(cacheNameKey);
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
		public static IList<SmtpList> SelectPageList(int pageIndex, int pageSize, out long totalRecords, string dbkey = "", Where where = null, string order = "", string fieldList = "", PagerSQLEnum pageEnum = PagerSQLEnum.sqlite) {
			string cacheNameKey = "TH.Mailer.SmtpListCache_SelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			string cacheRecordsKey = "TH.Mailer.SmtpListCache_RecordsSelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			IList<SmtpList> list = (IList<SmtpList>)Cache2.Get(cacheNameKey);
			if (!list.IsNull()) { totalRecords = (int)Cache2.Get(cacheRecordsKey); return list; }

			using (PagerSQLHelper s = new PagerSQLHelper(pageEnum)) {
				list = s.GetSQL(pageIndex, pageSize, SmtpList._, SmtpList._SmtpServer, fieldList.IfNullOrEmpty("[SmtpServer],[SmtpPort],[UserName],[SPassword],[SSL],[Status],[Sends],[SendFails],[CreateTime],"), where, "", order).ToList<SmtpList>(out totalRecords, dbkey);
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
		public static IList<SmtpList> SelectPageList(int pageIndex, int pageSize, out long totalRecords, string dbkey) {
			return SelectPageList(pageIndex, pageSize, out totalRecords, dbkey, null, "", "", PagerSQLEnum.sqlite);
		}
		/// <summary>
		/// 清除查询记录，带分页的缓存
		/// </summary>
		public static void ClearCacheSelectPageList() {
			string cacheNameKey = "TH.Mailer.SmtpListCache_SelectPageList_(.+?)";
			string cacheRecordsKey = "TH.Mailer.SmtpListCache_RecordsSelectPageList_(.+?)";
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
		public static IList<SmtpList> SelectListByAll(string dbkey = "", Where where = null, string order = "", string fieldList = "") {
			string cacheNameKey = "TH.Mailer.SmtpListCache_SelectListByAll_{0}_{1}_{2}".FormatWith(where, order, fieldList);
			return Cache2.Get<IList<SmtpList>>(cacheNameKey, cacheSeconds, () => {
				IList<SmtpList> list = new List<SmtpList>();
				if (fieldList.IsNullEmpty()) {
					list = new SQL().Database(dbkey).From(SmtpList._)
						.Select(SmtpList._SmtpServer)
						.Select(SmtpList._SmtpPort)
						.Select(SmtpList._UserName)
						.Select(SmtpList._SPassword)
						.Select(SmtpList._SSL)
						.Select(SmtpList._Status)
						.Select(SmtpList._Sends)
						.Select(SmtpList._SendFails)
						.Select(SmtpList._CreateTime)
						.Where(where).Order(order).ToList<SmtpList>();
				} else {
					list = new SQL().Database(dbkey).From(SmtpList._).Select(fieldList).Where(where).Order(order).ToList<SmtpList>();
				}
				return list;
			});
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		/// <returns>返回实体记录集</returns>
		public static IList<SmtpList> SelectListByAll(string dbkey) {
			return SelectListByAll(dbkey, null, "", "");
		}
		/// <summary>
		/// 删除所有记录
		/// </summary>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回实体记录集</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(SmtpList._).ToExec()) > 0;
		}
		/// <summary>
		/// 清除查询所有记录的缓存
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.SmtpListCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.SmtpListCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// 清除所有缓存
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.SmtpListCache_(.+?)");
		}
	}
}

