USE [master]
GO
/****** Object:  Database [Mailer]    Script Date: 06/18/2013 17:26:33 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Mailer')
BEGIN
CREATE DATABASE [Mailer] ON  PRIMARY 
( NAME = N'Mailer', FILENAME = N'd:\db\Mailer.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Mailer_log', FILENAME = N'd:\db\Mailer_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mailer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mailer] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Mailer] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Mailer] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Mailer] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Mailer] SET ARITHABORT OFF
GO
ALTER DATABASE [Mailer] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Mailer] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Mailer] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Mailer] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Mailer] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Mailer] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Mailer] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Mailer] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Mailer] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Mailer] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Mailer] SET  DISABLE_BROKER
GO
ALTER DATABASE [Mailer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Mailer] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Mailer] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Mailer] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Mailer] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Mailer] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Mailer] SET  READ_WRITE
GO
ALTER DATABASE [Mailer] SET RECOVERY FULL
GO
ALTER DATABASE [Mailer] SET  MULTI_USER
GO
ALTER DATABASE [Mailer] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Mailer] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Mailer', N'ON'
GO
USE [Mailer]
GO
/****** Object:  Table [dbo].[EmailList]    Script Date: 06/18/2013 17:26:34 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__EmailList__Email__014935CB]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF__EmailList__Email__014935CB]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EmailList_NickName]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF_EmailList_NickName]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__EmailList__Statu__023D5A04]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF__EmailList__Statu__023D5A04]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EmailList_LastError]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF_EmailList_LastError]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EmailList_LastUseSMTP]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF_EmailList_LastUseSMTP]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EmailList_SendCount]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF_EmailList_SendCount]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__EmailList__Creat__0519C6AF]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF__EmailList__Creat__0519C6AF]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EmailList_ex00]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF_EmailList_ex00]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EmailList_ex01]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF_EmailList_ex01]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EmailList_ex02]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF_EmailList_ex02]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EmailList_ex03]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF_EmailList_ex03]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EmailList_ex04]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF_EmailList_ex04]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EmailList_ex05]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF_EmailList_ex05]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EmailList_ex06]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF_EmailList_ex06]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EmailList_ex07]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF_EmailList_ex07]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EmailList_ex08]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EmailList] DROP CONSTRAINT [DF_EmailList_ex08]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailList]') AND type in (N'U'))
DROP TABLE [dbo].[EmailList]
GO
/****** Object:  Table [dbo].[HtmlTemplate]    Script Date: 06/18/2013 17:26:34 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__HtmlTempl__Subje__09DE7BCC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[HtmlTemplate] DROP CONSTRAINT [DF__HtmlTempl__Subje__09DE7BCC]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__HtmlTempla__Body__0AD2A005]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[HtmlTemplate] DROP CONSTRAINT [DF__HtmlTempla__Body__0AD2A005]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_HtmlTemplate_ShowName]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[HtmlTemplate] DROP CONSTRAINT [DF_HtmlTemplate_ShowName]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__HtmlTempl__IsHTM__0BC6C43E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[HtmlTemplate] DROP CONSTRAINT [DF__HtmlTempl__IsHTM__0BC6C43E]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__HtmlTempl__Statu__0CBAE877]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[HtmlTemplate] DROP CONSTRAINT [DF__HtmlTempl__Statu__0CBAE877]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__HtmlTempl__Creat__0DAF0CB0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[HtmlTemplate] DROP CONSTRAINT [DF__HtmlTempl__Creat__0DAF0CB0]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HtmlTemplate]') AND type in (N'U'))
DROP TABLE [dbo].[HtmlTemplate]
GO
/****** Object:  Table [dbo].[IpHistory]    Script Date: 06/18/2013 17:26:33 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IpHistory_IP]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IpHistory] DROP CONSTRAINT [DF_IpHistory_IP]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IpHistory_CreateTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IpHistory] DROP CONSTRAINT [DF_IpHistory_CreateTime]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IpHistory]') AND type in (N'U'))
DROP TABLE [dbo].[IpHistory]
GO
/****** Object:  Table [dbo].[IpSetting]    Script Date: 06/18/2013 17:26:33 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IpSetting_WebName]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IpSetting] DROP CONSTRAINT [DF_IpSetting_WebName]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IpSetting_IPUrl]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IpSetting] DROP CONSTRAINT [DF_IpSetting_IPUrl]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IpSetting_IPRegex]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IpSetting] DROP CONSTRAINT [DF_IpSetting_IPRegex]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IpSetting_DataEncode]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IpSetting] DROP CONSTRAINT [DF_IpSetting_DataEncode]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IpSetting]') AND type in (N'U'))
DROP TABLE [dbo].[IpSetting]
GO
/****** Object:  Table [dbo].[ModelSetting]    Script Date: 06/18/2013 17:26:33 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ModelSetting_ModelID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ModelSetting] DROP CONSTRAINT [DF_ModelSetting_ModelID]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ModelSetting_UserName]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ModelSetting] DROP CONSTRAINT [DF_ModelSetting_UserName]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Table_1_RPassword]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ModelSetting] DROP CONSTRAINT [DF_Table_1_RPassword]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ModelSetting]') AND type in (N'U'))
DROP TABLE [dbo].[ModelSetting]
GO
/****** Object:  Table [dbo].[RouteSetting]    Script Date: 06/18/2013 17:26:33 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_RouteSetting_RouteID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[RouteSetting] DROP CONSTRAINT [DF_RouteSetting_RouteID]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_RouteList_RouteUrl]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[RouteSetting] DROP CONSTRAINT [DF_RouteList_RouteUrl]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_RouteList_UserName]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[RouteSetting] DROP CONSTRAINT [DF_RouteList_UserName]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_RouteList_Password]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[RouteSetting] DROP CONSTRAINT [DF_RouteList_Password]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_RouteSetting_RouteConnect]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[RouteSetting] DROP CONSTRAINT [DF_RouteSetting_RouteConnect]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_RouteSetting_RouteDisConnect]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[RouteSetting] DROP CONSTRAINT [DF_RouteSetting_RouteDisConnect]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_RouteSetting_RouteMethod]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[RouteSetting] DROP CONSTRAINT [DF_RouteSetting_RouteMethod]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RouteSetting]') AND type in (N'U'))
DROP TABLE [dbo].[RouteSetting]
GO
/****** Object:  Table [dbo].[SendSetting]    Script Date: 06/18/2013 17:26:33 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SendSetting_SettingID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SendSetting] DROP CONSTRAINT [DF_SendSetting_SettingID]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SendSetting_TemplateID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SendSetting] DROP CONSTRAINT [DF_SendSetting_TemplateID]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SendSetting_ConnectType]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SendSetting] DROP CONSTRAINT [DF_SendSetting_ConnectType]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SendSetting_SendInterval]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SendSetting] DROP CONSTRAINT [DF_SendSetting_SendInterval]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SendSetting_IPInterval]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SendSetting] DROP CONSTRAINT [DF_SendSetting_IPInterval]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SendSetting_SmtpInterval]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SendSetting] DROP CONSTRAINT [DF_SendSetting_SmtpInterval]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SendSetting_DeleteInterval]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SendSetting] DROP CONSTRAINT [DF_SendSetting_DeleteInterval]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SendSetting_MaxRetryCount]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SendSetting] DROP CONSTRAINT [DF_SendSetting_MaxRetryCount]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SendSetting_MaxRetryCount1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SendSetting] DROP CONSTRAINT [DF_SendSetting_MaxRetryCount1]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SendSetting_Status]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SendSetting] DROP CONSTRAINT [DF_SendSetting_Status]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SendSetting]') AND type in (N'U'))
DROP TABLE [dbo].[SendSetting]
GO
/****** Object:  Table [dbo].[SmtpList]    Script Date: 06/18/2013 17:26:33 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__SmtpList__SmtpSe__1273C1CD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SmtpList] DROP CONSTRAINT [DF__SmtpList__SmtpSe__1273C1CD]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__SmtpList__SmtpPo__1367E606]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SmtpList] DROP CONSTRAINT [DF__SmtpList__SmtpPo__1367E606]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__SmtpList__UserNa__145C0A3F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SmtpList] DROP CONSTRAINT [DF__SmtpList__UserNa__145C0A3F]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__SmtpList__Passwo__15502E78]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SmtpList] DROP CONSTRAINT [DF__SmtpList__Passwo__15502E78]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__SmtpList__SSL__164452B1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SmtpList] DROP CONSTRAINT [DF__SmtpList__SSL__164452B1]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__SmtpList__Status__173876EA]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SmtpList] DROP CONSTRAINT [DF__SmtpList__Status__173876EA]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__SmtpList__Sends__182C9B23]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SmtpList] DROP CONSTRAINT [DF__SmtpList__Sends__182C9B23]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__SmtpList__SendFa__1920BF5C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SmtpList] DROP CONSTRAINT [DF__SmtpList__SendFa__1920BF5C]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__SmtpList__Create__1A14E395]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SmtpList] DROP CONSTRAINT [DF__SmtpList__Create__1A14E395]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SmtpList]') AND type in (N'U'))
DROP TABLE [dbo].[SmtpList]
GO
/****** Object:  Table [dbo].[TianYiSetting]    Script Date: 06/18/2013 17:26:33 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Table_1_ModelID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TianYiSetting] DROP CONSTRAINT [DF_Table_1_ModelID]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TanYiSetting_TanYiExePath]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TianYiSetting] DROP CONSTRAINT [DF_TanYiSetting_TanYiExePath]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TianYiSetting]') AND type in (N'U'))
DROP TABLE [dbo].[TianYiSetting]
GO
/****** Object:  Table [dbo].[TianYiSetting]    Script Date: 06/18/2013 17:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TianYiSetting]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TianYiSetting](
	[TianYiID] [int] NOT NULL CONSTRAINT [DF_Table_1_ModelID]  DEFAULT ((1)),
	[TianYiExePath] [varchar](200) NOT NULL CONSTRAINT [DF_TanYiSetting_TanYiExePath]  DEFAULT (''),
 CONSTRAINT [PK_TanYiSetting] PRIMARY KEY CLUSTERED 
(
	[TianYiID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'TianYiSetting', N'COLUMN',N'TianYiID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'天翼连接设置编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TianYiSetting', @level2type=N'COLUMN',@level2name=N'TianYiID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'TianYiSetting', N'COLUMN',N'TianYiExePath'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'天翼主程序路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TianYiSetting', @level2type=N'COLUMN',@level2name=N'TianYiExePath'
GO
/****** Object:  Table [dbo].[SmtpList]    Script Date: 06/18/2013 17:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SmtpList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SmtpList](
	[SmtpServer] [varchar](50) NOT NULL CONSTRAINT [DF__SmtpList__SmtpSe__1273C1CD]  DEFAULT (''),
	[SmtpPort] [int] NOT NULL CONSTRAINT [DF__SmtpList__SmtpPo__1367E606]  DEFAULT ((25)),
	[UserName] [varchar](50) NOT NULL CONSTRAINT [DF__SmtpList__UserNa__145C0A3F]  DEFAULT (''),
	[SPassword] [varchar](50) NOT NULL CONSTRAINT [DF__SmtpList__Passwo__15502E78]  DEFAULT (''),
	[SSL] [bit] NOT NULL CONSTRAINT [DF__SmtpList__SSL__164452B1]  DEFAULT ((0)),
	[Status] [int] NOT NULL CONSTRAINT [DF__SmtpList__Status__173876EA]  DEFAULT ((0)),
	[Sends] [int] NOT NULL CONSTRAINT [DF__SmtpList__Sends__182C9B23]  DEFAULT ((0)),
	[SendFails] [int] NOT NULL CONSTRAINT [DF__SmtpList__SendFa__1920BF5C]  DEFAULT ((0)),
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF__SmtpList__Create__1A14E395]  DEFAULT (getdate()),
 CONSTRAINT [PK_SmtpList] PRIMARY KEY CLUSTERED 
(
	[SmtpServer] ASC,
	[SmtpPort] ASC,
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SmtpList', N'COLUMN',N'SmtpServer'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SMTP服务器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmtpList', @level2type=N'COLUMN',@level2name=N'SmtpServer'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SmtpList', N'COLUMN',N'SmtpPort'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SMTP端口' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmtpList', @level2type=N'COLUMN',@level2name=N'SmtpPort'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SmtpList', N'COLUMN',N'UserName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmtpList', @level2type=N'COLUMN',@level2name=N'UserName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SmtpList', N'COLUMN',N'SPassword'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmtpList', @level2type=N'COLUMN',@level2name=N'SPassword'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SmtpList', N'COLUMN',N'SSL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否支持SSL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmtpList', @level2type=N'COLUMN',@level2name=N'SSL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SmtpList', N'COLUMN',N'Status'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 0可用 1不可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmtpList', @level2type=N'COLUMN',@level2name=N'Status'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SmtpList', N'COLUMN',N'Sends'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmtpList', @level2type=N'COLUMN',@level2name=N'Sends'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SmtpList', N'COLUMN',N'SendFails'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送失败次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmtpList', @level2type=N'COLUMN',@level2name=N'SendFails'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SmtpList', N'COLUMN',N'CreateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmtpList', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
/****** Object:  Table [dbo].[SendSetting]    Script Date: 06/18/2013 17:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SendSetting]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SendSetting](
	[SettingID] [int] NOT NULL CONSTRAINT [DF_SendSetting_SettingID]  DEFAULT ((1)),
	[TemplateID] [bigint] NOT NULL CONSTRAINT [DF_SendSetting_TemplateID]  DEFAULT ((0)),
	[ConnectType] [int] NOT NULL CONSTRAINT [DF_SendSetting_ConnectType]  DEFAULT ((0)),
	[SendInterval] [int] NOT NULL CONSTRAINT [DF_SendSetting_SendInterval]  DEFAULT ((0)),
	[IPInterval] [int] NOT NULL CONSTRAINT [DF_SendSetting_IPInterval]  DEFAULT ((0)),
	[SmtpInterval] [int] NOT NULL CONSTRAINT [DF_SendSetting_SmtpInterval]  DEFAULT ((0)),
	[DeleteInterval] [int] NOT NULL CONSTRAINT [DF_SendSetting_DeleteInterval]  DEFAULT ((60)),
	[MaxRetryCount] [int] NOT NULL CONSTRAINT [DF_SendSetting_MaxRetryCount]  DEFAULT ((10)),
	[SendRetryCount] [int] NOT NULL CONSTRAINT [DF_SendSetting_MaxRetryCount1]  DEFAULT ((10)),
	[Status] [int] NOT NULL CONSTRAINT [DF_SendSetting_Status]  DEFAULT ((0)),
 CONSTRAINT [PK_SendSetting] PRIMARY KEY CLUSTERED 
(
	[SettingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SendSetting', N'COLUMN',N'SettingID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设置编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SendSetting', @level2type=N'COLUMN',@level2name=N'SettingID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SendSetting', N'COLUMN',N'TemplateID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送主题编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SendSetting', @level2type=N'COLUMN',@level2name=N'TemplateID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SendSetting', N'COLUMN',N'ConnectType'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'连网类型 0使用路由连接 1使用拨号连接' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SendSetting', @level2type=N'COLUMN',@level2name=N'ConnectType'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SendSetting', N'COLUMN',N'SendInterval'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送邮件时间间隔(毫秒)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SendSetting', @level2type=N'COLUMN',@level2name=N'SendInterval'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SendSetting', N'COLUMN',N'IPInterval'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送多少封邮件后更换IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SendSetting', @level2type=N'COLUMN',@level2name=N'IPInterval'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SendSetting', N'COLUMN',N'SmtpInterval'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送多少封邮件后更换SMTP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SendSetting', @level2type=N'COLUMN',@level2name=N'SmtpInterval'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SendSetting', N'COLUMN',N'DeleteInterval'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'清理多少分钟之前的历史IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SendSetting', @level2type=N'COLUMN',@level2name=N'DeleteInterval'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SendSetting', N'COLUMN',N'MaxRetryCount'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最多重试次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SendSetting', @level2type=N'COLUMN',@level2name=N'MaxRetryCount'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SendSetting', N'COLUMN',N'SendRetryCount'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送邮件失败重试次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SendSetting', @level2type=N'COLUMN',@level2name=N'SendRetryCount'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'SendSetting', N'COLUMN',N'Status'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态  0等待发送 1正在发送 2已发送完成' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SendSetting', @level2type=N'COLUMN',@level2name=N'Status'
GO
/****** Object:  Table [dbo].[RouteSetting]    Script Date: 06/18/2013 17:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RouteSetting]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RouteSetting](
	[RouteID] [int] NOT NULL CONSTRAINT [DF_RouteSetting_RouteID]  DEFAULT ((1)),
	[RouteIP] [varchar](200) NOT NULL CONSTRAINT [DF_RouteList_RouteUrl]  DEFAULT (''),
	[UserName] [varchar](50) NOT NULL CONSTRAINT [DF_RouteList_UserName]  DEFAULT (''),
	[RPassword] [varchar](50) NOT NULL CONSTRAINT [DF_RouteList_Password]  DEFAULT (''),
	[RouteConnect] [varchar](200) NOT NULL CONSTRAINT [DF_RouteSetting_RouteConnect]  DEFAULT (''),
	[RouteDisConnect] [varchar](200) NOT NULL CONSTRAINT [DF_RouteSetting_RouteDisConnect]  DEFAULT (''),
	[RouteMethod] [varchar](10) NOT NULL CONSTRAINT [DF_RouteSetting_RouteMethod]  DEFAULT ('POST'),
 CONSTRAINT [PK_RouteList_1] PRIMARY KEY CLUSTERED 
(
	[RouteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'RouteSetting', N'COLUMN',N'RouteID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路由编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RouteSetting', @level2type=N'COLUMN',@level2name=N'RouteID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'RouteSetting', N'COLUMN',N'RouteIP'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路由地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RouteSetting', @level2type=N'COLUMN',@level2name=N'RouteIP'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'RouteSetting', N'COLUMN',N'UserName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RouteSetting', @level2type=N'COLUMN',@level2name=N'UserName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'RouteSetting', N'COLUMN',N'RPassword'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RouteSetting', @level2type=N'COLUMN',@level2name=N'RPassword'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'RouteSetting', N'COLUMN',N'RouteConnect'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'连接参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RouteSetting', @level2type=N'COLUMN',@level2name=N'RouteConnect'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'RouteSetting', N'COLUMN',N'RouteDisConnect'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'断开连接参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RouteSetting', @level2type=N'COLUMN',@level2name=N'RouteDisConnect'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'RouteSetting', N'COLUMN',N'RouteMethod'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求方式 POST GET' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RouteSetting', @level2type=N'COLUMN',@level2name=N'RouteMethod'
GO
/****** Object:  Table [dbo].[ModelSetting]    Script Date: 06/18/2013 17:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ModelSetting]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ModelSetting](
	[ModelID] [int] NOT NULL CONSTRAINT [DF_ModelSetting_ModelID]  DEFAULT ((1)),
	[ModelName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL CONSTRAINT [DF_ModelSetting_UserName]  DEFAULT (''),
	[MPassword] [varchar](50) NOT NULL CONSTRAINT [DF_Table_1_RPassword]  DEFAULT (''),
 CONSTRAINT [PK_ModelSetting] PRIMARY KEY CLUSTERED 
(
	[ModelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ModelSetting', N'COLUMN',N'ModelID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拨号连接编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ModelSetting', @level2type=N'COLUMN',@level2name=N'ModelID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ModelSetting', N'COLUMN',N'ModelName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拨号连接名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ModelSetting', @level2type=N'COLUMN',@level2name=N'ModelName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ModelSetting', N'COLUMN',N'UserName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ModelSetting', @level2type=N'COLUMN',@level2name=N'UserName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ModelSetting', N'COLUMN',N'MPassword'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ModelSetting', @level2type=N'COLUMN',@level2name=N'MPassword'
GO
/****** Object:  Table [dbo].[IpSetting]    Script Date: 06/18/2013 17:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IpSetting]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[IpSetting](
	[IPCID] [bigint] IDENTITY(1,1) NOT NULL,
	[WebName] [varchar](50) NOT NULL CONSTRAINT [DF_IpSetting_WebName]  DEFAULT (''),
	[IPUrl] [varchar](200) NOT NULL CONSTRAINT [DF_IpSetting_IPUrl]  DEFAULT (''),
	[IPRegex] [varchar](200) NOT NULL CONSTRAINT [DF_IpSetting_IPRegex]  DEFAULT (''),
	[DataEncode] [varchar](10) NOT NULL CONSTRAINT [DF_IpSetting_DataEncode]  DEFAULT (''),
 CONSTRAINT [PK_IpSetting] PRIMARY KEY CLUSTERED 
(
	[IPCID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'IpSetting', N'COLUMN',N'IPCID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'获取IP配置编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IpSetting', @level2type=N'COLUMN',@level2name=N'IPCID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'IpSetting', N'COLUMN',N'WebName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网址名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IpSetting', @level2type=N'COLUMN',@level2name=N'WebName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'IpSetting', N'COLUMN',N'IPUrl'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'获取IP的网址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IpSetting', @level2type=N'COLUMN',@level2name=N'IPUrl'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'IpSetting', N'COLUMN',N'IPRegex'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'获取IP的正则' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IpSetting', @level2type=N'COLUMN',@level2name=N'IPRegex'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'IpSetting', N'COLUMN',N'DataEncode'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IpSetting', @level2type=N'COLUMN',@level2name=N'DataEncode'
GO
/****** Object:  Table [dbo].[IpHistory]    Script Date: 06/18/2013 17:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IpHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[IpHistory](
	[IP] [varchar](50) NOT NULL CONSTRAINT [DF_IpHistory_IP]  DEFAULT (''),
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_IpHistory_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_IpHistory_1] PRIMARY KEY CLUSTERED 
(
	[IP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'IpHistory', N'COLUMN',N'IP'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IpHistory', @level2type=N'COLUMN',@level2name=N'IP'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'IpHistory', N'COLUMN',N'CreateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IpHistory', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
/****** Object:  Table [dbo].[HtmlTemplate]    Script Date: 06/18/2013 17:26:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HtmlTemplate]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HtmlTemplate](
	[TemplateID] [bigint] IDENTITY(1,1) NOT NULL,
	[Subject] [varchar](200) NOT NULL CONSTRAINT [DF__HtmlTempl__Subje__09DE7BCC]  DEFAULT (''),
	[Body] [nvarchar](max) NOT NULL CONSTRAINT [DF__HtmlTempla__Body__0AD2A005]  DEFAULT (''),
	[ShowName] [varchar](100) NOT NULL CONSTRAINT [DF_HtmlTemplate_ShowName]  DEFAULT (''),
	[IsHTML] [bit] NOT NULL CONSTRAINT [DF__HtmlTempl__IsHTM__0BC6C43E]  DEFAULT ((1)),
	[Status] [int] NOT NULL CONSTRAINT [DF__HtmlTempl__Statu__0CBAE877]  DEFAULT ((0)),
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF__HtmlTempl__Creat__0DAF0CB0]  DEFAULT (getdate()),
 CONSTRAINT [PK_HtmlTemplate] PRIMARY KEY CLUSTERED 
(
	[TemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'HtmlTemplate', N'COLUMN',N'TemplateID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮件模版编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlTemplate', @level2type=N'COLUMN',@level2name=N'TemplateID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'HtmlTemplate', N'COLUMN',N'Subject'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlTemplate', @level2type=N'COLUMN',@level2name=N'Subject'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'HtmlTemplate', N'COLUMN',N'Body'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlTemplate', @level2type=N'COLUMN',@level2name=N'Body'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'HtmlTemplate', N'COLUMN',N'ShowName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示发件人名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlTemplate', @level2type=N'COLUMN',@level2name=N'ShowName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'HtmlTemplate', N'COLUMN',N'IsHTML'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否使用HTML发送' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlTemplate', @level2type=N'COLUMN',@level2name=N'IsHTML'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'HtmlTemplate', N'COLUMN',N'Status'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 0可用 1不可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlTemplate', @level2type=N'COLUMN',@level2name=N'Status'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'HtmlTemplate', N'COLUMN',N'CreateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlTemplate', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
/****** Object:  Table [dbo].[EmailList]    Script Date: 06/18/2013 17:26:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmailList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EmailList](
	[EmailAddress] [varchar](50) NOT NULL CONSTRAINT [DF__EmailList__Email__014935CB]  DEFAULT (''),
	[NickName] [varchar](50) NOT NULL CONSTRAINT [DF_EmailList_NickName]  DEFAULT (''),
	[LastSendStatus] [int] NOT NULL CONSTRAINT [DF__EmailList__Statu__023D5A04]  DEFAULT ((0)),
	[LastSendError] [varchar](1000) NOT NULL CONSTRAINT [DF_EmailList_LastError]  DEFAULT (''),
	[LastSendTime] [datetime] NULL,
	[LastSendSmtp] [varchar](100) NOT NULL CONSTRAINT [DF_EmailList_LastUseSMTP]  DEFAULT (''),
	[SendCount] [int] NOT NULL CONSTRAINT [DF_EmailList_SendCount]  DEFAULT ((0)),
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF__EmailList__Creat__0519C6AF]  DEFAULT (getdate()),
	[ex0] [varchar](200) NOT NULL CONSTRAINT [DF_EmailList_ex00]  DEFAULT (''),
	[ex1] [varchar](200) NOT NULL CONSTRAINT [DF_EmailList_ex01]  DEFAULT (''),
	[ex2] [varchar](200) NOT NULL CONSTRAINT [DF_EmailList_ex02]  DEFAULT (''),
	[ex3] [varchar](200) NOT NULL CONSTRAINT [DF_EmailList_ex03]  DEFAULT (''),
	[ex4] [varchar](200) NOT NULL CONSTRAINT [DF_EmailList_ex04]  DEFAULT (''),
	[ex5] [varchar](200) NOT NULL CONSTRAINT [DF_EmailList_ex05]  DEFAULT (''),
	[ex6] [varchar](200) NOT NULL CONSTRAINT [DF_EmailList_ex06]  DEFAULT (''),
	[ex7] [varchar](200) NOT NULL CONSTRAINT [DF_EmailList_ex07]  DEFAULT (''),
	[ex8] [varchar](200) NOT NULL CONSTRAINT [DF_EmailList_ex08]  DEFAULT (''),
 CONSTRAINT [PK__EmailLis__A9D105357F60ED59] PRIMARY KEY CLUSTERED 
(
	[EmailAddress] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'EmailList', N'COLUMN',N'EmailAddress'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送的Email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmailList', @level2type=N'COLUMN',@level2name=N'EmailAddress'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'EmailList', N'COLUMN',N'NickName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收件人昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmailList', @level2type=N'COLUMN',@level2name=N'NickName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'EmailList', N'COLUMN',N'LastSendStatus'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 0等待发送 1发送成功 2发送失败' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmailList', @level2type=N'COLUMN',@level2name=N'LastSendStatus'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'EmailList', N'COLUMN',N'LastSendError'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次出错日志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmailList', @level2type=N'COLUMN',@level2name=N'LastSendError'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'EmailList', N'COLUMN',N'LastSendTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次发送时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmailList', @level2type=N'COLUMN',@level2name=N'LastSendTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'EmailList', N'COLUMN',N'LastSendSmtp'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次使用SMTP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmailList', @level2type=N'COLUMN',@level2name=N'LastSendSmtp'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'EmailList', N'COLUMN',N'SendCount'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmailList', @level2type=N'COLUMN',@level2name=N'SendCount'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'EmailList', N'COLUMN',N'CreateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmailList', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
