using IMCustSys.Model;
using System.Collections.Generic;

namespace IMCustSys.BLL.Services
{
    /// <summary>
    /// Category service interface
    /// </summary>
    public partial interface ICategoryService
    {

        void MarkCategoryAsDeleted(int categoryId);
         
     
        List<Category> GetAllCategories(string comId="", string categoryName="", bool? showHidden=null);
        
        
        List<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId);
        
         
        List<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId,
            bool showHidden);
        
         
        List<Category> GetAllCategoriesDisplayedOnHomePage();
                
         
        Category GetCategoryById(int categoryId);

        Category GetCategoryByName(string categoryName);

        List<Category> GetBreadCrumb(int categoryId);

        
        void InsertCategory(Category category);

        
        void UpdateCategory(Category category);

        void DeleteCategory(Category category);

        void DeleteProductCategory(int productCategoryId);

      
        List<ShopCategory> GetProductCategoriesByCategoryId(int categoryId);

      
        List<ShopCategory> GetProductCategoriesByProductId(int productId);

       
        ShopCategory GetProductCategoryById(int productCategoryId);

     
        void InsertProductCategory(ShopCategory productCategory);
 
        void UpdateProductCategory(ShopCategory productCategory);
    }
}
