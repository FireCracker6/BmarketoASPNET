using System.ComponentModel.DataAnnotations;

namespace BMarketo.Models.Entities.Products;
    public class ProductTag
    {
    [Key]
    public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductsEntity Product { get; set; }

        public int TagId { get; set; }
        public TagEntity Tag { get; set; }
    }


