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


        List<Shop_ShopInfo> GetAllProducts();

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Product collection</returns>
        List<Shop_ShopInfo> GetAllProducts(bool showHidden);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Product collection</returns>
        List<Shop_ShopInfo> GetAllProducts(int pageSize, int pageIndex,
            out int totalRecords);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="manufacturerId">Manufacturer identifier</param>
        /// <param name="productTagId">Product tag identifier</param>
        /// <param name="featuredProducts">A value indicating whether loaded products are marked as featured (relates only to categories and manufacturers). 0 to load featured products only, 1 to load not featured products only, null to load all products</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Product collection</returns>
        List<Shop_ShopInfo> GetAllProducts(int categoryId,
            int manufacturerId, int productTagId, bool? featuredProducts,
            int pageSize, int pageIndex, out int totalRecords);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="keywords">Keywords</param>
        /// <param name="searchDescriptions">A value indicating whether to search in descriptions</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Product collection</returns>
        List<Shop_ShopInfo> GetAllProducts(string keywords,
            bool searchDescriptions, int pageSize, int pageIndex, out int totalRecords);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="manufacturerId">Manufacturer identifier</param>
        /// <param name="productTagId">Product tag identifier</param>
        /// <param name="featuredProducts">A value indicating whether loaded products are marked as featured (relates only to categories and manufacturers). 0 to load featured products only, 1 to load not featured products only, null to load all products</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="searchDescriptions">A value indicating whether to search in descriptions</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="filteredSpecs">Filtered product specification identifiers</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Product collection</returns>
        List<Shop_ShopInfo> GetAllProducts(int categoryId,
            int manufacturerId, int productTagId, bool? featuredProducts,
            string keywords, bool searchDescriptions, int pageSize,
            int pageIndex, List<int> filteredSpecs, out int totalRecords);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="manufacturerId">Manufacturer identifier</param>
        /// <param name="productTagId">Product tag identifier</param>
        /// <param name="featuredProducts">A value indicating whether loaded products are marked as featured (relates only to categories and manufacturers). 0 to load featured products only, 1 to load not featured products only, null to load all products</param>
        /// <param name="priceMin">Minimum price</param>
        /// <param name="priceMax">Maximum price</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="filteredSpecs">Filtered product specification identifiers</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Product collection</returns>
        List<Shop_ShopInfo> GetAllProducts(int categoryId,
            int manufacturerId, int productTagId, bool? featuredProducts,
            decimal? priceMin, decimal? priceMax, int pageSize,
            int pageIndex, List<int> filteredSpecs, out int totalRecords);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="manufacturerId">Manufacturer identifier</param>
        /// <param name="productTagId">Product tag identifier</param>
        /// <param name="featuredProducts">A value indicating whether loaded products are marked as featured (relates only to categories and manufacturers). 0 to load featured products only, 1 to load not featured products only, null to load all products</param>
        /// <param name="priceMin">Minimum price</param>
        /// <param name="priceMax">Maximum price</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="searchDescriptions">A value indicating whether to search in descriptions</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="filteredSpecs">Filtered product specification identifiers</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Product collection</returns>
        List<Shop_ShopInfo> GetAllProducts(int categoryId,
            int manufacturerId, int productTagId, bool? featuredProducts,
            decimal? priceMin, decimal? priceMax, string keywords,
            bool searchDescriptions, int pageSize, int pageIndex,
            List<int> filteredSpecs, out int totalRecords);
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="manufacturerId">Manufacturer identifier</param>
        /// <param name="productTagId">Product tag identifier</param>
        /// <param name="featuredProducts">A value indicating whether loaded products are marked as featured (relates only to categories and manufacturers). 0 to load featured products only, 1 to load not featured products only, null to load all products</param>
        /// <param name="priceMin">Minimum price</param>
        /// <param name="priceMax">Maximum price</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="searchDescriptions">A value indicating whether to search in descriptions</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="filteredSpecs">Filtered product specification identifiers</param>
        /// <param name="orderBy">Order by</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Product collection</returns>
        List<Shop_ShopInfo> GetAllProducts(int categoryId,
            int manufacturerId, int productTagId, bool? featuredProducts,
            decimal? priceMin, decimal? priceMax, string keywords,
            bool searchDescriptions, int pageSize, int pageIndex,
              ProductSortingEnum orderBy, out int totalRecords);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="manufacturerId">Manufacturer identifier</param>
        /// <param name="productTagId">Product tag identifier</param>
        /// <param name="featuredProducts">A value indicating whether loaded products are marked as featured (relates only to categories and manufacturers). 0 to load featured products only, 1 to load not featured products only, null to load all products</param>
        /// <param name="priceMin">Minimum price</param>
        /// <param name="priceMax">Maximum price</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="searchDescriptions">A value indicating whether to search in descriptions</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="filteredSpecs">Filtered product specification identifiers</param>
        /// <param name="languageId">Language identifier</param>
        /// <param name="orderBy">Order by</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Product collection</returns>
        List<Shop_ShopInfo> GetAllProducts(int categoryId,
            int manufacturerId, int productTagId, bool? featuredProducts,
            decimal? priceMin, decimal? priceMax,
            string keywords, bool searchDescriptions, int pageSize,
            int pageIndex, List<int> filteredSpecs, int languageId,
            ProductSortingEnum orderBy, out int totalRecords);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="categoryId">Category identifier; 0 to load all recordss</param>
        /// <param name="manufacturerId">Manufacturer identifier; 0 to load all recordss</param>
        /// <param name="productTagId">Product tag identifier; 0 to load all recordss</param>
        /// <param name="featuredProducts">A value indicating whether loaded products are marked as featured (relates only to categories and manufacturers). 0 to load featured products only, 1 to load not featured products only, null to load all products</param>
        /// <param name="priceMin">Minimum price</param>
        /// <param name="priceMax">Maximum price</param>
        /// <param name="relatedToProductId">Filter by related product; 0 to load all recordss</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="searchDescriptions">A value indicating whether to search in descriptions</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="filteredSpecs">Filtered product specification identifiers</param>
        /// <param name="languageId">Language identifier</param>
        /// <param name="orderBy">Order by</param>
        /// <param name="totalRecords">Total records</param>
        /// <returns>Product collection</returns>
        List<Shop_ShopInfo> GetAllProducts(int categoryId,
            int manufacturerId, int productTagId, bool? featuredProducts,
            decimal? priceMin, decimal? priceMax,
            int relatedToProductId, string keywords, bool searchDescriptions, int pageSize,
            int pageIndex, List<int> filteredSpecs, int languageId,
            ProductSortingEnum orderBy, out int totalRecords);

        /// <summary>
        /// Gets all products displayed on the home page
        /// </summary>
        /// <returns>Product collection</returns>
        List<Shop_ShopInfo> GetAllProductsDisplayedOnHomePage();

        /// <summary>
        /// Gets product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product</returns>
        Shop_ShopInfo GetProductById(int productId);

        /// <summary>
        /// Inserts a product
        /// </summary>
        /// <param name="product">Product</param>
        void InsertProduct(Shop_ShopInfo product);

        /// <summary>
        /// Updates the product
        /// </summary>
        /// <param name="product">Product</param>
        void UpdateProduct(Shop_ShopInfo product);
         
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
