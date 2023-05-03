namespace BMarketo.ViewModels;

public class TopSellingCollectionViewModel
{
    public string Title { get; set; } = "";
    public IEnumerable<GridCollectionItemViewModel> GridItems { get; set; } = null!;
		public IEnumerable<GridCollectionItemViewModel> GridDiscountItems { get; set; } = null!;

		public bool Arrows { get; set; } = false;
}
