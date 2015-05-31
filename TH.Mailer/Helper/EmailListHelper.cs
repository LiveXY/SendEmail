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
	public partial class EmailListHelper {
		/// <summary>
		/// 缓存多少秒 x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="emailList">实体类</param>
		/// <param name="delCache">添加成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>添加是否成功</returns>
		public static bool Insert(EmailList emailList, string dbkey = "", string[] delCache = null) {
			int obj = new SQL().Database(dbkey).Insert(EmailList._)
				.ValueP(EmailList._EmailAddress, emailList.EmailAddress)
				.ValueP(EmailList._NickName, emailList.NickName)
				.ValueP(EmailList._LastSendStatus, emailList.LastSendStatus)
				.ValueP(EmailList._LastSendError, emailList.LastSendError)
				.ValueP(EmailList._LastSendTime, emailList.LastSendTime)
				.ValueP(EmailList._LastSendSmtp, emailList.LastSendSmtp)
				.ValueP(EmailList._SendCount, emailList.SendCount)
				.ValueP(EmailList._CreateTime, emailList.CreateTime)
				.ValueP(EmailList._ex0, emailList.ex0)
				.ValueP(EmailList._ex1, emailList.ex1)
				.ValueP(EmailList._ex2, emailList.ex2)
				.ValueP(EmailList._ex3, emailList.ex3)
				.ValueP(EmailList._ex4, emailList.ex4)
				.ValueP(EmailList._ex5, emailList.ex5)
				.ValueP(EmailList._ex6, emailList.ex6)
				.ValueP(EmailList._ex7, emailList.ex7)
				.ValueP(EmailList._ex8, emailList.ex8)
				.ToExec();
			if (delCache.IsNull()) return obj == 1;
			Cache2.Remove("TH.Mailer.EmailListCache_", delCache);
			return obj == 1;
		}
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="emailList">实体类</param>
		/// <returns>添加是否成功</returns>
		public static bool Insert(EmailList emailList, string dbkey) {
			return Insert(emailList, dbkey, null);
		}
		/// <summary>
		/// 修改记录
		/// </summary>
		/// <param name="emailList">实体类</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(EmailList emailList, string dbkey = "", Where where = null, string[] delCache = null) {
			if (emailList.EmailAddress.IsNullEmpty()) return false;
			int value = new SQL().Database(dbkey).Update(EmailList._)
				.SetP(EmailList._NickName, emailList.NickName)
				.SetP(EmailList._LastSendStatus, emailList.LastSendStatus)
				.SetP(EmailList._LastSendError, emailList.LastSendError)
				.SetP(EmailList._LastSendTime, emailList.LastSendTime)
				.SetP(EmailList._LastSendSmtp, emailList.LastSendSmtp)
				.SetP(EmailList._SendCount, emailList.SendCount)
				.SetP(EmailList._CreateTime, emailList.CreateTime)
				.SetP(EmailList._ex0, emailList.ex0)
				.SetP(EmailList._ex1, emailList.ex1)
				.SetP(EmailList._ex2, emailList.ex2)
				.SetP(EmailList._ex3, emailList.ex3)
				.SetP(EmailList._ex4, emailList.ex4)
				.SetP(EmailList._ex5, emailList.ex5)
				.SetP(EmailList._ex6, emailList.ex6)
				.SetP(EmailList._ex7, emailList.ex7)
				.SetP(EmailList._ex8, emailList.ex8)
				.Where(new Where()
					.AndP(EmailList._EmailAddress, emailList.EmailAddress, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.EmailListCache_", delCache);
			return true;
		}
		/// <summary>
		/// 修改记录
		/// </summary>
		/// <param name="emailList">实体类</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(EmailList emailList, string dbkey) {
			return Update(emailList, dbkey, null, null);
		}
		/// <summary>
		/// 修改多条记录
		/// </summary>
		/// <param name="emailAddressList">发送的Email列表，用“,”号分隔</param>
		/// <param name="emailList">实体类</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>修改是否成功</returns>
		public static bool UpdateByIDList(IEnumerable<string> emailAddressList,  EmailList emailList, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(EmailList._)
				.SetP(EmailList._NickName, emailList.NickName)
				.SetP(EmailList._LastSendStatus, emailList.LastSendStatus)
				.SetP(EmailList._LastSendError, emailList.LastSendError)
				.SetP(EmailList._LastSendTime, emailList.LastSendTime)
				.SetP(EmailList._LastSendSmtp, emailList.LastSendSmtp)
				.SetP(EmailList._SendCount, emailList.SendCount)
				.SetP(EmailList._CreateTime, emailList.CreateTime)
				.SetP(EmailList._ex0, emailList.ex0)
				.SetP(EmailList._ex1, emailList.ex1)
				.SetP(EmailList._ex2, emailList.ex2)
				.SetP(EmailList._ex3, emailList.ex3)
				.SetP(EmailList._ex4, emailList.ex4)
				.SetP(EmailList._ex5, emailList.ex5)
				.SetP(EmailList._ex6, emailList.ex6)
				.SetP(EmailList._ex7, emailList.ex7)
				.SetP(EmailList._ex8, emailList.ex8)
				.Where(new Where()
					.And(EmailList._EmailAddress, "(" + emailAddressList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.EmailListCache_", delCache);
			return true;
		}
		/// <summary>
		/// 修改多条记录
		/// </summary>
		/// <param name="emailAddressList">发送的Email列表，用“,”号分隔</param>
		/// <param name="emailList">实体类</param>
		/// <returns>修改是否成功</returns>
		public static bool UpdateByIDList(IEnumerable<string> emailAddressList,  EmailList emailList, string dbkey) {
			return UpdateByIDList(emailAddressList,  emailList, dbkey, null, null);
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		/// <param name="emailAddress">发送的Email</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">删除成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(string emailAddress,  string dbkey = "", Where where = null, string[] delCache = null) {
			if (emailAddress.IsNullEmpty()) return false;
			int value = new SQL().Database(dbkey).Delete(EmailList._)
				.Where(new Where()
					.AndP(EmailList._EmailAddress, emailAddress, Operator.Equal, true)
				).Where(where).ToExec();
			if (value != 1) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.EmailListCache_", delCache);
			return true;
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		/// <param name="emailAddress">发送的Email</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByID(string emailAddress, string dbkey) {
			return DeleteByID(emailAddress,  dbkey, null, null);
		}
		/// <summary>
		/// 删除多条记录
		/// </summary>
		/// <param name="emailAddressList">发送的Email列表，用“,”号分隔</param>
		/// <param name="where">删除时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByIDList(IEnumerable<string> emailAddressList,  string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Delete(EmailList._)
				.Where(new Where()
					.And(EmailList._EmailAddress, "(" + emailAddressList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.EmailListCache_", delCache);
			return true;
		}
		/// <summary>
		/// 删除多条记录
		/// </summary>
		/// <param name="emailAddressList">发送的Email列表，用“,”号分隔</param>
		/// <param name="where">删除时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>删除是否成功</returns>
		public static bool DeleteByIDList(IEnumerable<string> emailAddressList, string dbkey) {
			return DeleteByIDList(emailAddressList,  dbkey, null, null);
		}
		/// <summary>
		/// 记录是否存在
		/// </summary>
		/// <param name="emailAddress">发送的Email</param>
		/// <param name="where">附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>记录是否存在</returns>
		public static bool IsExistByID(string emailAddress,  string dbkey = "", Where where = null) {
			long value = new SQL().Database(dbkey).Count(EmailList._EmailAddress).From(EmailList._)
				.Where(new Where()
					.AndP(EmailList._EmailAddress, emailAddress, Operator.Equal)
				).Where(where).ToScalar().ToString().ToBigInt();
			return value == 1;
		}
		/// <summary>
		/// 记录是否存在
		/// </summary>
		/// <param name="emailAddress">发送的Email</param>
		/// <returns>记录是否存在</returns>
		public static bool IsExistByID(string emailAddress, string dbkey) {
			return IsExistByID(emailAddress,  dbkey, null);
		}
		/// <summary>
		/// 按主键查询，返回数据的实体类
		/// </summary>
		/// <param name="emailAddress">发送的Email</param>
		/// <param name="where">附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回单条记录的实体类</returns>
		public static EmailList SelectByID(string emailAddress,  string dbkey = "", Where where = null) {
			string cacheNameKey = "TH.Mailer.EmailListCache_SelectByID_{0}".FormatWith(emailAddress + "_" +  "_" + where);
			return Cache2.Get<EmailList>(cacheNameKey, cacheSeconds, () => {
				EmailList obj = new SQL().Database(dbkey).From(EmailList._)
					.Select(EmailList._EmailAddress)
					.Select(EmailList._NickName)
					.Select(EmailList._LastSendStatus)
					.Select(EmailList._LastSendError)
					.Select(EmailList._LastSendTime)
					.Select(EmailList._LastSendSmtp)
					.Select(EmailList._SendCount)
					.Select(EmailList._CreateTime)
					.Select(EmailList._ex0)
					.Select(EmailList._ex1)
					.Select(EmailList._ex2)
					.Select(EmailList._ex3)
					.Select(EmailList._ex4)
					.Select(EmailList._ex5)
					.Select(EmailList._ex6)
					.Select(EmailList._ex7)
					.Select(EmailList._ex8)
					.Where(new Where()
						.AndP(EmailList._EmailAddress, emailAddress, Operator.Equal)
					).Where(where).ToEntity<EmailList>();
				return obj;
			});
		}
		/// <summary>
		/// 按主键查询，返回数据的实体类
		/// </summary>
		/// <param name="emailAddress">发送的Email</param>
		/// <returns>返回单条记录的实体类</returns>
		public static EmailList SelectByID(string emailAddress, string dbkey) {
			return SelectByID(emailAddress,  dbkey, null);
		}
		/// <summary>
		/// 清除按主键查询的缓存
		/// </summary>
		public static void ClearCacheSelectByID(string emailAddress,  Where where = null) {
			string cacheName = "TH.Mailer.EmailListCache_SelectByID_{0}";
			string cacheNameKey = string.Format(cacheName, emailAddress + "_" +  "_" + where);
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
		public static IList<EmailList> SelectPageList(int pageIndex, int pageSize, out long totalRecords, string dbkey = "", Where where = null, string order = "", string fieldList = "", PagerSQLEnum pageEnum = PagerSQLEnum.sqlite) {
			string cacheNameKey = "TH.Mailer.EmailListCache_SelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			string cacheRecordsKey = "TH.Mailer.EmailListCache_RecordsSelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			IList<EmailList> list = (IList<EmailList>)Cache2.Get(cacheNameKey);
			if (!list.IsNull()) { totalRecords = (int)Cache2.Get(cacheRecordsKey); return list; }

			using (PagerSQLHelper s = new PagerSQLHelper(pageEnum)) {
				list = s.GetSQL(pageIndex, pageSize, EmailList._, EmailList._EmailAddress, fieldList.IfNullOrEmpty("[EmailAddress],[NickName],[LastSendStatus],[LastSendError],[LastSendTime],[LastSendSmtp],[SendCount],[CreateTime],[ex0],[ex1],[ex2],[ex3],[ex4],[ex5],[ex6],[ex7],[ex8],"), where, "", order).ToList<EmailList>(out totalRecords, dbkey);
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
		public static IList<EmailList> SelectPageList(int pageIndex, int pageSize, out long totalRecords, string dbkey) {
			return SelectPageList(pageIndex, pageSize, out totalRecords, dbkey, null, "", "", PagerSQLEnum.sqlite);
		}
		/// <summary>
		/// 清除查询记录，带分页的缓存
		/// </summary>
		public static void ClearCacheSelectPageList() {
			string cacheNameKey = "TH.Mailer.EmailListCache_SelectPageList_(.+?)";
			string cacheRecordsKey = "TH.Mailer.EmailListCache_RecordsSelectPageList_(.+?)";
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
		public static IList<EmailList> SelectListByAll(string dbkey = "", Where where = null, string order = "", string fieldList = "") {
			string cacheNameKey = "TH.Mailer.EmailListCache_SelectListByAll_{0}_{1}_{2}".FormatWith(where, order, fieldList);
			return Cache2.Get<IList<EmailList>>(cacheNameKey, cacheSeconds, () => {
				IList<EmailList> list = new List<EmailList>();
				if (fieldList.IsNullEmpty()) {
					list = new SQL().Database(dbkey).From(EmailList._)
						.Select(EmailList._EmailAddress)
						.Select(EmailList._NickName)
						.Select(EmailList._LastSendStatus)
						.Select(EmailList._LastSendError)
						.Select(EmailList._LastSendTime)
						.Select(EmailList._LastSendSmtp)
						.Select(EmailList._SendCount)
						.Select(EmailList._CreateTime)
						.Select(EmailList._ex0)
						.Select(EmailList._ex1)
						.Select(EmailList._ex2)
						.Select(EmailList._ex3)
						.Select(EmailList._ex4)
						.Select(EmailList._ex5)
						.Select(EmailList._ex6)
						.Select(EmailList._ex7)
						.Select(EmailList._ex8)
						.Where(where).Order(order).ToList<EmailList>();
				} else {
					list = new SQL().Database(dbkey).From(EmailList._).Select(fieldList).Where(where).Order(order).ToList<EmailList>();
				}
				return list;
			});
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		/// <returns>返回实体记录集</returns>
		public static IList<EmailList> SelectListByAll(string dbkey) {
			return SelectListByAll(dbkey, null, "", "");
		}
		/// <summary>
		/// 删除所有记录
		/// </summary>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回实体记录集</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(EmailList._).ToExec()) > 0;
		}
		/// <summary>
		/// 清除查询所有记录的缓存
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.EmailListCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.EmailListCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// 清除所有缓存
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.EmailListCache_(.+?)");
		}
	}
}

