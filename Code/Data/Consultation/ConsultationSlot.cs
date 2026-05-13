using Abc.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Data.Consultation;

public class ConsultationSlot : BaseEntity
{
    public Guid CourseId { get; set; }
    public Guid LecturerId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string MeetingLink { get; set; } = string.Empty;
    public bool IsBooked { get; set; }
}