using BMarketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers;


public class HomeController : Controller
{
	public IActionResult Index()
	{
		ViewData["Title"] = "Home";




		var viewModel = new HomeIndexViewModel
		{
			Showcase_1 = new ShowcaseViewModel()
			{
				Ingress = "WELCOME TO BMARKETO SHOP",
				Title = "Exclusive Chair gold Collection",
				LinkContent = "SHOP NOW",
				LinkUrl = "/ProductDetails",
				ImageUrl = "images/placeholders/625x647.svg"

			},
			Showcase_2 = new ShowcaseViewModel()
			{
				Ingress = "WELCOME TO SHOP SHOP",
				Title = "Exclusive Chair gold Collection",
				LinkContent = "SHOP NOW",
				LinkUrl = "/ProductDetails",
				ImageUrl = "images/placeholders/625x647.svg"

			}
		};


		return View(viewModel);
	}
}
