﻿using Business.Abstract;
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
        if (car.Description.Length < 2) return new ErrorResult("Araba açıklaması 2 karakterden büüyk olmalıdır.");
        if (car.DailyPrice <= 0) return new ErrorResult("Günlük kiralama bedeli pozitif olmalıdır");
        _carDal.Add(car);
        return new SuccessResult("eklendi");
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
        return new SuccessDataResult<List<CarDetailDto>>(carDetailDtos);
    }
}