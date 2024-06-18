using System;
using System.Collections.Generic;

namespace EMIAS.Models;

public partial class AnalysDocument
{
    public int? IdAppointment { get; set; }

    public string Rtf { get; set; } = null!;
    
    public string DocumentName { get; set; }
}
