using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
