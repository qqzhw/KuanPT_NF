using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly IRepository<Campaign> _campaignRepository;

        public CampaignService(IRepository<Campaign>  campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public void DeleteCampaign(Campaign campaign)
        {
            
        }

        public IList<Campaign> GetAllCampaigns(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return null;
        }

        public IList<Campaign> GetAllCampaigns(string keyword = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public Campaign GetCampaignById(int campaignId)
        {
            return _campaignRepository.GetById(campaignId);
        }

        public void InsertCampaign(Campaign campaign)
        {
            _campaignRepository.Insert(campaign);
        }

        public void UpdateCampaign(Campaign campaign)
        {
            
        }
    }
}
