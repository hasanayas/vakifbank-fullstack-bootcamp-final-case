using System.Data.Entity;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Repository.Interfaces;

namespace Vk.Data.Repository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(VkDbContext dbContext) : base(dbContext)
    {
    }

    public List<Order> GetUserOrders(int userId, params string[] includes)
    {
        var query = dbContext.Set<Order>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.Where(x => x.UserId == userId).ToList();
    }
}
