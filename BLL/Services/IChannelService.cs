using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
   public  interface IChannelService
    {
        void InsertChannel(Channel channel);


        void UpdateChannel(Channel channel);


        void DeleteChannel(Channel channel);


        Channel GetChannelById(int channelId);

        Channel GetChannelById(string  channelCode);

        IList<Channel> GetAllChannels(string keywords = "", string channelCode="" ,int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
