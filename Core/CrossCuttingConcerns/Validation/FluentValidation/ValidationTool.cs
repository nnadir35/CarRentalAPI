using FluentValidation;
using FluentValidation.Results;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                string errorMessages = "";
                foreach (ValidationFailure failure in result.Errors)
                {
                    errorMessages += '\n' + failure.ErrorMessage;
                }
               throw new ValidationException(errorMessages);
            }
        }
    }
}