using BLL.Infrastructure;
using BLL.Services;
using Common;
using Model;
using System.Collections.Generic;
using System.IO;
using System.Web;
namespace  BLL
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Gets the download binary array
        /// </summary>
        /// <param name="postedFile">Posted file</param>
        /// <returns>Download binary array</returns>
        public static byte[] GetDownloadBits(this HttpPostedFile postedFile)
        {
            Stream fs = postedFile.InputStream;
            int size = postedFile.ContentLength;
            byte[] binary = new byte[size];
            fs.Read(binary, 0, size);
            return binary;
        }

        /// <summary>
        /// Gets the picture binary array
        /// </summary>
        /// <param name="postedFile">Posted file</param>
        /// <returns>Picture binary array</returns>
        public static byte[] GetPictureBits(this HttpPostedFile postedFile)
        {
            Stream fs = postedFile.InputStream;
            int size = postedFile.ContentLength;
            byte[] img = new byte[size];
            fs.Read(img, 0, size);
            return img;
        }

        /// <summary>
        /// Gets the loaded picture binary depending on picture storage settings
        /// </summary>
        /// <param name="picture">Picture</param>
        /// <param name="fromDb">Load from database; otherwise, from file system</param>
        /// <returns>Picture binary</returns>
        public static byte[] LoadPictureBinary(this Picture picture, bool fromDb)
        {
            byte[] result = null;
            if (fromDb)
            {
                result = picture.PictureBinary;
            }
            else
            {
                result =EngineContext.Current.Resolve<IPictureService>().LoadPictureFromFile(picture.PictureId, picture.MimeType);
            }
            return result;
        }

        /// <summary>
        /// Gets the loaded picture binary depending on picture storage settings
        /// </summary>
        /// <param name="picture">Picture</param>
        /// <returns>Picture binary</returns>
        public static byte[] LoadPictureBinary(this Picture picture)
        {
            return LoadPictureBinary(picture, EngineContext.Current.Resolve<IPictureService>().StoreInDB);
        }
       
        public static ShopCategory FindProductCategory(this List<ShopCategory> source,
            int productId, int categoryId)
        {
            foreach (ShopCategory productCategory in source)
                if (productCategory.ShopId == productId && productCategory.CategoryId == categoryId)
                    return productCategory;
            return null;
        }

        
        public static List<Category> SortCategoriesForTree(this List<Category> source, int parentId)
        {
            var result = new List<Category>();

            var temp = source.FindAll(c => c.ParentCategoryId == parentId);
            foreach (var cat in temp)
            {
                result.Add(cat);
                result.AddRange(SortCategoriesForTree(source, cat.CategoryId));
            }
            return result;
        }
        public static Category GetParentCategory(this Category category,int ParentCategoryId)
        {
            var categoryService = EngineContext.Current.Resolve<ICategoryService>();  
                return categoryService.GetCategoryById(ParentCategoryId);
           
        }
        public static string GetOrderStatusName(this OrderStatusEnum os)
        {
            string name = "������";
            switch (os)
            {
                case OrderStatusEnum.Pending:
                    name = "������";
                    break;
                case OrderStatusEnum.Processing:
                    name = "������";
                    break;
                case OrderStatusEnum.Complete:
                    name = "�����";
                    break;
                case OrderStatusEnum.Cancelled:
                    name = "��ȡ��";
                    break;
                default:
                    break;
            }
            return name;
        }
        public static string GetPaymentStatusName(this PaymentStatusEnum paymentStatus)
        {
            string name = "��֧��";
            switch (paymentStatus)
            {
                case PaymentStatusEnum.Pending:
                    name = "��֧��";
                    break; 
                case PaymentStatusEnum.Paid:
                    name = "��֧��";
                    break;
                case PaymentStatusEnum.PartiallyRefunded:
                    name = "�����˿�";
                    break;
                case PaymentStatusEnum.Refunded:
                    name = "���˿�";
                    break;
                case PaymentStatusEnum.Voided:
                    name = "����";
                    break;
                default: 
                    break;
            }
            return name;
        }
    }
}
