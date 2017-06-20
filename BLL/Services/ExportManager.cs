using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace BLL.Services
{
    public partial class ExportManager : IExportManager
    {
        private readonly IOrderService _orderService;
        private readonly IShopService _shopService;
        private readonly IChannelService _channelService;
        public ExportManager(IOrderService  orderService, IShopService shopService, IChannelService  channelService)
        {
            _orderService = orderService;
            _shopService = shopService;
            _channelService = channelService;
        }
        public byte[] ExportChannelToXlsx(IEnumerable<Channel> channels)
        { 
            var properties = new[]
           {
                new PropertyByName<Channel>("序号", p => p.ChannelId),
                new PropertyByName<Channel>("渠道名称", p => p.ChannelName),
                new PropertyByName<Channel>("渠道编码", p => p.ChannelCode),
                new PropertyByName<Channel>("渠道标签", p => p.ChannelLable), 
                new PropertyByName<Channel>("上级渠道", p =>_channelService.GetChannelById(p.ParentChannelId)?.ChannelName),
                new PropertyByName<Channel>("渠道链接", p =>p.ChannelUrl), 
                new PropertyByName<Channel>("企业号", p => p.ComId)
            };
            return ExportToXlsx(properties, channels);
        }

        public byte[] ExportOrdersToXlsx(IList<Order> orders)
        {
            var properties = new[]
          {
                new PropertyByName<Order>("序号", p => p.OrderId),
                new PropertyByName<Order>("订单编号", p => p.OrderNo),
                new PropertyByName<Order>("产品类型", p => p.ShopType),
               new PropertyByName<Order>("产品名称", p => p.ShopName),
                 new PropertyByName<Order>("产品价格", p => p.Price),
                new PropertyByName<Order>("佣金", p => p.Commission),
                new PropertyByName<Order>("客户名称", p => p.CustomerName),
                new PropertyByName<Order>("客户身份证", p => p.IdCard),
                new PropertyByName<Order>("客户电话", p => p.CustomerTel),
                new PropertyByName<Order>("客户地址", p => p.CustomerAddress),
                new PropertyByName<Order>("订单状态", p =>((OrderStatusEnum)p.OrderState).GetOrderStatusName()),
                new PropertyByName<Order>("付款状态", p =>((PaymentStatusEnum)p.PaymentStatus).GetPaymentStatusName()),
                new PropertyByName<Order>("企业号", p => p.ComId)
            };
            return ExportToXlsx(properties, orders);
        }

        public byte[] ExportProductsToXlsx(IEnumerable<Shop> products)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Export objects to XLSX
        /// </summary>  
        protected virtual byte[] ExportToXlsx<T>(PropertyByName<T>[] properties, IEnumerable<T> itemsToExport)
        {
            using (var stream = new MemoryStream())
            { 
                using (var xlPackage = new ExcelPackage(stream))
                { 
                    // get handles to the worksheets
                    var worksheet = xlPackage.Workbook.Worksheets.Add(typeof(T).Name);
                    var fWorksheet = xlPackage.Workbook.Worksheets.Add("DataForProductsFilters");
                    fWorksheet.Hidden = eWorkSheetHidden.VeryHidden;

                    //create Headers and format them 
                    var manager = new PropertyManager<T>(properties.Where(p => !p.Ignore).ToArray());
                    manager.WriteCaption(worksheet, SetCaptionStyle);

                    var row = 2;
                    foreach (var items in itemsToExport)
                    {
                        manager.CurrentObject = items;
                        manager.WriteToXlsx(worksheet, row++,fWorksheet: fWorksheet);
                    }

                    xlPackage.Save();
                }
                return stream.ToArray();
            }
        }
        protected virtual void SetCaptionStyle(ExcelStyle style)
        {
            style.Fill.PatternType = ExcelFillStyle.Solid;
            style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
            style.Font.Bold = true;
        }

    }
}
