using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers;



[ApiController]
[Route("[controller]")]
public class RentalController:ControllerBase
{
    private IRentalService _rentalService;

    public RentalController(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }


    [HttpGet]
    public IDataResult<List<Rental>> Get()
    {
        return _rentalService.GetAll();
    }
    
    [HttpPost]
    public IResult Add(AddRentalVm addRentalVm)
    {
        Rental rental = new Rental()
        {
            RentDate = addRentalVm.RentDate,
            ReturnDate = addRentalVm.ReturnDate,
            UserId = addRentalVm.UserId
        };
        
        rental.Car.BrandId = addRentalVm.AddCarVm.BrandId;
        rental.Car.ColorId = addRentalVm.AddCarVm.ColorId;
        rental.Car.ModelYear = addRentalVm.AddCarVm.ModelYear;
        
        return _rentalService.Add(rental);
    }
}