using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Table("Campaign")]
    public class Campaign
    {
        
        [Key]
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string Subject { get; set; }
       
        public string Body { get; set; }
        public string ImgPath { get; set; }
	 
       public bool IsHomeBanner { get; set; }

       public bool Published { get; set; }
        public int DisplayOrder { get; set; }
       public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }

        public DateTime CreatedDate { get; set; }
         
        public string ComId { get; set; }
      
        public int BmId { get; set; } 
    }
}
