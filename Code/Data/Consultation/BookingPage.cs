using Abc.Data.Common;

namespace Abc.Data.Consultation;

public sealed class BookingPage : BaseEntity
{
    public DateTime BookingDate { get; set; }
    public string Note { get; set; } = string.Empty;
    public Guid SlotId { get; set; }
    public string Status { get; set; } = string.Empty;
    public Guid StudentId { get; set; }

    public ConsultationSlot? Slot { get; set; }
    public User? Student { get; set; }
}