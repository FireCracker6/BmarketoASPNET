using BMarketo.Models.Contexts;
using BMarketo.Models.Entities;

namespace BMarketo.Services.Repositories;

public class AddressRepository : Repository<AddressEntity>
{
    public AddressRepository(IdentityContext context) : base(context)
    {
    }
}
