using Abc.Aids;
using Abc.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Abc.Data.Consultation;

public sealed class ConsultationSlot : BaseEntity
{
    [Select(typeof(User))] public Guid? LecturerId { get; set; }

    [DataType(DataType.DateTime)] public DateTime StartTime { get; set; }
    [DataType(DataType.DateTime)] public DateTime EndTime { get; set; }
    public bool IsBooked { get; set; }
    public string MeetingLink { get; set; } = string.Empty;

    public User? Lecturer { get; set; }

    // A consultation slot's schedule is StartTime/EndTime; the generic ValidFrom/ValidTo
    // inherited from BaseEntity is redundant here, so hide it from the auto-generated UI.
    // Overriding (as Movie does for ValidFrom) keeps EF mapping the existing columns.
    [ScaffoldColumn(false)] public override DateTime? ValidFrom { get; set; }
    [ScaffoldColumn(false)] public override DateTime? ValidTo { get; set; }
}