﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMCustSys.Model;
using IMCustSys.DAL;
using IMCustSys.Common;
using DapperExtensions;
using IMCustSys.BLL.Caching;

namespace IMCustSys.BLL.Services
{
    public class ChannelService : IChannelService
    {
        #region Fields 
        private readonly IRepository<Channel> _channelRepository;
        private readonly IRepository<ChannelData> _channelDataRepository;
        //private readonly ICacheManager _cacheManager; 
        #endregion
        public ChannelService(IRepository<Channel>  channelRepository,IRepository<ChannelData>  channelDataRepository)
        {
            _channelRepository = channelRepository;
            _channelDataRepository = channelDataRepository;
        }
        public string CurrentItem { get; set; }
        public void DeleteChannel(Channel channel)
        {
            if (channel == null)
                return; 
            _channelRepository.Delete(channel);

        }

        public IList<Channel> GetAllChannels(string comId="", string keywords = "", string channelCode = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var pgMain = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
            var pgb = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            if (!string.IsNullOrEmpty(comId))
            {
                pgb.Predicates.Add(Predicates.Field<Channel>(f => f.ComId, Operator.Eq, comId));
            }
            pgMain.Predicates.Add(pgb);
            if (!string.IsNullOrEmpty(keywords))
            {
                pgb.Predicates.Add(Predicates.Field<Channel>(p => p.ChannelName, Operator.Like, "%" + keywords + "%"));
            } 
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "Published",Ascending = false }
            };
            var query = _channelRepository.GetList(pgMain, sortItems);
            return query.ToList(); 
        }

        public Channel GetChannelById(int channelId)
        {
            if (channelId == 0)
                return null;  
            var query =_channelRepository.GetById(channelId);  
            return query;
        }

        public Channel  GetChannelByCode(string channelCode)
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

        public void InsertChannelData(ChannelData channelData)
        {
            if (channelData == null)
                throw new ArgumentNullException("channelData"); 
            _channelDataRepository.Insert(channelData);
        }

        public void UpdateChannelData(ChannelData channelData)
        {
            if (channelData == null)
                throw new ArgumentNullException("channelData");
            _channelDataRepository.Update(channelData);
        }

        public void DeleteChannelData(ChannelData channelData)
        {
            if (channelData == null)
                return;
            _channelDataRepository.Delete(channelData);
        }

        public ChannelData GetChannelDataById(int channelDataId)
        {
            if (channelDataId==0)
                return null;
            return _channelDataRepository.GetById(channelDataId);
        }

        public IList<ChannelData> GetAllChannelDatas(string channelName = "")
        {
            object predicate = null;
            if (!string.IsNullOrEmpty(channelName))
            {
                predicate = Predicates.Field<ChannelData>(p => p.ChannelName, Operator.Like, "%" + channelName + "%");
            }
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "ChannelName",Ascending = true }
            };
            var query = _channelDataRepository.GetList(predicate, sortItems);
            return query.ToList();
        }

        public IList<ChannelData> GetAllChannelDatas(string channelName = "", DateTime? beginTime = default(DateTime?), DateTime? endTime = default(DateTime?))
        {
            var pgMain = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
            var pgb = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            if (beginTime != null)
            {
                pgb.Predicates.Add(Predicates.Field<ChannelData>(f => f.CreatedDate, Operator.Ge, beginTime));
            }
            if (endTime != null)
            {
                pgb.Predicates.Add(Predicates.Field<ChannelData>(f => f.CreatedDate, Operator.Le, endTime));
            } 
           
            if (!string.IsNullOrEmpty(channelName))
            {
                pgb.Predicates.Add(Predicates.Field<ChannelData>(f => f.ChannelName, Operator.Like, "%" + channelName + "%"));
            }
            pgMain.Predicates.Add(pgb);
            var query = _channelDataRepository.GetList(pgMain);
            return query.ToList();
        }
    }
}
