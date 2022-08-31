using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IUserService:IBaseService<User>
{
    bool CheckUserEmailExist(User user);
}