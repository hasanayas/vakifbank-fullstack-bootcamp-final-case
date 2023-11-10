using Serilog;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Repository;
using Vk.Data.Repository.Interfaces;

namespace Vk.Data.Uow;

public class UnitOfWork : IUnitOfWork
{

    private readonly VkDbContext dbContext;

    public UnitOfWork(VkDbContext dbContext)
    {
        this.dbContext = dbContext;

        ProductRepository = new ProductRepository(dbContext);
        OrderRepository = new OrderRepository(dbContext);
        UserRepository = new UserRepository(dbContext);
        AddressRepository = new AddressRepository(dbContext);
        BasketRepository = new BasketRepository(dbContext);

    }

    public IProductRepository ProductRepository { get; private set; }

    public IOrderRepository OrderRepository { get; private set; }

    public IUserRepository UserRepository { get; private set; }

    public IAddressRepository AddressRepository { get; private set; }

    public IBasketRepository BasketRepository { get; private set; }

    public void Complete()
    {
        dbContext.SaveChanges();
    }

    public void CompleteTransaction()
    {
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                dbContext.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.Error("CompleteTransaction", ex);
            }
        }
    }

}