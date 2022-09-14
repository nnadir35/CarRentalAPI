using AutoMapper;
using Entities.Concrete;
using Entities.ViewModels;

namespace Business.Mapper;

public class CarProfile:Profile
{
    public CarProfile()
    {
        CreateMap<Car, AddCarVm>();
        CreateMap<AddCarVm, Car>();
    }
}