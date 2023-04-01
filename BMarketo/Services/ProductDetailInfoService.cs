using BMarketo.Models;

namespace BMarketo.Services
{
    public class ProductDetailInfoService
    {
        private readonly List<ProductDetailInfoModel> _productDetailsInfo = new()
        {
            new ProductDetailInfoModel()
            {
                NavButton1 = "DESCRIPTION",
                NavButton2 = "ADDITIONAL INFO",
                NavButton3 = "REVIEWS(0)",
                NavButton4 = "SHOPPING & DELIVERY",

                NavContentTitle1 = "PRODUCT INFORMATION",
                NavContentTitle2 = "KEY BENEFITS",
                NavContentTitle3 = "FEATURES",
                NavContentTitle4 = "SPORTIVE DESIGN",

                NavContentDescription1 = "Never change a winning team, right? Well, we don’t necessarily think that’s true! Building upon the reputation of two successful generations, the Xena 3 Ladies motorcycle jacket received an update to extend its reputation as the ultimate sportive female motorcycle garment.\r\n",
                NavContentDescription2 = "Based upon extensive research and the feedback of riders worldwide, the Xena 3 truly is a case of the best becoming better. Slight changes to the pattern means an improved fit, allowing for more comfort and freedom of movement without compromising safety.",
                NavContentDescription3 = "Our award-winning SEEFLEX™ CE-level 2 protectors come standard at the shoulders and elbows, with the option to upgrade your armor by installing our SEESOFT™ CE-level 2 back protector insert. Style-wise, the Xena 3 brings rich details to the table that might require a doubletake to discover, but once seen, they can never be unseen.\r\n",
                NavContentDescription4 = "Thanks to a long and short connection zipper, the partially ventilated Xena 3 Ladies motorcycle jacket can be zipped onto the Xena 3 Ladies trousers for a trip down the track, as well as to our female riding jeans when using our Safeway 2 belt.",

                NavContentImage1 = "images/mc-clothing/XenaJacketBenefits.webp",
                NavContentImage2 = "images/mc-clothing/XenaJacketBenefits.webp",
                NavContentImage3 = "images/mc-clothing/XenaJacketBenefits.webp",
                NavContentImage4 = "images/mc-clothing/XenaJacketBenefits.webp ",


            }
        };
        public ProductDetailInfoModel GetLatest()
        {
            return _productDetailsInfo.LastOrDefault()!;
        }
    }
}
