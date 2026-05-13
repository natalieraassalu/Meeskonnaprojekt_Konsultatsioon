using Abc.Aids;
using System.ComponentModel.DataAnnotations;

namespace Abc.Data.Common;

    public class BaseEntity
    {
    public virtual Guid Id { get; set; } = Guid.NewGuid();
    [Random(-50, -1)] public virtual DateTime? ValidFrom { get; set; }
    [Random(2, 10)] public virtual DateTime? ValidTo { get; set; }
}

