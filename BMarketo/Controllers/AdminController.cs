using BMarketo.Models.Contexts.Identity;
using BMarketo.Services.Repositories;
using BMarketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BMarketo.Controllers;
[Authorize(Policy = "AdminOnly")]
public class AdminController : Controller
{
    private readonly NewsletterSubscriptionRepository _newsletterSubscriptionRepository;
    private readonly UserManager<AppUser> _userManager;
    public AdminController(NewsletterSubscriptionRepository newsletterSubscriptionRepository, UserManager<AppUser> userManager)
    {
        _newsletterSubscriptionRepository = newsletterSubscriptionRepository;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        var displayName = user.FirstName + " " + user.LastName;
        var viewModel = new AdminIndexViewModel
        {
            DisplayName = displayName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
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
