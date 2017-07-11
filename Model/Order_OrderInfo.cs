using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMCustSys.Model
{
    /// <summary>
    /// 订单实体
    /// </summary>
    public class Order
    {
        public  int OrderId { get; set; }
        //        订单类 无   Orders 订单表 OrderId INT PK IDENTITY NOT NULL

        public string OrderNo { get; set; }
        public string UserPhone { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTel { get; set; }
        public string CustomerAddress { get; set; }
        public string IdCard { get; set; }
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopType { get; set; } 
        public double Price { get; set; }
        public double PayPrice { get; set; }
        public string PayType { get; set; }
        public double Commission { get; set; }
         public double PayCommission { get; set; }
        public double PayCommissionType { get; set; }
        public string Img { get; set; }
        
        public int OrderState { get;set;}
        public int PaymentStatus { get; set; } 
        public DateTime? PayTime { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string AliAccount { get; set; }
        public int CommissionState { get; set; }
        public DateTime? CommissionPayTime { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool Deleted { get; set; }
        public string Remark { get; set; }
        public string ComId { get; set; }
        public int BmId { get; set; }

        //                Price FLOAT NOT NULL

        //                PayPrice FLOAT NOT NULL

        //                PayType VARCHAR(10) NOT NULL

        //                Commission FLOAT NOT NULL

        //                PayCommission FLOAT NOT NULL

        //                PayCommissionType VARCHAR(10) NOT NULL

        //                Img VARCHAR(50) NOT NULL

        //                OrderState INT NOT NULL

        //                PayTime DATETIME

        //                CreateUserId INT NOT NULL

        //                CreateDate DATETIME

        //                AliAccount VARCHAR(50) NOT NULL

        //                CommissionState INT NOT NULL

        //                CommissionPayTime DATETIME

        //                PaymentDate DATETIME

        //                comId VARCHAR(10) NOT NULL

        //                bmId INT NOT NULL
        //产品分类 无   Category 分类表 CategoryId INT PK IDENTITY NOT NULL

        //                CategoryName NVARCHAR(100) NOT NULL

        //                Description NVARCHAR(500)  NULL
        //                ParentCategoryId    INT NOT NULL
        //                ShowOnHomePage  BIT NOT NULL
        //                Published   Bit NOT NULL
        //                Deleted Bit Not NULL
        //                DisplayOrder    int not null

        //                CreateDate DATETIME NOT NULL

        //                UpdateDate DATETIME NULL
        //               comId   VARCHAR(10) NOT NULL

        //                bmId INT NOT NULL
        //产品分类映射表 无   Shop_Category_Mapping 产品分类关联表 Id INT PK IDENTITY NOT NULL

        //                ShopId INT NOT NULL

        //                CategoryId INT NOT NULL

        //                IsFeatureProduct Bit Not NULL

        //                DisplayOrder int not null

        //                comId VARCHAR(10) NOT NULL

        //                bmId INT NOT NULL
        //订单跟踪记录 无   OrderNote 订单跟踪表   NoteId INT PK IDENTITY NOT NULL

        //                OrderId INT NOT NULL

        //                NoteType INT  NULL
        //             Description NVARCHAR(1000)   NULL
        //             CreateDate  DATETIME NOT NULL
        //             comId   VARCHAR(10) NOT NULL

        //                bmId INT NOT NULL
        //渠道表 无   Channel 渠道表 ChannelId INT PK IDENTITY NOT NULL

        //                ChannelLable NVARCHAR(100)  NULL
        //             ChannelCode VARCHAR(50)

        //                ChannelName NVARCHAR(100) NOT NULL

        //                ChannelUrl NVARCHAR(200)   NULL
        //               ParentChannelId INT NOT NUL
        //               CreateDate  DATETIME NOT NULL
        //               comId   VARCHAR(10) NOT NULL

        //                bmId INT NOT NULL
        //活动表 无   Channel 活动表 CampaignId INT PK IDENTITY NOT NULL

        //                CampaignName NVARCHAR(100)  NULL
        //             Subject VARCHAR(100)

        //                Body NVARCHAR(Max) NOT NULL

        //                Published Bit not NULL


        //                BeginTime DATETIME   NULL
        //              EndTime DATETIME NULL

        //                CreateDate DATETIME NOT NULL

        //                comId VARCHAR(10) NOT NULL

        //                bmId INT NOT NULL

    }
}
