using BMarketo.Models;

namespace BMarketo.Services
{
    public class ProductDetailService
    {
        private readonly List<ProductDetailModel> _productDetails = new()
        {
            new ProductDetailModel()
            {
                MainImage = "images/mc-clothing/Xena-Jacket-Red.webp",
                UnderImage1 =  "images/mc-clothing/Xena-Jacket-Red.webp",
                UnderImage2 = "images/mc-clothing/Xena-Jacket-Red.webp",
                UnderImage3 = "images/mc-clothing/Xena-Jacket-Red.webp",
                UnderImage4 = "images/mc-clothing/Xena-Jacket-Red.webp",

                ProductDetailTitle = "Full-spec, figure-hugging sport motocycle jacket",
                ProductDescription = "Never change a winning team, right? Well, we don’t necessarily think that’s true! Building upon the reputation of two successful...",
                ProductDetailReviews  = "16 Reviews",
                Price = 500,

                AddtoCartButton = true,
                AddToWishListButton = true,
                SKUNumber = "N/A",
                Category = "Category: Womens MC Jackets"

               
            }
        };
        public ProductDetailModel GetLatest()
        {
            return _productDetails.LastOrDefault()!;
        }
    }
}
