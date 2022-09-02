using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IRentalService:IBaseService<Rental>
{
    IResult RentACar(Rental rental,DateTime dateTime);
}