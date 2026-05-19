using Abc.Data.Common;

namespace Abc.Data.Consultation;

public sealed class CourseSelector : BaseEntity
{
    public Guid CourseId { get; set; }
    public Guid LecturerId { get; set; }
    public Guid StudentId { get; set; }

    public Course? Course { get; set; }
    public User? Lecturer { get; set; }
    public User? Student { get; set; }
}