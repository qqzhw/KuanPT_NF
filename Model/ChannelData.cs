using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ChannelData
    {
        public int ChannelDataId { get; set; } 
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public int ShopId {get; set; }
        public string ShopName { get; set; }
        public int ViewsCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
