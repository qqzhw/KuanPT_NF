using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMCustSys.Model
{
    public class Channel
    {
        public int ChannelId { get; set; }

        public string ChannelLable { get; set; }
        public string ChannelCode { get; set; }
        public string ChannelName { get; set; }
        public string ChannelUrl { get; set; }
        public string ChannelDesc { get; set; }
        public int ParentChannelId { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ComId { get; set; }
        public int BmId { get; set; }
    }
}
