using BMarketo.Models.Contexts.Identity;
using BMarketo.Services.Repositories;
using BMarketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace BMarketo.Controllers;
//[Authorize(Policy = "AdminOnly")]
[Authorize(Roles = "Admin")]

public class AdminController : Controller
{
    private readonly NewsletterSubscriptionRepository _newsletterSubscriptionRepository;
    private readonly UserManager<AppUser> _userManager;
    public AdminController(NewsletterSubscriptionRepository newsletterSubscriptionRepository, UserManager<AppUser> userManager)
    {
        _newsletterSubscriptionRepository = newsletterSubscriptionRepository;
        _userManager = userManager;
    }
    [HttpGet]
    public IActionResult TestAuth()
    {
        var user = User;
        if (user == null)
        {
            return Content("User is not authenticated.");
        }

        var rolesClaim = user.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
        var rolesString = string.Join(", ", rolesClaim);
        return Content($"User: {user.Identity.Name}, Roles: {rolesString}");
    }



    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        var displayName = user!.FirstName + " " + user.LastName;
        var viewModel = new AdminIndexViewModel
        {
            DisplayName = displayName,
            Email = user.Email!,
            PhoneNumber = user.PhoneNumber!
        };

        return View(viewModel);
    }

    public IActionResult ProductList()
    {
        // Fetch and display a list of products from the database.
        // You can reuse the logic from the ProductsController.
        return View();
    }

    public IActionResult EditProduct(int id)
    {
        // Fetch the product with the given id from the database and display it in a form for editing.
        return View();
    }

    //[HttpPost]
    //public IActionResult UpdateProduct(int id, ProductViewModel model)
    //{
    //    // Validate and update the product in the database.
    //    return RedirectToAction("ProductList");
    //}

    public IActionResult AddProduct()
    {
        // Display a form for adding a new product.
        return View();
    }

    [HttpPost]
    public IActionResult SaveProduct()
    {
        // Validate and save the new product in the database.
        return RedirectToAction("ProductList");
    }
   
    public async Task<IActionResult> Profile()
    {
        // Get the currently logged-in user
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound();
        }

        // Create a UserProfileViewModel based on the user's information
        var userProfileViewModel = new UserProfileViewModel
        {
            DisplayName = $"{user.FirstName} {user.LastName}",
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            ProfileImageUrl = "" // Set the ProfileImageUrl based on where you store your images
        };

        // Return the view with the UserProfileViewModel
        return View("Profile", userProfileViewModel);
    }





    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveUserAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("User ID is required.");
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        // Remove user roles
        var roles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, roles);

        // Remove the user
        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            return BadRequest("Failed to remove the user.");
        }

        return RedirectToAction(nameof(UserList));
    }

    [HttpGet]
    public async Task<IActionResult> ManageRoles()
    {
        var users = await _userManager.Users.ToListAsync();
        var model = new ManageRolesViewModel
        {
            Users = users.Select(u => new ManageRolesUserViewModel
            {
                UserId = u.Id,
                Email = u.Email!,
                Roles = _userManager.GetRolesAsync(u).Result.ToList(),
                AvailableRoles = GetAvailableRoles(_userManager.GetRolesAsync(u).Result.FirstOrDefault()!)
            }).ToList()
        };

        return View(model);
    }

    private List<SelectListItem> GetAvailableRoles(string currentRole)
    {
        var roles = new List<SelectListItem>();

        roles.Add(new SelectListItem { Value = "Admin", Text = "Admin" });
        roles.Add(new SelectListItem { Value = "User", Text = "User" });

        // Find the current role SelectListItem
        var currentRoleItem = roles.FirstOrDefault(r => r.Value.Equals(currentRole, StringComparison.OrdinalIgnoreCase));

        if (currentRoleItem != null)
        {
            // Remove the current role SelectListItem from the list
            roles.Remove(currentRoleItem);

            // Insert the current role SelectListItem at the first position
            roles.Insert(0, currentRoleItem);
        }

        return roles;
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUserRole(string userId, string selectedRole)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound($"User with ID '{userId}' not found.");
        }

        // Get the existing roles for the user
        var existingRoles = await _userManager.GetRolesAsync(user);

        // Remove the user from their existing roles
        var removeFromRolesResult = await _userManager.RemoveFromRolesAsync(user, existingRoles);

        if (!removeFromRolesResult.Succeeded)
        {
            ModelState.AddModelError("", "Error removing user from existing roles.");
            return RedirectToAction("ManageRoles");
        }

        // Add the user to the selected role
        var addToRoleResult = await _userManager.AddToRoleAsync(user, selectedRole);

        if (!addToRoleResult.Succeeded)
        {
            ModelState.AddModelError("", "Error adding user to the new role.");
            return RedirectToAction("ManageRoles");
        }

        return RedirectToAction("ManageRoles");
    }






    public async Task<IActionResult> UserList()
    {
        var users = await _userManager.Users.ToListAsync();
        var userList = new List<UserListItemViewModel>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            userList.Add(new UserListItemViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CompanyName = user.CompanyName,
                Roles = roles
            });
        }

        return View(userList);
    }

    public async Task<IActionResult> Subscribers()
    {
        var subscriptions = await _newsletterSubscriptionRepository.GetAllAsync();
        var viewModel = subscriptions.Select(s => new NewsletterSubscriptionListItemViewModel
        {
            Id = s.Id,
            Email = s.Email
        }).ToList();

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteSubscriber(int id)
    {
        await _newsletterSubscriptionRepository.DeleteAsync(id);
        return RedirectToAction("Subscribers");
    }






}
