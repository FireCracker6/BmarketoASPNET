using BMarketo.Models;

namespace BMarketo.Services;

public class AddProductFormService
{
    private readonly List<ProductFormModel> _products = new()
    {
        new ProductFormModel()
        {
            Title = "Create New Product",
            NameLabel = "Product Name*",
            NameError = "Product name is required",
            DescriptionLabel = "Product Description*",
            DescriptionError = "Product description is required",
            PriceLabel = "Price*",
            Categorylabel = "Category",
            TagsLabel = "Select Product Tag",
            PriceError = "Price is required",
            OldPriceLabel = "Old Price",
            ImageLabel = "Product Image",
            SubmitButton = "CREATE PRODUCT"
        }
    };

    public ProductFormModel GetLatest()
    {
        return _products.LastOrDefault()!;
    }
}
