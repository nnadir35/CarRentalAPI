using System.Linq.Expressions;
using Core;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal:EfEntityRepositoryBase<Car,CarDbContext>,ICarDal
{
    public List<CarDetailDto> GetCarsWithDetails()
    {
        using (CarDbContext carDbContext = new CarDbContext())
        {
            var carDetailDtos = from car in carDbContext.Cars
                join color in carDbContext.Colors
                    on car.ColorId equals color.Id
                join brand in carDbContext.Brands
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