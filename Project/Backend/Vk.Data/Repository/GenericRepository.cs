using Microsoft.EntityFrameworkCore;
using Vk.Base;
using Vk.Base.Date;
using Vk.Data.Context;
using Vk.Data.Repository.Interfaces;

namespace Vk.Data.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseModel
{
    internal readonly VkDbContext dbContext;

    public GenericRepository(VkDbContext dbContext)
    {
        this.dbContext = dbContext;
    }


    public List<TEntity> GetAll(params string[] includes)
    {
        var query = dbContext.Set<TEntity>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.ToList();
    }

    public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken, params string[] includes)
    {
        var query = dbContext.Set<TEntity>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }


    public void Insert(TEntity entity)
    {
        entity.InsertDate = InstantDate.GetTurkeyLocalTime();
        dbContext.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        var existingEntity = dbContext.Set<TEntity>().Local.FirstOrDefault(e => e.Id == entity.Id);

        if (existingEntity != null)
        {
            entity.InsertDate = existingEntity.InsertDate;
            dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        }else
            dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var entity = dbContext.Set<TEntity>().Find(id);
        dbContext.Set<TEntity>().Remove(entity);
    }


}