namespace BMarketo.Models.Entities.Products;

public class CategoryEntity
{
	public int? Id { get; set; }
	public string? CategoryName { get; set; } = null!;

    public bool IsNew { get; set; }
    public bool IsPopular { get; set; }
    public bool IsFeatured { get; set; }


    public ICollection<ProductsEntity>? Products { get; set; } = new List<ProductsEntity>();
}


