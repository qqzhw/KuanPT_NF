using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMCustSys.Web.Models
{
    public class ShopModel
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }

        public string ShopType { get; set; }

        public float Price { get; set; }

        public float Commission { get; set; }

        public string Img { get; set; }
        public string BigImg { get; set; }
        public int State { get; set; }

        public bool ShowOnHomePage { get; set; }

        public int DisplayOrder { get; set; }

        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Remark { get; set; }


        public DateTime CreateDate { get; set; }

    }
}