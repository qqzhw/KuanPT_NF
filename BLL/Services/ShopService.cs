using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using BLL.Caching;
using DAL;
using DapperExtensions;

namespace BLL.Services
{
    public class ShopService : IShopService
    {
        #region Constants
        private const string PRODUCTS_BY_ID_KEY = "kpt.product.id-{0}";  
        private const string PRODUCTS_PATTERN_KEY = "kpt.product."; 
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
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "DisplayOrder", Ascending = true }
            };
            var query = _shopInfoRepository.GetList(sort:sortItems);
            return query.ToList();
        }
        public List<Shop> GetAllHotProducts()
        { 
            var predicate = Predicates.Field<Shop>(p => p.IsHotShop, Operator.Eq, true);
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "DisplayOrder", Ascending = true }
            };
            var query = _shopInfoRepository.GetList(predicate, sortItems);
            return query.ToList();
        }
        public List<Shop> GetAllProducts(int showHidden)
        { 
            var predicate = Predicates.Field<Shop>(p => p.State, Operator.Eq, showHidden);
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "ShopName", Ascending = true },
                new Sort { PropertyName = "DisplayOrder", Ascending = true }, 
            };
            var query = _shopInfoRepository.GetList(predicate, sortItems);
            return query.ToList();
        }

        public List<Shop> GetAllProducts( int pageIndex, int pageSize,out int totalRecords,out int totalPage)
        { 
            var query = _shopInfoRepository.GetPageData("Shop","ShopId",out totalRecords,out totalPage,pageIndex:pageIndex,pageSize:pageSize);
            return query.ToList();
        }

       

        public List<Shop> GetAllProducts(string keywords, bool searchDescriptions  )
        {
            throw new NotImplementedException();
        }

         
        public List<Shop> GetAllProductsDisplayedOnHomePage()
        {
            IList<IPredicate> predList = new List<IPredicate>
            {
                Predicates.Field<Shop>(p => p.ShowOnHomePage, Operator.Eq, true),
               // Predicates.Field<Shop>(p=>p.State, Operator.Eq, 1)
            };
            var predicate = Predicates.Field<Shop>(p => p.ShowOnHomePage, Operator.Eq, true);
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "DisplayOrder", Ascending = true }
            };
            var query = _shopInfoRepository.GetList(predicate, sortItems);
            return query.Take(4).ToList(); 
        }

        public Shop GetProductById(int productId)
        {
            if (productId == 0)
                return null;
            var shop = _shopInfoRepository.GetById(productId);
            return shop;
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
            if (productId == 0)
                return;
            var shop = _shopInfoRepository.GetById(productId);
            shop.State = 0;//产品下架
            _shopInfoRepository.Update(shop);
        }

        public void UpdateProduct(Shop product)
        {
            if (product ==null)
                return;
            _shopInfoRepository.Update(product);
        }

        public void UpdateProductPicture(ProductPicture productPicture)
        {
            throw new NotImplementedException();
        }
         

        public List<Shop> GetAllProducts(int? categoryId, bool? featuredProducts, string keywords = "", int? state = default(int?), bool? searchDescriptions = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public List<Shop> GetAllProducts(int categoryId, bool? featuredProducts)
        {
            throw new NotImplementedException();
        }
    }
}
