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
                new PropertyByName<Channel>("ChannelId", p => p.ChannelId),
                new PropertyByName<Channel>("ChannelName", p => p.ChannelName),
                new PropertyByName<Channel>("ChannelCode", p => p.ChannelCode),
                new PropertyByName<Channel>("ChannelLable", p => p.ChannelLable), 
                new PropertyByName<Channel>("ParentChannelId", p => p.ParentChannelId),
                new PropertyByName<Channel>("ChannelUrl", p =>p.ChannelUrl), 
                new PropertyByName<Channel>("ComId", p => p.ComId)
            };
            return ExportToXlsx(properties, channels);
        }

        public byte[] ExportOrdersToXlsx(IList<Order> orders)
        {
            var properties = new[]
          {
                new PropertyByName<Order>("OrderId", p => p.OrderId),
                new PropertyByName<Order>("OrderNo", p => p.OrderNo),
                new PropertyByName<Order>("CustomerName", p => p.CustomerName),
                new PropertyByName<Order>("CustomerTel", p => p.CustomerTel),
                new PropertyByName<Order>("CustomerAddress", p => p.CustomerAddress),
                new PropertyByName<Order>("OrderState", p =>((OrderStatusEnum)p.OrderState).GetOrderStatusName()),
                new PropertyByName<Order>("ComId", p => p.ComId)
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
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="properties">Class access to the object through its properties</param>
        /// <param name="itemsToExport">The objects to export</param>
        /// <returns></returns>
        protected virtual byte[] ExportToXlsx<T>(PropertyByName<T>[] properties, IEnumerable<T> itemsToExport)
        {
            using (var stream = new MemoryStream())
            {
                // ok, we can run the real code of the sample now
                using (var xlPackage = new ExcelPackage(stream))
                {
                    // uncomment this line if you want the XML written out to the outputDir
                    //xlPackage.DebugMode = true; 

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
