using System.Linq.Expressions;
using Core.Utilities.Results;

namespace Core.Business;

public interface IBaseService<T>
{
    IResult Add(T entity);
    IDataResult<List<T>> GetAll();
    
    IDataResult<T> GetById(Expression<Func<T,bool>> filter);

}