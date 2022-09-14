using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class RentalValidator:AbstractValidator<Rental>
{
    public RentalValidator()
    {
        RuleFor(rental => rental.Car.BrandId).NotEqual(0);
        RuleFor(rental => rental.Car.ColorId).NotEqual(0);
        RuleFor(rental => rental.Car.ModelYear).GreaterThan(1900).LessThan(DateTime.Now.Year);
        RuleFor(rental => rental.DailyPrice).GreaterThan(1);
        RuleFor(rental => rental.ReturnDate.Value.Day).NotEqual(DateTime.Now.Day);
    }
}