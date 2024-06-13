using System;
using System.Collections.Generic;

namespace EMIAS.Models;

public partial class AppointmentDocument
{
    public int? IdAppointment { get; set; }

    public string Rtf { get; set; } = null!;
}
