using AutoMapper;
using Entities.Concrete;
using Entities.ViewModels;

namespace Business.Mapper;

public class RentalProfile:Profile
{
    public RentalProfile()
    {
        CreateMap<Rental,AddRentalVm>().ForMember(vm => vm.AddCarVm ,
            opt =>opt.MapFrom(rental => rental.Car));
        CreateMap<AddRentalVm, Rental>().ForMember(rental => rental.Car,
            expression => expression.MapFrom(vm => vm.AddCarVm));
    }
}