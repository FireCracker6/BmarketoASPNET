using BMarketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers;


public class HomeController : Controller
{
	public IActionResult Index()
	{

        var viewModel = new HomeIndexViewModel
        {
            BestCollection = new GridCollectionViewModel
            {
                Title = "Best Collection",
                Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptops", "Mobile", "Beauty" },
                GridItems = new List<GridCollectionItemViewModel>
                {
                    new GridCollectionItemViewModel { Id = "1", Title = "Apple Watch Series", Price = 10, ImageUrl = "images/mc-clothing/WomanSuite.webp" },
                    new GridCollectionItemViewModel { Id = "2", Title = "Apple Watch Series", Price = 20, ImageUrl = "images/mc-clothing/WomanSuite.webp" },
                    new GridCollectionItemViewModel { Id = "3", Title = "Apple Watch Series", Price = 30, ImageUrl = "images/mc-clothing/WomanSuite.webp" },
                    new GridCollectionItemViewModel { Id = "4", Title = "Apple Watch Series", Price = 40, ImageUrl = "images/mc-clothing/WomanSuite.webp" },
                    new GridCollectionItemViewModel { Id = "5", Title = "Apple Watch Series", Price = 50, ImageUrl = "images/mc-clothing/WomanSuite.webp" },
                    new GridCollectionItemViewModel { Id = "6", Title = "Apple Watch Series", Price = 60, ImageUrl = "images/mc-clothing/WomanSuite.webp" },
                    new GridCollectionItemViewModel { Id = "7", Title = "Apple Watch Series", Price = 70, ImageUrl = "images/mc-clothing/WomanSuite.webp" },
                    new GridCollectionItemViewModel { Id = "8", Title = "Apple Watch Series", Price = 80, ImageUrl = "images/mc-clothing/WomanSuite.webp" },


                }
            },

            // TopSelling Items
            TopSelling = new TopSellingCollectionViewModel
            {
                Title = "Top Selling products in this Week ",

                GridItems = new List<GridCollectionItemViewModel>
                {
                    new GridCollectionItemViewModel { Id = "1", Title = "Apple Watch Series", Price = 10, ImageUrl = "images/mc-clothing/McJacket-W.webp" },
                    new GridCollectionItemViewModel { Id = "2", Title = "Apple Watch Series", Price = 20, ImageUrl = "images/mc-clothing/McJacket-W.webp" },
                    new GridCollectionItemViewModel { Id = "3", Title = "Apple Watch Series", Price = 30, ImageUrl = "images/mc-clothing/McJacket-W.webp" },
                    new GridCollectionItemViewModel { Id = "4", Title = "Apple Watch Series", Price = 40, ImageUrl = "images/mc-clothing/McJacket-W.webp" },
                    new GridCollectionItemViewModel { Id = "5", Title = "Apple Watch Series", Price = 50, ImageUrl = "images/mc-clothing/McJacket-W.webp" },
                    new GridCollectionItemViewModel { Id = "6", Title = "Apple Watch Series", Price = 60, ImageUrl = "images/mc-clothing/McJacket-W.webp" },



                },
                GridDiscountItems = new List<GridCollectionItemViewModel>
                {
                    new GridCollectionItemViewModel { Id = "7", Title = "Apple Watch Series", AdminPosts = "POSTS BY ADMIN", Comments = "COMMENTS 13", Description = " Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno", ImageUrl = "images/mc-clothing/McJacket-W.webp" },
                    new GridCollectionItemViewModel { Id = "8", Title = "Apple Watch Series", AdminPosts = "POSTS BY ADMIN", Comments = "COMMENTS 13", Description = " Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno", ImageUrl = "images/mc-clothing/McJacket-W.webp" },
                    new GridCollectionItemViewModel { Id = "9", Title = "Apple Watch Series", AdminPosts = "POSTS BY ADMIN", Comments = "COMMENTS 13", Description = " Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno", ImageUrl = "images/mc-clothing/McJacket-W.webp" },
                },



            },
            DiscountCards = new GridCollectionViewModel
            {
                GridItems = new List<GridCollectionItemViewModel>
                {
                    new GridCollectionItemViewModel{ Id = "10", Title = "Jacket Xena 3 Ladies", OldPrice = 59, Price = 30, ImageUrl = "images/mc-clothing/Xena-Jacket.webp" , HeaderTitle = "", HeaderText = "", DiscountDescription = "", DiscountLink = ""},

                 
                     new GridCollectionItemViewModel{ Id = "11", HeaderTitle = "UP TO SELL", HeaderText = "50% OFF", HeaderSlogan = "Get The Best Price", DiscountDescription = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki", DiscountLink = "DISCOVER MORE"},

						  new GridCollectionItemViewModel{ Id = "11", Title = "Jacket Xena 3 Ladies", OldPrice = 59, Price = 30, ImageUrl = "images/mc-clothing/Xena-Jacket.webp"}
				}
            },
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
}
