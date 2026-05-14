using Abc.Data.Common;

namespace Abc.Data.Consultation;

public sealed class Notification : BaseEntity
{
    public Guid ConsultationSlotId { get; set; }
    public Guid LecturerId { get; set; }
    public Guid StudentId { get; set; }

    public string Message { get; set; } = string.Empty;
    public DateTime SentAt { get; set; }
    public string Status { get; set; } = string.Empty;

    public ConsultationSlot? ConsultationSlot { get; set; }
    public User? Lecturer { get; set; }
    public User? Student { get; set; }
}