namespace BMarketo.ViewModels;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Home";
    public GridCollectionViewModel BestCollection { get; set; } = null!;

    public GridCollectionViewModel DiscountCards { get; set; } = null!;

	public GridCollectionViewModel UpToSell { get; set; } = null!;
    public ProductDetailViewModel ProductDetails { get; set; } = null!;

	public TopSellingCollectionViewModel TopSelling { get; set; } = null!;

    public SubcribeNewsLetterViewModel SubcribeNewsLetter { get; set;} = null!;


}
