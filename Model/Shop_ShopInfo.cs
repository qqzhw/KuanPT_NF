using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{ 
    public class Shop
    { 
        public int ShopId { get; set; }
        public string ShopName { get; set; }

        public string ShopType { get; set; }
       
        public float Price { get; set; }

        public float Commission { get; set; }
        public string Img { get; set; }

        public int State { get; set; }

        public bool ShowOnHomePage { get; set; }

         public int DisplayOrder { get; set; }

        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Remark { get; set; }
        public int CreateUserId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastDate { get; set; }

        public string ComId { get; set; }

        public int BmId { get; set; }       
        //新增字段
        public bool IsHotShop { get; set; } //热销
        public int OrderCount { get; set; }//订单数
        public int ViewsCount { get; set; }//浏览数
        public string BigImg { get; set; }//产品大图
    }
}
