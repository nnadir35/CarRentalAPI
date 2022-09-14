using AutoMapper;
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
    private readonly IRentalService _rentalService;
    private readonly IMapper _mapper;

    public RentalController(IRentalService rentalService,IMapper mapper)
    {
        _rentalService = rentalService;
        _mapper = mapper;
    }


    [HttpGet]
    public IDataResult<List<Rental>> Get()
    {
        return _rentalService.GetAll();
    }
    
    [HttpPost]
    public IResult Add(AddRentalVm addRentalVm)
    {
        var rental = _mapper.Map<AddRentalVm, Rental>(addRentalVm);
        return _rentalService.Add(rental);
    }
}