using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public interface ICampaignService
    {
        /// <summary>
        /// Inserts a campaign
        /// </summary>
        /// <param name="campaign">Campaign</param>        
        void InsertCampaign(Campaign campaign);

        /// <summary>
        /// Updates a campaign
        /// </summary>
        /// <param name="campaign">Campaign</param>
        void UpdateCampaign(Campaign campaign);

        /// <summary>
        /// Deleted a queued email
        /// </summary>
        /// <param name="campaign">Campaign</param>
        void DeleteCampaign(Campaign campaign);

        /// <summary>
        /// Gets a campaign by identifier
        /// </summary>
        /// <param name="campaignId">Campaign identifier</param>
        /// <returns>Campaign</returns>
        Campaign GetCampaignById(int campaignId);

       
        IList<Campaign> GetAllCampaigns(int pageIndex=0,int pageSize=int.MaxValue );
         
    }

}
 
