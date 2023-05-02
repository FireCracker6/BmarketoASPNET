using Microsoft.AspNetCore.Mvc.Rendering;

namespace BMarketo.ViewModels;

public class GridCollectionViewModel
{
    public string Title { get; set; } = "";
   
    public IEnumerable<string> Categories { get; set; } = null!;
    public IEnumerable<SelectListItem> CategoriesSelected { get; set; } = null!;
    public IEnumerable<GridCollectionItemViewModel> GridItems { get; set; } = null!;
    public IEnumerable<GridCollectionSmallCardsItemViewModel> GridItemsSmall { get; set; } = null!;
    public int SelectedCategoryId { get; set; } = 0;
    public bool LoadMore { get; set; } = false;
    public bool ShowCategoryFilter { get; set; }
}
