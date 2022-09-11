using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entities.Concrete;

public class Car:BaseEntity
{
    
    public int BrandId { get; set; }
    public int ColorId { get; set; }
    [ForeignKey("Rental")]
    public int RentalId { get; set; }
    public Rental Rental { get; set; }
    public string Description { get; set; }
    public int ModelYear { get; set; }
    public float DailyPrice { get; set; }
    public List<CarImage>? CarImages { get; set; }
}