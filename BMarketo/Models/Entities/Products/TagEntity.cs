namespace BMarketo.Models.Entities.Products;

public class TagEntity
{
    public int? Id { get; set; }
    public string? TagName { get; set; } = null!;
    public List<ProductTag> ProductTag { get; set; }
}
