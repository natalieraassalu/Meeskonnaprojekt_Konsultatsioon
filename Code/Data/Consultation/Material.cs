using Abc.Aids;
using Abc.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Abc.Data.Consultation;

public sealed class Material : NamedEntity
{ 
    [Random(3, 5, "0123456789")] public string Number { get; set; } = "";
    [Random(10, 30)] public string Author { get; set; } = "";
    [Random(20, 50)] public string Details { get; set; } = "";
    public ICollection<CourseMaterial> CourseMaterials { get; set; } = [];
    public ICollection<Course> Courses => [.. CourseMaterials.Select(cm => cm.Course)];
    [Timestamp] public byte[] Timestamp { get; set; } = [];
}
