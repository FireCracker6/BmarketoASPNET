using BMarketo.Models.Contexts.Identity;
using BMarketo.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BMarketo.Models.Contexts;

public class IdentityContext : IdentityDbContext<AppUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }
    public DbSet<AddressEntity> AspNetAddresses { get; set; }
    public DbSet<UserAddressEntity> AspNetUserAddresses { get; set; }
    public DbSet<NewsletterSubscription> NewsletterSubscriptions { get; set; }

    /*

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        var roleId = Guid.NewGuid().ToString();
        var userId = Guid.NewGuid().ToString();



        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin"

            }
        );

        var passwordHasher = new PasswordHasher<AppUser>();

        builder.Entity<AppUser>().HasData(new AppUser
        {
            Id = userId,
            FirstName = "Jack",
            LastName = "Russell",
            UserName = "admin",
            Email = "administrator@domain.com",

            PasswordHash = passwordHasher.HashPassword(null!, "BytMig123!"),

        });

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = roleId,
            UserId = userId,
        });

    }
    */
}

