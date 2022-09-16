using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entities.Concrete;

public class Rental:BaseEntity
{
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    public Customer Customer { get; set; }
    public Car Car { get; set; }
    public bool IsRented { get; set; } = true;
    
    public float DailyPrice { get; set; }
    
    public string Description { get; set; }
    public DateTime? RentDate { get; set; } = null;

    public DateTime? ReturnDate { get; set; } = null;
}