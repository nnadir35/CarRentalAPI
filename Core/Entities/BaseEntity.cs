using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public abstract class BaseEntity
{   public virtual int Id { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}