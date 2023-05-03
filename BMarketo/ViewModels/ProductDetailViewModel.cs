using BMarketo.Models.Entities.Products;

namespace BMarketo.ViewModels
{
    public class ProductDetailViewModel
    {
        public List<ProductImagesEntity> Images { get; set; } = new List<ProductImagesEntity>();
        public byte[] MainImage { get; set; }
        public byte[] UnderImage1 { get; set; }
        public byte[] UnderImage2 { get; set; }
        public byte[] UnderImage3 { get; set; }
        public byte[] UnderImage4 { get; set; }
        public string ProductDetailTitle { get; set; }
        public string Description { get; set; }
        public int ProductDetailReviews { get; set; }
        public decimal Price { get; set; }
        public string SKUNumber { get; set; }
        public string Category { get; set; }
        public int ProductId { get; set; }

        public RelatedProductsViewModel RelatedProducts { get; set; } = new RelatedProductsViewModel();
        public GridCollectionViewModel SmallCards { get; set; }
    }

}
