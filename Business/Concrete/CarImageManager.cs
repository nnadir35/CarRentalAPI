using System.Linq.Expressions;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CarImageManager:ICarImageService
{
    private ICarImageDal _carImageDal;

    public CarImageManager(ICarImageDal carImageDal)
    {
        _carImageDal = carImageDal;
    }

    public IResult Add(CarImage entity)
    {
        _carImageDal.Add(entity);
        return new SuccessResult();
    }

    public IDataResult<List<CarImage>> GetAll()
    {
        throw new NotImplementedException();
    }

    public IDataResult<CarImage> GetById(Expression<Func<CarImage, bool>> filter)
    {
        throw new NotImplementedException();
    }
}