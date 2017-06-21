using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Lottery
    {
        public int LotteryId { get; set; }
        public string LotteryName { get; set; }//彩票活动名称
        public string LotteryImg { get; set; }
        public string ExchangeInfo { get; set; }
        public string Description { get; set; }//简介
        public string Introduction { get; set; }//说明
        public string RepeatLotteryInfo { get; set; }//重复抽奖说明
        public string  LotteryPassword { get; set; }// 奖密码
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
        public DateTime CreatedDate { get; set; }
        public int ViewCount { get; set; }
        public string ComId { get; set; }
        public int BmId { get; set; }

//        关键词 活动名称 活动图片 兑奖信息 简介 活动开始时间 活动结束时间 活动说明 重复抽奖说明 兑奖密码 中奖提示语
//活动结束内容（结束图片 结束公告，结束说明）   活动人数 没人每日抽奖数  最多允许抽奖次数
    }
}
