using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete;

public class Customer:BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public ICollection<OperationClaim> OperationClaimsList { get; set; }
    public ICollection<Rental> RentalList { get; set; }
    
}