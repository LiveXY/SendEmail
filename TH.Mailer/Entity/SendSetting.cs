//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
	/// <summary>
	/// 设置实体类
	///
	/// 修改纪录
	///	 2013-06-03 版本：1.0 系统自动创建此类
	///
	/// </summary>
	[Serializable]
	[EntityInfo("设置")]
	public partial class SendSetting {
		/// <summary>
		/// 设置
		/// </summary>
		public static readonly string _ = "SendSetting";

		/// <summary>
		/// 设置编号
		/// </summary>
		public static readonly string _SettingID = "SettingID";
		private int? settingID = null;
		/// <summary>
		/// 设置编号
		/// </summary>
		[EntityInfo("设置编号")]
		public new int? SettingID { get { return settingID; } set { settingID = value; } }

		/// <summary>
		/// 发送主题编号
		/// </summary>
		public static readonly string _TemplateID = "TemplateID";
		private Int64? templateID = null;
		/// <summary>
		/// 发送主题编号
		/// </summary>
		[EntityInfo("发送主题编号")]
		public new Int64? TemplateID { get { return templateID; } set { templateID = value; } }

		/// <summary>
		/// 连网类型 0使用路由连接 1使用拨号连接
		/// </summary>
		public static readonly string _ConnectType = "ConnectType";
		private int? connectType = null;
		/// <summary>
		/// 连网类型 0使用路由连接 1使用拨号连接
		/// </summary>
		[EntityInfo("连网类型 0使用路由连接 1使用拨号连接")]
		public new int? ConnectType { get { return connectType; } set { connectType = value; } }

		/// <summary>
		/// 发送邮件时间间隔(毫秒)
		/// </summary>
		public static readonly string _SendInterval = "SendInterval";
		private int? sendInterval = null;
		/// <summary>
		/// 发送邮件时间间隔(毫秒)
		/// </summary>
		[EntityInfo("发送邮件时间间隔(毫秒)")]
		public new int? SendInterval { get { return sendInterval; } set { sendInterval = value; } }

		/// <summary>
		/// 发送多少封邮件后更换IP
		/// </summary>
		public static readonly string _IPInterval = "IPInterval";
		private int? iPInterval = null;
		/// <summary>
		/// 发送多少封邮件后更换IP
		/// </summary>
		[EntityInfo("发送多少封邮件后更换IP")]
		public new int? IPInterval { get { return iPInterval; } set { iPInterval = value; } }

		/// <summary>
		/// 发送多少封邮件后更换SMTP
		/// </summary>
		public static readonly string _SmtpInterval = "SmtpInterval";
		private int? smtpInterval = null;
		/// <summary>
		/// 发送多少封邮件后更换SMTP
		/// </summary>
		[EntityInfo("发送多少封邮件后更换SMTP")]
		public new int? SmtpInterval { get { return smtpInterval; } set { smtpInterval = value; } }

		/// <summary>
		/// 清理多少分钟之前的历史IP
		/// </summary>
		public static readonly string _DeleteInterval = "DeleteInterval";
		private int? deleteInterval = null;
		/// <summary>
		/// 清理多少分钟之前的历史IP
		/// </summary>
		[EntityInfo("清理多少分钟之前的历史IP")]
		public new int? DeleteInterval { get { return deleteInterval; } set { deleteInterval = value; } }

		/// <summary>
		/// 最多重试次数
		/// </summary>
		public static readonly string _MaxRetryCount = "MaxRetryCount";
		private int? maxRetryCount = null;
		/// <summary>
		/// 最多重试次数
		/// </summary>
		[EntityInfo("最多重试次数")]
		public new int? MaxRetryCount { get { return maxRetryCount; } set { maxRetryCount = value; } }

		/// <summary>
		/// 发送邮件失败重试次数
		/// </summary>
		public static readonly string _SendRetryCount = "SendRetryCount";
		private int? sendRetryCount = null;
		/// <summary>
		/// 发送邮件失败重试次数
		/// </summary>
		[EntityInfo("发送邮件失败重试次数")]
		public new int? SendRetryCount { get { return sendRetryCount; } set { sendRetryCount = value; } }

		/// <summary>
		/// 状态  0等待发送 1正在发送 2已发送完成
		/// </summary>
		public static readonly string _Status = "Status";
		private int? status = null;
		/// <summary>
		/// 状态  0等待发送 1正在发送 2已发送完成
		/// </summary>
		[EntityInfo("状态  0等待发送 1正在发送 2已发送完成")]
		public new int? Status { get { return status; } set { status = value; } }
	}
}



