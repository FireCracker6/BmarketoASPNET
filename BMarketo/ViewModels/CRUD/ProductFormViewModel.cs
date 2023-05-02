using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BMarketo.Models.Entities.Products;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BMarketo.ViewModels.CRUD;

public class ProductFormViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public IFormFile? ImageFile { get; set; } 
    public string? SKUNumber { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public decimal? OldPrice { get; set; }

    //public int CategoryId { get; set; } // Change the name of the property
    //public List<SelectListItem> CategoryOptions { get; set; } = null!;
    public List<int> SelectedTagIds { get; set; } = new List<int>();
    public List<SelectListItem> AvailableTags { get; set; } = new List<SelectListItem>();
    public IEnumerable<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>(); // Add this property

    public IEnumerable<TagEntity> TagsItems { get; set; } = new List<TagEntity>();

    public IEnumerable<ProductImagesEntity> Images { get; set; } = new List<ProductImagesEntity>();

    public List<IFormFile>? UnderImageFiles { get; set; }


    public bool IsNew { get; set; }
    public bool IsPopular { get; set; }
    public bool IsFeatured { get; set; }
    [Display(Name = "Category")]

    public int SelectedCategoryId { get; set; }

    public IEnumerable<SelectListItem>? CategoryOptions { get; set; }

    public string? DescriptionText { get; set; }
    public IFormFile? AdditionalDescriptionImage { get; set; }

    public string? AdditionalInfoText { get; set; }
    public IFormFile? AdditionalInfoImage { get; set; }
    
    public string? ReviewsText { get; set; }
    public IFormFile? ReviewsImage { get; set; }

    public string? ShoppingDeliveryText { get; set; }
    public IFormFile? ShoppingDeliveryImage { get; set; }


    public List<IFormFile>? ProductImages { get; set; }

    public ProductsEntity ToEntity(ModelStateDictionary modelState)
    {
        byte[]? imageBytes = null;
        try
        {
            if (ImageFile != null)
            {
                using (var ms = new MemoryStream())
                {
                    ImageFile.CopyTo(ms);
                    imageBytes = ms.ToArray();
                }
            }

            return new ProductsEntity
            {
                Title = Title,
                Image = imageBytes,
                Tags = (List<TagEntity>)TagsItems,
                SKUNumber = SKUNumber,
                Description = Description,
                Price = Price,
                OldPrice = OldPrice
            };
        }
        catch (Exception ex)
        {
            modelState.AddModelError("ImageFile", ex.Message);
            return null!;
        }
    }

}
