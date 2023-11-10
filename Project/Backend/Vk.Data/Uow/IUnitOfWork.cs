using Vk.Data.Domain;
using Vk.Data.Repository.Interfaces;

namespace Vk.Data.Uow;

public interface IUnitOfWork
{
    void Complete();
    void CompleteTransaction();

    IProductRepository ProductRepository { get; }
    IOrderRepository OrderRepository { get; }
    IUserRepository UserRepository { get; }
    IAddressRepository AddressRepository { get; }
    IBasketRepository BasketRepository { get; }




}