﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KuanPT_NF.Web.Models
{
    public class CampaignModel
    {
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
        public string ComId { get; set; }
        public int BmId { get; set; }
    }
}