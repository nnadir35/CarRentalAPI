using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IUserService:IBaseService<Customer>
{
    bool CheckUserEmailExist(Customer customer);
}