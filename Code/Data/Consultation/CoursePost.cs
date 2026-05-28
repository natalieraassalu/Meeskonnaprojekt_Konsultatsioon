using Abc.Data.Common;

namespace Abc.Data.Consultation;

// A short announcement or note posted to a course (like a feed item).
public class CoursePost : BaseEntity
{
    // The course this post belongs to.
    public Guid CourseId { get; set; }

    // Title of the post shown in the list.
    public string Title { get; set; } = "";

    // Full body text of the post.
    public string Body { get; set; } = "";

    // When the post was created (defaults to now so it's set on creation).
    public DateTime PostedAt { get; set; } = DateTime.Now;
}
