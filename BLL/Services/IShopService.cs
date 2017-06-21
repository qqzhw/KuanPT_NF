using Model; 
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
        List<Shop> GetAllHotProducts();
        List<Shop> GetAllProducts(int showHidden); 
        List<Shop> GetAllProducts(int categoryId,  bool? featuredProducts );
         
        List<Shop> GetAllProducts(int? categoryId,
             bool? featuredProducts,  string keywords="", int? state=null, bool? searchDescriptions=false,int pageIndex=0,int pageSize=int.MaxValue);
 
         
       
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
