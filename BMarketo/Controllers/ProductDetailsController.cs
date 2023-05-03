using System.Text;
using BMarketo.Models;
using BMarketo.Services.Repositories;
using BMarketo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace BMarketo.Controllers;

public class ProductDetailsController : Controller
{
    private readonly ProductsRepository _productRepository;

    public ProductDetailsController(ProductsRepository productRepository)
    {
        ViewData["Title"] = "Product Details";

        _productRepository = productRepository;
    }
    public async Task<IActionResult> Index(int id)
    {
        var productDetailEntity = await _productRepository.GetByIdAsync(id);
        var productImages = await _productRepository.GetProductImagesAsync(id);
        byte[] mainImageBytes = await _productRepository.GetMainImageAsync(id);
        // Fetch random products (you can replace 4 with the desired number of products)
        var randomProducts = await _productRepository.GetRandomProductsAsync(4);

        // Create view models for the random products
        var smallCards = randomProducts.Select(p => new GridCollectionSmallCardsItemViewModel
        {
            Id = p.Id.ToString(),
            Image = p.Image
        }).ToList();
        var viewModel = new ProductDetailViewModel
        {
            ProductDetailTitle = productDetailEntity.Title,
            Description = productDetailEntity.Description,
            Price = (decimal)productDetailEntity.Price!,
            SKUNumber = productDetailEntity.SKUNumber!,
            MainImage = mainImageBytes,
            // Get the underimages
            Images = productImages.ToList(),
           
        
         
            UnderImage1 = productImages.FirstOrDefault()?.Image,
            UnderImage2 = productImages.Skip(1).FirstOrDefault()?.Image,
            UnderImage3 = productImages.Skip(2).FirstOrDefault()?.Image,
            UnderImage4 = productImages.Skip(3).FirstOrDefault()?.Image,

            SmallCards = new GridCollectionViewModel()
            {
                GridItemsSmall = smallCards
            }

        };
       





        return View(viewModel);
    }




    

    //SmallCards = new GridCollectionViewModel()
    //{
    //    GridItemsSmall = new List<GridCollectionSmallCardsItemViewModel>
    //    {
    //         new GridCollectionSmallCardsItemViewModel {Id = "20", ImageUrl = "images/mc-clothing/Touratech.webp"},
    //          new GridCollectionSmallCardsItemViewModel {Id = "21",ImageUrl = "images/mc-clothing/Touratech.webp"},
    //           new GridCollectionSmallCardsItemViewModel {Id = "22",ImageUrl = "images/mc-clothing/Touratech.webp"},
    //            new GridCollectionSmallCardsItemViewModel {Id = "23",ImageUrl = "images/mc-clothing/Touratech.webp"}
    //    }
    //}


}
