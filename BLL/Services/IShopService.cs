﻿using IMCustSys.Model; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMCustSys.BLL.Services
{
    public interface IShopService
    {
        #region Shop
         
        void MarkProductAsDeleted(int productId); 
         
        List<Shop> GetAllHotProducts();
       List<Shop> GetAllProducts(string comId="", int? showHidden=null); 
        List<Shop> GetAllProducts(int? categoryId=0,   string comId = "", string keywords = "", int? state = null, bool? featuredProducts=null);
          
       
        List<Shop> GetAllProductsDisplayedOnHomePage(string comId="");

        
        Shop GetProductById(int productId);

        
        void InsertProduct(Shop product);

        
        void UpdateProduct(Shop product);
         
        #endregion

        #region Shop pictures


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
