namespace Entities.ViewModels;

public class AddRentalVm
{
    
    public int UserId { get; set; }
    public AddCarVm AddCarVm { get; set; }
    public bool IsRented { get; set; } = true;
    public DateTime? RentDate { get; set; } = null;

    public DateTime? ReturnDate { get; set; } = null;
}