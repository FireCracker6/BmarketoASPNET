using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMarketo.Models.Entities.Products
{
    public class DescriptionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = null!;

        public byte[]? Image { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual ProductsEntity Product { get; set; } = null!;
    }
    public class AdditionalInfoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = null!;

        public byte[]? Image { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual ProductsEntity Product { get; set; } = null!;
    }

    public class ReviewsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = null!;

        public byte[]? Image { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual ProductsEntity Product { get; set; } = null!;

        public class ShoppingDeliveryEntity
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            public string Text { get; set; } = null!;

            public byte[]? Image { get; set; }

            [ForeignKey("Product")]
            public int ProductId { get; set; }

            public virtual ProductsEntity Product { get; set; } = null!;
        }
    }
}
