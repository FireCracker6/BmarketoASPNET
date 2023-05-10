
using BMarketo.Models.Contexts.Identity;
using BMarketo.Services;
using BMarketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BMarketo.Controllers;

public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AuthenticationService _auth;

    public RegisterController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AuthenticationService auth)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _auth = auth;
    }







    public IActionResult Index()
    {
        return View();
    }

    
    [HttpPost]
    public async Task<IActionResult> Index(UserRegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            
            string imageFileName = null!;
            if (model.ProfileImage != null)
            {
                imageFileName = await SaveProfileImageAsync(model.ProfileImage);
            }
            var user = new AppUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, ImageUrl = imageFileName }; // Include the ImageFile property here
            var result = await _userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                // Check if there is only one user in the database.
                if (await _userManager.Users.CountAsync() == 1)
                {
                    // Ensure the "Admin" role exists.
                    if (!await _roleManager.RoleExistsAsync("Admin"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    }
                    // Assign the "Admin" role to the first user.
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    // Ensure the "User" role exists.
                    if (!await _roleManager.RoleExistsAsync("User"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("User"));
                    }
                    // Assign the "User" role to the other users.
                    await _userManager.AddToRoleAsync(user, "User");
                }

              // await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Login");
            }
           // AddErrors(result);
        }

        // If we got this far, something failed, redisplay the form.
        return View(model);
    }

    private async Task<string> SaveProfileImageAsync(IFormFile profileImage)
    {
        // Set your desired image folder here
        string imageFolder = "wwwroot/images/profiles";

        // Check if the directory exists and create it if not
        if (!Directory.Exists(imageFolder))
        {
            Directory.CreateDirectory(imageFolder);
        }

        string uniqueFileName = Guid.NewGuid().ToString() + "_" + profileImage.FileName;
        string filePath = Path.Combine(imageFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await profileImage.CopyToAsync(fileStream);
        }

        return uniqueFileName;

    }
    }
