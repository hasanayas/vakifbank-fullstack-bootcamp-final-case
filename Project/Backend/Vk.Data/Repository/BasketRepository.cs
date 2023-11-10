using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Repository.Interfaces;

namespace Vk.Data.Repository;

public class BasketRepository : GenericRepository<Basket>, IBasketRepository
{
    public BasketRepository(VkDbContext dbContext) : base(dbContext)
    {
    }

    public List<Basket> GetOrderBaskets(int orderId, params string[] includes)
    {
        var query = dbContext.Set<Basket>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.Where(x => x.OrderId == orderId).ToList();
    }

    public List<Basket> GetProductBaskets(int productId, params string[] includes)
    {
        var query = dbContext.Set<Basket>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.Where(x => x.ProductId == productId).ToList();
    }

    public List<Basket> GetUserBaskets(int userId, params string[] includes)
    {
        var query = dbContext.Set<Basket>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.Where(x => x.UserId == userId).ToList();
    }
}
