using System.Linq.Expressions;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class RentalManager:IRentalService
{
    
    private readonly IRentalDal _rentalDal;
    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }

    
    [ValidationAspect(typeof(RentalValidator))]
    public IResult Add(Rental entity)
    {
        _rentalDal.Add(entity);
        return new SuccessResult("Kiralık Araç Eklendi");
    }

    public IDataResult<List<Rental>> GetAll()
    {
        // var rentaList = _rentalDal.GetAll(rental => rental.User.Id != id);
        // foreach (Rental rental in rentaList)
        // {
        //     new 
        // }
        return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
    }

    public IDataResult<Rental> GetById(Expression<Func<Rental, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public IDataResult<Rental> Get(Expression<Func<Rental,bool>> expression)
    {
        return new SuccessDataResult<Rental>(_rentalDal.Get(expression));
    }
    public IResult RentACar(Rental rental,DateTime dateTime)
    {
        Rental selectedRental = _rentalDal.Get(filterRental =>filterRental.Id==rental.Id);
        if (selectedRental.IsRented) return new ErrorResult("Araç zaten başkası tarafından kiralanmış");
        selectedRental.IsRented = true;
        selectedRental.RentDate = DateTime.Now;
        selectedRental.ReturnDate = dateTime;
        _rentalDal.Update(selectedRental);
        return new SuccessResult("Araç kiralandı");
    }
}