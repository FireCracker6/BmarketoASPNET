using BMarketo.Models.Contexts.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers
{
    public class LogOutController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogOutController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
                await _signInManager.SignOutAsync();
            return LocalRedirect("/");
        }
    }
}
