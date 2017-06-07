using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public class ShopCategory
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public int CategoryId { get; set; }
        public bool IsFeatureProduct { get; set; }
        public int DisplayOrder { get; set; }
        public string ComId { get; set; }
        public int BmId { get; set; }        
    }
}
