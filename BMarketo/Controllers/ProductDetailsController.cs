using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers;

public class ProductDetailsController : Controller
{
	public IActionResult Index()
	{
		ViewData["Title"] = "Product Details";
		return View();
	}
}
