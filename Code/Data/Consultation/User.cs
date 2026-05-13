using Abc.Data.Common;

namespace Abc.Data.Consultation;

public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}