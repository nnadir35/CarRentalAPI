using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class BrandManager:IBrandService
{
    private IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }
    public IResult AddNewBrand(Brand brand)
    {
        throw new NotImplementedException();
    }

    public IResult Add(Brand entity)
    {
        throw new NotImplementedException();
    }

    public IDataResult<List<Brand>> GetAll()
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
    }

    public IDataResult<bool> IsRecordExist(Brand entity)
    {
        return _brandDal.IsRecordExist(brand =>brand.Name == entity.Name );

    }
}