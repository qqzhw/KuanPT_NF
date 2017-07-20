using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMCustSys.Model;
using IMCustSys.DAL;
using DapperExtensions;

namespace IMCustSys.BLL.Services
{
    public class LotteryService : ILotteryService
    {
        private readonly IRepository<Lottery> _lotteryRepository;
        private readonly IRepository<LotteryItem> _lotteryItemRepository;

        public LotteryService(IRepository<Lottery>  lotteryRepository, IRepository<LotteryItem> lotteryItemRepository)
        {
            _lotteryRepository = lotteryRepository;
            _lotteryItemRepository = lotteryItemRepository;
        }
        public void DeleteLottery(Lottery lottery)
        {
            if (lottery == null)
                return;
            var list = GetAllLotteryItems(lottery.LotteryId);
            _lotteryItemRepository.Delete(list);
            _lotteryRepository.Delete(lottery);

        }

        public void DeleteLotteryItem(LotteryItem lotteryItem)
        {
            if (lotteryItem == null)
                return;
             _lotteryItemRepository.Delete(lotteryItem);
        }

        public IList<LotteryItem> GetAllLotteryItems(int LotteryId)
        { 
            var   predicate = Predicates.Field<LotteryItem>(p => p.LotteryId, Operator.Eq,LotteryId);
             var query =  _lotteryItemRepository.GetList(predicate);
            return query.ToList();
        }

        public IList<Lottery> GetAllLotterys(string comId="",string name = "")
        {
          
         
            var pgMain = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
            var pgb = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            if (!string.IsNullOrEmpty(name))
            {
                pgb.Predicates.Add(Predicates.Field<Lottery>(p => p.LotteryName, Operator.Like, "%" + name + "%"));
            }
            if (!string.IsNullOrEmpty(comId))
            {
                pgb.Predicates.Add(Predicates.Field<Lottery>(f => f.ComId, Operator.Eq, comId));
            }
            pgMain.Predicates.Add(pgb);

            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "LotteryId",Ascending = false }
            };
            var query = _lotteryRepository.GetList(pgMain, sortItems);
            return query.ToList();
        }

        public Lottery GetLotteryById(int lotteryId)
        {
            if (lotteryId == 0)
                return null;
            return  _lotteryRepository.GetById(lotteryId);
        }

        public LotteryItem GetLotteryItemById(int lotteryItemId)
        {
            if (lotteryItemId == 0)
                return null;
            return  _lotteryItemRepository.GetById(lotteryItemId);
        }

        public void InsertLottery(Lottery lottery)
        {
            if (lottery == null)
                throw new ArgumentNullException("lottery");
            _lotteryRepository.Insert(lottery);
        }

        public void InsertLotteryItem(LotteryItem lotteryItem)
        {
            if (lotteryItem == null)
                throw new ArgumentNullException("lotteryItem");
            _lotteryItemRepository.Insert(lotteryItem);
        }

        public void UpdateLottery(Lottery lottery)
        {
            if (lottery == null)
                throw new ArgumentNullException("lottery");
            _lotteryRepository.Update(lottery);
        }

        public void UpdateLotteryItem(LotteryItem lotteryItem)
        {
            if (lotteryItem == null)
                throw new ArgumentNullException("lotteryItem");
             _lotteryItemRepository.Insert(lotteryItem);
        }
    }
}
