using Abc.Data.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.Data.Consultation;

public class CourseConsultation : BaseEntity {
    public Guid CourseId { get; set; }
    public Guid ConsultationSlotId { get; set; }

    [NotMapped] public Course? Course { get; set; }
    [NotMapped] public ConsultationSlot? ConsultationSlot { get; set; }
}
