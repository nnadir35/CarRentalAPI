using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Business.Abstract;
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


    public IResult Add(User user)
    {
        bool isUserExist = CheckUserEmailExist(user: user);
        if (isUserExist) return new ErrorResult("Girilen e-posta adresiyle ilişkili hesap bulunmaktadır");
        if (EmailValidator.IsEmailValid(user.Email).Success == false) return new ErrorResult("Geçersiz e-posta");
        _userDal.Add(user);
        return new SuccessResult("Kullanıcı veritabanına eklendi");
    }

    public IDataResult<List<User>> GetAll()
    {
        return new SuccessDataResult<List<User>>(_userDal.GetAll());
    }

    public IDataResult<User> GetById(Expression<Func<User, bool>> filter)
    {
        return new SuccessDataResult<User>(_userDal.Get(filter));
    }

    public bool CheckUserEmailExist(User user)
    {
        var result = _userDal.IsRecordExist(user1 => user1.Email == user.Email);
        return result.Data;
    }

    
}