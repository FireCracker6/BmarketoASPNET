using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers;

public class ContactsController : Controller
{
	public IActionResult Index()
	{
		ViewData["Title"] = "Contact Us";
		return View();
	}
}
