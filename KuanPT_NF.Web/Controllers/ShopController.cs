﻿using BLL.Services;
using KuanPT_NF.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KuanPT_NF.Web.Controllers
{
    public class ShopController : Controller
    {
        //
        // GET: /Shop/
        private readonly IShopService _shopService;
        public ShopController(IShopService  shopService)
        {
            _shopService = shopService;
        }
        public ActionResult Index()
        {
            var items = _shopService.GetAllProducts(1).Select(o => new ShopModel()
            {
                Commission = o.Commission,
                CreateDate = o.CreateDate,
                Description = o.Description,
                DisplayOrder = o.DisplayOrder,
                Img = o.Img,
                Price = o.Price,
                Remark = o.Remark,
                ShopId = o.ShopId,
                ShopName = o.ShopName,
                ShopType = o.ShopType,
                ShortDescription = o.ShortDescription,
                ShowOnHomePage = o.ShowOnHomePage,
            }).OrderBy(o=>o.ShopName).ThenBy(o=>o.Price).ToList();
            return View(items); 
        }
        public ActionResult List()
        {
            var items = _shopService.GetAllProducts(1).Select(o => new ShopModel()
            {
                Commission = o.Commission,
                CreateDate = o.CreateDate,
                Description = o.Description,
                DisplayOrder = o.DisplayOrder,
                Img = o.Img,
                Price = o.Price,
                Remark = o.Remark,
                ShopId = o.ShopId,
                ShopName = o.ShopName,
                ShopType = o.ShopType,
                ShortDescription = o.ShortDescription,
                ShowOnHomePage = o.ShowOnHomePage,
            }).OrderBy(o => o.ShopName).ToList(); 
            return View(items);
        }
        public ActionResult Detail(int Id)
        {
            var model = new ShopModel();
            var item = _shopService.GetProductById(Id);
            model.Commission = item.Commission;
            model.Description = item.Description;
            model.Img = item.Img;
            model.Price = item.Price;
            model.Remark = item.Remark;
            model.ShopId = item.ShopId;
            model.ShopName = item.ShopName;
            model.ShortDescription = item.ShortDescription;
            model.ShopType = item.ShopType;
            return View(model);
        }
    }
}
