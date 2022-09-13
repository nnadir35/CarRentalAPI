// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
DateTime dateTime = DateTime.Now;
CarManager carManager = new CarManager(new EfCarDal());
var addedDays = dateTime.AddDays(1.0);
UserManager userManager = new UserManager(new EfUserDal());

User user = new User()
{
    Name = "Nadircan",
    Surname = "Alkış",
    Email = "nadir@gmail.com",
    Password = "123",
    RentalList = new List<Rental>()
    {
        new Rental()
        {
            Car = new Car()
            {
                BrandId = 1,
                ColorId = 2,
            }
        }
    }
    
};
//var addUser = userManager.Add(user);
RentalManager rentalManager = new RentalManager(new EfRentalDal());

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var newCar = new Car()
{
    BrandId = 1,
    ColorId = 1,
    ModelYear = 2005
};
//var asdasdasda =carManager.Add(newCar);
//Console.WriteLine(asdasdasda.Message);
 Rental rental = new Rental()
 { 
     UserId = 1,
 };
rentalManager.Add(rental);
// var carWithDetails = carManager.GetCarWithDetails().Data;
// foreach (CarDetailDto dto in carWithDetails)
// {
//     //Console.WriteLine(dto.ToString());
//     Console.WriteLine($"{dto.Brand}/ {dto.Color}/ {dto.Description}/ {dto.DailyPrice}/ {dto.UserId}");
// }
// Console.WriteLine("rental.Id: "+rental.Id);
//
// Console.WriteLine("rental.Id: "+rental.Car.Id);
//var asdsdsdf= rentalManager.RentACar(rental2, DateTime.Today.AddDays(4.0));
//Console.WriteLine(asdsdsdf.Message);
rentalManager.GetAll();
Console.WriteLine(rentalManager.Get(rental1 => rental1.Id == 20));