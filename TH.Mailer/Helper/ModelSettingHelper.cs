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
	/// 拨号连接操作类
	///
	/// 修改纪录
	///	 2013-06-03 版本：1.0 系统自动创建此类
	///
	/// </summary>
	public partial class ModelSettingHelper {
		/// <summary>
		/// 拨号连接缓存多少秒 x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// 拨号连接添加记录
		/// </summary>
		/// <param name="modelSetting">拨号连接实体类</param>
		/// <param name="delCache">添加成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>添加是否成功</returns>
		public static bool Insert(ModelSetting modelSetting, string dbkey = "", string[] delCache = null) {
			int obj = new SQL().Database(dbkey).Insert(ModelSetting._)
				.ValueP(ModelSetting._ModelID, modelSetting.ModelID)
				.ValueP(ModelSetting._ModelName, modelSetting.ModelName)
				.ValueP(ModelSetting._UserName, modelSetting.UserName)
				.ValueP(ModelSetting._MPassword, modelSetting.MPassword)
				.ToExec();
			if (delCache.IsNull()) return obj == 1;
			Cache2.Remove("TH.Mailer.ModelSettingCache_", delCache);
			return obj == 1;
		}
		/// <summary>
		/// 拨号连接添加记录
		/// </summary>
		/// <param name="modelSetting">拨号连接实体类</param>
		/// <returns>添加是否成功</returns>
		public static bool Insert(ModelSetting modelSetting, string dbkey) {
			return Insert(modelSetting, dbkey, null);
		}
		/// <summary>
		/// 拨号连接修改记录
		/// </summary>
		/// <param name="modelSetting">拨号连接实体类</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(ModelSetting modelSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			if (modelSetting.ModelID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Update(ModelSetting._)
				.SetP(ModelSetting._ModelName, modelSetting.ModelName)
				.SetP(ModelSetting._UserName, modelSetting.UserName)
				.SetP(ModelSetting._MPassword, modelSetting.MPassword)
				.Where(new Where()
					.AndP(ModelSetting._ModelID, modelSetting.ModelID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.ModelSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// 拨号连接修改记录
		/// </summary>
		/// <param name="modelSetting">拨号连接实体类</param>
		/// <returns>修改是否成功</returns>
		public static bool Update(ModelSetting modelSetting, string dbkey) {
			return Update(modelSetting, dbkey, null, null);
		}
		/// <summary>
		/// 拨号连接修改多条记录
		/// </summary>
		/// <param name="modelIDList">拨号连接编号列表，用“,”号分隔</param>
		/// <param name="modelSetting">拨号连接实体类</param>
		/// <param name="where">修改时附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="delCache">修改成功后清理的CACHE key，支持正则</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时使用ConnString连接</param>
		/// <returns>修改是否成功</returns>
		public static bool UpdateByIDList(IEnumerable<int> modelIDList,  ModelSetting modelSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(ModelSetting._)
				.SetP(ModelSetting._ModelName, modelSetting.ModelName)
				.SetP(ModelSetting._UserName, modelSetting.UserName)
				.SetP(ModelSetting._MPassword, modelSetting.MPassword)
				.Where(new Where()
					.And(ModelSetting._ModelID, "(" + modelIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.ModelSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// 拨号连接修改多条记录
		/// </summary>
		/// <param name="modelIDList">拨号连接编号列表，用“,”号分隔</param>
		/// <param name="modelSetting">拨号连接实体类</param>
		/// <returns>修改是否成功</returns>
		public static bool UpdateByIDList(IEnumerable<int> modelIDList,  ModelSetting modelSetting, string dbkey) {
			return UpdateByIDList(modelIDList,  modelSetting, dbkey, null, null);
		}
		/// <summary>
		/// 拨号连接按主键查询，返回数据的实体类
		/// </summary>
		/// <param name="modelID">拨号连接编号</param>
		/// <param name="where">附加条件，统一的前面要加链接符（and、or等等）</param>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回单条记录的实体类</returns>
		public static ModelSetting SelectByID(int modelID,  string dbkey = "", Where where = null) {
			string cacheNameKey = "TH.Mailer.ModelSettingCache_SelectByID_{0}".FormatWith(modelID + "_" +  "_" + where);
			return Cache2.Get<ModelSetting>(cacheNameKey, cacheSeconds, () => {
				ModelSetting obj = new SQL().Database(dbkey).From(ModelSetting._)
					.Select(ModelSetting._ModelID)
					.Select(ModelSetting._ModelName)
					.Select(ModelSetting._UserName)
					.Select(ModelSetting._MPassword)
					.Where(new Where()
						.AndP(ModelSetting._ModelID, modelID, Operator.Equal)
					).Where(where).ToEntity<ModelSetting>();
				return obj;
			});
		}
		/// <summary>
		/// 拨号连接按主键查询，返回数据的实体类
		/// </summary>
		/// <param name="modelID">拨号连接编号</param>
		/// <returns>返回单条记录的实体类</returns>
		public static ModelSetting SelectByID(int modelID, string dbkey) {
			return SelectByID(modelID,  dbkey, null);
		}
		/// <summary>
		/// 清除拨号连接按主键查询的缓存
		/// </summary>
		public static void ClearCacheSelectByID(int modelID,  Where where = null) {
			string cacheName = "TH.Mailer.ModelSettingCache_SelectByID_{0}";
			string cacheNameKey = string.Format(cacheName, modelID + "_" +  "_" + where);
			Cache2.Remove(cacheNameKey);
		}
		/// <summary>
		/// 拨号连接删除所有记录
		/// </summary>
		/// <param name="dbkey">存在数据库连接池中的连接key，为空时随机取连接key</param>
		/// <returns>返回实体记录集</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(ModelSetting._).ToExec()) > 0;
		}
		/// <summary>
		/// 清除拨号连接查询所有记录的缓存
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.ModelSettingCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.ModelSettingCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// 清除拨号连接所有缓存
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.ModelSettingCache_(.+?)");
		}
	}
}

