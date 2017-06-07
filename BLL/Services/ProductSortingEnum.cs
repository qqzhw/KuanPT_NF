 
namespace NopSolutions.NopCommerce.BusinessLogic.Products
{
    /// <summary>
    /// Represents the product sorting
    /// </summary>
    public enum ProductSortingEnum : int
    {
        /// <summary>
        /// Position (display order)
        /// </summary>
        Position = 0,
        /// <summary>
        /// Name
        /// </summary>
        Name = 5,
        /// <summary>
        /// Price
        /// </summary>
        Price = 10,
        /// <summary>
        /// Product creation date
        /// </summary>
        CreatedOn = 15,

    }
}