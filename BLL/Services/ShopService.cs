using IMCustSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMCustSys.DAL;
using DapperExtensions;
using IMCustSys.BLL.Caching;

namespace IMCustSys.BLL.Services
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
            var predicate = Predicates.Field<Shop>(p => p.State, Operator.Eq, 1);
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "DisplayOrder", Ascending = true }
            };
            var query = _shopInfoRepository.GetList(predicate,sort:sortItems);
            return query.ToList();
        }
        public List<Shop> GetAllHotProducts()
        {  
            var pgMain = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
            var pgb = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pgb.Predicates.Add(Predicates.Field<Shop>(f => f.IsHotShop, Operator.Eq, true));
            pgb.Predicates.Add(Predicates.Field<Shop>(f => f.State, Operator.Eq, 1));
            pgMain.Predicates.Add(pgb);
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "DisplayOrder", Ascending = true }
            };
            var query = _shopInfoRepository.GetList(pgMain, sortItems);
            return query.ToList();
        }
        public List<Shop> GetAllProducts(string comId="", int? showHidden=null)
        {
            var pgMain = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
            var pgb = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            if (!string.IsNullOrEmpty(comId))
            {
                pgb.Predicates.Add(Predicates.Field<Shop>(f => f.ComId, Operator.Eq, comId));
            }
            if (showHidden!=null)
            {
                pgb.Predicates.Add(Predicates.Field<Shop>(f => f.State, Operator.Eq, showHidden));
            }
            
            pgMain.Predicates.Add(pgb);

            var predicate = Predicates.Field<Shop>(p => p.State, Operator.Eq, showHidden);
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "ShopName", Ascending = true },
                new Sort { PropertyName = "DisplayOrder", Ascending = true }, 
            };
            var query = _shopInfoRepository.GetList(predicate, sortItems);
            return query.ToList();
        }
         
        public List<Shop> GetAllProductsDisplayedOnHomePage()
        { 
            var pgMain = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
            var pgb = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
             
            pgb.Predicates.Add(Predicates.Field<Shop>(f => f.ShowOnHomePage, Operator.Eq, true));
            pgb.Predicates.Add(Predicates.Field<Shop>(f => f.State, Operator.Eq, 1));
            pgMain.Predicates.Add(pgb);
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "DisplayOrder", Ascending = true }
            };
            var query = _shopInfoRepository.GetList(pgMain, sortItems);
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
           
        public List<Shop> GetAllProducts(int? categoryId = default(int?), string comId = "", string keywords = "", int? state = default(int?), bool? featuredProducts = default(bool?))
        { 
            if (categoryId.HasValue)
                categoryId = (int)categoryId.Value;
             
            var pgMain = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
            var pgb = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            if (categoryId != null&&categoryId>0)
            {
                pgb.Predicates.Add(Predicates.Field<Shop>(f => f.CategoryId, Operator.Eq, categoryId));
            }
            if (!string.IsNullOrEmpty(comId))
            {
                pgb.Predicates.Add(Predicates.Field<Shop>(f => f.ComId, Operator.Eq, comId));
            }
            if (state != null)
            {
                pgb.Predicates.Add(Predicates.Field<Shop>(f => f.State, Operator.Eq, state));
            }
            if (featuredProducts != null)
            {
                pgb.Predicates.Add(Predicates.Field<Shop>(f => f.IsHotShop, Operator.Eq, featuredProducts));
            }
            if (!string.IsNullOrEmpty(comId))
            {
                pgb.Predicates.Add(Predicates.Field<Shop>(f => f.ComId, Operator.Eq, comId));
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                pgb.Predicates.Add(Predicates.Field<Shop>(f => f.ShopName, Operator.Like, "%" + keywords + "%"));
            }
            pgMain.Predicates.Add(pgb);
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "ShopName", Ascending = true },
                new Sort { PropertyName = "DisplayOrder", Ascending = true },
            };
            IEnumerable<Shop> list = _shopInfoRepository.GetList(pgMain,sortItems);
            return list.ToList();
        }
    }
}
