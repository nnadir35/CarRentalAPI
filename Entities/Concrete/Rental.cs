using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entities.Concrete;

public class Rental:BaseEntity
{
    [ForeignKey("User")]
    public int UserId { get; set; }

    public User User { get; set; }
    public Car Car { get; set; }
    public bool IsRented { get; set; }
    public DateTime? RentDate { get; set; } = null;

    public DateTime? ReturnDate { get; set; } = null;
}