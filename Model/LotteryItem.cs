using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMCustSys.Model
{
    public class LotteryItem
    { 
        public int LotteryItemId { get; set; }
        public int LotteryId { get; set; }
        public string ItemName { get; set; }//奖项名称
        public string AwardName { get; set; }//奖品名称
        public int AwardCount { get; set; }//奖品数量
        public int CurrentCount { get; set; }//实际奖品数
        public int AwardPercent { get; set; }//中奖几率
        public string ComId { get; set; }
        public int BmId { get; set; }
    }
}
