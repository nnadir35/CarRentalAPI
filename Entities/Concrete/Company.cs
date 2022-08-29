using Core.Entities;

namespace Entities.Concrete;
     
public class Company:BaseEntity
{
    public string CompanyName { get; set; }
    private List<Rental> RentalList { get; set; }
}