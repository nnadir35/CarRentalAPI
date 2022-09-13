using System.Linq.Expressions;
using Core;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal:EfEntityRepositoryBase<Car,CarRentalDbContext>,ICarDal
{
    public List<CarDetailDto> GetCarsWithDetails()
    {
        using (CarRentalDbContext carRentalDbContext = new CarRentalDbContext())
        {
            var carDetailDtos = from car in carRentalDbContext.Cars
                join color in carRentalDbContext.Colors
                    on car.ColorId equals color.Id
                join brand in carRentalDbContext.Brands
                    on car.BrandId equals brand.Id
                join user in carRentalDbContext.Users on car.Rental.UserId equals user.Id
                select new CarDetailDto()
                {
                    UserId = user.Id,
                    Brand = brand.Name,
                    Color = color.Name,
                };
            return carDetailDtos.Where(dto => dto.UserId==20).ToList();
        }
        
    }
}