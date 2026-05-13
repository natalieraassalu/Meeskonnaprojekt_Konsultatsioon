using Abc.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Data.Consultation;

public class Lecturer : NamedEntity
{
    public string Email { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
}