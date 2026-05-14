using Abc.Data.Common;

namespace Abc.Data.Consultation;

public sealed class ConsultationSlot : BaseEntity
{
    public Guid LecturerId { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsBooked { get; set; }
    public string MeetingLink { get; set; } = string.Empty;

    public User? Lecturer { get; set; }
}