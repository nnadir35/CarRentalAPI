using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

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
    public List<Car> Get()
    {
        return new List<Car>();
    }
    
    [HttpPost]
    public IActionResult Add(Car car)
    {
        _carService.Add(car);
        return Ok();
    }
}