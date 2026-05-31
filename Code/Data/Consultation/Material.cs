using Abc.Aids;
using Abc.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Abc.Data.Consultation;

public sealed class Material : NamedEntity
{
    [Random(3, 5, "0123456789")] public string Number { get; set; } = "";

    [Random(10, 30)] public string Author { get; set; } = "";

    // Excluded from Blazor form binding to break the Material<->CourseMaterial<->Course
    // reference cycle (see Course.CourseMaterials). EF/JSON serialization unaffected.
    [IgnoreDataMember] public ICollection<CourseMaterial> CourseMaterials { get; set; } = [];

    [Timestamp] public byte[] Timestamp { get; set; } = [];
}