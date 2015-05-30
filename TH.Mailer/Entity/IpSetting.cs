//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
	/// <summary>
	/// 获取IP配置实体类
	///
	/// 修改纪录
	///	 2013-06-03 版本：1.0 系统自动创建此类
	///
	/// </summary>
	[Serializable]
	[EntityInfo("获取IP配置")]
	public partial class IpSetting {
		/// <summary>
		/// 获取IP配置
		/// </summary>
		public static readonly string _ = "IpSetting";

		/// <summary>
		/// 获取IP配置编号
		/// </summary>
		public static readonly string _IPCID = "IPCID";
		private Int64? iPCID = null;
		/// <summary>
		/// 获取IP配置编号
		/// </summary>
		[EntityInfo("获取IP配置编号")]
		public new Int64? IPCID { get { return iPCID; } set { iPCID = value; } }

		/// <summary>
		/// 网址名称
		/// </summary>
		public static readonly string _WebName = "WebName";
		private string webName = null;
		/// <summary>
		/// 网址名称
		/// </summary>
		[EntityInfo("网址名称")]
		public new string WebName { get { return webName; } set { webName = value; } }

		/// <summary>
		/// 获取IP的网址
		/// </summary>
		public static readonly string _IPUrl = "IPUrl";
		private string iPUrl = null;
		/// <summary>
		/// 获取IP的网址
		/// </summary>
		[EntityInfo("获取IP的网址")]
		public new string IPUrl { get { return iPUrl; } set { iPUrl = value; } }

		/// <summary>
		/// 获取IP的正则
		/// </summary>
		public static readonly string _IPRegex = "IPRegex";
		private string iPRegex = null;
		/// <summary>
		/// 获取IP的正则
		/// </summary>
		[EntityInfo("获取IP的正则")]
		public new string IPRegex { get { return iPRegex; } set { iPRegex = value; } }

		/// <summary>
		/// 使用编码
		/// </summary>
		public static readonly string _DataEncode = "DataEncode";
		private string dataEncode = null;
		/// <summary>
		/// 使用编码
		/// </summary>
		[EntityInfo("使用编码")]
		public new string DataEncode { get { return dataEncode; } set { dataEncode = value; } }
	}
}



