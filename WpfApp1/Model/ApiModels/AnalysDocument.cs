namespace EMIAS.Models;

public class AnalysDocument
{
    public int? IdAppointment { get; set; }

    public string Rtf { get; set; } = null!;

    public string DocumentName { get; set; }
}