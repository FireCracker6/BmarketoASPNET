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
                    Price = (decimal)p.Price,
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
                    Price = (decimal)p.Price,
                    Image = p.Image,
                    CommentsCount = p.Comments.Count, // Set the CommentsCount property
                }).ToList(),

                GridDiscountItems = topSellingProducts.Select(p => new GridCollectionItemViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = (decimal)p.Price,
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
                    Price = (decimal)p.Price,
                    Image = p.Image,

                    CommentsCount = p.Comments.Count, // Set the CommentsCount property
                }).ToList()
            },
            //        {
            //            new GridCollectionItemViewModel { Id = "7", Title = "Apple Watch Series", AdminPosts = "POSTS BY ADMIN", Comments = "COMMENTS 13", Description = " Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno", ImageUrl = "images/mc-clothing/McJacket-W.webp" },
            //            new GridCollectionItemViewModel { Id = "8", Title = "Apple Watch Series", AdminPosts = "POSTS BY ADMIN", Comments = "COMMENTS 13", Description = " Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno", ImageUrl = "images/mc-clothing/McJacket-W.webp" },
            //            new GridCollectionItemViewModel { Id = "9", Title = "Apple Watch Series", AdminPosts = "POSTS BY ADMIN", Comments = "COMMENTS 13", Description = " Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno", ImageUrl = "images/mc-clothing/McJacket-W.webp" },
            //        },



            // TopSelling Items

            //TopSelling = new TopSellingCollectionViewModel
            //    {


            //        Title = "Top Selling products in this Week ",

            //        GridItems = new List<GridCollectionItemViewModel>
            //        {
            //            new GridCollectionItemViewModel { Id = "1", Title = "Apple Watch Series", Price = 10, ImageUrl = "images/mc-clothing/McJacket-W.webp" },
            //            new GridCollectionItemViewModel { Id = "2", Title = "Apple Watch Series", Price = 20, ImageUrl = "images/mc-clothing/McJacket-W.webp" },
            //            new GridCollectionItemViewModel { Id = "3", Title = "Apple Watch Series", Price = 30, ImageUrl = "images/mc-clothing/McJacket-W.webp" },
            //            new GridCollectionItemViewModel { Id = "4", Title = "Apple Watch Series", Price = 40, ImageUrl = "images/mc-clothing/McJacket-W.webp" },
            //            new GridCollectionItemViewModel { Id = "5", Title = "Apple Watch Series", Price = 50, ImageUrl = "images/mc-clothing/McJacket-W.webp" },
            //            new GridCollectionItemViewModel { Id = "6", Title = "Apple Watch Series", Price = 60, ImageUrl = "images/mc-clothing/McJacket-W.webp" },



            //        },
            //        GridDiscountItems = new List<GridCollectionItemViewModel>
            //        {
            //            new GridCollectionItemViewModel { Id = "7", Title = "Apple Watch Series", AdminPosts = "POSTS BY ADMIN", Comments = "COMMENTS 13", Description = " Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno", ImageUrl = "images/mc-clothing/McJacket-W.webp" },
            //            new GridCollectionItemViewModel { Id = "8", Title = "Apple Watch Series", AdminPosts = "POSTS BY ADMIN", Comments = "COMMENTS 13", Description = " Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno", ImageUrl = "images/mc-clothing/McJacket-W.webp" },
            //            new GridCollectionItemViewModel { Id = "9", Title = "Apple Watch Series", AdminPosts = "POSTS BY ADMIN", Comments = "COMMENTS 13", Description = " Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno", ImageUrl = "images/mc-clothing/McJacket-W.webp" },
            //        },



            //    },
    //        DiscountCards = new GridCollectionViewModel
    //        {
    //            GridItems = new List<GridCollectionItemViewModel>
    //            {
    //                new GridCollectionItemViewModel{ Id = "10", Title = "Jacket Xena 3 Ladies", OldPrice = 59, Price = 30, ImageUrl = "images/mc-clothing/Xena-Jacket.webp" , HeaderTitle = "", HeaderText = "", DiscountDescription = "", DiscountLink = ""},

                 
    //                 new GridCollectionItemViewModel{ Id = "11", HeaderTitle = "UP TO SELL", HeaderText = "50% OFF", HeaderSlogan = "Get The Best Price", DiscountDescription = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki", DiscountLink = "DISCOVER MORE"},

				//		  new GridCollectionItemViewModel{ Id = "11", Title = "Jacket Xena 3 Ladies", OldPrice = 59, Price = 30, ImageUrl = "images/mc-clothing/Xena-Jacket.webp"}
				//}
    //        },
            SubcribeNewsLetter = new SubcribeNewsLetterViewModel
            {
                SubscribeItem = new List<SubscribeItemViewModel>
                {
                    new SubscribeItemViewModel    { InputPlaceHolder = "Your mail here", EmailPlaceHolder = "subcribe mail here...", SubmitText = "SUBSCRIBE FOR NEWSLETTER", SubcribeButton = "SUBSCRIBE"}
                }
             
            }
           


            //SummerCollection = new GridCollectionViewModel { Title = "Summer Collection" }
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
            Description = productDetailEntity.Description,
            Price = (decimal)productDetailEntity.Price!,
            SKUNumber = productDetailEntity.SKUNumber!,
            Images = productImages.ToList(),

            UnderImage1 = productImages.FirstOrDefault()?.Image,
            UnderImage2 = productImages.Skip(1).FirstOrDefault()?.Image,
            UnderImage3 = productImages.Skip(2).FirstOrDefault()?.Image,
            UnderImage4 = productImages.Skip(3).FirstOrDefault()?.Image,

            MainImage = await _productRepository.GetMainImageAsync(id),
        };

        return View(viewModel);
    }

}
