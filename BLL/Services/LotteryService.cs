using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using DapperExtensions;

namespace BLL.Services
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

        public IList<Lottery> GetAllLotterys(string name = "")
        {
            object predicate = null;
            if (!string.IsNullOrEmpty(name))
            {
                predicate = Predicates.Field<Lottery>(p => p.LotteryName, Operator.Like, "%" + name + "%");
            }
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "LotteryId",Ascending = false }
            };
            var query = _lotteryRepository.GetList(predicate, sortItems);
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
            _lotteryRepository.Insert(lottery);
        }

        public void UpdateLotteryItem(LotteryItem lotteryItem)
        {
            if (lotteryItem == null)
                throw new ArgumentNullException("lotteryItem");
             _lotteryItemRepository.Insert(lotteryItem);
        }
    }
}
