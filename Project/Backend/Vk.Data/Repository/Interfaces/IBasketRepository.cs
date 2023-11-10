using Vk.Data.Domain;

namespace Vk.Data.Repository.Interfaces;

public interface IBasketRepository : IGenericRepository<Basket>
{
    List<Basket> GetUserBaskets(int userId, params string[] includes);
    List<Basket> GetOrderBaskets(int orderId, params string[] includes);
    List<Basket> GetProductBaskets(int productId, params string[] includes);
}
