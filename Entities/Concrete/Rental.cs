using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entities.Concrete;

public class Rental:BaseEntity
{
    [ForeignKey("CompanyId")]
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public Car Car { get; set; }
    private DateTime RentDate { get; set; }
    public DateTime? ReturnDate { get; set; } = null;
    public bool IsActive { get; set; }
}