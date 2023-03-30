using BMarketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers;

public class ProductsController : Controller
{
	public IActionResult Index()
	{
		var viewModel = new ProductsIndexViewModel
		{
			All = new GridCollectionViewModel
			{
				Title = "All Products",
				Categories = new List<string> { "All", "Mobile", "Computers" }
			}
		};
		ViewData["Title"] = "Products";

		return View(viewModel);
	}
	public IActionResult Search()
	{
		ViewData["Title"] = "Search for products";
		return View();
	}
}
