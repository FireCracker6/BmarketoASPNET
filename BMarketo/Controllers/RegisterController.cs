
using BMarketo.Services;
using BMarketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers
{
    public class RegisterController : Controller
    {

        private readonly AuthenticationService _auth;

        public RegisterController(AuthenticationService auth)
        {
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                if (await _auth.UserAlreadyExistsAsync(x => x.Email == viewModel.Email)) 
                    ModelState.AddModelError("", "An account with the same e-mail already exists");
              

                if (await _auth.RegisterUserAsync(viewModel))
                    return RedirectToAction("Index", "Login");

            }
         
            return View(viewModel);

        }
    }
}
