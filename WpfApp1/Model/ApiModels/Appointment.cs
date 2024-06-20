namespace EMIAS.Models;

public class Appointment
{
    public int? IdAppointment { get; set; }

    public DateOnly AppointmentDate { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public int? DoctorId { get; set; }

    public long? Oms { get; set; }

    public int? StatusId { get; set; }
}