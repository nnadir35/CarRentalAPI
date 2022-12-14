using Entities.Concrete;
using Entities.ViewModels;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class CarValidator:AbstractValidator<Car>
{
    public CarValidator()
    {
        RuleFor(car => car.BrandId).NotEmpty();
        RuleFor(car => car.ColorId).NotEmpty();
        RuleFor(car => car.ModelYear).GreaterThan(1900).LessThan(DateTime.Today.Year);
    }
}