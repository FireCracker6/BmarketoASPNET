using BMarketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers;

public class ProductDetailsController : Controller
{
	public IActionResult Index()
	{
        var viewModel = new ProductDetailsIndexViewModel
        {
            RelatedProducts = new RelatedProductsViewModel
            {
                Title = "Related Products",
               
                GridItems = new List<GridCollectionItemViewModel>
                {
                    new GridCollectionItemViewModel { Id = "1", Title = "Apple Watch Series", Price = 10, ImageUrl = "images/mc-clothing/Xena-Jacket.webp" },
                    new GridCollectionItemViewModel { Id = "2", Title = "Apple Watch Series", Price = 20, ImageUrl = "images/mc-clothing/Xena-Jacket.webp" },
                    new GridCollectionItemViewModel { Id = "3", Title = "Apple Watch Series", Price = 30, ImageUrl = "images/mc-clothing/Xena-Jacket.webp" },
                    new GridCollectionItemViewModel { Id = "4", Title = "Apple Watch Series", Price = 40, ImageUrl = "images/mc-clothing/Xena-Jacket.webp" },
                  


                }
            },
            SmallCards = new GridCollectionViewModel()
            {
                GridItemsSmall = new List<GridCollectionSmallCardsItemViewModel>
                {
                     new GridCollectionSmallCardsItemViewModel {Id = "20", ImageUrl = "images/mc-clothing/Touratech.webp"},
                      new GridCollectionSmallCardsItemViewModel {Id = "21",ImageUrl = "images/mc-clothing/Touratech.webp"},
                       new GridCollectionSmallCardsItemViewModel {Id = "22",ImageUrl = "images/mc-clothing/Touratech.webp"},
                        new GridCollectionSmallCardsItemViewModel {Id = "23",ImageUrl = "images/mc-clothing/Touratech.webp"}
                }
            }
        };
        ViewData["Title"] = "Product Details";

        return View(viewModel);
    }
}
