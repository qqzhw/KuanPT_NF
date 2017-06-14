using Model;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public interface IShopService
    {
        #region Products


        void MarkProductAsDeleted(int productId);


        List<Shop> GetAllProducts();

       
        List<Shop> GetAllProducts(bool showHidden);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Product collection</returns>
        List<Shop> GetAllProducts(int pageSize, int pageIndex,
            out int totalRecords);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="categoryId">Category identifier</param> 
        /// <param name="featuredProducts">A value indicating whether loaded products are marked as featured (relates only to categories and manufacturers). 0 to load featured products only, 1 to load not featured products only, null to load all products</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Product collection</returns>
        List<Shop> GetAllProducts(int categoryId,
           bool? featuredProducts,  int pageSize, int pageIndex, out int totalRecords);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="keywords">Keywords</param>
        /// <param name="searchDescriptions">A value indicating whether to search in descriptions</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Product collection</returns>
        List<Shop> GetAllProducts(string keywords,
            bool searchDescriptions, int pageSize, int pageIndex, out int totalRecords);

        
        List<Shop> GetAllProducts(int categoryId,
             bool? featuredProducts,  string keywords, bool searchDescriptions, int pageSize,
            int pageIndex, List<int> filteredSpecs, out int totalRecords);
 
        List<Shop> GetAllProducts(int categoryId,
            bool? featuredProducts,  decimal? priceMin, decimal? priceMax, int pageSize,
            int pageIndex, List<int> filteredSpecs, out int totalRecords);

        
        List<Shop> GetAllProducts(int categoryId,  bool? featuredProducts,
            decimal? priceMin, decimal? priceMax, string keywords,
            bool searchDescriptions, int pageSize, int pageIndex,
            List<int> filteredSpecs, out int totalRecords);
       
        List<Shop> GetAllProducts(int categoryId,
           bool? featuredProducts,  decimal? priceMin, decimal? priceMax, string keywords,
            bool searchDescriptions, int pageSize, int pageIndex,
              ProductSortingEnum orderBy, out int totalRecords); 
        
        List<Shop> GetAllProducts(int categoryId,
            bool? featuredProducts, decimal? priceMin, decimal? priceMax,
            string keywords, bool searchDescriptions, int pageSize,
            int pageIndex, List<int> filteredSpecs,    ProductSortingEnum orderBy, out int totalRecords);
          
       
        List<Shop> GetAllProductsDisplayedOnHomePage();

        
        Shop GetProductById(int productId);

        
        void InsertProduct(Shop product);

        
        void UpdateProduct(Shop product);
         
        #endregion

        #region Product pictures


        void DeleteProductPicture(int productPictureId);


        ProductPicture GetProductPictureById(int productPictureId);

        /// <summary>
        /// Inserts a product picture mapping
        /// </summary>
        /// <param name="productPicture">Product picture mapping</param>
        void InsertProductPicture(ProductPicture productPicture);

        /// <summary>
        /// Updates the product picture mapping
        /// </summary>
        /// <param name="productPicture">Product picture mapping</param>
        void UpdateProductPicture(ProductPicture productPicture);

        /// <summary>
        /// Gets all product picture mappings by product identifier
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product picture mapping collection</returns>
        List<ProductPicture> GetProductPicturesByProductId(int productId);
        #endregion



    }
}
