using Abc.Data.Common;

namespace Abc.Data.Consultation;

public sealed class UserRole : BaseEntity
{
    public Guid RoleId { get; set; }
    public Guid UserId { get; set; }
}