using BMarketo.Models.Entities.Products;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BMarketo.ViewModels;

public class ProductsIndexViewModel
{
    public string Title { get; set; } = "Products";
    public IEnumerable<string> Categories { get; set; } = null!;
    public int SelectedCategoryId { get; set; } // Default value of 0 for no category selected
    // Tags
    public List<TagEntity> TagItems { get; set; } = new List<TagEntity>();
    public GridCollectionViewModel All { get; set; } = null!;
    public bool ShowCategoryFilter { get; set; }
}
