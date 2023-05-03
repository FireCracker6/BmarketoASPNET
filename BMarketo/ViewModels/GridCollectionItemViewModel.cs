using System.Diagnostics;
using BMarketo.Migrations.Products;
using BMarketo.Models.Entities.Products;

namespace BMarketo.ViewModels
{
    public class GridCollectionItemViewModel
    {
        public int Id { get; set; } 
        public string ImageUrl { get; set; } = null!;
        public byte[]? Image { get; set; } = null!;
        public string MimeType { get; set; } = null!;
        public string Title { get; set; } = null!;
        public decimal? OldPrice { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Category { get; set; } 
        public int CategoryId { get; set; } // Add the CategoryId property here
        // TopSelling Section Only
        public string? Description { get; set; } = "";
        public string? AdminPosts { get; set; } = null!;
		public string? Comments { get; set; } = null!;
        public int CommentsCount { get; set; }
        public List<string> Tags { get; set; } = null!;

        public string HeaderTitle { get; set; } = "";
		public string HeaderText { get; set; } = "";
        public string HeaderSlogan { get; set; } = "";
		public string DiscountDescription { get; set; } = "";
		public string DiscountLink { get; set; } = "";
	}
    public class TagViewModel
    {
        public int Id { get; set; }
        public string TagName { get; set; }
    }
}
