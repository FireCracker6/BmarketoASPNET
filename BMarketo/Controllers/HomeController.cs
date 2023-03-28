using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers;


public class HomeController : Controller
{
	public IActionResult Index()
	{
		ViewData["Title"] = "Home";

		return View();
	}
}
