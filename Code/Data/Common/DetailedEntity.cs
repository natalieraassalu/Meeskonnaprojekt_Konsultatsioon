using Abc.Aids;

namespace Abc.Data.Common;

    public class DetailedEntity:BaseEntity
    {
    [Random(15, 31)] public virtual string Details { get; set; } = "";
}

