using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using BLL.Caching;
using Common;
using DapperExtensions;
 
namespace BLL.Services
{
    public class ChannelService : IChannelService
    {
        #region Fields 
        private readonly IRepository<Channel> _channelRepository; 
        private readonly ICacheManager _cacheManager; 
        #endregion
        public ChannelService(IRepository<Channel>  channelRepository)
        {
            _channelRepository = channelRepository;
        }
        public void DeleteChannel(Channel channel)
        {
            if (channel == null)
                return; 
            _channelRepository.Delete(channel);

        }

        public IList<Channel> GetAllChannels(string keywords = "", string channelCode = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _channelRepository.GetAll();
            return query.ToList();
        }

        public Channel GetChannelById(int channelId)
        {
            if (channelId == 0)
                return null;  
            var query =_channelRepository.GetById(channelId);  
            return query;
        }

        public Channel GetChannelById(string channelCode)
        {
            if (string.IsNullOrEmpty(channelCode))
                return null;
            var predicate = Predicates.Field<Channel>(f => f.ChannelCode, Operator.Eq, channelCode);
            IEnumerable<Channel> query = _channelRepository.GetList(predicate);

            var channel = query.FirstOrDefault(); 
          
            return channel;
        }

        public void InsertChannel(Channel channel)
        {
            if (channel == null)
                throw new ArgumentNullException("channel");

            channel.ChannelName = CommonHelper.EnsureNotNull(channel.ChannelName);
            channel.ChannelName = CommonHelper.EnsureMaximumLength(channel.ChannelName, 400);
            _channelRepository.Insert(channel);
        }

        public void UpdateChannel(Channel channel)
        {
            if (channel == null)
                throw new ArgumentNullException("channel"); 
            channel.ChannelName = CommonHelper.EnsureNotNull(channel.ChannelName);
            channel.ChannelName = CommonHelper.EnsureMaximumLength(channel.ChannelName, 400);
            _channelRepository.Update(channel);
        }
    }
}
