using BMarketo.Models.Contexts;
using BMarketo.Models.Entities.Products;
using BMarketo.Services;
using BMarketo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BMarketo.Controllers;

public class ContactController : Controller
{
    private readonly ContactFormService _contactFormService;
    private readonly ProductsContext _productsContext;

    public ContactController(ContactFormService contactFormService, ProductsContext productsContext)
    {
        _contactFormService = contactFormService;
        _productsContext = productsContext;
    }


    [HttpGet]
    public IActionResult Index()
    {
        var contactInfo = _contactFormService.GetLatest();
        return View(contactInfo);
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactFormViewModel model)
    {
        if (ModelState.IsValid)
        {
            var contactSubmission = new ContactSubmissionEntity
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                CompanyName = model.CompanyName,
                Message = model.Message,
                SaveUserInfo = model.SaveUserInfo,
                SubmitDate = DateTime.Now
            };

            _productsContext.ContactSubmissions.Add(contactSubmission);
            await _productsContext.SaveChangesAsync();

            // You can add a TempData message to show a success message after submission.
            TempData["SuccessMessage"] = "Your contact form submission was successful!";
            return RedirectToAction("Index");
        }
        else
        {
            // Log or display the validation errors.
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                // Log the error messages to the console or any logging system you prefer.
                Console.WriteLine(error.ErrorMessage);
            }
        }


            return View(model);
    }


}
