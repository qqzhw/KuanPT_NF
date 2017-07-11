using IMCustSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMCustSys.BLL.Services
{
    public interface ILotteryService
    {
        void InsertLottery(Lottery lottery);
        void UpdateLottery(Lottery lottery);
        void DeleteLottery(Lottery lottery);
        Lottery GetLotteryById(int lotteryId);
        IList<Lottery> GetAllLotterys(string comId="",string name = "");

        void InsertLotteryItem(LotteryItem lotteryItem);
        void UpdateLotteryItem(LotteryItem lotteryItem);
        void DeleteLotteryItem(LotteryItem lotteryItem);
        LotteryItem GetLotteryItemById(int lotteryItemId);
        IList<LotteryItem> GetAllLotteryItems(int LotteryId);
    }
}
