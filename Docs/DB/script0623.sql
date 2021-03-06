USE [master]
GO
/****** Object:  Database [KPTTestDB]    Script Date: 2017/6/23 16:05:21 ******/
CREATE DATABASE [KPTTestDB] ON  PRIMARY 
( NAME = N'KPTTestDB', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\KPTTestDB.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KPTTestDB_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\KPTTestDB_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [KPTTestDB] SET  ENABLE_BROKER 
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
/****** Object:  Table [dbo].[Campaign]    Script Date: 2017/6/23 16:05:21 ******/
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
	[BmId] [int] NOT NULL,
 CONSTRAINT [PK_Campaign] PRIMARY KEY CLUSTERED 
(
	[CampaignId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2017/6/23 16:05:21 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Channel]    Script Date: 2017/6/23 16:05:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Channel](
	[ChannelId] [int] IDENTITY(1,1) NOT NULL,
	[ChannelName] [nvarchar](400) NOT NULL,
	[ChannelCode] [nvarchar](400) NOT NULL,
	[ChannelLable] [nvarchar](400) NOT NULL,
	[ChannelUrl] [nvarchar](400) NOT NULL,
	[ChannelDesc] [nvarchar](2000) NULL,
	[ParentChannelId] [int] NOT NULL CONSTRAINT [DF_Channel_ParentChannelId]  DEFAULT ((0)),
	[Published] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ComId] [varchar](10) NOT NULL,
	[BmId] [int] NOT NULL,
 CONSTRAINT [PK_Channel] PRIMARY KEY CLUSTERED 
(
	[ChannelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChannelData]    Script Date: 2017/6/23 16:05:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChannelData](
	[ChannelDataId] [int] IDENTITY(1,1) NOT NULL,
	[ChannelId] [int] NOT NULL,
	[ChannelName] [nvarchar](200) NOT NULL,
	[ShopId] [int] NOT NULL CONSTRAINT [DF_ChannelData_ShopId]  DEFAULT ((0)),
	[ShopName] [nvarchar](400) NOT NULL,
	[ViewsCount] [int] NOT NULL CONSTRAINT [DF_ChannelData_ViewsCount]  DEFAULT ((1)),
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ChannelData] PRIMARY KEY CLUSTERED 
(
	[ChannelDataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lottery]    Script Date: 2017/6/23 16:05:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Lottery](
	[LotteryId] [int] IDENTITY(1,1) NOT NULL,
	[KeyWord] [nvarchar](50) NOT NULL,
	[LotteryName] [nvarchar](100) NOT NULL,
	[LotteryImg] [nvarchar](100) NOT NULL,
	[ExchangeInfo] [nvarchar](200) NULL,
	[Description] [nvarchar](512) NULL,
	[Introduction] [nvarchar](1000) NOT NULL,
	[RepeatLotteryInfo] [nvarchar](100) NULL,
	[LotteryPassword] [nvarchar](50) NULL,
	[LotteryTips] [nvarchar](50) NOT NULL,
	[LotteryEndImg] [nvarchar](100) NULL,
	[LotteryEndNotice] [nvarchar](512) NULL,
	[LotteryEndInfo] [nvarchar](1000) NULL,
	[PersonCount] [int] NOT NULL,
	[MaxLotteryCount] [int] NOT NULL,
	[TodayLotteryCount] [int] NOT NULL,
	[LotteryUrl] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[BeginDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[ViewCount] [int] NOT NULL CONSTRAINT [DF_Lottery_ViewCount]  DEFAULT ((0)),
	[ComId] [varchar](10) NOT NULL,
	[BmId] [int] NOT NULL,
 CONSTRAINT [PK_Lottery] PRIMARY KEY CLUSTERED 
(
	[LotteryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LotteryItem]    Script Date: 2017/6/23 16:05:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LotteryItem](
	[LotteryItemId] [int] IDENTITY(1,1) NOT NULL,
	[LotteryId] [int] NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[AwardName] [varchar](50) NOT NULL,
	[AwardCount] [int] NOT NULL,
	[CurrentCount] [int] NOT NULL,
	[AwardPercent] [int] NOT NULL CONSTRAINT [DF_LotteryItem_AwardPercent]  DEFAULT ((0)),
	[ComId] [varchar](10) NOT NULL,
	[BmId] [int] NOT NULL,
 CONSTRAINT [PK_LotteryItem] PRIMARY KEY CLUSTERED 
(
	[LotteryItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2017/6/23 16:05:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [nvarchar](20) NOT NULL,
	[UserPhone] [varchar](30) NOT NULL,
	[UserId] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[RealName] [varchar](50) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[CustomerTel] [varchar](50) NOT NULL,
	[IdCard] [varchar](20) NULL,
	[CustomerAddress] [varchar](200) NOT NULL,
	[ShopId] [int] NOT NULL,
	[ShopName] [varchar](100) NOT NULL,
	[ShopType] [varchar](100) NOT NULL,
	[Price] [float] NOT NULL,
	[PayPrice] [float] NOT NULL,
	[PayType] [nvarchar](50) NOT NULL,
	[Commission] [float] NOT NULL,
	[PayCommission] [float] NOT NULL,
	[PayCommissionType] [varchar](10) NOT NULL,
	[Img] [nvarchar](100) NOT NULL,
	[OrderState] [int] NOT NULL,
	[PaymentStatus] [int] NOT NULL,
	[PayTime] [datetime] NULL,
	[CreateUserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[AliAccount] [varchar](50) NOT NULL,
	[CommissionState] [int] NOT NULL,
	[CommissionPayTime] [datetime] NULL,
	[PaymentDate] [datetime] NULL,
	[ComId] [varchar](10) NOT NULL,
	[BmId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL CONSTRAINT [DF_Order_Deleted]  DEFAULT ((0)),
	[Remark] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Shop]    Script Date: 2017/6/23 16:05:21 ******/
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
	[BigImg] [nvarchar](512) NULL,
	[State] [int] NOT NULL,
	[ShowOnHomePage] [bit] NOT NULL,
	[IsHotShop] [bit] NOT NULL CONSTRAINT [DF_Shop_IsHotShop]  DEFAULT ((0)),
	[DisplayOrder] [int] NOT NULL,
	[ShortDescription] [nvarchar](512) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Remark] [nvarchar](1000) NULL,
	[CreateUserId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastDate] [datetime] NOT NULL,
	[OrderCount] [int] NOT NULL CONSTRAINT [DF_Shop_OrderCount]  DEFAULT ((0)),
	[ViewsCount] [int] NOT NULL CONSTRAINT [DF_Shop_ViewsCount]  DEFAULT ((0)),
	[ComId] [varchar](10) NOT NULL,
	[BmId] [int] NOT NULL,
 CONSTRAINT [PK_Shop] PRIMARY KEY CLUSTERED 
(
	[ShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Campaign] ON 

INSERT [dbo].[Campaign] ([CampaignId], [CampaignName], [Subject], [Body], [ImgPath], [IsHomeBanner], [DisplayOrder], [Published], [BeginTime], [EndTime], [CreatedDate], [ComId], [BmId]) VALUES (1, N'168套餐', N'168套餐', N'<img src="/attached/image/20170623/20170623114654_1679.png" alt="" />', N'Uploads\Products\2017\06\23\42bfa283-5da6-478d-be33-9f2a0179d09d_0.jpeg', 1, 5, 1, NULL, NULL, CAST(N'2017-06-12 23:14:43.163' AS DateTime), N'kpt', 1)
INSERT [dbo].[Campaign] ([CampaignId], [CampaignName], [Subject], [Body], [ImgPath], [IsHomeBanner], [DisplayOrder], [Published], [BeginTime], [EndTime], [CreatedDate], [ComId], [BmId]) VALUES (2, N'168套餐', N'168套餐', N'<img src="/attached/image/20170623/20170623114654_1679.png" alt="" />', N'Uploads\Products\2017\06\23\42bfa283-5da6-478d-be33-9f2a0179d09d_0.jpeg', 1, 66, 0, NULL, NULL, CAST(N'2017-06-12 23:18:20.480' AS DateTime), N'kpt', 1)
SET IDENTITY_INSERT [dbo].[Campaign] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description], [ParentCategoryId], [ShowOnHomePage], [Published], [Deleted], [DisplayOrder], [CreatedDate], [UpdatedDate], [ComId], [BmId]) VALUES (1, N'12', N'werwer2232223', 0, 1, 1, 0, 1, CAST(N'2017-06-13 17:15:38.407' AS DateTime), NULL, N'test', 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description], [ParentCategoryId], [ShowOnHomePage], [Published], [Deleted], [DisplayOrder], [CreatedDate], [UpdatedDate], [ComId], [BmId]) VALUES (48, N'124555', N'dddddd', 1, 0, 1, 0, 0, CAST(N'2017-06-13 17:56:47.677' AS DateTime), NULL, N'test', 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description], [ParentCategoryId], [ShowOnHomePage], [Published], [Deleted], [DisplayOrder], [CreatedDate], [UpdatedDate], [ComId], [BmId]) VALUES (49, N'宽带专区', N'宽带专区', 0, 0, 1, 0, 0, CAST(N'2017-06-13 17:58:30.650' AS DateTime), NULL, N'test', 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Channel] ON 

INSERT [dbo].[Channel] ([ChannelId], [ChannelName], [ChannelCode], [ChannelLable], [ChannelUrl], [ChannelDesc], [ParentChannelId], [Published], [DisplayOrder], [CreatedDate], [ComId], [BmId]) VALUES (1, N'微信', N'weixin', N'kuanpa', N'123213', N'23122212', 0, 1, 1, CAST(N'2017-06-20 16:29:27.273' AS DateTime), N'test', 1)
SET IDENTITY_INSERT [dbo].[Channel] OFF
SET IDENTITY_INSERT [dbo].[ChannelData] ON 

INSERT [dbo].[ChannelData] ([ChannelDataId], [ChannelId], [ChannelName], [ShopId], [ShopName], [ViewsCount], [CreatedDate]) VALUES (1, 1, N'微信', 0, N'首页', 0, CAST(N'2017-06-21 15:23:25.510' AS DateTime))
INSERT [dbo].[ChannelData] ([ChannelDataId], [ChannelId], [ChannelName], [ShopId], [ShopName], [ViewsCount], [CreatedDate]) VALUES (2, 1, N'微信', 0, N'首页', 0, CAST(N'2017-06-21 15:23:35.003' AS DateTime))
INSERT [dbo].[ChannelData] ([ChannelDataId], [ChannelId], [ChannelName], [ShopId], [ShopName], [ViewsCount], [CreatedDate]) VALUES (3, 1, N'微信', 11, N'手机+58', 0, CAST(N'2017-06-21 15:24:00.103' AS DateTime))
SET IDENTITY_INSERT [dbo].[ChannelData] OFF
SET IDENTITY_INSERT [dbo].[Lottery] ON 

INSERT [dbo].[Lottery] ([LotteryId], [KeyWord], [LotteryName], [LotteryImg], [ExchangeInfo], [Description], [Introduction], [RepeatLotteryInfo], [LotteryPassword], [LotteryTips], [LotteryEndImg], [LotteryEndNotice], [LotteryEndInfo], [PersonCount], [MaxLotteryCount], [TodayLotteryCount], [LotteryUrl], [CreatedDate], [BeginDate], [EndDate], [ViewCount], [ComId], [BmId]) VALUES (1, N'儿', N'儿', N'', N'儿', N'33', N'33', N'32', N'3', N'32', NULL, NULL, NULL, 1, 11, 1, N'33', CAST(N'2017-06-22 15:34:57.730' AS DateTime), CAST(N'2017-06-07 00:00:00.000' AS DateTime), CAST(N'2017-05-31 00:00:00.000' AS DateTime), 0, N'test', 1)
INSERT [dbo].[Lottery] ([LotteryId], [KeyWord], [LotteryName], [LotteryImg], [ExchangeInfo], [Description], [Introduction], [RepeatLotteryInfo], [LotteryPassword], [LotteryTips], [LotteryEndImg], [LotteryEndNotice], [LotteryEndInfo], [PersonCount], [MaxLotteryCount], [TodayLotteryCount], [LotteryUrl], [CreatedDate], [BeginDate], [EndDate], [ViewCount], [ComId], [BmId]) VALUES (2, N'儿', N'儿', N'', N'儿', N'33', N'33', N'32', N'3', N'32', NULL, NULL, NULL, 1, 11, 17, N'33', CAST(N'2017-06-22 15:35:17.270' AS DateTime), CAST(N'2017-06-07 00:00:00.000' AS DateTime), CAST(N'2017-05-31 00:00:00.000' AS DateTime), 0, N'test', 1)
INSERT [dbo].[Lottery] ([LotteryId], [KeyWord], [LotteryName], [LotteryImg], [ExchangeInfo], [Description], [Introduction], [RepeatLotteryInfo], [LotteryPassword], [LotteryTips], [LotteryEndImg], [LotteryEndNotice], [LotteryEndInfo], [PersonCount], [MaxLotteryCount], [TodayLotteryCount], [LotteryUrl], [CreatedDate], [BeginDate], [EndDate], [ViewCount], [ComId], [BmId]) VALUES (3, N'儿', N'儿', N'', N'儿', N'33', N'33', N'32', N'3', N'32', NULL, NULL, NULL, 1, 12, 1, N'33', CAST(N'2017-06-22 15:35:17.270' AS DateTime), CAST(N'2017-06-07 00:00:00.000' AS DateTime), CAST(N'2017-05-31 00:00:00.000' AS DateTime), 0, N'test', 1)
INSERT [dbo].[Lottery] ([LotteryId], [KeyWord], [LotteryName], [LotteryImg], [ExchangeInfo], [Description], [Introduction], [RepeatLotteryInfo], [LotteryPassword], [LotteryTips], [LotteryEndImg], [LotteryEndNotice], [LotteryEndInfo], [PersonCount], [MaxLotteryCount], [TodayLotteryCount], [LotteryUrl], [CreatedDate], [BeginDate], [EndDate], [ViewCount], [ComId], [BmId]) VALUES (4, N'儿', N'儿', N'', N'儿', N'33', N'33', N'32', N'3', N'32', NULL, N'454554', N'r445', 1, 11, 17, N'33', CAST(N'2017-06-22 15:35:17.270' AS DateTime), CAST(N'2017-06-07 00:00:00.000' AS DateTime), CAST(N'2017-05-31 00:00:00.000' AS DateTime), 0, N'test', 1)
SET IDENTITY_INSERT [dbo].[Lottery] OFF
SET IDENTITY_INSERT [dbo].[LotteryItem] ON 

INSERT [dbo].[LotteryItem] ([LotteryItemId], [LotteryId], [ItemName], [AwardName], [AwardCount], [CurrentCount], [AwardPercent], [ComId], [BmId]) VALUES (2, 1, N'34', N'3434', 1, 1, 0, N'test', 1)
SET IDENTITY_INSERT [dbo].[LotteryItem] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderId], [OrderNo], [UserPhone], [UserId], [UserName], [RealName], [CustomerName], [CustomerTel], [IdCard], [CustomerAddress], [ShopId], [ShopName], [ShopType], [Price], [PayPrice], [PayType], [Commission], [PayCommission], [PayCommissionType], [Img], [OrderState], [PaymentStatus], [PayTime], [CreateUserId], [CreateDate], [AliAccount], [CommissionState], [CommissionPayTime], [PaymentDate], [ComId], [BmId], [Deleted], [Remark]) VALUES (1, N'KD20170617175857757', N'10086', 1, N'admin', N'张三', N'有', N'67', N'', N'67', 13, N'新爱家138', N'宽带', 138, 0, N'12', 0, 0, N'0', N'Uploads\Products\2017\06\14\taocan50M.png', 0, 0, NULL, 1, CAST(N'2017-06-17 17:58:57.757' AS DateTime), N'67', 0, NULL, NULL, N'test', 1, 0, N'32')
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Shop] ON 

INSERT [dbo].[Shop] ([ShopId], [ShopName], [ShopType], [Price], [Commission], [Img], [BigImg], [State], [ShowOnHomePage], [IsHotShop], [DisplayOrder], [ShortDescription], [Description], [Remark], [CreateUserId], [CreateDate], [LastDate], [OrderCount], [ViewsCount], [ComId], [BmId]) VALUES (11, N'手机+58', N'宽带', 78, 0, N'Uploads\Products\2017\06\14\taocan20M.png', N'\Content\Images\home_20M1.png', 1, 1, 0, 0, N'手机+58，个人消费58/月，送20M宽带和高清收视', N'•资费名称：手机+58<br/>•带宽：20M<br/>•套餐费用：20元/月<br/>•手机成员（含主号码）：--<br/>•共享话费：--<br/>•赠送语音：--<br/>•初装费：150<br/>使用4G资费并保底58元免费赠送一年宽带和收视，活动到期后收费20元/月', N'1、因地址覆盖问题登原因可能会出现无法安装的情况，敬请谅解，我们后续将尽快解决，感谢您的支持&lt;br /&gt;
2、协议期为一年&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;', 1, CAST(N'2017-06-14 17:21:06.263' AS DateTime), CAST(N'2017-06-14 17:21:06.263' AS DateTime), 0, 0, N'test', 1)
INSERT [dbo].[Shop] ([ShopId], [ShopName], [ShopType], [Price], [Commission], [Img], [BigImg], [State], [ShowOnHomePage], [IsHotShop], [DisplayOrder], [ShortDescription], [Description], [Remark], [CreateUserId], [CreateDate], [LastDate], [OrderCount], [ViewsCount], [ComId], [BmId]) VALUES (12, N'新爱家108', N'宽带', 108, 0, N'Uploads\Products\2017\06\14\taocan50M.png', N'\Content\Images\home_50M1.png', 1, 1, 0, 0, N'个人消费108/月，50M宽带和高清收视', N'•资费名称：新爱家108&lt;br /&gt;
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
&lt;br /&gt;', 1, CAST(N'2017-06-14 17:22:15.517' AS DateTime), CAST(N'2017-06-14 17:22:15.517' AS DateTime), 0, 0, N'test', 1)
INSERT [dbo].[Shop] ([ShopId], [ShopName], [ShopType], [Price], [Commission], [Img], [BigImg], [State], [ShowOnHomePage], [IsHotShop], [DisplayOrder], [ShortDescription], [Description], [Remark], [CreateUserId], [CreateDate], [LastDate], [OrderCount], [ViewsCount], [ComId], [BmId]) VALUES (13, N'新爱家138', N'宽带', 138, 0, N'Uploads\Products\2017\06\14\taocan50M.png', NULL, 1, 0, 0, 0, N'个人消费138/月，50M宽带和高清收视', N'&amp;nbsp;•资费名称：新爱家138&lt;br /&gt;
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
&lt;br /&gt;', 1, CAST(N'2017-06-14 17:23:12.123' AS DateTime), CAST(N'2017-06-14 17:23:12.123' AS DateTime), 0, 0, N'test', 1)
INSERT [dbo].[Shop] ([ShopId], [ShopName], [ShopType], [Price], [Commission], [Img], [BigImg], [State], [ShowOnHomePage], [IsHotShop], [DisplayOrder], [ShortDescription], [Description], [Remark], [CreateUserId], [CreateDate], [LastDate], [OrderCount], [ViewsCount], [ComId], [BmId]) VALUES (14, N'新爱家168', N'宽带', 168, 0, N'Uploads\Products\2017\06\14\taocan100M.png', N'\Content\Images\home_100M1.png', 1, 1, 1, 0, N'个人消费168/月，100M宽带和高清收视', N'•资费名称：新爱家168&lt;br /&gt;
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
&lt;br /&gt;', 1, CAST(N'2017-06-14 17:24:20.423' AS DateTime), CAST(N'2017-06-14 17:24:20.423' AS DateTime), 0, 0, N'test', 1)
INSERT [dbo].[Shop] ([ShopId], [ShopName], [ShopType], [Price], [Commission], [Img], [BigImg], [State], [ShowOnHomePage], [IsHotShop], [DisplayOrder], [ShortDescription], [Description], [Remark], [CreateUserId], [CreateDate], [LastDate], [OrderCount], [ViewsCount], [ComId], [BmId]) VALUES (15, N'爱家138', N'宽带', 138, 0, N'Uploads\Products\2017\06\14\taocan50M.png', N'\Content\Images\home_50M138.png', 1, 1, 0, 0, N'个人消费138/月，送50M宽带和高清收视', N'资费名称：爱家138&lt;br /&gt;
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
&lt;br /&gt;', 1, CAST(N'2017-06-14 17:25:56.123' AS DateTime), CAST(N'2017-06-14 17:25:56.123' AS DateTime), 0, 0, N'test', 1)
INSERT [dbo].[Shop] ([ShopId], [ShopName], [ShopType], [Price], [Commission], [Img], [BigImg], [State], [ShowOnHomePage], [IsHotShop], [DisplayOrder], [ShortDescription], [Description], [Remark], [CreateUserId], [CreateDate], [LastDate], [OrderCount], [ViewsCount], [ComId], [BmId]) VALUES (16, N'爱家168', N'宽带', 168, 0, N'Uploads\Products\2017\06\14\taocan50M.png', NULL, 1, 0, 0, 0, N'个人消费168/月，送50M宽带和高清收视', N'•资费名称：爱家168&lt;br /&gt;
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
&lt;br /&gt;', 1, CAST(N'2017-06-14 17:27:01.013' AS DateTime), CAST(N'2017-06-14 17:27:01.013' AS DateTime), 0, 0, N'test', 1)
SET IDENTITY_INSERT [dbo].[Shop] OFF
USE [master]
GO
ALTER DATABASE [KPTTestDB] SET  READ_WRITE 
GO
