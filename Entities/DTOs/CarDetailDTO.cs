using Entities.Abstract;

namespace Entities.DTOs;

public class CarDetailDto:IDto
{
    public int UserId { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public string Brand { get; set; }
    public float DailyPrice { get; set; }
}