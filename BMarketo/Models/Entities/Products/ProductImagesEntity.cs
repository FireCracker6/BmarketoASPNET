namespace BMarketo.Models.Entities.Products;

public class ProductImagesEntity
{
    public int Id { get; set; }
    public byte[] Image { get; set; } = null!;

    public string MimeType { get; set; } = null!;
    public int ProductId { get; set; }
    
    public virtual ProductsEntity Product { get; set; } = null!;
}


