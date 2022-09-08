﻿using Entities.Concrete;
using Entities.ViewModels;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class CarValidator:AbstractValidator<AddCarVm>
{
    public CarValidator()
    {
        RuleFor(car => car.Description).NotEmpty();
        RuleFor(car => car.BrandId).NotEmpty();
        RuleFor(car => car.ColorId).NotEmpty();
        RuleFor(car => car.DailyPrice).GreaterThan(0);
        RuleFor(car => car.ModelYear).GreaterThan(1900);
    }
}