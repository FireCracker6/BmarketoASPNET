using BMarketo.Models.Contexts;
using BMarketo.Models.Entities;

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
}
