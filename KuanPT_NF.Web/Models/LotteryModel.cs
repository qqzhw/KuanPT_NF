using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMCustSys.Web.Models
{
    public class LotteryModel
    {
        public int LotteryId { get; set; }
        public string LotteryName { get; set; }
        public string LotteryImg { get; set; }
        public string ExchangeInfo { get; set; }
        public string Description { get; set; }//简介
        public string Introduction { get; set; }//说明
        public string RepeatLotteryInfo { get; set; }//重复抽奖说明
        public string LotteryPassword { get; set; }// 奖密码
        /// <summary>
        /// 中奖提示语
        /// </summary>
        public string LotteryTips { get; set; }

        /// <summary>
        /// 活动结束图片
        /// </summary>
        public string LotteryEndImg { get; set; }
        /// <summary>
        /// 活动结束公告
        /// </summary>
        public string LotteryEndNotice { get; set; }
        /// <summary>
        /// 活动结束说明
        /// </summary>
        public string LotteryEndInfo { get; set; }
        public string KeyWord { get; set; }

        public int PersonCount { get; set; }
        public int MaxLotteryCount { get; set; }
        public int TodayLotteryCount { get; set; }
        public string LotteryUrl { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        
    }
}