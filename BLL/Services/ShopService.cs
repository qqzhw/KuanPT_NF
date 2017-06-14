using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using BLL.Caching;
using DAL;

namespace BLL.Services
{
    public class ShopService : IShopService
    {
        #region Constants
        private const string PRODUCTS_BY_ID_KEY = "Nop.product.id-{0}";
        private const string PRODUCTVARIANTS_ALL_KEY = "Nop.productvariant.all-{0}-{1}";
        private const string PRODUCTVARIANTS_BY_ID_KEY = "Nop.productvariant.id-{0}";
        private const string TIERPRICES_ALLBYPRODUCTVARIANTID_KEY = "Nop.tierprice.allbyproductvariantid-{0}";
        private const string CUSTOMERROLEPRICES_ALL_KEY = "Nop.customerroleproductprice.all-{0}";
        private const string PRODUCTS_PATTERN_KEY = "Nop.product.";
        private const string PRODUCTVARIANTS_PATTERN_KEY = "Nop.productvariant.";
        private const string TIERPRICES_PATTERN_KEY = "Nop.tierprice.";
        private const string CUSTOMERROLEPRICES_PATTERN_KEY = "Nop.customerroleproductprice.";
        #endregion

        #region Fields  
        private readonly ICacheManager _cacheManager;
        private readonly IRepository<Shop> _shopInfoRepository; 
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<ShopCategory> _shopcategoryRepository;
        #endregion

        #region Ctor

        public ShopService(IRepository<Shop> shopInfoRepository, IRepository<Category> categoryRepository, IRepository<ShopCategory> shopcategoryRepository)
        {
            _shopInfoRepository = shopInfoRepository;
            _categoryRepository = categoryRepository;
            _shopcategoryRepository = shopcategoryRepository;
            this._cacheManager = new KptRequestCache();
        }

        #endregion

        public void DeleteProductPicture(int productPictureId)
        {
            throw new NotImplementedException();
        }

        public List<Shop> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<Shop> GetAllProducts(bool showHidden)
        {
            throw new NotImplementedException();
        }

        public List<Shop> GetAllProducts(int pageSize, int pageIndex, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Shop> GetAllProducts(int categoryId, bool? featuredProducts, int pageSize, int pageIndex, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Shop> GetAllProducts(string keywords, bool searchDescriptions, int pageSize, int pageIndex, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Shop> GetAllProducts(int categoryId, bool? featuredProducts, string keywords, bool searchDescriptions, int pageSize, int pageIndex, List<int> filteredSpecs, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Shop> GetAllProducts(int categoryId, bool? featuredProducts, decimal? priceMin, decimal? priceMax, int pageSize, int pageIndex, List<int> filteredSpecs, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Shop> GetAllProducts(int categoryId, bool? featuredProducts, decimal? priceMin, decimal? priceMax, string keywords, bool searchDescriptions, int pageSize, int pageIndex, List<int> filteredSpecs, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Shop> GetAllProducts(int categoryId, bool? featuredProducts, decimal? priceMin, decimal? priceMax, string keywords, bool searchDescriptions, int pageSize, int pageIndex, ProductSortingEnum orderBy, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Shop> GetAllProducts(int categoryId, bool? featuredProducts, decimal? priceMin, decimal? priceMax, string keywords, bool searchDescriptions, int pageSize, int pageIndex, List<int> filteredSpecs, ProductSortingEnum orderBy, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public List<Shop> GetAllProductsDisplayedOnHomePage()
        {
            throw new NotImplementedException();
        }

        public Shop GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public ProductPicture GetProductPictureById(int productPictureId)
        {
            throw new NotImplementedException();
        }

        public List<ProductPicture> GetProductPicturesByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public void InsertProduct(Shop product)
        {
            if (product == null)
                throw new ArgumentNullException("product");
            //var model = GetCategoryByName(category.CategoryName);
            //if (model != null)
            //{
            //    return;
            //}
            _shopInfoRepository.Insert(product);
        }

        public void InsertProductPicture(ProductPicture productPicture)
        {
            throw new NotImplementedException();
        }

        public void MarkProductAsDeleted(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Shop product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductPicture(ProductPicture productPicture)
        {
            throw new NotImplementedException();
        }
    }
}
