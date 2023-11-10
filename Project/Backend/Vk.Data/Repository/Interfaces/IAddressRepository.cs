using Vk.Data.Domain;

namespace Vk.Data.Repository.Interfaces;

public interface IAddressRepository : IGenericRepository<Address>
{

    List<Address> GetUserAddresses(int userId, params string[] includes);

}
