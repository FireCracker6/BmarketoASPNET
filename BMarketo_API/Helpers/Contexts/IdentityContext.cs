using BMarketo_API.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BMarketo_API.Helpers.Contexts
{
    public class IdentityContext : IdentityDbContext<IdentityUserEntity>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
    }
}
