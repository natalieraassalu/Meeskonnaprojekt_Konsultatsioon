using Abc.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abc.Data.Consultation;

public class CourseSelector : BaseEntity
{
    public Guid CourseId { get; set; }
    public Guid LecturerId { get; set; }
    public Guid StudentId { get; set; }
}