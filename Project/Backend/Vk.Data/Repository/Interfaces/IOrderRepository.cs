using Vk.Data.Domain;

namespace Vk.Data.Repository.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    List<Order> GetUserOrders(int userId, params string[] includes);
}
