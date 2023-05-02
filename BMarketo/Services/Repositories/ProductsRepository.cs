using BMarketo.Migrations.Products;
using BMarketo.Models.Contexts;
using BMarketo.Models.Entities.Products;

namespace BMarketo.Services.Repositories;

public class ProductsRepository : ProductRepo<ProductsEntity>
{
    public ProductsRepository(ProductsContext context) : base(context)
    {
    }
   

}
