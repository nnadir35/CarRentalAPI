using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entities.Concrete;

public class OperationClaim:BaseEntity
{
    public string ClaimName { get; set; }
}