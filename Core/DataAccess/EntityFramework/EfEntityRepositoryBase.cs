using System.Linq.Expressions;
using Core.Entities;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TContext> :IEntityRepository<TEntity>
    where TEntity : BaseEntity, new()
    where TContext : DbContext, new()
{
    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
    {
        using (TContext context = new TContext())
        {
            return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        }
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using (TContext context = new TContext())
        {
            return context.Set<TEntity>().Where(filter).FirstOrDefault();
        }
    }

    public void Add(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            context.Add(entity);
            context.SaveChanges();
        }
    }

    public void Update(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }

    public void Delete(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
    public IDataResult<bool> IsRecordExist(Expression<Func<TEntity, bool>> filter)
    {
        using (TContext context = new TContext())
        {
            if (context.Set<TEntity>().Where(filter).Any())
                return new SuccessDataResult<bool>(true);
            
        }
        return new ErrorDataResult<bool>(false);
    }
}