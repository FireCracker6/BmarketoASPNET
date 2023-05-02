using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers
{
	public class DeniedController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
