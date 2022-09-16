using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ViewModels;

namespace Business.Concrete;

public class UserManager:IUserService
{
    private IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }
    
    
    [ValidationAspect(typeof(UserValidator))]
    public IResult Add(Customer customer)
    {
        if (CheckUserEmailExist(customer))
            return new ErrorResult("Bu email' e kayıtlı kullanıcı bulunmaktadır");
        _userDal.Add(customer);
        return new SuccessResult("Kullanıcı veritabanına eklendi");
    }

    public IDataResult<List<Customer>> GetAll()
    {
        return new SuccessDataResult<List<Customer>>(_userDal.GetAll());
    }

    public IDataResult<Customer> GetById(Expression<Func<Customer, bool>> filter)
    {
        return new SuccessDataResult<Customer>(_userDal.Get(filter));
    }

    public bool CheckUserEmailExist(Customer customer)
    {
        var result = _userDal.IsRecordExist(user1 => user1.Email == customer.Email);
        return result.Data;
    }

    
}