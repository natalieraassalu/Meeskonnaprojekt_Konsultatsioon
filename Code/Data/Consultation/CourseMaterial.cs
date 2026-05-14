using Abc.Data.Common;

namespace Abc.Data.Consultation;

public sealed class CourseMaterial : BaseEntity
{
    public Guid CourseId { get; set; }
    public Guid MaterialId { get; set; }

    public Course? Course { get; set; }
    public Material? Material { get; set; }
}