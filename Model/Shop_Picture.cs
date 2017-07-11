namespace IMCustSys.Model
{
    /// <summary>
    /// Represents a product picture mapping
    /// </summary>
    public partial class ProductPicture
    {
        public int ProductPictureId { get; set; }


        public int ProductId { get; set; }


        public int PictureId { get; set; }


        public int DisplayOrder { get; set; }

    } 

}
