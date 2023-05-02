using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMarketo.Models.Entities.Products
{
	public class CommentsEntity
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = null!;

        [Required]
        public string CommentText { get; set; } = null!;

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual ProductsEntity Product { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public CommentsEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }


    }
}
