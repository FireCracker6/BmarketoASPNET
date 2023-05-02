using static BMarketo.Models.Entities.Products.ReviewsEntity;

namespace BMarketo.Models.Entities.Products;

public class ProductsEntity
{
	public int Id { get; set; }
	public string Title { get; set; } = null!;
        public byte[] Image { get; set; } = null!;
        public string? SKUNumber { get; set; } 
	public string? Description { get; set; }
	public decimal? Price { get; set; }
	public decimal? OldPrice { get; set; }

    public int? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }

    //images 
    public List<ProductImagesEntity> ProductImages { get; set; } = new List<ProductImagesEntity>();

    // Tags
    public List<TagEntity> Tags { get; set; } = new List<TagEntity>();


    public virtual ICollection<CommentsEntity> Comments { get; set; } = null!;


    public virtual DescriptionEntity AdditionalDescription { get; set; } = null!;
    public virtual AdditionalInfoEntity AdditionalInfo { get; set; } = null!;
    public virtual ReviewsEntity Reviews { get; set; } = null!;
    public virtual ShoppingDeliveryEntity ShoppingDelivery { get; set; } = null!;
        
}


