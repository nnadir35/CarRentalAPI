using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public IDataResult<List<ListCarVm>> Get()
    {
        var data = _carService.GetAll();
        List<ListCarVm> listCarVms = new List<ListCarVm>();
        foreach (Car carData in data.Data)
        {
            var carVm = new ListCarVm()
            {
               Description = carData.Description,
               BrandId = carData.BrandId,
               ColorId = carData.ColorId,
               DailyPrice = carData.DailyPrice,
               ModelYear = 2005,
               RentalId = carData.RentalId
            };
            listCarVms.Add(carVm);
        }
        return new SuccessDataResult<List<ListCarVm>>(listCarVms);
    }

    [HttpGet("getbyid")]
    public IDataResult<ListCarVm> GetById(int id)
    {
        var carData = _carService.GetById(car => car.Id == id);
        Console.WriteLine(carData.Success);
        if (carData.Success)
        {
            var carDataResult = carData.Data;
            var carVm = new ListCarVm()
            {
                Description = carDataResult.Description,
                BrandId = carDataResult.BrandId,
                ColorId = carDataResult.ColorId,
                DailyPrice = carDataResult.DailyPrice,
                ModelYear = carDataResult.ModelYear,
                RentalId = carDataResult.RentalId
            };
            return new DataResult<ListCarVm>(carData.Success, carVm);
        }

        return new ErrorDataResult<ListCarVm>(null, "yok");
    }
    
    [HttpPost]
    public IResult Add(AddCarVm car)
    {
        Car added = new Car();

        added.Description = car.Description;
        added.BrandId = car.BrandId;
        added.ColorId = car.ColorId;
        added.DailyPrice = car.DailyPrice;
        added.ModelYear = car.ModelYear;
        added.RentalId = 28;
        var action = _carService.Add(added);
        return new Result(action.Success,action.Message);
    }
}