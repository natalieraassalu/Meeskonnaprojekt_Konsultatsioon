using Abc.Data.Common;
using System;

namespace Abc.Data.Consultation;

public class CourseConsultation : BaseEntity
{
    public Guid CourseId { get; set; }
    public Guid ConsultationSlotId { get; set; }
}