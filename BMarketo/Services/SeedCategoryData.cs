using BMarketo.Models.Contexts;
using BMarketo.Models.Entities.Products;

namespace BMarketo.Services
{
    public class SeedCategoryData
    {
        private readonly ProductsContext _context;

        public SeedCategoryData(ProductsContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            // Check if the categories table is empty
            if (!_context.Categories.Any())
            {
                // Create and add the category entities
                var newCategory = new CategoryEntity { CategoryName = "New", IsNew = true, IsPopular = false, IsFeatured = false };
                var popularCategory = new CategoryEntity { CategoryName = "Popular", IsNew = false, IsPopular = true, IsFeatured = false };
                var featuredCategory = new CategoryEntity { CategoryName = "Featured", IsNew = false, IsPopular = false, IsFeatured = true };

                _context.Categories.AddRange(newCategory, popularCategory, featuredCategory);

                // Save the changes to the database
                _context.SaveChanges();
            }
        }
        public static async Task Seed(ProductsContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<CategoryEntity>
        {
            new CategoryEntity { CategoryName = "New", IsNew = true },
            new CategoryEntity { CategoryName = "Popular", IsPopular = true },
            new CategoryEntity { CategoryName = "Featured", IsFeatured = true }
        };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }
        }



    }

}
