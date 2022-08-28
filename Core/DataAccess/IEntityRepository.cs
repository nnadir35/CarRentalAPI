using System.Linq.Expressions;
using Core.Entities;
using Core.Utilities.Results;


namespace Core.DataAccess;

public interface IEntityRepository<T> where T:BaseEntity,new()
{
    List<T> GetAll(Expression<Func<T, bool>>? filter = null);
    T Get(Expression<Func<T,bool>> filter);
    void Add(T entity);

    public IDataResult<bool> IsRecordExist(Expression<Func<T, bool>> filter);
    void Update(T entity);
    void Delete(T entity);
}