﻿using Business.Abstract;
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

    public IResult Add(Rental entity)
    {
        _rentalDal.Add(entity);
        return new SuccessResult("Kiralık Araç Eklendi");
    }

    public IDataResult<List<Rental>> GetAll()
    {
        return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
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