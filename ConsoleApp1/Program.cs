// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
DateTime dateTime = DateTime.Now;

Car car = new Car()
{
    Description = $"{dateTime}",
    BrandId = 1,
    ColorId = 1,
    DailyPrice = 100,
    ModelYear = 1999
};
CarManager carManager = new CarManager(new EfCarDal());
//carManager.Add(car);
BrandManager brandManager = new BrandManager(new EfBrandDal());

var cars =  carManager.GetAll();

var carsss = cars.Data.FindAll(indexedCar => indexedCar.BrandId ==1);
Console.WriteLine($"carsss length: {carsss.Count}");

carManager.GetCarWithDetails();


carManager.GetCarsByColorId(2);
carManager.GetCarsByBrandId(3);

Brand brand = new Brand()
{
    Name = "RENAULT"
};
var isRecordExist = brandManager.IsRecordExist(brand);
var addNewBrand = brandManager.Add(brand);

Console.WriteLine(addNewBrand.Success);
Console.WriteLine(addNewBrand.Message);