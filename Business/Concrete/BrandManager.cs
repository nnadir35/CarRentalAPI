using System.Linq.Expressions;
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

    public IResult Add(Brand entity)
    {
        var isRecordExist = IsRecordExist(entity);
        if (isRecordExist.Data)
        {
            return new ErrorResult(isRecordExist.Message);
        }
        else
        {
            _brandDal.Add(entity);
            return new SuccessResult("veri başarıyla eklendi");
        }
    }

    public IDataResult<List<Brand>> GetAll()
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
    }

    public IDataResult<Brand> GetById(Expression<Func<Brand, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public IDataResult<bool> IsRecordExist(Brand entity)
    {
        return _brandDal.IsRecordExist(brand =>brand.Name == entity.Name );

    }
}