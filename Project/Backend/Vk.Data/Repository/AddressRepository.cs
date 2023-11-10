using System.Data.Entity;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Repository.Interfaces;

namespace Vk.Data.Repository;

public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    public AddressRepository(VkDbContext dbContext) : base(dbContext)
    {
    }



    public List<Address> GetUserAddresses(int userId, params string[] includes)
    {
        var query = dbContext.Set<Address>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.Where(x => x.UserId == userId).ToList();
    }



}
