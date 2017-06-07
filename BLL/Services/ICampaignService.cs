﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public interface ICampaignService
    {
        
        void InsertCampaign(Campaign campaign);

        
        void UpdateCampaign(Campaign campaign);

       
        void DeleteCampaign(Campaign campaign);

       
        Campaign GetCampaignById(int campaignId);

       
        IList<Campaign> GetAllCampaigns(string keyword="", int pageIndex=0,int pageSize=int.MaxValue );
         
    }

}
 