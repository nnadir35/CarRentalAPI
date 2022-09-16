using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal:EfEntityRepositoryBase<Customer,CarRentalDbContext>,IUserDal
{
    
}