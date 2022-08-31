// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

DateTime dateTime = DateTime.Now;
//
// Car car = new Car()
// {
//     Description = $"{dateTime}",
//     BrandId = 1,
//     ColorId = 1,
//     DailyPrice = 100,
//     ModelYear = 1999
// };
// CarManager carManager = new CarManager(new EfCarDal());
// //carManager.Add(car);
// BrandManager brandManager = new BrandManager(new EfBrandDal());
//
// var cars =  carManager.GetAll();
//
// var carsss = cars.Data.FindAll(indexedCar => indexedCar.BrandId ==1);
// Console.WriteLine($"carsss length: {carsss.Count}");
//
// carManager.GetCarWithDetails();
//
//
// carManager.GetCarsByColorId(2);
// carManager.GetCarsByBrandId(3);
//
// Brand brand = new Brand()
// {
//     Name = "RENAULT"
// };
// var isRecordExist = brandManager.IsRecordExist(brand);
// var addNewBrand = brandManager.Add(brand);
//
// Console.WriteLine(addNewBrand.Success);
// Console.WriteLine(addNewBrand.Message);
//
// CarRentalDbContext carRentalDbContext = new CarRentalDbContext();
// var asd = await carRentalDbContext.Cars.CountAsync(car1 => car1.ColorId==2);
// Console.WriteLine("asd: "+asd);
UserManager userManager = new UserManager(new EfUserDal());

User user = new User()
{
    Name = "Nadircan",
    Surname = "Alkış",
    Email = "nadir@gmail.com",
    Password = "asd",
};

//var addUser = userManager.Add(user);


//Console.WriteLine(addUser.Message);
// Console.WriteLine(EmailValidator.IsEmailValid(user.Email).Success);
// Console.WriteLine(EmailValidator.IsEmailValid(user.Email).Message);
Console.WriteLine("EmailValidationRegexCompiled:  "+EmailValidator.EmailValidationRegexCompiled.IsMatch(user.Email).ToString());
