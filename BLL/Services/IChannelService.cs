using IMCustSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMCustSys.BLL.Services
{
   public  interface IChannelService
    {
        string CurrentItem { get; set; }
        void InsertChannel(Channel channel); 
        void UpdateChannel(Channel channel); 
        void DeleteChannel(Channel channel); 

        Channel GetChannelById(int channelId);

        Channel GetChannelByCode(string  channelCode);

        IList<Channel> GetAllChannels(string comId="", string keywords = "", string channelCode="" ,int pageIndex = 0, int pageSize = int.MaxValue);

        #region 渠道统计
        void InsertChannelData(ChannelData channelData);
        void UpdateChannelData(ChannelData channelData);
        void DeleteChannelData(ChannelData channelData);
        ChannelData GetChannelDataById(int channelDataId);

        IList<ChannelData> GetAllChannelDatas(string channelName = "", DateTime? beginTime = null, DateTime? endTime = null);
        #endregion

    }
}
