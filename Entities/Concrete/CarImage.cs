using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entities.Concrete;

public class CarImage:BaseEntity
{
    [ForeignKey("Car")]
    public int CarId { get; set; }
    public Car Car { get; set; }
    public string ImagePath { get; set; }
    public DateTime AddedTime { get; set; }=DateTime.Now;
}