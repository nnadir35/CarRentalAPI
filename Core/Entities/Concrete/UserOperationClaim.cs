using Core.Entities;

namespace Entities.Concrete;

public class UserOperationClaim:BaseEntity
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}