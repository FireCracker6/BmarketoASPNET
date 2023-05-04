using BMarketo.Models.Contexts;
using BMarketo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BMarketo.Services.Repositories;

public class NewsletterSubscriptionRepository
{
    private readonly ProductsContext _context;

    public NewsletterSubscriptionRepository(ProductsContext context)
    {
        _context = context;
    }

    public async Task AddAsync(NewsletterSubscription subscription)
    {
        _context.NewsletterSubscriptions.Add(subscription);
        await _context.SaveChangesAsync();
    }
    public async Task<List<NewsletterSubscription>> GetAllAsync()
    {
        return await _context.NewsletterSubscriptions.ToListAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var subscription = await _context.NewsletterSubscriptions.FindAsync(id);
        if (subscription != null)
        {
            _context.NewsletterSubscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
        }
    }


}
