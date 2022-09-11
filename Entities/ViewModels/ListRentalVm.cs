using Entities.Concrete;

namespace Entities.ViewModels;

public class ListRentalVm
{
    
    
    public int UserId { get; set; }
        public Car Car { get; set; }
    public bool IsRented { get; set; } = true;
    public DateTime? RentDate { get; set; } = null;

    public DateTime? ReturnDate { get; set; } = null;
}