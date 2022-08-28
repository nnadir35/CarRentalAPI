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
                select new CarDetailDto()
                {
                    Description = car.Description,
                    Brand = brand.Name,
                    Color = color.Name,
                    DailyPrice = car.DailyPrice
                };
            return carDetailDtos.ToList();
        }
        
    }
}