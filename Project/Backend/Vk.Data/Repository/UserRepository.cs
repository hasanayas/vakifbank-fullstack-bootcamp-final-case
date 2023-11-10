using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Repository.Interfaces;

namespace Vk.Data.Repository;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    public UserRepository(VkDbContext dbContext) : base(dbContext)
    {

    }
}
