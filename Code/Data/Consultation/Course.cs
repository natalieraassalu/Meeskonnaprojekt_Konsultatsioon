using Abc.Aids;
using Abc.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Abc.Data.Consultation;

public sealed class Course : NamedEntity
{
    // Navigation collection: excluded from Blazor form binding ([IgnoreDataMember])
    // to break the Course<->CourseMaterial<->Material reference cycle, which would
    // otherwise exceed the form mapper's max recursion depth. EF mapping and the
    // System.Text.Json API (which honors [JsonIgnore], not this) are unaffected.
    [IgnoreDataMember] public ICollection<CourseMaterial> CourseMaterials { get; set; } = [];

    [Timestamp] public byte[] Timestamp { get; set; } = [];
}