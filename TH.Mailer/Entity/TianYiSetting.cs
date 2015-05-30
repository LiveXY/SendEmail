//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
	/// <summary>
	/// 天翼连接设置实体类
	///
	/// 修改纪录
	///	 2013-06-03 版本：1.0 系统自动创建此类
	///
	/// </summary>
	[Serializable]
	[EntityInfo("天翼连接设置")]
	public partial class TianYiSetting {
		/// <summary>
		/// 天翼连接设置
		/// </summary>
		public static readonly string _ = "TianYiSetting";

		/// <summary>
		/// 天翼连接设置编号
		/// </summary>
		public static readonly string _TianYiID = "TianYiID";
		private int? tianYiID = null;
		/// <summary>
		/// 天翼连接设置编号
		/// </summary>
		[EntityInfo("天翼连接设置编号")]
		public new int? TianYiID { get { return tianYiID; } set { tianYiID = value; } }

		/// <summary>
		/// 天翼主程序路径
		/// </summary>
		public static readonly string _TianYiExePath = "TianYiExePath";
		private string tianYiExePath = null;
		/// <summary>
		/// 天翼主程序路径
		/// </summary>
		[EntityInfo("天翼主程序路径")]
		public new string TianYiExePath { get { return tianYiExePath; } set { tianYiExePath = value; } }
	}
}



