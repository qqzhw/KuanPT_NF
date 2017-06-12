using System;
using System.Collections.Generic;
using System.Linq; 
using Common;
using Model;
using BLL.Caching;
using DAL;
using DapperExtensions;
using System.Data;
using Dapper;
namespace BLL.Services
{
    /// <summary>
    /// Category service
    /// </summary>
    public partial class CategoryService : ICategoryService
    {
        #region Constants
        private const string CATEGORIES_BY_ID_KEY = "Kpt.category.id-{0}";
        private const string PRODUCTCATEGORIES_ALLBYCATEGORYID_KEY = "Kpt.productcategory.allbycategoryid-{0}-{1}";
        private const string PRODUCTCATEGORIES_ALLBYPRODUCTID_KEY = "Kpt.productcategory.allbyproductid-{0}-{1}";
        private const string PRODUCTCATEGORIES_BY_ID_KEY = "Kpt.productcategory.id-{0}";
        private const string CATEGORIES_PATTERN_KEY = "Kpt.category.";
        private const string PRODUCTCATEGORIES_PATTERN_KEY = "Kpt.productcategory.";

        #endregion

        #region Fields 
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<ShopCategory> _shopcategoryRepository;
        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion
        
        #region Ctor

      
        public CategoryService(IRepository<Category> categoryRepository, IRepository<ShopCategory>  shopcategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _shopcategoryRepository = shopcategoryRepository;
            this._cacheManager = new KptRequestCache(); 
        }

        #endregion

        #region Methods
         
        /// <summary>
        /// 标记为删除
        /// </summary>
        /// <param name="categoryId"></param>
        public void MarkCategoryAsDeleted(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            if (category != null)
            {
                category.Deleted = true;
                UpdateCategory(category);
            }
        }

      
        public List<Category> GetAllCategories()
        { 
            return GetAllCategories(true);
        }
        
       
        public List<Category> GetAllCategories(bool showHidden)
        {
            var query = _categoryRepository.GetAll().Where(o => o.Published).OrderBy(o => o.Published).ThenBy(o => o.DisplayOrder);
            //var query = from c in _context.Categories
            //            orderby c.ParentCategoryId, c.DisplayOrder
            //            where (showHidden || c.Published) &&
            //            !c.Deleted
            //            select c;

            ////filter by access control list (public store)
            //if (!showHidden)
            //{
            //    query = query.WhereAclPerObjectNotDenied(_context);
            //}
            var unsortedCategories = query.ToList();

            ////sort categories
            ////TODO sort categories on database layer
            var sortedCategories = unsortedCategories.SortCategoriesForTree(0);

            return sortedCategories; 
        }
        
       
        public List<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId)
        { 
            return GetAllCategoriesByParentCategoryId(parentCategoryId, true);
        }
        
      
        public List<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId,
            bool showHidden)
        {
            IList<IPredicate> predList = new List<IPredicate>
            {
                Predicates.Field<Category>(p => p.ParentCategoryId, Operator.Eq, parentCategoryId),
                Predicates.Field<Category>(f => f.Published, Operator.Eq, true)
            };
            IPredicateGroup predGroup = Predicates.Group(GroupOperator.And, predList.ToArray());
             
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "DisplayOrder", Ascending = true }
            };
            var query = _categoryRepository.GetList(predGroup, sortItems); 

             var categories = query.ToList();
             return categories;
           
        }
        
      
        public List<Category> GetAllCategoriesDisplayedOnHomePage()
        { 
            IList<IPredicate> predList = new List<IPredicate>
            {
                Predicates.Field<Category>(p => p.ShowOnHomePage, Operator.Eq, true),
                Predicates.Field<Category>(f => f.Published, Operator.Eq, true)
            };
            IPredicateGroup predGroup = Predicates.Group(GroupOperator.And, predList.ToArray());
             
            IList<ISort> sortItems = new List<ISort>
            {
                new Sort { PropertyName = "DisplayOrder", Ascending = true }
            };
            var query = _categoryRepository.GetList(predGroup, sortItems);
             
            var categories = query.ToList();
            return categories;
             
        }


        public Category GetCategoryById(int categoryId)
        {
            if (categoryId == 0)
                return null;

            string key = string.Format(CATEGORIES_BY_ID_KEY, categoryId);
            object obj= _cacheManager.Get(key);
            if (obj != null)
            {
                return (Category)obj;
            }
            var category = _categoryRepository.GetById(categoryId);
            _cacheManager.Add(key, category);
            return category;
        }

       
        public List<Category> GetBreadCrumb(int categoryId)
        {
            var breadCrumb = new List<Category>();

            var category = GetCategoryById(categoryId);

            while (category != null &&!category.Deleted &&category.Published)  
            {
                breadCrumb.Add(category);
               //  category = category.ParentCategory;
            }
            breadCrumb.Reverse();
            return breadCrumb;
        }

        /// <summary>
        /// Inserts category
        /// </summary>
        /// <param name="category">Category</param>
        public void InsertCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            category.CategoryName = CommonHelper.EnsureNotNull(category.CategoryName);
            category.CategoryName = CommonHelper.EnsureMaximumLength(category.CategoryName, 400);
            category.Description = CommonHelper.EnsureNotNull(category.Description);
            _categoryRepository.Insert(category);
        }

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="category">Category</param>
        public void UpdateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            category.CategoryName = CommonHelper.EnsureNotNull(category.CategoryName);
            category.CategoryName = CommonHelper.EnsureMaximumLength(category.CategoryName, 400);
            category.Description = CommonHelper.EnsureNotNull(category.Description);

            //validate category hierarchy
            var parentCategory = GetCategoryById(category.ParentCategoryId);
            while (parentCategory != null)
            {
                if (category.CategoryId == parentCategory.CategoryId)
                {
                    category.ParentCategoryId = 0;
                    break;
                }
                parentCategory = GetCategoryById(parentCategory.ParentCategoryId);
            }
             
            _cacheManager.RemoveByPattern(CATEGORIES_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCTCATEGORIES_PATTERN_KEY);
        }
          
        public void DeleteProductCategory(int productCategoryId)
        {
            if (productCategoryId == 0)
                return;

            var productCategory = GetProductCategoryById(productCategoryId);
            if (productCategory == null)
                return;
            _shopcategoryRepository.Delete(productCategory);            
        }

      
        public List<ShopCategory> GetProductCategoriesByCategoryId(int categoryId)
        {
            if (categoryId == 0)
                return new List<ShopCategory>();
            string key = string.Format(PRODUCTCATEGORIES_ALLBYCATEGORYID_KEY, true, categoryId);
            object obj2 = _cacheManager.Get(key);
            if (obj2 != null)
            {
                return (List<ShopCategory>)obj2;
            }
            List<ShopCategory> items = new List<ShopCategory>();
           string sql = @"SELECT *
                              from ShowCategories a
                               join Products b on a.ProductId = b.ProductId
                              where a.CategoryId == categoryId and
                        b.Deleted=false and   b.Published=true 
                        orderby a.DisplayOrder ";
            var infos = _shopcategoryRepository.DbContext.Query<ShopCategory,Shop_ShopInfo,ShopCategory>(sql,(s,p)=> {
                var currentItem = items.Find(x => x.Id == s.Id);
                if (currentItem==null)
                {
                   
                }
                return null;
            },splitOn: "ShopId");
            //var infos = connecton.Query<Client, ClientField, Client>(sql, (c, f) =>
            //{
            //    var currentClient = clients.Find(x => x.ClientId == c.ClientId);
            //    if (currentClient == null)
            //    {
            //        c.Fields.Add(f);
            //        clients.Add(c);
            //        return c;
            //    }
            //    else
            //    {
            //        currentClient.Fields.Add(f);
            //        return currentClient;
            //    }
            //}, splitOn: "ModelId");
            //var query = from pc in _context.ProductCategories
            //            join p in _context.Products on pc.ProductId equals p.ProductId
            //            where pc.CategoryId == categoryId &&
            //            !p.Deleted &&
            //            (p.Published)
            //            orderby pc.DisplayOrder
            //            select pc;


            //var productCategories = query.ToList();


            //   _cacheManager.Add(key, productCategories);

            //  return productCategories;
            return null;
        }

        /// <summary>
        /// Gets a product category mapping collection
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product category mapping collection</returns>
        public List<ShopCategory> GetProductCategoriesByProductId(int productId)
        {
            if (productId == 0)
                return new List<ShopCategory>();


            //string key = string.Format(PRODUCTCATEGORIES_ALLBYPRODUCTID_KEY,   productId);
            //object obj2 = _cacheManager.Get(key);

            //var query = from pc in _context.ProductCategories
            //            join c in _context.Categories on pc.CategoryId equals c.CategoryId
            //            where pc.ProductId == productId &&
            //            !c.Deleted && (c.Published)
            //            orderby pc.DisplayOrder
            //            select pc;
            //var productCategories = query.ToList(); 
            //return productCategories;
            return null;
        }
         
        public ShopCategory GetProductCategoryById(int productCategoryId)
        {
            if (productCategoryId == 0)
                return null;

            string key = string.Format(PRODUCTCATEGORIES_BY_ID_KEY, productCategoryId);
            object obj2 = _cacheManager.Get(key);
            if (obj2!=null)
            {
                return (ShopCategory)obj2;
            }
            var query = _shopcategoryRepository.GetById(productCategoryId);
                
            return query;
           
        }
         
        public void InsertProductCategory(ShopCategory productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("productCategory");
            _shopcategoryRepository.Insert(productCategory); 
        }

        /// <summary>
        /// Updates the product category mapping 
        /// </summary>
        /// <param name="productCategory">>Product category mapping</param>
        public void UpdateProductCategory(ShopCategory productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("productCategory");
            _shopcategoryRepository.Update(productCategory);
        }
        #endregion
        
        
    }
}
