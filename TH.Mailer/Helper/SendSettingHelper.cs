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
	/// 设置操作类
	///
	/// 修改纪录
	///	 2013-06-03 版本：1.0 系统自动创建此类
	///
	/// </summary>
	public partial class SendSettingHelper {
		/// <summary>
		/// 设置缓存多少秒 x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// 设置添加记录
		/// </summary>
		/// <param name="sendSetting">设置实体类</param>
		/// <param name="delCache">添加成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>添加是否成功</returns>
		public static bool Insert(SendSetting sendSetting, string dbkey = "", string[] delCache = null) {
			int obj = new SQL().Database(dbkey).Insert(SendSetting._)
				.ValueP(SendSetting._SettingID, sendSetting.SettingID)
				.ValueP(SendSetting._TemplateID, sendSetting.TemplateID)
				.ValueP(SendSetting._ConnectType, sendSetting.ConnectType)
				.ValueP(SendSetting._SendInterval, sendSetting.SendInterval)
				.ValueP(SendSetting._IPInterval, sendSetting.IPInterval)
				.ValueP(SendSetting._SmtpInterval, sendSetting.SmtpInterval)
				.ValueP(SendSetting._DeleteInterval, sendSetting.DeleteInterval)
				.ValueP(SendSetting._MaxRetryCount, sendSetting.MaxRetryCount)
				.ValueP(SendSetting._SendRetryCount, sendSetting.SendRetryCount)
				.ValueP(SendSetting._Status, sendSetting.Status)
				.ToExec();
			if (delCache.IsNull()) return obj == 1;
			Cache2.Remove("TH.Mailer.SendSettingCache_", delCache);
			return obj == 1;
		}
		/// <summary>
		/// 设置添加记录
		/// </summary>
		/// <param name="sendSetting">设置实体类</param>
		/// <returns>添加是否成功</returns>
		public static bool Insert(SendSetting sendSetting, string dbkey) {
			return Insert(sendSetting, dbkey, null);
		}
		/// <summary>
		/// 设置修改记录
		/// </summary>
		/// <param name="sendSetting">设置实体类</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(SendSetting sendSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			if (sendSetting.SettingID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Update(SendSetting._)
				.SetP(SendSetting._TemplateID, sendSetting.TemplateID)
				.SetP(SendSetting._ConnectType, sendSetting.ConnectType)
				.SetP(SendSetting._SendInterval, sendSetting.SendInterval)
				.SetP(SendSetting._IPInterval, sendSetting.IPInterval)
				.SetP(SendSetting._SmtpInterval, sendSetting.SmtpInterval)
				.SetP(SendSetting._DeleteInterval, sendSetting.DeleteInterval)
				.SetP(SendSetting._MaxRetryCount, sendSetting.MaxRetryCount)
				.SetP(SendSetting._SendRetryCount, sendSetting.SendRetryCount)
				.SetP(SendSetting._Status, sendSetting.Status)
				.Where(new Where()
					.AndP(SendSetting._SettingID, sendSetting.SettingID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.SendSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// 设置修改记录
		/// </summary>
		/// <param name="sendSetting">设置实体类</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(SendSetting sendSetting, string dbkey) {
			return Update(sendSetting, dbkey, null, null);
		}
		/// <summary>
		/// 设置修改多条记录
		/// </summary>
		/// <param name="settingIDList">设置编号列表，用“,”号分隔</param>
		/// <param name="sendSetting">设置实体类</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>修改是否成功</returns>
		public static bool UpdateByIDList(IEnumerable<int> settingIDList,  SendSetting sendSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(SendSetting._)
				.SetP(SendSetting._TemplateID, sendSetting.TemplateID)
				.SetP(SendSetting._ConnectType, sendSetting.ConnectType)
				.SetP(SendSetting._SendInterval, sendSetting.SendInterval)
				.SetP(SendSetting._IPInterval, sendSetting.IPInterval)
				.SetP(SendSetting._SmtpInterval, sendSetting.SmtpInterval)
				.SetP(SendSetting._DeleteInterval, sendSetting.DeleteInterval)
				.SetP(SendSetting._MaxRetryCount, sendSetting.MaxRetryCount)
				.SetP(SendSetting._SendRetryCount, sendSetting.SendRetryCount)
				.SetP(SendSetting._Status, sendSetting.Status)
				.Where(new Where()
					.And(SendSetting._SettingID, "(" + settingIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.SendSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// 设置修改多条记录
		/// </summary>
		/// <param name="settingIDList">设置编号列表，用“,”号分隔</param>
		/// <param name="sendSetting">设置实体类</param>
		/// <returns>修改是否成功</returns>
		public static bool UpdateByIDList(IEnumerable<int> settingIDList,  SendSetting sendSetting, string dbkey) {
			return UpdateByIDList(settingIDList,  sendSetting, dbkey, null, null);
		}
		/// <summary>
		/// 设置按主键查询，返回数据的实体类
		/// </summary>
		/// <param name="settingID">设置编号</param>
		/// <param name="where">附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回单条记录的实体类</returns>
		public static SendSetting SelectByID(int settingID,  string dbkey = "", Where where = null) {
			string cacheNameKey = "TH.Mailer.SendSettingCache_SelectByID_{0}".FormatWith(settingID + "_" +  "_" + where);
			return Cache2.Get<SendSetting>(cacheNameKey, cacheSeconds, () => {
				SendSetting obj = new SQL().Database(dbkey).From(SendSetting._)
					.Select(SendSetting._SettingID)
					.Select(SendSetting._TemplateID)
					.Select(SendSetting._ConnectType)
					.Select(SendSetting._SendInterval)
					.Select(SendSetting._IPInterval)
					.Select(SendSetting._SmtpInterval)
					.Select(SendSetting._DeleteInterval)
					.Select(SendSetting._MaxRetryCount)
					.Select(SendSetting._SendRetryCount)
					.Select(SendSetting._Status)
					.Where(new Where()
						.AndP(SendSetting._SettingID, settingID, Operator.Equal)
					).Where(where).ToEntity<SendSetting>();
				return obj;
			});
		}
		/// <summary>
		/// 设置按主键查询，返回数据的实体类
		/// </summary>
		/// <param name="settingID">设置编号</param>
		/// <returns>返回单条记录的实体类</returns>
		public static SendSetting SelectByID(int settingID, string dbkey) {
			return SelectByID(settingID,  dbkey, null);
		}
		/// <summary>
		/// 清除设置按主键查询的缓存
		/// </summary>
		public static void ClearCacheSelectByID(int settingID,  Where where = null) {
			string cacheName = "TH.Mailer.SendSettingCache_SelectByID_{0}";
			string cacheNameKey = string.Format(cacheName, settingID + "_" +  "_" + where);
			Cache2.Remove(cacheNameKey);
		}
		/// <summary>
		/// 设置删除所有记录
		/// </summary>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回实体记录集</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(SendSetting._).ToExec()) > 0;
		}
		/// <summary>
		/// 清除设置查询所有记录的缓存
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.SendSettingCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.SendSettingCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// 清除设置所有缓存
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.SendSettingCache_(.+?)");
		}
	}
}

