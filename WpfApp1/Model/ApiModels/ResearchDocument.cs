namespace EMIAS.Models;

public class ResearchDocument
{
    public int? IdAppointment { get; set; }

    public string Rtf { get; set; } = null!;

    public byte[]? Attachment { get; set; }

    public string DocumentName { get; set; }
}