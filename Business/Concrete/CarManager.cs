using Business.Abstract;
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
    
    public IDataResult<List<Car>> GetById(int id)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.Id == id));
    }


    public IResult Add(Car car)
    {
        if (car.Description.Length>=3 && car.DailyPrice>0)
        {
            _carDal.Add(car);
            return new SuccessResult("eklendi");
        }else return new ErrorResult("olmadı");
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

    public IDataResult<List<CarDetailDto>> GetCarWithDetails()
    {
        List<CarDetailDto> carDetailDtos =  _carDal.GetCarsWithDetails();
        Console.WriteLine(carDetailDtos.Count);
        foreach (var carDetailDto in carDetailDtos)
        {
            Console.WriteLine($"{carDetailDto.Description}/ " +
                              $"{carDetailDto.Color}/ " +
                              $"{carDetailDto.Brand}/ " +
                              $"{carDetailDto.DailyPrice}/ ");
        }

        return new SuccessDataResult<List<CarDetailDto>>(carDetailDtos);
    }
}