USE [master]
GO
/****** Object:  Database [KPTTestDB]    Script Date: 06/15/2017 01:20:43 ******/
CREATE DATABASE [KPTTestDB] ON  PRIMARY 
( NAME = N'KPTTestDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\KPTTestDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KPTTestDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\KPTTestDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [KPTTestDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KPTTestDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KPTTestDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [KPTTestDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [KPTTestDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [KPTTestDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [KPTTestDB] SET ARITHABORT OFF
GO
ALTER DATABASE [KPTTestDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [KPTTestDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [KPTTestDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [KPTTestDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [KPTTestDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [KPTTestDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [KPTTestDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [KPTTestDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [KPTTestDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [KPTTestDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [KPTTestDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [KPTTestDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [KPTTestDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [KPTTestDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [KPTTestDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [KPTTestDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [KPTTestDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [KPTTestDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [KPTTestDB] SET  READ_WRITE
GO
ALTER DATABASE [KPTTestDB] SET RECOVERY FULL
GO
ALTER DATABASE [KPTTestDB] SET  MULTI_USER
GO
ALTER DATABASE [KPTTestDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [KPTTestDB] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'KPTTestDB', N'ON'
GO
USE [KPTTestDB]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 06/15/2017 01:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Id] [int] NOT NULL,
	[gg] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shop]    Script Date: 06/15/2017 01:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Shop](
	[ShopId] [int] IDENTITY(1,1) NOT NULL,
	[ShopName] [nvarchar](400) NOT NULL,
	[ShopType] [varchar](100) NOT NULL,
	[Price] [float] NOT NULL,
	[Commission] [float] NOT NULL,
	[Img] [nvarchar](512) NOT NULL,
	[State] [int] NOT NULL,
	[ShowOnHomePage] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[ShortDescription] [nvarchar](512) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Remark] [nvarchar](1000) NULL,
	[CreateUserId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastDate] [datetime] NOT NULL,
	[ComId] [varchar](10) NOT NULL,
	[BmId] [int] NOT NULL,
 CONSTRAINT [PK_Shop] PRIMARY KEY CLUSTERED 
(
	[ShopId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Shop] ON
INSERT [dbo].[Shop] ([ShopId], [ShopName], [ShopType], [Price], [Commission], [Img], [State], [ShowOnHomePage], [DisplayOrder], [ShortDescription], [Description], [Remark], [CreateUserId], [CreateDate], [LastDate], [ComId], [BmId]) VALUES (11, N'手机+58', N'宽带', 58, 0, N'Uploads\Products\2017\06\14\taocan20M.png', 1, 1, 0, N'手机+58，个人消费58/月，送20M宽带和高清收视', N'•资费名称：手机+58<br/>•带宽：20M<br/>•套餐费用：20元/月<br/>•手机成员（含主号码）：--<br/>•共享话费：--<br/>•赠送语音：--<br/>•初装费：150<br/>使用4G资费并保底58元免费赠送一年宽带和收视，活动到期后收费20元/月', N'1、因地址覆盖问题登原因可能会出现无法安装的情况，敬请谅解，我们后续将尽快解决，感谢您的支持&lt;br /&gt;
2、协议期为一年&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;', 1, CAST(0x0000A792011DF2A7 AS DateTime), CAST(0x0000A792011DF2A7 AS DateTime), N'test', 1)
INSERT [dbo].[Shop] ([ShopId], [ShopName], [ShopType], [Price], [Commission], [Img], [State], [ShowOnHomePage], [DisplayOrder], [ShortDescription], [Description], [Remark], [CreateUserId], [CreateDate], [LastDate], [ComId], [BmId]) VALUES (12, N'新爱家108', N'宽带', 108, 0, N'Uploads\Products\2017\06\14\taocan50M.png', 1, 1, 0, N'新爱家108，个人消费108/月，50M宽带和高清收视', N'•资费名称：新爱家108&lt;br /&gt;
•带宽：50M&lt;br /&gt;
•套餐费用：108元/月&lt;br /&gt;
•手机成员（含主号码）：2&lt;br /&gt;
•共享话费：98&lt;br /&gt;
•赠送语音：成员间共享本地互拨通话2000分钟&lt;br /&gt;
•初装费：150&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;', N'1、基本成员的主资费在加入本融合套餐时不变更主资费；&lt;br /&gt;
2、共享话费通过账单优惠方式实现，可以实时优惠除小额支付，补收外的其他费用，改优惠针对套餐内的所有成员共享；&lt;br /&gt;
3、因地址覆盖问题登原因可能会出现无法安装的情况，敬请谅解，我们后续将尽快解决，感谢您的支持；&lt;br /&gt;
4、赠送语音2000分钟仅限成员间本地通话&lt;br /&gt;
5、协议期为一年&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;', 1, CAST(0x0000A792011E43CF AS DateTime), CAST(0x0000A792011E43CF AS DateTime), N'test', 1)
INSERT [dbo].[Shop] ([ShopId], [ShopName], [ShopType], [Price], [Commission], [Img], [State], [ShowOnHomePage], [DisplayOrder], [ShortDescription], [Description], [Remark], [CreateUserId], [CreateDate], [LastDate], [ComId], [BmId]) VALUES (13, N'新爱家138', N'宽带', 138, 0, N'Uploads\Products\2017\06\14\taocan50M.png', 1, 1, 0, N'新爱家138，个人消费138/月，50M宽带和高清收视', N'&amp;nbsp;•资费名称：新爱家138&lt;br /&gt;
•带宽：50M&lt;br /&gt;
•套餐费用：138元/月&lt;br /&gt;
•手机成员（含主号码）：3&lt;br /&gt;
•共享话费：138&lt;br /&gt;
•赠送语音：成员间共享本地互拨通话2000分钟&lt;br /&gt;
•初装费：150&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;', N'1、基本成员的主资费在加入本融合套餐时不变更主资费；&lt;br /&gt;
2、共享话费通过账单优惠方式实现，可以实时优惠除小额支付，补收外的其他费用，改优惠针对套餐内的所有成员共享；&lt;br /&gt;
3、因地址覆盖问题登原因可能会出现无法安装的情况，敬请谅解，我们后续将尽快解决，感谢您的支持；&lt;br /&gt;
4、赠送语音2000分钟仅限成员间本地通话&lt;br /&gt;
5、协议期为一年&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;', 1, CAST(0x0000A792011E8625 AS DateTime), CAST(0x0000A792011E8625 AS DateTime), N'test', 1)
INSERT [dbo].[Shop] ([ShopId], [ShopName], [ShopType], [Price], [Commission], [Img], [State], [ShowOnHomePage], [DisplayOrder], [ShortDescription], [Description], [Remark], [CreateUserId], [CreateDate], [LastDate], [ComId], [BmId]) VALUES (14, N'新爱家168', N'宽带', 168, 0, N'Uploads\Products\2017\06\14\taocan100M.png', 1, 1, 0, N'新爱家168，个人消费168/月，100M宽带和高清收视', N'•资费名称：新爱家168&lt;br /&gt;
•带宽：100M&lt;br /&gt;
•套餐费用：168元/月&lt;br /&gt;
•手机成员（含主号码）：3&lt;br /&gt;
•共享话费：168&lt;br /&gt;
•赠送语音：成员间共享本地互拨通话2000分钟&lt;br /&gt;
•初装费：150&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;', N'1、基本成员的主资费在加入本融合套餐时不变更主资费；&lt;br /&gt;
2、共享话费通过账单优惠方式实现，可以实时优惠除小额支付，补收外的其他费用，改优惠针对套餐内的所有成员共享；&lt;br /&gt;
3、因地址覆盖问题登原因可能会出现无法安装的情况，敬请谅解，我们后续将尽快解决，感谢您的支持；&lt;br /&gt;
4、赠送语音2000分钟仅限成员间本地通话&lt;br /&gt;
5、协议期为一年&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;', 1, CAST(0x0000A792011ED62F AS DateTime), CAST(0x0000A792011ED62F AS DateTime), N'test', 1)
INSERT [dbo].[Shop] ([ShopId], [ShopName], [ShopType], [Price], [Commission], [Img], [State], [ShowOnHomePage], [DisplayOrder], [ShortDescription], [Description], [Remark], [CreateUserId], [CreateDate], [LastDate], [ComId], [BmId]) VALUES (15, N'爱家138', N'宽带', 138, 0, N'Uploads\Products\2017\06\14\taocan50M.png', 1, 1, 0, N'爱家138，个人消费138/月，送50M宽带和高清收视', N'资费名称：爱家138&lt;br /&gt;
•带宽：50M&lt;br /&gt;
•套餐费用：138元/月&lt;br /&gt;
•手机成员（含主号码）：2&lt;br /&gt;
•共享话费：98&lt;br /&gt;
•赠送语音：成员间共享本地互拨通话2000分钟&lt;br /&gt;
•初装费：100-300&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;', N'1、基本成员的主资费在加入本融合套餐时不变更主资费；&lt;br /&gt;
2、共享话费通过账单优惠方式实现，可以实时优惠除小额支付，补收外的其他费用，改优惠针对套餐内的所有成员共享；&lt;br /&gt;
3、因地址覆盖问题登原因可能会出现无法安装的情况，敬请谅解，我们后续将尽快解决，感谢您的支持；&lt;br /&gt;
4、赠送语音2000分钟仅限成员间本地通话&lt;br /&gt;
5、协议期为一年&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;', 1, CAST(0x0000A792011F4655 AS DateTime), CAST(0x0000A792011F4655 AS DateTime), N'test', 1)
INSERT [dbo].[Shop] ([ShopId], [ShopName], [ShopType], [Price], [Commission], [Img], [State], [ShowOnHomePage], [DisplayOrder], [ShortDescription], [Description], [Remark], [CreateUserId], [CreateDate], [LastDate], [ComId], [BmId]) VALUES (16, N'爱家168', N'宽带', 168, 0, N'Uploads\Products\2017\06\14\taocan50M.png', 1, 1, 0, N'爱家168，个人消费168/月，送50M宽带和高清收视', N'•资费名称：爱家168&lt;br /&gt;
•带宽：50M&lt;br /&gt;
•套餐费用：168元/月&lt;br /&gt;
•手机成员（含主号码）：3&lt;br /&gt;
•共享话费：118&lt;br /&gt;
•赠送语音：成员间共享本地互拨通话2000分钟&lt;br /&gt;
•初装费：100-300&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;', N'1、基本成员的主资费在加入本融合套餐时不变更主资费；&lt;br /&gt;
2、共享话费通过账单优惠方式实现，可以实时优惠除小额支付，补收外的其他费用，改优惠针对套餐内的所有成员共享；&lt;br /&gt;
3、因地址覆盖问题登原因可能会出现无法安装的情况，敬请谅解，我们后续将尽快解决，感谢您的支持；&lt;br /&gt;
4、赠送语音2000分钟仅限成员间本地通话&lt;br /&gt;
5、协议期为一年&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;', 1, CAST(0x0000A792011F9260 AS DateTime), CAST(0x0000A792011F9260 AS DateTime), N'test', 1)
SET IDENTITY_INSERT [dbo].[Shop] OFF
/****** Object:  Table [dbo].[Category]    Script Date: 06/15/2017 01:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](400) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ParentCategoryId] [int] NOT NULL,
	[ShowOnHomePage] [bit] NOT NULL,
	[Published] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[ComId] [varchar](10) NOT NULL,
	[BmId] [int] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description], [ParentCategoryId], [ShowOnHomePage], [Published], [Deleted], [DisplayOrder], [CreatedDate], [UpdatedDate], [ComId], [BmId]) VALUES (1, N'12', N'werwer2232223', 0, 1, 1, 0, 1, CAST(0x0000A791011C7272 AS DateTime), NULL, N'test', 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description], [ParentCategoryId], [ShowOnHomePage], [Published], [Deleted], [DisplayOrder], [CreatedDate], [UpdatedDate], [ComId], [BmId]) VALUES (48, N'124555', N'dddddd', 1, 0, 1, 0, 0, CAST(0x0000A7910127C01F AS DateTime), NULL, N'test', 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description], [ParentCategoryId], [ShowOnHomePage], [Published], [Deleted], [DisplayOrder], [CreatedDate], [UpdatedDate], [ComId], [BmId]) VALUES (49, N'宽带专区', N'宽带专区', 0, 0, 1, 0, 0, CAST(0x0000A791012838CB AS DateTime), NULL, N'test', 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Table [dbo].[Campaign]    Script Date: 06/15/2017 01:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Campaign](
	[CampaignId] [int] IDENTITY(1,1) NOT NULL,
	[CampaignName] [nvarchar](50) NOT NULL,
	[Subject] [nvarchar](512) NULL,
	[Body] [nvarchar](max) NOT NULL,
	[ImgPath] [nvarchar](512) NULL,
	[IsHomeBanner] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Published] [bit] NOT NULL,
	[BeginTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ComId] [varchar](10) NOT NULL,
	[BmId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Campaign] ON
INSERT [dbo].[Campaign] ([CampaignId], [CampaignName], [Subject], [Body], [ImgPath], [IsHomeBanner], [DisplayOrder], [Published], [BeginTime], [EndTime], [CreatedDate], [ComId], [BmId]) VALUES (1, N'FRTGH', N'FGH', N'WERWERWER', N'Uploads\Products\2017\06\12\f6d2ca5a-b764-482e-bc8b-625be34793df_0.png', 1, 5, 1, NULL, NULL, CAST(0x0000A790017F1235 AS DateTime), N'kpt', 1)
INSERT [dbo].[Campaign] ([CampaignId], [CampaignName], [Subject], [Body], [ImgPath], [IsHomeBanner], [DisplayOrder], [Published], [BeginTime], [EndTime], [CreatedDate], [ComId], [BmId]) VALUES (2, N'43545', N'546456', N'rfgthfgh', N'Uploads\Products\2017\06\12\75ceef9b-17da-4bb3-9c4d-061ca83e8744_0.png', 1, 66, 0, NULL, NULL, CAST(0x0000A790018010E0 AS DateTime), N'kpt', 1)
SET IDENTITY_INSERT [dbo].[Campaign] OFF
