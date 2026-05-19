using Abc.Aids;
using Abc.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Abc.Data.Consultation;

public sealed class Course : NamedEntity
{
    [Random(6, 8, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")]
    public string Code { get; set; } = "";

    [Random(20, 100)]
    public string Details { get; set; } = "";

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }

    public ICollection<CourseMaterial> CourseMaterials { get; set; } = [];

    [Timestamp] public byte[] Timestamp { get; set; } = [];
}