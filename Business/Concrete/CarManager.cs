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
    public List<Car> GetAll()
    {
        return _carDal.GetAll();
    }

    public void Add(Car car)
    {
        if (car.Description.Length>=3 && car.DailyPrice>0)
        {
            _carDal.Add(car);
        }else Console.WriteLine("olmadı");
    }

    public IResult GetCarsByBrandId(int id)
    {
        List<Car> cars = _carDal.GetAll(indexedCar => indexedCar.BrandId == id)??null;
        Console.WriteLine($"GetCarsByBrandId: {cars.Count}");
        return cars;
    }

    public IResult GetCarsByColorId(int id)
    {
        List<Car> cars = _carDal.GetAll(indexedCar => indexedCar.ColorId == id)??null;
        Console.WriteLine($"GetCarsByColorId: {cars.Count}");
        return cars;
    }

    public void GetCarWithDetails()
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
    }
}