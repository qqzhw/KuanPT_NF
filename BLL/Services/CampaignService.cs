using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMCustSys.Model;
using IMCustSys.DAL;
using DapperExtensions;

namespace IMCustSys.BLL.Services
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
            if (campaign == null)
                return;
            _campaignRepository.Delete(campaign);
        }
              

        public IList<Campaign> GetAllCampaigns(string comId="", string keyword = "", int pageIndex = 0, int pageSize = int.MaxValue)
        { 
            var pgMain = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
            var pgb = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            if (!string.IsNullOrEmpty(comId))
            {
                pgb.Predicates.Add(Predicates.Field<Campaign>(f => f.ComId, Operator.Eq, comId));
            }  
            pgMain.Predicates.Add(pgb);
            IEnumerable<Campaign> list = _campaignRepository.GetList(pgMain);
            return list.ToList();

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
            if (campaign == null)
                return;
            _campaignRepository.Insert(campaign);
        }

        public void UpdateCampaign(Campaign campaign)
        {
            if (campaign == null)
                return;
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

        public List<Campaign> GetAllHomeCampaign()
        { 
            var pgMain = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
            var pgb = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            
                pgb.Predicates.Add(Predicates.Field<Campaign>(f => f.IsHomeBanner, Operator.Ge, true)); 
                pgb.Predicates.Add(Predicates.Field<Campaign>(f => f.Published, Operator.Le, true));
             
            pgMain.Predicates.Add(pgb);
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "DisplayOrder",Ascending = true }
            };
           var list = _campaignRepository.GetList(pgMain,sortItems);
            return list.Take(5).ToList(); 
        }
    }
}
