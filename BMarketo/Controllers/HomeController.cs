using BMarketo.Models.Entities.Products;
using BMarketo.Services.Repositories;
using BMarketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers;


public class HomeController : Controller
{
    private readonly ProductsRepository _productRepository;

    public HomeController(ProductsRepository productRepository)
    {
        _productRepository = productRepository;
    }
  
    public async Task<IActionResult> Index()
    {

        var products = await _productRepository.GetByTagWithCommentsAsync("BestCollection");
        var topSellingProducts = await _productRepository.GetByTagWithCommentsAsync("TopSelling");
        var discountProducts = await _productRepository.GetByTagWithCommentsAsync("Discounted");


        var viewModel = new HomeIndexViewModel
        {
            BestCollection = new GridCollectionViewModel
            {
                ShowCategoryFilter = false,
                Title = "Best Collection",
                GridItems = products.Select(p => new GridCollectionItemViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = (decimal)p.Price!,
                    Image = p.Image
                }).ToList()
            },

            // TopSelling Items
            TopSelling = new TopSellingCollectionViewModel
            {
                Title = "Top Selling products in this Week",
                GridItems = topSellingProducts.Select(p => new GridCollectionItemViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = (decimal)p.Price!,
                    Image = p.Image,
                    CommentsCount = p.Comments.Count, // Set the CommentsCount property
                }).ToList(),

                GridDiscountItems = topSellingProducts.Select(p => new GridCollectionItemViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = (decimal)p.Price!,
                    Image = p.Image,
                    CommentsCount = p.Comments.Count, // Set the CommentsCount property
                }).ToList(),
            },
         
            DiscountCards = new GridCollectionViewModel
            {
                GridItems = discountProducts.Select(p => new GridCollectionItemViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = (decimal)p.Price!,
                    Image = p.Image,

                    CommentsCount = p.Comments.Count, 
                }).ToList()
            },
           
            SubcribeNewsLetter = new SubcribeNewsLetterViewModel
            {
                SubscribeItem = new List<SubscribeItemViewModel>
                {
                    new SubscribeItemViewModel    { InputPlaceHolder = "Your mail here", EmailPlaceHolder = "subcribe mail here...", SubmitText = "SUBSCRIBE FOR NEWSLETTER", SubcribeButton = "SUBSCRIBE"}
                }
             
            }
        };
		return View(viewModel);
	}
    public async Task<IActionResult> ProductDetails(int id)
    {
        var productDetailEntity = await _productRepository.GetByIdAsync(id);
        var productImages = await _productRepository.GetProductImagesAsync(id);

        var viewModel = new ProductDetailViewModel
        {
            ProductDetailTitle = productDetailEntity.Title,
            Description = productDetailEntity.Description!,
            Price = (decimal)productDetailEntity.Price!,
            SKUNumber = productDetailEntity.SKUNumber!,
            Images = productImages.ToList(),

            UnderImage1 = productImages.FirstOrDefault()?.Image!,
            UnderImage2 = productImages.Skip(1).FirstOrDefault()?.Image!,
            UnderImage3 = productImages.Skip(2).FirstOrDefault()?.Image!,
            UnderImage4 = productImages.Skip(3).FirstOrDefault()?.Image!,

            MainImage = await _productRepository.GetMainImageAsync(id),
        };

        return View(viewModel);
    }

}
