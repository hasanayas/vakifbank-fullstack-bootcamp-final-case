using Vk.Base;

namespace Vk.Data.Repository.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : BaseModel
{

    Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken, params string[] includes);
    List<TEntity> GetAll(params string[] includes);
    void Delete(int id);
    void Update(TEntity entity);
    void Insert(TEntity entity);

}
