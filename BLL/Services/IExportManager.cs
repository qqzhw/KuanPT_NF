using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public partial interface IExportManager
    {

        byte[] ExportChannelToXlsx(IEnumerable<Channel> channels);

        byte[] ExportProductsToXlsx(IEnumerable<Shop> products);

        byte[] ExportOrdersToXlsx(IList<Order> orders);

        byte[] ExportChannelDataToXlsx(IList<ChannelData> channelDatas);

    }
}