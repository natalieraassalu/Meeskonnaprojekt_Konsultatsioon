using Abc.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Data.Consultation;

public class Notification : BaseEntity
{
    public Guid ConsultationSlotId { get; set; }
    public Guid LecturerId { get; set; }
    public Guid StudentId { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime SentAt { get; set; }
    public string Status { get; set; } = string.Empty;
}