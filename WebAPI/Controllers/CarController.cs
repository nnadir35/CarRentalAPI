using Business.Concrete;
using Core;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private CarDbContext _carDbContext;

    private readonly ILogger<CarController> _logger;

    private ICarDal _carDal;

    public CarController(ILogger<CarController> logger, CarDbContext carDbContext, ICarDal carDal)
    {
        _logger = logger;
        _carDbContext = carDbContext;
        _carDal = carDal;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public List<Car> Get()
    {
        return new List<Car>();
    }
    
    [HttpPost]
    public IActionResult Add(Car car)
    {
        CarManager carManager = new CarManager(_carDal);
        carManager.Add(car:car);
        return Ok();
    }
}