using Core.Entities;

namespace Entities.Concrete;

public class Brand:BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}