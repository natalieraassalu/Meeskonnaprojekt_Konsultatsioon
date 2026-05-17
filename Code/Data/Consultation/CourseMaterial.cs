using System.ComponentModel.DataAnnotations;
using Abc.Aids;
using Abc.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Abc.Data.Consultation;

public sealed class CourseMaterial : BaseEntity
{
    [Select(typeof(Course))] public Guid? CourseId { get; set; }
    [Select(typeof(Material))] public Guid? MaterialId { get; set; }

    public Course? Course { get; set; }
    public Material? Material { get; set; }
    [Timestamp] public byte[] Timestamp { get; set; } = [];
}