using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Table("Shop")]
    public class Shop_ShopsInfo
    {
        [Key]
        public int ShopId { get; set; }
        public string ShopName { get; set; }

        public string ShopType { get; set; }
       
        public float Price { get; set; }

        public float Commission { get; set; }
        public string Img { get; set; }

        public int State { get; set; }

        public bool ShowOnHomePage { get; set; }

         public int DisplayOrder { get; set; }

        public int CreateUserId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastDate { get; set; }

        public string ComId { get; set; }

        public int BmId { get; set; }       

    }
}
