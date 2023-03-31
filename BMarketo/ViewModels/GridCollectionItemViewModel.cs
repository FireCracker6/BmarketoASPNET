namespace BMarketo.ViewModels
{
    public class GridCollectionItemViewModel
    {
        public string Id { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public decimal? OldPrice { get; set; } = null!;
        public decimal Price { get; set; }

        // TopSelling Section Only
        public string? Description { get; set; } = "";
        public string? AdminPosts { get; set; } = null!;
		public string? Comments { get; set; } = null!;

		public string HeaderTitle { get; set; } = "";
		public string HeaderText { get; set; } = "";
        public string HeaderSlogan { get; set; } = "";
		public string DiscountDescription { get; set; } = "";
		public string DiscountLink { get; set; } = "";
	}
}
