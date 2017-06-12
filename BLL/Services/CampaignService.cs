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
            var totalRecord = 0;
            var totalPage = 0;
            return _campaignRepository.GetPageData("Campaign", "CampaignId", out totalRecord,out totalPage, pageIndex:pageIndex,pageSize:pageSize);
        }
       
        public Campaign GetCampaignById(int campaignId)
        {
            if (campaignId==0)
            {
                return null;
            }
            return _campaignRepository.GetById(campaignId);
        }

        public void InsertCampaign(Campaign campaign)
        {
            _campaignRepository.Insert(campaign);
        }

        public void UpdateCampaign(Campaign campaign)
        {
            _campaignRepository.Update(campaign);
        }

      
        public IList<Campaign> GetPageData(out int totalRecord, out int totalPage, string fields = "", string orderField = "", int pageIndex = 0, string whereStr = "",
          int pageSize = int.MaxValue)
        {
            if (string.IsNullOrEmpty(orderField))
            {
                orderField = "campaignId";
            }
            var items = _campaignRepository.GetPageData("Campaign",orderField, out totalRecord, out totalPage,fields,whereStr, pageIndex, pageSize);
            return items;
        }
    }
}
