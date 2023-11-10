using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Repository.Interfaces;

namespace Vk.Data.Repository;

public class ProductRepository:GenericRepository<Product> , IProductRepository
{
    public ProductRepository(VkDbContext dbContext) : base(dbContext)
    {

    }
}
