using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICarService:IBaseService<Car>
{
    IDataResult<List<Car>> GetById(int id);
    IDataResult<List<Car>> GetCarsByBrandId(int id);
    IDataResult<List<Car>> GetCarsByColorId(int id);
}