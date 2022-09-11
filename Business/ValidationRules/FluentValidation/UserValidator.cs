using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class UserValidator:AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Email).Must(IsEmailValid).WithMessage("Geçersiz e-posta formatı");
        RuleFor(user => user.Password).MinimumLength(6);
        RuleFor(user => user.Name).NotEmpty();
        RuleFor(user => user.Surname).NotEmpty();
    }

    private bool IsEmailValid(string email)
    {
        return EmailValidator.IsEmailValid(email).Success;
    }
}