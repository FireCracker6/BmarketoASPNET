using BMarketo.Models.Contexts;
using BMarketo.Services.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace BMarketo.Controllers;

public class ProductImagesController : Controller
{
    private readonly ProductsContext _context;
    private readonly ProductsRepository _repository;
    public ProductImagesController(ProductsContext context, ProductsRepository repository)
    {
        _context = context;
        _repository = repository;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult GetImage(int id)
    {
        var image = _context.ProductImages.Find(id);

        if (image?.Image == null)
        {
            return NotFound();
        }

        return File(image.Image, "image/jpeg");
    }
}

