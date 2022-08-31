using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entities.Concrete;

public class Rental:BaseEntity
{
    [ForeignKey(nameof(UserId))]
    public int UserId { get; set; }
    public Car Car { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime? ReturnDate { get; set; } = null;
}