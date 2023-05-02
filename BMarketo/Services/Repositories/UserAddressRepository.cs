using BMarketo.Models.Contexts;
using BMarketo.Models.Entities;

namespace BMarketo.Services.Repositories;

public class UserAddressRepository : Repository<UserAddressEntity>
{
    public UserAddressRepository(IdentityContext context) : base(context)
    {
    }
}
