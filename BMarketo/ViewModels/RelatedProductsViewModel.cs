namespace BMarketo.ViewModels
{
    public class RelatedProductsViewModel
    {
        public string Title { get; set; } = "";
        public IEnumerable<GridCollectionItemViewModel> GridItems { get; set; } = null!;

    }
}
