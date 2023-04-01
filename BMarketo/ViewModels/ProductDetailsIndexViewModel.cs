namespace BMarketo.ViewModels
{
    public class ProductDetailsIndexViewModel
    {
        public string Title { get; set; } = "Related Products";
        public RelatedProductsViewModel RelatedProducts { get; set; } = null!;
        public GridCollectionViewModel SmallCards { get; set; } = null!;
        public IEnumerable<GridCollectionItemViewModel> GridItems { get; set; } = null!;
        public IEnumerable<GridCollectionSmallCardsItemViewModel> GridItemsSmall { get; set; } = null!;

    }
}
