namespace Entities.ViewModels;

public class AddRentalVm
{
    
    public int UserId { get; set; }
    public AddCarVm AddCarVm { get; set; }
    public string Description { get; set; }
    public float DailyPrice { get; set; }
    public DateTime? RentDate { get; set; } = null;

    public DateTime? ReturnDate { get; set; } = null;
}