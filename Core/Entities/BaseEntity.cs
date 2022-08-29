using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public abstract class BaseEntity
{   public virtual int Id { get; set; }
    public bool Active { get; set; } = true;
}