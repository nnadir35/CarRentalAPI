using System.Linq.Expressions;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class CarManager:ICarService
{
    private readonly ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }
    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll());
    }

    public IDataResult<Car> GetById(Expression<Func<Car, bool>> filter)
    {
        var result = _carDal.Get(filter);
        
        return new DataResult<Car>(result ==null?false:true,result ==null?null:result);
    }

    
    
    [ValidationAspect(typeof(CarValidator))]
    public IResult Add(Car car)
    {
        _carDal.Add(car);
        return new SuccessResult("eklendi");
    }

    public IDataResult<List<Car>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IDataResult<List<Car>> GetCarsByBrandId(int id)
    {
        List<Car> cars = _carDal.GetAll(indexedCar => indexedCar.BrandId == id)??null;
        Console.WriteLine($"GetCarsByBrandId: {cars.Count}");
        return new SuccessDataResult<List<Car>>(cars);
    }

    public IDataResult<List<Car>> GetCarsByColorId(int id)
    {
        List<Car> cars = _carDal.GetAll(indexedCar => indexedCar.ColorId == id)??null;
        Console.WriteLine($"GetCarsByColorId: {cars.Count}");
        return new SuccessDataResult<List<Car>>(cars);
    }

    public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
    {
        throw new NotImplementedException();
    }

    public IDataResult<List<CarDetailDto>> GetCarWithDetails()
    {
        List<CarDetailDto> carDetailDtos =  _carDal.GetCarsWithDetails();
        Console.WriteLine(carDetailDtos.Count);
        return new SuccessDataResult<List<CarDetailDto>>(carDetailDtos);
    }
}