using BMarketo.Models;
using BMarketo.Models.Contexts;
using BMarketo.Models.Entities.Products;
using BMarketo.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BMarketo.Services
{
    public class ProductDetailInfoService
    {
        private readonly ProductsContext _context;

        public ProductDetailInfoService(ProductsContext context)
        {
            _context = context;
        }
        public async Task<ProductDetailInfoViewModel> GetLatestAsync(int productId)
        {
            var descriptionEntity = await _context.AdditionalDescription
                .Where(a => a.ProductId == productId)
                .OrderByDescending(a => a.Id)
                .FirstOrDefaultAsync();

            var additionalEntity = await _context.AdditionalInfo
                .Where(a => a.ProductId == productId)
                .OrderByDescending(a => a.Id)
                .FirstOrDefaultAsync();

            var reviewsEntity = await _context.Reviews
               .Where(a => a.ProductId == productId)
               .OrderByDescending(a => a.Id)
               .FirstOrDefaultAsync();

            var shoppingdeliveryEntity = await _context.ShoppingDelivery
             .Where(a => a.ProductId == productId)
             .OrderByDescending(a => a.Id)
             .FirstOrDefaultAsync();


            // You can either use a manual mapping or use a library like AutoMapper.
            var viewModel = new ProductDetailInfoViewModel
            {
                NavButton1 = "Description",
                Text = descriptionEntity?.Text ?? "", // Use null conditional operator
                Image = descriptionEntity?.Image,
                MimeType = "image/jpeg", // Default value

                NavButton2 = "Additional Info",
                AdditionalText = additionalEntity?.Text ?? "", // Use null conditional operator
                AdditionalImage = additionalEntity?.Image,
                
                NavButton3 = "Reviews",
                ReviewsText = reviewsEntity?.Text ?? "",
                ReviewsImage = reviewsEntity?.Image,

                NavButton4 = "Shopping and Delivery",
                ShoppingDeliveryText = shoppingdeliveryEntity?.Text ?? "",
                ShoppingDeliveryImage = shoppingdeliveryEntity?.Image,

                //NavButton3 = descriptionEntity.NavButton3,
                //NavButton4 = descriptionEntity.NavButton4,
                //NavContentTitle1 = descriptionEntity.NavContentTitle1,
                //NavContentTitle2 = descriptionEntity.NavContentTitle2,
                //NavContentTitle3 = descriptionEntity.NavContentTitle3,
                //NavContentTitle4 = descriptionEntity.NavContentTitle4,
                //NavContentDescription1 = descriptionEntity.NavContentDescription1,
                //NavContentDescription2 = descriptionEntity.NavContentDescription2,
                //NavContentDescription3 = descriptionEntity.NavContentDescription3,
                //NavContentDescription4 = descriptionEntity.NavContentDescription4,
                //NavContentImage1 = descriptionEntity.NavContentImage1,
                //NavContentImage2 = descriptionEntity.NavContentImage2,
                //NavContentImage3 = descriptionEntity.NavContentImage3,
                //NavContentImage4 = descriptionEntity.NavContentImage4
            };

            return viewModel;
        }

    }
}
