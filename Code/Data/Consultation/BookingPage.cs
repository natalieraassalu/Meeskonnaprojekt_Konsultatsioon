using Abc.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Data.Consultation;

public class BookingPage : BaseEntity
{
    public Guid SlotId { get; set; }
    public Guid StudentId { get; set; }
    public DateTime BookingDate { get; set; }
    public string Note { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}