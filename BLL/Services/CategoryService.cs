using System;
using System.Collections.Generic;
using System.Linq; 
using Common;
using Model;

namespace BLL.Services
{
    /// <summary>
    /// Category service
    /// </summary>
    public partial class CategoryService : ICategoryService
    {
        #region Constants
        private const string CATEGORIES_BY_ID_KEY = "Nop.category.id-{0}";
        private const string PRODUCTCATEGORIES_ALLBYCATEGORYID_KEY = "Nop.productcategory.allbycategoryid-{0}-{1}";
        private const string PRODUCTCATEGORIES_ALLBYPRODUCTID_KEY = "Nop.productcategory.allbyproductid-{0}-{1}";
        private const string PRODUCTCATEGORIES_BY_ID_KEY = "Nop.productcategory.id-{0}";
        private const string CATEGORIES_PATTERN_KEY = "Nop.category.";
        private const string PRODUCTCATEGORIES_PATTERN_KEY = "Nop.productcategory.";

        #endregion

        #region Fields 
         
        /// <summary>
        /// Cache manager
        /// </summary>
       // private readonly ICacheManager _cacheManager;

        #endregion
        
        #region Ctor

      
        public CategoryService()
        {
            //this._context = context;
            //this._cacheManager = new NopRequestCache();
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
            //var unsortedCategories = query.ToList();

            ////sort categories
            ////TODO sort categories on database layer
            //var sortedCategories = unsortedCategories.SortCategoriesForTree(0);

            //return sortedCategories;
            return null;
        }
        
       
        public List<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId)
        { 
            return GetAllCategoriesByParentCategoryId(parentCategoryId, true);
        }
        
      
        public List<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId,
            bool showHidden)
        {

            //var query = from c in _context.Categories
            //            orderby c.DisplayOrder
            //            where (showHidden || c.Published) && 
            //            !c.Deleted && 
            //            c.ParentCategoryId == parentCategoryId
            //            select c;



            //var categories = query.ToList();
            //return categories;
            return null;
        }
        
      
        public List<Category> GetAllCategoriesDisplayedOnHomePage()
        {

            //var query = from c in _context.Categories
            //            orderby c.DisplayOrder
            //            where (showHidden || c.Published) && !c.Deleted && c.ShowOnHomePage
            //            select c;


            //var categories = query.ToList();
            //return categories;
            return null;
        }
                
        /// <summary>
        /// Gets a category
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Category</returns>
        public Category GetCategoryById(int categoryId)
        {
            if (categoryId == 0)
                return null;

            //string key = string.Format(CATEGORIES_BY_ID_KEY, categoryId);
            //object obj2 = _cacheManager.Get(key);
            //if (this.CategoriesCacheEnabled && (obj2 != null))
            //{
            //    return (Category)obj2;
            //}

            //bool showHidden = NopContext.Current.IsAdmin;


            //var query = from c in _context.Categories
            //            where c.CategoryId == categoryId
            //            select c;
            //var category = query.SingleOrDefault();

            ////filter by access control list (public store)
            //if (category != null && !showHidden && IsCategoryAccessDenied(category))
            //{
            //    category = null;
            //}
            //if (this.CategoriesCacheEnabled)
            //{
            //    _cacheManager.Add(key, category);
            //}
            //return category;
            return null;
        }

        /// <summary>
        /// Gets a category breadcrumb
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Category</returns>
        public List<Category> GetBreadCrumb(int categoryId)
        {
            var breadCrumb = new List<Category>();

            var category = GetCategoryById(categoryId);

            while (category != null && //category is not null
                !category.Deleted && //category is not deleted
                category.Published) //category is published
            {
                breadCrumb.Add(category);
             //   category = category.ParentCategory;
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
            
            //category.Name = CommonHelper.EnsureNotNull(category.Name);
            //category.Name = CommonHelper.EnsureMaximumLength(category.Name, 400);
            //category.Description = CommonHelper.EnsureNotNull(category.Description);
            //category.MetaKeywords = CommonHelper.EnsureNotNull(category.MetaKeywords);
            //category.MetaKeywords = CommonHelper.EnsureMaximumLength(category.MetaKeywords, 400);
            //category.MetaDescription = CommonHelper.EnsureNotNull(category.MetaDescription);
            //category.MetaDescription = CommonHelper.EnsureMaximumLength(category.MetaDescription, 4000);
            //category.MetaTitle = CommonHelper.EnsureNotNull(category.MetaTitle);
            //category.MetaTitle = CommonHelper.EnsureMaximumLength(category.MetaTitle, 400);
            //category.SEName = CommonHelper.EnsureNotNull(category.SEName);
            //category.SEName = CommonHelper.EnsureMaximumLength(category.SEName, 100);
            //category.PriceRanges = CommonHelper.EnsureNotNull(category.PriceRanges);
            //category.PriceRanges = CommonHelper.EnsureMaximumLength(category.PriceRanges, 400);
             
        }

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="category">Category</param>
        public void UpdateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            //category.Name = CommonHelper.EnsureNotNull(category.Name);
            //category.Name = CommonHelper.EnsureMaximumLength(category.Name, 400);
            //category.Description = CommonHelper.EnsureNotNull(category.Description);
            //category.MetaKeywords = CommonHelper.EnsureNotNull(category.MetaKeywords);
            //category.MetaKeywords = CommonHelper.EnsureMaximumLength(category.MetaKeywords, 400);
            //category.MetaDescription = CommonHelper.EnsureNotNull(category.MetaDescription);
            //category.MetaDescription = CommonHelper.EnsureMaximumLength(category.MetaDescription, 4000);
            //category.MetaTitle = CommonHelper.EnsureNotNull(category.MetaTitle);
            //category.MetaTitle = CommonHelper.EnsureMaximumLength(category.MetaTitle, 400);
            //category.SEName = CommonHelper.EnsureNotNull(category.SEName);
            //category.SEName = CommonHelper.EnsureMaximumLength(category.SEName, 100);
            //category.PriceRanges = CommonHelper.EnsureNotNull(category.PriceRanges);
            //category.PriceRanges = CommonHelper.EnsureMaximumLength(category.PriceRanges, 400);

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

            
            //if (!_context.IsAttached(category))
            //    _context.Categories.Attach(category);

            //_context.SaveChanges();

            //if (this.CategoriesCacheEnabled || this.MappingsCacheEnabled)
            //{
            //    _cacheManager.RemoveByPattern(CATEGORIES_PATTERN_KEY);
            //    _cacheManager.RemoveByPattern(PRODUCTCATEGORIES_PATTERN_KEY);
            //}
        }
         
        /// <summary>
        /// Deletes a product category mapping
        /// </summary>
        /// <param name="productCategoryId">Product category identifier</param>
        public void DeleteProductCategory(int productCategoryId)
        {
            if (productCategoryId == 0)
                return;

            var productCategory = GetProductCategoryById(productCategoryId);
            if (productCategory == null)
                return;

            
            //if (!_context.IsAttached(productCategory))
            //    _context.ProductCategories.Attach(productCategory);
            //_context.DeleteObject(productCategory);
            //_context.SaveChanges(); 
        }

        /// <summary>
        /// Gets product category mapping collection
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Product a category mapping collection</returns>
        public List<ShopCategory> GetProductCategoriesByCategoryId(int categoryId)
        {
            //if (categoryId == 0)
            //    return new List<ProductCategory>(); 
            //string key = string.Format(PRODUCTCATEGORIES_ALLBYCATEGORYID_KEY, true, categoryId);
            //object obj2 = _cacheManager.Get(key); 
            //var query = from pc in _context.ProductCategories
            //            join p in _context.Products on pc.ProductId equals p.ProductId
            //            where pc.CategoryId == categoryId &&
            //            !p.Deleted &&
            //            (p.Published)
            //            orderby pc.DisplayOrder
            //            select pc;
            //var productCategories = query.ToList();

            //if (this.MappingsCacheEnabled)
            //{
            //    _cacheManager.Add(key, productCategories);
            //}
            // return productCategories;
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

        /// <summary>
        /// Gets a product category mapping 
        /// </summary>
        /// <param name="productCategoryId">Product category mapping identifier</param>
        /// <returns>Product category mapping</returns>
        public ShopCategory GetProductCategoryById(int productCategoryId)
        {
            if (productCategoryId == 0)
                return null;

            //string key = string.Format(PRODUCTCATEGORIES_BY_ID_KEY, productCategoryId);
            //object obj2 = _cacheManager.Get(key); 

            //var query = from pc in _context.ProductCategories
            //            where pc.ProductCategoryId == productCategoryId
            //            select pc;
            //var productCategory = query.SingleOrDefault();


            //return productCategory;
            return null;
        }

        /// <summary>
        /// Inserts a product category mapping
        /// </summary>
        /// <param name="productCategory">>Product category mapping</param>
        public void InsertProductCategory(ShopCategory productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("productCategory");

            
            
          //  _context.ProductCategories.AddObject(productCategory);
           // _context.SaveChanges();

         
        }

        /// <summary>
        /// Updates the product category mapping 
        /// </summary>
        /// <param name="productCategory">>Product category mapping</param>
        public void UpdateProductCategory(ShopCategory productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("productCategory");
             
        }
        #endregion
        
        
    }
}
