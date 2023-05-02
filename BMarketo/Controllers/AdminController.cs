using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers
{
	 [Authorize(Roles = "user")]
	//[AllowAnonymous]
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
