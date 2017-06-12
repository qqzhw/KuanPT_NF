using Common;
using Model; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Services
{
  
    public partial interface IPictureService
    {
        
        string GetDefaultPictureUrl(int targetSize);

         
        byte[] LoadPictureFromFile(int pictureId, string mimeType);

        
        string GetPictureUrl(int imageId);

         
        string GetPictureUrl(Picture picture);

        
        string GetPictureUrl(int imageId, int targetSize);

        
        string GetPictureUrl(Picture picture, int targetSize);

       
        string GetPictureUrl(int imageId, int targetSize,
            bool showDefaultPicture);

       
        List<String> GetPictureUrls(int pictureId);

        
        string GetPictureUrl(Picture picture, int targetSize,
            bool showDefaultPicture);

         
        string GetPictureLocalPath(Picture picture, int targetSize, bool showDefaultPicture);

        
        Picture GetPictureById(int pictureId);

      
        void DeletePicture(int pictureId);
 
        byte[] ValidatePicture(byte[] pictureBinary, string mimeType);

        
        PagedList<Picture> GetPictures(int pageSize, int pageIndex);

       
        List<Picture> GetPicturesByProductId(int productId);
 
        List<Picture> GetPicturesByProductId(int productId,
            int recordsToReturn);

       
        Picture InsertPicture(byte[] pictureBinary, string mimeType, bool isNew);
        string UploadPicture(byte[] pictureBinary, string mimeType);

        Picture UpdatePicture(int pictureId, byte[] pictureBinary,
            string mimeType, bool isNew);

        /// <summary>
        /// Gets an image quality
        /// </summary>
        long ImageQuality { get; }

        /// <summary>
        /// Gets a local thumb image path
        /// </summary>
        string LocalThumbImagePath { get; }

        /// <summary>
        /// Gets the local image path
        /// </summary>
        string LocalImagePath { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the images should be stored in data base.
        /// </summary>
        bool StoreInDB { get; set; }
    }
}