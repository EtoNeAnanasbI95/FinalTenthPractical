using System;
using System.Collections.Generic;

namespace EMIAS.Models;

public partial class Appointment
{
    public int? IdAppointment { get; set; }

    public DateOnly AppointmentDate { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public int? DoctorId { get; set; }

    public long? Oms { get; set; }

    public int? StatusId { get; set; }
}
