using System.Security.Claims;
using BMarketo.Models.Contexts.Identity;
using BMarketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ILogger<AccountController> _logger;

    public AccountController(UserManager<AppUser> userManager, IWebHostEnvironment webHostEnvironment, ILogger<AccountController> logger)
    {
        _userManager = userManager;
        _webHostEnvironment = webHostEnvironment;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.FindByIdAsync(userId!);

        var model = new UserProfileViewModel
        {
            DisplayName = $"{user!.FirstName} {user.LastName}",
            Email = user.Email!,
            PhoneNumber = user.PhoneNumber,
            ProfileImageUrl = $"/images/profiles/{user.ImageUrl}" // Set the correct path here
        };

        return View(model);


    }
    public async Task<IActionResult> GetProfileImage(string id)
    {
        // Retrieve the user's data
        var user = await _userManager.FindByIdAsync(id);

        if (user == null || string.IsNullOrEmpty(user.ImageUrl))
        {
            return NotFound();
        }

        // Get the image path from the user's profileImageUrl
        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "profiles", user.ImageUrl);

        // Check if the file exists
        if (!System.IO.File.Exists(imagePath))
        {
            return NotFound();
        }

        // Get the image file extension (e.g., "jpg", "png", "webp")
        string fileExtension = Path.GetExtension(imagePath).TrimStart('.').ToLower();

        // Map the file extension to a corresponding MIME type
        string mimeType = fileExtension switch
        {
            "jpg" => "image/jpeg",
            "jpeg" => "image/jpeg",
            "png" => "image/png",
            "webp" => "image/webp",
            _ => "application/octet-stream"
        };

        // Return the image file
        return File(System.IO.File.ReadAllBytes(imagePath), mimeType);
    }

    [HttpPost]
    [HttpPost]
    public async Task<IActionResult> UpdateProfile(UserProfileViewModel model)
    {
        _logger.LogInformation("UpdateProfile method called.");

        if (ModelState.IsValid)
        {
            _logger.LogInformation("ModelState is valid.");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger.LogInformation($"User ID: {userId}");

            var user = await _userManager.FindByIdAsync(userId);
            _logger.LogInformation($"User: {user?.UserName}");

            // Update user properties
            user!.FirstName = model.DisplayName.Split(' ')[0];
            user.LastName = model.DisplayName.Split(' ')[1];
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            // Save the profile image if it's provided
            if (model.ProfileImage != null)
            {
                string imageFileName = await SaveProfileImageAsync(model.ProfileImage);
                user.ImageUrl = imageFileName;
            }

            // Save changes to the user
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                _logger.LogInformation("Update succeeded. Redirecting to Index.");
                // Redirect to a success page or back to the profile page
                return RedirectToAction("Index");
            }
            else
            {
                _logger.LogInformation("Update failed.");
                // Add errors to the ModelState
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    _logger.LogError($"Error: {error.Description}");
                }
            }
        }
        else
        {
            _logger.LogInformation("ModelState is invalid.");
            foreach (var entry in ModelState)
            {
                if (entry.Value.Errors.Count > 0)
                {
                    _logger.LogError($"ModelState error for key {entry.Key}: {string.Join(", ", entry.Value.Errors.Select(e => e.ErrorMessage))}");
                }
            }

        }

        // If we got this far, something failed, redisplay the form.
        return View("Index", model);
    }


    private async Task<string> SaveProfileImageAsync(IFormFile profileImage)
    {
        // Image location
        string imageFolder = "wwwroot/images/profiles";
        string uniqueFileName = Guid.NewGuid().ToString() + "_" + profileImage.FileName;
        string filePath = Path.Combine(imageFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await profileImage.CopyToAsync(fileStream);
        }

        return uniqueFileName;
    }




}
