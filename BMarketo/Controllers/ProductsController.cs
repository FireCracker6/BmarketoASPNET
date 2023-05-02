using BMarketo.Models.Contexts;
using BMarketo.Models.Entities.Products;
using BMarketo.Services.Repositories;
using BMarketo.ViewModels;
using BMarketo.ViewModels.CRUD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static BMarketo.Models.Entities.Products.ReviewsEntity;

namespace BMarketo.Controllers;

public class ProductsController : Controller
{
	private readonly ProductsContext _context;
    private readonly ProductsRepository _repository;
    private readonly List<IFormFile> images = new List<IFormFile>();
    public ProductsController(ProductsContext context, ProductsRepository repository)
    {
        _context = context;
        _repository = repository;
    }
    [HttpGet]
    public async Task<IActionResult> Index(int selectedCategoryId = 0)
    {
        // Retrieve the list of products from the repository.
        var products = await _repository.GetAllAsync();

        // Retrieve the list of categories from the database.
        var categories = await _context.Categories.ToListAsync();

        // Filter products based on selected category.
        var filteredProducts = products.Where(p => selectedCategoryId == 0 || p.Category!.Id == selectedCategoryId);


        // Create a ProductsIndexViewModel instance.
        var viewModel = new ProductsIndexViewModel
        {





            Title = "Products",
            All = new GridCollectionViewModel
            {
                ShowCategoryFilter = true,
                Title = "All Products",
                GridItems = filteredProducts.Select(product => new GridCollectionItemViewModel
                {
                    Id = product.Id.ToString(),
                    Image = product.Image,
                    Title = product.Title,
                    OldPrice = product.OldPrice,
                    Price = product.Price ?? 0,
                    Category = product.Category!.CategoryName,

                }).ToList(),
                Categories = categories.Select(category => category.CategoryName!),
                CategoriesSelected = categories.Select(category => new SelectListItem
                {
                    Text = category.CategoryName!,
                    Value = category.Id.ToString(),
                    Selected = category.Id == selectedCategoryId
                })
            },
            SelectedCategoryId = selectedCategoryId,
           
           
        };

        
        return View(viewModel);
    }


    [HttpGet]
    public async Task<IActionResult> ProductDetails(int id)
    {
      //  ViewBag.ProductId = id; // Set the product ID to the ViewBag
        // Retrieve the selected product from the repository.
        var product = await _repository.GetByIdAsync(id);
        var productImages = await _repository.GetProductImagesAsync(id);
        // Create a ProductDetailViewModel instance.
        var viewModel = new ProductDetailViewModel
        {
            ProductId = id,
            ProductDetailTitle = product?.Title ?? "",
            Description = product?.Description ?? "",
            Price = product?.Price ?? 0.00m,
            SKUNumber = product?.SKUNumber ?? "",
            Category = product?.Category?.CategoryName ?? "",
            Images = productImages.ToList(),

            UnderImage1 = productImages.FirstOrDefault()?.Image ?? null!,
            UnderImage2 = productImages.Skip(1).FirstOrDefault()?.Image ?? null!,
            UnderImage3 = productImages.Skip(2).FirstOrDefault()?.Image ?? null!,
            UnderImage4 = productImages.Skip(3).FirstOrDefault()?.Image ?? null!,
        };


        //// Retrieve the main image for the product.
        var mainImageBytes = await _repository.GetMainImageAsync(id);
        viewModel.MainImage = mainImageBytes;

        //// Retrieve the product's related products.
        //viewModel.RelatedProducts = await _repository.GetRelatedProductsAsync(product);

        return View(viewModel);
    }




    public IActionResult Search()
	{
		ViewData["Title"] = "Search for products";
		return View();
	}


    [HttpGet]
    public async Task<IActionResult> AddProducts()
    {
        // Retrieve categories from the database
        var categories = await _context.Categories.ToListAsync();

        // Create a SelectList with the category options
        var categoryOptions = new SelectList(categories, "Id", "CategoryName");
        var tags = await _context.Tags.ToListAsync();
        var tagItems = tags.Select(t => new SelectListItem
        {
            Value = t.Id.ToString(),
            Text = t.TagName
        });

        // Create a new ProductFormViewModel and set the CategoryOptions property to the SelectList
        var viewModel = new ProductFormViewModel
        {
            CategoryOptions = categoryOptions,
            SelectedCategoryId = categories.FirstOrDefault()?.Id ?? 0, // Set the default selected category ID to the first category ID, or 0 if the categories list is empty
            TagsItems = tags
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AddProducts(ProductFormViewModel model)
    {
        if (ModelState.IsValid)
        {
            var entity = model.ToEntity(ModelState);

            if (entity != null)
            {
                // Set the category based on the user's selection
                var selectedCategory = await _context.Categories.FindAsync(model.SelectedCategoryId);
                if (selectedCategory != null)
                {
                    entity.Category = selectedCategory;
                }

                // Set the tags of the product
                foreach (var tagId in model.SelectedTagIds)
                {
                    var tag = await _context.Tags.FindAsync(tagId);
                    if (tag != null)
                    {
                        entity.Tags.Add(tag);
                    }
                }
                // Handle the optional information
                if (!string.IsNullOrEmpty(model.DescriptionText))
                {
                    entity.AdditionalDescription = new DescriptionEntity { Text = model.DescriptionText };
                }
                // Save AdditionalDescription image to the database
                if (model.AdditionalDescriptionImage != null && model.AdditionalDescriptionImage.Length > 0)
                {
                    using var stream = model.AdditionalDescriptionImage.OpenReadStream();
                    using var ms = new MemoryStream();
                    await stream.CopyToAsync(ms);

                    if (entity.AdditionalDescription == null)
                    {
                        entity.AdditionalDescription = new DescriptionEntity();
                    }

                    entity.AdditionalDescription.Image = ms.ToArray();
                }


                if (!string.IsNullOrEmpty(model.AdditionalInfoText))
                {
                    entity.AdditionalInfo = new AdditionalInfoEntity { Text = model.AdditionalInfoText };
                }
                // Save AdditionalInfo image to the database
                if (model.AdditionalInfoImage != null && model.AdditionalInfoImage.Length > 0)
                {
                    using var stream = model.AdditionalInfoImage.OpenReadStream();
                    using var ms = new MemoryStream();
                    await stream.CopyToAsync(ms);

                    if (entity.AdditionalInfo == null)
                    {
                        entity.AdditionalInfo = new AdditionalInfoEntity();
                    }

                    entity.AdditionalInfo.Image = ms.ToArray();
                }

                if (!string.IsNullOrEmpty(model.ReviewsText))
                {
                    entity.Reviews = new ReviewsEntity { Text = model.ReviewsText };
                }

                // Save Reviews image to the database
                if (model.ReviewsImage != null && model.ReviewsImage.Length > 0)
                {
                    using var stream = model.ReviewsImage.OpenReadStream();
                    using var ms = new MemoryStream();
                    await stream.CopyToAsync(ms);

                    if (entity.Reviews == null)
                    {
                        entity.Reviews = new ReviewsEntity();
                    }

                    entity.Reviews.Image = ms.ToArray();
                }

                if (!string.IsNullOrEmpty(model.ShoppingDeliveryText))
                {
                    entity.ShoppingDelivery = new ShoppingDeliveryEntity { Text = model.ShoppingDeliveryText };
                }

                // Save AdditionalInfo image to the database
                if (model.ShoppingDeliveryImage != null && model.ShoppingDeliveryImage.Length > 0)
                {
                    using var stream = model.ShoppingDeliveryImage.OpenReadStream();
                    using var ms = new MemoryStream();
                    await stream.CopyToAsync(ms);

                    if (entity.ShoppingDelivery == null)
                    {
                        entity.ShoppingDelivery = new ShoppingDeliveryEntity();
                    }

                    entity.ShoppingDelivery.Image = ms.ToArray();
                }

                _context.Products.Add(entity);
                await _context.SaveChangesAsync();

                var files = Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        using var stream = file.OpenReadStream();
                        using var ms = new MemoryStream();
                        await stream.CopyToAsync(ms);

                        var imageEntity = new ProductImagesEntity
                        {
                            ProductId = entity.Id,
                            Image = ms.ToArray(),
                            MimeType = file.ContentType
                        };

                        _context.ProductImages.Add(imageEntity);
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Index");
            }
        }

        // Retrieve the categories from the database again
        var categories = await _context.Categories.ToListAsync();
        var categoryOptions = new SelectList(categories, "Id", "CategoryName");

        // Set the CategoryOptions and SelectedCategoryId properties of the ViewModel
        model.CategoryOptions = categoryOptions;

        return View(model);
    }




    [HttpGet]
    public IActionResult ProductList()
    {
      //  var products = _context.Products.ToList();
        var products = _context.Products.Include(p => p.Tags).ToList(); // Include the tags

        var productListItems = products.Select(p => new ProductListItemViewModel
        {
            Id = p.Id,
            Title = p.Title,
            Price = p.Price,
           Description = p.Description!,
           Image = p.Image,
            Category = p.Category?.CategoryName!,
            Tags = string.Join(", ", p.Tags.Select(t => t.TagName))
        }).ToList();

        return View(productListItems);
    }
    public IActionResult GetImage(int id)
    {
        var product = _context.Products.Find(id);

        if (product?.Image == null)
        {
            return NotFound();
        }

        return File(product.Image, "image/jpeg");
    }
    public async Task<IActionResult> GetMainImage(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null || product.Image == null)
        {
            return NotFound();
        }

        return File(product.Image, "image/jpeg");
    }

    public async Task<IActionResult> GetUnderImage(int id)
    {
        var underImage = await _context.ProductImages.FindAsync(id);
        if (underImage == null || underImage.Image == null)
        {
            return NotFound();
        }

        return File(underImage.Image, "image/jpeg");
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _context.Products.Include(p => p.Tags).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        var viewModel = new ProductFormViewModel
        {
            Id = product.Id,
            Title = product.Title,
            ImageFile = null, // You cannot directly set the IFormFile property from an existing product image
            SKUNumber = product.SKUNumber,
            Description = product.Description,
            Price = product.Price,
            OldPrice = product.OldPrice,
            SelectedCategoryId = product.Category?.Id ?? 0
        };

        // Retrieve the tags from the database
        var tags = await _context.Tags.ToListAsync();
        viewModel.TagsItems = tags;

        // Set the selected tags
        viewModel.SelectedTagIds = product.Tags.Select(t => (int)t.Id).ToList();

        // Retrieve the categories from the database
        var categories = await _context.Categories.ToListAsync();
        viewModel.CategoryOptions = new SelectList(categories, "Id", "CategoryName", viewModel.SelectedCategoryId);
        viewModel.Images = await _context.ProductImages.Where(pi => pi.ProductId == id).ToListAsync();

        return View(viewModel);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProductFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var product = await _context.Products.Include(p => p.Category).Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            // Update the product properties from the viewModel
            product.Title = viewModel.Title;
            product.SKUNumber = viewModel.SKUNumber;
            product.Description = viewModel.Description;
            product.Price = viewModel.Price;
            product.OldPrice = viewModel.OldPrice;
          //  product.CategoryId = viewModel.CategoryId;
        

            // Update the product image if a new one was uploaded
            if (viewModel.ImageFile != null)
            {
                using var ms = new MemoryStream();
                viewModel.ImageFile.CopyTo(ms);
                product.Image = ms.ToArray();
            }


            // Update the main image
            if (viewModel.ImageFile != null)
            {
                using var ms = new MemoryStream();
                viewModel.ImageFile.CopyTo(ms);
                product.Image = ms.ToArray();
            }

            // Add more under images
            if (viewModel.UnderImageFiles != null && viewModel.UnderImageFiles.Any())
            {
                foreach (var underImageFile in viewModel.UnderImageFiles)
                {
                    using var ms = new MemoryStream();
                    underImageFile.CopyTo(ms);
                    var underImage = new ProductImagesEntity
                    {
                        ProductId = product.Id,
                        Image = ms.ToArray()
                    };
                    _context.ProductImages.Add(underImage);
                }
            }
            // Update AdditionalDescription
            var additionalDescriptionEntity = await _context.AdditionalDescription.FirstOrDefaultAsync(a => a.ProductId == id);
            if (additionalDescriptionEntity != null)
            {
                if (!string.IsNullOrEmpty(viewModel.DescriptionText))
                {
                    additionalDescriptionEntity.Text = viewModel.DescriptionText;
                }

                if (viewModel.AdditionalDescriptionImage != null && viewModel.AdditionalDescriptionImage.Length > 0)
                {
                    using var stream = viewModel.AdditionalDescriptionImage.OpenReadStream();
                    using var ms = new MemoryStream();
                    await stream.CopyToAsync(ms);
                    additionalDescriptionEntity.Image = ms.ToArray();
                }
            }

            // Update AdditionalInfo
            var additionalInfoEntity = await _context.AdditionalInfo.FirstOrDefaultAsync(a => a.ProductId == id);
            if (additionalInfoEntity != null && !string.IsNullOrEmpty(viewModel.AdditionalInfoText))
            {
                additionalInfoEntity.Text = viewModel.AdditionalInfoText;
            }

            // Update Reviews
            var reviewsEntity = await _context.Reviews.FirstOrDefaultAsync(a => a.ProductId == id);
            if (reviewsEntity != null && !string.IsNullOrEmpty(viewModel.ReviewsText))
            {
                reviewsEntity.Text = viewModel.ReviewsText;
            }

            // Update ShoppingDelivery
            var shoppingDeliveryEntity = await _context.ShoppingDelivery.FirstOrDefaultAsync(a => a.ProductId == id);
            if (shoppingDeliveryEntity != null && !string.IsNullOrEmpty(viewModel.ShoppingDeliveryText))
            {
                shoppingDeliveryEntity.Text = viewModel.ShoppingDeliveryText;
            }



            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ProductList));
        }

        viewModel.Categories = await _context.Categories.ToListAsync();
       
        viewModel.Images = await _context.ProductImages.Where(pi => pi.ProductId == id).ToListAsync();

        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteUnderImage(int id)
    {
        var underImage = await _context.ProductImages.FindAsync(id);
        if (underImage == null)
        {
            return NotFound();
        }

        _context.ProductImages.Remove(underImage);
        await _context.SaveChangesAsync();

        return RedirectToAction("Edit", new { id = underImage.ProductId });
    }


    [HttpGet]
    public async Task<IActionResult> FilterByCategory(int categoryId)
    {
        var products = await _repository.GetAsync(p => p.CategoryId == categoryId);

        return View("Index", products);
    }
    public IActionResult ProductComments(int id)
    {
        // Fetch comments for the given product ID from the database
        var comments = _context.Comments.Where(c => c.ProductId == id).ToList();

        // Pass the comments to the view
        return View(comments);
    }










}
