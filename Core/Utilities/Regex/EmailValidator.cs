using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Core.Utilities.Results;

public static class EmailValidator
{
    public static readonly string EmailValidationRegex = @"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

    public static readonly Regex EmailValidationRegexCompiled =
        new Regex(EmailValidationRegex, RegexOptions.IgnoreCase);


    public static IResult IsEmailValid(string email)
    {
        if (email is null) return new ErrorResult("Email adresi boş bırakılamaz");
        //IsMatch == email is valid
        if (!(EmailValidationRegexCompiled.IsMatch(email)) )return new ErrorResult();
        return new SuccessResult();
    }

}