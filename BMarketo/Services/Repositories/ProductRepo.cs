using BMarketo.Models.Contexts;
using BMarketo.Models.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BMarketo.Services.Repositories;

public abstract class ProductRepo<TEntity> where TEntity : class
{
    private readonly ProductsContext _context;


    protected ProductRepo(ProductsContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        if (entity != null)
            return entity;

        return null!;
    }


    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _context.Set<TEntity>().Where(expression).ToListAsync();
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

  


    public virtual async Task<bool> DeleteAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch { };
        return false;
    }
    public async Task<IEnumerable<ProductsEntity>> GetByTagAsync(string tagName)
    {
        return await _context.Products
            .Where(p => p.Tags.Any(t => t.TagName == tagName))
            .ToListAsync();
    }
    public async Task<IEnumerable<ProductsEntity>> GetByTagWithCommentsAsync(string tagName)
    {
        return await _context.Products
            .Include(p => p.Comments) // Include comments
            .Where(p => p.Tags.Any(t => t.TagName == tagName))
            .ToListAsync();
    }

    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<ProductImagesEntity>> GetProductImagesAsync(int productId)
    {
        return await _context.ProductImages
            .Where(pi => pi.ProductId == productId)
            .ToListAsync();
    }
    public async Task<byte[]> GetMainImageAsync(int productId)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (product == null || product.Image == null)
        {
            return null!;
        }

        return product.Image;
    }

    public async Task<IEnumerable<ProductsEntity>> GetRandomProductsAsync(int count)
    {
        return await _context.Products
            .OrderBy(r => Guid.NewGuid()) // Order randomly
            .Take(count) // Limit the number of products
            .ToListAsync();
    }





}


