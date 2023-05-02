using BMarketo.Models.Entities.Products;

namespace BMarketo.Models
{
    public class ProductDetailModel
    {
        public List<ProductImagesEntity> Images { get; set; } = new List<ProductImagesEntity>();
        public string MainImage { get; set; } = "";
        public string UnderImage1 { get; set; } = "";
        public string UnderImage2 { get; set; } = "";
        public string UnderImage3 { get; set; } = "";
        public string UnderImage4 { get; set; } = "";

        public string ProductDetailTitle { get; set; } = "";    
        public string ProductDescription { get; set; } = "";    
        public string ProductDetailReviews { get; set; } = "";
        public decimal Price { get; set; }

        public bool AddtoCartButton { get; set; } = false;
        public bool AddToWishListButton { get; set; } = false;
        public string SKUNumber { get; set; } = "";

        public string Category { get; set; } = "";
    }
}
