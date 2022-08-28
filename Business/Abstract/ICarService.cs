using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICarService
{
    IResult GetCarsByBrandId(int id);
    IResult GetCarsByColorId(int id);
}